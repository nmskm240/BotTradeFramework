using System;
using System.Reactive.Linq;

using BotTrade.Domain;
using BotTrade.Domain.Features;
using BotTrade.Domain.Features.Process;
using BotTrade.Domain.Ohlcvs;

namespace BotTrade.Test;

public class FeaturePiplineBuilderTest
{
    [Fact]
    public async Task CreateTest()
    {
        var now = DateTimeOffset.UtcNow;
        var symbol = new Symbol
        {
            Name = string.Empty,
            Code = "BTCUSDT",
            Place = new ExchangePlace
            {
                IsBacktest = true,
                Name = "Test"
            }
        };
        var ohlcvs = new List<Ohlcv>
        {
            new (100d, 100d, 100d, 100d, 100d, now.DateTime, symbol)
        };
        var ohlcvStream = ohlcvs.ToObservable();
        var builder = new FeaturePiplineBuilder(ohlcvStream);
        var piplineOrders = new List<FeaturePiplineOrder> {
            new (typeof(Remove), 0, new Dictionary<string, object> { { "Symbol", null } }),
        };
        var completion = new TaskCompletionSource();
        var results = new List<Dictionary<string, object>>();
        var subscription = builder.Create(piplineOrders)
            .Subscribe(
                results.Add,
                completion.SetException,
                completion.SetResult
            );

        await completion.Task;
        subscription.Dispose();

        Assert.Equal(ohlcvs.Count, results.Count);
        Assert.False(results.First().TryGetValue("Symbol", out var _));
    }
}
