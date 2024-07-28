using BotTrade.Domain.Settings;

namespace BotTrade.Domain;

public interface IBotFactory
{
    Bot Create(BotSetting setting);
}
