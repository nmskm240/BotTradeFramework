from abc import ABC, abstractmethod
from . import Candle

class ICandleRepository(ABC):
    @abstractmethod
    def fetch(self) -> list[Candle]:
        pass
