using System;

namespace BotTrade.Domain.Features;

// TODO: Json経由でなく、SouceGenerateでInfoを作成するようにしたい
public interface IFeaturePipelineInfoLoader
{
    IEnumerable<FeaturePipelineInfo> Load(string path);
}
