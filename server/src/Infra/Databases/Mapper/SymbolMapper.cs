using System;
using System.Data;

using BotTrade.Domain;
using BotTrade.Infra.Databases.Orm;

using ServiceStack.OrmLite;

namespace BotTrade.Infra.Databases.Mapper;

internal class SymbolMapper : IOrmMappger<Symbol, SymbolOrm>
{
    public static Symbol ToEntity(SymbolOrm orm, IDbConnection connection)
    {
        var placeOrm = connection.Single<ExchangePlaceOrm>(e => e.Id == orm.PlaceId);
        var place = ExchangePlaceMapper.ToEntity(placeOrm, connection);
        return new Symbol(
            orm.Code,
            orm.Name,
            place
        );
    }

    public static SymbolOrm ToOrm(Symbol entity, IDbConnection connection)
    {
        var saved = connection.Single<SymbolOrm>(x => x.Code == entity.Code);

        if (saved != null)
        {
            return saved;
        }

        var orm = new SymbolOrm
        {
            Code = entity.Code,
            Name = entity.Name,
            PlaceId = ExchangePlaceMapper.ToOrm(entity.Place, connection).Id
        };

        orm.Id = connection.Insert(orm);
        return orm;
    }
}
