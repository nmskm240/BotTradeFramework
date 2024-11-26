namespace BotTrade.Domain.Features;

public record struct FeaturePiplineOrder(
    Type ProcessKind,
    int NeedDataSize,
    Dictionary<string, object> Parameters
);

public sealed class FeaturePiplineOrderCompareer : IEqualityComparer<FeaturePiplineOrder>
{
    public bool Equals(FeaturePiplineOrder x, FeaturePiplineOrder y)
    {
        return x.NeedDataSize == y.NeedDataSize
            && x.Parameters.Count == y.Parameters.Count
            && x.Parameters.All(pair => y.Parameters.TryGetValue(pair.Key, out var value) && Equals(pair.Value, value));
    }

    public int GetHashCode(FeaturePiplineOrder obj)
    {
        var hash = obj.NeedDataSize;
        foreach(var pair in obj.Parameters)
        {
            hash ^= pair.Key.GetHashCode() ^ pair.Value.GetHashCode();
        }
        return hash;
    }
}
