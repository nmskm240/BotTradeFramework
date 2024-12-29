using System;

using BotTrade.Domain;
using BotTrade.Infra.Exchanges;

namespace BotTrade.Test;

public class CryptoExchangeClientSelectorTest
{
    [Fact]
    public void CreateClient()
    {
        var place = new ExchangePlace
        {
            Name = "Bybit",
            IsBacktest = false,
        };
        var client = CryptoExchangeClientSelector.GetOrCreateClient(place);

        Assert.NotNull(client);
        Assert.IsType(typeof(ccxt.Bybit), client);
    }
}
