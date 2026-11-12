# Prepare the local feed and a portable smoke notebook through the repository build.
# No package caches are deleted. Run RunVersoIntegrationTests for isolated host testing.
$ErrorActionPreference = 'Stop'
$repository = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../..'))
Push-Location -LiteralPath $repository
try {
    dotnet run --project ./build/build.fsproj -- PackVersoIntegrationPackages
    if ($LASTEXITCODE -ne 0) { throw "Package preparation failed with exit code $LASTEXITCODE." }
    Write-Host "Local smoke notebook: $(Join-Path $PSScriptRoot 'artifacts/test.verso')"
}
finally {
    Pop-Location
}
