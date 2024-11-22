using BotTrade.Domain;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Ohlcvs;
using BotTrade.Infra.Exchanges;

using Microsoft.Extensions.Logging;

using Moq;

using ServiceStack.Text;

using Xunit.Abstractions;

namespace BotTrade.Test;

public class CryptoExternalExchangeTest
{
    public static IEnumerable<object[]> ExchangeOhlcvFetchTestData()
    {
        yield return new object[]
        {
            new ccxt.Bybit(),
            new Symbol("BTCUSDT", string.Empty, new()),
            new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero),
            new DateTimeOffset(2020, 5, 31, 23, 59, 59, TimeSpan.Zero),
        };
        yield return new object[]
        {
            new ccxt.Binance(),
            new Symbol("ETHUSDT", string.Empty, new()),
            new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
            new DateTimeOffset(2024, 1, 1, 23, 59, 59, TimeSpan.Zero),
        };
    }

    [Theory(DisplayName = "取引所からOhlcvデータを取得")]
    [MemberData(nameof(ExchangeOhlcvFetchTestData))]
    public async Task OhlcvStreamAsObservableTest(ccxt.Exchange client, Symbol symbol, DateTimeOffset startAt, DateTimeOffset endAt)
    {
        var logger = new Mock<ILogger<IExchange>>();
        var exchange = new CryptoExternalExchange(client, logger.Object);
        var observable = exchange.OhlcvStreamAsObservable(symbol, startAt, endAt);
        var results = new List<Ohlcv>();
        var completionSource = new TaskCompletionSource<bool>();
        var subscription = observable.Subscribe(
            results.Add,
            completionSource.SetException,
            () => completionSource.SetResult(true)
        );

        observable.Connect();

        await completionSource.Task;

        Assert.NotEmpty(results);
        Assert.Equal(results.First().Date, startAt.UtcDateTime.Truncate(TimeSpan.FromMinutes(1)));
        Assert.Equal(results.Last().Date, endAt.UtcDateTime.Truncate(TimeSpan.FromMinutes(1)));
        Assert.All(results, ohlcv => Assert.Equal(symbol, ohlcv.Symbol));
        for (int i = 1; i < results.Count; i++)
        {
            var diff = results[i].Date - results[i - 1].Date;
            Assert.Equal(TimeSpan.FromMinutes(1), diff);
        }
    }
}
