using OxyPlot;
using BotTrade.Domain;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Infra;

public class TradeHistoryGraphPrinter
{
    private PlotModel Chart { get; init; }
    private DateTimeAxis DateTimeAxis { get; init; }
    private CandleStickSeries CandleStickSeries { get; init; }

    public TradeHistoryGraphPrinter(Exchange exchange)
    {
        DateTimeAxis = new DateTimeAxis();
        CandleStickSeries = new CandleStickSeries();
        Chart = new PlotModel();
        Chart.Axes.Add(DateTimeAxis);
        Chart.Series.Add(CandleStickSeries);

        exchange.OnFetchedCandle.Subscribe(
            PlotOHLCV,
            Output
        );
    }

    private void PlotOHLCV(Candle candle)
    {
        var item = new HighLowItem
        {
            X = CandleStickSeries.Items.Count,
            Open = (double)candle.Open,
            High = (double)candle.High,
            Low = (double)candle.Low,
            Close = (double)candle.Close,
        };
        CandleStickSeries.Items.Add(item);
        DateTimeAxis.DataMinimum 
    }

    private void Output()
    {
        Chart.InvalidatePlot(true);
        using var stream = File.Create("hoge.pdf");
        var exporter = new PdfExporter()
        {
            Width = 3000,
            Height = 600,
        };
        exporter.Export(Chart, stream);
    }
}
