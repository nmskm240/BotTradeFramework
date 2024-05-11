using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public record class Setting
{
    public record class API
    {
        public ExchangePlace Place { get; set; }
        public required string Key { get; set; }
        public required string Secret { get; set; }
    }

    public record class Bot
    {
        public decimal Capital { get; set; }
        public required Exchange Exchange { get; set; }
        public required IEnumerable<Strategy> Strategies { get; set; }
    }

    public record Exchange
    {
        public ExchangePlace Place { get; set; }
        public Symbol Symbol { get; set; }
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
