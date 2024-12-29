using System.Reflection;

using BotTrade.Application.Converters;
using BotTrade.Application.Grpc.Generated;
using BotTrade.Domain.Attributes;

namespace BotTrade.Application.Usecases;

public sealed class ParseFeaturePipelineInfosUsease
{
    public FeaturePipelineInfos Call()
    {
        // TODO: 後々パイプライン処理をプラグイン化したいためその場合は修正が必須
        var assembly = Assembly.Load("Domain");
        var infos = assembly.GetTypes()
            .Select(type => (type, attribute: type.GetCustomAttribute<FeaturePipelineInfoAttribute>()))
            .Where(pair => pair.attribute != null)
            .Select(pair =>
            {
                var parameters = pair.type.GetProperties()
                    .Where(p => p != null)
                    .SelectMany(p =>
                    {
                        var attributes = p.GetCustomAttributes(true);
                        var parameterInfos = new List<FeaturePipelineParameterInfo?>();
                        foreach (var attribute in attributes)
                        {
                            if (attribute is IFeaturePipelineParameterInfo<Domain.Features.FeaturePipelineParameterValue> info)
                            {
                                var parsed = new FeaturePipelineParameterInfo
                                {
                                    Name = info.Name,
                                    Description = info.Description,
                                    DefaultValue = FeaturePipelineParameterValueConverter.ToGrpcMessage(info.ResolveParameterValue(p)),
                                };
                                parameterInfos.Add(parsed);
                            }
                            else
                            {
                                parameterInfos.Add(null);
                            }
                        }

                        return parameterInfos;
                    })
                    .Where(p => p != null);
                return new FeaturePipelineInfo
                {
                    Name = pair.attribute!.Name,
                    Description = pair.attribute.Description,
                    Parameters = { parameters },
                    Type = pair.type.FullName,
                };
            })
            .ToList();
        return new FeaturePipelineInfos
        {
            Infos = { infos },
        };
    }
}
