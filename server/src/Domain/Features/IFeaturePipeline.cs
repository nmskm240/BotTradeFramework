namespace BotTrade.Domain.Features;

public interface IFeaturePipeline
{
    public FeaturePipelineOrder Order { get; init; }

    Dictionary<string, double> Execute(Dictionary<string, double> input);
}
