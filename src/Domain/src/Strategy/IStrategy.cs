namespace BotTrade.Domain.Strategy;

public interface IStrategy
{
    Task Start();
    Task Stop();
}
