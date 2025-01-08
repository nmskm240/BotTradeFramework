using System.Reactive.Linq;

using BotTrade.Domain.Attributes;

namespace BotTrade.Domain.Features.Process;

[FeaturePipelineInfo(name: "Remove", description: "指定した特徴量を削除する")]
public sealed class Remove : IFeaturePipeline
{
    public FeaturePipelineOrder Order { get; init; }
    [ListParameterInfo(name: "targets", description: "", defalutValue: [])]
    public IEnumerable<string> Targets { get; init; }

    public Remove(FeaturePipelineOrder order)
    {
        Order = order;

        Targets = Order.Parameters
            .FirstOrDefault(p => p.Name == "targets").ListValue ?? [];
    }

    public Dictionary<string, double> Execute(Dictionary<string, double> input)
    {
        return input.Where(pair => !Targets.Contains(pair.Key))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
