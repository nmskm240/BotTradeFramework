using Domain.Attribute;

namespace Domain.Candle
{
    public enum Symbol
    {
        [EnumString("BTC/USDT")]
        BTCUSDT,
        [EnumString("ETH/USDT")]
        ETHUSDT,
        [EnumString("ETH/BTC")]
        ETHBTC,
    }
}
