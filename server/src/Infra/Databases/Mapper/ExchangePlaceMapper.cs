using System.Data;

using BotTrade.Domain;
using BotTrade.Infra.Databases.Orm;

using ServiceStack.OrmLite;

namespace BotTrade.Infra.Databases.Mapper;

internal class ExchangePlaceMapper : IOrmMappger<ExchangePlace, ExchangePlaceOrm>
{
    public static ExchangePlace ToEntity(ExchangePlaceOrm orm, IDbConnection connection)
    {
        return new ExchangePlace(
            orm.Name,
            true
        );
    }

    public static ExchangePlaceOrm ToOrm(ExchangePlace entity, IDbConnection connection)
    {
        var query = connection.From<ExchangePlaceOrm>()
            .Where(x => x.Name == entity.Name);
        var saved = connection.Select(query)
            .SingleOrDefault();

        if (saved != null)
            return saved;

        var orm = new ExchangePlaceOrm
        {
            Name = entity.Name,
        };

        orm.Id = connection.Insert(orm, selectIdentity: true);
        return orm;
    }
}
