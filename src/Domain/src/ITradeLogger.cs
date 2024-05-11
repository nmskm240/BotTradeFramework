using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public record class CapitalFlow
{
    public DateTime DateTime { get; set; }
    public double Capital { get; set; }
}

public interface ITradeLogger
{
    void Log(Candle candle);
    void Log(AnalysisData analysis);
    void Log(Position position);
    void Log(CapitalFlow flow);
    void Stop();
}
