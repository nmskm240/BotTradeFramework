using BotTrade.Infra.Databases.Orm;

using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace BotTrade.Infra.Databases;

public static class DatabaseStarter
{
    public static async Task CreateTables(IDbConnectionFactory dbConnectionFactory)
    {
        using var connection = await dbConnectionFactory.OpenAsync();
        connection.CreateTableIfNotExists<ExchangePlaceOrm>();
        connection.CreateTableIfNotExists<SymbolOrm>();
        connection.CreateTableIfNotExists<OhlcvOrm>();
    }
}
