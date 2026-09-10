# C# Chart API File Split Plan

## Background

The C# Chart API wrapper in [src/Plotly.NET.CSharp/ChartAPI/](src/Plotly.NET.CSharp/ChartAPI/) is still split only by chart family:

| File | Lines |
|---|---:|
| [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs) | 2723 |
| [ChartDomain.cs](src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs) | 876 |
| [ChartMap.cs](src/Plotly.NET.CSharp/ChartAPI/ChartMap.cs) | 871 |
| [Chart3D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart3D.cs) | 834 |
| [ChartCarpet.cs](src/Plotly.NET.CSharp/ChartAPI/ChartCarpet.cs) | 607 |
| [ChartPolar.cs](src/Plotly.NET.CSharp/ChartAPI/ChartPolar.cs) | 482 |
| [ChartTernary.cs](src/Plotly.NET.CSharp/ChartAPI/ChartTernary.cs) | 361 |
| [ChartSmith.cs](src/Plotly.NET.CSharp/ChartAPI/ChartSmith.cs) | 334 |

The F# Chart API has already been split into smaller files grouped by chart-type families. The C# wrapper still concentrates many generated-looking forwarding methods plus long XML doc blocks into single family files, especially [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs). That makes review, navigation, and future edits harder than they need to be.

The goal of this refactor is purely structural:

- keep the public C# API surface unchanged,
- preserve `Plotly.NET.CSharp.Chart.*` as the entry point,
- reorganize the wrapper implementation into per-family folders and root-level utility files,
- use one partial-class file per chart type or tightly related chart group,
- add per-chart wrapper tests alongside the split so each moved chart keeps explicit coverage.

## Target layout

Create subfolders under [src/Plotly.NET.CSharp/ChartAPI/](src/Plotly.NET.CSharp/ChartAPI/) and move methods into one `public static partial class Chart` file per chart or tightly related chart group.

```text
src/Plotly.NET.CSharp/ChartAPI/
    Chart/
        Combine.cs
        Grid.cs
        SingleStack.cs
        Invisible.cs
    Chart2D/
        Scatter.cs
        Point.cs
        Line.cs
        Spline.cs
        Bubble.cs
        Range.cs
        Pareto.cs
        Area.cs
        SplineArea.cs
        StackedArea.cs
        Funnel.cs
        StackedFunnel.cs
        Waterfall.cs
        Bar.cs
        StackedBar.cs
        Column.cs
        StackedColumn.cs
        Histogram.cs
        Histogram2D.cs
        Histogram2DContour.cs
        BoxPlot.cs
        Violin.cs
        Heatmap.cs
        AnnotatedHeatmap.cs
        Image.cs
        Contour.cs
        OHLC.cs
        Candlestick.cs
        Splom.cs
        PointDensity.cs
    Chart3D/
        Scatter3D.cs
        Point3D.cs
        Line3D.cs
        Bubble3D.cs
        Surface.cs
        Mesh3D.cs
        Cone.cs
        StreamTube.cs
        Volume.cs
        IsoSurface.cs
    ChartPolar/
        ScatterPolar.cs
        PointPolar.cs
        LinePolar.cs
        SplinePolar.cs
        BubblePolar.cs
        BarPolar.cs
    ChartMap/
        ChoroplethMap.cs
        ScatterGeo.cs
        PointGeo.cs
        LineGeo.cs
        BubbleGeo.cs
        ScatterMapbox.cs
        PointMapbox.cs
        LineMapbox.cs
        BubbleMapbox.cs
        ChoroplethMapbox.cs
        DensityMapbox.cs
    ChartTernary/
        ScatterTernary.cs
        PointTernary.cs
        LineTernary.cs
        BubbleTernary.cs
    ChartCarpet/
        Carpet.cs
        ScatterCarpet.cs
        PointCarpet.cs
        LineCarpet.cs
        SplineCarpet.cs
        BubbleCarpet.cs
        ContourCarpet.cs
    ChartDomain/
        Pie.cs
        Doughnut.cs
        FunnelArea.cs
        Sunburst.cs
        Treemap.cs
        ParallelCoord.cs
        ParallelCategories.cs
        Sankey.cs
        Table.cs
        Indicator.cs
        Icicle.cs
    ChartSmith/
        ScatterSmith.cs
        PointSmith.cs
        LineSmith.cs
        BubbleSmith.cs
```

