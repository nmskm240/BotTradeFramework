using System.Text.Json;
using System.Text.Json.Serialization;

namespace BotTrade.Domain.Features;

public readonly record struct FeaturePipelineParameterInfo
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    [JsonPropertyName("default_value")]
    [JsonConverter(typeof(FeaturePipelineParameterInfoDefaultValueConverter))]
    public required object DefaultValue { get; init; }

    [JsonIgnore]
    public string? StringValue => DefaultValue as string;
    [JsonIgnore]
    public long? LongValue => DefaultValue as long?;
    [JsonIgnore]
    public double? DoubleValue => DefaultValue as double?;
    [JsonIgnore]
    public bool? BoolValue => DefaultValue as bool?;
}

public class FeaturePipelineParameterInfoDefaultValueConverter : JsonConverter<object>
{
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return reader.GetString();
            case JsonTokenType.Number:
                if (reader.TryGetInt64(out var longValue))
                    return longValue;
                if (reader.TryGetDouble(out var doubleValue))
                    return doubleValue;
                break;
            case JsonTokenType.True:
            case JsonTokenType.False:
                return reader.GetBoolean();
            default:
                return null;
        }
        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case string stringValue:
                writer.WriteStringValue(stringValue);
                break;
            case long longValue:
                writer.WriteNumberValue(longValue);
                break;
            case double doubleValue:
                writer.WriteNumberValue(doubleValue);
                break;
            case bool boolValue:
                writer.WriteBooleanValue(boolValue);
                break;
            default:
                writer.WriteNullValue();
                break;
        }
    }
}
