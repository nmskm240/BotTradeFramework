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
            Value = message.ValueCase switch
            {
                GrpcMessages.FeaturePipelineParameterOrder.ValueOneofCase.StringValue => message.StringValue,
                GrpcMessages.FeaturePipelineParameterOrder.ValueOneofCase.IntValue => message.IntValue,
                GrpcMessages.FeaturePipelineParameterOrder.ValueOneofCase.FloatValue => message.FloatValue,
                GrpcMessages.FeaturePipelineParameterOrder.ValueOneofCase.BoolValue => message.BoolValue,
                _ => throw new NotImplementedException(),
            },
        };
    }

    public static GrpcMessages.FeaturePipelineParameterOrder ToGrpcMessage(FeaturePipelineParameterOrder entity)
    {
        var grpc = new GrpcMessages.FeaturePipelineParameterOrder
        {
            Name = entity.Name,
        };

        if (entity.BoolValue != null)
            grpc.BoolValue = (bool)entity.BoolValue;
        else if (entity.IntValue != null)
            grpc.IntValue = (int)entity.IntValue;
        else if (entity.FloatValue != null)
            grpc.FloatValue = (float)entity.FloatValue;
        else if (entity.StringValue != null)
            grpc.StringValue = entity.StringValue;
        else
            throw new NotImplementedException();

        return grpc;
    }
}
