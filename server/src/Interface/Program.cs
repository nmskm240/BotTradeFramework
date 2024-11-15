using BotTrade.Application.Services;

namespace BotTrade.Interface;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddGrpc();

        var app = builder.Build();
        app.MapGrpcService<ExchangeService>();
        app.Run();
    }
}