Notes:

- The current root file [Chart.cs](src/Plotly.NET.CSharp/ChartAPI/Chart.cs) should be split into a top-level [Chart/](src/Plotly.NET.CSharp/ChartAPI/Chart/) folder, with one partial-class file per helper method or tightly related helper group.
- The current family files (`Chart2D.cs`, `Chart3D.cs`, etc.) should be removed once their members are fully migrated.
- SDK-style project defaults should include new `**/*.cs` files automatically, so no `.csproj` item updates are expected unless we deliberately add build metadata later.
- Test coverage should land in [tests/ExtensionLibsTests/CSharpTests/](tests/ExtensionLibsTests/CSharpTests/), which already contains the Plotly.NET.CSharp xUnit suite.

## File shape

Each new file should look like this:

```csharp
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
    /// <summary>...</summary>
    public static GenericChart Scatter<XType, YType, TextType>(...)
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        => Plotly.NET.Chart2D_Scatter.Chart.Scatter(...);
}
```

Implementation rules:

- Keep the namespace and class name unchanged: `Plotly.NET.CSharp.Chart`.
- Preserve method names, generic parameter names, parameter order, default values, constraints, and XML docs exactly unless a follow-up cleanup explicitly chooses otherwise.
- Keep all overloads of the same method name in the same file. Example: both `Pareto` overloads stay together in `Pareto.cs`.
- Keep the forwarding target unchanged apart from moving the source file. Example: `Scatter` should still call `Plotly.NET.Chart2D_Scatter.Chart.Scatter(...)`.
- Avoid opportunistic API cleanup in the same refactor. This is a file-structure change, not a signature redesign.
- Apply the same rule to root-level helpers from `Chart.cs`: `Combine`, `Invisible`, `Grid`, and `SingleStack` move into their own files without behavioral changes.
- For each chart method that moves, add or move a focused C# test that proves the wrapper still produces the expected chart output.

## Testing strategy

The file split should ship with stronger C# wrapper coverage, not just structural changes.

### Test location

Add the new wrapper tests under [tests/ExtensionLibsTests/CSharpTests/](tests/ExtensionLibsTests/CSharpTests/), mirroring the production folder layout:

```text
tests/ExtensionLibsTests/CSharpTests/
    Chart/
        CombineTests.cs
        GridTests.cs
        SingleStackTests.cs
        InvisibleTests.cs
    Chart2D/
        ScatterTests.cs
        PointTests.cs
        ...
    Chart3D/
        Scatter3DTests.cs
        ...
```

If the suite grows enough to justify shared helpers, add them under [tests/Common/CSharpTestBase/](tests/Common/CSharpTestBase/) rather than duplicating setup logic.

### Fixture reuse preference

Preferred order:

1. Reuse the existing F# fixtures from [tests/Common/FSharpTestBase/TestCharts/](tests/Common/FSharpTestBase/TestCharts/) when they are accessible cleanly from C#.
2. If direct C# consumption is awkward because of F# module shape, nested modules, or backtick-named values, add a thin stable accessor layer in `FSharpTestBase` or a mirrored C# fixture in `CSharpTestBase`.
3. Only create fully independent C# fixture data when reuse would add more indirection than value.

Practical guidance:

- Many current F# fixtures already express the canonical expected charts and consistently set `UseDefaults = false`; that should remain the source of truth where possible.
- If C# cannot consume a fixture ergonomically, prefer mirroring that fixture with the same data and intent, and document the correspondence in the test file or helper.
- For charts that already have no concrete F# fixture yet, such as placeholders like `StackedFunnel` or `Waterfall`, create a C# mirror fixture until the F# side gains one.

