using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain.Exceptions;
using BotTrade.Domain.Settings;

namespace BotTrade.Domain;

public abstract class Strategy : IDisposable
{
    private CompositeDisposable Disposables { get; init; }
    protected abstract int NeedParameterSize { get; }
    protected abstract int NeedDataCountForAnalysis { get; }
    protected abstract int NeedDataCountForTrade { get; }
    public abstract StrategyKind KInd { get; }
    public Timeframe Timeframe { get; init; }
    public IEnumerable<decimal> Parameters { get; init; }

    private Subject<AnalysisData> AnalysisSubject { get; init; }
    protected IObservable<AnalysisData> OnAnalysised => AnalysisSubject;
    private Subject<StrategyActionType> NextActionSubject { get; init; }
    protected IObservable<StrategyActionType> OnComfirmedNextAction => NextActionSubject;
    public IObservable<TradePoint> OnTradePointWithEvidence { get; init; }

    public Strategy(IObservable<Candle> candleStream, StrategySetting setting)
    {
        Timeframe = setting.Timeframe;
        Parameters = setting.Parameters;
        AnalysisSubject = new();
        NextActionSubject = new();
        OnTradePointWithEvidence = OnComfirmedNextAction
            .Where(action => action != StrategyActionType.Neutral)
            .WithLatestFrom(OnAnalysised.Buffer(NeedDataCountForTrade),
                (action, analyses) => new TradePoint(action, analyses)
            );

        Validate();

        Disposables = new(
            candleStream
                .Buffer((int)Timeframe)
                .Select(candles => Candle.Aggregate(candles, Timeframe))
                .Buffer(NeedDataCountForAnalysis, 1)
                .Subscribe(
                    async candles => await Analysis(candles)
                ),
            OnAnalysised
                .Buffer(NeedDataCountForTrade, 1)
                .Subscribe(NextAction)
        );
    }

    protected abstract Task<Dictionary<string, decimal>> OnAnalysis(IEnumerable<Candle> candles);
    protected abstract StrategyActionType OnNextAction(IEnumerable<AnalysisData> datas);

    protected virtual void Validate()
    {
        if (Parameters.Count() < NeedParameterSize)
            throw new InvalidParameterException($"パラメータ数が{NeedParameterSize}以上必要");
    }

    private async Task Analysis(IEnumerable<Candle> candles)
    {
        if (candles.Count() < NeedDataCountForAnalysis)
        {
            AnalysisSubject.OnCompleted();
        }
        else
        {
            var date = candles.MaxBy(candle => candle.Date)?.Date ?? DateTime.UtcNow;
            var data = await OnAnalysis(candles);
            var analysis = new AnalysisData(date, data);
            AnalysisSubject.OnNext(analysis);
        }
    }

    private void NextAction(IEnumerable<AnalysisData> analyses)
    {
        if (analyses.Count() < NeedDataCountForTrade)
        {
            NextActionSubject.OnCompleted();
        }
        else
        {
            var action = OnNextAction(analyses);
            NextActionSubject.OnNext(action);
        }
    }

    public static Strategy FromSetting(StrategySetting setting, IObservable<Candle> stream)
    {
        if (setting.Kind.Reflection<Strategy>(stream, setting) is not Strategy strategy)
        {
            throw new ArgumentException("生成できない戦略", nameof(setting));
        }

        return strategy;
    }

    public override string ToString()
    {
        var parameters = string.Join(", ", Parameters);
        return $"{KInd.GetStringValue()}({parameters})";
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposable)
    {
        if (disposable)
        {
            AnalysisSubject.OnCompleted();
            NextActionSubject.OnCompleted();

            Disposables.Dispose();
        }
    }
}
