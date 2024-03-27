from domain import ICandleRepository, Candle
from infra import Session

class PastCandleRepository(ICandleRepository):
    def fetch(self) -> list[Candle]:
        session = Session()
        return session.query(Candle).all()
