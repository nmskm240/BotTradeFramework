namespace BotTrade.Domain;

public interface ICandleRepository
{
    IAsyncEnumerable<Candle> Fetch(Symbol symbol, Timeframe timeframe = Timeframe.OneMinute, CancellationToken token = default);
}
