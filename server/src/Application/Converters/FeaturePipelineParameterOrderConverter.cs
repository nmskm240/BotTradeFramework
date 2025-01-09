using BotTrade.Domain.Features;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class FeaturePipelineParameterOrderConverter : IGrpcConverter<FeaturePipelineParameterOrder, GrpcMessages.FeaturePipelineParameterOrder>
{
    public static FeaturePipelineParameterOrder ToEntity(GrpcMessages.FeaturePipelineParameterOrder message)
    {
        return new FeaturePipelineParameterOrder
        {
            Name = message.Name,
            Value = message.Value.ValueCase switch
            {
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.StringValue => message.Value.StringValue,
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.LongValue => message.Value.LongValue,
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.DoubleValue => message.Value.DoubleValue,
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.BoolValue => message.Value.BoolValue,
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.ListValue => new List<string>(message.Value.ListValue.Values),
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.MapValue => new Dictionary<string, string>(message.Value.MapValue.Values),
                GrpcMessages.FeaturePipelineParameterValue.ValueOneofCase.SelectValue => message.Value.SelectValue,
                _ => throw new NotImplementedException(),
            },
        };
    }


    public static GrpcMessages.FeaturePipelineParameterOrder ToGrpcMessage(FeaturePipelineParameterOrder entity)
    {
        return new GrpcMessages.FeaturePipelineParameterOrder
        {
            Name = entity.Name,
            Value = entity switch
            {
                { BoolValue: not null } => new() { BoolValue = (bool)entity.BoolValue },
                { LongValue: not null } => new() { LongValue = (long)entity.LongValue },
                { DoubleValue: not null } => new() { DoubleValue = (double)entity.DoubleValue },
                { StringValue: not null } => new() { StringValue = entity.StringValue },
                { ListValue: not null } => new() { ListValue = { Values = { entity.ListValue } } },
                { MapValue: not null } => new() { MapValue = { Values = { entity.MapValue } } },
                _ => throw new NotImplementedException(),
            }
        };
    }
}
