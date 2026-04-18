# Generic devcontainer base; .NET 10 SDK is layered on via the dotnet feature
# in devcontainer.json (the dedicated dotnet:10.0 devcontainer image isn't
# published yet — pinned via global.json rollForward once installed).
FROM mcr.microsoft.com/devcontainers/base:bookworm

# System deps for Plotly.NET.ImageExport tests (PuppeteerSharp downloads its own
# Chromium at runtime, but needs these shared libraries and fonts to launch it).
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        fonts-liberation \
        libasound2 \
        libatk-bridge2.0-0 \
        libatk1.0-0 \
        libc6 \
        libcairo2 \
        libcups2 \
        libdbus-1-3 \
        libdrm2 \
        libexpat1 \
        libgbm1 \
        libglib2.0-0 \
        libgtk-3-0 \
        libnspr4 \
        libnss3 \
        libpango-1.0-0 \
        libx11-6 \
        libx11-xcb1 \
        libxcb1 \
        libxcomposite1 \
        libxdamage1 \
        libxext6 \
        libxfixes3 \
        libxkbcommon0 \
        libxrandr2 \
        xdg-utils \
    && rm -rf /var/lib/apt/lists/*
