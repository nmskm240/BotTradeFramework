using System.Collections;
using System.Reactive.Linq;

using BotTrade.Domain;
using BotTrade.Domain.Strategies;

using ScottPlot;
using ScottPlot.Plottables;

namespace BotTrade.Infra;

public class TradeHistoryReporter : IChartMaker
{
    private const string CANDLE_SERIES_LABEL = "candles";
    private const string VOLUME_SERIES_LABEL = "volumes";
    private const float ARROW_SIZE = 10f;

    private decimal HighestPrice { get; set; } = decimal.MinValue;
    private decimal LowestPrice { get; set; } = decimal.MaxValue;
    private Plot OHLCChart { get; init; }
    private Plot VolumeChart { get; init; }
    private Dictionary</*描画先*/Plot, Dictionary<string, IList>> ChartAndSeries { get; init; }

    public TradeHistoryReporter()
    {
        OHLCChart = new Plot();
        var candles = new List<OHLC>();
        var ohlcSeries = new Dictionary<string, IList>()
        {
            { CANDLE_SERIES_LABEL, candles },
        };
        OHLCChart.Add.Candlestick(candles);
        OHLCChart.Axes.DateTimeTicksBottom();
        OHLCChart.Axes.Margins(bottom: 0);
        OHLCChart.Title(CANDLE_SERIES_LABEL);

        VolumeChart = new Plot();
        var volumes = new List<Bar>();
        var volumeSeries = new Dictionary<string, IList>()
        {
            { VOLUME_SERIES_LABEL, volumes },
        };
        VolumeChart.Add.Bars(volumes);
        VolumeChart.Axes.DateTimeTicksBottom();
        VolumeChart.Axes.Margins(bottom: 0);
        VolumeChart.Title(VOLUME_SERIES_LABEL);

        ChartAndSeries = new Dictionary<Plot, Dictionary<string, IList>>()
        {
            {OHLCChart, ohlcSeries},
            {VolumeChart, volumeSeries},
        };
    }

    private void PlotOHLC(Candle candle)
    {
        var item = new OHLC(
            (double)candle.Open,
            (double)candle.High,
            (double)candle.Low,
            (double)candle.Close,
            candle.Date,
            candle.Timeframe.ToTimeSpan()
        );
        ChartAndSeries[OHLCChart][CANDLE_SERIES_LABEL].Add(item);
        HighestPrice = HighestPrice < candle.High ? candle.High : HighestPrice;
        LowestPrice = LowestPrice > candle.Low ? candle.Low : LowestPrice;
    }

    private void PlotVolume(Candle candle)
    {
        var item = new Bar()
        {
            Value = (double)candle.Volume,
            Position = candle.Date.ToOADate(),
        };
        ChartAndSeries[VolumeChart][VOLUME_SERIES_LABEL].Add(item);
    }

    private void PlotIndicators(AnalysisData analysis)
    {
        var zipped = ChartAndSeries.Zip(analysis.Indicators);
        var x = analysis.Date.ToOADate();
        foreach (var (chartAndSeries, indicatorValues) in zipped)
        {
            var chart = chartAndSeries.Key;
            var itemSources = chartAndSeries.Value;
            foreach (var (label, indicatorValue) in indicatorValues)
            {
                if (!itemSources.TryGetValue(label, out var itemSource))
                {
                    switch (indicatorValue.GraphType)
                    {
                        case GraphType.Line:
                            {
                                var source = new List<Coordinates>();
                                itemSource = source;
                                chart.Add.ScatterLine(source);
                                break;
                            }
                        case GraphType.Bar:
                            {
                                var source = Enumerable
                                    .Repeat<Bar?>(null, ChartAndSeries[OHLCChart][CANDLE_SERIES_LABEL].Count)
                                    .ToList();
                                itemSource = source;
                                chart.Add.Bars(source!);
                                break;
                            }
                        default:
                            {
                                itemSource = new List<object>();
                                break;
                            }
                    }
                    ChartAndSeries[chart].Add(label, itemSource);
                }
                object? item = indicatorValue.GraphType switch
                {
                    GraphType.Line => new Coordinates(x, (double)indicatorValue.Value),
                    GraphType.Bar => new Bar() { Value = (double)indicatorValue.Value },
                    _ => null,
                };
                itemSource.Add(item);
            }
        }
    }

    private void PlotPositionInfo(Position position, bool isEntry)
    {
        var x = (isEntry ? position.EntryAt : position.ExitAt).ToOADate();
        var y = (double)(isEntry ? position.Entry : position.Exit);
        var isBuyOrder = (position.Type == PositionType.Long && isEntry) ||
                        (position.Type == PositionType.Short && !isEntry);
        var shape = isBuyOrder ? MarkerShape.TriUp : MarkerShape.TriDown;
        var color = isBuyOrder ? Colors.Green : Colors.Red;
        OHLCChart.Add.Marker(x, y, shape, ARROW_SIZE, color);
    }

    public void Plot(Candle candle)
    {
        PlotOHLC(candle);
        PlotVolume(candle);
    }

    public void Plot(AnalysisData analysis)
    {
        PlotIndicators(analysis);
    }

    public void Log(Position position)
    {
        var entry = new Coordinates(position.EntryAt.ToOADate(), (double)position.Entry);
        var exit = new Coordinates(position.ExitAt.ToOADate(), (double)position.Exit);
        var line = OHLCChart.Add.Line(entry, exit);
        line.LineColor = position.Type == PositionType.Long ? Colors.Green : Colors.Red;
        PlotPositionInfo(position, true);
        PlotPositionInfo(position, false);
    }

    public IEnumerable<object> Output()
    {
        return ChartAndSeries.Select(pair => pair.Key);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            OHLCChart.Dispose();
            VolumeChart.Dispose();
        }
    }
}
