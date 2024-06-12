using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BotTrade.Domain.Strategies;

public record class AnalysisData
{
    /// <summary>
    /// インジケーターの値
    /// </summary>
    /// <remarks>
    /// ロウソク足チャート、取引高、カスタムチャートの順番で格納する
    /// </remark>
    /// <value></value>
    public IEnumerable<Dictionary<string, AnalysisValue>> Indicators { get; init; }
    public DateTime Date { get; init; }

    public Dictionary<string, AnalysisValue> ChartPlotValues
    {
        get { return Indicators.FirstOrDefault() ?? []; }
    }
    public AnalysisData(DateTime date, Dictionary<string, AnalysisValue>? candleIndicators = null, Dictionary<string, AnalysisValue>? volumeIndicators = null, IEnumerable<Dictionary<string, AnalysisValue>>? customChartIndicators = null)
    {
        Date = date;
        Indicators = [
            candleIndicators ?? new Dictionary<string, AnalysisValue>(),
            volumeIndicators ?? new Dictionary<string, AnalysisValue>(),
            .. customChartIndicators ?? [],
        ];
    }
}
