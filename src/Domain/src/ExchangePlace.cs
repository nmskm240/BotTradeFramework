namespace BotTrade.Domain;

public enum ExchangePlace
{
    [EnumString("Backtest")]
    Backtest,
    [EnumString("Bybit")]
    Bybit,
    [EnumString("BybitTestnet")]
    BybitTestnet,
    [EnumString("Binance")]
    Binance,
    [EnumString("BinanceTestnet")]
    BinanceTestnet,
}
