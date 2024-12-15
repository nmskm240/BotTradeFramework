using System.Reactive.Disposables;
using System.Reactive.Linq;

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
        var startAt = request.StartAt?.ToDateTimeOffset()
             ?? new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var endAt = request.EndAt?.ToDateTimeOffset()
             ?? DateTimeOffset.UtcNow;
        var orders = request.PipelineOrders
            .Select(FeaturePipelineOrderConverter.ToEntity)
            .ToList();
        var ohlcvStream = _exchange.OhlcvStreamAsObservable(symbol, startAt, endAt);
        var pipeline = ohlcvStream.BuildPipeline(orders);
        var completion = new TaskCompletionSource();
        var bot = new Bot(pipeline, _logger);
        using var disposables = new CompositeDisposable([
            bot,
            bot.OnPredicatedAsObservable()
                .WithLatestFrom(ohlcvStream, (pred, ohlcv) => new BotPerformance()
                {
                    PredictValue = pred.First(),
                    ActualValue = ohlcv.Close,
                    Timestamp = ohlcv.Date.ToTimestamp()
                })
                .Subscribe(async e => await stream.WriteAsync(e)),
            pipeline.Subscribe(
                _ => {},
                completion.SetException,
                completion.SetResult
            ),
            ohlcvStream.Connect(),
        ]);

        try
        {
            await completion.Task;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            disposables.Dispose();
        }
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
