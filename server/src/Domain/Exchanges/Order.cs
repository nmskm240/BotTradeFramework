namespace BotTrade.Domain.Exchanges;

public record struct Order(
    float? Price,
    float Quantity,
    Symbol Symbol
);
