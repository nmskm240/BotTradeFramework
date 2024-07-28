using BotTrade.Domain;
using BotTrade.Domain.Settings;
using BotTrade.Infra.Exchanges;
using BotTrade.Infra.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BotTrade.Infra.Factories;

public class BacktestBotFactory : IBotFactory
{
    public BacktestBotFactory()
    {

    }

    public Bot Create(BotSetting setting)
    {
        var services = new ServiceCollection();

        services.AddLogging(logger => logger.AddConsole());
        services.AddSingleton<Bot>();
        services.AddSingleton<Strategy>(provider =>
        {
            var exchange = provider.GetRequiredService<IExchange>();
            return Strategy.FromSetting(setting.Strategy, exchange.OnPulled);
        });
        services.AddSingleton<ExchangeSetting>(setting.Exchange);
        services.AddSingleton<BotSetting>(setting);
        services.AddSingleton<IExchange, Backtest>();
        services.AddSingleton<ICandleRepository, PastCandleRepository>();
        services.AddSingleton<ITradeHistoryRepository, InMemoryTrradeHistoryRrepository>();

        var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<Bot>();
    }
}