### Assertion style

Use focused output-based assertions similar to the existing `htmlcodegen/SimpleTests.cs`:

- assert on stable JSON/HTML substrings that identify the expected trace type and key options,
- avoid brittle full-document snapshots unless a chart genuinely needs broad coverage,
- keep `UseDefaults = false` on all fixture charts to avoid noisy template output,
- prefer one representative test per chart method, with extra tests only for overloads or behavior that differs materially.

### Shared test utilities

The shared markup helpers remain in `tests/ExtensionLibsTests/CSharpTests/TestUtils.cs`, where they serve the folders within the same C# test project.

- Moving the helpers into [tests/Common/CSharpTestBase/](tests/Common/CSharpTestBase/) is deferred until another test project needs them. Reuse across folders in one project does not require a separate assembly.
- Add reusable fixture accessors to the common project when cross-project fixture reuse is needed.
- Keep helper names aligned with the F# `TestUtils` vocabulary where that improves cross-language readability.

## Refactor strategy

The safest path is to mirror the F# split that already exists and move the C# wrappers in small, buildable slices.

### Phase 1: Establish the pattern on Chart2D

Start with the largest file because it gives the biggest readability win and validates the folder conventions. Use one chart file per public method group.

Recommended first moves:

- `Scatter.cs`
- `Point.cs`
- `Line.cs`
- `Spline.cs`
- `Bubble.cs`
- `Range.cs`
- `Pareto.cs`

These methods already target `Plotly.NET.Chart2D_Scatter.Chart` and `Plotly.NET.Chart2D_Statistical.Chart`, so they form a natural first slice.

Add matching C# tests for each moved chart method in `tests/ExtensionLibsTests/CSharpTests/Chart2D/`, reusing the existing F# fixtures where practical and mirroring them where direct reuse is not worth the friction.

### Phase 2: Finish Chart2D

Migrate the remaining 2D files in coherent clusters:

- area family: `Area`, `SplineArea`, `StackedArea`
- funnel family: `Funnel`, `StackedFunnel`, `Waterfall`
- bar family: `Bar`, `StackedBar`, `Column`, `StackedColumn`
- histogram/distribution family: `Histogram`, `Histogram2D`, `Histogram2DContour`, `BoxPlot`, `Violin`
- heatmap/image family: `Heatmap`, `AnnotatedHeatmap`, `Image`, `Contour`
- finance/dimension family: `OHLC`, `Candlestick`, `Splom`, `PointDensity`

Delete [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs) only after all 2D methods have landed in their new files and the build is green.

Finish the 2D test coverage in the same phase so the folder structure and test structure stay in sync.

### Phase 3: Split the root Chart helpers

Move the current root-level methods from [Chart.cs](src/Plotly.NET.CSharp/ChartAPI/Chart.cs) into dedicated files:

- `Chart/Combine.cs`
- `Chart/Invisible.cs`
- `Chart/Grid.cs`
- `Chart/SingleStack.cs`

Delete [Chart.cs](src/Plotly.NET.CSharp/ChartAPI/Chart.cs) once it no longer contains members.

Add coverage for `Combine`, `Invisible`, `Grid`, and `SingleStack` in `tests/ExtensionLibsTests/CSharpTests/Chart/`.

### Phase 4: Migrate the medium-sized families

Recommended order:

1. `Chart3D`
2. `ChartMap`
3. `ChartDomain`
4. `ChartCarpet`
5. `ChartPolar`
6. `ChartTernary`
7. `ChartSmith`

This order roughly follows size and payoff. It also keeps the more repetitive scatter-derived families for later, when the pattern is already proven.

Each family migration should include the corresponding test folder in the same commit or commit pair.

### Phase 5: Optional follow-up cleanup

Only after the structural split is complete and verified:

- consider consolidating repeated `using` directives with project-level global usings if the team wants that style,
- consider shared editorconfig or file-header conventions for the new folders,
- consider whether related tiny files should be re-merged if one-method-per-file becomes too granular in practice.

