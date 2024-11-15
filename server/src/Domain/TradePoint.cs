namespace BotTrade.Domain;

public record TradePoint(
    StrategyActionType Action,
    IEnumerable<AnalysisData> Analyses
);
