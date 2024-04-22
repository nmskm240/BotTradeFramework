using System.Collections.Generic;

namespace BotTrade.Domain;

public record class AnalysisData
{
    public Candle Candle { get; init;}
    public IEnumerable<Dictionary<string, AnalysisValue>> Indicators { get; init;}

    public Dictionary<string, AnalysisValue> ChartPlotValues
    {
        get { return Indicators.FirstOrDefault() ?? []; }
    }
    public AnalysisData(Candle candle, params Dictionary<string, AnalysisValue>[] values)
    {
        Candle = candle;
        Indicators = values;
    }
}
