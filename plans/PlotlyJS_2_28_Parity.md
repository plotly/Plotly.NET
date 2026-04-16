# plotly.js 2.28.0 Full Parity Plan

## Summary

Plotly.NET has been targeting plotly.js 2.28.0 since the bundle was bumped in commit `62a96500`. The bulk of the work — encoded typed array support across all trace types and the F# Chart API — was completed in a long series of commits tracked in [EncodedArraySupport.md](EncodedArraySupport.md). This document identifies the **remaining gaps** needed for full 2.28.0 parity and lays out a plan to close them.

## plotly.js 2.28.0 Release Features

Source: https://github.com/plotly/plotly.js/releases/tag/v2.28.0

### Added

1. **Sankey node `align`** — horizontal alignment option for sankey nodes ([#6800](https://github.com/plotly/plotly.js/pull/6800))
2. **Virtual-WebGL** — option to load a `virtual-webgl` script for multiple WebGL 1 contexts ([#6784](https://github.com/plotly/plotly.js/pull/6784))
3. **Encoded typed arrays** — base64 `bdata`/`dtype`/`shape` object form for data arrays ([#5230](https://github.com/plotly/plotly.js/pull/5230))

### Fixed (JS-only, no Plotly.NET surface needed)

- scattergl rendering on M1 mac
- sankey hover highlighting across multiple traces
- rangeslider drag at x=0
- duplicated major/minor ticks in calc data
- range defaults respecting `minallowed`/`maxallowed`
- `scattergl` legend with `marker.angle` array
- `scatterpolargl` `line.shape` schema cleanup

The fixes are JS-runtime-only and do not require Plotly.NET changes — they are resolved by shipping the updated `plotly-2.28.0.min.js` bundle, which is already in place.

## Current Implementation Status

| Feature | F# Trace Layer | F# Chart API | C# Wrapper | Tests | Status |
|---------|:-:|:-:|:-:|:-:|---|
| Encoded typed arrays | ✅ | ✅ | ✅ (foundational) | ✅ 944 passing | H3 done |
| Sankey node `align` | ✅ | ✅ | ❌ | ✅ | Done (Commit I) |
| Virtual-WebGL | N/A | N/A | N/A | N/A | No surface needed — use `DisplayOptions.AdditionalHeadTags` |
| Sankey encoded arrays (nodes + links) | ✅ | ✅ | ❌ | ✅ | Done (Commit K) |
| ParallelCoord/Categories `keyValuesEncoded` | ✅ | ✅ | ❌ | ✅ | Done (Commit L) |
| Documentation | ✅ | — | — | — | Done (Commit N) |
| Bundled plotly.js 2.28.0 | ✅ | — | — | — | Done |

## Remaining Work Packages

### Commit I: Sankey node `align` property

**Priority: High** — this is a user-visible new feature from 2.28.0 that has no Plotly.NET surface at all.

Scope:

- add a `SankeyNodeAlign` `StyleParam` enum with values matching plotly.js: `Left`, `Right`, `Center`, `Justify` (plotly.js values: `"left"`, `"right"`, `"center"`, `"justify"`)
- add `?Align: StyleParam.SankeyNodeAlign` to `SankeyNodes.init` and `SankeyNodes.style`
- add `?NodeAlign` to `Chart.Sankey` (F#) and `Chart.Sankey` (C#) forwarding to `SankeyNodes`
- verify the `align` property appears in the plotly.js schema for sankey nodes before settling on the exact enum values

Files to change:

- `src/Plotly.NET/CommonAbstractions/StyleParam.fs` — add `SankeyNodeAlign` DU
- `src/Plotly.NET/Traces/ObjectAbstractions/Sankey.fs` — add `?Align` param to `SankeyNodes`
- `src/Plotly.NET/ChartAPI/ChartDomain/ChartDomain_Relations.fs` — add `?NodeAlign` to `Chart.Sankey`
- `src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs` — add `NodeAlign` param to C# `Chart.Sankey`

Tests:

- add a test fixture in `tests/Common/FSharpTestBase/TestCharts/UpstreamFeatures/2.28.fs`
- add assertions in `tests/CoreTests/CoreTests/UpstreamFeatures/2.28.fs`
- verify serialization produces `"node": { "align": "right" }` (or whichever value)

### Commit J: Virtual-WebGL config option

**Priority: Low** — niche feature for pages with many WebGL contexts. Plotly.NET charts are typically rendered one-at-a-time in HTML, but notebook and multi-chart scenarios could benefit.

Scope:

- determine how plotly.js exposes this option (likely a config-level flag or a separate script include)
- if it is a config option: add it to `Config.fs` as `?VirtualWebGL: bool`
- if it is a script include: add support in `DisplayOptions` to inject the virtual-webgl script tag before the plotly.js bundle
- add minimal test coverage

Files to change (depending on mechanism):

- `src/Plotly.NET/Config/Config.fs` — if config-level
- `src/Plotly.NET/DisplayOptions/DisplayOptions.fs` — if script-level
- corresponding C# surface if applicable

Note: This requires further investigation of the plotly.js implementation ([#6784](https://github.com/plotly/plotly.js/pull/6784)) to determine the exact integration point. May be purely client-side and not need a Plotly.NET wrapper at all.

### Commit K: Sankey encoded arrays at Chart API level

**Priority: Medium** — trace-level encoded support already exists; this is about exposing it ergonomically at the Chart API.

Scope:

- design encoded array support for `SankeyNodes` and `SankeyLinks`:
  - add `?LabelEncoded`, `?ColorEncoded`, `?XEncoded`, `?YEncoded`, `?CustomDataEncoded` to `SankeyNodes.init`/`SankeyNodes.style`
  - add `?SourceEncoded`, `?TargetEncoded`, `?ValueEncoded`, `?LabelEncoded`, `?ColorEncoded`, `?CustomDataEncoded` to `SankeyLinks.init`/`SankeyLinks.style`
- add an encoded `Chart.Sankey` overload that accepts nodes/links built with encoded arrays
- add tests

Files to change:

- `src/Plotly.NET/Traces/ObjectAbstractions/Sankey.fs`
- `src/Plotly.NET/ChartAPI/ChartDomain/ChartDomain_Relations.fs`
- test fixtures and assertions in upstream 2.28 test files

### Commit L: ParallelCoord / ParallelCategories `keyValuesEncoded` convenience

**Priority: Low** — `Dimension.initParallel` already supports `ValuesEncoded`, so users can build encoded dimensions manually. This is a convenience-only gap.

Scope:

- add `Chart.ParallelCoord(keyValuesEncoded = ...)` and `Chart.ParallelCategories(keyValuesEncoded = ...)` overloads
- delegate to existing `Dimension.initParallel(ValuesEncoded = ...)` internally
- add tests

### Commit M: C# surface projection (Phase H3)

**Priority: High** — blocks any C# consumer from using encoded arrays through the idiomatic API.

Scope:

- mirror the finalized F# encoded overloads into `Plotly.NET.CSharp`
- focus on foundational chart roots first:
  - `Chart.Scatter`, `Chart.Bar`, `Chart.Histogram`, `Chart.Heatmap`, `Chart.Scatter3D`, etc.
- avoid duplicating every convenience overload — only add C# encoded overloads for the most commonly used chart types
- add C# interop tests in `tests/CoreTests/CSharpInteroperabilityTests/`

Files to change:

- `src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs`
- `src/Plotly.NET.CSharp/ChartAPI/Chart3D.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartMap.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartPolar.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartSmith.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartTernary.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartCarpet.cs`
- test files in `tests/CoreTests/CSharpInteroperabilityTests/`

### Commit N: Documentation updates

**Priority: Medium** — users need to know encoded arrays exist.

Scope:

- add a new doc page (e.g. `docs/general/encoded-arrays.fsx`) showing how to use `EncodedTypedArray` with common chart types
- update the Sankey docs page to show the `align` property
- mention 2.28.0 features in RELEASE_NOTES.md for the upcoming version

## Recommended Commit Order

| Order | Commit | Description | Dependency |
|:---:|:---:|---|---|
| 1 | **I** | Sankey `align` property | None |
| 2 | **K** | Sankey encoded Chart API | None (can parallel with I) |
| 3 | **M** | C# encoded surface (H3) | H2 complete ✅ |
| 4 | **L** | ParallelCoord/Categories encoded convenience | H1-D-Splom complete ✅ |
| 5 | **J** | Virtual-WebGL (investigation + possible impl) | None |
| 6 | **N** | Documentation | After I, K, M |

Commits I and K are independent and can be developed in parallel. Commit M (C# surface) is the largest remaining effort. Commit J requires upstream investigation and may turn out to be unnecessary for the Plotly.NET surface.

## Verification

After all commits:

- `.\build.cmd runTestsAll` should pass
- all upstream 2.28 test fixtures should be green
- C# interop tests should cover at least the foundational encoded chart roots
- manual console samples should render correctly in a browser
