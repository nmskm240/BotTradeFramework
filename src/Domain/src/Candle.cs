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
    public Timeframe Timeframe { get; init; }

    public Candle(Symbol symbol, DateTime date, decimal open, decimal high, decimal low, decimal close, decimal volume, Timeframe timeframe = Timeframe.OneMinute)
    {
        Symbol = symbol;
        Date = date;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        Volume = volume;
        Timeframe = timeframe;
    }

    /// <summary>
    /// １分足を指定足データに変換する
    /// </summary>
    /// <remarks>
    /// <c>candles</c>の要素数が時間足変換に必要な個数に達していなくても変換する<br/>
    /// <c>candles</c>の要素数が時間足変換に必要な個数以上ある場合は先頭から必要な個数抽出して変換する
    /// </remarks>
    /// <param name="candles">1分足の列挙型</param>
    /// <param name="timeframe"></param>
    /// <returns><c>timeframe</c>で指定した時間足に変換された<c>Candle</c></returns>
    public static Candle Aggregate(IEnumerable<Candle> candles, Timeframe timeframe)
    {
        if (candles.GroupBy(candle => candle.Timeframe).Any(group => group.Key != Timeframe.OneMinute))
            throw new ArgumentException($"{nameof(candles)}はすべて１分足でなければならない", nameof(candles));
        if (candles.GroupBy(candle => candle.Symbol).Count() > 1)
            throw new ArgumentException($"{nameof(candles)}はすべて同じ{nameof(Symbol)}でなければならない", nameof(candles));

        candles = candles.Take((int)timeframe);

        var symbol = candles.First().Symbol;
        var date = candles.Last().Date;
        var open = candles.First().Open;
        var high = candles.MaxBy(e => e.High)?.High ?? decimal.MinusOne;
        var low = candles.MinBy(e => e.Low)?.Low ?? decimal.MinusOne;
        var close = candles.Last().Close;
        var volume = candles.Sum(e => e.Volume);

        return new Candle(symbol, date, open, high, low, close, volume, timeframe);
    }
}
