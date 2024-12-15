namespace BotTrade.Domain.Features.Process;

public sealed class Aggregate : IFeaturePipeline
{
    private readonly RingQueue<Dictionary<string, double>> _buffer;
    private const string DEFALUT_RULE = "last";
    public FeaturePipelineOrder Order { get; init; }

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
