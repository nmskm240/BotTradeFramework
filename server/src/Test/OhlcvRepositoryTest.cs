using System.Reactive.Linq;

using BotTrade.Domain;
using BotTrade.Domain.Ohlcvs;
using BotTrade.Infra.Databases;
using BotTrade.Infra.Databases.Orm;

using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace BotTrade.Test;

public class OhlcvRepositoryTest
{
    private async Task<IDbConnectionFactory> CreateInMemoryDbConnectionFactoryAsync()
    {
        var dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
        await DatabaseStarter.CreateTables(dbFactory);
        return dbFactory;
    }

    [Fact]
    public async Task PushAsync_InsertsOhlcvData()
    {
        // Arrange
        var dbFactory = await CreateInMemoryDbConnectionFactoryAsync();
        var repository = new OhlcvRepository(dbFactory);

        var ohlcvs = new List<Ohlcv>
        {
            new(
                100d,
                110d,
                90d,
                105d,
                1000d,
                DateTime.UtcNow,
                new (
                    "BTC/USD",
                    "Bitcoin to USD",
                    new("Bybit", true)
                )
            )
        };

        // Act
        await repository.PushAsync(ohlcvs, CancellationToken.None);

        // Assert
        using var db = await dbFactory.OpenAsync();
        var result = db.Select<OhlcvOrm>();
        Assert.Single(result);
        Assert.Equal(100d, result.First().Open);
    }

    [Fact]
    public async Task PullAsObservable_ReturnsFilteredData()
    {
        // Arrange
        var dbFactory = await CreateInMemoryDbConnectionFactoryAsync();
        var repository = new OhlcvRepository(dbFactory);

        var symbol = new Symbol(
            "BTC/USD",
            "Bitcoin to USD",
            new("Bybit", true)
        );
        var now = DateTime.UtcNow;

        var ohlcvs = new List<Ohlcv>
        {
            new(100d, 110d, 90d, 105d, 1000d, now.AddMinutes(-10), symbol),
            new(105d, 115d, 95d, 110d, 2000d, now.AddMinutes(-5), symbol)
        };

        await repository.PushAsync(ohlcvs, CancellationToken.None);

        // Act
        var observable = repository.PullAsObservable(symbol, startAt: now.AddMinutes(-6), endAt: now);
        var result = await observable.ToList(); // Observable をリストに変換

        // Assert
        Assert.Single(result);
        Assert.Equal(105d, result.First().Open);
        Assert.Equal(110d, result.First().Close);
    }

    [Fact]
    public async Task LastUpdatedAtAsyncTest()
    {
        var factory = await CreateInMemoryDbConnectionFactoryAsync();
        var repository = new OhlcvRepository(factory);
        var symbol = new Symbol(
            "BTC/USD",
            "Bitcoin to USD",
            new("Bybit", true)
        );
        var now = DateTime.UtcNow;
        var ohlcvs = new List<Ohlcv>
        {
            new(100d, 110d, 90d, 105d, 1000d, now.AddMinutes(-10), symbol),
            new(105d, 115d, 95d, 110d, 2000d, now.AddMinutes(-5), symbol),
            new(105d, 115d, 95d, 110d, 2000d, now, symbol),
        };

        await repository.PushAsync(ohlcvs, CancellationToken.None);

        var result = await repository.LastUpdatedAtAsync(symbol, CancellationToken.None);

        Assert.Equal(result, now);
    }
}
