using BotTrade.Domain;

using Microsoft.Data.Sqlite;

namespace BotTrade.Infra;

public class StrategyReporter : IStrategyReporter
{
    private const string TABLE_NAME = "positions";
    private SqliteConnection Connection { get; init; }


    public StrategyReporter(Setting.Bot setting)
    {
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
                entry FLOAT,
                exit FLOAT,
                quantity FLOAT,
                type INTEGER,
                PRIMARY KEY(id)
            )
        """;
        using var command = new SqliteCommand(sql, Connection);
        command.ExecuteReader();
    }

    public void Log(CapitalFlow flow)
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }
}
