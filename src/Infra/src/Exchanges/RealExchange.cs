using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain;

using Microsoft.Extensions.Logging;

namespace BotTrade.Infra.Exchanges;

public class RealExchange : IExchange
{
    private ccxt.Exchange Exchange { get; init; }
    private ILogger<IExchange> Logger { get; init; }
    public ExchangePlace Place { get; init; }
    public List<Position> Positions { get; init; }
    public Symbol Symbol { get; init; }
    public IConnectableObservable<Candle> OnPulled { get; init; }

    public RealExchange(ccxt.Exchange exchange, Setting.Exchange setting, ILogger<IExchange> logger)
    {
        Place = setting.Place;
        Exchange = exchange;
        Logger = logger;
        Positions = new List<Position>();
        Symbol = setting.Symbol;
        Console.WriteLine(Exchange.balance.ToString());
        OnPulled = Observable.Timer(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1))
            .SelectMany(async _ =>
            {
                var datas = await Exchange.FetchOHLCV(Symbol.GetStringValue());
                var data = datas.FirstOrDefault();
                var timestamp = DateTimeOffset.FromUnixTimeMilliseconds(data.timestamp ?? 0);
                Logger.LogInformation($"{timestamp}: {data.open}");
                return new Candle(Symbol, timestamp.UtcDateTime, (decimal)data.open, (decimal)data.high, (decimal)data.low, (decimal)data.close, (decimal)data.volume);
            }).Publish();
    }

    public async Task<Position> Buy(float quantity)
    {
        var order = await Exchange.CreateMarketBuyOrder(Symbol.GetStringValue(), (double)quantity);
        DateTime.TryParse(order.lastTradeTimestamp, out var time);
        var position = new Position(Symbol, PositionType.Long, quantity, (decimal)order.price, time, order.id);
        Positions.Add(position);
        return position;
    }

    public async Task<Position> Sell(float quantity)
    {
        var order = await Exchange.CreateMarketSellOrder(Symbol.GetStringValue(), (double)quantity);
        DateTime.TryParse(order.lastTradeTimestamp, out var time);
        var position = new Position(Symbol, PositionType.Short, quantity, (decimal)order.price, time, order.id);
        Positions.Add(position);
        return position;
    }

    public async Task<decimal> ClosePosition(Position position)
    {
        var prev = await Exchange.FetchBalance();
        await Exchange.closePosition(position.Symbol.GetStringValue());
        var current = await Exchange.FetchBalance();
        return (decimal)(current.total["usdt"] - prev.total["usdt"]);
    }

    public async Task<decimal> ClosePositionAll()
    {
        decimal profit = 0;
        foreach (var position in Positions)
        {
            profit += await ClosePosition(position);
        }
        return profit;
    }
}
