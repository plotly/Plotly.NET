(**
---
title: Verso notebooks
category: General
categoryindex: 1
index: 20
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.3"
#r "nuget: DynamicObj, 8.0.0"
#r "nuget: Giraffe.ViewEngine, 1.4.0"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

(**
# Verso notebooks

`Plotly.NET.Verso` formats chart values in Verso 1.2.3 and later compatible 1.x hosts.
Use `Plotly.NET.Interactive` for .NET Interactive / Polyglot Notebooks.
Chart-construction code is shared between both hosts; their registration steps differ.

Before the initial Verso package release is published, follow
the [local package workflow](https://github.com/plotly/Plotly.NET/blob/dev/tests/README.md#verso-tests).

## Registering the formatter

Reference the selected package version in an F# notebook cell, then register the
extension in a separate cell. These are notebook commands, not commands to run in FSI.

```text
[lang=text]
#r "nuget: Plotly.NET.Verso, 1.0.0"
```

```text
[lang=text]
#!extension Plotly.NET.Verso 1.0.0
```

Verso can ask for approval when installing a package version. `#r` alone does not
activate the formatter; installation through the Extensions panel is also supported.

## Creating a chart

End an F# cell with the chart value:

```fsharp
open Plotly.NET

Chart.Point(x = [0; 1; 2], y = [1; 4; 9])
|> Chart.withTitle "Squares"
```

The default asynchronously loads the Plotly CDN. Multiple cell outputs share a
pending load. For embedded offline chart output, replace the display options:

```fsharp
Chart.Point(x = [0; 1; 2], y = [1; 4; 9])
|> Chart.withDisplayOptions (
    DisplayOptions.init(PlotlyJSReference = PlotlyJSReference.Full)
)
```

`Full` embeds several megabytes of JavaScript in each output. It removes the chart's
Plotly download requirement; the notebook host and explicitly added external resources
may still need a connection. Explicit `CDN` URLs are supported. `NoReference` uses an
existing Plotly instance or pending load, and never starts a download. Replace any
old `Require` options with `CDN` or `Full`; RequireJS is unsupported in this adapter.

## Troubleshooting and migration

Text-only output usually means the formatter was not registered or enabled. Check the
host version and the extension registration step. Script download/rendering failures
appear inside the chart output; rerun to retry a failed download or select `Full`.
Do not override Monaco's global `define` function.

When moving from Polyglot, change the package reference to `Plotly.NET.Verso` and add
the registration cell. The packages stay separate to avoid requiring both hosts'
dependency graphs. See the [package guide](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.Verso/README.md)
for HTML helper functions and the full reference-option contract.
*)
