namespace BotTrade.Domain.Strategy;

public record class StrategyParameter
{
    public Symbol Symbol { get; init; }
    public Timeframe Timeframe { get; init; }
}
