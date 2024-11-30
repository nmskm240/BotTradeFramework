namespace BotTrade.Domain.Features;

public interface IFeaturePipline
{
    public FeaturePiplineOrder Order { get; init; }

    Dictionary<string, double> Execute(Dictionary<string, double> input);
}
