using System.Diagnostics;
using System.Reactive.Linq;

using BotTrade.Domain.Strategies;

using Microsoft.Extensions.Logging;

using Reactive.Bindings;

namespace BotTrade.Domain;

public class Bot : IDisposable
{
    public ReactiveProperty<decimal> StartCapital { get; private set; }
    public ReactiveProperty<decimal> NowCapital { get; private set; }
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
        NowCapital = new ReactiveProperty<decimal>();
        StartCapital = new ReactiveProperty<decimal>();

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
                datas =>
                {
                    foreach (var data in datas)
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
            Exchange.OnPulled.CombineLatest(NowCapital)
                .Select(e => new CapitalFlow() { DateTime = e.First.Date, Capital = (double)e.Second })
                .Subscribe(TradeLogger.Log),
        ];

        NowCapital.Value = setting.Capital;
        StartCapital.Value = setting.Capital;
    }

    public void Start()
    {
        if (IsStarted) return;
        Logger.LogInformation("Bot start at [{strategies}] from {capital} in {exchange}_{symbol}_{timeframe}",
            string.Join(", ", Strategies.Select(strategy => strategy.ToString())),
            StartCapital.Value,
            Exchange.Place,
            Exchange.Symbol.GetStringValue(),
            SmallestTimeframe.GetStringValue()
        );
        IsStarted = true;
        Exchange.OnPulled.Connect();
    }

    public async Task Stop()
    {
        NowCapital.Value += await Exchange.ClosePositionAll();
        Logger.LogInformation("Bot stoped. Profit/loss {pl}",
            StartCapital.Value - NowCapital.Value
        );
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
                NowCapital.Value += await Exchange.ClosePositionAll();
                return;
            }
            var position = await Exchange.Buy(0.01f);
            position.OnClosed += TradeLogger.Log;
        }
        else if (recommendedActions.All(action => action == StrategyActionType.Sell))
        {
            if (Exchange.Positions.Count > 0)
            {
                NowCapital.Value += await Exchange.ClosePositionAll();
                return;
            }
            var position = await Exchange.Sell(0.01f);
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
