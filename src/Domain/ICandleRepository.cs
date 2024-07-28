using System.Reactive.Subjects;
using System.Runtime.CompilerServices;

namespace BotTrade.Domain;

public interface ICandleRepository
{
    IAsyncEnumerable<Candle> Pull(DateTimeOffset? startAt = null, DateTimeOffset? endAt = null, CancellationToken cancellation = default);
}

public interface IUpdatableCandleRepository : ICandleRepository
{
    Task Fetch(CancellationToken token = default);
}
