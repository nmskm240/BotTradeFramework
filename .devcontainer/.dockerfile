FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG FLUTTER_VERSION=3.24.0
ARG FLUTTER_SDK_PATH=/opt/flutter

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
        default-jre \
        graphviz \
        ca-certificates \
        build-essential \
        libffi-dev \
        cargo \
        sqlite3 \
        python3 \
        python3-pip \
        python3.11-venv \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

RUN python3 -m venv /opt/venv
ENV PATH="/opt/venv/bin:$PATH"
RUN pip install --no-cache-dir --upgrade pip && \
    pip install \
        rust \
        cython \
        git+https://github.com/online-ml/river

RUN git clone https://github.com/flutter/flutter.git ${FLUTTER_SDK_PATH} \
    && cd ${FLUTTER_SDK_PATH} \
    && git fetch --all --tags \
    && git checkout ${FLUTTER_VERSION} \
    && export PATH="$PATH:/opt/flutter/bin" \
    && flutter channel stable \
    && flutter upgrade \
    && flutter precache \
    && chmod -R 777 ${FLUTTER_SDK_PATH}

ENV PATH="${FLUTTER_SDK_PATH}/bin/cache/dart-sdk/bin:${PATH}"

