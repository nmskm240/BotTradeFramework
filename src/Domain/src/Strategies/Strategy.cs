using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace BotTrade.Domain.Strategies;

// MEMO: あとでアービトラージ系に対応するなら、インターフェースと抽象クラスに切り分けた方がいいかもしれない
/// <summary>
/// 取引戦略のベースクラス
/// </summary>
/// <remarks>
/// アービトラージなどの複数の取引所の監視や、両建てのような複数ポジションの管理には非対応<br/>
/// </remarks>
/// <typeparam name="T"></typeparam>
public abstract class Strategy<T> : IDisposable where T : StrategyParameter
{
    private List<IDisposable> Subscriptions {get; init;}

    private Exchange Exchange { get; init; }
    protected T Parameter { get; init; }
    private Position? OpenPosition { get; set; } = null;
    private ITradeLogger Logger { get; init; }
    public bool IsStarted { get; private set; } = false;
    public decimal Capital { get; private set; }
    /// <summary>
    /// 1回の分析に必要な確定データの個数
    /// </summary>
    /// <remarks>
    /// 指定された個数確定するまで<c>Analysis</c>の呼び出しはされない
    /// </remarks>
    public abstract int NeedDataCountForAnalysis { get; }
    /// <summary>
    /// 1回の取引に必要な確定データの個数
    /// </summary>
    /// <remarks>
    /// 指定された個数確定するまで<c>Trade</c>の呼び出しはされない
    /// </remarks>
    public abstract int NeedDataCountForTrade { get; }
    public event Action? OnStoped = null;
    private readonly Subject<AnalysisData> _onAnalysed = new Subject<AnalysisData>();
    public IObservable<AnalysisData> OnAnalysed => _onAnalysed;

    public Strategy(Exchange exchange, T parameter, ITradeLogger logger)
    {
        Debug.Assert(exchange != null);
        Debug.Assert(parameter != null);

        Exchange = exchange;
        Parameter = parameter;
        Logger = logger;
        Subscriptions = [
            Exchange.OnFetchedCandle
                .Subscribe(
                    (_) => {} ,
                    async () => await Stop()
                ),
            Exchange.OnFetchedCandle
                .Buffer(NeedDataCountForAnalysis, 1)
                .Select(Analysis)
                .Subscribe(_onAnalysed),
            OnAnalysed
                .Buffer(NeedDataCountForTrade, 1)
                .Subscribe(
                    async value => await Trade(value)
                ),
        ];
    }

    public void MightStart(decimal capital)
    {
        if (IsStarted)
        {
            return;
        }

        Capital = capital;
        IsStarted = true;
        Exchange.OnFetchedCandle.Connect();
    }

    public async Task Stop()
    {
        UnSubscribe();
        if (OpenPosition?.Status == PositionStatus.Open)
        {
            await Exchange.ClosePosition(OpenPosition);
        }
        IsStarted = false;
        Logger.Close();
        OnStoped?.Invoke();
    }

    public void Dispose()
    {
        if (IsStarted) UnSubscribe();
        GC.SuppressFinalize(this);
    }

    private void UnSubscribe()
    {
        _onAnalysed.Dispose();
        foreach(var subscription in Subscriptions)
        {
            subscription.Dispose();
        }
        Subscriptions.Clear();
    }

    // MEMO: ポジションを1つしか持てないように制限するための実装
    protected async Task Buy(decimal quantity)
    {
        if (OpenPosition?.Status == PositionStatus.Open)
        {
            Capital += await Exchange.ClosePosition(OpenPosition);
            OpenPosition = null;
        }
        else
        {
            OpenPosition = await Exchange.Buy(Parameter.Symbol, quantity);
            OpenPosition.OnClosed += Logger.WritePositionHistory;
        }
    }

    protected async Task Sell(decimal quantity)
    {
        if (OpenPosition?.Status == PositionStatus.Open)
        {
            Capital += await Exchange.ClosePosition(OpenPosition);
            OpenPosition = null;
        }
        else
        {
            OpenPosition = await Exchange.Sell(Parameter.Symbol, quantity);
            OpenPosition.OnClosed += Logger.WritePositionHistory;
        }
    }

    /// <summary>
    /// 確定
    /// </summary>
    /// <param name="candles">取引所の確定足</param>
    /// <returns>計算後のインジケーターの値を含む解析データ</returns>
    protected abstract AnalysisData Analysis(IEnumerable<Candle> candles);
    protected abstract Task Trade(IEnumerable<AnalysisData> analyses);
}
