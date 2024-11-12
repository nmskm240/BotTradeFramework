using BotTrade.Domain;

namespace BotTrade.Infra.Repositories;

public class InMemoryTrradeHistoryRrepository : ITradeHistoryRepository
{
    private List<Position> _trades;

    public InMemoryTrradeHistoryRrepository()
    {
        _trades = new();
    }

    public Task<IEnumerable<Position>> GetAll()
    {
        return Task.FromResult(_trades.AsEnumerable());
    }

    public Task AddHistory(Position trade)
    {
        return Task.Run(() => _trades.Add(trade));
    }
}
