using System.Reactive.Linq;
using System.Reactive.Subjects;
using BotTrade.Domain;
using BotTrade.Domain.Strategy;

namespace BotTrade.Infra.Exchange;

/// <summary>
/// バックテスト用の取引所
/// </summary>
/// <remarks>
/// 通常の取引所と同様に扱え、注文処理は今の時間足のOClose価格で確定される
/// </remarks>
public class Backtest : Domain.Exchange
{
    private ICandleRepository Repository { get; init; }
    private Candle? _currentCandle;
    public override IConnectableObservable<Candle> OnFetchedCandle { get; init; }

    // TODO: 手数料を設定できるように
    public Backtest(StrategyParameter parameter, ICandleRepository repository) : base(parameter)
    {
        Repository = repository;
        OnFetchedCandle = Observable.Create<Candle>(async observer =>
            {
                try
                {
                    await foreach (var e in Repository.Fetch(Symbol, Timeframe))
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
            }).Publish();
    }

    public override async Task<Position> Buy(Symbol symbol, decimal quantity)
    {
        var position = new Position(symbol, PositionType.Long, quantity, _currentCandle!.Close);
        return await Task.FromResult(position);
    }

    public override async Task<decimal> ClosePosition(Position position)
    {
        position.Close(_currentCandle!.Close);
        return await Task.FromResult(position.Result());
    }


    public override async Task<Position> Sell(Symbol symbol, decimal quantity)
    {
        var position = new Position(symbol, PositionType.Short, quantity, _currentCandle!.Close);
        return await Task.FromResult(position);
    }
}
