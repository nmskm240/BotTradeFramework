using System.Reactive.Subjects;

namespace BotTrade.Domain.Ohlcvs;

public interface IOhlcvRepository
{
    Task<IEnumerable<Symbol>> LoadableSymbolsAsync(CancellationToken token);
    Task<DateTimeOffset> LastUpdatedAtAsync(Symbol symbol, CancellationToken token);
    Task PushAsync(IEnumerable<Ohlcv> ohlcvs, CancellationToken token);
    IObservable<Ohlcv> PullAsObservable(Symbol symbol, DateTimeOffset? startAt = null, DateTimeOffset? endAt = null);
}
