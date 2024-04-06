using System.Diagnostics;
using System.Reactive.Linq;

namespace BotTrade.Domain.Strategy;

public abstract class Strategy<T> : IDisposable where T : StrategyParameter
{
    private IDisposable? _disposable;
    protected IExchange Exchange { get; init; }
    protected T Parameter { get; init; }
    public bool IsStarted { get; private set; } = false;

    protected Strategy(IExchange exchange, T parameter)
    {
        Debug.Assert(exchange != null);
        Debug.Assert(parameter != null);

        Exchange = exchange;
        Parameter = parameter;
    }

    public void MightStart()
    {
        if (IsStarted) return;
        
        OnPreStart();
        _disposable = Exchange.OnFetchedCandle(Parameter.Symbol, Parameter.Timeframe)
        .Subscribe(MightTrade);
        IsStarted = true;
        OnPostStart();
    }

    public void Stop()
    {
        OnPreStop();
        _disposable?.Dispose();
        _disposable = null;
        IsStarted = false;
        OnPostStop();
    }

    public void Dispose()
    {
        if (IsStarted) Stop();
        GC.SuppressFinalize(this);
    }

    protected virtual void OnPreStart() { }
    protected virtual void OnPostStart() { }
    protected virtual void OnPreStop() { }
    protected virtual void OnPostStop() { }
    protected abstract void MightTrade(Candle candle);
}
