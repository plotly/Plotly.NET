# Complete Plotly.NET.Verso and its testing pipeline

Approved 2026-11-12. All four implementation chunks are complete and recorded as five local commits on `verso-ext`. Automated local validation passed on Windows and Linux. GitHub Actions execution and the complete manual VS Code checklist remain unverified; the user reported successful F# setup in VS Code. Packages remain unpublished.

## Findings and decisions

Verso fixed the Monaco/AMD issue in 1.0.15, but external Plotly loading must still be awaited. The prototype uses RequireJS and its tests mostly bypass the Verso helpers. Its net8.0 test project references a net10.0 shared test project. Current Verso also isolates extension assemblies, so notebook chart values need a bridge across assembly load contexts.

- Keep Plotly.NET.Verso separate from Plotly.NET.Interactive. A combined package is technically possible but brings both host dependency graphs and requires both-host compatibility testing. Add prominent migration guidance to Interactive instead.
- Support/test Verso 1.2.3; pin Abstractions, Testing, and integration CLI to 1.2.3. Keep the shipped extension on net8.0 and run tests on net10.0.
- Pin Verso tests to Expecto 11.1.1, YoloDev.Expecto.TestSdk 0.16.1, Microsoft.NET.Test.Sdk 18.12.0; retain VSTest and disable optional MTP integration. Browser tests use PuppeteerSharp 25.15.0.
- Preserve GenericChartFormatter, toVersoHTML, toVersoHTMLOffline, extension ID and priority. Synchronize metadata with the built package version.
- Automate CLI/web-host coverage; perform VS Code installation/render/rerun/offline/save/reopen smoke separately.
- No publishing, automatic theme adaptation, or unrelated core/runtime upgrades.

## Rendering contract

`toVersoHTML` returns an adaptive notebook fragment. `toVersoHTMLOffline` returns a complete self-contained document. Preserve data/layout/config, descriptions and additional HTML tags without mutating charts. Serialize and retrieve embedded JavaScript through the originating core assembly.

| Reference | Behavior |
|---|---|
| Missing | CDN matching the originating core runtime |
| CDN url | Load the supplied URL |
| Full | Embed Plotly for automatic offline rendering |
| NoReference | No download; use loaded Plotly or an existing pending load, otherwise actionable error |
| Require | Actionable migration message to use CDN or Full |

## Planned self-contained commits

- [x] **1. Dependencies and extension contracts.** Updated dependencies/frameworks and focused FAKE targets; implemented MIME/cancellation/metadata contracts and narrowly validated originating-assembly bridge. Tested actual helpers, unrelated values, cancellation, metadata and Chart/MultiChart in genuinely separate assembly contexts.
- [x] **2. Rendering and browser regressions.** Replaced RequireJS with asynchronous shared loading, readiness/error handling, retries, removed outputs and offline rendering. Added deterministic Chromium tests with dynamic cell insertion and locally fulfilled bundled Plotly; verified real rendered content, unique IDs, all reference modes and preserved chart options. Payload expectations use actual core serialization rather than handwritten snapshots.
- [x] **3. Reproducible packages and real host.** Added noninteractive FAKE packing, isolated feed/NuGet/temp/CLI directories and portable fixtures. Executed/saved through CLI, verified package hashes, then served/rendered/reran/reopened both modes. Bounded timeouts and child-process cleanup retain diagnostics.
- [x] **4. CI and documentation.** Registered projects/solutions/aggregate targets and Windows/Linux unit/browser jobs plus a separate Linux packaged-host job. Explicitly provision/cache Chromium and retain failure artifacts. Replaced the destructive repack script; added package README, guide, migration notes and release notes. Verified docs, packages and full clean tests. Actual platform/host execution is tracked below.

## Acceptance and validation log

- [x] Fresh local package registers and formats notebook-created charts in Verso 1.2.3.
- [x] Delayed CDN loading and fully embedded offline output render correctly.
- [x] Unit and browser tests exercise actual extension output and isolated assembly loading.
- [x] Windows and Linux unit/browser runs pass (Linux validated in an isolated Ubuntu 24.04 container).
- [x] Packaged CLI/web-host integration passes on Windows and Linux and proves local package provenance.
- [ ] Execute the configured GitHub Actions jobs on the final branch; local Docker validation is not a GitHub CI run.
- [ ] VS Code smoke: install, first render, multiple charts, rerun, offline, save/reopen.
- [x] Full clean `./build.cmd runTestsAll` and dedicated integration target pass before committing.
- [x] Package contents/dependencies and documentation generation verified.

### Implementation notes and results

