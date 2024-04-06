

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
    public MACross(IExchange exchange, decimal capital, MACrossParameter parameter) : base(exchange, capital, parameter)
    {
    }

    protected override async Task MightTrade()
    {
        var shortMa = PastCandles.GetSma(Parameter.ShortSpan);
        var longMa = PastCandles.GetSma(Parameter.LongSpan);

        if(StrategyUtilty.IsGoldenCross(shortMa, longMa))
        {
            await Buy(1);
        }
        else if(StrategyUtilty.IsDeadCross(shortMa, longMa))
        {
            await Sell(1);
        }
    }
}
