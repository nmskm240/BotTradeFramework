using System.Reactive.Subjects;

namespace BotTrade.Domain.Strategies;

public abstract class Strategy
{
    protected Subject<AnalysisData> AnalysisSubject = new();

    public abstract StrategyKind KInd { get; }
    public Timeframe Timeframe { get; init; }
    public IEnumerable<int> Parameters { get; init; }
    public abstract int NeedDataCountForAnalysis { get; }
    public abstract int NeedDataCountForTrade { get; }
    public IObservable<AnalysisData> OnAnalysised => AnalysisSubject;

    public Strategy(Timeframe timeframe, IEnumerable<int> parameters)
    {
        Timeframe = timeframe;
        Parameters = parameters;
    }

    protected abstract Task<AnalysisData> Analysis(IEnumerable<Candle> candles);
    public abstract StrategyActionType RecommendedAction(IEnumerable<AnalysisData> datas);

    internal async Task OnAnalysis(IEnumerable<Candle> candles)
    {
        var data = await Analysis(candles);
        AnalysisSubject.OnNext(data);
    }

    public static Strategy FromSetting(Setting.Strategy setting)
    {
        return setting.Kind switch
        {
            StrategyKind.MACross => new MACross(setting.Timeframe, setting.Parameters),
            _ => throw new ArgumentException("未対応の戦略", nameof(setting.Kind)),
        };
    }

    public override string ToString()
    {
        var parameters = string.Join(", ", Parameters);
        return $"{KInd.GetStringValue()}({parameters})";
    }
}
