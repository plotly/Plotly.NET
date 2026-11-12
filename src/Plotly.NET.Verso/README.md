# Plotly.NET.Verso

Display Plotly.NET charts inline in [Verso notebooks](https://github.com/DataficationSDK/Verso), with interactive zooming, panning and hover information.

## Compatibility

Plotly.NET.Verso 1.0.0 requires **Verso 1.2.3 or later in the compatible 1.x host line** and Plotly.NET `>= 6.0.0` and `< 7.0.0`. The extension targets `net8.0` and also runs on newer compatible .NET runtimes. It uses Verso's supported `IDataFormatter` extension contract and isolated assembly loading.

Before the initial release is published, use the local-package workflow below rather than assuming version 1.0.0 is available on NuGet.org.

## Installation and quick start

In an F# notebook, reference the package in one cell:

```fsharp
#r "nuget: Plotly.NET.Verso, 1.0.0"
```

Register its formatter in the next cell:

```text
#!extension Plotly.NET.Verso 1.0.0
```

Then leave a chart as a cell's final expression:

```fsharp
open Plotly.NET

Chart.Point(x = [0; 1; 2; 3], y = [1; 4; 9; 16])
|> Chart.withTitle "Squares"
```

Verso may ask you to approve the extension package. Referencing it with `#r` alone does not register the formatter. Installing and enabling it through Verso's Extensions panel is another supported registration path.

## Online and offline charts

The default loads the Plotly CDN version bundled with the chart's Plotly.NET assembly. Loading is asynchronous and shared between outputs in the same page. For offline chart rendering, set `Full`:

```fsharp
Chart.Point(x = [0; 1; 2], y = [1; 4; 9])
|> Chart.withDisplayOptions (
    DisplayOptions.init(PlotlyJSReference = PlotlyJSReference.Full)
)
```

Each embedded output includes several megabytes of Plotly JavaScript so that saved charts can render without downloading it. Verso itself and any additional resources explicitly added to the chart can have their own network requirements.

| Reference option | Verso behavior |
|---|---|
| Default / absent | Load the CDN for the chart's Plotly.NET version |
| `CDN url` | Use the supplied JavaScript URL |
| `Full` | Embed the originating Plotly.NET assembly's JavaScript |
| `NoReference` | Use already loaded Plotly or a pending extension load; never start a download |
| `Require` | Display a migration message: use `CDN` or `Full` |

`Plotly.NET.Verso.Formatters.toVersoHTML chart` returns the notebook HTML fragment. `toVersoHTMLOffline chart` forces embedded Plotly and returns a complete HTML document suitable for saving to a file. Both retain chart data, layout, config and descriptions without changing the original chart.

## Moving from Polyglot Notebooks

Use `Plotly.NET.Interactive` with .NET Interactive / Polyglot Notebooks and `Plotly.NET.Verso` with Verso. Existing chart-construction code can remain the same. Replace the notebook package reference and add the Verso registration step shown above. Replace explicit `Require` display options with `CDN` or `Full`.

The packages remain separate so each host loads only its own adapter dependencies. Installing `Plotly.NET.Interactive` does not activate the Verso formatter.

## Local development and troubleshooting

From the repository root:

```text
./build.cmd RunVersoTestsFast
./build.cmd RunVersoBrowserTestsFast
./build.cmd PackVersoIntegrationPackages
./build.cmd RunVersoIntegrationTests
```

Use `./build.sh` on Linux. The real-host tests use isolated caches; these targets never delete your global NuGet cache. See the [test guide](https://github.com/plotly/Plotly.NET/blob/dev/tests/README.md) for browser provisioning, artifacts and the VS Code smoke procedure.

If a chart appears as text, check that the extension is registered and enabled and that the host is at least 1.2.3. For download failures, inspect the output error and check the configured URL or use `Full`; rerunning the cell retries a failed load. Do not install RequireJS or override Monaco's `define` function.

Licensed under the [MIT License](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).
