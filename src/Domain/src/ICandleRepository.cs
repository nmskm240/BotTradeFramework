using System.Reactive.Subjects;

namespace BotTrade.Domain;

public interface ICandleRepository
{
    IAsyncEnumerable<Candle> Pull(DateTimeOffset? startAt = null, DateTimeOffset? endAt = null);
}

public interface IUpdatableCandleRepository : ICandleRepository
{
    Task Fetch();
}
