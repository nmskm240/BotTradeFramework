

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
    public MACross(IExchange exchange, MACrossParameter parameter) : base(exchange, parameter)
    {
    }

    protected override void MightTrade()
    {
        var shortMa = PastCandles.GetSma(Parameter.ShortSpan);
        var longMa = PastCandles.GetSma(Parameter.LongSpan);

        Console.WriteLine(shortMa.First());

        if(StrategyUtilty.IsGoldenCross(shortMa, longMa))
        {
            Exchange.Buy(Parameter.Symbol, 1);
        }
        else if(StrategyUtilty.IsDeadCross(shortMa, longMa))
        {
            Exchange.Sell(Parameter.Symbol, 1);
        }
    }
}
