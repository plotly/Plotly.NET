# Plotly.NET

Create interactive plotly.js charts in .NET. Plotly.NET provides an F# API for building,
styling, combining, and rendering charts, with lower-level access to traces, layouts,
and configuration. This is the core library used by the other Plotly.NET packages.

## Installation

```shell
dotnet add package Plotly.NET --version 6.0.0
```

The library targets .NET Standard 2.0. For an idiomatic C# API, install
[Plotly.NET.CSharp](https://www.nuget.org/packages/Plotly.NET.CSharp/) as well.

## Quick start

In an F# project with the package installed:

```fsharp
open Plotly.NET

let chart =
    Chart.Line(
        x = [ 1; 2; 3; 4 ],
        y = [ 2; 5; 3; 8 ]
    )
    |> Chart.withTitle "My first chart"

chart |> Chart.saveHtml "chart.html"
```

Open `chart.html` in a browser to interact with the chart. Use `chart |> Chart.show`
to save a temporary HTML file and open it in your default browser automatically.
For an `.fsx` script, add `#r "nuget: Plotly.NET, 6.0.0"` before the example.

By default, the HTML loads plotly.js from a CDN and needs an internet connection.
See [display options](https://plotly.net/general/display-options.html) for using an
embedded or local plotly.js reference.

## Related packages

- [Plotly.NET.CSharp](https://www.nuget.org/packages/Plotly.NET.CSharp/): C# chart factories and extension methods.
- [Plotly.NET.Interactive](https://www.nuget.org/packages/Plotly.NET.Interactive/): inline chart display in .NET Interactive / Polyglot Notebooks.
- [Plotly.NET.ImageExport](https://www.nuget.org/packages/Plotly.NET.ImageExport/): programmatic static image export.

## Documentation and support

- [Examples and tutorials](https://plotly.net/)
- [API reference](https://plotly.net/reference/index.html)
- [Release notes and migration information](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET/RELEASE_NOTES.md)
- [Source code and issue tracker](https://github.com/plotly/Plotly.NET)

Plotly.NET is licensed under the [MIT license](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).
