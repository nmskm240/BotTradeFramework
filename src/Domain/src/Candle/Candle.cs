namespace Domain.Candle;
public class Candle
{
    public Candle(Symbol symbol, long timestamp, float open, float high, float low, float close, float volume)
    {
        this.Symbol = symbol;
        this.Timestamp = timestamp;
        this.Open = open;
        this.High = high;
        this.Low = low;
        this.Close = close;
        this.Volume = volume;
    }

    public Symbol Symbol { get; private set; }
    public long Timestamp { get; private set; }
    public float Open { get; private set; }
    public float High { get; private set; }
    public float Low { get; private set; }
    public float Close { get; private set; }
    public float Volume { get; private set; }
}
