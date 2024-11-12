using BotTrade.Domain;
using BotTrade.Domain.Settings;
using BotTrade.Infra.Exchanges;
using BotTrade.Infra.Repositories;

using ccxt;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BotTrade.Infra.Factories;

public class RealTradeBotFactory : IBotFactory
{
    private IDictionary<ExchangePlace, Exchange> ExchangeMap { get; init; }

    public RealTradeBotFactory(IEnumerable<ApiSetting> settings)
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
        services.AddSingleton<IExchange, RealExchange>();
        services.AddSingleton<ccxt.Exchange>(ExchangeMap[setting.Exchange.Place]);

        var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<Bot>();
    }
}
