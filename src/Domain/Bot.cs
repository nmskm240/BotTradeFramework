using System.Reactive.Linq;

using BotTrade.Domain.Settings;

using Microsoft.Extensions.Logging;

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

    private IList<IDisposable> Subscriptions { get; init; }

    public Bot(BotSetting setting, IExchange exchange, Strategy strategy, ITradeHistoryRepository tradeHistory, ILogger<Bot> logger)
    {
        Exchange = exchange;
        Strategy = strategy;
        Logger = logger;
        Lot = setting.Lot;
        IsTakeableMultiPosition = setting.IsTakeableMultiPosition;
        TradeHistory = tradeHistory;

        Subscriptions = [
            Strategy.OnComfirmedNextAction
                .Subscribe(
                    async action => await Trade(action),
                    async () => await Stop()
                ),
        ];
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
        UnSubscribe();
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
            UnSubscribe();
            Strategy.Dispose();
        }
    }

    /// <summary>
    /// 戦略の分析に基づいて取引所で売買を行う
    /// </summary>
    /// <remarks>
    /// 分析結果で1つでも<c>StrategyActionType.Neutral</c>があれば売買は行わない。
    /// </remarks>
    /// <param name="action"></param>
    /// <returns></returns>
    private async Task Trade(StrategyActionType action)
    {
        if (action == StrategyActionType.Neutral)
            return;

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
    }

    private void UnSubscribe()
    {
        foreach (var subscription in Subscriptions)
        {
            subscription.Dispose();
        }
        Subscriptions.Clear();
    }
}
