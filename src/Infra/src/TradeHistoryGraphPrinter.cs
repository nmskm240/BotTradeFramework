using OxyPlot;
using BotTrade.Domain;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Infra;

public class TradeHistoryGraphPrinter
{
    const string GRAPTH_TITLE = "TradeHistory";
    const string FILE_NAME = $"{GRAPTH_TITLE}.pdf";

    private PlotModel? Chart { get; set; }
    private DateTimeAxis? DateTimeAxis { get; set; }
    private CandleStickSeries? CandleStickSeries { get; set; }

    public TradeHistoryGraphPrinter(Exchange exchange)
    {
        exchange.OnFetchedCandle.Subscribe(
            OnNext,
            Output
        );
    }

    private void OnNext(Candle candle)
    {
        if (Chart == null)
        {
            Console.WriteLine(candle.Date);
            CandleStickSeries = new CandleStickSeries();
            DateTimeAxis = new DateTimeAxis
            {
                Minimum = DateTimeAxis.ToDouble(candle.Date),
                Maximum = DateTimeAxis.ToDouble(DateTime.Now),
            };
            Chart = new PlotModel()
            {
                Title = GRAPTH_TITLE,
            };
            Chart.Axes.Add(DateTimeAxis);
            Chart.Series.Add(CandleStickSeries);
        }
        PlotOHLCV(candle);
    }

    private void PlotOHLCV(Candle candle)
    {
        var item = new HighLowItem
        {
            X = DateTimeAxis.ToDouble(candle.Date),
            Open = (double)candle.Open,
            High = (double)candle.High,
            Low = (double)candle.Low,
            Close = (double)candle.Close,
        };
        CandleStickSeries.Items.Add(item);
    }

    private void Output()
    {
        Chart!.InvalidatePlot(true);
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
