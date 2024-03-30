namespace BotTrade.Domain;

public interface IExchange
{
    void Buy(Symbol symbol, float quantity);
    void Sell(Symbol symbol, float quantity);
    void Cancel();
    Task<Candle> Fetch(Symbol symbol, Timeframe timeframe);
}
