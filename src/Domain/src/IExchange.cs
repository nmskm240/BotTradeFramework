using System.Reactive;

namespace BotTrade.Domain;

public interface IExchange
{
    Task Buy(Symbol symbol, float quantity);
    Task Sell(Symbol symbol, float quantity);
    Task Cancel();
    IObservable<Candle> OnFetchedCandle(Symbol symbol, Timeframe timeframe);
}
