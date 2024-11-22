using BotTrade.Domain;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class SymbolConverter : IGrpcConverter<Symbol, GrpcMessages.Symbol>
{
    public static Symbol ToEntity(GrpcMessages.Symbol message)
    {
        return new Symbol()
        {
            Code = message.Code,
            Name = message.Name,
            Place = ExchangePlaceConverter.ToEntity(message.Place)
        };
    }

    public static GrpcMessages.Symbol ToGrpcMessage(Symbol entity)
    {
        return new GrpcMessages.Symbol
        {
            Code = entity.Code,
            Name = entity.Name,
            Place = ExchangePlaceConverter.ToGrpcMessage(entity.Place),
        };
    }
}
