namespace BotTrade.Domain;

/// <summary>
/// 対象取引所Enum
/// </summary>
/// <remarks>
/// フォワードテスト用の取引所をは<c>Testnet</c>を付ける
/// </remarks>
public enum ExchangePlace
{
    [ReflectableEnum("ccxt", "ccxt.Bybit", typeof(object))]
    [EnumString("Bybit")]
    Bybit,
    [ReflectableEnum("ccxt", "ccxt.Bybit", typeof(object))]
    [EnumString("Bybit")]
    BybitTestnet,
    [ReflectableEnum("ccxt", "ccxt.Binance", typeof(object))]
    [EnumString("Binance")]
    Binance,
    [ReflectableEnum("ccxt", "ccxt.Binance", typeof(object))]
    [EnumString("Binance")]
    BinanceTestnet,
    [ReflectableEnum("ccxt", "ccxt.Bitfinex", typeof(object))]
    [EnumString("Bitfinex")]
    Bitfinex,
    [ReflectableEnum("ccxt", "ccxt.Bitfinex2", typeof(object))]
    [EnumString("Bitfinex2")]
    Bitfinex2,
    [ReflectableEnum("ccxt", "ccxt.Bitmex", typeof(object))]
    [EnumString("Bitmex")]
    Bitmex,
    [ReflectableEnum("ccxt", "ccxt.Bitbank", typeof(object))]
    [EnumString("Bitbank")]
    Bitbank,
}
