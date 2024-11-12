FROM dart:3.5.0

ARG FLUTTER_VERSION=3.24.0
ARG FLUTTER_SDK_PATH=/opt/flutter

ENV PATH="${PATH}:/opt/flutter/bin"

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    curl \
    git \
    wget \
    unzip \
    xz-utils \
    clang \
    cmake \
    ninja-build \
    pkg-config \
    libgtk-3-dev \
    liblzma-dev \
    libstdc++-12-dev \
    libglu1-mesa \
    python3-dev \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

RUN git clone https://github.com/flutter/flutter.git ${FLUTTER_SDK_PATH} \
    && cd ${FLUTTER_SDK_PATH} \
    && git fetch --all --tags \
    && git checkout ${FLUTTER_VERSION} \
    && flutter channel stable \
    && flutter upgrade \
    && flutter precache \
    && chmod -R 777 ${FLUTTER_SDK_PATH}

ENV PATH="${FLUTTER_SDK_PATH}/bin/cache/dart-sdk/bin:${PATH}"
