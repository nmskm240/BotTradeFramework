from sqlalchemy import Column, Text, Float,  BigInteger
from . import Base

class Candle(Base):
    __tablename__ = "candles"

    symbol = Column(Text, primary_key=True)
    timestamp = Column(BigInteger, primary_key=True)
    open = Column(Float)
    high = Column(Float)
    low = Column(Float)
    close = Column(Float)
    volume = Column(Float)

    def __str__(self) -> str:
        return f"<Candle(symbol={self.symbol}" \
            f"timestamp={self.timestamp}, " \
            f"open={self.open}, " \
            f"high={self.high}, " \
            f"low={self.low}, " \
            f"close={self.close}, " \
            f"volume={self.volume})> "
