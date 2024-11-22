using ServiceStack.DataAnnotations;

namespace BotTrade.Infra.Databases.Orm;

[Alias("ohlcvs")]
[UniqueConstraint(nameof(DecisionAt), nameof(SymbolId))]
[CompositeIndex(nameof(DecisionAt), nameof(SymbolId))]
[CompositeKey(nameof(DecisionAt), nameof(SymbolId))]
internal class OhlcvOrm
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }
    [DecimalLength]
    public decimal Open { get; set; }
    [DecimalLength]
    public decimal High { get; set; }
    [DecimalLength]
    public decimal Low { get; set; }
    [DecimalLength]
    public decimal Close { get; set; }
    [DecimalLength]
    public decimal Volume { get; set; }
    public DateTimeOffset DecisionAt { get; set; }
    [ForeignKey(typeof(SymbolOrm))]
    public long SymbolId { get; set; }
}
