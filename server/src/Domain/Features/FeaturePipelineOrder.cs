namespace BotTrade.Domain.Features;

public readonly record struct FeaturePipelineOrder
{
    public required Type ProcessKind { get; init; }
    public required FeaturePipelineParameterOrder[] Parameters { get; init; }
}

public sealed class FeaturePipelineOrderComparer : IEqualityComparer<FeaturePipelineOrder>
{
    public bool Equals(FeaturePipelineOrder x, FeaturePipelineOrder y)
    {
        if (x.Parameters.Length != y.Parameters.Length)
            return false;

        for (var i = 0; i < x.Parameters.Length; i++)
        {
            if (!Equals(x.Parameters[i], y.Parameters[i]))
                return false;
        }
        return true;
    }

    public int GetHashCode(FeaturePipelineOrder obj)
    {
        var hash = obj.ProcessKind.GetHashCode();
        foreach (var param in obj.Parameters)
        {
            hash = (hash * 397) ^ param.GetHashCode();
        }
        return hash;

    }
}
