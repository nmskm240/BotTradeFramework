namespace BotTrade.Domain.Ohlcvs;

public record class Ohlcv(
    double Open,
    double High,
    double Low,
    double Close,
    double Volume,
    // FIXME: DateTimeOffsetにしたい
    DateTime Date,
    Symbol Symbol
)
{
    public const string OPEN_LABEL = "Open";
    public const string HIGH_LABEL = "High";
    public const string LOW_LABEL = "Low";
    public const string CLOSE_LABEL = "Close";
    public const string VOLUME_LABEL = "Volume";
    public const string DATE_LABEL = "Date";

    public Dictionary<string, double> ToDictonary()
    {
        return new Dictionary<string, double> {
            { OPEN_LABEL, Open },
            { HIGH_LABEL, High },
            { LOW_LABEL, Low },
            { CLOSE_LABEL, Close },
            { VOLUME_LABEL, Volume },
            { DATE_LABEL, new DateTimeOffset(Date).ToUnixTimeMilliseconds() },
        };
    }
}
