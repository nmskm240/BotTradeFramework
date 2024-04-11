using System.Reactive;
using System.Reactive.Subjects;
using BotTrade.Domain.Strategy;

namespace BotTrade.Domain;

public abstract class Exchange
{
    public Symbol Symbol { get; init; }
    public Timeframe Timeframe { get; init; }
    public abstract IConnectableObservable<Candle> OnFetchedCandle { get; init; }

    public Exchange(StrategyParameter parameter)
    {
        Symbol = parameter.Symbol;
        Timeframe = parameter.Timeframe;
    }

    public abstract Task<Position> Buy(Symbol symbol, decimal quantity);
    public abstract Task<Position> Sell(Symbol symbol, decimal quantity);
    public abstract Task<decimal> ClosePosition(Position position);
}
