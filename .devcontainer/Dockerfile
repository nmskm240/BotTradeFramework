FROM python:3.10.6
# Latest version in 2022.9.1

RUN python -m pip install --upgrade pip

WORKDIR /workspace

COPY ./requirements.txt /workspace/

RUN pip install -r requirements.txt

ENV JUPYTER_ENABLE_LAB = yes