using BotTrade.Domain;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace BotTrade.Infra;

public class TradeHistoryGraphPrinter : ITradeLogger
{
    private const string GRAPTH_TITLE = "TradeHistory";
    private const string FILE_NAME = $"{GRAPTH_TITLE}.pdf";
    private const double ARROW_SIZE = 2.5;

    private PlotModel Chart { get; init; }
    private List<HighLowItem> SeriesItem { get; init; }
    private Axis Axis { get { return Chart.Axes.First(); } }

    public TradeHistoryGraphPrinter(Exchange exchange)
    {
        SeriesItem = new List<HighLowItem>();
        var series = new CandleStickSeries
        {
            ItemsSource = SeriesItem,
        };
        var axis = new DateTimeAxis
        {
            MajorGridlineStyle = LineStyle.Solid,
            MajorGridlineColor = OxyColors.Gray,
        };
        Chart = new PlotModel()
        {
            Title = GRAPTH_TITLE,
        };
        Chart.Axes.Add(axis);
        Chart.Series.Add(series);
        exchange.OnFetchedCandle.Subscribe(PlotOHLCV);
    }

    private void PlotOHLCV(Candle candle)
    {
        var x = DateTimeAxis.ToDouble(candle.Date);
        var item = new HighLowItem
        {
            X = x,
            Open = (double)candle.Open,
            High = (double)candle.High,
            Low = (double)candle.Low,
            Close = (double)candle.Close,
        };
        SeriesItem.Add(item);
        Axis.Maximum = x;
        Axis.Minimum = double.IsNaN(Axis.Minimum) ? x : Axis.Minimum;
    }

    private void PlotPositionInfo(Position position, bool isEntry)
    {
        var x = DateTimeAxis.ToDouble(isEntry ? position.EntryDate : position.ExitDate);
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
            HeadLength = ARROW_SIZE
        };
        Chart.Annotations.Add(annotation);
    }

    public void WritePositionHistory(Position position)
    {
        var trade = new LineSeries
        {
            RenderInLegend = true,
            Color = OxyColors.Gray,
        };
        trade.Points.Add(new DataPoint(DateTimeAxis.ToDouble(position.EntryDate), (double)position.Entry));
        trade.Points.Add(new DataPoint(DateTimeAxis.ToDouble(position.ExitDate), (double)position.Exit));
        Chart.Series.Add(trade);
        PlotPositionInfo(position, true);
        PlotPositionInfo(position, false);
    }

    public void Close()
    {
        Chart.InvalidatePlot(true);
        using var stream = File.Create(FILE_NAME);
        var exporter = new PdfExporter()
        {
            // MEMO: ひとまず適当な長さに設定
            Width = 3000,
            Height = 600,
        };
        exporter.Export(Chart, stream);
    }
}
