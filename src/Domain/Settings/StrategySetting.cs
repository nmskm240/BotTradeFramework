namespace BotTrade.Domain.Settings;

public record class StrategySetting
{
    public StrategyKind Kind { get; set; }
    public Timeframe Timeframe { get; set; }
    public required IEnumerable<int> Parameters { get; set; }
}
