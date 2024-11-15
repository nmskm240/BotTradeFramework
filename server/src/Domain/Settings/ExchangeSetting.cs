namespace BotTrade.Domain.Settings;

public record ExchangeSetting
{
    public ExchangePlace Place { get; set; }
    public Symbol Symbol { get; set; }
    //バックテスト用
    public DateTimeRange? Range { get; set; }

    public record DateTimeRange
    {
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }
    }
}
