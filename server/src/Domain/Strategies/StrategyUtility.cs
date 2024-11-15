using Skender.Stock.Indicators;

namespace BotTrade.Domain.Strategies;

internal static class StrategyUtilty
{
    /// <summary>
    /// ゴールデンクロスしているかを確認する
    /// </summary>
    /// <remarks>
    /// 引数に要素数2以上の <c>IReusableResult</c> を渡しても実際に使用するのは最後の2要素のみ
    /// </remarks>
    /// <param name="shorts">短期</param>
    /// <param name="longs">長期</param>
    /// <returns>
    /// 要素数2以下の列挙型を引数に渡した場合は<c>false</c><br/>
    /// それ以外はゴールデンクロスの結果による
    /// </returns>
    public static bool IsGoldenCross(IEnumerable<decimal> shorts, IEnumerable<decimal> longs)
    {
        if (shorts.Count() < 2 || longs.Count() < 2)
            return false;
        var s = shorts.TakeLast(2);
        var l = longs.TakeLast(2);

        return s?.First() < l?.First() &&
            s?.Last() >= l?.Last();
    }

    /// <summary>
    /// デットクロスしているかを確認する
    /// </summary>
    /// <remarks>
    /// 引数に要素数2以上の <c>IReusableResult</c> を渡しても実際に使用するのは最後の2要素のみ
    /// </remarks>
    /// <param name="shorts">短期</param>
    /// <param name="longs">長期</param>
    /// <returns>
    /// 要素数2以下の列挙型を引数に渡した場合は<c>false</c><br/>
    /// それ以外はデットクロスの結果による
    /// </returns>
    public static bool IsDeadCross(IEnumerable<decimal> shorts, IEnumerable<decimal> longs)
    {
        if (shorts.Count() < 2 || longs.Count() < 2)
            return false;
        var s = shorts.TakeLast(2);
        var l = longs.TakeLast(2);

        return s?.First() >= l?.First() &&
            s?.Last() < l?.Last();
    }
}
