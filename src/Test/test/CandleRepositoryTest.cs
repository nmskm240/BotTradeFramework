using Infra;
using Domain.Candle;

namespace Test;

public class CnadleRepositoryTest
{
    [Theory(DisplayName = "過去データの取得")]
    [InlineData(Symbol.BTCUSDT, Timeframe.OneMinute)]
    [InlineData(Symbol.BTCUSDT, Timeframe.FiveMinute)]
    [InlineData(Symbol.ETHUSDT, Timeframe.FifteenMinute)]
    [InlineData(Symbol.ETHUSDT, Timeframe.OneHour)]
    [InlineData(Symbol.ETHBTC, Timeframe.FourHour)]
    [InlineData(Symbol.ETHBTC, Timeframe.OneDay)]
    public async Task FetchHistoricalData(Symbol symbol, Timeframe timeframe)
    {
        var repository = new PastCandleRepository();
        var candles = new List<Candle>();
        using var cancellation = new CancellationTokenSource();

        await foreach (var candle in repository.Fetch(symbol, timeframe, token: cancellation.Token))
        {
            candles.Add(candle);

            if (candles.Count == 2)
            {
                cancellation.Cancel();
                break;
            }
        }

        var a = candles.First();
        var b = candles.Last();
        var span = b.Timestamp - a.Timestamp;

        Assert.Equal(a.Symbol, b.Symbol);
        Assert.NotEqual(a.Timestamp, 0);
        Assert.NotEqual(b.Timestamp, 0);
        Assert.Equal(span, (int)timeframe * 60 * 1000);
        // リサンプリング失敗などを考慮しておく
        Assert.True(a.Open > 0f);
        Assert.True(b.Open > 0f);
        Assert.True(a.Close > 0f);
        Assert.True(b.Close > 0f);
        Assert.True(a.High > 0f);
        Assert.True(b.High > 0f);
        Assert.True(a.Low > 0f);
        Assert.True(b.Low > 0f);
        Assert.True(a.Volume >= 0f);
        Assert.True(b.Volume >= 0f);
    }
}
