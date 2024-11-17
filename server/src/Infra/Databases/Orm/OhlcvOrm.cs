using ServiceStack.DataAnnotations;

namespace BotTrade.Infra.Databases.Orm;

[Alias("ohlcvs")]
[CompositeKey(nameof(DecisionAt), nameof(SymbolOrm))]
internal class OhlcvOrm
{
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal Volume { get; set; }
    public DateTimeOffset DecisionAt { get; set; }
    [ForeignKey(typeof(SymbolOrm))]
    public long SymbolId { get; set; }
}
