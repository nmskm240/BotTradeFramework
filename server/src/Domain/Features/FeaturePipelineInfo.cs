using System.Text.Json.Serialization;

namespace BotTrade.Domain.Features;

public readonly record struct FeaturePipelineInfo
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    [JsonPropertyName("parameters")]
    public required FeaturePipelineParameterInfo[] Parameters { get; init; }
}
