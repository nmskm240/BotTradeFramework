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
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = @"../data/Bybit.sqlite3",
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

        public async IAsyncEnumerable<Candle> Fetch(Symbol symbol, [EnumeratorCancellation] CancellationToken token = default)
        {
            var sql = $"select * from {TABLE_NAME} where symbol={symbol.GetStringValue()}";

            //TODO: テーブルがないときのエラー処理
            using var command = new SqliteCommand(sql, _connection);
            using var reader = await command.ExecuteReaderAsync(token);
            var candles = new List<Candle>();

            while (reader.Read())
            {
                var index = 0;
                var timestamp = reader.GetInt64(index++);
                var open = reader.GetFloat(index++);
                var high = reader.GetFloat(index++);
                var low = reader.GetFloat(index++);
                var close = reader.GetFloat(index++);
                var volume = reader.GetFloat(index++);
                var candle = new Candle(symbol, timestamp, open, high, low, close, volume);

                yield return candle;
            }
        }
    }
}
