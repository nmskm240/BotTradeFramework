namespace BotTrade.Common.Extensions;

public static class ArrayExtensions
{
    public static Dictionary<T, T> ToDictionary<T>(this T[,] source)
        where T : notnull
    {
        if (source.GetLength(1) != 2)
        {
            throw new ArgumentException("");
        }

        var result = new Dictionary<T, T>();
        var rows = source.GetLength(0);
        for (var i = 0; i < rows; i++)
        {
            var key = source[i, 0];
            var value = source[i, 1];
            result.Add(key, value);
        }
        return result;
    }
}
