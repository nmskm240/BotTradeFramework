using System.Reactive.Subjects;

namespace BotTrade.Domain;

public interface ICandleRepository
{
    IAsyncEnumerable<Candle> Pull();
}

public interface IUpdatableCandleRepository : ICandleRepository
{
    Task Fetch();
}
