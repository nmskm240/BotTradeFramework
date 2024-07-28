namespace BotTrade.Domain.Settings;

public record class ApiSetting
{
    public ExchangePlace Place { get; set; }
    public bool IsTestnet { get { return Enum.GetName(Place)?.Contains("Testnet") ?? true; } }
    public required string Key { get; set; }
    public required string Secret { get; set; }
}
