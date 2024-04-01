using BotTrade.Infra;
using BotTrade.Infra.Exchange;
using BotTrade.Domain;
using System.Diagnostics;
using Microsoft.Reactive.Testing;

namespace BotTrade.Test;

public class ExchangeTest
{
    [Fact]
    public void FetchedCandle()
    {
        var repository = new PastCandleRepository();
        var ex = new Backtest(repository);
        var values = new List<Candle>();
        ex.OnFetchedCandle(Symbol.Spot_BTCUSDT, Timeframe.FourHour).Subscribe(
            values.Add,
            e => Assert.True(false, "error"),
            () =>
        {
            Assert.NotEqual(0, values.Count);
        });
    }
}
