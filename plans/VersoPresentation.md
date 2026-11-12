# Verso notebook presentation and output lifecycle

Status: deferred until after the v1 release, per the user's decision on 2026-11-12. The current implementation in `VersoExtension.md` defines the v1 scope; this proposal is not a release requirement and implementation has not started.
Baseline: local commit `6ef04eb8`; reviewed maintainer fork `bd568aba75134a08ba02a8320251e86258384592`.

## Objective

Add the maintainer's useful notebook presentation behaviors to our tested Verso adapter: host-aware colors/fonts, container-width sizing, and convenient image-download defaults. Add explicit disposal of rendered outputs before introducing more browser observers and event handlers.

Retain the inline `text/html` renderer, shared asynchronous Plotly loader, originating-assembly bridge, and existing public HTML helpers. Widget/iframe output is a separate architectural decision, not a prerequisite for these features.

## Proposed public behavior

Add a small per-chart API in `Plotly.NET.Verso`, provisionally `PresentationOptions` and `Presentation.withOptions options chart`:

| Option | Default | Opt-in behavior |
|---|---|---|
| Theme | `Preserve` | `FollowHost`: apply host presentation colors/fonts under the precedence rules below and follow live theme changes |
| Sizing | `Preserve` | `FitContainerWidth`: deliberately replace rendered width with the output container's width; keep chart height |
| Snapshot | `Preserve` | `NotebookDefaults`: fill missing image-download filename/format/scale settings |

The names are proposed API names, not existing functions. A chart with no presentation metadata must render as it does today. Lifecycle cleanup applies to all charts independently of these choices.

Store options as a versioned JSON string under a reserved DisplayOptions property, such as `Plotly.NET.Verso.Presentation`. The helper copies the DisplayOptions container and attaches the new metadata without changing the source chart or its nested HTML nodes. Read the metadata through the originating assembly's public DynamicObj API; pass strings and simple values through the bridge, not foreign option types. Do not introduce mutable global settings that can diverge between kernel and extension assembly contexts.

Read policy once per formatted output. Later changes to another chart must not change existing output policies. Live host-theme changes are the deliberate exception for outputs using `FollowHost`. Recommend applying the helper after `Chart.combine`; do not invent trace-level option merging in this change.

## Goal 1: deterministic output disposal

- Track each rendered output by its actual DOM element and unique ID.
- When a rendered output is removed or replaced, call `Plotly.purge` and remove adapter-owned listeners, observers, timers, and queued animation-frame work.
- Removal during loading must prevent subsequent `newPlot`, error insertion, or ready-state updates for that output. Keep a shared load alive when another output still needs it.
- Removal during asynchronous drawing must prevent later callbacks from reviving the output. Perform final cleanup after drawing settles if it can create resources after the initial disposal.
- Keep lifecycle tracking bounded: unregister disposed elements and stop shared observation when no outputs need it. Do not attach one permanent document-wide observer per cell.
- Keep shared Plotly availability and failed-load retry behavior intact. Do not remove another cell's library or output.

Acceptance tests use real rendering plus spies on purge and adapter-owned registrations. Ready-output removal purges once; in-flight drawing may require final cleanup again. Repeated reruns leave one live chart and its expected active subscriptions. Test one of two waiting cells being removed, removal while drawing, and removal before a queued callback fires. Assert observable cleanup rather than unreliable heap-size thresholds.

## Goal 2: optional host-theme adaptation

- Apply theme values before the first `Plotly.newPlot` call so the first rendered frame uses the selected palette.
- Use the existing Verso theme context as fallback and the host's resolved CSS tokens when present. Listen for `verso:themechanged` only for opted-in, eligible outputs.
- Scope every update to that chart's element. Do not wrap global `Plotly.newPlot`/`react` or restyle all charts on the page.
- First-version coverage is paper/plot backgrounds, font family/size/color, and Cartesian axis grid/line/zero-line/tick colors, including Cartesian subplots. Trace colors, colorways, colorscales, and family-specific 3D/polar/geo/ternary styling are outside this change.
- Missing or invalid theme tokens leave the corresponding original presentation value in place. Do not fetch fonts or inject external font resources.
- Theme changes must preserve data, chart IDs, zoom/ranges, and explicit user settings; they must not recreate the chart with `newPlot`.

Precedence is explicit:

1. Direct layout and trace properties win, including properties whose values happen to equal library defaults.
2. A non-stock custom template remains authoritative; skip automatic theme adaptation for that chart in this first version.
3. An absent template or a structurally stock Plotly.NET template is eligible only when `FollowHost` was selected. Apply a render-only presentation overlay while retaining the other template settings.
4. Obtain the stock template baseline from the chart's originating assembly (`ChartTemplates.plotly`), not the extension's assembly or the mutable current `Defaults.DefaultTemplate`. Do not retain foreign assembly/type objects in static caches.

There is no historical provenance for an explicitly supplied template identical to the stock template. Under this contract, opting into `FollowHost` makes that template eligible too; `Preserve` keeps it unchanged. Do not claim that value comparison can reconstruct how a chart was created.

Acceptance tests cover light/dark first draw, live theme switching, fallback with absent CSS tokens, explicit layout overrides, custom templates, stock-equivalent templates, Cartesian subplots, independent opted-in/opted-out outputs, and unchanged zoom after a theme change. Verify source-chart immutability and settings round-trip for both normal and foreign-assembly charts. No updates may run after disposal.

## Goal 3: optional container-width sizing

