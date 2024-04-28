namespace BotTrade.Domain;

public interface ITradeLogger
{
    void WriteCandleAndIndicators(AnalysisData analysis);
    void WritePositionHistory(Position position);
    void Close();
}
