namespace BotTrade.Domain;

public interface ITradeLogger
{
    void Log(Candle candle);
    void Log(AnalysisData analysis);
    void Log(Position position);
    void Stop();
}
