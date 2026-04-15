# Encoded Typed Array Support Plan

## Background

Issue `#441` tracks Plotly.NET support for the plotly.js `>= 2.28.0` encoded `data_array` object form:

```json
{
  "dtype": "f8",
  "bdata": "...base64...",
  "shape": "rows,cols"
}
```

This enables faster transport for trace data fields such as `x`, `y`, `z`, error arrays, and many other `arrayOk` properties.

The implementation approach we agreed on is:

- keep the existing plain `seq<#IConvertible>` API surface
- add parallel `...Encoded` optional parameters using `EncodedTypedArray`
- serialize the encoded property after the plain property so the encoded form wins when both are set
- cover the feature at three levels:
  - low-level serialization/precedence tests in `tests/CoreTests/CoreTests/CommonAbstractions/EncodedTypedArray.fs`
  - upstream feature fixtures in `tests/Common/FSharpTestBase/TestCharts/UpstreamFeatures/2.28.fs`
  - upstream HTML assertions in `tests/CoreTests/CoreTests/UpstreamFeatures/2.28.fs`
- add a small number of manually testable charts in `tests/ConsoleApps/FSharpConsole/Program.fs`

## Commit Packages

### Commit A: Bundle bump + 2.28 scaffold

Scope:

- bump embedded `plotly.js` from `2.27.1` to `2.28.0`
- update embedded resources and `Globals.PLOTLYJS_VERSION`
- remove the explicit CDN pin from `FSharpConsole`
- add the `PlotlyJS_2_28` upstream scaffold and first encoded scatter smoke test

Status:

- implemented and committed as `62a96500`

### Commit B: Scatter completion + Error object

Scope:

- finish remaining encoded `Scatter` data-array fields:
  - `IdsEncoded`
  - `CustomDataEncoded`
  - `SelectedPointsEncoded`
  - `MultiTextEncoded`
- add encoded error arrays on `Error`:
  - `ArrayEncoded`
  - `ArrayminusEncoded`
- add precedence tests and a manual scatter-with-error-bars console chart

Status:

- implemented and committed as `43ff9869`

### Commit C: Trace2D bar family

Scope:

- `Bar`
- `Funnel`
- `Waterfall`

Fields:

- shared where applicable:
  - `XEncoded`
  - `YEncoded`
  - `IdsEncoded`
  - `CustomDataEncoded`
  - `SelectedPointsEncoded`
  - `MultiTextEncoded`
- additional:
  - `Bar.MultiWidthEncoded`
  - `Bar.MultiOffsetEncoded`
  - `Waterfall.MultiOffsetEncoded`

Status:

- implemented and committed as `9c7d1bdd`

### Commit D: Trace2D 1-D trace families

Scope:

- `Histogram`
- `BoxPlot`
- `Violin`
- `OHLC`
- `Candlestick`
- `Splom`

Fields:

- standard encoded sample/metadata arrays where applicable
- `BoxPlot` computed-stat arrays:
  - `Q1Encoded`
  - `MedianEncoded`
  - `Q3Encoded`
  - `LowerFenceEncoded`
  - `UpperFenceEncoded`
  - `NotchSpanEncoded`
  - `MeanEncoded`
  - `SDEncoded`
- finance arrays:
  - `OpenEncoded`
  - `HighEncoded`
  - `LowEncoded`
  - `CloseEncoded`

Status:

- implemented and committed as `f70dea0b`

### Commit E: Trace2D matrix trace families

Scope:

- `Histogram2D`
- `Histogram2DContour`
- `Heatmap`
- `Contour`
- `Image`

Fields:

- matrix traces:
  - `IdsEncoded`
  - `XEncoded`
  - `YEncoded`
  - `ZEncoded`
  - `CustomDataEncoded`
- `Heatmap` and `Contour` additionally:
  - `MultiTextEncoded`
- `Image` only:
  - `IdsEncoded`
  - `MultiTextEncoded`
  - `CustomDataEncoded`

Design note:

- `ZEncoded` uses a flat payload plus `shape`, for example `EncodedTypedArray.ofFloat64Array(flat, shape = [ rows; cols ])`
- `Image` intentionally does **not** get `ZEncoded`, because its `z` shape is RGB/RGBA pixel data rather than the standard numeric matrix path

Status:

- implemented and committed as `97de944e`

### Commit F: Trace3D families

Planned scope:

