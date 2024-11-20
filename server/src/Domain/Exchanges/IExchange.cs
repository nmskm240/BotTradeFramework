using System.Reactive.Subjects;
using BotTrade.Domain.Ohlcvs;

namespace BotTrade.Domain.Exchanges;

/// <summary>
/// バックテスト、実稼働共通の取引所クラス
/// </summary>
public interface IExchange
{
    public ExchangePlace Place { get; init; }

    public Task<IEnumerable<Symbol>> SupportSymbolsAsync(CancellationToken token);
    public IConnectableObservable<Ohlcv> OhlcvStreamAsObservable(Symbol symbol, DateTimeOffset? startAt = null, DateTimeOffset? endAt = null);
    public Task<Trade> Trade(Order order);
}