This should be a separate decision, not bundled into the main refactor.

## Risks and verification

- **Public API drift.** The main risk is accidentally changing signatures while moving code. Mitigation: copy methods verbatim, then trim the old files.
- **XML documentation drift.** Large comment blocks are easy to damage during moves. Mitigation: prefer whole-method moves and review generated XML docs through a normal build.
- **Duplicate method definitions.** Partial classes merge all members; leaving the old method behind while adding the new one will create compile errors. Mitigation: migrate by cut-over, not by copy-and-forget.
- **Overload separation mistakes.** Unlike the F# side, C# can spread overloads across partial class files, but that makes navigation worse. Mitigation: keep overload families together in one file.
- **Root helper discoverability.** Splitting `Chart.cs` removes the single obvious location for shared helpers. Mitigation: use intuitive filenames that exactly match the public method names.
- **Too many tiny commits.** One-file-per-method is good for layout, but not every single file needs its own commit. Mitigation: commit in family-sized batches that remain reviewable.
- **Style inconsistency.** Mixing block-scoped and file-scoped namespaces or varying `using` sets would create noise. Mitigation: pick one file template and apply it consistently across new files.
- **Fixture reuse friction across F# and C#.** Some F# test-chart modules may not be pleasant to consume directly from C#. Mitigation: prefer reuse, but allow mirrored fixtures in `CSharpTestBase` when access is awkward.
- **Coverage gaps during the move.** A pure file split could accidentally preserve compile success while breaking a forwarder. Mitigation: require at least one representative C# test per chart method as part of the migration.

Verification for each commit:

```shell
./build.cmd
./build.cmd runTestsCore
./build.cmd runTestsExtensionLibs
```

If a commit only touches C# wrappers and the full build is too expensive during active iteration, at minimum run:

```shell
./build.cmd runTestsExtensionLibs
./build.cmd runTestsCore
```

Before the final merge, run the broader build target used by the team for confidence.

## Commit packages

Each commit should stay independently buildable and should include verification.

### Commit 1: Chart2D scatter-derived wrapper split

Scope:

- Create `src/Plotly.NET.CSharp/ChartAPI/Chart2D/`.
- Move `Scatter`, `Point`, `Line`, `Spline`, `Bubble`, `Range`, and both `Pareto` overloads into dedicated files.
- Trim the moved members from [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs).
- Add `tests/ExtensionLibsTests/CSharpTests/Chart2D/` with representative tests for the moved methods.
- Reuse the matching F# fixtures if they are accessible cleanly from C#; otherwise add mirrored fixture helpers.
- Keep signatures and docs unchanged.
- Run `./build.cmd runTestsCore` and `./build.cmd runTestsExtensionLibs`.

Exit criteria:

- New `Chart2D/` folder exists.
- The moved methods compile from partial-class files.
- `Chart2D.cs` is materially smaller.
- The moved chart methods have explicit C# wrapper tests.

Implementation notes:

- Done. All seven scatter-derived method groups live in [src/Plotly.NET.CSharp/ChartAPI/Chart2D/](src/Plotly.NET.CSharp/ChartAPI/Chart2D/): `Scatter.cs`, `Point.cs`, `Line.cs`, `Spline.cs`, `Bubble.cs`, `Range.cs`, `Pareto.cs` (both overloads together).
- Those methods have been removed from [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs) (now ~2081 lines, down from ~2564).
- Test coverage lives under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart2D/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart2D/) — one `*Tests.cs` per method, with mirrored C# fixtures using `UseDefaults = false` and full `var data = ...` baseline assertions.
- Verification: `./build.cmd RunCSharpTestsFast` (16 passed), `./build.cmd runTestsExtensionLibs` (16 passed), `./build.cmd runTestsCore` (933 passed).

### Commit 2: Finish Chart2D wrapper split

Scope:

