using BotTrade.Domain;
using BotTrade.Domain.Settings;

namespace BotTrade.Application.Usecases;

public class RunAndReportUsecase
{
    private IBotFactory _factory;

    public RunAndReportUsecase(IBotFactory factory)
    {
        _factory = factory;
    }

    public async Task<StrategyReport> Call(BotSetting setting)
    {
        using var bot = _factory.Create(setting);
        await bot.Start();
        var report = await bot.Report();
        return report;
    }
}
