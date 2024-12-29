using System;

using BotTrade.Domain;

namespace BotTrade.Infra.Exchanges;

public static class CryptoExchangeClientSelector
{
    private static Dictionary<ExchangePlace, ccxt.Exchange> _exchanges = new();

    public static ccxt.Exchange GetOrCreateClient(ExchangePlace place)
    {
        if (_exchanges.TryGetValue(place, out var client))
        {
            return client;
        }

        client = place.Name switch
        {
            "Bybit" => new ccxt.Bybit(),
            _ => throw new NotImplementedException(),
        };

        _exchanges.TryAdd(place, client);
        return client;
    }
}
