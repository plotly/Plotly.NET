# Plotly.NET.Interactive

Display [Plotly.NET](https://plotly.net/) charts directly in .NET Interactive notebooks, including Polyglot Notebooks. This package registers an HTML formatter for chart values, so charts appear inline with zooming, panning, and hover information.

## Installation and quick start

Run this in an F# notebook cell:

```fsharp
#r "nuget: Plotly.NET.Interactive, 6.0.0"
```

Referencing the package loads the formatter automatically and installs the core Plotly.NET dependency. In the next F# cell, create a chart and leave it as the final expression:

```fsharp
open Plotly.NET

Chart.Point(
    x = [ 0; 1; 2; 3 ],
    y = [ 1; 4; 9; 16 ]
)
|> Chart.withTitle "Squares"
```

The notebook displays the chart below the cell. `Chart.show` opens a separate browser window; it is unnecessary for inline output. The formatter loads plotly.js from the Plotly CDN, so the notebook browser needs access to that CDN.

## Compatibility

Version 6.0.0 targets `netstandard2.1` and requires a compatible .NET Interactive host. It depends on Plotly.NET `>= 6.0.0` and `< 7.0.0`, and is built against `Microsoft.DotNet.Interactive` and `Microsoft.DotNet.Interactive.Formatting` version `1.0.0-beta.26120.1`. The package does not target .NET Framework.

For the C# chart API, also reference `Plotly.NET.CSharp` 0.14.0. That package requires a .NET 10 C# kernel. End a C# cell with the chart value to use the same formatter.

## Documentation

- [Installation and notebook examples](https://plotly.net/)
- [Chart examples and guides](https://plotly.net/general/basics.html)
- [API reference](https://plotly.net/reference/index.html)
- [Release notes](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.Interactive/RELEASE_NOTES.md)

Licensed under the [MIT License](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).
