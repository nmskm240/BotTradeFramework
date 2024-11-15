using BotTrade.Domain;

using Microsoft.Data.Sqlite;

using ScottPlot;

namespace BotTrade.Infra;

public static class StrategyReporter
{
    private const string TABLE_NAME = "positions";
    private const string OUT_DIR_PATH = "/workspace/out";
    private const string TRADE_HISTORY_FILE_NAME = "trrade.sqlite3";

    public static async Task<Plot> Export(string directoryName, StrategyReport report, bool shouldExportTradesToDB = true, CancellationToken cancellation = default)
    {
        var path = FindOrCreateReportDirectory(directoryName);

        if (shouldExportTradesToDB)
            await TryExportTradeDB(path, report.Trades, cancellation);

        return ExportProfitGraph(report.Trades);
    }

    private static async Task<SqliteConnection> MakeConnection(string path, CancellationToken cancellation)
    {
        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = Path.GetFullPath(Path.Combine(path, TRADE_HISTORY_FILE_NAME)),
        };
        var connection = new SqliteConnection(builder.ConnectionString);
        await connection.OpenAsync(cancellation);

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
        using var command = new SqliteCommand(sql, connection);
        await command.ExecuteNonQueryAsync(cancellation);
        return connection;
    }

    private static string FindOrCreateReportDirectory(string directoryName)
    {
        var path = Path.Combine(OUT_DIR_PATH, directoryName);
        if (Directory.Exists(path))
        {
            return Path.GetFullPath(path);
        }
        var dir = Directory.CreateDirectory(path);
        return dir.FullName;
    }

    private static async Task TryExportTradeDB(string path, IEnumerable<Position> trades, CancellationToken cancellation)
    {
        using var connection = await MakeConnection(path, cancellation);
        var values = string.Join(",", trades.Select(trade => $"""
        (
            '{trade.Id}',
            '{trade.Symbol.GetStringValue()}',
            '{trade.Type}',
            '{trade.Quantity}',
            '{trade.Entry}',
            '{new DateTimeOffset(trade.EntryAt).ToUnixTimeMilliseconds()}',
            '{trade.Exit}',
            '{new DateTimeOffset(trade.ExitAt).ToUnixTimeMilliseconds()}'
        )
        """));
        var sql = $"""
            insert into {TABLE_NAME} (
                id,
                symbol,
                type,
                quantity,
                entry,
                entry_at,
                exit,
                exit_at
            ) values {values}
        """;
        using var command = new SqliteCommand(sql, connection);
        await command.ExecuteNonQueryAsync(cancellation);
    }

    private static Plot ExportProfitGraph(IEnumerable<Position> trades)
    {
        var totalProfit = new Plot();
        var xAxis = new List<DateTime>();
        var yAxis = new List<decimal>();
        var capital = decimal.Zero;
        foreach (var trade in trades)
        {
            xAxis.Add(trade.EntryAt);
            yAxis.Add(capital);
            xAxis.Add(trade.ExitAt);
            yAxis.Add(capital += trade.PnL);
        }
        totalProfit.Add.Scatter(xAxis, yAxis);
        totalProfit.Axes.DateTimeTicksBottom();
        return totalProfit;
    }
}
