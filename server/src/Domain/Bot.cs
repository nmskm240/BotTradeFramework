using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain.Settings;

using Microsoft.Extensions.Logging;

using Python.Runtime;

namespace BotTrade.Domain;

public class Bot : IDisposable
{
    public float Lot { get; init; }
    public bool IsRunning { get; private set; } = false;
    protected ITradeHistoryRepository TradeHistory { get; init; }
    protected bool IsTakeableMultiPosition { get; init; }
    protected IExchange Exchange { get; init; }
    protected Strategy Strategy { get; init; }
    protected ILogger<Bot> Logger { get; init; }
    private CompositeDisposable Disposables { get; init; }

    private Subject<Position> TradedSubject { get; init; }
    private IObservable<Position> OnTraded => TradedSubject;
    public IObservable<(Position, TradePoint)> OnTradedWithEvidence { get; init; }

    public Bot(BotSetting setting, IExchange exchange, Strategy strategy, ITradeHistoryRepository tradeHistory, ILogger<Bot> logger)
    {
        Exchange = exchange;
        Strategy = strategy;
        Logger = logger;
        Lot = setting.Lot;
        IsTakeableMultiPosition = setting.IsTakeableMultiPosition;
        TradeHistory = tradeHistory;
        TradedSubject = new();

        OnTradedWithEvidence = OnTraded
            .WithLatestFrom(Strategy.OnTradePointWithEvidence);

        Disposables = new(
            Strategy.OnTradePointWithEvidence
                .Subscribe(
                    async tradePoint => await Trade(tradePoint.Action),
                    async () => await Stop()
                )
        );
    }
    public async Task Start()
    {
        if (IsRunning)
            return;
        Logger.LogInformation("Bot start at [{strategies}] in {exchange}_{symbol}_{timeframe}",
            string.Join(", ", Strategy.ToString()),
            Exchange.Place,
            Exchange.Symbol.GetStringValue(),
            Strategy.Timeframe.GetStringValue()
        );
        IsRunning = true;
        await Task.Run(async () =>
        {
            Exchange.OnPulled.Connect();

            while (IsRunning)
                await Task.Delay(100);
        });
    }

    public async Task Stop()
    {
        Disposables.Clear();
        await Exchange.ClosePositionAll();
        IsRunning = false;
    }

    public async Task<StrategyReport> Report()
    {
        var trades = await TradeHistory.GetAll();
        return new StrategyReport(trades);
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
            Disposables.Dispose();
            Strategy.Dispose();
        }
    }

    /// <summary>
    /// 戦略の分析に基づいて取引所で売買を行う
    /// </summary>
    /// <param name="tradePoint"></param>
    /// <returns></returns>
    private async Task Trade(StrategyActionType action)
    {
        var currentPosition = Exchange.Positions.FirstOrDefault();

        if (currentPosition != null)
        {
            var shouldClosePostion = (currentPosition.Type == PositionType.Long && action == StrategyActionType.Sell) ||
                                        (currentPosition.Type == PositionType.Short && action == StrategyActionType.Buy);
            if (shouldClosePostion)
            {
                var pl = await Exchange.ClosePositionAll();
                return;
            }
            else if (!IsTakeableMultiPosition)
            {
                return;
            }
        }

        var newPosition = action switch
        {
            StrategyActionType.Buy => await Exchange.Buy(Lot),
            StrategyActionType.Sell => await Exchange.Sell(Lot),
            _ => throw new NotSupportedException(),
        };
        newPosition.OnClosed += async (t) => await TradeHistory.AddHistory(t);
        newPosition.OnClosed += TradedSubject.OnNext;
        TradedSubject.OnNext(newPosition);
    }
}
