using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

using Microsoft.Extensions.Logging;

using Python.Runtime;

namespace BotTrade.Domain;

public sealed class Bot : IDisposable
{
    // protected IExchange Exchange { get; init; }
    protected ILogger Logger { get; init; }
    private CompositeDisposable _disposables;
    private readonly dynamic _model;
    private Subject<IEnumerable<double>> _onPredicated = new();
    public IObservable<IEnumerable<double>> OnPredicatedAsObservable() => _onPredicated;

    public Bot(IObservable<Dictionary<string, double>> stream, ILogger logger)
    {
        // Exchange = exchange;
        Logger = logger;

        using (var gil = Py.GIL())
        {
            dynamic river = Py.Import("river.time_series");
            _model = river.SNARIMAX(1, 0, 0);
        }

        _disposables = new([
            _onPredicated,
            stream.Buffer(2, 1)
                .Subscribe(Think),
        ]);
    }

    private void Think(IEnumerable<IDictionary<string, double>> features)
    {
        try
        {
            var old = features.ElementAtOrDefault(0);
            var recent = features.ElementAtOrDefault(1);

            if (old == null || recent == null)
            {
                Logger.LogWarning("Insufficient data to process. At least two feature sets are required.");
                return;
            }

            if (!recent.TryGetValue("Close", out var ans))
            {
                Logger.LogWarning("The 'close' key is missing or null in the recent feature set.");
                return;
            }

            using (Py.GIL())
            {
                _model.learn_one(ans.ToPython(), x: old.ToPython());

                var input = new PyList();
                input.Append(recent.ToPython());
                var preds = new List<double>();
                foreach (double pred in _model.forecast(horizon: 1, xs: input))
                {
                    preds.Add(pred);
                }
                _onPredicated.OnNext(preds);
            }
        }
        catch (PythonException ex)
        {
            Logger.LogError(ex, "An error occurred while calling the Python model.");
            _onPredicated.OnError(ex);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An unexpected error occurred in Think.");
            _onPredicated.OnError(ex);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool dispose)
    {
        _disposables.Dispose();
        if (dispose)
        {

        }
    }
}
