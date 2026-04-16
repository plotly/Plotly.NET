# Chart API File Split Plan

## Background

The per-family files under [src/Plotly.NET/ChartAPI/](src/Plotly.NET/ChartAPI/) have grown unwieldy:

| File | Lines |
|---|---:|
| [Chart2D.fs](src/Plotly.NET/ChartAPI/Chart2D.fs) | 9234 |
| [Chart.fs](src/Plotly.NET/ChartAPI/Chart.fs) | 3713 |
| [ChartMap.fs](src/Plotly.NET/ChartAPI/ChartMap.fs) | 2930 |
| [ChartDomain.fs](src/Plotly.NET/ChartAPI/ChartDomain.fs) | 2701 |
| [Chart3D.fs](src/Plotly.NET/ChartAPI/Chart3D.fs) | 2482 |
| [ChartCarpet.fs](src/Plotly.NET/ChartAPI/ChartCarpet.fs) | 1765 |
| [ChartPolar.fs](src/Plotly.NET/ChartAPI/ChartPolar.fs) | 1519 |
| [ChartTernary.fs](src/Plotly.NET/ChartAPI/ChartTernary.fs) | 1022 |
| [ChartSmith.fs](src/Plotly.NET/ChartAPI/ChartSmith.fs) | 995 |

`Chart2D.fs` alone holds ~25 chart-type families (`Scatter`, `Line`, `Point`, `Bubble`, `Bar`, `Histogram`, `BoxPlot`, `Violin`, `Heatmap`, `OHLC`, `Candlestick`, `Splom`, ...), each with 3–4 overloads averaging ~100 lines due primarily to long XML doc blocks and wide optional parameter lists. The tiny internal helpers at the top of the file are not the main source of bloat.

This matters for the refactor choice: simply offloading implementation bodies into helper modules would slightly reduce per-member complexity, but it would leave the bulk of the 9k-line file intact because the docs and constructor signatures would still live in `Chart2D.fs`.

F# has no partial classes, so we cannot simply split `type Chart` across files the way [src/Plotly.NET.CSharp/ChartAPI/](src/Plotly.NET.CSharp/ChartAPI/) does with `public static partial class Chart`.

## Mechanism already in the codebase

