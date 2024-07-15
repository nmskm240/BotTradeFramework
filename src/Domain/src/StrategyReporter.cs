using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public class StrategyReport
{
    public IEnumerable<Position> Trades { get; init; }
    public object TotalProfitChart { get; init; }
    /// <summary>
    /// 損益
    /// </summary>
    public decimal PnL { get { return Trades.Sum(trade => trade.PnL); } }

    /// <summary>
    /// 利益の平均リターン
    /// </summary>
    public decimal ProfitAverage
    {
        get
        {
            var winTrades = Trades.Where(trade => trade.IsWin);
            var total = winTrades.Sum(trade => trade.PnL);
            var count = winTrades.Count();
            return total / count;
        }
    }

    /// <summary>
    /// 損失の平均リターン
    /// </summary>
    public decimal LossAverage
    {
        get
        {
            var loseTrades = Trades.Where(trade => !trade.IsWin);
            var total = loseTrades.Sum(trade => trade.PnL);
            var count = loseTrades.Count();
            return total / count;
        }
    }

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
                if (trade.IsWin)
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
                if (!trade.IsWin)
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
            var win = (float)Trades.Count(trade => trade.IsWin);
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
                sumProfit += trade.PnL;
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
            var avgProfit = Trades.Where(trade => trade.IsWin)
                            .Average(trade => trade.PnL);
            var avgLoss = Trades.Where(trade => !trade.IsWin)
                            .Average(trade => trade.PnL);
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
