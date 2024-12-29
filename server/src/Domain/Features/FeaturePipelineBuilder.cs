using System.Reactive.Linq;

using BotTrade.Domain.Ohlcvs;

namespace BotTrade.Domain.Features;

public static class FeaturePipelineBuilder
{
    public static IObservable<Dictionary<string, double>> BuildPipeline(this IObservable<Ohlcv> stream, IEnumerable<FeaturePipelineOrder> orders)
    {
        var processes = orders.Select(order => Activator.CreateInstance(order.ProcessKind, [order]) as IFeaturePipeline)
            .Where(p => p != null)
            .ToList();
        return stream.Select(ohlcv =>
        {
            var input = ohlcv.ToDictonary();
            return processes.Aggregate(input, (current, process) => process!.Execute(current));
        });
    }
}
