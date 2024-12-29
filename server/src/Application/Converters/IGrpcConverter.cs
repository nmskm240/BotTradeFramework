using System;

namespace BotTrade.Application.Converters;

internal interface IGrpcConverter<TEntity, SMessage>
    where TEntity : notnull
    where SMessage : notnull
{
    internal abstract static TEntity ToEntity(SMessage message);
    internal abstract static SMessage ToGrpcMessage(TEntity entity);
}
