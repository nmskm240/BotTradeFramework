using System.Runtime.Serialization.Json;
using System.Text.Json;

using BotTrade.Domain.Features;


namespace BotTrade.Infra;

public class FeaturePipelineInfoLoader : IFeaturePipelineInfoLoader
{
    public IEnumerable<FeaturePipelineInfo> Load(string path)
    {
        using var stream = new FileStream(path, FileMode.Open);
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();
        var infos = JsonSerializer.Deserialize<FeaturePipelineInfo[]>(json)
            ?? Enumerable.Empty<FeaturePipelineInfo>();
        return infos;
    }
}
