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

    public override int NeedDataCountForAnalysis => Parameters.LastOrDefault(int.MaxValue);
    public override int NeedDataCountForTrade => 2;
    public override StrategyKind KInd => StrategyKind.MACross;

    public MACross(Timeframe timeframe, IEnumerable<int> parameters) : base(timeframe, parameters)
    {
        Debug.Assert(parameters.Count() == 2, "MACrossではパラメーターを2つ設定しなければならない");
        Debug.Assert(parameters.First() < parameters.Last(), "パラメーターの先頭要素が最後尾の要素の数より小さくなければならない");
    }

    public override void Analysis(IEnumerable<Candle> candles)
    {
        var indicators = new Dictionary<string, AnalysisValue>();
        var analysisedDate = candles.MaxBy(candle => candle.Date)?.Date ?? DateTime.UtcNow;
        foreach (var (label, span) in Enumerable.Zip([ShortMALabel, LongMALabel], [Parameters.FirstOrDefault(0), Parameters.LastOrDefault(0)]))
        {
            var ma = candles.GetSma(span).LastOrDefault()?.Sma;
            if (ma != null)
            {
                var value =new AnalysisValue(analysisedDate, (decimal)ma, GraphType.Line);
                indicators.Add(label, value);
            }
        }
        var data = new AnalysisData(candles.Last(), indicators);

        AnalysisSubject.OnNext(data);
    }
}