- `RunVersoTestsFast`: 14/14 passed on Windows. Covers direct formatter contracts, independent Chart/MultiChart assembly contexts, date preservation, custom DisplayOptions subclasses and chart immutability.
- `RunVersoBrowserTestsFast`: 17/17 passed on Windows, PuppeteerSharp 25.15.0 / Chromium 155.0.8059.84. Initial failures exposed only a harness mistake treating Plotly's data-URL image probe as external networking; corrected while retaining strict external request assertions.
- `RunVersoIntegrationTests`: passed in 61.6 seconds. Online fixture 4/4 cells and offline fixture 3/3 cells passed, with local core/extension SHA-256 provenance. Both actual web-host flows verified initial rendering, UI-kernel provenance, two reruns, saving the latest chart ID, cold reopening and matching data, with no browser/console errors. Artifacts: `tests/VersoTests/artifacts/runs/20261112T125545-27c53a76` (including chart screenshots).
- `Chart.withDisplayOptions` merges in this checkout. Independent test fixtures use `GenericChart.setDisplayOptions` to select truly absent or explicit references; the extension itself never mutates chart options.
- Generated manual fixtures use C# `#i` to register the feed explicitly with the shared extension resolver. Correction after the user's VS Code check: F# `#i` is supported and worked in their setup. The earlier blanket claim that F# cannot be used was not established by our tests: automated host fixtures obtain their feed through `NuGet.Config`, without either language's `#i`. Separate resolver implementations do not by themselves prove failure in a particular host/configuration. Updated the test guide and build comments accordingly; the reason the user's setup resolves successfully has not been independently traced.
- VS Code has Verso 1.2.3 installed. Agent computer-use approval timed out, but the user subsequently reported successful F# setup and that the integration looked good. The complete install/render/rerun/offline/save/reopen checklist has not been explicitly recorded.
- Host-harness details learned from real execution: open notebooks through the toolbar after the interactive UI is ready (the 1.2.3 recovery URL can wait for consent before the UI mounts); await completed readable JSON when saving large Full outputs; allow the host's exact Monaco 0.45.0/Mermaid 11 asset paths while blocking chart networking in Full mode. Use independent server processes per fixture.
- Full clean `./build.cmd runTestsAll`: passed in 4m07s, **972 core + 6 ImageExport + 139 C# + 14 Verso + 17 Verso browser = 1,148 passed**, with the same 2 existing pending ImageExport tests skipped. TRX results are retained in each test project's `TestResults` directory.
- Generated the shared line fixture's actual data/layout/config through `tools/chart-baseline-generation/generate-chart-markup.fsx`; it matched the browser/host semantics (`scatter`, `lines`, x `[1,2,3]`, y `[4,6,5]`). Temporarily pointed the harness at current Release test dependencies because a clean build removes console Debug output, then restored the harness byte-for-byte. No handwritten large snapshot was introduced.
- Workflow YAML parses and both solution files list the new projects. Removed incidental x86/x64 platform additions from `dotnet sln add`; existing solution platforms are preserved.
- Documentation: full clean `BuildDocs` passed in 5m37s; a focused strict/evaluated check of the Verso guide also passed. The generated site includes the guide and both public Verso API pages. Refreshed an old local fsdocs project cache and corrected literate-script syntax so registration examples are displayed without trying to restore the unpublished package.
- Final `PrepareVersoBrowser` and `PackVersoIntegrationPackages` passed on Windows. Fresh package assembly hashes match both the build manifest and the successful Windows integration run byte-for-byte; the adapter contains the current README, core dependency `[6.0.0, 7.0.0)`, Verso.Abstractions minimum 1.2.3, and no test/browser dependencies.
- Additional isolated Ubuntu 24.04/.NET 10 Docker validation found FAKE's old MSBuild binary-log parser failing after the new provisioning target's build. Set `DisableInternalBinLog = true`, consistent with the other build calls, and verified the target on both Windows and Linux.
- Linux validation passed with Ubuntu 24.04.4, SDK 10.0.302/runtime 10.0.10 (only .NET 10 installed), and Chromium 155.0.8059.84: **14/14 unit tests, 17/17 browser tests**, explicit browser provisioning, and packaged CLI/web-host integration (78.8 seconds including packing). Both reference modes passed CLI output/provenance and actual web rendering/reruns/save/reopen. The temporary container was removed; tested source hashes matched the workspace. Log: `tests/VersoTests/artifacts/linux-validation/linux-validation.log`; 23 retained result files under `linux-validation/results`, host run `20261112T132534-53c85c64`.
- Before committing, repeated full clean `runTestsAll`: **1,148 passed, 2 existing skips**, in 4m08.6s (`tests/VersoTests/artifacts/precommit-full-tests.log`).
- The additional pre-commit host run exposed a harness race: cell-local completion could precede notebook-wide readiness, so clicking the next disabled Run button did nothing. The harness now waits up to 90 seconds for an enabled button and issues exactly one click; completion also waits for Run to be re-enabled. Existing execution/output assertions remain intact. The corrected Windows host run passed both CLI and browser modes in 96.2s including packing (`precommit-integration-retry.log`, run `20261112T140142-f28c570c`). The earlier successful Linux run preceded this harness-only readiness guard.
- GitHub Actions has not yet run for this feature branch. The complete manual VS Code checklist remains unrecorded as described above.

## Commit record

The formatter contracts and renderer are committed together because the new bridge, HTML helpers, and script resource depend on one another. Browser aggregate activation is committed with CI provisioning so earlier commits do not require unprovisioned browser libraries.

| Commit | Scope |
|---|---|
| `443ffc28` | Formatter contracts, isolated assembly bridge, asynchronous/offline rendering, dependency updates, and 14 unit tests |
| `3616296b` | 17 browser regressions, focused FAKE targets, Chromium provisioning, solution registration, and test diagnostics |
| `6a64b36e` | Noninteractive packing, isolated CLI/web-host tests, execution-readiness guard, and portable manual fixtures |
| `86eff4b7` | Windows/Linux Chromium provisioning, aggregate browser tests, separate Linux host job, and CI artifacts |
| Documentation commit containing this plan | Installation/migration guides, packaged README, release notes, and final validation record |

## Sources

- [Original upstream discussion](https://github.com/DataficationSDK/Verso/discussions/30)
- [Verso 1.2.3](https://github.com/DataficationSDK/Verso/releases/tag/verso-v1.2.3)
- [Extension packaging](https://github.com/DataficationSDK/Verso/blob/verso-v1.2.3/docs/extensions/packaging-and-publishing.md)
- [Isolated formatter precedent](https://github.com/DataficationSDK/Verso/blob/verso-v1.2.3/src/Verso.DataFrame/Formatters/DataFrameFormatter.cs)
- [CLI commands](https://github.com/DataficationSDK/Verso/blob/verso-v1.2.3/src/Verso.Cli/README.md)
