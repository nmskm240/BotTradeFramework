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
    public double Open { get; set; }
    [DecimalLength]
    public double High { get; set; }
    [DecimalLength]
    public double Low { get; set; }
    [DecimalLength]
    public double Close { get; set; }
    [DecimalLength]
    public double Volume { get; set; }
    public DateTimeOffset DecisionAt { get; set; }
    [ForeignKey(typeof(SymbolOrm))]
    public long SymbolId { get; set; }
}
