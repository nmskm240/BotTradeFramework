using BotTrade.Domain.Features;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class FeaturePipelineOrderConverter : IGrpcConverter<FeaturePipelineOrder, GrpcMessages.FeaturePipelineOrder>
{
    public static FeaturePipelineOrder ToEntity(GrpcMessages.FeaturePipelineOrder message)
    {
        return new FeaturePipelineOrder
        {
            ProcessKind = Type.GetType(message.Type, throwOnError: true)!,
            Parameters = message.Parameters
                .Select(FeaturePipelineParameterOrderConverter.ToEntity)
                .ToArray(),
        };
    }

    public static GrpcMessages.FeaturePipelineOrder ToGrpcMessage(FeaturePipelineOrder entity)
    {
        return new GrpcMessages.FeaturePipelineOrder
        {
            Type = entity.ProcessKind.FullName,
            Parameters = {
                entity.Parameters
                    .Select(FeaturePipelineParameterOrderConverter.ToGrpcMessage)
                    .ToArray()
            },
        };
    }
}
