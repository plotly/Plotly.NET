# clean up the previously-cached NuGet packages
Remove-Item -Recurse ~\.nuget\packages\Plotly.NET.Interactive* -Force
Remove-Item -Recurse ~\.nuget\packages\Plotly.NET* -Force

# build and pack Plotly.NET.Interactive
cd ../../
dotnet tool restore
dotnet fake build
dotnet pack -c Release -p:PackageVersion=0.0.0-dev -o "./pkg"