namespace BotTrade.Domain.Strategies;

/// <summary>
/// 設定ファイルで使用する定義済み戦略のEnum
/// </summary>
public enum StrategyKind
{
    [ReflectableEnum(
        typeof(MACross),
        [typeof(Timeframe), typeof(IEnumerable<int>)])]
    MACross,
}
