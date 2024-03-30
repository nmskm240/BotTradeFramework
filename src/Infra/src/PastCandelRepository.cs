using System.Runtime.CompilerServices;
using Domain.Attribute;
using Domain.Candle;
using Microsoft.Data.Sqlite;

namespace Infra
{
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
                var timestamp = reader.GetInt64(index++);
                var open = reader.GetFloat(index++);
                var high = reader.GetFloat(index++);
                var low = reader.GetFloat(index++);
                var close = reader.GetFloat(index++);
                var volume = reader.GetFloat(index++);
                var candle = new Candle(symbol, timestamp, open, high, low, close, volume);

                if(timeframe != Timeframe.OneMinute)
                {
                    candles.Add(candle);
                    if (candles.Count != (int)timeframe)
                        continue;

                    open = candles.First().Open;
                    high = candles.MaxBy(e => e.High)?.High ?? float.MinValue;
                    low = candles.MinBy(e => e.Low)?.Low ?? float.MinValue;
                    close = candles.Last().Close;
                    volume = candles.Sum(e => e.Volume);
                    candle = new Candle(symbol, timestamp, open, high, low, close, volume);
                    candles.Clear();
                }

                yield return candle;
            }
        }
    }
}
