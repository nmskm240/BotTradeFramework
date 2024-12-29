namespace BotTrade.Domain;

public record struct ExchangePlace(
    string Name,
    bool IsBacktest
);
