using System;

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

    // TODO: 本来はどの取引所を使用するかもCLからのリクエストに含める
    public BotService(IExchange exchange/*, FeaturePiplineBuilder piplineBuilder*/)
    {
        _exchange = exchange;
        // _piplineBuilder = piplineBuilder;
    }

    public override async Task<Empty> Run(Empty request, ServerCallContext context)
    {
        var logger = LoggerFactory.Create(b => b.AddConsole())
            .CreateLogger(string.Empty);
        var symbol = new Domain.Symbol("BTCUSDT", string.Empty, new("Bybit", true));
        var startAt = new DateTimeOffset(2022, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var endAt = new DateTimeOffset(2023, 12, 31, 23, 59, 59, TimeSpan.Zero);
        var stream = _exchange.OhlcvStreamAsObservable(symbol, startAt: startAt, endAt: endAt);
        var bot = new Bot(stream, logger);
        var completion = new TaskCompletionSource();
        using var _ = stream.Subscribe(
            Console.WriteLine,
            completion.SetException,
            completion.SetResult
        );

        stream.Connect();
        try
        {
            await completion.Task;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }

        return new Empty();
    }
}
