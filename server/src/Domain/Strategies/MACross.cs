using BotTrade.Domain.Exceptions;
using BotTrade.Domain.Settings;

using Skender.Stock.Indicators;

namespace BotTrade.Domain.Strategies;

/// <summary>
/// ゴールデンクロスで買い、デッドクロスで売る
/// </summary>
/// <remarks>
///     <list type="table">
///         <listheader>
///             <term>index</term>
///             <description>description</description>
///         </listheader>
///         <item>
///             <term>0</term>
///             <description>短期移動平均期間</description>
///         </item>
///         <item>
///             <term>1</term>
///             <description>長期移動平均期間</description>
///         </item>
///         <item>
///             <term>2</term>
///             <description>取引方向（省略時はロング）</description>
///         </item>
///     </list>
/// </remarks>
internal class MACross : Strategy
{
    private const string ShortMALabel = "ShortMA";
    private const string LongMALabel = "LongMA";

    protected override int NeedDataCountForAnalysis => LongMASpan;
    protected override int NeedDataCountForTrade => 2;
    protected override int NeedParameterSize => 2;
    public override StrategyKind KInd => StrategyKind.MACross;

    protected int ShortMASpan => (int)Parameters.ElementAtOrDefault(0);
    protected int LongMASpan => (int)Parameters.ElementAtOrDefault(1);
    protected StrategyActionType Action
    {
        get
        {
            var action = Parameters.ElementAtOrDefault(2);
            if (action == default)
                return StrategyActionType.Buy;
            return Enum.TryParse<StrategyActionType>(action.ToString(), out var res)
                ? res
                : StrategyActionType.Buy;
        }
    }

    private bool _isMatchedAction = false;

    public MACross(IObservable<Candle> candleStream, StrategySetting setting) : base(candleStream, setting)
    {
    }

    protected override void Validate()
    {
        base.Validate();
        if (ShortMASpan >= LongMASpan)
            throw new InvalidParameterException("短期Maのパラメータは長期Maのパラメータより小さくなければならない");
        if (Action == StrategyActionType.Neutral)
            throw new InvalidParameterException($"{nameof(StrategyActionType.Buy)}または{nameof(StrategyActionType.Sell)}のどちらかを指定");
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

    protected override StrategyActionType OnNextAction(IEnumerable<AnalysisData> datas)
    {
        var shortMa = datas.Select(analysis => analysis.Values[ShortMALabel]);
        var longMa = datas.Select(analysis => analysis.Values[LongMALabel]);
        var nextAction = StrategyActionType.Neutral;

        if (StrategyUtilty.IsGoldenCross(shortMa, longMa))
            nextAction = StrategyActionType.Buy;
        else if (StrategyUtilty.IsDeadCross(shortMa, longMa))
            nextAction = StrategyActionType.Sell;

        if (!_isMatchedAction)
        {
            if (nextAction == Action)
                _isMatchedAction = true;
            else
                nextAction = StrategyActionType.Neutral;
        }

        return nextAction;
    }
}
