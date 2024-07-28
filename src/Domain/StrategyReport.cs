using ScottPlot;

namespace BotTrade.Domain;

public record StrategyReport
{
    public IEnumerable<Position> Trades { get; init; }

    /// <summary>
    /// 損益図
    /// </summary>
    /// <value></value>
    public Plot PnLChart
    {
        get
        {
            var chart = new Plot();
            var xAxis = new List<DateTime>();
            var yAxis = new List<decimal>();
            var capital = decimal.Zero;
            foreach (var trade in Trades)
            {
                xAxis.Add(trade.EntryAt);
                yAxis.Add(capital);
                xAxis.Add(trade.ExitAt);
                yAxis.Add(capital += trade.PnL);
            }
            var scatter = chart.Add.Scatter(xAxis, yAxis);
            chart.Axes.DateTimeTicksBottom();
            scatter.FillY = true;
            scatter.FillYValue = 0;
            scatter.FillYAboveColor = Colors.Green.WithAlpha(0.2f);
            scatter.FillYBelowColor = Colors.Red.WithAlpha(0.2f);
            return chart;
        }
    }

    /// <summary>
    /// 損益散布図
    /// </summary>
    /// <value></value>
    public Plot PnLValueChart
    {
        get
        {
            var chart = new Plot();
            var xAxis = new List<DateTime>();
            var yAxis = new List<decimal>();
            foreach (var trade in Trades)
            {
                xAxis.Add(trade.ExitAt);
                yAxis.Add(trade.PnL);
            }
            chart.Add.ScatterPoints(xAxis, yAxis);
            chart.Axes.DateTimeTicksBottom();
            return chart;
        }
    }

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
                    .DefaultIfEmpty(new Position(default, default, default, default, default))
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
                    .DefaultIfEmpty(new Position(default, default, default, default, default))
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
            if (LossAverage == decimal.Zero)
                return decimal.Zero;
            return Math.Abs(ProfitAverage / LossAverage);
        }
    }

    public StrategyReport(IEnumerable<Position> trades)
    {
        Trades = trades.ToList();
    }
}