- `Scatter3D`
- `Surface`
- `Mesh3D`
- `Cone`
- `StreamTube`
- `Volume`
- `IsoSurface`

Expected encoded coverage:

- common:
  - `XEncoded`
  - `YEncoded`
  - `ZEncoded`
  - `IdsEncoded`
  - `CustomDataEncoded`
  - `MultiTextEncoded`
- vector-field traces:
  - `UEncoded`
  - `VEncoded`
  - `WEncoded`
- `Mesh3D`:
  - `IEncoded`
  - `JEncoded`
  - `KEncoded`
  - `IntensityEncoded`
- `Volume` / `IsoSurface`:
  - `ValueEncoded`
- matrix-like scale arrays should follow the same flattened `EncodedTypedArray + shape` pattern when appropriate

Status:

- implemented and committed as `343e31e4`

### Commit G1: Remaining subplot traces, part 1

Planned scope:

- `TracePolar`
- `TraceGeo`
- `TraceMapbox`
- `TraceTernary`
- `TraceSmith`

Expected families include:

- polar:
  - `ScatterPolar`
  - `BarPolar`
- geo/map:
  - `ScatterGeo`
  - `ScatterMapbox`
  - `ChoroplethMap`
  - `ChoroplethMapbox`
  - `DensityMapbox`
- ternary/smith:
  - `ScatterTernary`
  - `ScatterSmith`

Status:

- implemented and committed as `81bd99fd`

### Commit G2: Remaining subplot/domain trace families, part 2

Planned scope:

- `TraceCarpet`
- `TraceDomain`

Expected families include:

- carpet:
  - `Carpet`
  - `ScatterCarpet`
  - `ContourCarpet`
- domain traces:
  - `Pie`
  - `FunnelArea`
  - `Sunburst`
  - `Treemap`
  - `Icicle`
  - `ParallelCoord`
  - `ParallelCategories`
  - `Sankey`
  - `Table`
  - `Indicator`

Status:

- implemented and committed as `8a9fcb64`

## Cross-Cutting Test Strategy

Each package should include:

- low-level integration tests in `EncodedTypedArray.fs`
- matching upstream fixture charts in `TestCharts/UpstreamFeatures/2.28.fs`
- matching upstream HTML assertions in `CoreTests/UpstreamFeatures/2.28.fs`
- one or a few representative manual charts in `FSharpConsole`

For precedence, encoded values should override plain values when both are supplied. This is tested explicitly wherever both APIs coexist.

## Current Progress Summary

Implemented so far:

- base `EncodedTypedArray` type and helpers
- bundle bump to plotly.js `2.28.0`
- full scatter + error-object encoded support
- bar-family encoded support
- 1-D trace-family encoded support
- matrix trace-family encoded support
- Trace3D encoded support
- subplot trace-family support for polar, geo, mapbox, ternary, and smith traces
- carpet and domain trace-family support

Committed so far:

- `62a96500` `Bump bundled plotly.js to 2.28.0`
- `43ff9869` `Complete encoded scatter fields and error arrays`
- `9c7d1bdd` `Add encoded bar-family trace fields`
- `f70dea0b` `Add encoded 1-D trace-family fields`
- `97de944e` `Add encoded matrix trace-family fields`
- `343e31e4` `Add encoded Trace3D fields`
- `81bd99fd` `Add encoded subplot trace fields (part 1)`
- `8a9fcb64` `Add encoded carpet and domain trace fields`

Implemented but not yet committed:

- none for the trace-level rollout

Next planned action:

- plan and implement top-level `Chart` API support for encoded arrays

Latest verification result:

- `.\build.cmd runTestsCore`
- `802` tests passed
- `Plotly.NET` builds successfully
- current committed `Commit G1` work introduces temporary F# XML-doc warnings for newly added encoded parameters

## Next Phase: Top-Level Chart API Support

Now that trace-level support is complete, the next phase is exposing encoded arrays through the high-level `Chart` API in a way that fits the existing Plotly.NET surface.

### Observed `Chart` API shape today

The current high-level API generally follows this pattern:

- one or a few foundational constructors per chart family:
  - `Chart.Scatter`
  - `Chart.Bar`
  - `Chart.Histogram`
  - `Chart.Heatmap`
  - `Chart.Scatter3D`
  - `Chart.Pie`
  - etc.
- multiple convenience overloads for alternate input shapes:
  - `x/y`
  - zipped tuples
  - category/value pairs
  - family-specific shortcuts
