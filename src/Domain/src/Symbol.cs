namespace BotTrade.Domain;
// NOTE: このシンボル区分はBybitをベースにしているため
//         複数取引所での稼働を考えるなら修正が必要
public enum Symbol
{
    [EnumString("BTCUSD")]
    Future_BTCUSD,
    [EnumString("BTCUSDT")]
    Future_BTCUSDT,
    [EnumString("ETHUSDT")]
    Future_ETHUSDT,
    [EnumString("BTC/USD")]
    Spot_BTCUSD,
    [EnumString("BTC/USDT")]
    Spot_BTCUSDT,
    [EnumString("ETH/USDT")]
    Spot_ETHUSDT,
    [EnumString("ETH/BTC")]
    Spot_ETHBTC,
    [EnumString("BTC/JPY")]
    Spot_BTCJPY,
}
