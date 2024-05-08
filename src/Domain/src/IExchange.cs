using System.Reactive.Subjects;

namespace BotTrade.Domain;

/// <summary>
/// バックテスト、実稼働共通の取引所クラス
/// </summary>
/// <remarks>
/// バックテストの都合上、<c>Symbol</c>、<c>Timeframe</c>が異なる場合は別の取引所として扱う
/// </remarks>
public interface IExchange
{
    public List<Position> Positions { get; init; }
    public IConnectableObservable<Candle> OnPulled { get; init; }

    public Task<Position> Buy(Symbol symbol, decimal quantity);
    public Task<Position> Sell(Symbol symbol, decimal quantity);
    public abstract Task<decimal> ClosePosition(Position position);
}
