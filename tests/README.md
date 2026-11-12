# The Plotly.NET Test Suite

This folder contains all tests performed in this monorepo.

As It got quite large and complex, this reamde is a try to make things less opaque for contributors.

## Testing frameworks used

- Most of the F# test projects use [Expecto](https://github.com/haf/expecto), some use [xUnit](https://xunit.net/)

- The C# test projects use [xUnit](https://xunit.net/)

- The JS test projects use [Mocha](https://mochajs.org/)

## Running tests

### Using the `build` project

This is the main way of running tests from the command line. 

Either use `build.cmd` or `build.sh` depending on your OS to run test targets, e.g. :

```
build.cmd runTestsAll
build.sh runTestsCore
```

Available test targets are:

- `RunTestsAll` - runs all tests
- `RunTestsCore` - runs all tests in the `CoreTests` folder
- `RunTestsExtensionLibs` - runs all tests in the `ExtensionLibTests` folder
- `RunTestsJSTests` - runs all tests in the `JSTests` folder

### Verso tests

The Verso adapter has three test layers:

| Suite | What it verifies | FAKE targets |
|---|---|---|
| `VersoTests` | Formatter contracts, options and charts crossing isolated assembly contexts | `RunVersoTests`, `RunVersoTestsFast` |
| `VersoBrowserTests` | Actual chart rendering with delayed/failed script loads and embedded offline output | `RunVersoBrowserTests`, `RunVersoBrowserTestsFast` |
| `VersoIntegrationTests` | Locally packed core/adapter packages in the pinned Verso CLI and its web UI | `RunVersoIntegrationTests` |

Use `./build.cmd <target>` on Windows or `./build.sh <target>` on Linux. The first two suites are also part of `RunTestsExtensionLibs[Fast]` and `RunTestsAll[Fast]`. The real-host suite is a separate Linux CI job and can also run locally on Windows. All test projects use .NET 10; the shipped Verso adapter targets .NET 8.

Provision the pinned Chromium revision with `PrepareVersoBrowser`. Local browser tests provision it if absent; a download/launch error fails the suite instead of skipping it. Set `PUPPETEER_CACHE_DIR` to share the browser cache across runs. Linux needs Chromium's shared libraries (see the CI workflow or devcontainer Dockerfile).

Browser tests intercept Plotly downloads with the actual bundled script and dynamically insert formatter output as notebook cells do. They do not depend on CDN availability. Failure screenshots, HTML and browser logs go to `PLOTLY_VERSO_TEST_ARTIFACTS`, or the suite's `TestResults/artifacts` directory. FAKE writes TRX results into each project's `TestResults` directory.

`PackVersoIntegrationPackages` builds and packs only the core and Verso adapter without publishing or interactive release prompts. `RunVersoIntegrationTests` additionally runs the packaged-host smoke. Generated feeds, manifests, notebooks and diagnostics live under ignored `tests/VersoTests/artifacts`. The harness isolates NuGet and Verso's own temporary package cache, verifies the hashes of loaded assemblies against the fresh packages, and terminates the local server when finished. The `Repack.ps1` helper delegates to FAKE and does not clear the user's global NuGet cache.

The host suite needs network access to restore the pinned Verso CLI and dependencies. The web host itself also loads Monaco and Mermaid externally. Offline chart checks run after host initialization and allow those exact host asset paths while blocking external chart requests.

#### VS Code release smoke

Use the installed Verso extension version 1.2.3 or later compatible 1.x release. `PackVersoIntegrationPackages` generates `tests/VersoTests/artifacts/test.verso` with the absolute feed path and package version. Open that generated copy. Its first cell uses **C#** to register the local source with Verso's shared extension resolver:

```text
#i "nuget: <absolute local feed path>"
```

Register `#!extension Plotly.NET.Verso <packed version>` in the next **F#** cell; this also makes the package assemblies available to the kernel. The generated C# source-registration cell is an explicit setup choice, not a requirement that notebooks use C#. F# `#i` is supported, and you can keep an F# setup that successfully resolves the local extension. If `#!extension` cannot find the local package, the generated C# cell explicitly registers its feed with the shared resolver. Use a fresh process temporary directory for a repeated local-package smoke: Verso's extraction cache can otherwise shadow a rebuilt package with the same version. The automated harness isolates this directory and verifies provenance.

Verify first render, two chart cells, rerunning a cell, a `Full` chart with Plotly network access unavailable, and saving/closing/reopening outputs. Confirm there are no Monaco/AMD errors or duplicate charts. Record the VS Code/Verso versions and observed results in `plans/VersoExtension.md`; CLI/web-host tests do not substitute for this host-specific check.

Before committing, run full clean `RunTestsAll` and the dedicated `RunVersoIntegrationTests` target. CI publishes failure diagnostics for the Windows/Linux suites and host artifacts for the integration job.

### Using Visual Studio Test Explorer

You can also run tests from within Visual Studio using the Test Explorer.

## Folder structure

### Common

`Common` contains all common code used in the test suite.
This includes the `TestUtils` and `TestCharts` modules, which contain utility functions for testing and the actual chart objets to use in tests.

The projects contained here are `FSharpTestBase.fsproj` and `CSharptestBase.csproj` - classlibs that contain the above for each language respectively.

### ConsoleApps

`ConsoleApps` is a folder containing projects that use any amount of the other projects in this repo.
They are not TestProjects as in that they contain UnitTests, but are more thought of as playgrounds 
to manually test functionality of the projects in a console application.

### CoreTests

`CoreTests` contains all UnitTests for the core `Plotly.NET` F# project. This is by far the largest test suite.

Currently, the following test projects are contained:

#### CoreTests.fsproj

The largets test suite by far that tests all things Plotly.NET, such as HTML code generation, JSON serialization, Object validity, etc.

#### CSharpInteroperabilityTests.csproj

Testing usage of the core F# API from C#

### ExtensionLibTests

`ExtensionLibTests` contains all UnitTests for extension libraries, such as `Plotly.NET.CSharp` or `Plotly.NET.ImageExport`.

### JSTests

`JSTests` contains all UnitTests that run on node.js. The main application here is the validation of generated JSON via the `Plotly.validate` function in the `plotly.js` library.
