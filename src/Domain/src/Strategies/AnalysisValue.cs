namespace BotTrade.Domain.Strategies;

public record class AnalysisValue
{
    public decimal Value { get; init; }
    public GraphType GraphType { get; init; }

    public AnalysisValue(decimal value, GraphType graphType)
    {
        Value = value;
        GraphType = graphType;
    }
}
