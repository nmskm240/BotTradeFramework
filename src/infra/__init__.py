from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, scoped_session

engine = create_engine(f"sqlite:///../data/Bybit.sqlite3")
# Base.metadata.create_all(bind=engine)
Session = scoped_session(
    sessionmaker(
        bind=engine,
        autoflush=True
    )
)

from infra.past_candle_repository import PastCandleRepository

__all__ = [
    PastCandleRepository,
]