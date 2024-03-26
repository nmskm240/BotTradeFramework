from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

from . import candle

Candle = candle.Candle