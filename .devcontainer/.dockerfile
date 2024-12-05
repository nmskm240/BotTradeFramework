FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG FLUTTER_VERSION=3.24.0
ARG FLUTTER_SDK_PATH=/opt/flutter
ARG PYTHON_VERSION=3.10.15
ARG PYENV_ROOT=/root/.pyenv

EXPOSE 5000 5001

RUN apt-get update \
    && DEBIAN_FRONTEND=noninteractive \
    && apt-get install -y \
        libssl-dev \
        zlib1g-dev \
        git \
        curl \
        unzip \
        xz-utils \
        zip \
        libglu1-mesa \
        clang \
        cmake \
        ninja-build \
        pkg-config \
        libgtk-3-dev \
        liblzma-dev \
        libstdc++-12-dev \
        default-jre \
        graphviz \
        ca-certificates \
        build-essential \
        libffi-dev \
        cargo \
        sqlite3 \
        python3-openssl \
        protobuf-compiler \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

RUN curl https://pyenv.run | bash

ENV PATH="$PYENV_ROOT/bin:$PYENV_ROOT/shims:$PATH"
ENV PYTHON_CONFIGURE_OPTS="--enable-shared"

RUN pyenv install ${PYTHON_VERSION} && pyenv global ${PYTHON_VERSION}

ENV LD_LIBRARY_PATH="/usr/local/lib:$LD_LIBRARY_PATH"

RUN pip install --no-cache-dir --upgrade pip && \
    pip install \
        rust \
        cython \
        river

RUN git clone https://github.com/flutter/flutter.git ${FLUTTER_SDK_PATH} \
    && cd ${FLUTTER_SDK_PATH} \
    && git fetch --all --tags \
    && git checkout ${FLUTTER_VERSION} \
    && chmod -R 777 ${FLUTTER_SDK_PATH}

ENV PATH="$PATH:${FLUTTER_SDK_PATH}/bin"
