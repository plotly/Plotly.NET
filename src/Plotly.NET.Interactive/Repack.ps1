# Clean up the previously-cached NuGet packages.
# Lower-case is intentional (that's how nuget stores those packages).
Remove-Item -Recurse ~\.nuget\packages\plotly.net.interactive* -Force
Remove-Item -Recurse ~\.nuget\packages\plotly.net* -Force

# build and pack Plotly.NET.Interactive
cd ../../
dotnet tool restore
dotnet fake build
dotnet pack -c Release -p:PackageVersion=0.0.0-dev -o "./pkg"
