using BotTrade.Domain;

using ccxt;

using Microsoft.Extensions.Configuration;

namespace BotTrade.Infra;

public class ExchangeContainer
{
    public ExchangeContainer()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var apis = config.GetSection("api")
            .Get<IEnumerable<Setting.API>>() ?? [];

        foreach (var api in apis)
        {
            ccxt.Exchange exchange;
            var isTestnet = api.Place == ExchangePlace.BybitTestnet;
            switch (api.Place)
            {
                case ExchangePlace.Bybit:
                case ExchangePlace.BybitTestnet:
                    {
                        exchange = new Bybit()
                        {
                            apiKey = api.Key,
                            secret = api.Secret
                        };
                        break;
                    }
                default:
                    {
                        throw new Exception("非対応の取引所");
                    }
            }
            exchange.setSandboxMode(isTestnet);
        }
    }
}
