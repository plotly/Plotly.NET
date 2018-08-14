@echo off
cls

dotnet restore build.proj

IF NOT EXIST build.fsx (
  fake run init.fsx
)
fake build %*