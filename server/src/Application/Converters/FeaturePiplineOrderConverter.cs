using BotTrade.Domain.Features;

using GrpcMessages = BotTrade.Application.Grpc.Generated;

namespace BotTrade.Application.Converters;

internal class FeaturePiplineOrderConverter : IGrpcConverter<FeaturePiplineOrder, GrpcMessages.FeaturePiplineOrder>
{
    public static FeaturePiplineOrder ToEntity(GrpcMessages.FeaturePiplineOrder message)
    {
        return new FeaturePiplineOrder
        {
            ProcessKind = Type.GetType(message.Kind),
            NeedDataSize = message.BufferSize,
            Parameters = message.Parameters.ToDictionary(pair => pair.Key, pair => (object)pair.Value),
        };
    }

    public static GrpcMessages.FeaturePiplineOrder ToGrpcMessage(FeaturePiplineOrder entity)
    {
        var order = new GrpcMessages.FeaturePiplineOrder
        {
            Kind = entity.ProcessKind.FullName,
            BufferSize = entity.NeedDataSize,
        };

        order.Parameters.Add(entity.Parameters.ToDictionary(pair => pair.Key, pair => pair.Value.ToString()));

        return order;
    }
}
