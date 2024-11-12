namespace BotTrade.Domain.Settings;

public record class BotSetting
{
    public float Lot { get; set; }
    public required ExchangeSetting Exchange { get; set; }
    public required StrategySetting Strategy { get; set; }
    public bool IsTakeableMultiPosition { get; set; }

    public string ReportDir
    {
        get
        {
            var strategy = string.Join("_", $"{Enum.GetName(Strategy.Kind)}_{string.Join("_", Strategy.Parameters)}");
            return $"{strategy}/{Enum.GetName(Exchange.Place)}_{Enum.GetName(Exchange.Symbol)}_{Strategy.Timeframe.GetStringValue()}";
        }
    }
}