- derived chart helpers delegate to those foundations:
  - `Point`/`Line`/`Bubble` build on `Scatter`
  - `Column`/`StackedBar` build on `Bar`
  - similar patterns exist in `Chart3D`, `ChartPolar`, `ChartDomain`, and others

This means the most natural place for encoded support is the foundational chart constructors, not a totally separate abstraction layer.

### Top-level API design reset

The original H1 prototype work explored adding `...Encoded` optional parameters to existing `Chart.*` methods.

That direction is now superseded.

New rule set for the top-level API:

- keep the existing chart family names such as `Chart.Scatter`, `Chart.Bar`, `Chart.Heatmap`
- add **one additional encoded overload per chart type**
- the encoded overload should take encoded array arguments directly, for example `xEncoded`, `yEncoded`
- the encoded overload should **not** also expose the corresponding plain `x`/`y`/`z`/`values` parameters
- do **not** add tuple-based encoded overloads
- keep tuple/zip convenience overloads on the plain pathway only
- style/config arguments can remain optional on the encoded overload, but the encoded data arguments themselves should be explicit and required where they define the chart

Examples of the intended shape:

- `Chart.Scatter(xEncoded, yEncoded, ?Mode, ?Name, ...)`
- `Chart.Bar(valuesEncoded, ?keysEncoded, ?MultiWidthEncoded, ?Name, ...)`
- `Chart.Heatmap(zEncoded, ?xEncoded, ?yEncoded, ?Name, ...)`

This gives a clearer user-facing distinction than mixing plain and encoded inputs in one giant signature, while still preserving the familiar `Chart.*` family names.

### Consequence for current H1 work

The first top-level API commits were implemented against the older optional-parameter design and should still be treated as **prototype-only**:

- `37006fd9` (`H1-A`)
- `5edcbb17` (`H1-B`)

After the reset, the current working direction is:

- keep those earlier commits as historical prototypes for now
- re-implement the desired API shape through new encoded-only overloads
- continue package-by-package from that reset design

Current reset-design status:

- `H1-A` scatter root overload is still pending under the reset design
- `H1-B` scatter-derived encoded overloads are implemented and committed as `b5767af5`
- `H1-C` bar-family roots are implemented and committed with the Waterfall encoded-width fix
- `H1-D` distribution and finance roots are implemented and committed as `4913748a`
- encoded `Dimension` values and top-level `Chart.Splom` encoded construction are implemented and committed as `ed86f94d`
- `H1-E` matrix roots are implemented and committed as `62e9161c`
- `H1-F` 3D roots are implemented and committed as `045a2b63`
- `H1-G` subplot and domain roots are implemented locally and pending commit, with Sankey intentionally deferred

### Recommended scope split for this phase

#### Phase H1: Core family constructors

H1 should be implemented as a sequence of small work packages rather than one full API sweep.

##### H1-A: Scatter encoded overload

Scope:

- add one encoded overload for `Chart2D.Scatter`
- require `xEncoded` and `yEncoded`
- do not expose plain `x` or `y` on that overload
- do not add encoded tuple overloads
- keep the existing plain overloads untouched
- add focused chart-level tests plus one manual console sample

Status:

- implemented locally and ready to commit
- encoded overload is in place for `Chart.Scatter(xEncoded, yEncoded, mode, ...)`
- chart-level, upstream, and console coverage are in place

Why first:

- smallest useful slice
- validates the reset top-level API shape
- establishes the encoded-overload test pattern before applying the change broadly

##### H1-B: Scatter-derived encoded overloads

Scope:

- add one encoded overload per scatter-derived helper that meaningfully owns data binding:
  - `Point`
  - `Line`
  - `Spline`
  - `Bubble`
  - `Range`
  - `Area`
  - `SplineArea`
  - `StackedArea`
- each encoded overload should take encoded primary data arrays as direct arguments
- no tuple-based encoded overloads

Why grouped:

- same underlying trace family
- strong chance to reuse the same overload and delegation pattern introduced by H1-A

Status:

- implemented and committed as `b5767af5`

Verification completed locally:

- chart-level unit tests in `EncodedTypedArray.fs`
- upstream `2.28` fixtures/tests for helper constructors
- focused `FSharpConsole` sample using encoded `Chart.Range`
- `.\build.cmd runTestsCore`

##### H1-C: Bar-family roots

Scope:

