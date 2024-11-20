namespace BotTrade.Domain.Exchanges;

public record class Trade(
    float Price,
    float Quantity,
    DateTimeOffset TradeAt
);
