using BotTrade.Application.Grpc.Generated;
using BotTrade.Application.Usecases;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using ServiceBase = BotTrade.Application.Grpc.Generated.FeatureService;

namespace BotTrade.Application.Services;

public class FeatureService : ServiceBase.FeatureServiceBase
{
    public override Task<FeaturePipelineInfos> SupportedFeaturePipelines(Empty request, ServerCallContext context)
    {
        var usecase = new ParseFeaturePipelineInfosUsease();
        return Task.FromResult(usecase.Call());
    }
}
