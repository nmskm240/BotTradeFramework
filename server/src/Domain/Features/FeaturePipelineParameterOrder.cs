namespace BotTrade.Domain.Features;

public readonly record struct FeaturePipelineParameterOrder
{
    public required string Name { get; init; }
    public required object Value { get; init; }

    public bool? BoolValue => Value as bool?;
    public long? LongValue => Value as long?;
    public double? DoubleValue => Value as double?;
    public string? StringValue => Value as string;
    public List<string>? ListValue => Value as List<string>;
    public Dictionary<string, string>? MapValue => Value as Dictionary<string, string>;
}
