using BotTrade.Domain.Features;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal sealed class FeaturePipelineParameterValueConverter
     : IGrpcConverter<FeaturePipelineParameterValue, GrpcMessages.FeaturePipelineParameterValue>
{
    public static FeaturePipelineParameterValue ToEntity(GrpcMessages.FeaturePipelineParameterValue message)
    {
        throw new NotImplementedException();
    }

    public static GrpcMessages.FeaturePipelineParameterValue ToGrpcMessage(FeaturePipelineParameterValue entity)
    {
        return entity switch
        {
            LongValue p => new GrpcMessages.FeaturePipelineParameterValue { LongValue = p.Value },
            DoubleValue p => new GrpcMessages.FeaturePipelineParameterValue { DoubleValue = p.Value },
            StringValue p => new GrpcMessages.FeaturePipelineParameterValue { StringValue = p.Value },
            BoolValue p => new GrpcMessages.FeaturePipelineParameterValue { BoolValue = p.Value },
            ListValue p => new GrpcMessages.FeaturePipelineParameterValue { ListValue = new() { Values = { p.Value } } },
            MapValue p => ParseParameterValue(p),
            SelectValue p => ParseParameterValue(p),
            RangeValue p => ParseParameterValue(p),
            _ => throw new NotImplementedException(),
        };
    }

    private static GrpcMessages.FeaturePipelineParameterValue ParseParameterValue(MapValue p)
    {
        var value = new GrpcMessages.FeaturePipelineParameterValue
        {
            MapValue = new()
            {
                Values = { p.Value },
            },
        };

        if (p.KeyOptions != null && p.KeyOptions.Length > 0)
        {
            value.MapValue.SelectableKeys = new()
            {
                Value = p.KeyOptions.First(),
                Options = { p.KeyOptions }
            };
        }
        if (p.ValueOptions != null && p.ValueOptions.Length > 0)
        {
            value.MapValue.SelectableValues = new()
            {
                Value = p.ValueOptions.First(),
                Options = { p.ValueOptions }
            };
        }

        return value;
    }

    private static GrpcMessages.FeaturePipelineParameterValue ParseParameterValue(SelectValue p)
    {
        var value = new GrpcMessages.FeaturePipelineParameterValue
        {
            SelectValue = new()
            {
                Value = p.Value,
                Options = { p.Options },
            },
        };

        return value;
    }

    private static GrpcMessages.FeaturePipelineParameterValue ParseParameterValue(RangeValue p)
    {
        var value = new GrpcMessages.FeaturePipelineParameterValue
        {
            RangeValue = new()
            {
                Value = p.Value,
            }
        };

        if (p.Max != null)
            value.RangeValue.Max = (double)p.Max;
        if (p.Min != null)
            value.RangeValue.Min = (double)p.Min;

        return value;
    }
}
