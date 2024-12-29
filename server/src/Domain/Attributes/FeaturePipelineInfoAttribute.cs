using BotTrade.Domain.Features;

namespace BotTrade.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class FeaturePipelineInfoAttribute(string name, string description) : Attribute
{
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
}
