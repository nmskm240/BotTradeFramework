using Skender.Stock.Indicators;

namespace BotTrade.Domain;
public class Candle : IQuote
{
    public Symbol Symbol { get; init; }
    public DateTime Date { get; init; }
    public decimal Open { get; init; }
    public decimal High { get; init; }
    public decimal Low { get; init; }
    public decimal Close { get; init; }
    public decimal Volume { get; init; }

    public Candle(Symbol symbol, DateTime date, decimal open, decimal high, decimal low, decimal close, decimal volume)
    {
        Symbol = symbol;
        Date = date;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        Volume = volume;
    }

    public static Candle Aggregate(IEnumerable<Candle> candles)
    {
        if (candles == null || candles.Any(e => e == null))
            throw new ArgumentException("引数がNullもしくは空", nameof(candles));
        else if (candles.GroupBy(e => e.Symbol).Count() != 1)
            throw new ArgumentException("別銘柄の統合はできない", nameof(candles));

        var symbol = candles.First().Symbol;
        var date = candles.Last().Date;
        var open = candles.First().Open;
        var high = candles.MaxBy(e => e.High)?.High ?? decimal.MinusOne;
        var low = candles.MinBy(e => e.Low)?.Low ?? decimal.MinusOne;
        var close = candles.Last().Close;
        var volume = candles.Sum(e => e.Volume);
        return new Candle(symbol, date, open, high, low, close, volume);
    }
}