- Add the remaining `Chart2D/*.cs` files.
- Remove the rest of the methods from [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs).
- Delete [Chart2D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart2D.cs) once empty.
- Add the remaining `Chart2D/*Tests.cs` coverage.
- Run `./build.cmd runTestsCore` and `./build.cmd runTestsExtensionLibs`.

Exit criteria:

- All 2D wrapper methods live under `ChartAPI/Chart2D/`.
- No `Chart2D.cs` remains.
- All 2D wrapper methods have dedicated C# tests.

Implementation notes:

- Added the remaining `tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart2D/*Tests.cs` coverage for the split `Chart2D` wrappers: `Bar`, `StackedBar`, `Column`, `StackedColumn`, `Funnel`, `StackedFunnel`, `Waterfall`, `Histogram`, `Histogram2D`, `Histogram2DContour`, `BoxPlot`, `Violin`, `Heatmap`, `AnnotatedHeatmap`, `Image`, `Contour`, `OHLC`, `Candlestick`, `Splom`, and `PointDensity`.
- Generated the expected `data`/`layout` baselines from real chart rendering via `tools/chart-baseline-generation/generate-chart-markup.fsx` instead of hand-authoring the markup.
- Verification: `./build.cmd RunCSharpTestsFast` / `dotnet run --project ./build/build.fsproj -- RunCSharpTestsFast` (45 passed).

### Commit 3: Split root Chart helpers

Scope:

- Add `Combine.cs`, `Invisible.cs`, `Grid.cs`, and `SingleStack.cs` under `src/Plotly.NET.CSharp/ChartAPI/Chart/`.
- Move the corresponding methods out of [Chart.cs](src/Plotly.NET.CSharp/ChartAPI/Chart.cs).
- Delete [Chart.cs](src/Plotly.NET.CSharp/ChartAPI/Chart.cs) once empty.
- Add `tests/ExtensionLibsTests/CSharpTests/Chart/` coverage for the moved helpers.
- Run `./build.cmd runTestsCore` and `./build.cmd runTestsExtensionLibs`.

Why here:

- It keeps the refactor rule consistent across the whole C# Chart API before moving on to the remaining family files.
- The low method count makes this a safe, fast validation of the root-level pattern.

Implementation notes:

