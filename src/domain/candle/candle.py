from dataclasses import dataclass
from sqlalchemy import Column, Text, Float,  BigInteger
from .. import Base

@dataclass()
class Candle(Base):
    __tablename__ = "candles"

    symbol: str = Column(Text, primary_key=True)
    timestamp: int = Column(BigInteger, primary_key=True)
    open: float = Column(Float)
    high: float = Column(Float)
    low: float = Column(Float)
    close: float = Column(Float)
    volume: float = Column(Float)

    def __str__(self) -> str:
        return f"<Candle(symbol={self.symbol}" \
            f"timestamp={self.timestamp}, " \
            f"open={self.open}, " \
            f"high={self.high}, " \
            f"low={self.low}, " \
            f"close={self.close}, " \
            f"volume={self.volume})> "
