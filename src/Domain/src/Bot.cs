using System.Diagnostics;
using System.Reactive.Linq;

using BotTrade.Domain.Strategies;

using Microsoft.Extensions.Logging;

namespace BotTrade.Domain;

public class Bot : IDisposable
{
    public decimal Capital { get; private set; }
    public bool IsStarted { get; private set; } = false;

    protected IExchange Exchange { get; init; }
    //MEMO: 複数戦略でAND/OR判定できるように多次元構造にしたい
    protected IEnumerable<Strategy> Strategies { get; init; }
    protected ITradeLogger TradeLogger { get; init; }
    protected ILogger<Bot> Logger { get; init; }
    protected Timeframe SmallestTimeframe => Strategies.MaxBy(strategy =>
            (int)strategy.Timeframe)?.Timeframe ?? Timeframe.OneMinute;

    private IList<IDisposable> Subscriptions { get; init; }

    public Bot(Setting.Bot setting, IExchange exchange, IEnumerable<Strategy> strategies, ITradeLogger tradeLogger, ILogger<Bot> logger)
    {
        Exchange = exchange;
        Strategies = strategies;
        TradeLogger = tradeLogger;
        Logger = logger;
        Capital = setting.Capital;

        Subscriptions = [
            Exchange.OnPulled
                .Subscribe(
                    TradeLogger.Log,
                    async () => await Stop()
                ),
            .. Strategies.Select(strategy =>
                Exchange.OnPulled
                    .Buffer((int)strategy.Timeframe)
                    .Select(candles => Candle.Aggregate(candles, strategy.Timeframe))
                    .Buffer(strategy.NeedDataCountForAnalysis, 1)
                    .Subscribe(strategy.Analysis)
                ),
            Observable.CombineLatest(
                Strategies.Select(strategy =>
                    strategy.OnAnalysised
                )
            ).Subscribe(
                datas => {
                    foreach(var data in datas)
                    {
                        TradeLogger.Log(data);
                    }
                }
            ),
            Observable.CombineLatest(
                Strategies.Select(strategy =>
                    strategy.OnAnalysised
                        .Buffer(strategy.NeedDataCountForTrade)
                        .Select(strategy.RecommendedAction)
                )
            ).Subscribe(
                async datas => await Trade(datas)
            ),
        ];
    }

    public void Start()
    {
        if (IsStarted) return;
        IsStarted = true;
        Exchange.OnPulled.Connect();
    }

    public async Task Stop()
    {
        Capital += await Exchange.ClosePositionAll();
        IsStarted = false;
        UnSubscribe();
        TradeLogger.Stop();
    }

    public void Dispose()
    {
        if (IsStarted) UnSubscribe();
        GC.SuppressFinalize(this);
    }

    private async Task Trade(IEnumerable<StrategyActionType> recommendedActions)
    {
        if (recommendedActions.All(action => action == StrategyActionType.Buy))
        {
            if (Exchange.Positions.Count > 0)
            {
                Capital += await Exchange.ClosePositionAll();
                return;
            }
            var position = await Exchange.Buy(1);
            position.OnClosed += TradeLogger.Log;
        }
        else if (recommendedActions.All(action => action == StrategyActionType.Sell))
        {
            if (Exchange.Positions.Count > 0)
            {
                Capital += await Exchange.ClosePositionAll();
                return;
            }
            var position = await Exchange.Sell(1);
            position.OnClosed += TradeLogger.Log;
        }
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
