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
        var piplineOrders = new List<FeaturePipelineOrder>{
            new() {
                ProcessKind = typeof(Remove),
                Parameters = [
                    new FeaturePipelineParameterOrder () {
                        Name = "targets",
                        Value = "",
                    },
                ]
            },
        };
        var pipline = ohlcvStream.BuildPipline(piplineOrders);
        var completion = new TaskCompletionSource();
        var results = new List<Dictionary<string, double>>();
        using var subscription = pipline
            .Subscribe(
                results.Add,
                completion.SetException,
                completion.SetResult
            );

        await completion.Task;

        Assert.Equal(ohlcvs.Count, results.Count);
        Assert.False(results.First().TryGetValue("Symbol", out var _));
    }
}
