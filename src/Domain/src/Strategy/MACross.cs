

using Microsoft.Extensions.Logging;
using Skender.Stock.Indicators;

namespace BotTrade.Domain.Strategy;

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

public class MACross : Strategy<MACrossParameter>
{
    public MACross(Exchange exchange, MACrossParameter parameter, ILogger<MACross> logger) : base(exchange, parameter, logger)
    {
    }

    protected override async Task MightTrade()
    {
        var shortMa = PastCandles.GetSma(Parameter.ShortSpan);
        var longMa = PastCandles.GetSma(Parameter.LongSpan);

        if (StrategyUtilty.IsGoldenCross(shortMa, longMa))
        {
            await Buy(1);
        }
        else if (StrategyUtilty.IsDeadCross(shortMa, longMa))
        {
            await Sell(1);
        }
    }
}
