using BotTrade.Application.Dto;
using BotTrade.Domain;
using BotTrade.Domain.Settings;

namespace BotTrade.Application;

public record ParameterFittingResponse(
    Dictionary<Timeframe, PerforrmanceTopAndBottoms> DuringAtParameterEvaluation,
    Dictionary<Timeframe, PerforrmanceTopAndBottoms> AfterWalkForwardTest
);

public record ParameterFittingRequest(
    IEnumerable<Timeframe> Timeframes,
    IEnumerable<decimal> Parameters1,
    IEnumerable<decimal>? Parameters2 = null,
    IEnumerable<decimal>? Parameters3 = null,
    IEnumerable<decimal>? Parameters4 = null,
    int WalkForwardTestableSize = 10,
    int OptimalParameterSetSize = 3
);

public class ParameterFittingUsecase
{
    private BotSetting TemplateSetting { get; init; }
    private RunAndReportUsecase BacktestUsecase { get; init; }
    private int ProcessorsCount { get; init; }

    public ParameterFittingUsecase(IBotFactory factory, ExchangePlace place, Symbol symbol, StrategyKind strategyKind, DateTimeOffset? parameterRatingAt = null, int processorsCount = 4)
    {
        var now = DateTimeOffset.UtcNow;
        var defaultRatingAt = now.AddYears(-1);
        TemplateSetting = new BotSetting()
        {
            Lot = 1,
            Exchange = new ExchangeSetting()
            {
                Place = place,
                Symbol = symbol,
                Range = new ExchangeSetting.DateTimeRange()
                {
                    EndAt = parameterRatingAt ?? defaultRatingAt,
                }
            },
            Strategy = new StrategySetting()
            {
                Kind = strategyKind,
                Timeframe = default,
                Parameters = [],
            }
        };
        BacktestUsecase = new RunAndReportUsecase(factory);
        ProcessorsCount = processorsCount;
    }

    private BotSetting CreateSettingFromTemplate(Timeframe timeframe, params decimal[] parameters)
    {
        return TemplateSetting with
        {
            Strategy = TemplateSetting.Strategy with
            {
                Timeframe = timeframe,
                Parameters = parameters
            }
        };
    }

    private IEnumerable<BotSetting> ConvertToSettingFromRequest(ParameterFittingRequest request)
    {
        if (!request.Parameters1.Any())
            throw new InvalidOperationException();
        else if (request.Parameters2 == null || !request.Parameters2.Any())
            return request.Timeframes.Combination(request.Parameters1, (timeframe, param) => CreateSettingFromTemplate(timeframe, param));
        else if (request.Parameters3 == null || !request.Parameters3.Any())
            return request.Timeframes.Combination(request.Parameters1, request.Parameters2, (timeframe, param1, param2) => CreateSettingFromTemplate(timeframe, [param1, param2]));
        else if (request.Parameters4 == null || !request.Parameters4.Any())
            return request.Timeframes.Combination(request.Parameters1, request.Parameters2, request.Parameters3, (timeframe, param1, param2, param3) => CreateSettingFromTemplate(timeframe, [param1, param2, param3]));
        else
            return request.Timeframes.Combination(request.Parameters1, request.Parameters2, request.Parameters3, request.Parameters4, (timeframe, param1, param2, param3, param4) => CreateSettingFromTemplate(timeframe, [param1, param2, param3, param4]));
    }

    private async Task<Dictionary<Timeframe, PerforrmanceTopAndBottoms>> SortByBotPerformance(IEnumerable<BotSetting> settings, int takeTopAndBottom)
    {
        using var semaphore = new SemaphoreSlim(ProcessorsCount);
        var tasks = settings.Select(async (setting) =>
            {
                await semaphore.WaitAsync();
                try
                {
                    return await BacktestUsecase.Call(setting);
                }
                catch
                {
                    return new ReportAndSetting(setting, new StrategyReport([]));
                }
                finally
                {
                    semaphore.Release();
                }
            });
        var results = await Task.WhenAll(tasks);
        return results.GroupBy(result => result.Setting.Strategy.Timeframe)
            .Select(group =>
            {
                var sorted = group.OrderByDescending(result => result.Report.PnL)
                    .ThenBy(result => result.Report.RiskReward);
                var tops = sorted.Take(takeTopAndBottom)
                    .ToList();
                var bottoms = sorted.TakeLast(takeTopAndBottom)
                    .ToList();

                return new KeyValuePair<Timeframe, PerforrmanceTopAndBottoms>(
                    group.Key,
                    new PerforrmanceTopAndBottoms(tops, bottoms)
                );
            }).ToDictionary();
    }

    public async Task<ParameterFittingResponse> Call(ParameterFittingRequest request)
    {
        var settings = ConvertToSettingFromRequest(request);
        var duringAtParameterEvaluationReports = await SortByBotPerformance(settings, request.WalkForwardTestableSize);
        var walkForwardTestSettings = duringAtParameterEvaluationReports.SelectMany(pair =>
            pair.Value.Tops.Select(value =>
                value.Setting with
                {
                    Exchange = value.Setting.Exchange with
                    {
                        Range = value.Setting.Exchange.Range! with
                        {
                            StartAt = value.Setting.Exchange.Range?.EndAt ?? DateTimeOffset.MinValue,
                            EndAt = DateTimeOffset.MaxValue,
                        }
                    }
                }
            ));
        var afterWalkForwardTest = await SortByBotPerformance(walkForwardTestSettings, request.OptimalParameterSetSize);

        return new ParameterFittingResponse(
            duringAtParameterEvaluationReports,
            afterWalkForwardTest
        );
    }
}
