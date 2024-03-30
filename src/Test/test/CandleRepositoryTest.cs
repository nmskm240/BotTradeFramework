using Infra;
using Domain.Candle;

namespace Test;

public class CnadleRepositoryTest
{
    [Fact]
    public async Task AccessPastDatabase()
    {
        var repository = new PastCandleRepository();
        var cancellation = new CancellationTokenSource();
        await foreach(var candle in repository.Fetch(Symbol.BTCUSDT, token: cancellation.Token))
        {
            Assert.NotNull(candle);
            cancellation.Cancel();
        }
    }
}
