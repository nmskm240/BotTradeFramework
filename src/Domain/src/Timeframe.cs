namespace BotTrade.Domain;
public enum Timeframe
{
    [EnumString("1m")]
    OneMinute = 1,
    [EnumString("5m")]
    FiveMinute = 5,
    [EnumString("15m")]
    FifteenMinute = 15,
    [EnumString("1h")]
    OneHour = 60,
    [EnumString("4h")]
    FourHour = 240,
    [EnumString("1d")]
    OneDay = 1440,
}
