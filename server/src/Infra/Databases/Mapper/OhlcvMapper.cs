using System.Data;

using BotTrade.Domain.Ohlcvs;
using BotTrade.Infra.Databases.Orm;

using ServiceStack.OrmLite;

namespace BotTrade.Infra.Databases.Mapper;

internal class OhlcvMapper : IOrmMappger<Ohlcv, OhlcvOrm>
{
    public static Ohlcv ToEntity(OhlcvOrm orm, IDbConnection connection)
    {
        var symbolOrm = connection.Single<SymbolOrm>(e => e.Id == orm.SymbolId);
        return new Ohlcv(
            orm.Open,
            orm.High,
            orm.Low,
            orm.Close,
            orm.Volume,
            orm.DecisionAt.UtcDateTime,
            SymbolMapper.ToEntity(symbolOrm, connection)
        );
    }

    public static OhlcvOrm ToOrm(Ohlcv entity, IDbConnection connection)
    {
        return new OhlcvOrm
        {
            Open = entity.Open,
            High = entity.High,
            Low = entity.Low,
            Close = entity.Close,
            Volume = entity.Volume,
            DecisionAt = entity.Date,
            SymbolId = SymbolMapper.ToOrm(entity.Symbol, connection).Id
        };
    }
}
