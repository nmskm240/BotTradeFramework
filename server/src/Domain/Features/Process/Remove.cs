using System.Reactive.Linq;

using BotTrade.Domain.Attributes;

namespace BotTrade.Domain.Features.Process;

[FeaturePipelineInfo(name: "Remove", description: "指定した特徴量を削除する")]
public sealed class Remove : IFeaturePipeline
{
    public FeaturePipelineOrder Order { get; init; }
    [ListParameterInfo(name: "", description: "", defalutValue: [])]
    public IEnumerable<string> Targets { get; init; }

    public Remove(FeaturePipelineOrder order)
    {
        Order = order;

        var elements = Order.Parameters
            .FirstOrDefault(p => p.Name == "target").StringValue ?? string.Empty;
        Targets = elements.Split(",");
    }

    public Dictionary<string, double> Execute(Dictionary<string, double> input)
    {
        return input.Where(pair => !Targets.Contains(pair.Key))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
