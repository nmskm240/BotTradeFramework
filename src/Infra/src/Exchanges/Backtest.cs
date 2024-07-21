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
    private ICandleRepository Repository { get; init; }
    public List<Position> Positions { get; init; }
    public ExchangePlace Place { get; init; }
    public IConnectableObservable<Candle> OnPulled { get; init; }
    public Symbol Symbol { get; init; }

    // TODO: 手数料を設定できるように
    public Backtest(Setting.Exchange setting, ICandleRepository repository)
    {
        Place = setting.Place;
        Symbol = setting.Symbol;
        Repository = repository;
        Positions = new List<Position>();
        OnPulled = Observable.Create<Candle>(async observer =>
        {
            using var cancellation = new CancellationTokenSource();
            try
            {
                await foreach (var candle in Repository.Pull(setting.Range?.StartAt, setting.Range?.EndAt).WithCancellation(cancellation.Token))
                {
                    _currentCandle = candle;
                    observer.OnNext(candle);
                }
                observer.OnCompleted();
            }
            catch (Exception e)
            {
                cancellation.Cancel();
                observer.OnError(e);
            }
        }).Publish();
    }

    public Task<Position> Buy(float quantity)
    {
        var position = new Position(Symbol, PositionType.Long, quantity, _currentCandle!.Close, _currentCandle!.Date);
        Positions.Add(position);
        return Task.FromResult(position);
    }

    public Task<decimal> ClosePosition(Position position)
    {
        if (position?.Status == PositionStatus.Open)
        {
            position.Close(_currentCandle!.Close, _currentCandle!.Date);
            Positions.Remove(position);
            return Task.FromResult(position.PnL);
        }
        return Task.FromResult(decimal.Zero);
    }

    public Task<decimal> ClosePositionAll()
    {
        decimal profit = 0;
        foreach (var position in Positions.ToList())
        {
            profit += ClosePosition(position).Result;
        }
        return Task.FromResult(profit);
    }


    public Task<Position> Sell(float quantity)
    {
        var position = new Position(Symbol, PositionType.Short, quantity, _currentCandle!.Close, _currentCandle!.Date);
        Positions.Add(position);
        return Task.FromResult(position);
    }
}
