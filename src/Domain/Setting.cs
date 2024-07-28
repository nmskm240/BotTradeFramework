using BotTrade.Domain.Settings;

namespace BotTrade.Domain;

public record class Setting
{
    public required IEnumerable<ApiSetting> Api { get; set; }
    public required IEnumerable<BotSetting> Bots { get; set; }
}
