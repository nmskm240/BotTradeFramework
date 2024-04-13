using BotTrade.Domain;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace BotTrade.Infra;
public class PastCandleRepository : ICandleRepository, IDisposable
{
    private const string TABLE_NAME = "candles";
    private SqliteConnection? _connection;

    public PastCandleRepository()
    {
        // TODO: 開発用に直書きのためあとで変える
        var path = @"/workspaces/sandbox/data/Bybit.sqlite3";
        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = Path.GetFullPath(path),
        };
        _connection = new SqliteConnection(builder.ConnectionString);
        _connection.Open();
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
        _connection = null;
        GC.SuppressFinalize(this);
    }

    public async IAsyncEnumerable<Candle> Fetch(Symbol symbol, Timeframe timeframe = Timeframe.OneMinute, [EnumeratorCancellation] CancellationToken token = default)
    {
        var sql = $@"
                select * from {TABLE_NAME}
                where symbol='{symbol.GetStringValue()}'
                order by timestamp asc";

        //TODO: テーブルがないときのエラー処理
        using var command = new SqliteCommand(sql, _connection);
        using var reader = await command.ExecuteReaderAsync(token);
        var candles = new List<Candle>();

        while (reader.Read())
        {
            var index = 1;
            var date = DateTime.UnixEpoch.AddMilliseconds(reader.GetDouble(index++));
            var open = reader.GetDecimal(index++);
            var high = reader.GetDecimal(index++);
            var low = reader.GetDecimal(index++);
            var close = reader.GetDecimal(index++);
            var volume = reader.GetDecimal(index++);
            var candle = new Candle(symbol, date, open, high, low, close, volume);

            if (timeframe != Timeframe.OneMinute)
            {
                candles.Add(candle);
                if (candles.Count != (int)timeframe)
                    continue;

                candle = Candle.Aggregate(candles);
                candles.Clear();
            }

            yield return candle;
        }
    }
}
