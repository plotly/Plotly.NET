---
name: chart-baseline-generation
description: Generate Plotly.NET test baselines from real chart rendering so expected data or layout markup is derived from actual output instead of hand-written from memory.
compatibility: opencode
metadata:
  audience: maintainers
  workflow: chart-tests
---

# Chart Baseline Generation

Use this skill when a Plotly.NET test needs an expected string derived from actual chart output.

## Goal

Generate the real chart output first, inspect it, then copy only the stable part into the test as the expected value.

Do not hand-write large expected strings from memory.

## Prerequisites

The script loads Plotly.NET assemblies from `tests/ConsoleApps/CSharpConsole/bin/Debug/net10.0/`.
Before running the script, verify that directory contains `Plotly.NET.dll` and `Plotly.NET.CSharp.dll`.
If it is empty or the DLLs are missing, build them first via the FAKE pipeline:

```powershell
./build.cmd Build
```

Any of the `Run*TestsFast` targets also produce these assemblies as a side effect, so if you are about to run tests anyway you can skip the explicit build step.

If you edit sources in `src/Plotly.NET` or `src/Plotly.NET.CSharp` during the investigation, rebuild before re-running the script. `dotnet fsi` will happily use stale assemblies.

## Workflow

1. Ensure the dependency DLLs exist.
2. Identify the chart fixture or chart-construction expression you want to validate.
3. Prefer an existing fixture from `tests/Common/FSharpTestBase/TestCharts/`.
4. If there is no suitable fixture, put a temporary focused chart expression into `tools/chart-baseline-generation/generate-chart-markup.fsx`.
5. Use that script for both F# tests and C# tests.
6. For C# wrapper baselines, call `Plotly.NET.CSharp.Chart...` inside the F# script.
7. Keep `UseDefaults = false` on the chart to avoid noisy default template output.
8. Generate output with the same renderer the test uses.
9. Copy the smallest stable section into the test.
10. Revert any temporary helper code in the script before finishing.

## Canonical Harness

Always use `tools/chart-baseline-generation/generate-chart-markup.fsx` as the investigation harness.

Edit `createChart()` in that script, run it for the section you need, inspect the generated output, then revert the temporary chart expression when finished.

## Commands

```powershell
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- data
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- layout
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- html
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- data --write-html temp/chart.html
```

## Assertions

Prefer the smallest stable assertion that proves the behavior:

- full `var data = ...;` block when validating trace serialization
- full `var layout = ...;` block when validating layout generation
- a small but meaningful substring only when the full block is too brittle

Avoid asserting volatile values such as generated DOM ids.

## Verification

Use the smallest matching FAKE target while iterating:

- `./build.cmd RunCSharpTestsFast`
- `./build.cmd RunTestsCoreFast`
- `./build.cmd RunTestsExtensionLibsFast`

Run the broader suite before committing when the change scope warrants it.
