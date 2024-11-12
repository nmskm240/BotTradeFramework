using BotTrade.Domain.Settings;
using BotTrade.Domain.Strategies;

namespace BotTrade.Domain;

/// <summary>
/// 設定ファイルで使用する定義済み戦略のEnum
/// </summary>
public enum StrategyKind
{
    [ReflectableEnum(
        typeof(MACross),
        [typeof(IObservable<Candle>), typeof(StrategySetting)])]
    MACross,
}
