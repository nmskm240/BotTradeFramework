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

using Reactive.Bindings.Extensions;

using ServiceBase = BotTrade.Application.Grpc.Generated.BotService;

namespace BotTrade.Application.Services;

public class BotService : ServiceBase.BotServiceBase
{
    private IExchange _exchange;
    private ILogger _logger;

    // TODO: 本来はどの取引所を使用するかもCLからのリクエストに含める
    public BotService(IExchange exchange, ILogger<BotService> logger)
    {
        _exchange = exchange;
        _logger = logger;
    }

    public override async Task Run(BotOrder request, IServerStreamWriter<BotPerformance> stream, ServerCallContext context)
    {
        var disposables = new CompositeDisposable();
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
        var semaphore = new SemaphoreSlim(1, 1)
            .AddTo(disposables);
        var streamWriteProcess = async (BotPerformance e) =>
        {
            await semaphore.WaitAsync();
            try
            {
                await stream.WriteAsync(e);
            }
            finally
            {
                if (!disposables.IsDisposed)
                {
                    semaphore.Release();
                }
            }
        };
        var bot = new Bot(pipeline, _logger)
            .AddTo(disposables);
        bot.OnPredicatedAsObservable()
            .WithLatestFrom(ohlcvStream, (pred, ohlcv) => new BotPerformance()
            {
                PredictValue = pred.First(),
                ActualValue = ohlcv.Close,
                Timestamp = ohlcv.Date.ToTimestamp()
            })
            .Subscribe(async e => await streamWriteProcess(e))
            .AddTo(disposables);
        pipeline.Subscribe(
            _ => { },
            completion.SetException,
            completion.SetResult
        ).AddTo(disposables);
        ohlcvStream.Connect()
            .AddTo(disposables);

        try
        {
            await completion.Task;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        finally
        {
            disposables.Dispose();
        }
    }
}
