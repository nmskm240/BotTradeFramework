using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

public class StrategyReport
{
    private List<Position> _trades;

    public IEnumerable<Position> Trades => _trades;
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
            return Trades.Where(trade => trade.IsWin)
                    .Average(trade => trade.PnL);
        }
    }

    /// <summary>
    /// 損失の平均リターン
    /// </summary>
    public decimal LossAverage
    {
        get
        {
            return Trades.Where(trade => !trade.IsWin)
                    .Average(trade => trade.PnL);
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
            return Math.Abs(ProfitAverage / LossAverage);
        }
    }

    public StrategyReport(IEnumerable<Position>? trades = null)
    {
        _trades = trades?.ToList() ?? [];
    }

    public void Log(Position position)
    {
        _trades.Add(position);
    }
}
