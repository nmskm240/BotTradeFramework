from domain import IStrategy, Action, Candle

class NoTrade(IStrategy):
    def publish_action(candles: list[Candle]) -> Action:
        return Action()