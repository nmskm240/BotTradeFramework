using System.Reactive.Linq;

using BotTrade.Domain.Strategies;

using Microsoft.Extensions.Logging;

namespace BotTrade.Domain;

public class Bot : IDisposable
{
    public float Lot { get; init; }
    public bool IsStarted { get; private set; } = false;

    public IStrategyReporter? Reporter { get; init; }
    public IChartMaker? ChartMaker { get; init; }
    protected bool IsTakeableMultiPosition { get; init; }
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
        IsTakeableMultiPosition = setting.IsTakeableMultiPosition;
        Reporter = reporter;
        ChartMaker = chartMaker;

        Subscriptions = [
            Exchange.OnPulled
                .Buffer((int)SmallestTimeframe)
                .Select(candles => Candle.Aggregate(candles, SmallestTimeframe))
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

    /// <summary>
    /// 戦略の分析に基づいて取引所で売買を行う
    /// </summary>
    /// <remarks>
    /// 分析結果で1つでも<c>StrategyActionType.Neutral</c>があれば売買は行わない。
    /// </remarks>
    /// <param name="actions"></param>
    /// <returns></returns>
    private async Task Trade(IEnumerable<StrategyActionType> actions)
    {
        if (actions.Any(action => action == StrategyActionType.Neutral))
            return;

        var action = actions.First();
        var currentPosition = Exchange.Positions.FirstOrDefault();

        if (currentPosition != null)
        {
            var shouldClosePostion = (currentPosition.Type == PositionType.Long && action == StrategyActionType.Sell) ||
                                        (currentPosition.Type == PositionType.Short && action == StrategyActionType.Buy);
            if (shouldClosePostion)
            {
                var pl = await Exchange.ClosePositionAll();
                Logger.LogInformation("Position close. P/L: {pl}", pl);
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

        Logger.LogInformation("Sell order. price: {entryPrice}, quantity: {lot}", newPosition.Entry, Lot);
        newPosition.OnClosed += (p) => Reporter?.Log(p);
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
