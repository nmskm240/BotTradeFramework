using System.Reactive.Subjects;

using BotTrade.Domain;

namespace BotTrade.Infra.Exchanges;

public class RealExchange : IExchange
{
    private ccxt.Exchange Exchange { get; init; }
    public List<Position> Positions { get; init; }

    public IConnectableObservable<Candle> OnPulled { get; init; }

    public RealExchange(ccxt.Exchange exchange, Setting.Exchange setting)
    {
        Exchange = exchange;
        Positions = new List<Position>();

    }

    public Task<Position> Buy(Symbol symbol, decimal quantity)
    {
        throw new NotImplementedException();
    }

    public Task<Position> Sell(Symbol symbol, decimal quantity)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ClosePosition(Position position)
    {
        throw new NotImplementedException();
    }
}
