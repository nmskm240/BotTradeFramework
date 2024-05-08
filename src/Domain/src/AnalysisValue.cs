namespace BotTrade.Domain;

public record class AnalysisValue
{
    public DateTime Date { get; init; }
    public decimal Value { get; init; }
    public GraphType GraphType { get; init; }

    public AnalysisValue(DateTime date, decimal value, GraphType graphType)
    {
        Date = date;
        Value = value;
        GraphType = graphType;
    }
}
