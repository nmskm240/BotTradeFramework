using BotTrade.Domain.Attributes;
using BotTrade.Domain.Ohlcvs;

namespace BotTrade.Domain.Features.Process;

[FeaturePipelineInfo(name: "Aggregate", description: "指定の時間足情報に変換する")]
public sealed class Aggregate : IFeaturePipeline
{
    private static class Rule
    {
        public const string First = "First";
        public const string Last = "Last";
        public const string Sum = "Sum";
        public const string Min = "Min";
        public const string Max = "Max";
    }
    interface IProcess
    {
        double Call(IEnumerable<double> values);
    }
    private sealed class First : IProcess
    {
        public double Call(IEnumerable<double> values) => values.First();
    }
    private sealed class Last : IProcess
    {
        public double Call(IEnumerable<double> values) => values.Last();
    }
    private sealed class Sum : IProcess
    {
        public double Call(IEnumerable<double> values) => values.Sum();
    }
    private sealed class Max : IProcess
    {
        public double Call(IEnumerable<double> values) => values.Max();
    }
    private sealed class Min : IProcess
    {
        public double Call(IEnumerable<double> values) => values.Min();
    }
    private static class ProcessResolver
    {
        public static IProcess Resolve(string rule)
        {
            return rule switch
            {
                Rule.First => new First(),
                Rule.Last => new Last(),
                Rule.Sum => new Sum(),
                Rule.Min => new Min(),
                Rule.Max => new Max(),
                _ => throw new NotImplementedException(),
            };
        }
    }

    private const string DEFALUT_RULE = Rule.Last;
    private readonly RingQueue<Dictionary<string, double>> _buffer;
    public FeaturePipelineOrder Order { get; init; }

    [LongParameterInfo(name: "buffer_size", description: "", defalutValue: 60)]
    public long BufferSize { get; init; }
    [MapParameterInfo(name: "rule_map", description: "", valueOptions: [Rule.First, Rule.Last, Rule.Sum, Rule.Min, Rule.Max])]
    [MapParameterInfo.Element(key: Ohlcv.OPEN_LABEL, value: Rule.First)]
    [MapParameterInfo.Element(key: Ohlcv.HIGH_LABEL, value: Rule.Max)]
    [MapParameterInfo.Element(key: Ohlcv.LOW_LABEL, value: Rule.Min)]
    [MapParameterInfo.Element(key: Ohlcv.CLOSE_LABEL, value: Rule.Last)]
    [MapParameterInfo.Element(key: Ohlcv.VOLUME_LABEL, value: Rule.Sum)]
    [MapParameterInfo.Element(key: Ohlcv.DATE_LABEL, value: Rule.Last)]
    public Dictionary<string, string> RuleMap { get; init; }

    public Aggregate(FeaturePipelineOrder order)
    {
        BufferSize = order.Parameters.First(p => p.Name == "buffer_size").LongValue ?? 60;
        RuleMap = order.Parameters.First(p => p.Name == "rule_map").MapValue ?? [];
        Order = order;
        _buffer = new((int)BufferSize);
    }

    public Dictionary<string, double> Execute(Dictionary<string, double> input)
    {
        _buffer.Enqueue(input);

        if (!_buffer.IsMax)
            return input;

        var header = _buffer.First().Keys;
        var aggregated = new Dictionary<string, double>();
        foreach (var key in header)
        {
            var values = _buffer.Select(pair => pair[key]);
            // TODO: 拡張性を考えるならここはインターフェース化したい
            var rule = RuleMap.GetValueOrDefault(key, DEFALUT_RULE);
            var res = (string)rule switch
            {
                Rule.First => values.First(),
                Rule.Last => values.Last(),
                Rule.Sum => values.Sum(),
                Rule.Max => values.Max(),
                Rule.Min => values.Min(),
                _ => throw new NotImplementedException(),
            };
            aggregated.Add(key, res!);
        }
        return aggregated;
    }
}
