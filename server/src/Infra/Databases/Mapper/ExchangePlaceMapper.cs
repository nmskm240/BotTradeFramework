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
            orm.Name
        );
    }

    public static ExchangePlaceOrm ToOrm(ExchangePlace entity, IDbConnection connection)
    {
        var saved = connection.Single<ExchangePlaceOrm>(x => x.Name == entity.Name);

        if (saved != null)
            return saved;

        var orm = new ExchangePlaceOrm
        {
            Name = entity.Name,
        };

        orm.Id = connection.Insert(orm);
        return orm;
    }
}
