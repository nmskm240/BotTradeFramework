using BotTrade.Domain;
using BotTrade.Domain.Settings;

namespace BotTrade.Application;

public class InDepthAnalysisUsecase
{
    private IBotFactory _factory;

    public InDepthAnalysisUsecase(IBotFactory factory)
    {
        _factory = factory;
    }

    public async Task Call(BotSetting setting, Action<(Position, TradePoint)> onTraded)
    {
        using var bot = _factory.Create(setting);
        using var disable = bot.OnTradedWithEvidence.Subscribe(onTraded);
        await bot.Start();
    }
}
