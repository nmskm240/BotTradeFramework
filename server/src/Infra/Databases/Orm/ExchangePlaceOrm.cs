using ServiceStack.DataAnnotations;

namespace BotTrade.Infra.Databases.Orm;

[Alias("exchange_places")]
internal class ExchangePlaceOrm
{
    [PrimaryKey]
    [AutoIncrement]
    public long Id { get; set; }
    [Unique]
    [Required]
    public required string Name { get; set; } = string.Empty;
}
