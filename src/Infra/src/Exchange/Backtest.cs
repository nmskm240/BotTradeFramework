using System.Reactive.Linq;
using BotTrade.Domain;

namespace BotTrade.Infra.Exchange;

public class Backtest : IExchange
{
    private readonly ICandleRepository _repository;

    public Backtest(ICandleRepository repository)
    {
        _repository = repository;
    }

    public Task Buy(Symbol symbol, float quantity)
    {
    }

    public Task Cancel()
    {
        throw new NotImplementedException();
    }

    public IObservable<Candle> OnFetchedCandle(Symbol symbol, Timeframe timeframe = Timeframe.OneMinute)
    {
        return Observable.Create<Candle>(async observer =>
        {
            try
            {
                await foreach (var e in _repository.Fetch(symbol, timeframe))
                {
                    observer.OnNext(e);
                }
                observer.OnCompleted();
            }
            catch (Exception e)
            {
                observer.OnError(e);
            }
        });
    }

    public Task Sell(Symbol symbol, float quantity)
    {
    }
}
