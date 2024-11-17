using Skender.Stock.Indicators;

namespace BotTrade.Domain.Ohlcvs;

public record class Ohlcv(
    decimal Open,
    decimal High,
    decimal Low,
    decimal Close,
    decimal Volume,
    DateTime Date,
    Symbol Symbol
) : IQuote;
