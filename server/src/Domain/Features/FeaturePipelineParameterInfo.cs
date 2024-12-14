using System.Text.Json;
using System.Text.Json.Serialization;

namespace BotTrade.Domain.Features;

public record FeaturePipelineParameterInfo
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    [JsonPropertyName("default_value")]
    [JsonConverter(typeof(FeaturePipelineParameterInfoDefaultValueConverter))]
    public required object DefaultValue { get; set; }

    [JsonIgnore]
    public string? StringValue => DefaultValue as string;
    [JsonIgnore]
    public int? IntValue => DefaultValue as int?;
    [JsonIgnore]
    public float? FloatValue => DefaultValue as float?;
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
                if (reader.TryGetInt32(out var intValue))
                    return intValue;
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
            case int intValue:
                writer.WriteNumberValue(intValue);
                break;
            case float floatValue:
                writer.WriteNumberValue(floatValue);
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
