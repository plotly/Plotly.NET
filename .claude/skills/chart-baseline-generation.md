---
name: chart-baseline-generation
description: Use when working in Plotly.NET tests and you need to generate or refresh expected chart output values from real chart rendering instead of inventing assertion strings. This skill helps produce candidate data/layout/html baselines, extract stable segments, and convert investigated output into test expectations.
---

# Chart Baseline Generation

Use this skill when a Plotly.NET test needs an expected string derived from actual chart output.

## Goal

Generate the real chart output first, inspect it, then copy only the stable part into the test as the expected value.

Do not hand-write large expected strings from memory.

## Prerequisites: build the dependency first

The script loads Plotly.NET assemblies from `tests/ConsoleApps/CSharpConsole/bin/Debug/net10.0/`. Before running the script, verify that directory contains `Plotly.NET.dll` and `Plotly.NET.CSharp.dll`. If it is empty or the DLLs are missing, build them first via the FAKE pipeline:

```powershell
./build.cmd Build
```

Any of the `Run*TestsFast` targets also produce these assemblies as a side effect, so if you are about to run tests anyway you can skip the explicit build step.

If you edit sources in `src/Plotly.NET` or `src/Plotly.NET.CSharp` during the investigation, rebuild before re-running the script — `dotnet fsi` caches nothing for you here and stale DLLs silently produce wrong baselines.

## Default workflow

1. Ensure the dependency DLLs exist (see Prerequisites above); build them if missing.
2. Identify the chart fixture or chart-construction expression you want to validate.
3. Prefer an existing fixture from `tests/Common/FSharpTestBase/TestCharts/`.
4. If there is no suitable fixture, put a temporary focused chart expression into `tools/chart-baseline-generation/generate-chart-markup.fsx`.
5. Always use that script for both F# tests and C# tests.
6. For C# wrapper baselines, call `Plotly.NET.CSharp.Chart...` inside the F# script.
7. Keep `UseDefaults = false` on the chart to avoid noisy default template output.
8. Generate output with the same renderer the test uses:
   - `GenericChart.toChartHTML` for shared chart html
   - `GenericChart.toEmbeddedHTML` when the test is specifically about embedded output
9. Let the script print the stable sections you care about directly: `data`, `layout`, `config`, or `plotly-call`.
10. Inspect the generated section output and decide which part is stable enough to assert.
11. Copy the investigated value into the test.
12. Delete any temporary helper code before finishing.

## Where to generate output

Always use `tools/chart-baseline-generation/generate-chart-markup.fsx` as the investigation harness. Do not create or edit console app projects for this workflow.

Edit `createChart()` in `tools/chart-baseline-generation/generate-chart-markup.fsx`, run the script for the section you need, inspect the generated output, then revert the temporary chart expression when finished.

## How to run the script

Examples:

```powershell
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- data
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- layout
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- html
dotnet fsi tools/chart-baseline-generation/generate-chart-markup.fsx -- data --write-html temp/chart.html
```

By default, the script prints extracted stable sections to stdout and does not create temporary files.

Use `--write-html <output-path>` only when you explicitly want the full generated html on disk.

Pick the smallest local loop that matches the test you are editing:

- C# wrapper tests: `./build.cmd RunCSharpTestsFast`
- Core F# tests: `./build.cmd RunTestsCoreFast`
- Extension library tests: `./build.cmd RunTestsExtensionLibsFast`

Use the full `./build.cmd runTestsAll` before committing.

## Recommended temporary pattern

For a one-off investigation, edit `tools/chart-baseline-generation/generate-chart-markup.fsx` so it generates the chart you need, then run the script with the section you want to inspect.

Prefer temporary F# script code like:

```fsharp
let html = GenericChart.toChartHTML chart
```

For C# wrapper baselines, still use the same script and create the chart with `Plotly.NET.CSharp.Chart...`, then render it with:

```fsharp
let html = GenericChart.toChartHTML chart
```

Do not leave exploratory printouts or file dumps in committed script code.

Do not create extra helper files for this workflow unless there is a strong reason. Prefer modifying `tools/chart-baseline-generation/generate-chart-markup.fsx` directly and then reverting the temporary code.

## What to assert

Prefer the smallest stable assertion that proves the behavior:

- full `var data = ...;` block when validating trace serialization
- full `var layout = ...;` block when validating layout generation
- a small but meaningful substring only when the full block is too brittle

Avoid asserting volatile values such as generated DOM ids.

The unified script can print sections by label:

- `data`
- `layout`
- `config`
- `plotly-call`

## Investigation rules

- Treat generated output as a candidate baseline, not automatically correct truth.
- Compare the output with the API intent and nearby F# tests before adopting it.
- If the output looks surprising, stop and investigate the chart construction rather than locking in a wrong baseline.
