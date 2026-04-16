# plotly.js 2.28.0 Full Parity Plan

## Summary

Plotly.NET has been targeting plotly.js 2.28.0 since the bundle was bumped in commit `62a96500`. The bulk of the work — encoded typed array support across all trace types and the F# Chart API — was completed in a long series of commits tracked in [EncodedArraySupport.md](EncodedArraySupport.md). The remaining C# domain-surface gaps were closed afterwards, so this document now serves as a completion record for the 2.28.0 parity work.

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

## Final Implementation Status

| Feature | F# Trace Layer | F# Chart API | C# Wrapper | Tests | Status |
|---------|:-:|:-:|:-:|:-:|---|
| Encoded typed arrays | ✅ | ✅ | ✅ | ✅ 946 passing | Done |
| Sankey node `align` | ✅ | ✅ | ✅ | ✅ | Done |
| Virtual-WebGL | N/A | N/A | N/A | N/A | No surface needed — use `DisplayOptions.AdditionalHeadTags` |
| Sankey encoded arrays (nodes + links) | ✅ | ✅ | ✅ | ✅ | Done |
| ParallelCoord/Categories `keyValuesEncoded` | ✅ | ✅ | ✅ | ✅ | Done |
| Documentation | ✅ | — | — | — | Done |
| Bundled plotly.js 2.28.0 | ✅ | — | — | — | Done |

## Implemented Items

### Sankey node `align` property

Implemented across the F# trace/chart layers and the C# wrapper.

Scope:

- add a `SankeyNodeAlign` `StyleParam` enum with values matching plotly.js: `Left`, `Right`, `Center`, `Justify` (plotly.js values: `"left"`, `"right"`, `"center"`, `"justify"`)
- add `?Align: StyleParam.SankeyNodeAlign` to `SankeyNodes.init` and `SankeyNodes.style`
- add `?NodeAlign` to `Chart.Sankey` (F#) and `Chart.Sankey` (C#) forwarding to `SankeyNodes`
- verify the `align` property appears in the plotly.js schema for sankey nodes before settling on the exact enum values

Files to change:

- `src/Plotly.NET/CommonAbstractions/StyleParam.fs` — add `SankeyNodeAlign` DU
- `src/Plotly.NET/Traces/ObjectAbstractions/Sankey.fs` — add `?Align` param to `SankeyNodes`
- `src/Plotly.NET/ChartAPI/ChartDomain/ChartDomain_Relations.fs` — add `?NodeAlign` to `Chart.Sankey`
- `src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs` — expose `NodeAlign` on the higher-level C# `Chart.Sankey` helper

Tests:

- add a test fixture in `tests/Common/FSharpTestBase/TestCharts/UpstreamFeatures/2.28.fs`
- add assertions in `tests/CoreTests/CoreTests/UpstreamFeatures/2.28.fs`
- verify serialization produces `"node": { "align": "right" }`

### Virtual-WebGL

No dedicated Plotly.NET surface was needed. Users can inject the `virtual-webgl` script through `DisplayOptions.AdditionalHeadTags`, which is sufficient for the plotly.js integration model.

### Sankey encoded arrays at Chart API level

Implemented on the trace layer, F# chart layer, and exposed to C# through the wrapper surface.

Scope:

- design encoded array support for `SankeyNodes` and `SankeyLinks`:
  - add `?LabelEncoded`, `?ColorEncoded`, `?XEncoded`, `?YEncoded`, `?CustomDataEncoded` to `SankeyNodes.init`/`SankeyNodes.style`
  - add `?SourceEncoded`, `?TargetEncoded`, `?ValueEncoded`, `?LabelEncoded`, `?ColorEncoded`, `?CustomDataEncoded` to `SankeyLinks.init`/`SankeyLinks.style`
- add an encoded `Chart.Sankey` overload that accepts nodes/links built with encoded arrays
- add tests

Files to change:

- `src/Plotly.NET/Traces/ObjectAbstractions/Sankey.fs`
- `src/Plotly.NET/ChartAPI/ChartDomain/ChartDomain_Relations.fs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs`
- test fixtures and assertions in upstream 2.28 test files

### ParallelCoord / ParallelCategories `keyValuesEncoded` convenience

Implemented on the F# chart layer and mirrored to C#.

Scope:

- add `Chart.ParallelCoord(keyValuesEncoded = ...)` and `Chart.ParallelCategories(keyValuesEncoded = ...)` overloads
- delegate to existing `Dimension.initParallel(ValuesEncoded = ...)` internally
- add tests

### C# surface projection (Phase H3)

Implemented. The foundational encoded chart roots were added earlier, and the missing domain helpers were completed by adding:

- C# `Chart.Sankey(..., NodeAlign, ...)`
- C# `Chart.ParallelCoord(IEnumerable<(string, EncodedTypedArray)> keyValuesEncoded, ...)`
- C# `Chart.ParallelCategories(IEnumerable<(string, EncodedTypedArray)> keyValuesEncoded, ...)`

Scope:

- mirror the finalized F# encoded overloads into `Plotly.NET.CSharp`
- focus on foundational chart roots first:
  - `Chart.Scatter`, `Chart.Bar`, `Chart.Histogram`, `Chart.Heatmap`, `Chart.Scatter3D`, etc.
- avoid duplicating every convenience overload — only add C# encoded overloads for the most commonly used chart types
- validate through the existing core build/test targets

Files to change:

- `src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs`
- `src/Plotly.NET.CSharp/ChartAPI/Chart3D.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartMap.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartPolar.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartSmith.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartTernary.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartCarpet.cs`
- documentation and release notes

### Documentation updates

Implemented.

Scope:

- add a new doc page (e.g. `docs/general/encoded-arrays.fsx`) showing how to use `EncodedTypedArray` with common chart types
- update the Sankey docs page to show the `align` property
- mention 2.28.0 features in `RELEASE_NOTES.md` for the upcoming version

## Outcome

Plotly.NET now has full planned parity with plotly.js 2.28.0:

- bundled plotly.js 2.28.0 runtime
- encoded typed arrays across trace layers and chart APIs
- Sankey node alignment
- encoded Sankey node/link support
- encoded ParallelCoord/ParallelCategories convenience overloads
- C# wrapper coverage for the parity surface
- docs and release notes

## Verification

Verified in repo:

- `.\build.cmd runTestsCore` passes
- upstream 2.28 fixtures are present and green in the core suite
- the C# wrapper builds successfully with the completed domain bindings
