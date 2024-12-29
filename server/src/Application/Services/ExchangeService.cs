using System.Reactive.Disposables;
using System.Reactive.Linq;

using BotTrade.Application.Converters;
using BotTrade.Application.Grpc.Generated;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Ohlcvs;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using ServiceBase = BotTrade.Application.Grpc.Generated.ExchangeService;

namespace BotTrade.Application.Services;
public class ExchangeService : ServiceBase.ExchangeServiceBase
{
    private IExchange _exchange { get; init; }
    private IOhlcvRepository _repository { get; init; }

    public ExchangeService(IExchange exchange, IOhlcvRepository repository)
    {
        _exchange = exchange;
        _repository = repository;
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
            var observable = _exchange.OhlcvStreamAsObservable(symbol, updatedAt.AddMinutes(1), now.AddMinutes(-1));
            using var _ = observable.Buffer(100000)
                .Subscribe(
                    async ohlcvs =>
                    {
                        try
                        {
                            await _repository.PushAsync(ohlcvs, context.CancellationToken);
                        }
                        catch (Exception e)
                        {
                            completion.SetException(e);
                        }
                    },
                    e => completion.SetException(e),
                    () => completion.SetResult(true)
                );
            observable.Connect();

            await completion.Task;
        });
        await Task.WhenAll(tasks);

        return new Empty();
    }
}
