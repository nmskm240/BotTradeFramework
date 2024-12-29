using System.Reactive.Disposables;
using System.Reactive.Linq;

using BotTrade.Domain;
using BotTrade.Domain.Ohlcvs;
using BotTrade.Infra.Databases.Mapper;
using BotTrade.Infra.Databases.Orm;

using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace BotTrade.Infra.Databases;

public class OhlcvRepository(IDbConnectionFactory connectionFactory) : IOhlcvRepository
{
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

    public async Task PushAsync(IEnumerable<Ohlcv> ohlcvs, CancellationToken token)
    {
        using var connection = await _connectionFactory.OpenAsync(token);
        var orms = ohlcvs.Select(e => OhlcvMapper.ToOrm(e, connection));
        connection.BulkInsert(orms, new BulkInsertConfig { Mode = BulkInsertMode.Sql });
    }

    public IObservable<Ohlcv> PullAsObservable(Symbol symbol, DateTimeOffset? startAt = null, DateTimeOffset? endAt = null)
    {
        startAt = startAt.GetValueOrDefault(DateTimeOffset.MinValue).UtcDateTime;
        endAt = endAt.GetValueOrDefault(DateTimeOffset.MinValue).UtcDateTime;
        return Observable.Create<Ohlcv>(async (observer, token) =>
        {
            var disposables = new CompositeDisposable();
            try
            {
                var connection = await _connectionFactory.OpenAsync(token);
                var symbolOrm = SymbolMapper.ToOrm(symbol, connection);
                disposables.Add(connection);
                var query = connection.From<OhlcvOrm>()
                    .Where(x =>
                        x.SymbolId == symbolOrm.Id &&
                        (x.DecisionAt >= startAt) &&
                        (x.DecisionAt <= endAt)
                    );
                var orms = connection.SelectLazy(query);

                foreach (var orm in orms)
                {
                    token.ThrowIfCancellationRequested();
                    observer.OnNext(OhlcvMapper.ToEntity(orm, connection));
                }
                observer.OnCompleted();
                disposables.Dispose();
            }
            catch (Exception e)
            {
                observer.OnError(e);
                disposables.Dispose();
            }

            return disposables;
        });
    }

    public async Task<IEnumerable<Symbol>> LoadableSymbolsAsync(CancellationToken token)
    {
        using var connection = await _connectionFactory.OpenAsync(token);
        return connection.SelectLazy<SymbolOrm>()
            .Select(e => SymbolMapper.ToEntity(e, connection));
    }

    public async Task<DateTimeOffset> LastUpdatedAtAsync(Symbol symbol, CancellationToken token)
    {
        using var connection = await _connectionFactory.OpenAsync(token);
        var symbolOrm = SymbolMapper.ToOrm(symbol, connection);
        var query = connection.From<OhlcvOrm>()
            .Where(x => x.SymbolId == symbolOrm.Id)
            .OrderByDescending(x => x.DecisionAt)
            .Limit(1);
        var ohlcvOrm = await connection.SingleAsync(query, token);
        return ohlcvOrm?.DecisionAt ?? new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);
    }
}
