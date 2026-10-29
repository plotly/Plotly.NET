# Plotly.NET.CSharp

Create interactive charts in C# with chart constructors and fluent styling methods built on [Plotly.NET](https://plotly.net/). Charts render with plotly.js in a browser or a .NET Interactive notebook.

## Installation

Version 0.14.0 targets **.NET 10**. Your application must target .NET 10 or later. Installing this package also installs the core Plotly.NET library, with a supported version range of `>= 6.0.0` and `< 7.0.0`.

In a C# project:

```shell
dotnet add package Plotly.NET.CSharp --version 0.14.0
```

## Quick start

Put this code in `Program.cs` and run the application:

```csharp
using Plotly.NET.CSharp;

var chart = Chart.Point<double, double, string>(
    x: new[] { 0.0, 1.0, 2.0, 3.0 },
    y: new[] { 1.0, 4.0, 9.0, 16.0 },
    Name: "Squares"
);

chart.Show();
```

`Show()` opens the chart in your browser. To save an HTML file instead, use `chart.SaveHtml("chart.html")`. The third generic argument, `string`, supplies the optional point-text type even when no text is provided.

For inline notebook output, reference [Plotly.NET.Interactive](https://www.nuget.org/packages/Plotly.NET.Interactive/6.0.0) as well and end the cell with the chart value. The notebook's C# kernel must support .NET 10.

## Documentation

- [Chart examples and guides](https://plotly.net/)
- [API reference](https://plotly.net/reference/index.html)
- [Encoded arrays and supported C# overloads](https://plotly.net/general/encoded-arrays.html)
- [Release notes](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.CSharp/RELEASE_NOTES.md)

Licensed under the [MIT License](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).
