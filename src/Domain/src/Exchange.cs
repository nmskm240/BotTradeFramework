using System.Reactive;
using System.Reactive.Subjects;
using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

/// <summary>
/// バックテスト、実稼働共通の取引所クラス
/// </summary>
/// <remarks>
/// バックテストの都合上、<c>Symbol</c>、<c>Timeframe</c>が異なる場合は別の取引所として扱う
/// </remarks>
public abstract class Exchange
{
    protected List<Position> Positions { get; init;}
    public Symbol Symbol { get; init; }
    public Timeframe Timeframe { get; init; }
    public abstract IConnectableObservable<Candle> OnFetchedCandle { get; init; }

    public Exchange(StrategyParameter parameter)
    {
        Positions = [];
        Symbol = parameter.Symbol;
        Timeframe = parameter.Timeframe;
    }

    public abstract Task<Position> Buy(Symbol symbol, decimal quantity);
    public abstract Task<Position> Sell(Symbol symbol, decimal quantity);
    public abstract Task<decimal> ClosePosition(Position position);
}
