using System.Reactive.Linq;

using BotTrade.Domain;
using BotTrade.Domain.Settings;
using BotTrade.Infra.Repositories;

using Microsoft.Extensions.Logging;

namespace BotTrade.Test;

public class CnadleRepositoryTest
{
    [Theory(DisplayName = "過去データの取得")]
    [InlineData(Symbol.Spot_BTCUSDT, ExchangePlace.Bybit)]
    [InlineData(Symbol.Spot_ETHUSDT, ExchangePlace.Bybit)]
    [InlineData(Symbol.Spot_ETHBTC, ExchangePlace.Bybit)]
    public async Task FetchHistoricalData(Symbol symbol, ExchangePlace place)
    {
        using var cancellation = new CancellationTokenSource();
        var logger = new LoggerFactory().CreateLogger<PastCandleRepository>();
        var setting = new ExchangeSetting() { Place = place, Symbol = symbol };
        var repository = new PastCandleRepository(setting, logger);
        var candles = new List<Candle>();

        await foreach (var candle in repository.Pull().WithCancellation(cancellation.Token))
        {
            candles.Add(candle);
            if (candles.Count == 2)
                cancellation.Cancel();
        }

        var a = candles.First();
        var b = candles.Last();
        var span = b.Date - a.Date;
        Assert.Equal(candles.Count, 2);
        Assert.Equal(a.Symbol, b.Symbol);
        Assert.NotEqual(0, a.Date.Ticks);
        Assert.NotEqual(0, b.Date.Ticks);
        Assert.Equal((int)Timeframe.OneMinute * TimeSpan.TicksPerMinute, span.Ticks);
        // リサンプリンjグ失敗などを考慮しておく
        Assert.True(a.Open > 0);
        Assert.True(b.Open > 0);
        Assert.True(a.Close > 0);
        Assert.True(b.Close > 0);
        Assert.True(a.High > 0);
        Assert.True(b.High > 0);
        Assert.True(a.Low > 0);
        Assert.True(b.Low > 0);
        Assert.True(a.Volume >= 0);
        Assert.True(b.Volume >= 0);
    }
}
