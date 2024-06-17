using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public interface IChartMaker
{
    void Plot(Candle candle);
    void Plot(AnalysisData analysis);
    IEnumerable<object> Output();
}
