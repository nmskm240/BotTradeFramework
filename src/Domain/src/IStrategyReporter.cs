using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public record class CapitalFlow
{
    public DateTime DateTime { get; set; }
    public double Capital { get; set; }
}

public interface IStrategyReporter
{
    void Log(CapitalFlow flow);
    void Stop();
}