- `Preserve` retains current dimensions and behavior, including an explicitly supplied width equal to the library default.
- `FitContainerWidth` explicitly authorizes overriding width for this rendered output, including a previously supplied width. Keep its height, data, and other layout settings unchanged.
- Observe a stable output wrapper's available content width, not the document root or the graph's own width. Respond when a sidebar or notebook column changes without a window resize.
- Ignore zero-width measurements until the output becomes visible. Coalesce rapid changes and do nothing when the effective width has not changed.
- Resize the existing graph; do not create a new chart or introduce height/width feedback loops. Do not globally force `config.responsive=false` as the iframe-specific fork implementation does.
- Preserve zoom/ranges during resize and disconnect the observer and queued work on disposal.

Acceptance tests change parent width without dispatching `window.resize`, check actual Plotly dimensions, preserve height, test hidden-to-visible output, rapid resizing, two independently sized cells, preserved zoom, and removed outputs. Explicit-width preservation is tested in `Preserve`; deliberate width replacement is tested in `FitContainerWidth`.

## Goal 4: optional image-download defaults

- In `NotebookDefaults`, fill only missing `toImageButtonOptions` properties: PNG format, scale 2, and a filename derived from the chart title.
- Preserve every supplied export property, including filename, format, scale, width, and height. Preserve all other config values and custom modebar settings.
- Produce a bounded, filesystem-safe title slug, removing title markup, separators, control characters, and invalid trailing characters. Handle reserved filenames and empty/unusable titles with a stable `plotly-chart` fallback; limit generated filenames to 80 characters before the extension.
- Resolve values per output without modifying the original chart. Do not alter trace data, titles, or normal chart display dimensions to improve exports.

Acceptance tests cover plain/markup/Unicode/empty/long/reserved titles and independently supplied option overrides. Verify the modebar receives the expected filename/options and generate an actual PNG, checking its dimensions at scale 2. A self-contained line-chart fixture must render and export with external HTTP requests blocked.

## Goal 5: preserve compatibility and prove host behavior

- Keep `GenericChartFormatter`, `Formatters.toVersoHTML`, and `Formatters.toVersoHTMLOffline` signatures and output contracts.
- Preserve custom CDN, missing-reference CDN, `Full`, `NoReference`, and actionable `Require` behavior, as well as MIME filtering, cancellation, metadata, descriptions, and additional HTML tags.
- Keep render-only changes separate from source chart JSON. Do not reintroduce date-string conversion while processing captured JSON.
- Extend packaged CLI/web-host fixtures to exercise the new policies, reruns, theme updates, resizing, save, and reopen. Reopened opted-in output follows the current host theme and container width; opted-out output keeps its chart styling.
- Existing helpers remain usable outside Verso. If no host theme context or CSS tokens are available, keep the original chart palette; do not manufacture a new default theme or fetch resources.
- Run deterministic unit/browser tests on Windows and Linux, packaged integration, documentation generation, and the required full clean suite before committing. Record actual environments and outcomes.
- Perform and record a manual VS Code check of dark/light switching, notebook-width changes, configured versus preserved export options, repeated reruns, offline output, and save/reopen. Do not substitute automated web-host tests for this check.

## Planned commits

- [ ] **1. Per-chart presentation policy.** Add typed options, immutable metadata helper, bridge capture, and unit/foreign-assembly round-trip tests. Document default/override semantics in API comments.
- [ ] **2. Output disposal.** Add lifecycle tracking and purge/observer cleanup with browser regressions for removal, reruns, and pending work.
- [ ] **3. Host themes.** Add initial and live theme application, explicit precedence rules, and unit/browser tests, including multi-cell and subplot cases.
- [ ] **4. Container sizing.** Add opt-in width observation, hidden-output handling, and browser resize/disposal/zoom tests.
- [ ] **5. Snapshot defaults.** Add safe filename generation and missing-property defaults with unit tests and actual browser export checks.
- [ ] **6. Packaged host coverage and documentation.** Extend host fixtures and manuals, attribute adapted maintainer code, run final validation, and record results.

## Explicit exclusions

- Switching the default formatter to `text/x-verso-widget` or changing existing helper return formats.
- Global monkey-patching of Plotly or page-wide selectors that affect unrelated charts.
- Global mutable theme/offline flags, silently overriding explicit config, or treating default-value equality as author-intent provenance.
- Full styling support for every Plotly trace family, new core chart APIs, unrelated dependency/runtime upgrades, or publishing packages.
- Claiming a demonstrated memory leak: removal cleanup is a source-supported lifecycle concern that the new tests must establish precisely.

## Sources and attribution

Adapt selected concepts/code from Torrey Betts' fork with attribution in the implementation commits. Its iframe-specific scripts require adaptation for the existing inline renderer.

- [Fork theme/sizing/export implementation](https://github.com/TorreyBetts/Plotly.NET/blob/bd568aba75134a08ba02a8320251e86258384592/src/Plotly.NET.Verso/Theming.fs)
- [Fork formatter and widget contract](https://github.com/TorreyBetts/Plotly.NET/blob/bd568aba75134a08ba02a8320251e86258384592/src/Plotly.NET.Verso/Formatters.fs)
- [Verso 1.2.3 output handling](https://github.com/DataficationSDK/Verso/blob/6f2e3dd9103be27931340bcb0bba2e326590f992/src/Verso.Blazor.Shared/Components/Notebook/OutputView.razor)
- [Verso theme context](https://github.com/DataficationSDK/Verso/blob/6f2e3dd9103be27931340bcb0bba2e326590f992/src/Verso.Abstractions/Contexts/IThemeContext.cs)
- [Inline theme-change event](https://github.com/DataficationSDK/Verso/blob/6f2e3dd9103be27931340bcb0bba2e326590f992/src/Verso.Blazor.Shared/wwwroot/js/verso-inline-layout-bridge.js)
