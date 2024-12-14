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
    private IFeaturePipelineInfoLoader _loader;
    private ILogger _logger;

    // TODO: 本来はどの取引所を使用するかもCLからのリクエストに含める
    // TODO: InfoLoaderではなく、SourceGenでPipelineProcessからInfoを作成するようにしたい
    public BotService(IExchange exchange, IFeaturePipelineInfoLoader loader, ILogger<BotService> logger)
    {
        _exchange = exchange;
        _loader = loader;
        _logger = logger;
    }

    public override async Task Run(BotOrder request, IServerStreamWriter<BotPerformance> stream, ServerCallContext context)
    {
        var symbol = SymbolConverter.ToEntity(request.Symbol);
        var startAt = request.StartAt.ToDateTimeOffset();
        var endAt = request.EndAt.ToDateTimeOffset();
        var orders = request.Orders.Select(FeaturePiplineOrderConverter.ToEntity);
        var stream = _exchange.OhlcvStreamAsObservable(symbol, startAt, endAt);
        var pipline = stream.BuildPipline(orders);
        var bot = new Bot(pipline, _logger);
        var completion = new TaskCompletionSource();
        using var _ = pipline.Subscribe(
            _ => {},
            completion.SetException,
            completion.SetResult
        );

        // try
        // {
        //     using var __ = ohlcvStream.Connect();
        //     await completion.Task;
        // }
        // catch (Exception e)
        // {
        //     _logger.LogError(e.Message);
        // }
    }

    public override Task<FeaturePipelineInfos> SupportedFeaturePipelines(Empty request, ServerCallContext context)
    {
        var infos = _loader.Load("/workspaces/BotTradeFramework/server/pipeline_info.json")
            .Select(FeaturePipelineInfoConverter.ToGrpcMessage)
            .ToList();
        var res = new FeaturePipelineInfos
        {
            Infos = { infos }
        };
        return Task.FromResult(res);
    }
}
