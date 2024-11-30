using System.Reactive.Linq;

using BotTrade.Domain.Ohlcvs;

using Microsoft.Extensions.Logging;

using Python.Runtime;

namespace BotTrade.Domain;

public class Bot
{
    // protected IExchange Exchange { get; init; }
    protected ILogger Logger { get; init; }
    private readonly dynamic _model;

    public Bot(IObservable<Ohlcv> stream, ILogger logger)
    {
        // Exchange = exchange;
        Logger = logger;

        using (var gil = Py.GIL())
        {
            dynamic river = Py.Import("river.time_series");
            _model = river.SNARIMAX(1, 0, 0);
        }

        stream.Select(x => x.ToDictonary())
            .Buffer(2, 1)
            .Subscribe(Think);
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
                var pred = _model.forecast(horizon: 1, xs: input);

                Logger.LogInformation($"Prediction: {pred}");
            }
        }
        catch (PythonException ex)
        {
            Logger.LogError(ex, "An error occurred while calling the Python model.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An unexpected error occurred in Think.");
        }
    }
}
