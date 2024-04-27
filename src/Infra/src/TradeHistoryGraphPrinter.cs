using System.Collections;
using System.Reactive.Linq;

using BotTrade.Domain;

using Microsoft.Extensions.Logging;

using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace BotTrade.Infra;

public class TradeHistoryGraphPrinter : ITradeLogger
{
    private const string GRAPTH_TITLE = "TradeHistory";
    private const string FILE_NAME = $"{GRAPTH_TITLE}.pdf";
    private const string CANDLE_SERIES_LABEL = "candles";
    private const string VOLUME_SERIES_LABEL = "volumes";
    private const double ARROW_SIZE = 2.5;

    private PlotModel OHLCChart { get; init; }
    private PlotModel VolumeChart { get; init; }
    private Dictionary</*描画先*/PlotModel, Dictionary<string, IList>> Charts { get; init; }
    private Axis DateTimeAxis { get; init; }

    public TradeHistoryGraphPrinter()
    {
        DateTimeAxis = new DateTimeAxis
        {
            MajorGridlineStyle = LineStyle.Solid,
            MajorGridlineColor = OxyColors.Gray,
        };

        OHLCChart = new PlotModel();
        var ohlcSeries = new Dictionary<string, IList>()
        {
            { CANDLE_SERIES_LABEL, new List<HighLowItem>() },
        };
        OHLCChart.Title = "ohlc";
        OHLCChart.Axes.Add(DateTimeAxis);
        OHLCChart.Series.Add(new CandleStickSeries() { ItemsSource = ohlcSeries[CANDLE_SERIES_LABEL] });

        VolumeChart = new PlotModel();
        var volumeSeries = new Dictionary<string, IList>()
        {
            { VOLUME_SERIES_LABEL, new List<BarItem>() },
        };
        VolumeChart.Title = "volume";
        // VolumeChart.Axes.Add(DateTimeAxis);

        Charts = new Dictionary<PlotModel, Dictionary<string, IList>>()
        {
            {OHLCChart, ohlcSeries},
            // {VolumeChart, volumeSeries},
        };
    }

    private void UpdateAxisRange(DateTime datetime)
    {
        var timestamp = OxyPlot.Axes.DateTimeAxis.ToDouble(datetime);
        DateTimeAxis.Maximum = DateTimeAxis.Maximum < timestamp ? timestamp : DateTimeAxis.Maximum;
        DateTimeAxis.Minimum = double.IsNaN(DateTimeAxis.Minimum) ? timestamp : DateTimeAxis.Minimum;
    }

    private void PlotOHLC(Candle candle)
    {
        var x = OxyPlot.Axes.DateTimeAxis.ToDouble(candle.Date);
        var item = new HighLowItem
        {
            X = x,
            Open = (double)candle.Open,
            High = (double)candle.High,
            Low = (double)candle.Low,
            Close = (double)candle.Close,
        };
        Charts[OHLCChart][CANDLE_SERIES_LABEL].Add(item);
    }

    private void PlotPositionInfo(Position position, bool isEntry)
    {
        var x = OxyPlot.Axes.DateTimeAxis.ToDouble(isEntry ? position.EntryDate : position.ExitDate);
        var y = (double)(isEntry ? position.Entry : position.Exit);
        var isBuyOrder = (position.Type == PositionType.Long && isEntry) ||
                        (position.Type == PositionType.Short && !isEntry);
        var direction = isBuyOrder ? 1 : -1;
        var annotation = new ArrowAnnotation
        {
            StartPoint = new DataPoint(x, y),
            EndPoint = new DataPoint(x, y + 1 * direction),
            Color = isBuyOrder ? OxyColors.Green : OxyColors.Red,
            HeadWidth = ARROW_SIZE,
            HeadLength = ARROW_SIZE,
        };
        OHLCChart.Annotations.Add(annotation);
    }

    public void WriteCandleAndIndicators(AnalysisData analysis)
    {
        UpdateAxisRange(analysis.Timestamp);
        PlotOHLC(analysis.Candle);
        var x = OxyPlot.Axes.DateTimeAxis.ToDouble(analysis.Timestamp);
        var zipped = Charts.Zip(analysis.Indicators);
        foreach (var (chartAndSeries, indicatorValues) in zipped)
        {
            var chart = chartAndSeries.Key;
            var itemSources = chartAndSeries.Value;
            foreach (var indicatorValue in indicatorValues)
            {
                if (!itemSources.TryGetValue(indicatorValue.Key, out var itemSource))
                {
                    switch (indicatorValue.Value.GraphType)
                    {
                        case GraphType.Line:
                            {
                                Console.WriteLine("!");
                                itemSource = new List<DataPoint>();
                                chart.Series.Add(new LineSeries() { ItemsSource = itemSource });
                                break;
                            }
                        case GraphType.Bar:
                            {
                                itemSource = new List<BarItem>();
                                chart.Series.Add(new BarSeries() { ItemsSource = itemSource });
                                break;
                            }
                        default:
                            {
                                itemSource = new List<object>();
                                break;
                            }
                    }
                    Charts[chart].Add(indicatorValue.Key, itemSource);
                }
                ICodeGenerating? item = indicatorValue.Value.GraphType switch
                {
                    GraphType.Line => new DataPoint(x, (double)indicatorValue.Value.Value),
                    GraphType.Bar => new BarItem(),
                    _ => throw new NotImplementedException(),
                };
                itemSource.Add(item);
            }
        }
    }

    public void WritePositionHistory(Position position)
    {
        var trade = new LineSeries
        {
            RenderInLegend = true,
            Color = OxyColors.Gray,
        };
        trade.Points.Add(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(position.EntryDate), (double)position.Entry));
        trade.Points.Add(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(position.ExitDate), (double)position.Exit));
        OHLCChart.Series.Add(trade);
        PlotPositionInfo(position, true);
        PlotPositionInfo(position, false);
    }

    public void Close()
    {
        foreach(var chart in Charts.Keys)
        {
            using var stream = File.Create($"{chart.Title}.pdf");
            var exporter = new PdfExporter()
            {
                // MEMO: ひとまず適当な長さに設定
                Width = 3000,
                Height = 600,
            };
            exporter.Export(chart, stream);
        }
    }
}
