# clean up the previously-cached NuGet packages
Remove-Item -Recurse ~\.nuget\packages\Plotly.NET.Interactive* -Force
Remove-Item -Recurse ~\.nuget\packages\Plotly.NET* -Force

# build and pack Plotly.NET.Interactive
dotnet restore
dotnet clean
dotnet build -c Release
dotnet pack -c Release