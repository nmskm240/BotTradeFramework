using BotTrade.Application.Dto;
using BotTrade.Domain;
using BotTrade.Domain.Settings;

namespace BotTrade.Application;

public class RunAndReportUsecase
{
    private IBotFactory _factory;

    public RunAndReportUsecase(IBotFactory factory)
    {
        _factory = factory;
    }

    public async Task<ReportAndSetting> Call(BotSetting setting)
    {
        using var bot = _factory.Create(setting);
        await bot.Start();
        var report = await bot.Report();
        return new ReportAndSetting(setting, report);
    }
}
