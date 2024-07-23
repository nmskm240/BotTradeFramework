using BotTrade.Domain.Settings;

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

    protected override int NeedDataCountForAnalysis => (int)Parameters.LastOrDefault(decimal.MaxValue);
    protected override int NeedDataCountForTrade => 2;
    public override StrategyKind KInd => StrategyKind.MACross;

    protected int ShortMASpan => (int)Parameters.FirstOrDefault(0);
    protected int LongMASpan => (int)Parameters.LastOrDefault(0);

    public MACross(IObservable<Candle> candleStream, StrategySetting setting) : base(candleStream, setting)
    {
        if (Parameters.Count() != 2)
            throw new ArgumentException($"{nameof(MACross)}ではパラメーターを2つ設定しなければならない", nameof(setting));
        if (Parameters.First() >= Parameters.Last())
            throw new ArgumentException("パラメーターの先頭要素が最後尾の要素の数より小さくなければならない", nameof(setting));
    }

    protected override Task<Dictionary<string, decimal>> OnAnalysis(IEnumerable<Candle> candles)
    {
        var shortMa = candles.GetSma(ShortMASpan).Last()?.Sma ?? 0;
        var longMa = candles.GetSma(LongMASpan).Last()?.Sma ?? 0;
        var values = new Dictionary<string, decimal>()
        {
            { ShortMALabel, (decimal)shortMa },
            { LongMALabel, (decimal)longMa },
        };
        return Task.FromResult(values);
    }

    public override StrategyActionType OnNextAction(IEnumerable<AnalysisData> datas)
    {
        var shortMa = datas.Select(analysis => analysis.Values[ShortMALabel]);
        var longMa = datas.Select(analysis => analysis.Values[LongMALabel]);

        if (StrategyUtilty.IsGoldenCross(shortMa, longMa))
            return StrategyActionType.Buy;

        if (StrategyUtilty.IsDeadCross(shortMa, longMa))
            return StrategyActionType.Sell;

        return StrategyActionType.Neutral;
    }
}
