namespace BotTrade.Domain.Ohlcvs;

public record class Ohlcv(
    double Open,
    double High,
    double Low,
    double Close,
    double Volume,
    DateTime Date,
    Symbol Symbol
) {
    public Dictionary<string, object> ToDictonary()
    {
        return new Dictionary<string, object> {
            { "Open", Open },
            { "High", High },
            { "Low", Low },
            { "Close", Close },
            { "Volume", Volume },
            { "Date", new DateTimeOffset(Date).ToUnixTimeMilliseconds() },
            { "Symbol", Symbol.Code },
        };
    }
}
