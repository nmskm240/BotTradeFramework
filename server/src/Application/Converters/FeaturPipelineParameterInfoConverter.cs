using BotTrade.Domain.Features;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class FeaturePipelineParameterInfoConverter : IGrpcConverter<FeaturePipelineParameterInfo, GrpcMessages.FeaturePipelineParameterInfo>
{
    public static FeaturePipelineParameterInfo ToEntity(GrpcMessages.FeaturePipelineParameterInfo message)
    {
        return new FeaturePipelineParameterInfo
        {
            Name = message.Name,
            Description = message.Description,
            DefaultValue = message.DefaultValueCase switch
            {
                GrpcMessages.FeaturePipelineParameterInfo.DefaultValueOneofCase.StringValue => message.StringValue,
                GrpcMessages.FeaturePipelineParameterInfo.DefaultValueOneofCase.IntValue => message.IntValue,
                GrpcMessages.FeaturePipelineParameterInfo.DefaultValueOneofCase.FloatValue => message.FloatValue,
                GrpcMessages.FeaturePipelineParameterInfo.DefaultValueOneofCase.BoolValue => message.BoolValue,
                _ => throw new NotImplementedException(),
            },
        };
    }

    public static GrpcMessages.FeaturePipelineParameterInfo ToGrpcMessage(FeaturePipelineParameterInfo entity)
    {
        var grpc = new GrpcMessages.FeaturePipelineParameterInfo
        {
            Name = entity.Name,
            Description = entity.Description,
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