- add one encoded overload for each foundational bar-family constructor:
  - `Chart2D.Bar`
  - `Chart2D.Funnel`
  - `Chart2D.Waterfall`
- use the existing public vocabulary of each chart type:
  - `Bar(valuesEncoded, ?keysEncoded, ...)`
  - `Funnel(xEncoded, yEncoded, ...)`
  - `Waterfall(xEncoded, yEncoded, ...)`
- include encoded width/offset arrays only when they are already meaningful on that chart type at the top-level API
- no encoded tuple overloads

Why grouped:

- these constructors already share similar positional/value wiring
- natural continuation after scatter-style 1D arrays

Status:

- implemented and committed under the reset design

Verification completed locally:

- chart-level unit tests in `EncodedTypedArray.fs`
- upstream `2.28` fixtures/tests for bar-family root constructors
- focused `FSharpConsole` sample using encoded `Chart.Bar`
- `.\build.cmd runTestsCore`

##### H1-D: Distribution and finance roots

Scope:

- add one encoded overload per foundational root:
  - `Chart2D.Histogram`
  - `Chart2D.BoxPlot`
  - `Chart2D.Violin`
  - `Chart2D.OHLC`
  - `Chart2D.Candlestick`
- keep the encoded overload count to one per chart type
- no tuple-based encoded overloads

Why grouped:

- all are foundational `Chart2D` roots with mainly 1D encoded inputs
- finance traces share the open/high/low/close pattern
- boxplot is the one larger outlier, but still mechanical once the encoded-overload convention is set

Status:

- implemented and committed under the reset design for `Histogram`, `BoxPlot`, `Violin`, `OHLC`, and `Candlestick` as `4913748a`
- `Splom` deferred pending a dedicated chart-level design pass around encoded `Dimension` construction

Verification completed locally:

- chart-level unit tests in `EncodedTypedArray.fs`
- upstream `2.28` fixtures/tests for distribution and finance root constructors
- focused `FSharpConsole` sample using encoded `Chart.Candlestick`
- `.\build.cmd runTestsCore`

##### H1-D-Splom: Draft adjustments

Original problem:

- `Chart2D.Splom` does not bind raw arrays directly at the chart-root signature
- it binds through `Dimension` objects, and each `Dimension` carries its own values
- the current reset-design rule of "one additional encoded overload per chart type" does not map as neatly here as it does for `Histogram` or `OHLC`
- the actual serialization seam is `Dimension.style`, which currently only writes plain `"values"`

Chosen adjustment:

- keep `Chart.Splom(dimensions, ...)` as the primary high-level constructor
- add one focused encoded chart overload:
  - `Chart.Splom(keyValuesEncoded = seq<string * EncodedTypedArray>, ...)`
- keep the existing `Chart.Splom(dimensions, ...)` and plain `Chart.Splom(keyValues, ...)` overloads intact
- instead, add encoded construction support at the `Dimension` layer and let `Chart.Splom` consume those dimensions unchanged

Concrete design sketch:

- add an encoded-capable dimension constructor, for example:
  - `Dimension.initSplom(Label = ..., ValuesEncoded = encoded)`
- extend `Dimension.style` with `?ValuesEncoded: EncodedTypedArray`
- serialize `"values"` twice in `Dimension.style`, plain first and encoded second, matching the precedence pattern used elsewhere
- keep the existing plain `Values` path intact
- ensure the resulting `Dimension` serializes encoded values to the underlying trace `dimensions[i].values` field
- then the new `Chart.Splom(keyValuesEncoded = ...)` overload simply maps into encoded `Dimension` objects and reuses the existing `Chart.Splom(dimensions, ...)` pathway

Likely code changes:

- [Dimensions.fs](/g:/source/repos/plotly/Plotly.NET/src/Plotly.NET/Traces/ObjectAbstractions/Dimensions.fs)
  - add `?ValuesEncoded` to `Dimension.style`
  - add `?ValuesEncoded` to `Dimension.initSplom`
  - optionally add `?ValuesEncoded` to `Dimension.initParallel` too, if we want the same capability available to `ParallelCoord`/`ParallelCategories`
- [Chart2D.fs](/g:/source/repos/plotly/Plotly.NET/src/Plotly.NET/ChartAPI/Chart2D.fs)
  - add a focused `Chart.Splom(keyValuesEncoded = ...)` overload that delegates to encoded `Dimension` construction
- trace layer:
  - no `Trace2DStyle.Splom` change appears necessary, because it already accepts `Dimensions: seq<Dimension>`

