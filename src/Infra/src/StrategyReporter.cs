using BotTrade.Domain;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

using ScottPlot;

using Skender.Stock.Indicators;

namespace BotTrade.Infra;

public class StrategyReporter : IStrategyReporter, IDisposable
{
    private const string TABLE_NAME = "positions";
    private SqliteConnection Connection { get; init; }
    private ILogger<StrategyReporter> Logger { get; init; }


    public StrategyReporter(Setting.Bot setting, ILogger<StrategyReporter> logger)
    {
        Logger = logger;
        var path = $"/workspace/out/{setting.ReportDir}";
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        Directory.CreateDirectory(path);
        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = Path.GetFullPath($"{path}/trade.sqlite3"),
        };
        Connection = new SqliteConnection(builder.ConnectionString);
        Connection.Open();

        var sql = $"""
            create table if not exists {TABLE_NAME} (
                id TEXT NOT NULL,
                symbol TEXT NOT NULL,
                type INTEGER,
                quantity FLOAT,
                entry FLOAT,
                entry_at BIGINT NOT NULL,
                exit FLOAT,
                exit_at BIGINT NOT NULL,
                PRIMARY KEY(id)
            )
        """;
        using var command = new SqliteCommand(sql, Connection);
        command.ExecuteNonQuery();
    }

    public void Log(Position position)
    {
        var values = $"""
            '{position.Id}',
            '{position.Symbol.GetStringValue()}',
            '{position.Type}',
            '{position.Quantity}',
            '{position.Entry}',
            '{new DateTimeOffset(position.EntryAt).ToUnixTimeMilliseconds()}',
            '{position.Exit}',
            '{new DateTimeOffset(position.ExitAt).ToUnixTimeMilliseconds()}'
        """;
        var sql = $"""
            insert into {TABLE_NAME} (id, symbol, type, quantity, entry, entry_at, exit, exit_at)
            values ({values})
        """;
        try
        {
            using var command = new SqliteCommand(sql, Connection);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Logger.LogError("{message}", e.Message);
        }
    }

    public StrategyReport? Report()
    {
        var sql = $"""
            select * from {TABLE_NAME}
        """;
        var trades = new List<Position>();
        var totalProfit = new Plot();
        var xAxis = new List<DateTime>();
        var yAxis = new List<decimal>();
        var capital = decimal.Zero;
        totalProfit.Add.Scatter(xAxis, yAxis);
        totalProfit.Axes.DateTimeTicksBottom();

        try
        {
            using var command = new SqliteCommand(sql, Connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var index = 0;
                var id = reader.GetString(index++);
                var symbol = reader.GetString(index++);
                var trade = new Position(
                    Enum.GetValues<Symbol>().FirstOrDefault(s => s.GetStringValue() == symbol),
                    (PositionType)reader.GetInt64(index++),
                    reader.GetFloat(index++),
                    reader.GetDecimal(index++),
                    DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64(index++)).DateTime,
                    id,
                    reader.GetDecimal(index++),
                    DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64(index++)).DateTime
                );
                trades.Add(trade);
                xAxis.Add(trade.EntryAt);
                yAxis.Add(capital);
                xAxis.Add(trade.ExitAt);
                yAxis.Add(capital += trade.Profit);
            }
        }
        catch (Exception e)
        {
            Logger.LogError("{message}", e.Message);
            return null;
        }
        return new StrategyReport(trades, totalProfit);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
