namespace BotTrade.Domain.Settings;

public record class BotSetting
{
    public float Lot { get; set; }
    public required ExchangeSetting Exchange { get; set; }
    public required IEnumerable<StrategySetting> Strategies { get; set; }
    public bool IsTakeableMultiPosition { get; set; }

    public string ReportDir
    {
        get
        {
            var strategy = string.Join("_", Strategies.Select(s => $"{Enum.GetName(s.Kind)}_{string.Join("_", s.Parameters)}"));
            var timeframe = Strategies.MaxBy(s => s.Timeframe)?.Timeframe ?? Timeframe.OneMinute;
            return $"{strategy}/{Enum.GetName(Exchange.Place)}_{Enum.GetName(Exchange.Symbol)}_{timeframe.GetStringValue()}";
        }
    }
}
