using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BotTrade.Domain.Strategies;

public record class AnalysisData
{
    public Dictionary<string, decimal> Values { get; init; }
    public DateTime Date { get; init; }

    public AnalysisData(DateTime date, Dictionary<string, decimal> values)
    {
        Date = date;
        Values = values;
    }
}
