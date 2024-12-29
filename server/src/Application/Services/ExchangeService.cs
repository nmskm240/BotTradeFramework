using System.Reactive.Disposables;
using System.Reactive.Linq;

using BotTrade.Application.Converters;
using BotTrade.Application.Grpc.Generated;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Ohlcvs;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using Microsoft.Extensions.Logging;

using ServiceBase = BotTrade.Application.Grpc.Generated.ExchangeService;

namespace BotTrade.Application.Services;
public class ExchangeService : ServiceBase.ExchangeServiceBase
{
    private IExchange _exchange { get; init; }
    private IOhlcvRepository _repository { get; init; }
    // private ILogger _logger { get; init; }

    public ExchangeService(IExchange exchange, IOhlcvRepository repository)
    {
        _exchange = exchange;
        _repository = repository;
        // _logger = logger;
    }

    public override async Task<Symbols> SupportedSymbols(ExchangePlace request, ServerCallContext context)
    {
        var symbols = await _exchange.SupportSymbolsAsync(context.CancellationToken);
        return new Symbols
        {
            Symbols_ = { symbols.Select(e => new Symbol { Code = e.Code, Name = e.Name }) }
        };
    }

    public override async Task<Empty> Fetch(Symbols request, ServerCallContext context)
    {
        var tasks = request.Symbols_.Select(async e =>
        {
            var symbol = SymbolConverter.ToEntity(e);
            var updatedAt = await _repository.LastUpdatedAtAsync(symbol, context.CancellationToken);
            var now = DateTimeOffset.UtcNow;
            var completion = new TaskCompletionSource<bool>();
            var ohlcvs = new List<Ohlcv>();
            var observable = _exchange.OhlcvStreamAsObservable(symbol, updatedAt.AddMinutes(1), now.AddMinutes(-1));
            var subscription = new CompositeDisposable(
                observable.Subscribe(
                    async ohlcv =>
                    {
                        ohlcvs.Add(ohlcv);
                        if (ohlcvs.Count >= 1000)
                        {
                            try
                            {
                                await _repository.PushAsync(ohlcvs, context.CancellationToken);
                                ohlcvs.Clear();
                            }
                            catch (Exception e)
                            {
                                completion.SetException(e);
                            }
                        }
                    },
                    e => completion.SetException(e),
                    () => completion.SetResult(true)
                ),
                observable.Connect()
            );

            await completion.Task;

            subscription.Dispose();
        });
        await Task.WhenAll(tasks);

        return new Empty();
    }
}
