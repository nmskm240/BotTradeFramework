namespace BotTrade.Domain.Features;

public abstract class FeaturePipelineParameterValue
{
}

public abstract class FeaturePipelineParameterValue<T> : FeaturePipelineParameterValue
{
    public abstract T Value { get; init; }
}

public sealed class LongValue : FeaturePipelineParameterValue<long>
{
    public override required long Value { get; init; }
}

public sealed class DoubleValue : FeaturePipelineParameterValue<double>
{
    public override required double Value { get; init; }
}

public sealed class BoolValue : FeaturePipelineParameterValue<bool>
{
    public override required bool Value { get; init; }
}

public sealed class StringValue : FeaturePipelineParameterValue<string>
{
    public override required string Value { get; init; }
}

public sealed class RangeValue : FeaturePipelineParameterValue<double>
{
    public override required double Value { get; init; }
    public double? Min { get; init; } = null;
    public double? Max { get; init; } = null;
}

public sealed class SelectValue : FeaturePipelineParameterValue<string>
{
    public override required string Value { get; init; }
    public required string[] Options { get; init; }
}

public sealed class ListValue : FeaturePipelineParameterValue<IEnumerable<string>>
{
    public override required IEnumerable<string> Value { get; init; }
}

public sealed class MapValue : FeaturePipelineParameterValue<IDictionary<string, string>>
{
    public override required IDictionary<string, string> Value { get; init; }
    public string[]? KeyOptions { get; init; } = null;
    public string[]? ValueOptions { get; init; } = null;
}
