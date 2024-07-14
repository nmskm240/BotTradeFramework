FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN apt-get update \
    && DEBIAN_FRONTEND=noninteractive \
    && apt-get install -y \
        sqlite3 \
        libsqlite3-dev \
        # plantuml用
        default-jre \
        graphviz \
        # vscode tunnel用
        curl \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

RUN cd /tmp \
    && curl -Lk 'https://code.visualstudio.com/sha/download?build=stable&os=cli-alpine-x64' --output vscode_cli.tar.gz \
    && tar -xf vscode_cli.tar.gz \
    && mv code /usr/local/bin/
