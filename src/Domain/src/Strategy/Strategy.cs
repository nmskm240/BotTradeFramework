using System.Diagnostics;
using System.Reactive.Linq;

namespace BotTrade.Domain.Strategy;

/// <summary>
/// 取引戦略のベースクラス
/// </summary>
/// <remarks> 
/// アービトラージなどの複数の取引所の監視や両建てには非対応<br/>
/// </remarks> 
/// <typeparam name="T"></typeparam>
public abstract class Strategy<T> : IDisposable where T : StrategyParameter
{
    private IDisposable? _disposable;
    
    /// <summary>
    /// 確定足のキャッシュデータ 
    /// </summary>
    /// <remarks>
    /// 指定された容量のみ所持し、上限に達すると古いものから削除される<br/>
    /// キュー管理のため最新は<c>Last</c>、最古は<c>First</c>で取得 
    /// </remarks>
    protected RingQueue<Candle> PastCandles { get; init; }
    protected IExchange Exchange { get; init; }
    protected T Parameter { get; init; }
    public bool IsStarted { get; private set; } = false;

    protected Strategy(IExchange exchange, T parameter)
    {
        Debug.Assert(exchange != null);
        Debug.Assert(parameter != null);

        // TODO: Configから変更できるようにする
        PastCandles = new RingQueue<Candle>(100);
        Exchange = exchange;
        Parameter = parameter;
    }

    public void MightStart()
    {
        if (IsStarted) return;
        
        OnPreStart();
        _disposable = Exchange.OnFetchedCandle(Parameter.Symbol, Parameter.Timeframe)
                        .Subscribe(
                            OnNext,
                            (ex) => Stop(),
                            Stop
                        );
        IsStarted = true;
        OnPostStart();
    }

    public void Stop()
    {
        OnPreStop();
        _disposable?.Dispose();
        _disposable = null;
        IsStarted = false;
        OnPostStop();
    }

    public void Dispose()
    {
        if (IsStarted) Stop();
        GC.SuppressFinalize(this);
    }

    private void OnNext(Candle candle)
    {
        PastCandles.Enqueue(candle);
        MightTrade();
    }

    protected virtual void OnPreStart() { }
    protected virtual void OnPostStart() { }
    protected virtual void OnPreStop() { }
    protected virtual void OnPostStop() { }
    protected abstract void MightTrade();
}
