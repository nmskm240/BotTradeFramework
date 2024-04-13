namespace BotTrade.Domain.Strategies;

public record class StrategyParameter
{
    public Symbol Symbol { get; init; }
    public Timeframe Timeframe { get; init; }

    public StrategyParameter(Symbol symbol, Timeframe timeframe)
    {
        Symbol = symbol;
        Timeframe = timeframe;
    }
}
