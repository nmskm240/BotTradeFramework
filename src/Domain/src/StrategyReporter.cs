using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public class StrategyReport
{
    public IEnumerable<Position> Trades { get; init; }
    public object TotalProfitChart { get; init; }
    /// <summary>
    /// 損益
    /// </summary>
    public decimal PnL { get { return Trades.Sum(p => p.Profit); } }
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
    /// <summary>
    /// 最大ドローダウン
    /// </summary>
    public decimal MaxDrawdown
    {
        get
        {
            var sumProfit = decimal.Zero;
            var maxProfit = decimal.Zero;
            var maxDrawdown = decimal.Zero;
            foreach (var trade in Trades)
            {
                sumProfit += trade.Profit;
                maxProfit = Math.Max(sumProfit, maxProfit);
                maxDrawdown = Math.Min(maxDrawdown, sumProfit - maxProfit);
            }
            return maxDrawdown;
        }
    }

    /// <summary>
    /// リスクリワードレシオ
    /// </summary>
    public decimal RiskReward
    {
        get
        {
            var avgProfit = Trades.Where(p => p.Profit > 0)
                            .Average(p => p.Profit);
            var avgLoss = Trades.Where(p => p.Profit <= 0)
                            .Average(p => p.Profit);
            return Math.Abs(avgProfit / avgLoss);
        }
    }

    public StrategyReport(IEnumerable<Position> trades, object capitalFlowChart)
    {
        Trades = trades;
        TotalProfitChart = capitalFlowChart;
    }
}

public interface IStrategyReporter : IDisposable
{
    void Log(Position position);
    StrategyReport? Report();
}
