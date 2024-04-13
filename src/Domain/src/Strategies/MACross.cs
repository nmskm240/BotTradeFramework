using Skender.Stock.Indicators;

namespace BotTrade.Domain.Strategies;

public record MACrossParameter : StrategyParameter
{
    public MACrossParameter(Symbol symbol, Timeframe timeframe, int shortSpan, int longSpan) : base(symbol, timeframe)
    {
        ShortSpan = shortSpan;
        LongSpan = longSpan;
    }

    public int ShortSpan { get; init; }
    public int LongSpan { get; init; }

}

/// <summary>
/// ゴールデンクロスで買い、デッドクロスで売る
/// </summary>
/// <remarks>
/// 単一ポジションの取引にのみ対応しているため、稼働後最初にしかポジションをとらない仕様
/// （最初にロングすると停止するまでショートはしない）
/// </remarks>
public class MACross : Strategy<MACrossParameter>
{
    public MACross(Exchange exchange, MACrossParameter parameter, ITradeLogger logger) : base(exchange, parameter, logger)
    {
    }

    protected override async Task MightTrade()
    {
        var shortMa = PastCandles.GetSma(Parameter.ShortSpan);
        var longMa = PastCandles.GetSma(Parameter.LongSpan);

        if (StrategyUtilty.IsGoldenCross(shortMa, longMa))
        {
            await Buy(1);
            return;
        }

        if (StrategyUtilty.IsDeadCross(shortMa, longMa))
        {
            await Sell(1);
            return;
        }
    }
}
