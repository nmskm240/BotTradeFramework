using System.Reactive.Linq;

using BotTrade.Domain.Ohlcvs;

namespace BotTrade.Domain.Features;

public static class FeaturePiplineBuilder
{
    public static IObservable<Dictionary<string, double>> BuildPipline(this IObservable<Ohlcv> stream, IEnumerable<FeaturePiplineOrder> orders)
    {
        var processes = orders.Select(order => Activator.CreateInstance(order.ProcessKind, order) as IFeaturePipline)
            .Where(p => p != null)
            .ToList();
        return stream.Select(ohlcv =>
        {
            var input = ohlcv.ToDictonary();
            return processes.Aggregate(input, (current, process) => process!.Execute(current));
        });
    }
}
