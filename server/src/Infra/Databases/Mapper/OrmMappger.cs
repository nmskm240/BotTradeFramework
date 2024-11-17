using System;
using System.Data;

namespace BotTrade.Infra.Databases.Mapper;

internal interface IOrmMappger<TEntity, SOrm>
    where TEntity : notnull
    where SOrm : notnull
{
    internal static abstract SOrm ToOrm(TEntity entity, IDbConnection connection);
    internal static abstract TEntity ToEntity(SOrm orm, IDbConnection connection);
}
