namespace BotTrade.Domain.Features;

public readonly record struct FeaturePipelineParameterOrder
{
    public required string Name { get; init; }
    public required object Value { get; init; }

    public bool? BoolValue => Value as bool?;
    public int? IntValue => Value as int?;
    public float? FloatValue => Value as float?;
    public string? StringValue => Value as string;
}