The current layout already does a partial-class-like split across families. Each family file defines its own `[<AutoOpen>] module` containing an `[<Extension>] type Chart` whose members are all marked `[<Extension>]`. Example from [Chart2D.fs:13-17](src/Plotly.NET/ChartAPI/Chart2D.fs#L13-L17):

```fsharp
[<AutoOpen>]
module Chart2D =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member Scatter(...) = ...
```

This compiles to a CLR class `Plotly.NET.Chart2D+Chart` carrying static methods with `[ExtensionAttribute]`. When `module Chart2D` is auto-opened, those methods are resolved by the F# compiler as extension members on the base `Plotly.NET.Chart` type from [Chart.fs](src/Plotly.NET/ChartAPI/Chart.fs), so user code keeps calling `Chart.Scatter(...)` uniformly regardless of which file the overload lives in.

There are already 8 `type Chart =` declarations coexisting this way (Chart2D, Chart3D, ChartCarpet, ChartDomain, ChartMap, ChartPolar, ChartSmith, ChartTernary). The proposal is to apply the same mechanism at finer granularity across the large extension-based Chart API families while keeping the base `Chart.fs` type out of scope for this refactor.

## Proposed layout

Split each large extension-based Chart API file into one F# file per chart-type group. The public API surface stays byte-identical; only the physical location of each `static member` changes.

```
src/Plotly.NET/ChartAPI/
    Chart.fs                         // base type Chart (unchanged)
    Chart2D/
        Chart2D_Scatter.fs           // Scatter / Point / Line / Spline / Bubble / Range
        Chart2D_Area.fs              // Area / SplineArea / StackedArea
        Chart2D_Bar.fs               // Bar / StackedBar / Column / StackedColumn
        Chart2D_Funnel.fs            // Funnel / StackedFunnel / Waterfall
        Chart2D_Histogram.fs         // Histogram / Histogram2D / Histogram2DContour
        Chart2D_Distribution.fs      // BoxPlot / Violin
        Chart2D_Heatmap.fs           // Heatmap / AnnotatedHeatmap / Image / Contour
        Chart2D_Finance.fs           // OHLC / Candlestick
        Chart2D_Splom.fs             // Splom / PointDensity
        Chart2D_Statistical.fs       // Pareto / Residual
    Chart3D/
        Chart3D_Scatter.fs           // Scatter3D / Point3D / Line3D / Bubble3D
        Chart3D_Surface.fs           // Surface / Mesh3D
        Chart3D_VectorField.fs       // Cone / StreamTube
        Chart3D_Volume.fs            // Volume / IsoSurface
    ChartPolar/
        ChartPolar_Scatter.fs        // ScatterPolar / PointPolar / LinePolar / SplinePolar / BubblePolar
        ChartPolar_Bar.fs            // BarPolar
    ChartMap/
        ChartMap_Geo.fs              // ChoroplethMap / ScatterGeo / PointGeo / LineGeo / BubbleGeo
        ChartMap_Mapbox.fs           // ScatterMapbox / PointMapbox / LineMapbox / BubbleMapbox
        ChartMap_Density.fs          // ChoroplethMapbox / DensityMapbox
    ChartTernary/
        ChartTernary_Scatter.fs      // ScatterTernary / PointTernary / LineTernary / BubbleTernary
    ChartCarpet/
        ChartCarpet_Base.fs          // Carpet
        ChartCarpet_Scatter.fs       // ScatterCarpet / PointCarpet / LineCarpet / SplineCarpet / BubbleCarpet
        ChartCarpet_Contour.fs       // ContourCarpet
    ChartDomain/
        ChartDomain_Pie.fs           // Pie / Doughnut / FunnelArea
        ChartDomain_Hierarchy.fs     // Sunburst / Treemap
        ChartDomain_Relations.fs     // ParallelCoord / ParallelCategories / Sankey
        ChartDomain_Table.fs         // Table / Indicator
        ChartDomain_Icicle.fs        // Icicle
    ChartSmith/
        ChartSmith_Scatter.fs        // ScatterSmith / PointSmith / LineSmith / BubbleSmith
    Chart2D.fs                       // already removed
    Chart3D.fs                       // trimmed remainder or deleted at the end
    ChartPolar.fs                    // trimmed remainder or deleted at the end
    ChartMap.fs                      // trimmed remainder or deleted at the end
    ChartTernary.fs                  // trimmed remainder or deleted at the end
    ChartCarpet.fs                   // trimmed remainder or deleted at the end
    ChartDomain.fs                   // trimmed remainder or deleted at the end
    ChartSmith.fs                    // trimmed remainder or deleted at the end
```

Each new file follows the established pattern:

```fsharp
namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open System
open System.Runtime.CompilerServices

[<AutoOpen>]
module Chart2D_Scatter =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member Scatter(...) = ...
        [<Extension>]
        static member Point(...) = ...
        // etc.
```

Key rules:

- Group overloads of the same `Chart.Foo` member into the **same** file. Never split overloads of one member name across files — F# overload resolution only works on members declared inside a single `type` block.
- Group closely related members that share private helpers into the same file (e.g. `Scatter`/`Point`/`Line`/`Bubble` all build the same `Marker`/`Line` objects and call the same `renderScatterTrace` helper).
- Do **not** introduce a shared helper file up front unless a second split actually needs one. The current helpers are tiny; extract them only when the move would otherwise duplicate code or block file ordering.
- File-level `AutoOpen` module names must be unique (`Chart2D_Scatter`, `Chart2D_Bar`, ...) so auto-open does not collide and each container `Chart` type gets a distinct CLR name.

## Rejected alternatives

### Alt A: Body offloading per chart type

Keep `Chart2D.fs` as-is but move each overload body into a per-chart-type implementation module (`module Chart2DImpl.ScatterImpl`) and forward from the thin `static member`. Rejected:

- `Chart2D.fs` stays ~6–7k lines as a forwarder shell because XML docs and parameter lists dominate the bulk, not bodies.
- Adds an indirection hop and a parallel naming surface (`ScatterImpl.create`) that the rest of the codebase does not use.
- It may still be a reasonable follow-up cleanup inside an extracted file, but it does not solve the actual file-size problem.

### Alt B: Parameter records to collapse overloads

Introduce e.g. a `ScatterArgs` record and reduce the 3–4 overloads per chart to a single implementation. Rejected:

- Changes API surface and migration risk is high.
- Orthogonal to the file-size problem — can be considered later as a separate refactor.

### Alt C: Source generation from the plotly.js schema

Generate the chart API from upstream schema. Rejected for this plan:

- Massive scope; affects every `Trace*Style` and docs toolchain.
- Worth revisiting long-term, but not a prerequisite for fixing file size today.

### Alt D: Do nothing

Agent tools can already chunk large files, and the code works. Rejected because:

- `Chart2D.fs` is the dominant context-cost file for any task touching 2D charts.
- Human navigation (jump-to-member, diff review) is noticeably slow on 9k-line files.

## Risks and verification

- **Overload resolution across files.** F# cannot overload across separate `type Chart` declarations. Mitigation: group all overloads of one member name into one file (enforced by the rule above). The PoC commit (Chart2D_Scatter) exercises this: `Chart.Scatter` has 4 overloads and must compile and resolve identically.
- **Name collision across auto-open modules.** Two files must not define the same container module name. Mitigation: one consistent naming scheme (`<Family>_<Group>`).
- **C# consumers.** The wrapper files under [src/Plotly.NET.CSharp/ChartAPI/](src/Plotly.NET.CSharp/ChartAPI/) call the F# CLR containers directly. After splitting, those calls must be retargeted to the new container names (`Plotly.NET.Chart3D_Scatter.Chart.*`, `Plotly.NET.ChartMap_Geo.Chart.*`, etc.). Verify by running `./build.cmd runTestsCore`, which already covers C# interoperability.
- **Internal visibility.** If a later split needs shared helpers, they must remain reachable from every family file. Mitigation: only extract helpers when needed, and keep them `internal` in a shared file ordered before dependents.
- **Documentation and fsdocs.** [docs/](docs/) references the public API by member name, not file path — unaffected. Verify a docs build locally after the PoC.
- **.fsproj compile order.** F# is order-sensitive. Mitigation: explicit `<Compile Include=...>` entries in [Plotly.NET.fsproj](src/Plotly.NET/Plotly.NET.fsproj), with any shared helper file placed before dependents only if such a file becomes necessary.
- **Refactor scope creep.** `Chart2D.fs` was the obvious first target, but expanding across the remaining family files increases churn. Mitigation: keep `Chart.fs` explicitly out of scope, preserve family-by-family grouping, and verify with `runTestsCore` after each wave.

## Commit packages

Each commit is independently buildable and testable. Follow the repo entry points (`./build.cmd` or `./build.sh`), with the relevant test target running after each commit.

### Commit 1: PoC — split Scatter family out of Chart2D.fs [done]

Scope:

- Create `src/Plotly.NET/ChartAPI/Chart2D/`.
- Add `Chart2D_Scatter.fs` in `src/Plotly.NET/ChartAPI/Chart2D/`, containing all overloads of `Scatter`, `Point`, `Line`, `Spline`, `Bubble`, `Range`.
- Remove the migrated members from `Chart2D.fs`.
- Keep `renderScatterTrace` in the moved file unless extracting it is required by file ordering or reuse.
- Update `Plotly.NET.fsproj` `<Compile>` ordering: the new file goes **before** the trimmed `Chart2D.fs`.
- Run `./build.cmd`, then `./build.cmd runTestsCore` to confirm no regression.
- If all green, this PoC confirms the mechanism and unblocks the rest of the plan.

Exit criteria:

- Build green and core tests green.
- `Chart2D.fs` shrinks substantially.
- No intended public API diff.

Implementation notes:

- Created `src/Plotly.NET/ChartAPI/Chart2D/Chart2D_Scatter.fs` and moved `renderScatterTrace` plus the `Scatter` / `Point` / `Line` / `Spline` / `Bubble` / `Range` overload groups there.
- Trimmed `src/Plotly.NET/ChartAPI/Chart2D.fs` so it retains `renderHeatmapTrace` and starts with `Area`.
- Added the new file to `src/Plotly.NET/Plotly.NET.fsproj` ahead of `Chart2D.fs`.
- Updated `src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs` so the wrapper calls the new CLR container for the moved members (`Plotly.NET.Chart2D_Scatter.Chart`).
- Verified with `./build.cmd runTestsCore` successfully: build passed and 933/933 core tests passed.

### Commit 2: Area + Bar + Funnel families [done]

Scope:

- `Chart2D_Area.fs` — Area / SplineArea / StackedArea.
- `Chart2D_Bar.fs` — Bar / StackedBar / Column / StackedColumn.
- `Chart2D_Funnel.fs` — Funnel / StackedFunnel / Waterfall.
- Remove migrated members from `Chart2D.fs`; update fsproj.

Implementation notes:

- Added `Chart2D_Area.fs`, `Chart2D_Bar.fs`, and `Chart2D_Funnel.fs` under `src/Plotly.NET/ChartAPI/Chart2D/`.
- Retargeted the matching C# wrapper calls in `src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs`.
- Verified with `./build.cmd runTestsCore` successfully.

### Commit 3: Histogram + Distribution families [done]

Scope:

- `Chart2D_Histogram.fs` — Histogram / Histogram2D / Histogram2DContour.
- `Chart2D_Distribution.fs` — BoxPlot / Violin.
- Remove from `Chart2D.fs`; update fsproj.

Implementation notes:

- Added `Chart2D_Histogram.fs` and `Chart2D_Distribution.fs`.
- Retargeted the matching C# wrapper calls in `src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs`.
- Verified with `./build.cmd runTestsCore` successfully as part of the full Chart2D split.

### Commit 4: Heatmap + Finance + Splom + Statistical families [done]

Scope:

- `Chart2D_Heatmap.fs` — Heatmap / AnnotatedHeatmap / Image / Contour.
- `Chart2D_Finance.fs` — OHLC / Candlestick.
- `Chart2D_Splom.fs` — Splom / PointDensity.
- `Chart2D_Statistical.fs` — Pareto / Residual.
- `Chart2D.fs` was deleted after the constructor families were fully migrated; the split now lives entirely under `ChartAPI/Chart2D/`.

Implementation notes:

- Added `Chart2D_Heatmap.fs`, `Chart2D_Finance.fs`, `Chart2D_Splom.fs`, and `Chart2D_Statistical.fs`.
- Moved `renderHeatmapTrace` into `Chart2D_Heatmap.fs`.
- Retargeted the remaining C# wrapper calls in `src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs`.
- Removed `src/Plotly.NET/ChartAPI/Chart2D.fs` and its `Plotly.NET.fsproj` entry once the transitional placeholder was no longer needed.
- Verified with `./build.cmd runTestsCore` successfully: build passed and 933/933 core tests passed.

### Commit 5: Chart3D + ChartPolar + ChartTernary + ChartSmith families [done]

Scope:

- `Chart3D_Scatter.fs` — Scatter3D / Point3D / Line3D / Bubble3D.
- `Chart3D_Surface.fs` — Surface / Mesh3D.
- `Chart3D_VectorField.fs` — Cone / StreamTube.
- `Chart3D_Volume.fs` — Volume / IsoSurface.
- `ChartPolar_Scatter.fs` — ScatterPolar / PointPolar / LinePolar / SplinePolar / BubblePolar, carrying `renderScatterPolarTrace`.
- `ChartPolar_Bar.fs` — BarPolar.
- `ChartTernary_Scatter.fs` — ScatterTernary / PointTernary / LineTernary / BubbleTernary.
- `ChartSmith_Scatter.fs` — ScatterSmith / PointSmith / LineSmith / BubbleSmith.
- Remove the original family files once all constructor groups are migrated and fsproj ordering is updated.
- Retarget the matching C# wrapper files (`Chart3D.cs`, `ChartPolar.cs`, `ChartTernary.cs`, `ChartSmith.cs`).
- Run `./build.cmd runTestsCore`.

Status:

- Done.

Implementation notes:

- Added `Chart3D_Scatter.fs`, `Chart3D_Surface.fs`, `Chart3D_VectorField.fs`, and `Chart3D_Volume.fs` under `src/Plotly.NET/ChartAPI/Chart3D/`.
- Added `ChartPolar_Scatter.fs` and `ChartPolar_Bar.fs`, moving `renderScatterPolarTrace` into `ChartPolar_Scatter.fs`.
- Added `ChartTernary_Scatter.fs` and `ChartSmith_Scatter.fs`.
- Removed the original `Chart3D.fs`, `ChartPolar.fs`, `ChartTernary.fs`, and `ChartSmith.fs` files and replaced their `Plotly.NET.fsproj` entries with the new per-family files.
- Retargeted the matching C# wrapper calls in `src/Plotly.NET.CSharp/ChartAPI/Chart3D.cs`, `ChartPolar.cs`, `ChartTernary.cs`, and `ChartSmith.cs`.
- Verified with `./build.cmd runTestsCore` successfully as part of the full branch verification.

### Commit 6: ChartMap + ChartCarpet + ChartDomain families [done]

Scope:

- `ChartMap_Geo.fs` — ChoroplethMap / ScatterGeo / PointGeo / LineGeo / BubbleGeo.
- `ChartMap_Mapbox.fs` — ScatterMapbox / PointMapbox / LineMapbox / BubbleMapbox.
- `ChartMap_Density.fs` — ChoroplethMapbox / DensityMapbox.
- `ChartCarpet_Base.fs` — Carpet.
- `ChartCarpet_Scatter.fs` — ScatterCarpet / PointCarpet / LineCarpet / SplineCarpet / BubbleCarpet.
- `ChartCarpet_Contour.fs` — ContourCarpet.
- `ChartDomain_Pie.fs` — Pie / Doughnut / FunnelArea.
- `ChartDomain_Hierarchy.fs` — Sunburst / Treemap.
- `ChartDomain_Relations.fs` — ParallelCoord / ParallelCategories / Sankey.
- `ChartDomain_Table.fs` — Table / Indicator.
- `ChartDomain_Icicle.fs` — Icicle.
- Remove the original family files once all constructor groups are migrated and fsproj ordering is updated.
- Retarget the matching C# wrapper files (`ChartMap.cs`, `ChartCarpet.cs`, `ChartDomain.cs`).
- Run `./build.cmd runTestsCore`.

Status:

- Done.

Implementation notes:

- Added `ChartMap_Geo.fs`, `ChartMap_Mapbox.fs`, and `ChartMap_Density.fs` under `src/Plotly.NET/ChartAPI/ChartMap/`.
- Added `ChartCarpet_Base.fs`, `ChartCarpet_Scatter.fs`, and `ChartCarpet_Contour.fs` under `src/Plotly.NET/ChartAPI/ChartCarpet/`.
- Added `ChartDomain_Pie.fs`, `ChartDomain_Hierarchy.fs`, `ChartDomain_Relations.fs`, `ChartDomain_Table.fs`, and `ChartDomain_Icicle.fs` under `src/Plotly.NET/ChartAPI/ChartDomain/`.
- Removed the original `ChartMap.fs`, `ChartCarpet.fs`, and `ChartDomain.fs` files and replaced their `Plotly.NET.fsproj` entries with the new per-family files.
- Retargeted the matching C# wrapper calls in `src/Plotly.NET.CSharp/ChartAPI/ChartMap.cs`, `ChartCarpet.cs`, and `ChartDomain.cs`.
- Updated internal repo references that still assumed the old monoliths: `tests/Common/FSharpTestBase/TestCharts/ChartDomainTestCharts.fs` now uses `Chart.Indicator`, and both playground scripts now `#load` the split files.
- Verified with `./build.cmd runTestsCore` successfully: build passed and 933/933 core tests passed.

### Final checkpoint

After Commit 6 lands:

- Reassess whether [Chart.fs](src/Plotly.NET/ChartAPI/Chart.fs) should stay as-is. It remains explicitly out of scope for this plan unless a later follow-up chooses to redesign the base `Chart` type.
- Confirm every extension-based family now lives in a per-family subdirectory under `ChartAPI/`.
- Keep any future `Chart.fs` work as a separate design/refactor effort, not an automatic continuation of this branch.

Status:

- Reached. The extension-based Chart API families now live under per-family subdirectories, and `Chart.fs` remains the only intentionally unsplit top-level Chart API file.

## Open questions

- Do we keep flat `Chart2D_X.fs` filenames in the existing `ChartAPI/` directory, or move to a `ChartAPI/Chart2D/` subdirectory? **Recommendation: use a `ChartAPI/Chart2D/` subdirectory** because it is cleaner for maintainers, keeps related constructor groups together, and scales better if other large families are ever split later.
- Should internal helpers live on a shared `Chart` type (via a future `Chart2D_Shared.fs`) or as free module-level functions? **Recommendation: defer this** until a second split actually needs shared code. Avoid inventing a helper layer before there is concrete reuse pressure.
- Naming: `Chart2D_Scatter` vs `Chart2DScatter` vs `Chart2D.Scatter`? The underscore form is unambiguous and avoids clashing with a nested module path. **Recommendation: underscore.**
