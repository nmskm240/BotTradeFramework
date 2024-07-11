using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public record class Setting
{
    public record class API
    {
        public ExchangePlace Place { get; set; }
        public bool IsTestnet { get { return Enum.GetName(Place)?.Contains("Testnet") ?? true; } }
        public required string Key { get; set; }
        public required string Secret { get; set; }
    }

    public record class Bot
    {
        public float Lot { get; set; }
        public required Exchange Exchange { get; set; }
        public required IEnumerable<Strategy> Strategies { get; set; }
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

    public record Exchange
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

    public record class Strategy
    {
        public StrategyKind Kind { get; set; }
        public Timeframe Timeframe { get; set; }
        public required IEnumerable<int> Parameters { get; set; }
    }

    public required IEnumerable<API> Api { get; set; }
    public required IEnumerable<Bot> Bots { get; set; }
}
