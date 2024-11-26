using System.Reactive.Linq;

using BotTrade.Domain.Ohlcvs;

namespace BotTrade.Domain.Features;

public class FeaturePiplineBuilder
{
    private readonly IObservable<Ohlcv> _ohlcvStream;

    public FeaturePiplineBuilder(IObservable<Ohlcv> ohlcvStream)
    {
        _ohlcvStream = ohlcvStream;
    }

    public IObservable<Dictionary<string, object>> Create(IEnumerable<FeaturePiplineOrder> orders)
    {
        var processes = orders.Select(order => Activator.CreateInstance(order.ProcessKind, order) as IFeaturePipline)
            .Where(p => p != null)
            .ToList();
        return _ohlcvStream.Select(ohlcv =>
        {
            var input = ohlcv.ToDictonary();
            return processes.Aggregate(input, (current, process) => process!.Execute(current));
        });
    }
}
