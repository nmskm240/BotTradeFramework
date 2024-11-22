using BotTrade.Domain;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class ExchangePlaceConverter : IGrpcConverter<ExchangePlace, GrpcMessages.ExchangePlace>
{
    public static ExchangePlace ToEntity(GrpcMessages.ExchangePlace message)
    {
        return new ExchangePlace()
        {
            Name = message.Name,
            IsBacktest = message.IsBacktest,
        };
    }

    public static GrpcMessages.ExchangePlace ToGrpcMessage(ExchangePlace entity)
    {
        return new GrpcMessages.ExchangePlace
        {
            Name = entity.Name,
            IsBacktest = entity.IsBacktest,
        };
    }
}
