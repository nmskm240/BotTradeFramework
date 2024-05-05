using System.Reactive.Subjects;

namespace BotTrade.Domain;

public interface ICandleRepository
{
    Task Pull();
    IObservable<Candle> OnPulled { get; }
}

public interface IUpdatableCandleRepository : ICandleRepository
{
    Task Fetch();
}
