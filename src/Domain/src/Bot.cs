using System.Diagnostics;
using System.Reactive.Linq;

using BotTrade.Domain.Strategies;

using Microsoft.Extensions.Logging;

using Reactive.Bindings;

namespace BotTrade.Domain;

public class Bot : IDisposable
{
    public float Lot { get; init; }
    public bool IsStarted { get; private set; } = false;

    public IStrategyReporter? Reporter { get; init; }
    public IChartMaker? ChartMaker { get; init; }
    protected IExchange Exchange { get; init; }
    protected IEnumerable<Strategy> Strategies { get; init; }
    protected ILogger<Bot> Logger { get; init; }
    protected Timeframe SmallestTimeframe => Strategies.MaxBy(strategy =>
            (int)strategy.Timeframe)?.Timeframe ?? Timeframe.OneMinute;

    private IList<IDisposable> Subscriptions { get; init; }

    public Bot(Setting.Bot setting, IExchange exchange, IEnumerable<Strategy> strategies, ILogger<Bot> logger, IStrategyReporter? reporter = null, IChartMaker? chartMaker = null)
    {
        Exchange = exchange;
        Strategies = strategies;
        Logger = logger;
        Lot = setting.Lot;
        Reporter = reporter;
        ChartMaker = chartMaker;

        Subscriptions = [
            Exchange.OnPulled
                .Subscribe(
                    ChartMaker!.Plot
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
                        ChartMaker?.Plot(data);
                    }
                }
            ),
            Observable.CombineLatest(
                Strategies.Select(strategy =>
                    strategy.OnComfirmedNextAction
                )
            ).Subscribe(
                async datas => await Trade(datas),
                async () => await Stop()
            ),
        ];
    }

    public void Start()
    {
        if (IsStarted) return;
        Logger.LogInformation("Bot start at [{strategies}] in {exchange}_{symbol}_{timeframe}",
            string.Join(", ", Strategies.Select(strategy => strategy.ToString())),
            Exchange.Place,
            Exchange.Symbol.GetStringValue(),
            SmallestTimeframe.GetStringValue()
        );
        IsStarted = true;
        Exchange.OnPulled.Connect();
    }

    public async Task Stop()
    {
        await Exchange.ClosePositionAll();
        IsStarted = false;
        UnSubscribe();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposable)
    {
        if (IsStarted)
            UnSubscribe();

        if (disposable)
        {
            ChartMaker?.Dispose();
            Reporter?.Dispose();

            foreach (var strategy in Strategies)
            {
                strategy.Dispose();
            }
        }
    }

    private async Task Trade(IEnumerable<StrategyActionType> recommendedActions)
    {
        if (recommendedActions.All(action => action == StrategyActionType.Buy))
        {
            if (Exchange.Positions.Count > 0)
            {
                var pl = await Exchange.ClosePositionAll();
                Logger.LogInformation("Position close. P/L: {pl}", pl);
                return;
            }
            var position = await Exchange.Buy(Lot);
            Logger.LogInformation("Buy order. price: {entryPrice}, quantity: {lot}", position.Entry, Lot);
            position.OnClosed += (position) => Reporter?.Log(position);
        }
        else if (recommendedActions.All(action => action == StrategyActionType.Sell))
        {
            if (Exchange.Positions.Count > 0)
            {
                var pl = await Exchange.ClosePositionAll();
                Logger.LogInformation("Position close. P/L: {pl}", pl);
                return;
            }
            var position = await Exchange.Sell(Lot);
            Logger.LogInformation("Sell order. price: {entryPrice}, quantity: {lot}", position.Entry, Lot);
            position.OnClosed += (position) => Reporter?.Log(position);
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
