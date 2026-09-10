# plotly.js 2.28.0 integration status

Updated on 2026-09-10 for the merge of `dev` at `41f2f88c` (C# refactor PR #503) into `plotly2.28` at `fd862365` (PR #502).

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
| Virtual-WebGL loading | Existing `DisplayOptions.AdditionalHeadTags` can inject a script | No dedicated wrapper API added; no integration test recorded here |
| Documentation | F# encoded-array page and Sankey examples | C# examples and the broader scope/limitations review remain pending |

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

## Remaining planned work

1. Finish the documentation milestone in [EncodedArraySupport.md](EncodedArraySupport.md): tested C# factory syntax and chart examples, numeric/shape limits, plain/encoded precedence, and the exact selected wrapper coverage.
2. Add further direct C# wrappers only in selected family-sized packages with C# compilation and serialization tests. Histogram, other 3D roots, and map/polar/carpet families are not covered merely because the initial eight overloads are present.
3. Record representative browser smoke tests separately from serialization tests. Passing JSON/HTML assertions does not establish rendering support for every encoded field.

These follow-ups are distinct from preserving PR #502's existing behavior through the C# refactor merge.

## Merge verification

Full clean `./build.cmd runTestsAll` passed on 2026-09-10 for the resolved merge: **958 core tests, 123 C# tests, and 6 ImageExportTests passed / 2 already pending**. The 18 new C# cases cover the 11 moved additions and the existing nested-object Sankey path; data/layout baselines were generated through the canonical harness and checked in the rendered HTML. The harness was restored after generation.

A read-only comparison confirmed that all 99 original `plotly2.28` C# methods and documentation are retained, including unchanged signatures and bodies for all 88 `dev` methods. The resolved F# console was type-checked with FSI. These checks establish merge preservation and emitted markup, without claiming new browser-rendering coverage. Explicit nested Sankey precedence tests and an additional C# encoded-SPLOM test remain follow-ups in the encoded-array plan.
