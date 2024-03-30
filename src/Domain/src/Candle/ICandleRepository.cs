using System.Runtime.CompilerServices;

namespace Domain.Candle
{
    public interface ICandleRepository
    {
        IAsyncEnumerable<Candle> Fetch(Symbol symbol, CancellationToken token = default);
    }
}