using System.Reactive.Linq;
using System.Reactive.Subjects;

using BotTrade.Domain;

namespace BotTrade.Infra.Exchanges;

/// <summary>
/// バックテスト用の取引所
/// </summary>
/// <remarks>j
/// 通常の取引所と同様に扱え、注文処理は今の時間足のOClose価格で確定される
/// </remarks>
public class Backtest : IExchange
{
    private Candle? _currentCandle;
    public List<Position> Positions { get; init; }
    public IConnectableObservable<Candle> OnPulled { get; init; }
    private ICandleRepository Repository { get; init; }

    // TODO: 手数料を設定できるように
    public Backtest(ICandleRepository repository)
    {
        Repository = repository;
        Positions = new List<Position>();
        OnPulled = Observable.Create<Candle>(async observer =>
        {
            try
            {
                await foreach (var candle in Repository.Pull())
                {
                    _currentCandle = candle;
                    observer.OnNext(candle);
                }
                observer.OnCompleted();
            }
            catch (Exception e)
            {
                observer.OnError(e);
            }
        }).Publish();
    }

    public async Task<Position> Buy(Symbol symbol, decimal quantity)
    {
        var position = new Position(symbol, PositionType.Long, quantity, _currentCandle!.Close, _currentCandle!.Date);
        return await Task.FromResult(position);
    }

    public async Task<decimal> ClosePosition(Position position)
    {
        if (position?.Status == PositionStatus.Open)
        {
            position.Close(_currentCandle!.Close, _currentCandle!.Date);
            Positions.Remove(position);
            return await Task.FromResult(position.Profit);
        }
        return await Task.FromResult(0);
    }


    public async Task<Position> Sell(Symbol symbol, decimal quantity)
    {
        var position = new Position(symbol, PositionType.Short, quantity, _currentCandle!.Close, _currentCandle!.Date);
        return await Task.FromResult(position);
    }
}
