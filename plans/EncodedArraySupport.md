# Encoded Typed Array Support Plan

## Scope and current status

Encoded-array support is a shared Plotly.NET feature, not a C#-only feature. The core `Plotly.NET` assembly owns the data representation, encoding helpers, serialization, trace objects, and F# `Chart` constructors. C# can already use those public .NET types and pass encoded nested objects through existing wrappers. Phase H3 adds convenient encoded overloads to `Plotly.NET.CSharp.Chart`.

The upstream context is [Plotly.NET issue #441](https://github.com/plotly/Plotly.NET/issues/441) and [plotly.js 2.28.0](https://github.com/plotly/plotly.js/releases/tag/v2.28.0). The wire representation contains `dtype`, base64 `bdata`, and optional `shape`; it is shared by both languages. This plan does not claim a measured performance improvement.

Updated on 2026-09-10 for the merge of `dev` at `41f2f88c` (the merged C# refactor, PR #503) into `plotly2.28` at `fd862365` (PR #502). Status means present in the resolved merge unless another ref is named explicitly. Verification of this integration is recorded below.

| Layer / scope | Status in this checkout | Remaining work |
|---|---|---|
| Shared `EncodedTypedArray`, numeric factories, JSON representation | Implemented; C# factory syntax compiled in regression tests | Document the verified syntax in Next 6; reuse the shared type |
| Bundled plotly.js 2.28.0 and selected trace fields (A–G2) | Implemented | Preserve existing serialization and precedence coverage |
| Selected foundational F# chart constructors (H1) | Implemented and committed | No repeat implementation; exclusions are listed below |
| Selected derived F# constructors (H2) | Implemented and committed | No repeat implementation |
| C# direct encoded chart overloads (H3) | Eight existing overloads ported into the split files and regression-tested from C# | Usage documentation remains; further families are in the backlog |
| Encoded dimensions | Shared Dimension support and F#/C# parallel-chart pair conveniences are present and tested | Additional C# encoded-SPLOM coverage remains Next 5 |
| Encoded Sankey flow data | Shared node/link support is present and tested through the existing object-based C# wrapper | Explicit plain/encoded collision coverage remains Next 4 |
| User documentation for encoded arrays | F# documentation is present | C# documentation and the broader documentation review remain Next 6 |

The structural [F# chart split](ChartAPIFileSplit.md) and [C# chart split](CSharpChartApiFileSplit.md) are separate plans. Their completion does not imply C# encoded-array coverage or full plotly.js feature parity.

## API contracts to preserve

- Reuse [EncodedTypedArray.fs](../src/Plotly.NET/CommonAbstractions/EncodedTypedArray.fs) from `Plotly.NET`. Do not introduce another C# payload type, base64 encoder, or serializer.
- Existing factories support float64/float32 and signed/unsigned 8-, 16-, and 32-bit integers, plus the UInt8Clamped tag. Arbitrary strings, objects, decimal, and 64-bit integer arrays are not additional supported dtypes. Do not silently coerce them or promise support for every field accepting `IConvertible`.
- At the trace/object layer, retain the existing plain parameters and parallel optional `...Encoded` parameters. When both set the same property, apply the encoded value last so the final JSON property contains the encoded object. This is property replacement, not duplicate JSON keys.
- At the high-level chart layer, prefer one additional overload per selected chart type, with explicit encoded primary inputs and no alternative plain inputs for those same fields. Preserve existing overloads, names, defaults, and behavior. Do not multiply coordinate tuple/zip variants.
- The original optional `Chart.Scatter` encoded parameters remain public and are used by the explicit overload. The design reset superseded the preferred API pattern; it did not remove that implementation. Do not remove it as part of H3.
- Follow actual F# signatures rather than a generic template: `Scatter(xEncoded, yEncoded, mode, ...)` requires `mode`; `Bar(valuesEncoded, KeysEncoded = ..., ...)` and `Heatmap(zEncoded, xEncoded = ..., yEncoded = ..., ...)` have different optional inputs.
- Encoded support does not make every accompanying argument encoded. Preserve meaningful plain labels, styles, or auxiliary inputs already accepted by the selected F# overload; for example encoded `Bubble` still takes plain `sizes`. Document mixed-input limitations. Any new mixed-input chart design should be addressed in the shared F# API before adding a C#-only variant.
- Multi-dimensional numeric data uses a flat payload with a matching `shape`, such as `[2; 3]` for a 2-by-3 matrix. Test shape retention and flattening order. Do not apply matrix assumptions to one-dimensional histogram samples or RGB/RGBA image pixels.
- For nested objects, put encoding where the values live: `dimensions[i].values`, `node.x`, or `link.value`. Existing chart wrappers can consume such objects without another encoded chart overload. Labeled-dimension pair conveniences are distinct from coordinate zip overloads.

### C# interoperability decisions

- Use required `EncodedTypedArray` arguments for primary encoded data and the existing `Optional<EncodedTypedArray>` / `.ToOption()` convention for optional encoded arguments.
- Verify actual C# factory calls for both one-dimensional and shaped data. The shared factory's optional F# `shape` is represented through `FSharpOption<IEnumerable<int>>`; do not assume C# can omit it as an ordinary optional parameter. Add a small forwarding adapter only if the compiled examples demonstrate that one is needed.
- Remove generic parameters that represented replaced numeric arrays, but retain generic style parameters required by the F# target. Existing candidate wrappers include `Scatter<TextType>`, `Heatmap<TextType>`, and `Bar<TextType, BaseType, WidthType>`. Test calls that omit optional styles with explicit type arguments; do not promise inference from omitted `Text`, `Base`, or `Width` arguments.
- Keep all overloads in the existing per-chart partial file under `src/Plotly.NET.CSharp/ChartAPI/<family>/`. Preserve plain C# call sites and check overload resolution with representative existing calls.

## Completed implementation record

The earlier plan contained contradictory pending/complete notes. The following records the implemented scope and its exceptions without scheduling it again.

| Package | Implemented scope | Commits |
|---|---|---|
| A | Bundle bump, globals/resources, upstream 2.28 scaffold | `62a96500` |
| B | Scatter metadata and error arrays | `43ff9869` |
| C | Bar/Funnel/Waterfall trace fields | `9c7d1bdd` |
| D | Distribution, finance, and SPLOM trace fields | `f70dea0b` |
| E | Matrix trace fields; Image metadata only | `97de944e` |
| F | 3D coordinates, vectors, topology, values, and metadata | `343e31e4` |
| G1 | Polar, geo/mapbox, ternary, and Smith trace fields | `81bd99fd` |
| G2 | Carpet/domain trace fields; not nested Sankey flow arrays | `8a9fcb64` |
| H1-A | Explicit `Scatter(xEncoded, yEncoded, mode, ...)` overload | `73965294` |
| H1-B | Point, Line, Spline, Bubble, Range, Area, SplineArea, StackedArea | `b5767af5` |
| H1-C | Bar, Funnel, Waterfall roots under the reset design, including Waterfall width support | `02df1fad` |
| H1-D | Histogram, BoxPlot, Violin, OHLC, Candlestick | `4913748a` |
| H1-D-Splom | Encoded Dimension values and `Splom(keyValuesEncoded = ...)` | `ed86f94d` |
| H1-E | Histogram2D, Histogram2DContour, Heatmap, Contour | `62e9161c` |
| H1-F | Scatter3D, Surface, Mesh3D, Cone, StreamTube, Volume, IsoSurface | `045a2b63` |
| H1-G | Selected subplot/domain roots listed below | `1d8e9e54`, `73965294` |
| H2 | Selected derived constructors listed below | `c9446e58` |

`37006fd9` and `5edcbb17` record the earlier optional-parameter prototype. Later commits established the preferred explicit-overload design.

H1-G covers `BarPolar`, `Pie`, `FunnelArea`, `Sunburst`, `Treemap`, `Icicle`, `ChoroplethMap`, `ChoroplethMapbox`, `DensityMapbox`, `ScatterPolar`, `ScatterGeo`, `ScatterMapbox`, `ScatterTernary`, `ScatterSmith`, `Carpet`, `ScatterCarpet`, and `ContourCarpet`.

H2 adds `StackedBar`, `Column`, `StackedColumn`, `PointDensity`, `StackedFunnel`; `Point3D`, `Line3D`, `Bubble3D`; carpet Point/Line/Spline/Bubble; `Doughnut`; geo/mapbox Point/Line/Bubble; polar Point/Line/Spline/Bubble; Smith and ternary Point/Line/Bubble. H1-B already covers the earlier scatter/area conveniences.

Encoded dimensions are implemented in [Dimensions.fs](../src/Plotly.NET/Traces/ObjectAbstractions/Dimensions.fs), and the F# SPLOM overload is in [Chart2D_Splom.fs](../src/Plotly.NET/ChartAPI/Chart2D/Chart2D_Splom.fs). Existing `Splom(dimensions, ...)`, `ParallelCoord(dimensions, ...)`, and `ParallelCategories(dimensions, ...)` can carry encoded dimension values, including through their existing C# wrappers. A missing pair convenience is not a missing encoding capability.

Historical verification recorded for H1/H2: `runTestsCore`, 933 passing. The full clean `runTestsAll` pipeline passed for refactor merge `51c744b0` on 2026-09-10: core tests 945 passed, C# tests 105 passed, and ImageExportTests 6 passed with 2 already marked pending. Those C# tests covered the plain wrapper surface; the current integration adds explicit regression coverage for the moved encoded and domain additions.

Verification for the resolved `dev` → `plotly2.28` merge on 2026-09-10: full clean `./build.cmd runTestsAll` passed with **958 core tests, 123 C# tests, and 6 ImageExportTests passed / 2 already pending**. The 18 new C# cases in `htmlcodegen/UpstreamFeatures/PlotlyJS228Tests.cs` cover all 11 moved additions and the existing nested-object Sankey path. Expected data/layout came from actual C# chart rendering through the canonical baseline harness, which was restored afterwards. A read-only comparison confirmed preservation of all 99 original branch C# methods and all 88 `dev` methods. The resolved F# console was also type-checked with FSI. No new browser-rendering verification is claimed by this merge.

## Implementations retained during integration

The following commits are already ancestors of the `plotly2.28` branch. The merge retains their implementations while adopting the C# file split from `dev`; do not reimplement or cherry-pick them again.

| Existing commit | Retained work | Integration concern |
|---|---|---|
| `f1e362a4` | Eight C# encoded overloads: Scatter, Bar, StackedBar, Column, StackedColumn, Heatmap, Histogram2D, Scatter3D | Moved out of the removed umbrella files into current partial files, preserving signatures and forwarding calls |
| `d91fe84a` | Shared Sankey node/link encoded fields; also node alignment | Review nested-field behavior; node alignment is a separate upstream feature, not a prerequisite for encoding |
| `1f775369` | F# ParallelCoord/ParallelCategories `keyValuesEncoded` conveniences | Reuse existing Dimension encoding; these are additive conveniences |
| `fd862365` | Matching C# parallel-chart pair overloads and a plain Sankey helper with NodeAlign | Parallel wrappers depend on the shared F# conveniences; the plain Sankey helper is not an encoded overload |
| `263d7518` | Encoded-array documentation and Sankey examples | Adapt to selected integrated APIs and add compiled C# examples |

The accompanying [2.28 integration status](PlotlyJS_2_28_Parity.md) records the same selected C# scope. The original feature commits did not add C# encoded tests; these are part of the merge validation. Neither a successful wrapper build nor F# tests prove C# forwarding behavior across all families.

Keep the removed umbrella files deleted and all overloads grouped in their per-chart files. Unrelated existing changes on PR #502 remain outside the conflict-resolution scope.

## Next commit packages

Each package includes implementation and its tests in the same independently buildable commit. Mark it done only after integration and verification on the working branch. The packages below define an initial C# milestone plus separate shared-core/convenience follow-ups; they do not require mirroring every F# overload.

### Next 1: C# Scatter and factory interoperability [done in integration merge]

- Adapt the encoded `Scatter` overload from `f1e362a4` into `ChartAPI/Chart2D/Scatter.cs`.
- Compile C# examples creating encoded arrays with the shared factories, including 1D data without a declared shape (passing `None` explicitly if C# requires it) and shaped data. Resolve factory/generic ergonomics using the rules above before expanding the surface.
- Add C# tests calling the C# wrapper with encoded coordinates, an omitted optional style, and a nondefault style. Assert dtype/base64 preservation and retain a representative plain call to verify overload resolution.
- Use `UseDefaults: false`; the integration regressions live in `htmlcodegen/UpstreamFeatures/PlotlyJS228Tests.cs` alongside the existing per-chart plain tests.
- Verify with `RunCSharpTestsFast`.

### Next 2: C# bar family [done in integration merge]

- Adapt `Bar`, `StackedBar`, `Column`, and `StackedColumn` from `f1e362a4` into their existing files.
- Add C# serialization tests for values/key forwarding, absent optional keys, an encoded width option where exposed, orientation, and stacked layout behavior. Exercise the remaining generic style arguments explicitly.
- Keep the plain wrappers and their current tests unchanged.
- Verify with `RunCSharpTestsFast`.

### Next 3: C# matrix and 3D representatives [done in integration merge]

- Adapt `Heatmap`, `Histogram2D`, and `Scatter3D` from `f1e362a4`.
- Add a non-square shaped heatmap test, histogram sample/optional aggregation tests, and a 3D coordinate forwarding test. Check both omitted and supplied optional encoded inputs where they change behavior.
- Verify with `RunCSharpTestsFast`.

Next 1–3 cover exactly the eight existing C# candidate methods. This is the initial H3 implementation milestone, not full F# chart parity. Additional roots are tracked separately below.

### Next 4: Shared Sankey node/link support [integrated; precedence coverage pending]

Integration retains the shared implementation and adds C# coverage for node positions and link source/target/value. Existing F# tests also cover encoded metadata. The explicit plain/encoded collision tests below remain a follow-up; encoded-only serialization tests do not establish precedence.

- Review and adapt the encoded portion of `d91fe84a` in `Traces/ObjectAbstractions/Sankey.fs`.
- Cover the meaningful nested numeric inputs first: node positions and link source/target/value, plus supported metadata fields. Preserve existing plain inputs and encoded precedence.
- Add shared-core nested serialization/precedence tests and an upstream fixture/assertion pair. Numeric encoding must not be presented as arbitrary string-label or color-string encoding.
- Add a C# test using the existing `Chart.Sankey(nodes, links, ...)` wrapper with encoded nested objects. Add another chart overload only if that test demonstrates a missing capability.
- Keep the node-alignment API change separate from the encoded-array completion criteria.
- Verify with `RunTestsCoreFast` and `RunCSharpTestsFast`.

### Next 5: Parallel dimension conveniences [integrated; extra SPLOM coverage pending]

Integration retains both pair conveniences and adds C# serialization/option-forwarding tests. The additional C# encoded-SPLOM test below remains a follow-up; no new SPLOM wrapper is needed.

- Adapt shared F# pair constructors from `1f775369`, then matching C# wrappers from `fd862365` in the existing `ParallelCoord.cs` and `ParallelCategories.cs` files.
- Use the candidate C# `IEnumerable<(string, EncodedTypedArray)>` shape and delegate to the shared Dimension-based implementation.
- Add F# and C# tests for string dimension labels with encoded numeric values in `dimensions[i].values`, preserving options and existing dimensions-based calls.
- Exercise C# `Splom(dimensions, ...)` with encoded dimensions as well; a new SPLOM pair overload is optional, not required to enable encoded values.
- Verify with `RunTestsCoreFast` and `RunCSharpTestsFast`.

### Next 6: Usage documentation and completion record [pending]

- Adapt `docs/general/encoded-arrays.fsx` from `263d7518` to APIs actually integrated on this branch.
- Explain the shared representation, numeric dtype limits, matrix shape, plain/encoded precedence at the object layer, and the distinction between direct wrappers and nested-object support.
- Include F# and C# examples for a 1D chart and shaped matrix; mirror executable C# examples in tests so the documented factory and generic-call syntax is checked.
- Document any mixed categorical/numeric input limitations and the selected C# coverage. Avoid claiming all-chart parity or guaranteed performance gains.
- Update applicable release notes with the actual delivered scope and this plan with commits/test results. Record Next 4 and Next 5 independently if they have not been integrated.
- Verify through the FAKE build entry points, including the full clean `./build.cmd runTestsAll` before committing changes; run the docs build target if executable docs are changed.

## Further C# coverage backlog

These are additional family-sized packages, not prerequisites for calling the initial eight-wrapper milestone complete. Each selected package must include C# compilation and serialization tests before it is marked implemented.

| Candidate package | Constructors / behavior |
|---|---|
| Distribution and finance roots | Histogram, BoxPlot, Violin, OHLC, Candlestick |
| Other 2D roots | Funnel, Waterfall, Histogram2DContour, Contour |
| Other 3D roots | Surface, Mesh3D, Cone, StreamTube, Volume, IsoSurface |
| Geo and mapbox roots | ScatterGeo, ScatterMapbox, ChoroplethMap, ChoroplethMapbox, DensityMapbox |
| Other subplot roots | ScatterPolar, BarPolar, ScatterTernary, ScatterSmith |
| Domain and carpet roots | Pie, FunnelArea, Sunburst, Treemap, Icicle, Carpet, ScatterCarpet, ContourCarpet |
| Derived conveniences | Select useful existing H1-B/H2 helpers after their roots; do not automatically replicate every plain overload |

Prefer foundational roots before additional conveniences. Update this table with the chosen scope and commit references as packages are selected. Do not mark H3 as full parity while these gaps remain.

## Deliberate exclusions and limits

- `Image`: encoded trace metadata exists, but no `ZEncoded` RGB/RGBA pixel API or high-level encoded Image overload is planned here.
- `Pareto`, `Residual`, and `AnnotatedHeatmap`: intentionally excluded from direct encoded overloads because their in-F# computations need accessible input values. A separate design would be needed for opaque encoded payloads.
- `Table` and `Indicator`: no dedicated encoded root is required by this plan; existing trace metadata support is not equivalent to an encoded primary-data path.
- Parallel pair conveniences are additive; existing Dimension-based support remains useful independently of Next 5.
- String/object encoding, new numeric conversions, shape-validation redesign, and encoding-performance benchmarks are separate work. Preserve current behavior and document limits in this pass.
- Sankey alignment, virtual-WebGL, and other plotly.js 2.28 features are outside encoded-array completion criteria.

## Verification and completion criteria

For each implementation package:

- Test through the public C# wrapper when checking C# behavior. Reuse shared fixtures where practical; do not count an F# test as a C# wrapper test.
- Check stable JSON sections, including nested fields and nondefault options, rather than full HTML snapshots. Generate new markup expectations with [the canonical baseline harness](../tools/chart-baseline-generation/generate-chart-markup.fsx); do not invent base64 or serialized expectations.
- Set `UseDefaults = false`. When overriding the JS reference, replace display options with `Chart.withDisplayOptions` rather than merging defaults.
- Run the smallest matching FAKE target during iteration (`RunCSharpTestsFast`, and `RunTestsCoreFast` for shared changes). Run full `./build.cmd runTestsAll` before committing changes and record results with the tested commit.
- For shared runtime behavior, use the existing upstream [2.28 fixtures](../tests/Common/FSharpTestBase/TestCharts/UpstreamFeatures/2.28.fs) and [tests](../tests/CoreTests/CoreTests/UpstreamFeatures/2.28.fs). Serialization assertions prove the emitted representation, not browser rendering; smoke-test representative 1D, non-square matrix, and nested charts with the bundled runtime when integrating those paths. Record that evidence separately and avoid implying all trace fields were browser-validated.

The initial H3 milestone is complete when the eight selected wrappers have C# tests, factory call syntax is verified, existing plain calls still compile, usage docs match the implementation, and the required verification is recorded. Shared Sankey support, parallel conveniences, and further C# families each retain their own status; none is implicitly completed by the C# file split or by this plan revision.
