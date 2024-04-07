using System.Diagnostics;
using System.Reactive.Linq;
using Microsoft.Extensions.Logging;

namespace BotTrade.Domain.Strategy;

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
    private IExchange Exchange { get; init; }
    protected T Parameter { get; init; }
    public bool IsStarted { get; private set; } = false;
    private Position? Position { get; set; }
    // TODO: 外部保存できるようにDI化したい
    private List<Position> TradeHistory { get; } = [];
    private ILogger Logger { get; init; }
    public decimal Capital { get; private set; }

    protected Strategy(IExchange exchange, T parameter, ILogger<Strategy<T>> logger)
    {
        Debug.Assert(exchange != null);
        Debug.Assert(parameter != null);

        // TODO: Configから変更できるようにする
        PastCandles = new RingQueue<Candle>(100);
        Exchange = exchange;
        Parameter = parameter;
        Logger = logger;
    }

    public void MightStart(decimal capital)
    {
        if (IsStarted) 
        {
            Logger.LogWarning("すでに動作中のため実行をキャンセル");
            return;
        }

        Logger.LogInformation($"{GetType()}を所持金{capital}で稼働");
        
        OnPreStart();

        _subscription = Exchange.OnFetchedCandle(Parameter.Symbol, Parameter.Timeframe)
                        .Subscribe(
                            async value => await OnNext(value),
                            (ex) => Stop(),
                            Stop
                        );
        IsStarted = true;
        OnPostStart();
    }

    public void Stop()
    {
        OnPreStop();
        _subscription?.Dispose();
        _subscription = null;
        IsStarted = false;
        OnPostStop();
    }

    public void Dispose()
    {
        if (IsStarted) Stop();
        GC.SuppressFinalize(this);
    }

    private async Task OnNext(Candle candle)
    {
        PastCandles.Enqueue(candle);
        await MightTrade();
    }

    // MEMO: ポジションを1つしか持てないように制限するための実装
    protected async Task Buy(decimal quantity)
    {
        if(Position?.Status == PositionStatus.Open)
        {
            Capital += await Exchange.ClosePosition(Position);
            Console.WriteLine($"position close. Capital: {Capital}");
            return;
        }

        Position = await Exchange.Buy(Parameter.Symbol, quantity);
        Console.WriteLine($"position create. type: {Position.Type} entry: {Position.Entry}");
        TradeHistory.Add(Position);
    }

    protected async Task Sell(decimal quantity)
    {
        if(Position?.Status == PositionStatus.Open)
        {
            Capital += await Exchange.ClosePosition(Position);
            Console.WriteLine($"position close. Capital: {Capital}");
            return;
        }

        Position = await Exchange.Sell(Parameter.Symbol, quantity);
        Console.WriteLine($"position create. type: {Position.Type} entry: {Position.Entry}");
        TradeHistory.Add(Position);
    }

    protected virtual void OnPreStart() { }
    protected virtual void OnPostStart() { }
    protected virtual void OnPreStop() { }
    protected virtual void OnPostStop() { }
    protected abstract Task MightTrade();
}
