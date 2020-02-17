@echo off
cls

dotnet restore build.proj
dotnet tool restore
dotnet paket restore
dotnet fake build %*