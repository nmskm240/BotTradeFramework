using BotTrade.Domain;
using BotTrade.Domain.Settings;

namespace BotTrade.Application.Dto;

public record ReportAndSetting(
    BotSetting Setting,
    StrategyReport Report
);
