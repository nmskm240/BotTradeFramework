using BotTrade.Domain.Features;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class FeaturePipelineInfoConverter : IGrpcConverter<FeaturePipelineInfo, GrpcMessages.FeaturePipelineInfo>
{
    public static FeaturePipelineInfo ToEntity(GrpcMessages.FeaturePipelineInfo message)
    {
        return new FeaturePipelineInfo()
        {
            Type = message.Type,
            Name = message.Name,
            Description = message.Description,
            Parameters = message.Parameters
                .Select(FeaturePipelineParameterInfoConverter.ToEntity)
                .ToArray(),
        };
    }

    public static GrpcMessages.FeaturePipelineInfo ToGrpcMessage(FeaturePipelineInfo entity)
    {
        return new GrpcMessages.FeaturePipelineInfo
        {
            Type = entity.Type,
            Name = entity.Name,
            Description = entity.Description,
            Parameters = {
                entity.Parameters
                    .Select(FeaturePipelineParameterInfoConverter.ToGrpcMessage)
                    .ToList()
            },
        };
    }
}
