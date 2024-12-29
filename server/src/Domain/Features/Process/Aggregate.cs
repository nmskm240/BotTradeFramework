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

    [MapParameterInfo(name: "", description: "", valueOptions: [Rule.First, Rule.Last, Rule.Sum, Rule.Min, Rule.Max])]
    [MapParameterInfo.Element(key: Ohlcv.OPEN_LABEL, value: Rule.First)]
    [MapParameterInfo.Element(key: Ohlcv.HIGH_LABEL, value: Rule.Max)]
    [MapParameterInfo.Element(key: Ohlcv.LOW_LABEL, value: Rule.Min)]
    [MapParameterInfo.Element(key: Ohlcv.CLOSE_LABEL, value: Rule.Last)]
    [MapParameterInfo.Element(key: Ohlcv.VOLUME_LABEL, value: Rule.Sum)]
    [MapParameterInfo.Element(key: Ohlcv.DATE_LABEL, value: Rule.Last)]
    public Dictionary<string, string> RuleMap { get; init; }

    public Aggregate(FeaturePipelineOrder order)
    {
        var size = order.Parameters
            .FirstOrDefault(p => p.Name == "buffer_size").LongValue ?? 0;

        Order = order;
        _buffer = new((int)size);
    }

    public Dictionary<string, double> Execute(Dictionary<string, double> input)
    {
        _buffer.Enqueue(input);

        if(!_buffer.IsMax)
            return input;

        var header = _buffer.First().Keys;
        var aggregated = new Dictionary<string, double>();
        foreach(var key in header)
        {
            var values = _buffer.Select(pair => pair[key]);
            // TODO: 拡張性を考えるならここはインターフェース化したい
            var rule = Order.Parameters
                .FirstOrDefault(p => p.Name == key).StringValue ?? DEFALUT_RULE;
            var res = (string)rule switch
            {
                "first" => values.First(),
                "last" => values.Last(),
                "sum" => values.Sum(),
                "max" => values.Max(),
                "min" => values.Min(),
                _ => throw new NotImplementedException(),
            };
            aggregated.Add(key, res!);
        }
        return aggregated;
    }
}
