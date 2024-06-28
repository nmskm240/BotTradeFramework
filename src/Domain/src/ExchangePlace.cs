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
}
