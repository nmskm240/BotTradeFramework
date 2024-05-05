using System.Reactive.Linq;

using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public class Bot : IDisposable
{
    public decimal Capital { get; private set; }
    public IExchange Exchange { get; init; }
    //MEMO: 複数戦略でAND/OR判定できるように多次元構造にしたい
    public IEnumerable<Strategy> Strategies { get; init; }
    public bool IsStarted { get; private set; } = false;

    private IList<IDisposable> Subscriptions { get; init; }

    public Bot(IExchange exchange, IEnumerable<Strategy> strategies)
    {
        Exchange = exchange;
        Strategies = strategies;
        Subscriptions = [
            Exchange.OnPulled
                .Subscribe(
                    (_) => {},
                    async () => await Stop()
                ),
        ];
    }

    public async Task Start()
    {
        if (IsStarted) return;
        IsStarted = true;
        await Exchange.Pull();
    }

    public async Task Stop()
    {
        IsStarted = false;
    }

    public void Dispose()
    {
        if (IsStarted) UnSubscribe();
        GC.SuppressFinalize(this);
    }

    private async Task Trade(AnalysisData analysis)
    {
        await Task.Delay(1);
    }

    private void UnSubscribe()
    {
        foreach (var subscription in Subscriptions)
        {
            subscription.Dispose();
        }
        Subscriptions.Clear();
    }
}