Why this fits the API better:

- preserves the existing `Splom` shape, where dimensions are first-class objects
- avoids inventing a chart-level overload with awkward arguments like `dimensionsEncoded`
- mirrors the actual plotly.js data model more closely, where SPLOM values live inside per-dimension objects
- keeps the reset-design principle of explicit encoded inputs while still giving `Chart.Splom` a direct encoded constructor

Suggested implementation split:

- `Splom-A`: add encoded support to `Dimension` / related trace object constructors
- `Splom-B`: add low-level tests for encoded dimension serialization
- `Splom-C`: add chart-level `Chart.Splom(keyValuesEncoded = ...)` tests
- `Splom-D`: add one upstream `2.28` fixture/assertion pair and one focused `FSharpConsole` sample

Suggested tests:

- low-level serialization in `tests/CoreTests/CoreTests/CommonAbstractions/EncodedTypedArray.fs`
  - `Dimension.initSplom(ValuesEncoded=...)` writes `"values":{"bdata":...}`
  - when both `Values` and `ValuesEncoded` are set, the encoded object wins
- chart-level:
  - `Chart.Splom(keyValuesEncoded = [ "a", ...; "b", ... ], UseDefaults=false)` emits encoded `dimensions[0].values`
  - `ShowLowerHalf`, `Name`, and other SPLOM-specific options still serialize correctly
- upstream:
  - one representative `Splom` chart with two encoded dimensions
  - assertions should check nested `"dimensions":[{"label":"...","values":{"bdata":...}}` rather than top-level data-array fields
- manual:
  - one small `FSharpConsole` example with two or three encoded dimensions and a marker color for easy visual inspection

Potential follow-on benefit:

- if `Dimension.style` gains `ValuesEncoded`, the same mechanism could unlock encoded support for:
  - `Chart.ParallelCoord`
  - `Chart.ParallelCategories`
- that suggests `Dimension` may be the better abstraction boundary than adding separate top-level encoded overloads for each chart that consumes dimensions

Status:

- implemented and committed as `ed86f94d`
- `Dimension.initSplom`, `Dimension.initParallel`, and `Dimension.style` now accept `ValuesEncoded`
- `Chart.Splom(keyValuesEncoded = ...)` is implemented at the top level
- low-level, upstream, and console coverage are in place

##### H1-E: Matrix roots

Scope:

- add one encoded overload per matrix root:
  - `Chart2D.Histogram2D`
  - `Chart2D.Histogram2DContour`
  - `Chart2D.Heatmap`
  - `Chart2D.Contour`
- consider `Image` separately only if a high-level encoded metadata pathway is still worth exposing

Special concern:

- matrix payloads need explicit `zEncoded` plus `shape`
- the encoded overload should reflect the chart-level semantics directly rather than mixing plain and encoded `z` in the same signature

Why grouped:

- all share the same matrix/flattening design question

Status:

- implemented and committed as `62e9161c`
- encoded overloads are in place for `Histogram2D`, `Histogram2DContour`, `Heatmap`, and `Contour`
- chart-level, upstream, and console coverage are in place

##### H1-F: 3D roots

Scope:

- add one encoded overload per foundational root:
  - `Chart3D.Scatter3D`
  - `Chart3D.Surface`
  - `Chart3D.Mesh3D`
  - `Chart3D.Cone`
  - `Chart3D.StreamTube`
  - `Chart3D.Volume`
  - `Chart3D.IsoSurface`

Why grouped:

- common xyz-style input shape
- vector-field and topology/value extras are easiest to review together once the chart-level pattern is established

Status:

- implemented and committed as `045a2b63`
- encoded overloads are in place for `Scatter3D`, `Surface`, `Mesh3D`, `Cone`, `StreamTube`, `Volume`, and `IsoSurface`
- chart-level, upstream, and console coverage are in place

##### H1-G: Subplot and domain roots

Scope:

- add one encoded overload per true root:
  - `BarPolar`
  - `Pie`
  - `Sunburst`
  - `Treemap`
  - `FunnelArea`
  - `Icicle`
  - `ChoroplethMap`
  - `ChoroplethMapbox`
  - `DensityMapbox`
  - `ScatterPolar`
  - `ScatterGeo`
  - `ScatterMapbox`
  - `ScatterTernary`
  - `ScatterSmith`
  - `Carpet`
  - `ScatterCarpet`
  - `ContourCarpet`
