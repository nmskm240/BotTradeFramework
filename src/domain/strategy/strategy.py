from abc import ABC, abstractmethod
from dataclasses import dataclass
from enum import IntEnum, auto
from ..candle import Candle

class ActionType(IntEnum):
    NONE = auto()
    BUY = auto()
    SELL = auto()

@dataclass(frozen=True)
class Action:
    type: ActionType
    quantity: int

    def __post__init__(self):
        if self.quantity < 0:
            raise ValueError("数量がマイナス指定されている")

class IStrategy(ABC):
    @abstractmethod
    def publish_action(candles: list[Candle]) -> Action:
        pass
