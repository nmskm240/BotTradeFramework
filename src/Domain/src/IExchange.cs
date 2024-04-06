using System.Reactive;

namespace BotTrade.Domain;

public interface IExchange
{
    Task<Position> Buy(Symbol symbol, decimal quantity);
    Task<Position> Sell(Symbol symbol, decimal quantity);
    Task<decimal> ClosePosition(Position position);
    IObservable<Candle> OnFetchedCandle(Symbol symbol, Timeframe timeframe);
}
