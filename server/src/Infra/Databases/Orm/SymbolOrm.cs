using System.Data;

using ServiceStack.DataAnnotations;

namespace BotTrade.Infra.Databases.Orm;

[Alias("symbols")]
[UniqueConstraint(nameof(Code), nameof(PlaceId))]
internal class SymbolOrm
{
    [PrimaryKey]
    [AutoIncrement]
    public long Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; } = string.Empty;
    [ForeignKey(typeof(ExchangePlaceOrm))]
    public long PlaceId { get; set; }
}
