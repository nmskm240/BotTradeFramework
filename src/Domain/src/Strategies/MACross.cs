using Microsoft.Extensions.Logging;

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
    private const string ShortMALabel = "ShortMA";
    private const string LongMALabel = "LongMA";

    public override int NeedDataCountForAnalysis => Parameter.LongSpan;
    public override int NeedDataCountForTrade => 2;

    public MACross(Exchange exchange, MACrossParameter parameter, ITradeLogger logger) : base(exchange, parameter, logger) { }

    protected override AnalysisData Analysis(IEnumerable<Candle> candles)
    {
        var indicators = new Dictionary<string, AnalysisValue>();
        foreach (var (label, span) in Enumerable.Zip([ShortMALabel, LongMALabel], [Parameter.ShortSpan, Parameter.LongSpan]))
        {
            var ma = candles.GetSma(span).LastOrDefault()?.Sma;
            if (ma != null)
            {
                indicators.Add(label, new AnalysisValue((decimal)ma, GraphType.Line));
            }
        }

        return new AnalysisData(candles.Last(), indicators);
    }

    protected override async Task Trade(IEnumerable<AnalysisData> analyses)
    {
        var recentryAnalysises = analyses.SelectMany(data => data.ChartPlotValues)
            .GroupBy(pair => pair.Key)
            .ToDictionary(
                group => group.Key,
                group => group.Select(pair => pair.Value.Value)
            ) ?? [];
        var shortMa = Enumerable.Empty<decimal>();
        var longMa = Enumerable.Empty<decimal>();

        recentryAnalysises.TryGetValue(ShortMALabel, out shortMa);
        recentryAnalysises.TryGetValue(LongMALabel, out longMa);

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
