using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Ohlcvs;

using Microsoft.Extensions.Logging;

using ServiceStack;

namespace BotTrade.Infra.Exchanges;

public class CryptoExternalExchange : IExchange
{
    private const int MAX_FETCH_SIZE = 1000;
    private const string TIMEFRAME = "1m";

    private readonly ccxt.Exchange _client;
    private readonly ILogger<IExchange> _logger;
    public ExchangePlace Place { get; init; }

    public CryptoExternalExchange(ccxt.Exchange client, ILogger<IExchange> logger)
    {
        _client = client;
        _logger = logger;
        Place = new((string)_client.name, false);
    }

    public async Task<IEnumerable<Symbol>> SupportSymbolsAsync(CancellationToken token)
    {
        var markets = await _client.LoadMarkets();
        return markets.Select(pair => new Symbol(pair.Key, string.Empty, Place));
    }

    public IConnectableObservable<Ohlcv> OhlcvStreamAsObservable(Symbol symbol, DateTimeOffset? startAt = null, DateTimeOffset? endAt = null)
    {
        var interval = endAt.HasValue
            ? TimeSpan.FromMilliseconds(_client.rateLimit)
            : TimeSpan.FromMinutes(1);
        var limit = endAt.HasValue ? MAX_FETCH_SIZE : 1;
        var since = startAt.GetValueOrDefault(DateTimeOffset.UtcNow.AddMinutes(-1));
        var until = endAt.GetValueOrDefault(DateTimeOffset.MaxValue);

        return Observable.Create<Ohlcv>(async (observer, token) =>
        {
            while (since < until)
            {
                var fetched = new List<ccxt.OHLCV>();
                var fetchedAt = since.AddMinutes(limit);
                token.ThrowIfCancellationRequested();
                try
                {
                    fetched = await _client.FetchOHLCV(symbol.Code, TIMEFRAME, since.ToUnixTimeMilliseconds(), limit);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "${message}", e.Message);
                    observer.OnError(e);
                    break;
                }

                if(fetched.IsNullOrEmpty())
                    break;

                foreach (var e in fetched)
                {
                    token.ThrowIfCancellationRequested();
                    if (e.Equals(default))
                        continue;

                    var entity = new Ohlcv(
                        e.open ?? 0,
                        e.high ?? 0,
                        e.low ?? 0,
                        e.close ?? 0,
                        e.volume ?? 0,
                        DateTimeOffset.FromUnixTimeMilliseconds(e.timestamp ?? 0).UtcDateTime,
                        symbol
                    );

                    if (until < entity.Date)
                        break;

                    observer.OnNext(entity);
                    since = new DateTimeOffset(entity.Date, TimeSpan.Zero);
                }
                since += TimeSpan.FromMinutes(1);
                await Task.Delay(interval, token);
            }
            observer.OnCompleted();
        })
        .Publish();
    }

    public Task<Trade> Trade(Order order)
    {
        throw new NotImplementedException();
    }
}
