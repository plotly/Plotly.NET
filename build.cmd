@echo off
cls

dotnet tool restore
dotnet restore
dotnet fake build %*