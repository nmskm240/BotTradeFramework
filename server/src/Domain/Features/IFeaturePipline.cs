namespace BotTrade.Domain.Features;

public interface IFeaturePipline
{
    public FeaturePiplineOrder Order { get; init; }

    Dictionary<string, object> Execute(Dictionary<string, object> input);
}
