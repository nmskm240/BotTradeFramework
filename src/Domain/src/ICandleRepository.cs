namespace BotTrade.Domain;

public interface ICandleRepository
{
    Task Fetch(Symbol symbol);
    IAsyncEnumerable<Candle> Pull(Symbol symbol, Timeframe timeframe = Timeframe.OneMinute, CancellationToken token = default);
}
