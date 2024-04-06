using System.Reactive.Linq;
using BotTrade.Domain;

namespace BotTrade.Infra.Exchange;

/// <summary>
/// バックテスト用の取引所
/// </summary>
/// <remarks>
/// 通常の取引所と同様に扱え、注文処理は今の時間足のOClose価格で確定される
/// </remarks>
public class Backtest : IExchange
{
    private readonly ICandleRepository _repository;
    private Candle? _currentCandle;

    // TODO: 手数料を設定できるように
    public Backtest(ICandleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Position> Buy(Symbol symbol, decimal quantity)
    {
        var position = new Position(symbol, PositionType.Long, quantity, _currentCandle!.Close);
        return await Task.FromResult(position);
    }

    public async Task<decimal> ClosePosition(Position position)
    {
        position.Close(_currentCandle!.Close);
        return await Task.FromResult(position.Result());
    }

    public IObservable<Candle> OnFetchedCandle(Symbol symbol, Timeframe timeframe = Timeframe.OneMinute)
    {
        return Observable.Create<Candle>(async observer =>
        {
            try
            {
                await foreach (var e in _repository.Fetch(symbol, timeframe))
                {
                    _currentCandle = e;
                    observer.OnNext(e);
                }
                observer.OnCompleted();
            }
            catch (Exception e)
            {
                observer.OnError(e);
            }
        });
    }

    public async Task<Position> Sell(Symbol symbol, decimal quantity)
    {
        var position = new Position(symbol, PositionType.Short, quantity, _currentCandle!.Close);
        return await Task.FromResult(position);
    }
}
