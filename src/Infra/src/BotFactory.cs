using BotTrade.Domain;
using BotTrade.Domain.Strategies;
using BotTrade.Infra.Exchanges;

using ccxt;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BotTrade.Infra;

public class BotFactory
{
    /// <summary>
    /// バックテスト用取引所以外のインスタンス郡
    /// </summary>
    /// <datails>
    /// 取引所ごとの呼び出し上限などをプログラム全体で管理するため<c>RealExchange</c>でラップする前のccxtのインスタンスを確保しておく
    /// </details>
    /// <value></value>
    private IDictionary<ExchangePlace, ccxt.Exchange> ExchangeMap { get; init; }
    public bool IsBacktest { get; private set; } = false;

    /// <summary>
    /// リアルトレードやフォワードテスト用
    /// </summary>
    /// <param name="settings"></param>
    public BotFactory(IEnumerable<Setting.API> settings)
    {
        ExchangeMap = new Dictionary<ExchangePlace, Exchange>();
        foreach (var api in settings)
        {
            var exchange = api.Place.Reflection<Exchange>([null]);
            if (exchange == null)
                continue;
            ExchangeMap.Add(api.Place, exchange);
        }
    }

    /// <summary>
    /// バックテスト用
    /// </summary>
    public BotFactory()
    {
        ExchangeMap = new Dictionary<ExchangePlace, ccxt.Exchange>();
        IsBacktest = true;
    }

    public Bot Create(Setting.Bot setting)
    {
        var services = new ServiceCollection();
        // StrategyのOnAnalysisを購読するため、ここでListインスタンに確定させる
        var strategies = setting.Strategies
            .Select(Strategy.FromSetting)
            .ToList();

        if (strategies.Count == 0)
        {
            throw new Exception("有効な戦略が存在しない");
        }

        services.AddLogging(logger => logger.AddConsole());
        services.AddSingleton<Bot>();
        services.AddSingleton<IEnumerable<Strategy>>(strategies);
        services.AddSingleton<Setting.Exchange>(setting.Exchange);
        services.AddSingleton<Setting.Bot>(setting);
        if (IsBacktest)
        {
            services.AddSingleton<IStrategyReporter, StrategyReporter>();
            services.AddSingleton<IChartMaker, TradeHistoryReporter>();
            services.AddSingleton<IExchange, Backtest>();
            services.AddSingleton<ICandleRepository, PastCandleRepository>();
        }
        else
        {
            services.AddSingleton<IExchange, RealExchange>();
            services.AddSingleton<ccxt.Exchange>(ExchangeMap[setting.Exchange.Place]);
        }

        var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<Bot>();
    }
}

