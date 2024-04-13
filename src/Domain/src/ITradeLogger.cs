namespace BotTrade.Domain;

public interface ITradeLogger
{
    void WritePositionHistory(Position position);
    void Close();
}
