using BotTrade.Domain;
using BotTrade.Domain.Strategy;
using BotTrade.Infra.Exchange;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BotTrade.Infra;

public class BacktestContainer<S, P> where S : Strategy<P> where P : StrategyParameter
{
    private ServiceProvider Provider{ get; init; }

    public BacktestContainer(P parameter)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IExchange, Backtest>();
        services.AddSingleton<ICandleRepository, PastCandleRepository>();
        services.AddSingleton<P>(parameter);
        services.AddSingleton<S>();
        services.AddLogging(logger => logger.AddConsole());

        Provider = services.BuildServiceProvider();
    }

    public S Resolve()
    {
        return Provider.GetRequiredService<S>();
    }
}
