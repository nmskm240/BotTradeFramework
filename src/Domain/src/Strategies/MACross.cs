using System.Diagnostics;

using Skender.Stock.Indicators;

namespace BotTrade.Domain.Strategies;

/// <summary>
/// ゴールデンクロスで買い、デッドクロスで売る
/// </summary>
/// <remarks>
/// 単一ポジションの取引にのみ対応しているため、稼働後最初にしかポジションをとらない仕様
/// （最初にロングすると停止するまでショートはしない）
/// </remarks>
public class MACross : Strategy
{
    private const string ShortMALabel = "ShortMA";
    private const string LongMALabel = "LongMA";

    protected override int NeedDataCountForAnalysis => Parameters.LastOrDefault(int.MaxValue);
    protected override int NeedDataCountForTrade => 2;
    public override StrategyKind KInd => StrategyKind.MACross;

    public MACross(IObservable<Candle> candleStream, Setting.Strategy setting) : base(candleStream, setting)
    {
        if (Parameters.Count() != 2)
            throw new ArgumentException($"{nameof(MACross)}ではパラメーターを2つ設定しなければならない", nameof(setting));
        if (Parameters.First() >= Parameters.Last())
            throw new ArgumentException("パラメーターの先頭要素が最後尾の要素の数より小さくなければならない", nameof(setting));
    }

    protected override async Task<AnalysisData> OnAnalysis(IEnumerable<Candle> candles)
    {
        var indicators = new Dictionary<string, AnalysisValue>();
        var date = candles.MaxBy(candle => candle.Date)?.Date ?? DateTime.UtcNow;
        foreach (var (label, span) in Enumerable.Zip([ShortMALabel, LongMALabel], [Parameters.FirstOrDefault(0), Parameters.LastOrDefault(0)]))
        {
            var ma = candles.GetSma(span).LastOrDefault()?.Sma;
            if (ma != null)
            {
                var value = new AnalysisValue((decimal)ma, GraphType.Line);
                indicators.Add(label, value);
            }
        }
        var data = new AnalysisData(date, candleIndicators: indicators);
        return await Task.FromResult(data);
    }

    public override StrategyActionType OnNextAction(IEnumerable<AnalysisData> datas)
    {
        var prevShortMa = datas.First().ChartPlotValues[ShortMALabel].Value;
        var prevLongMa = datas.First().ChartPlotValues[LongMALabel].Value;
        var currentShortMa = datas.Last().ChartPlotValues[ShortMALabel].Value;
        var currentLongMa = datas.Last().ChartPlotValues[LongMALabel].Value;

        if (StrategyUtilty.IsGoldenCross([prevShortMa, currentShortMa], [prevLongMa, currentLongMa]))
        {
            return StrategyActionType.Buy;
        }

        if (StrategyUtilty.IsDeadCross([prevShortMa, currentShortMa], [prevLongMa, currentLongMa]))
        {
            return StrategyActionType.Sell;
        }

        return StrategyActionType.Neutral;
    }
}
