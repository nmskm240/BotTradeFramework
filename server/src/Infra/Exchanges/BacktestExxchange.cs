using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain;
using BotTrade.Domain.Exchanges;
using BotTrade.Domain.Ohlcvs;

using Microsoft.Extensions.Logging;

namespace BotTrade.Infra.Exchanges;

/// <summary>
/// バックテスト用の取引所
/// </summary>
/// <remarks>j
/// 通常の取引所と同様に扱え、注文処理は今の時間足のOClose価格で確定される
/// </remarks>
public class BacktestExchange : IExchange
{
    public ExchangePlace Place { get; init; }
    private readonly ILogger _loggerr;
    private readonly IOhlcvRepository _ohlcvRepository;
    private IConnectableObservable<Ohlcv>? _ohlcvStream = null;

    public BacktestExchange(IOhlcvRepository ohlcvRepository, ILogger<IExchange> loggerr)
    {
        _ohlcvRepository = ohlcvRepository;
        _loggerr = loggerr;
    }

    public IConnectableObservable<Ohlcv> OhlcvStreamAsObservable(Symbol symbol, DateTimeOffset? startAt = null, DateTimeOffset? endAt = null)
    {
        _ohlcvStream ??= _ohlcvRepository.PullAsObservable(symbol, startAt, endAt).Publish();
        return _ohlcvStream;
    }

    public async Task<IEnumerable<Symbol>> SupportSymbolsAsync(CancellationToken token)
    {
        return await _ohlcvRepository.LoadableSymbolsAsync(token);
    }

    public Task<Trade> Trade(Order order)
    {
        throw new NotImplementedException();
    }
}
