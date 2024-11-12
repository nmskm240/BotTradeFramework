namespace BotTrade.Domain;

public interface ITradeHistoryRepository
{
    Task<IEnumerable<Position>> GetAll();
    Task AddHistory(Position trade);
}
