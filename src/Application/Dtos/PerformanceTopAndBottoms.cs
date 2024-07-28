using BotTrade.Domain;
using BotTrade.Domain.Settings;

namespace BotTrade.Application.Dto;

public record PerforrmanceTopAndBottoms(
    IEnumerable<ReportAndSetting> Tops,
    IEnumerable<ReportAndSetting> Bottoms
);
