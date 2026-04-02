# Clean up the previously-cached NuGet packages.
# Lower-case is intentional (that's how nuget stores those packages).
Remove-Item -Recurse ~\.nuget\packages\plotly.net.verso* -Force
Remove-Item -Recurse ~\.nuget\packages\plotly.net -Force -ErrorAction SilentlyContinue

# build and pack Plotly.NET + Plotly.NET.Verso
cd ../../
./build.cmd
dotnet pack src/Plotly.NET/Plotly.NET.fsproj -tl -c Release -p:PackageVersion=6.0.0 -o "./tests/VersoTests/pkg"
dotnet pack src/Plotly.NET.Verso/Plotly.NET.Verso.fsproj -tl -c Release -p:PackageVersion=0.0.1-dev -o "./tests/VersoTests/pkg"
cd tests/VersoTests