- Split the root `Chart` wrapper into dedicated partials under [src/Plotly.NET.CSharp/ChartAPI/Chart/](src/Plotly.NET.CSharp/ChartAPI/Chart/): `Combine.cs`, `Invisible.cs`, `Grid.cs`, and `SingleStack.cs`.
- Deleted [Chart.cs](src/Plotly.NET.CSharp/ChartAPI/Chart.cs) after moving the last root helper methods out of it.
- Added focused C# html-codegen coverage under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart/) for `Combine`, `Invisible`, `Grid`, and `SingleStack`, including baselines for the serialized invisible chart output.
- Verification: `dotnet run --project ./build/build.fsproj -- RunCSharpTestsFast` (52 passed), `dotnet run --project ./build/build.fsproj -- RunTestsExtensionLibsFast` (C# tests 52 passed; ImageExportTests 6 passed, 2 skipped).

### Commit 4: Split Chart3D and ChartPolar

Scope:

- Create `ChartAPI/Chart3D/` and `ChartAPI/ChartPolar/`.
- Move each chart method into its own file.
- Delete [Chart3D.cs](src/Plotly.NET.CSharp/ChartAPI/Chart3D.cs) and [ChartPolar.cs](src/Plotly.NET.CSharp/ChartAPI/ChartPolar.cs) after migration.
- Add `tests/ExtensionLibsTests/CSharpTests/Chart3D/` and `tests/ExtensionLibsTests/CSharpTests/ChartPolar/`.
- Run `./build.cmd runTestsCore` and `./build.cmd runTestsExtensionLibs`.

Why this pairing:

- Both families are direct scatter-style wrappers and are straightforward once Chart2D is done.

Implementation notes:

- `Chart3D/` and `ChartPolar/` source folders were already present in the branch, so this work package focused on the missing C# html-codegen coverage for those wrappers rather than another source-file move.
- Added focused C# wrapper serialization tests under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart3D/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/Chart3D/) for `Scatter3D`, `Point3D`, `Line3D`, `Bubble3D`, `Surface`, `Mesh3D`, `Cone`, `StreamTube`, `Volume`, and `IsoSurface`.
- Added matching C# wrapper serialization tests under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartPolar/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartPolar/) for `ScatterPolar`, `PointPolar`, `LinePolar`, `SplinePolar`, `BubblePolar`, and `BarPolar`.
- Derived and corrected the new expected markup against actual rendered output during verification, including the `BubblePolar` and `BarPolar` baseline differences.
- Verification: `dotnet run --project ./build/build.fsproj -- RunCSharpTestsFast` (68 passed), `dotnet run --project ./build/build.fsproj -- RunTestsCoreFast` (933 passed), `dotnet run --project ./build/build.fsproj -- RunTestsExtensionLibsFast` (C# tests 68 passed; ImageExportTests 6 passed, 2 skipped).

### Commit 5: Split ChartMap and ChartTernary

Scope:

- Create `ChartAPI/ChartMap/` and `ChartAPI/ChartTernary/`.
- Move each chart method into its own file.
- Delete [ChartMap.cs](src/Plotly.NET.CSharp/ChartAPI/ChartMap.cs) and [ChartTernary.cs](src/Plotly.NET.CSharp/ChartAPI/ChartTernary.cs) after migration.
- Add `tests/ExtensionLibsTests/CSharpTests/ChartMap/` and `tests/ExtensionLibsTests/CSharpTests/ChartTernary/`.
- Run `./build.cmd runTestsCore` and `./build.cmd runTestsExtensionLibs`.

Implementation notes:

- `ChartMap/` and `ChartTernary/` source folders were already present in the branch, so this package focused on adding the missing C# html-codegen coverage for those wrappers.
- Added focused C# wrapper serialization tests under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartMap/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartMap/) for `ScatterGeo`, `PointGeo`, `LineGeo`, `BubbleGeo`, `ScatterMapbox`, `PointMapbox`, `LineMapbox`, `BubbleMapbox`, `DensityMapbox`, `ChoroplethMap`, and `ChoroplethMapbox`.
- Added focused C# wrapper serialization tests under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartTernary/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartTernary/) for `ScatterTernary`, `PointTernary`, `LineTernary`, and `BubbleTernary`.
- Corrected the initial baselines against actual serialized output for `BubbleGeo`, `BubbleMapbox`, and `ChoroplethMapbox` where the emitted shape differed from the first-pass expectation.
- Verification: `dotnet run --project ./build/build.fsproj -- RunCSharpTestsFast` (83 passed), `dotnet run --project ./build/build.fsproj -- RunTestsCoreFast` (933 passed), `dotnet run --project ./build/build.fsproj -- RunTestsExtensionLibsFast` (C# tests 83 passed; ImageExportTests 6 passed, 2 skipped).

### Commit 6: Split ChartDomain, ChartCarpet, and ChartSmith

Scope:

- Create `ChartAPI/ChartDomain/`, `ChartAPI/ChartCarpet/`, and `ChartAPI/ChartSmith/`.
- Move each chart method into its own file.
- Delete [ChartDomain.cs](src/Plotly.NET.CSharp/ChartAPI/ChartDomain.cs), [ChartCarpet.cs](src/Plotly.NET.CSharp/ChartAPI/ChartCarpet.cs), and [ChartSmith.cs](src/Plotly.NET.CSharp/ChartAPI/ChartSmith.cs) after migration.
- Add `tests/ExtensionLibsTests/CSharpTests/ChartDomain/`, `tests/ExtensionLibsTests/CSharpTests/ChartCarpet/`, and `tests/ExtensionLibsTests/CSharpTests/ChartSmith/`.
- Run `./build.cmd runTestsCore` and `./build.cmd runTestsExtensionLibs`.

Implementation notes:

- `ChartDomain/`, `ChartCarpet/`, and `ChartSmith/` source folders were already present in the branch, so this package focused on filling the missing C# html-codegen coverage for those wrapper families.
- Added C# wrapper serialization coverage under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartDomain/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartDomain/) for `Pie`, `Doughnut`, `FunnelArea`, `Sunburst`, `Treemap`, `ParallelCoord`, `ParallelCategories`, `Sankey`, `Table`, `Indicator`, and `Icicle`.
- Added C# wrapper serialization coverage under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartCarpet/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartCarpet/) for `Carpet`, `ScatterCarpet`, `PointCarpet`, `LineCarpet`, `SplineCarpet`, `BubbleCarpet`, and `ContourCarpet`.
- Added C# wrapper serialization coverage under [tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartSmith/](tests/ExtensionLibsTests/CSharpTests/htmlcodegen/ChartSmith/) for `ScatterSmith`, `PointSmith`, `LineSmith`, and `BubbleSmith`.
- Adjusted the initial baselines to match actual C# wrapper serialization for the object-heavy and carpet traces, especially `Table`, `ContourCarpet`, `BubbleGeo`, `BubbleMapbox`, and `ChoroplethMapbox`.
- Verification: `dotnet run --project ./build/build.fsproj -- RunCSharpTestsFast` (105 passed), `dotnet run --project ./build/build.fsproj -- RunTestsCoreFast` (933 passed), `dotnet run --project ./build/build.fsproj -- RunTestsExtensionLibsFast` (C# tests 105 passed; ImageExportTests 6 passed, 2 skipped).

### Commit 7: Consistency pass and final verification

Scope:

- Ensure all new files use the same namespace style and `using` ordering.
- Check whether any stale folder-level comments or references still mention the removed family files.
- Run the standard build plus core tests.

Suggested verification:

```shell
./build.cmd
./build.cmd runTestsCore
./build.cmd runTestsExtensionLibs
```

Implementation notes:

- No additional namespace or `using` normalization was needed for the newly added C# test files; they already match the file-scoped namespace style used in the surrounding C# test suite.
- Searched for stale references to removed umbrella C# Chart API files. Remaining mentions are confined to planning documents that still describe the pre-split starting point; no code or project files needed cleanup.
- Final verification: `dotnet run --project ./build/build.fsproj` (Build target succeeded), `dotnet run --project ./build/build.fsproj -- RunTestsCoreFast` (933 passed), `dotnet run --project ./build/build.fsproj -- RunTestsExtensionLibsFast` (C# tests 105 passed; ImageExportTests 6 passed, 2 skipped).
- Merge verification on 2026-09-10: fetched `origin`, fast-forwarded local `dev` to `bca20de4`, and merged it into `C#-refactor` without conflicts in `51c744b0`. The full clean `./build.cmd runTestsAll` pipeline passed before the merge commit: core tests 945 passed, C# tests 105 passed, ImageExportTests 6 passed and 2 already marked pending. The additional core tests cover the incoming Venn and UpSet charts.

## Completion status

Implemented.

Resolved decisions:

1. New C# test files follow the surrounding suite's file-scoped namespace style; no normalization pass was needed beyond keeping that style consistent.
2. The split stayed at one public chart wrapper per file across the migrated families instead of regrouping tiny related methods.
3. Root helpers were split into one file per method: `Combine.cs`, `Grid.cs`, `SingleStack.cs`, and `Invisible.cs`.
4. Direct F# fixture reuse was not standardized for this pass; the new C# html-codegen coverage uses mirrored C# fixtures and rendered baselines where that kept the tests simpler and more stable.
5. Empty umbrella files were removed rather than kept as placeholders; the root `Chart.cs` file was deleted once its helpers moved.
6. Shared markup helpers stay in the CSharpTests project; moving them into CSharpTestBase is deferred until there is cross-project reuse.

No further implementation work remains for this plan.
