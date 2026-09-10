# plotly.js 2.28.0 integration status

Updated on 2026-09-10 for the `dev` → `plotly2.28` integration (`81c30c61`, after C# refactor PR #503) and the agreed completion pass for PR #502.

The branch bundles plotly.js 2.28.0 and implements shared encoded-array support, Sankey node alignment, and selected F# and C# chart conveniences. The C# additions cover a selected subset of the F# surface. This document records that scope; the remaining encoded-array work is tracked in [EncodedArraySupport.md](EncodedArraySupport.md).

Upstream context: [plotly.js 2.28.0 release](https://github.com/plotly/plotly.js/releases/tag/v2.28.0), [encoded typed arrays](https://github.com/plotly/plotly.js/pull/5230), [Sankey alignment](https://github.com/plotly/plotly.js/pull/6800), and [Virtual-WebGL integration](https://github.com/plotly/plotly.js/pull/6784).

## Delivered scope

| Feature | Implementation | Verification / remaining work |
|---|---|---|
| Bundled runtime | `plotly-2.28.0.min.js`, introduced in `62a96500` | Retained by this merge |
| Shared encoded arrays | `EncodedTypedArray`, serialization, selected trace fields and F# chart constructors | Existing core coverage; exclusions and later families are listed in the encoded-array plan |
| C# direct encoded chart overloads | Scatter, Bar, StackedBar, Column, StackedColumn, Heatmap, Histogram2D, Scatter3D | Moved into split files; new C# regression tests are part of merge validation |
| Parallel dimension pairs | F# and C# ParallelCoord / ParallelCategories conveniences | Existing F# coverage plus new C# regression tests |
| Encoded Sankey node/link data | Shared nested objects, consumed by existing F# and C# object-based Sankey wrappers | Existing F# coverage plus a new C# nested-data regression test |
| Sankey node alignment | StyleParam, SankeyNodes, F# convenience and plain C# convenience | Existing F# coverage plus a new C# forwarding regression test |
| Virtual-WebGL loading | Existing display options load Virtual-WebGL before plotly.js | Four WebGL charts rendered in the browser smoke check below; no dedicated API added |
| Documentation | F# examples, compiled C# examples, numeric/shape limits, selected scope, and Virtual-WebGL loading | Guide and both package release notes updated; documentation build and strict reevaluation passed |

## Resolution of the C# file-split conflicts

The deleted `Chart2D.cs`, `Chart3D.cs`, and `ChartDomain.cs` umbrella files remain deleted. Their additions from PR #502 now live beside the existing plain overloads:

- `src/Plotly.NET.CSharp/ChartAPI/Chart2D/{Scatter,Bar,StackedBar,Column,StackedColumn,Heatmap,Histogram2D}.cs`
- `src/Plotly.NET.CSharp/ChartAPI/Chart3D/Scatter3D.cs`
- `src/Plotly.NET.CSharp/ChartAPI/ChartDomain/{ParallelCoord,ParallelCategories,Sankey}.cs`

The public signatures, generic constraints, documentation, and forwarding calls from `f1e362a4` and `fd862365` are preserved. The domain files retain the LINQ import needed to convert C# value tuples to F# tuples. The existing plain Sankey test supplies explicit defaults for the new F# optional parameters so it compiles against the merged core.

The F# console retains the encoded heatmap from `plotly2.28` and the Venn/UpSet examples from `dev`.

## Shared domain support

`Traces/ObjectAbstractions/Sankey.fs` implements the following encoded options in node/link initialization and styling:

- Nodes: `ColorEncoded`, `CustomDataEncoded`, `XEncoded`, `YEncoded`.
- Links: `ColorEncoded`, `CustomDataEncoded`, `SourceEncoded`, `TargetEncoded`, `ValueEncoded`.

Labels remain plain strings. There is no `LabelEncoded` option. Existing `Chart.Sankey(nodes, links, ...)` APIs accept these objects, including the C# wrapper; a separate encoded Sankey overload is unnecessary. The new plain C# label/link convenience exposes `NodeAlign`, which is independent of encoded data support.

Parallel pair constructors reuse `Dimension.initParallel(ValuesEncoded = ...)`. Existing dimensions-based APIs, including SPLOM, can already carry encoded values. The pair conveniences are additive.

## Completion pass

The follow-up to the refactor merge adds two shared Sankey precedence cases and three C# cases (documented Scatter/Heatmap and existing SPLOM with encoded dimensions). It corrects the shape guidance for histogram/volume samples, supplies C# factory examples, documents script order, and removes all-chart/performance overclaims from the release notes.

Additional direct C# wrappers remain a separate milestone in [EncodedArraySupport.md](EncodedArraySupport.md). Histogram, other 3D roots, and map/polar/carpet families are not included in the selected eight-wrapper scope. No new wrapper families were added in this completion pass.

## Merge verification

Full clean `./build.cmd runTestsAll` passed on 2026-09-10 for the resolved merge: **958 core tests, 123 C# tests, and 6 ImageExportTests passed / 2 already pending**. The 18 new C# cases cover the 11 moved additions and the existing nested-object Sankey path; data/layout baselines were generated through the canonical harness and checked in the rendered HTML. The harness was restored after generation.

A read-only comparison confirmed that all 99 original `plotly2.28` C# methods and documentation were retained, including unchanged signatures and bodies for all 88 `dev` methods. The resolved F# console was type-checked with FSI. At that point, nested Sankey precedence, C# encoded-SPLOM tests, and browser checks were still follow-ups; the completion pass below adds that evidence.

## Browser verification, 2026-09-10

Generated actual charts through the canonical baseline harness and rendered complete documents with `GenericChart.toEmbeddedHTML`. The harness was restored after generation. Checks used headless Chrome **152.0.7977.83** on Windows with SwiftShader (`--use-angle=swiftshader --enable-unsafe-swiftshader`), and confirmed `Plotly.version === "2.28.0"` in every page. DOM/calculated-data assertions and screenshots were checked together so a WebGL fallback message could not count as successful rendering.

| Case | Observed result |
|---|---|
| Encoded C# Scatter documentation example | Three visible markers; x `[0,1,2]`, y `[1.5,4.5,2.5]` decoded correctly |
| Encoded C# Heatmap documentation example | Six cells in two rows and three columns; z `[[1,2,3],[4,5,6]]`, x `[10,20,30]`, y `[100,200]`; reversed y-axis preserved |
| Encoded Sankey nested data | Three visible nodes and two links; source `[0,1]`, target `[2,2]`, value `[8,4]`; encoded node positions and right alignment preserved |
| Existing C# SPLOM wrapper | Two labeled dimensions decoded correctly; WebGL points visible, upper half hidden, diagonal retained |
| Virtual-WebGL loading | The documented display-option pattern loaded each script once, in order; four encoded ScatterGL charts rendered on one page and each exported a PNG successfully; virtual context `dispose()` was present and no WebGL fallback was displayed |

Virtual-WebGL used the upstream-tested WebGL 1 source from [v1.0.6](https://github.com/greggman/virtual-webgl/blob/v1.0.6/src/virtual-webgl.js), tag commit `858e3980299a64027e0f3614075feedaa31376de`. Both scripts were served locally; the other pages embedded the bundled plotly.js directly. There were no uncaught JavaScript exceptions. Virtual-WebGL logged warnings for newer context properties it does not implement; they did not prevent these charts from rendering.

This is representative runtime evidence, not validation of every encoded field, all browsers/GPUs, maximum WebGL context counts, or performance. In particular, the numeric Sankey color/metadata collision fixtures prove serialization precedence; the browser Sankey case exercises positions and flow values with ordinary labels/colors.

## Completion verification

Both incremental `./build.cmd RunTestsAllFast` and final full clean `./build.cmd runTestsAll` passed: **960 core, 126 C#, and 6 ImageExport tests passed / 2 already pending**. The agreed completion pass is done; the broader direct C# wrapper backlog remains a separate milestone.

`./build.cmd BuildDocs` completed. Its first pass exposed an existing installation-example placeholder diagnostic in `docs/index.fsx`. Explicit language directives now keep those examples and the new C# snippets out of F# reference resolution. Both edited pages were then forced to regenerate with `dotnet fsdocs build --eval --strict --properties Configuration=Release --parameters fsdocs-package-version 6.0.0` against the FAKE-built assemblies; this passed without errors. Rendered HTML was checked for the expected guide content and for hidden formatting directives.
