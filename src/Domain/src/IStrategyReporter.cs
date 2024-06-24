using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public class StrategyReport
{
    public IEnumerable<Position> Trades { get; init; }
    public object CapitalFlowChart { get; init; }
    /// <summary>
    /// 損益
    /// </summary>
    public decimal Profit { get { return Trades.Sum(p => p.Profit); } }
    /// <summary>
    /// 最大連勝数
    /// </summary>
    public int MaxWinStreak
    {
        get
        {
            var streak = 0;
            var max = 0;
            foreach (var trade in Trades)
            {
                if (0 < trade.Profit)
                {
                    streak++;
                }
                else
                {
                    max = Math.Max(max, streak);
                    streak = 0;
                }
            }
            return max;
        }
    }
    /// <summary>
    /// 最大連敗数
    /// </summary>
    public int MaxLossStreak
    {
        get
        {
            var streak = 0;
            var max = 0;
            foreach (var trade in Trades)
            {
                if (trade.Profit <= 0)
                {
                    streak++;
                }
                else
                {
                    max = Math.Max(max, streak);
                    streak = 0;
                }
            }
            return max;
        }
    }
    /// <summary>
    /// 勝率
    /// </summary>
    public float WinRate
    {
        get
        {
            var win = (float)Trades.Count(p => 0 < p.Profit);
            return win / Trades.Count() * 100;
        }
    }

    public StrategyReport(IEnumerable<Position> trades, object capitalFlowChart)
    {
        Trades = trades;
        CapitalFlowChart = capitalFlowChart;
    }
}

public interface IStrategyReporter : IDisposable
{
    void Log(Position position);
    StrategyReport? Report();
}
