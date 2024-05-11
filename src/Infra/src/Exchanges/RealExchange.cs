using System.Reactive.Subjects;

using BotTrade.Domain;

namespace BotTrade.Infra.Exchanges;

public class RealExchange : IExchange
{
    private ccxt.Exchange Exchange { get; init; }
    public List<Position> Positions { get; init; }
    public Symbol Symbol { get; init; }

    public IConnectableObservable<Candle> OnPulled { get; init; }

    public RealExchange(ccxt.Exchange exchange, Setting.Exchange setting)
    {
        Exchange = exchange;
        Positions = new List<Position>();
        Symbol = setting.Symbol;
    }

    public Task<Position> Buy(decimal quantity)
    {
        throw new NotImplementedException();
    }

    public Task<Position> Sell(decimal quantity)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ClosePosition(Position position)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ClosePositionAll()
    {
        throw new NotImplementedException();
    }
}
