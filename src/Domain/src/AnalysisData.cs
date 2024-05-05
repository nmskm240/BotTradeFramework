using System.Collections.Generic;

namespace BotTrade.Domain;

public record class AnalysisData
{
    public Candle Candle { get; init; }
    /// <summary>
    /// インジケーターの値
    /// </summary>
    /// <remarks>
    /// ロウソク足チャート、取引高、カスタムチャートの順番で格納する
    /// </remark>
    /// <value></value>
    public IEnumerable<Dictionary<string, AnalysisValue>> Indicators { get; init; }
    public DateTime Timestamp { get { return Candle.Date; } }

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
