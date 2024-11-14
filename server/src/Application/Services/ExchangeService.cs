using BotTrade.Application.Grpc.Generated;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using ServiceBase = BotTrade.Application.Grpc.Generated.ExchangeService;

namespace BotTrade.Application.Services;
public class ExchangeService : ServiceBase.ExchangeServiceBase
{
    public override Task<Symbols> SupportedSymbols(Empty request, ServerCallContext context)
    {
        return base.SupportedSymbols(request, context);
    }

    public override Task<Empty> Fetch(Symbols request, ServerCallContext context)
    {
        return base.Fetch(request, context);
    }
}
