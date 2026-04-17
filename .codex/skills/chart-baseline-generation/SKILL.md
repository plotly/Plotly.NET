---
name: chart-baseline-generation
description: Use when working in Plotly.NET tests and you need to generate or refresh expected chart output values from real chart rendering instead of inventing assertion strings. This skill helps agents produce candidate data/layout/html baselines, extract stable segments, and convert investigated output into test expectations.
---

# Chart Baseline Generation

Use this skill when a Plotly.NET test needs an expected string derived from actual chart output.

## Goal

Generate the real chart output first, inspect it, then copy only the stable part into the test as the expected value.

Do not hand-write large expected strings from memory.

## Default workflow

1. Identify the chart fixture or chart-construction expression you want to validate.
2. Prefer an existing fixture from `tests/Common/FSharpTestBase/TestCharts/`.
3. If there is no suitable fixture, put a temporary focused chart expression directly into the appropriate console app entrypoint:
   - `tests/ConsoleApps/CSharpConsole/Program.cs` for C# wrapper output
   - `tests/ConsoleApps/FSharpConsole/Program.fs` for F# output
4. Keep `UseDefaults = false` on the chart to avoid noisy default template output.
5. Generate output with the same renderer the test uses:
   - `GenericChart.toChartHTML` for shared chart html
   - `GenericChart.toEmbeddedHTML` when the test is specifically about embedded output
6. Feed the generated html into `scripts/extract-chart-segments.fsx` to isolate stable sections such as `var data = ...;` and `var layout = ...;`.
7. Inspect the extracted output and decide which part is stable enough to assert.
8. Copy the investigated value into the test.
9. Delete any temporary helper code before finishing.

## Where to generate output

Prefer the console apps as the investigation harness. They are meant for manual exploration and keep baseline-generation code out of the test projects.

- C# investigations: `tests/ConsoleApps/CSharpConsole/Program.cs`
- F# investigations: `tests/ConsoleApps/FSharpConsole/Program.fs`

Add the temporary chart and file-writing code directly in `Program.cs` or `Program.fs`, generate the html you need, inspect it, then remove that temporary code when finished.

## How to run the console apps

Examples:

```powershell
dotnet run --project tests/ConsoleApps/CSharpConsole/CSharpConsole.csproj
dotnet run --project tests/ConsoleApps/FSharpConsole/FSharpConsole.fsproj
```

If you want to save the generated html for extraction, write it to a temporary file under `temp/`.

Pick the smallest local loop that matches the test you are editing:

- C# wrapper tests: `./build.cmd RunCSharpTestsFast`
- Core F# tests: `./build.cmd RunTestsCoreFast`
- Extension library tests: `./build.cmd RunTestsExtensionLibsFast`

Use the full `./build.cmd runTestsAll` before committing.

## Recommended temporary pattern

For a one-off investigation, add temporary code directly to one of the console app entrypoints that writes the generated html to a file under `temp/` or prints it. Then extract the stable pieces.

Prefer temporary C# console code like:

```csharp
var html = Plotly.NET.GenericChart.toChartHTML(chart);
```

or temporary F# console code like:

```fsharp
let html = GenericChart.toChartHTML chart
```

Do not leave exploratory printouts or file dumps in committed console code.

Do not create extra helper files for this workflow unless there is a strong reason. Prefer modifying `Program.cs` or `Program.fs` directly and then reverting the temporary code.

## What to assert

Prefer the smallest stable assertion that proves the behavior:

- full `var data = ...;` block when validating trace serialization
- full `var layout = ...;` block when validating layout generation
- a small but meaningful substring only when the full block is too brittle

Avoid asserting volatile values such as generated DOM ids.

## Helper script

Use `scripts/extract-chart-segments.fsx` to pull stable sections out of generated html.

Examples:

```powershell
dotnet fsi .codex/skills/chart-baseline-generation/scripts/extract-chart-segments.fsx -- temp/chart.html
dotnet fsi .codex/skills/chart-baseline-generation/scripts/extract-chart-segments.fsx -- temp/chart.html data
```

The script extracts sections by label:

- `data`
- `layout`
- `config`
- `plotly-call`

## Investigation rules

- Treat generated output as a candidate baseline, not automatically correct truth.
- Compare the output with the API intent and nearby F# tests before adopting it.
- If the output looks surprising, stop and investigate the chart construction rather than locking in a wrong baseline.
