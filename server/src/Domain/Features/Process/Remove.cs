using System.Reactive.Linq;

namespace BotTrade.Domain.Features.Process;

/// <summary>
/// <c>PiplineProcessOrder.Parameters</c>のキーで指定された項目名の物を削除する
/// </summary>
public sealed class Remove : IFeaturePipline
{
    public FeaturePiplineOrder Order { get; init; }
    private readonly IEnumerable<string> _targets;

    public Remove(FeaturePiplineOrder order)
    {
        Order = order;
        _targets = order.Parameters.Keys;
    }

    public Dictionary<string, double> Execute(Dictionary<string, double> input)
    {
        return input.Where(pair => !_targets.Contains(pair.Key))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
