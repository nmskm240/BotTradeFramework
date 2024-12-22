using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

using BotTrade.Common.Extensions;
using BotTrade.Domain.Features;

namespace BotTrade.Domain.Attributes;

public interface IFeaturePipelineParameterInfo<out T>
    where T : FeaturePipelineParameterValue
{
    public string Name { get; }
    public string Description { get; }

    public T ResolveParameterValue(PropertyInfo property);
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public abstract class FeaturePipelineParameterInfoAttribute<T, S>(string name, string description, T defaultValue)
     : Attribute, IFeaturePipelineParameterInfo<S>
     where S : FeaturePipelineParameterValue
{
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    protected T DefaultValue { get; init; } = defaultValue;

    public abstract S ResolveParameterValue(PropertyInfo property);
}

public sealed class LongParameterInfo(string name, string description, long defalutValue)
     : FeaturePipelineParameterInfoAttribute<long, LongValue>(name, description, defalutValue)
{
    public override LongValue ResolveParameterValue(PropertyInfo _) => new() { Value = DefaultValue };
}
public sealed class DoubleParameterInfo(string name, string description, double defalutValue)
     : FeaturePipelineParameterInfoAttribute<double, DoubleValue>(name, description, defalutValue)
{
    public override DoubleValue ResolveParameterValue(PropertyInfo _) => new() { Value = DefaultValue };
}
public sealed class BoolParameterInfo(string name, string description, bool defalutValue)
     : FeaturePipelineParameterInfoAttribute<bool, BoolValue>(name, description, defalutValue)
{
    public override BoolValue ResolveParameterValue(PropertyInfo _) => new() { Value = DefaultValue };
}
public sealed class StringParameterInfo(string name, string description, string defalutValue)
     : FeaturePipelineParameterInfoAttribute<string, StringValue>(name, description, defalutValue)
{
    public override StringValue ResolveParameterValue(PropertyInfo _) => new() { Value = DefaultValue };
}

public sealed class RangeParameterInfo(string name, string description, double defalutValue, double min, double max)
     : FeaturePipelineParameterInfoAttribute<double, RangeValue>(name, description, defalutValue)
{
    public override RangeValue ResolveParameterValue(PropertyInfo _) => new()
    {
        Value = DefaultValue,
        Min = min,
        Max = max,
    };
}
public sealed class SelectParameterInfo(string name, string description, string defalutValue, params string[] options)
     : FeaturePipelineParameterInfoAttribute<string, SelectValue>(name, description, defalutValue)
{
    public override SelectValue ResolveParameterValue(PropertyInfo _) => new()
    {
        Value = DefaultValue,
        Options = options,
    };
}

public sealed class ListParameterInfo(string name, string description, params string[] defalutValue)
    : FeaturePipelineParameterInfoAttribute<string[], ListValue>(name, description, defalutValue)
{
    public override ListValue ResolveParameterValue(PropertyInfo _) => new()
    {
        Value = DefaultValue,
    };
}

public sealed class MapParameterInfo : FeaturePipelineParameterInfoAttribute<string[,], MapValue>
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = true)]
    public sealed class Element(string key, string value) : Attribute
    {
        public string Key => key;
        public string Value => value;
    }

    private string[]? _keyOptions;
    private string[]? _valueOptions;

    public MapParameterInfo(string name, string description, string[]? keyOptions = null, string[]? valueOptions = null)
        : base(name, description, new string[,] { })
    {
        _keyOptions = keyOptions;
        _valueOptions = valueOptions;
    }

    public override MapValue ResolveParameterValue(PropertyInfo property)
    {
        if (property == null)
        {
            return new()
            {
                Value = new Dictionary<string, string>(),
                KeyOptions = _keyOptions,
                ValueOptions = _valueOptions,
            };
        }

        var elements = property.GetCustomAttributes<Element>()
            .Select(e => (e.Key, e.Value))
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        return new()
        {
            Value = elements,
            KeyOptions = _keyOptions,
            ValueOptions = _valueOptions,
        };
    }
}


