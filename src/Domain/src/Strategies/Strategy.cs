using System.Diagnostics;
using System.Reactive.Linq;
using Microsoft.Extensions.Logging;

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
    private IDisposable? _subscription;

    /// <summary>
    /// 確定足のキャッシュデータ
    /// </summary>
    /// <remarks>
    /// 指定された容量のみ所持し、上限に達すると古いものから削除される<br/>
    /// キュー管理のため最新は<c>Last</c>、最古は<c>First</c>で取得
    /// </remarks>
    protected RingQueue<Candle> PastCandles { get; init; }
    private Exchange Exchange { get; init; }
    protected T Parameter { get; init; }
    private Position? OpenPosition { get; set; } = null;
    private ITradeLogger Logger { get; init; }
    public bool IsStarted { get; private set; } = false;
    public decimal Capital { get; private set; }
    public event Action? OnStoped = null;

    public Strategy(Exchange exchange, T parameter, ITradeLogger logger)
    {
        Debug.Assert(exchange != null);
        Debug.Assert(parameter != null);

        // TODO: Configから変更できるようにする
        PastCandles = new RingQueue<Candle>(100);
        Exchange = exchange;
        Parameter = parameter;
        Logger = logger;
        _subscription = Exchange.OnFetchedCandle
                        .Subscribe(
                            async value => await OnNext(value),
                            async ex => await Stop(),
                            async () => await Stop()
                        );
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
        if(OpenPosition?.Status == PositionStatus.Open)
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
        _subscription?.Dispose();
        _subscription = null;
    }

    private async Task OnNext(Candle candle)
    {
        PastCandles.Enqueue(candle);
        await MightTrade();
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

    protected abstract Task MightTrade();
}
