using System.Reactive.Linq;
using System.Runtime.CompilerServices;

using BotTrade.Domain;

using ccxt;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace BotTrade.Infra;
public class PastCandleRepository : IUpdatableCandleRepository
{
    private const string PATH_FORMAT = "/workspace/data/{0}.sqlite3";
    private const string TABLE_NAME = "candles";
    private const string CREATE_TABLE_SQL = $"""
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
    private Symbol Symbol { get; init; }
    private ExchangePlace Place { get; init; }
    private ILogger<PastCandleRepository> Logger { get; init; }
    private string DatabasPath { get { return string.Format(PATH_FORMAT, Place.GetStringValue()); } }

    public PastCandleRepository(Setting.Exchange setting, ILogger<PastCandleRepository> logger)
    {
        Symbol = setting.Symbol;
        Place = setting.Place;
        Logger = logger;
    }

    private SqliteConnection MakeConnection(SqliteOpenMode mode)
    {
        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = Path.GetFullPath(DatabasPath),
            Mode = mode,
        };
        var connection = new SqliteConnection(builder.ConnectionString);
        connection.Open();
        using var command = new SqliteCommand(CREATE_TABLE_SQL, connection);
        command.ExecuteReader();
        return connection;
    }

    public async Task Fetch(CancellationToken token = default)
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
        using var connection = MakeConnection(SqliteOpenMode.ReadWrite);

        try
        {
            using var command = new SqliteCommand(fetchLastTimestampSQL, connection);
            using var reader = await command.ExecuteReaderAsync(token);
            if (reader.Read())
            {
                lastTime = DateTimeOffset.UnixEpoch.AddMilliseconds(reader.GetDouble(0)).ToUnixTimeMilliseconds();
                Logger.LogInformation("前回更新時: {lastime}", lastTime);
            }
        }
        catch
        {
            Logger.LogWarning("前回更新のデータが存在しないため、取引所から取得可能なデータをすべて取得する。これにはかなり時間がかかる。");
        }

        if (Place.Reflection<Exchange>([null]) is Exchange exchange)
        {
            var limit = 1000;
            // 確定足情報を取得するため１分前の情報から取得していく
            var latest = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1));
            IEnumerable<OHLCV> ohlcvs;
            while (true)
            {
                var since = latest.Subtract(TimeSpan.FromMinutes(limit - 1)).ToUnixTimeMilliseconds();
                ohlcvs = await exchange.FetchOHLCV(Symbol.GetStringValue(), since2: since, limit2: limit);
                ohlcvs = ohlcvs.Where(e => lastTime < e.timestamp && e.timestamp <= latest.ToUnixTimeMilliseconds());

                if (!ohlcvs.Any() || token.IsCancellationRequested)
                    break;

                Logger.LogInformation("Fetched since: {since}, count: {size}", DateTimeOffset.FromUnixTimeMilliseconds(since), ohlcvs.Count());

                var values = ohlcvs.Select(e => $"""
                    ('{Symbol.GetStringValue()}',
                    '{e.timestamp}',
                    '{e.open}',
                    '{e.high}',
                    '{e.low}',
                    '{e.close}',
                    '{e.volume}')
                    """
                );
                var insertOhlcvSQL = $"""
                    insert into {TABLE_NAME} (
                        Symbol,
                        timestamp,
                        open,high,
                        low,
                        close,
                        volume
                    ) values {string.Join(", ", values)}
                """;

                using var transaction = connection.BeginTransaction();
                using var command = new SqliteCommand(insertOhlcvSQL, connection, transaction);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    connection.Close();
                    Logger.LogError("データ更新に失敗");
                    throw;
                }

                latest = DateTimeOffset.FromUnixTimeMilliseconds(since);
                await Task.Delay(TimeSpan.FromMilliseconds(exchange.rateLimit), token);
            }
            Logger.LogInformation("データベース更新完了");
            connection.Close();
            return;
        }

        Logger.LogWarning("ccxtに対応していない取引所");
        connection.Close();
    }

    public async IAsyncEnumerable<Candle> Pull(DateTimeOffset? startAt = null, DateTimeOffset? endAt = null, [EnumeratorCancellation] CancellationToken token = default)
    {

        var sql = $"""
            select * from {TABLE_NAME}
            where symbol='{Symbol.GetStringValue()}'
                and {startAt?.ToUnixTimeMilliseconds() ?? long.MinValue} <= timestamp
                and timestamp <= {endAt?.ToUnixTimeMilliseconds() ?? long.MaxValue}
            order by timestamp asc
        """;

        using var connection = MakeConnection(SqliteOpenMode.ReadOnly);
        using var command = new SqliteCommand(sql, connection);
        using var reader = await command.ExecuteReaderAsync(token);

        while (await reader.ReadAsync(token))
        {
            var index = 1;
            var date = DateTime.UnixEpoch.AddMilliseconds(reader.GetDouble(index++));
            var open = reader.GetDecimal(index++);
            var high = reader.GetDecimal(index++);
            var low = reader.GetDecimal(index++);
            var close = reader.GetDecimal(index++);
            var volume = reader.GetDecimal(index++);
            yield return new Candle(Symbol, date, open, high, low, close, volume);
        }
        connection.Close();
    }
}
