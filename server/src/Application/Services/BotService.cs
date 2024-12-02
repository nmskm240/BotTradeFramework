using System;

using BotTrade.Application.Converters;
using BotTrade.Application.Grpc.Generated;
using BotTrade.Domain;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Features;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using Microsoft.Extensions.Logging;

using ServiceBase = BotTrade.Application.Grpc.Generated.BotService;

namespace BotTrade.Application.Services;

public class BotService : ServiceBase.BotServiceBase
{
    private IExchange _exchange;
    // private FeaturePiplineBuilder _piplineBuilder;
    private ILogger _logger;

    // TODO: 本来はどの取引所を使用するかもCLからのリクエストに含める
    public BotService(IExchange exchange/*, FeaturePiplineBuilder piplineBuilder*/, ILogger<BotService> logger)
    {
        _exchange = exchange;
        // _piplineBuilder = piplineBuilder;
        _logger = logger;
    }

    public override async Task<Empty> Run(BotOrder request, ServerCallContext context)
    {
        var symbol = SymbolConverter.ToEntity(request.Symbol);
        var startAt = request.StartAt.ToDateTimeOffset();
        var endAt = request.EndAt.ToDateTimeOffset();
        var stream = _exchange.OhlcvStreamAsObservable(symbol, startAt, endAt);
        var bot = new Bot(stream, _logger);
        var completion = new TaskCompletionSource();
        using var _ = stream.Subscribe(
            _ => { },
            completion.SetException,
            completion.SetResult
        );

        try
        {
            using var __ = stream.Connect();
            await completion.Task;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return new Empty();
    }
}
