namespace BotTrade.Domain;

public enum ExchangePlace
{
    [EnumString("Bybit")]
    Bybit,
    [EnumString("BybitTestnet")]
    BybitTestnet,
    [EnumString("Binance")]
    Binance,
    [EnumString("BinanceTestnet")]
    BinanceTestnet,
}
