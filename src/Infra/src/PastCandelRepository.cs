using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain;

using ccxt;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace BotTrade.Infra;
public class PastCandleRepository : IUpdatableCandleRepository, IDisposable
{
    private const string TABLE_NAME = "candles";
    private Symbol Symbol { get; init; }
    private SqliteConnection Connection { get; init; }
    private ILogger<PastCandleRepository> Logger { get; init; }
    private Subject<Candle> PulledSubject { get; } = new Subject<Candle>();

    public IObservable<Candle> OnPulled => PulledSubject;

    public PastCandleRepository(Setting.Exchange setting, ILogger<PastCandleRepository> logger)
    {
        var path = $"{setting.Place.GetStringValue()}.sqlite3";
        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = Path.GetFullPath(path),
        };
        Symbol = setting.Symbol;
        Logger = logger;
        Connection = new SqliteConnection(builder.ConnectionString);
        Connection.Open();

        var sql = $"""
                create table if not exists {TABLE_NAME} (
                    symbol TEXT NOT NULL,
                    timestamp BIGINT NOT NULL,
                    open FLOAT,
                    high FLOAT,
                    low FLOAT,
                    close FLOAT,
                    volume FLOAT,
                    PRIMARY KEY(symbol,timestamp)
                )
            """;
        using var command = new SqliteCommand(sql, Connection);
        command.ExecuteReader();
    }

    public void Dispose()
    {
        Connection.Close();
        Connection.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Fetch()
    {
        var fetchLastTimestampSQL = $"""
            select timestamp from {TABLE_NAME}
            where symbol='{Symbol.GetStringValue()}'
            order by timestamp desc
            limit 1
        """;
        // TODO: Configに切り出す
        // MEMO: 前回更新時の最新時間。存在しない場合はとりあえず2018/1/1
        var lastTime = new DateTimeOffset(new DateTime(2018, 1, 1)).ToUnixTimeSeconds();

        try
        {
            using var command = new SqliteCommand(fetchLastTimestampSQL, Connection);
            using var reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                lastTime = DateTimeOffset.UnixEpoch.AddMilliseconds(reader.GetDouble(0)).ToUnixTimeMilliseconds();
                Logger.LogInformation($"前回更新時: {lastTime}");
            }
        }
        catch
        {
            Logger.LogWarning("前回更新のデータが存在しないため、取引所から取得可能なデータをすべて取得する。これにはかなり時間がかかる。");
        }
        var constructor = typeof(ccxt.bybit).GetConstructor([typeof(object)]);
        if (constructor?.Invoke([null]) is ccxt.Exchange exchange)
        {
            var limit = 1000;
            // 確定足情報を取得するため１分前の情報から取得していく
            var latest = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1));
            IEnumerable<OHLCV> ohlcvs;
            while (true)
            {
                var since = latest.Subtract(TimeSpan.FromMinutes(limit)).ToUnixTimeMilliseconds();
                ohlcvs = await exchange.FetchOHLCV(Symbol.GetStringValue(), since2: since, limit2: limit);
                ohlcvs = ohlcvs.Where(e => lastTime < e.timestamp && e.timestamp <= latest.ToUnixTimeMilliseconds());

                if (!ohlcvs.Any())
                    break;

                Logger.LogInformation($"Fetched since: {DateTimeOffset.FromUnixTimeMilliseconds(since)}, count: {ohlcvs.Count()}");

                var values = ohlcvs.Select(e => $@"('{Symbol.GetStringValue()}', '{e.timestamp}', '{e.open}', '{e.high}', '{e.low}', '{e.close}', '{e.volume}')");
                var insertOhlcvSQL = $@"
                        insert into {TABLE_NAME}
                        (Symbol,timestamp,open,high,low,close,volume)
                        values {string.Join(", ", values)}";

                using var transaction = Connection.BeginTransaction();
                using var command = new SqliteCommand(insertOhlcvSQL, Connection, transaction);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    Logger.LogError("データ更新に失敗");
                    throw;
                }

                latest = DateTimeOffset.FromUnixTimeMilliseconds(since);
                await Task.Delay(TimeSpan.FromMilliseconds(exchange.rateLimit));
            }
            Logger.LogInformation("データベース更新完了");
            return;
        }

        Logger.LogWarning("ccxtに対応していない取引所");
    }

    public async Task Pull()
    {
        var sql = $"""
                    select * from {TABLE_NAME}
                    where symbol='{Symbol.GetStringValue()}'
                    order by timestamp asc
                """;

        try
        {

            using var command = new SqliteCommand(sql, Connection);
            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                var index = 1;
                var date = DateTime.UnixEpoch.AddMilliseconds(reader.GetDouble(index++));
                var open = reader.GetDecimal(index++);
                var high = reader.GetDecimal(index++);
                var low = reader.GetDecimal(index++);
                var close = reader.GetDecimal(index++);
                var volume = reader.GetDecimal(index++);
                var candle = new Candle(Symbol, date, open, high, low, close, volume);

                PulledSubject.OnNext(candle);
            }
        }
        catch (Exception e)
        {
            PulledSubject.OnError(e);
        }
        PulledSubject.OnCompleted();
    }
}
