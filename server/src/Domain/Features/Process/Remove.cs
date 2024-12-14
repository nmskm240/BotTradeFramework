using System.Reactive.Linq;

namespace BotTrade.Domain.Features.Process;

/// <summary>
/// <c>PiplineProcessOrder.Parameters</c>のキーで指定された項目名の物を削除する
/// </summary>
public sealed class Remove : IFeaturePipeline
{
    public FeaturePipelineOrder Order { get; init; }
    private IEnumerable<string> _targets;

    public Remove(FeaturePipelineOrder order)
    {
        var elements = Order.Parameters
            .FirstOrDefault(p => p.Name == "target").StringValue ?? string.Empty;

        Order = order;
        _targets = elements.Split(",");
    }

    public Dictionary<string, double> Execute(Dictionary<string, double> input)
    {
        return input.Where(pair => !_targets.Contains(pair.Key))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