- defer `Sankey` to a later follow-up because the meaningful encoded payloads live inside nested `node`/`link` objects rather than the top-level root signature
- do not add `keyValuesEncoded` conveniences for `ParallelCoord` or `ParallelCategories` in this slice
- leave `Indicator` and `Table` out unless a strong encoded root use case emerges later

Why grouped:

- smaller trace families with different file locations but the same top-level API decision
- better saved until the core 2D/3D patterns are stable

Status:

- implemented locally and ready to commit
- encoded overloads are in place for `BarPolar`, `ChoroplethMap`, `Pie`, `FunnelArea`, `Sunburst`, `Treemap`, `Icicle`, `ScatterPolar`, `ScatterGeo`, `ScatterMapbox`, `ChoroplethMapbox`, `DensityMapbox`, `ScatterTernary`, `ScatterSmith`, `Carpet`, `ScatterCarpet`, and `ContourCarpet`
- `Sankey` was analyzed and intentionally deferred for now
- no `keyValuesEncoded` overloads were added for `ParallelCoord` or `ParallelCategories`
- chart-level, upstream, and console coverage are in place

### Recommended H1 order

1. H1-A `Scatter` PoC
2. H1-B scatter-derived helpers
3. H1-C bar-family roots
4. H1-D distribution and finance roots
5. H1-E matrix roots
6. H1-F 3D roots
7. H1-G subplot and domain roots

### H1 testing expectations

Each H1 work package should add:

- chart-level serialization tests proving encoded objects appear in the generated figure JSON
- overload-shape tests where relevant, proving the encoded overload uses only the encoded pathway
- a small `FSharpConsole` sample only for the package currently under discussion, not a cumulative playground
- upstream feature coverage only once we decide that top-level API support is part of the user-facing 2.28 feature story and not just a convenience layer over the already-tested trace support

#### Phase H2: Derived convenience constructors

Update any remaining helpers that still deserve dedicated encoded overloads after H1:

- `Point`, `Line`, `Spline`, `Bubble`
- `Column`, `StackedBar`, `StackedColumn`, `Area`, `SplineArea`, `StackedArea`
- domain and map convenience helpers where encoded input still makes ergonomic sense

Rule of thumb:

- do not automatically mirror every plain convenience overload
- only add an encoded overload when the chart type is valuable enough on its own and still reads clearly without tuple shortcuts

Status:

- implemented for the full set of derived convenience helpers across `Chart2D`, `Chart3D`, `ChartCarpet`, `ChartDomain`, `ChartMap`, `ChartPolar`, `ChartSmith`, and `ChartTernary`
- `Chart2D`: `StackedBar`, `Column`, `StackedColumn`, `PointDensity`, `StackedFunnel`
- `Chart3D`: `Point3D`, `Line3D`, `Bubble3D`
- `ChartCarpet`: `PointCarpet`, `LineCarpet`, `SplineCarpet`, `BubbleCarpet`
- `ChartDomain`: `Doughnut`
- `ChartMap`: `PointGeo`, `LineGeo`, `BubbleGeo`, `PointMapbox`, `LineMapbox`, `BubbleMapbox`
- `ChartPolar`: `PointPolar`, `LinePolar`, `SplinePolar`, `BubblePolar`
- `ChartSmith`: `PointSmith`, `LineSmith`, `BubbleSmith`
- `ChartTernary`: `PointTernary`, `LineTernary`, `BubbleTernary`
- intentionally excluded: `Pareto`, `Residual`, `AnnotatedHeatmap` (in-F# computation over input arrays does not fit opaque encoded data)
- chart-level, upstream, and console coverage are in place
- `.\build.cmd runTestsCore` reports 933 tests passing

#### Phase H3: C# surface

Project the finalized F# shape into `Plotly.NET.CSharp`:

- avoid exposing a larger set of C# methods than necessary
- prefer mirroring the foundational F# constructors first
- only add C# convenience overloads after the F# API shape is stable

### Working rules for implementation

- avoid creating a parallel `Chart.*Encoded` namespace unless the current overload-based plan proves unworkable
- prefer adding encoded support to the smallest set of foundational methods that gives the rest of the API a delegation path
- keep encoded-overrides-plain precedence consistent with the trace layer
- add tests at the `Chart` level once the first H1 slice is in place
- defer XML-doc cleanup into its own targeted follow-up unless it blocks review
