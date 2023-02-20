FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN apt-get update \
    && apt-get -y upgrade \
    && apt-get -y install python3 python3-pip python3-dev ipython3

RUN pip3 install --no-cache notebook

ARG NB_USER=plotly
ARG NB_UID=1000
RUN useradd -m -s /bin/bash -N -u $NB_UID $NB_USER

USER $NB_USER

ENV HOME=/home/$NB_USER

WORKDIR $HOME

ENV PATH="${PATH}:$HOME/.dotnet/tools/"

RUN dotnet tool install --global Microsoft.dotnet-interactive --version 1.0.410202

RUN dotnet-interactive jupyter install
