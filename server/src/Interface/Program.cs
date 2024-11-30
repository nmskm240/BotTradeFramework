using BotTrade.Application.Services;
using BotTrade.Domain;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Ohlcvs;
using BotTrade.Infra.Databases;
using BotTrade.Infra.Exchanges;

using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace BotTrade.Interface;

public class Program
{
    public static async Task Main(string[] args)
    {
        Domain.Python.Setup();

        var connectionFactory = new OrmLiteConnectionFactory("/workspaces/trade_bot/server/data/ohlcvs.sqlite3", SqliteDialect.Provider);
        await DatabaseStarter.CreateTables(connectionFactory);

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddGrpc();
        builder.Services.AddGrpcReflection();
        builder.Services.AddLogging();
        builder.Services.AddSingleton<IOhlcvRepository, OhlcvRepository>();
        builder.Services.AddSingleton<ccxt.Exchange, ccxt.Bybit>();
        builder.Services.AddSingleton<IExchange, BacktestExchange>();
        builder.Services.AddSingleton<IDbConnectionFactory>(connectionFactory);
        builder.Services.AddSingleton<IObservable<Ohlcv>>(provider =>
        {
            var symbol = new Symbol("BTCUSDT", string.Empty, new("Bybit", true));
            var exchange = provider.GetRequiredService<IExchange>();
            return exchange.OhlcvStreamAsObservable(symbol);
        });

        var app = builder.Build();
        var env = app.Environment;

        if (env.IsDevelopment())
        {
            app.MapGrpcReflectionService();
        }

        app.MapGrpcService<ExchangeService>();
        app.MapGrpcService<BotService>();
        app.Run();
    }
}
