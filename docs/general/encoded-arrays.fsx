(**
---
title: Encoded typed arrays
category: General
categoryindex: 1
index: 10
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.3"
#r "nuget: DynamicObj, 7.0.1"
#r "nuget: Giraffe.ViewEngine, 1.4.0"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(**
# Encoded typed arrays

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This page explains how to use `EncodedTypedArray` for efficient data transfer with plotly.js 2.28+.

### Table of contents

- [What are encoded typed arrays?](#What-are-encoded-typed-arrays)
- [Creating EncodedTypedArray values](#Creating-EncodedTypedArray-values)
- [Using encoded arrays with Scatter](#Using-encoded-arrays-with-Scatter)
- [Using encoded arrays with Bar and Column charts](#Using-encoded-arrays-with-Bar-and-Column-charts)
- [Using encoded arrays with Heatmap](#Using-encoded-arrays-with-Heatmap)
- [Using encoded arrays with 3D charts](#Using-encoded-arrays-with-3D-charts)
- [Using encoded arrays with statistical charts](#Using-encoded-arrays-with-statistical-charts)
- [Using encoded arrays for error bars and trace-level styling](#Using-encoded-arrays-for-error-bars-and-trace-level-styling)

## What are encoded typed arrays?

plotly.js 2.28.0 introduced support for passing data arrays as **base64-encoded typed arrays** instead of plain JSON arrays.
This format (`bdata`/`dtype`/`shape`) is significantly more compact and faster to parse for large numeric datasets,
since it avoids the overhead of JSON number serialization.

For example, a float64 array `[1.0, 2.0, 3.0]` transmitted as plain JSON looks like `[1.0,2.0,3.0]`,
while the encoded form is `{"bdata":"AAAAAAAA8D8AAAAAAAAAQA==...","dtype":"f8"}` — smaller and faster to deserialize in the browser.

Plotly.NET exposes this via the `EncodedTypedArray` type.

## Creating EncodedTypedArray values

`EncodedTypedArray` can be constructed from any standard .NET typed array:
*)

open Plotly.NET

// Float64 (double) arrays — most common for continuous data
let xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0; 4.0; 5.0 |]
let yEncoded = EncodedTypedArray.ofFloat64Array [| 2.0; 4.0; 1.0; 5.0; 3.0 |]

// Int32 arrays — for integer data like indices or counts
let sourceEncoded = EncodedTypedArray.ofInt32Array [| 0; 1; 2 |]

// Float32 arrays — smaller footprint when full precision is not needed
let valuesEncoded = EncodedTypedArray.ofFloat32Array [| 1.0f; 2.5f; 0.8f |]

(**
Supported constructors:

| Constructor | .NET type | plotly.js dtype |
|---|---|---|
| `EncodedTypedArray.ofFloat64Array` | `float[]` | `f8` (64-bit float) |
| `EncodedTypedArray.ofFloat32Array` | `float32[]` | `f4` (32-bit float) |
| `EncodedTypedArray.ofInt32Array` | `int[]` | `i4` (32-bit int) |
| `EncodedTypedArray.ofInt16Array` | `int16[]` | `i2` (16-bit int) |
| `EncodedTypedArray.ofInt8Array` | `sbyte[]` | `i1` (8-bit int) |
| `EncodedTypedArray.ofUInt32Array` | `uint32[]` | `u4` (unsigned 32-bit) |
| `EncodedTypedArray.ofUInt16Array` | `uint16[]` | `u2` (unsigned 16-bit) |
| `EncodedTypedArray.ofUInt8Array` | `byte[]` | `u1` (unsigned 8-bit) |

## Using encoded arrays with Scatter

The encoded convenience overload for `Chart.Scatter` takes `xEncoded` and `yEncoded` as required
positional arguments instead of plain `x`/`y` sequences:
*)

let scatterEncoded =
    Chart.Scatter(
        xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0; 4.0; 5.0 |],
        yEncoded = EncodedTypedArray.ofFloat64Array [| 2.0; 4.0; 1.0; 5.0; 3.0 |],
        mode = StyleParam.Mode.Markers,
        Name = "encoded scatter",
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
scatterEncoded
#endif // IPYNB

(***hide***)
scatterEncoded |> GenericChart.toChartHTML
(***include-it-raw***)

(**
The same encoded overload is available for `Chart.Point`, `Chart.Line`, `Chart.Bubble`, `Chart.Area`, `Chart.SplineArea`, and `Chart.StackedArea`.

## Using encoded arrays with Bar and Column charts

For bar and column charts, the main data array (`values`) is always required and encoded.
The keys array is optional:
*)

let barEncoded =
    Chart.Bar(
        valuesEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 3.0; 7.0; 2.0 |],
        KeysEncoded = EncodedTypedArray.ofInt32Array [| 0; 1; 2; 3 |],
        Name = "encoded bar"
    )

(*** condition: ipynb ***)
#if IPYNB
barEncoded
#endif // IPYNB

(***hide***)
barEncoded |> GenericChart.toChartHTML
(***include-it-raw***)

(**
The same pattern applies to `Chart.Column`, `Chart.StackedBar`, and `Chart.StackedColumn`.

## Using encoded arrays with Heatmap

For heatmaps, the z matrix is required and encoded; x and y axes are optional and encoded.
When `zEncoded` is given as a flat encoded array, `shape` must also be set so plotly.js can reconstruct the matrix:
*)

let heatmapEncoded =
    Chart.Heatmap(
        zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0; 7.0; 8.0; 9.0 |], shape = [ 3; 3 ]),
        Name = "encoded heatmap",
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
heatmapEncoded
#endif // IPYNB

(***hide***)
heatmapEncoded |> GenericChart.toChartHTML
(***include-it-raw***)
(**
Note that for heatmaps the z data is passed as a flat 1D encoded array. plotly.js uses the `shape` field
(rows × columns) to interpret the layout, so `shape` must be specified:

```
// Explicit 3x3 shape
let z3x3 =
    EncodedTypedArray.ofFloat64Array([| 1.0 .. 9.0 |], shape = [ 3; 3 ])
```

The same `shape` requirement applies to other matrix-style traces such as `Chart.Surface`, `Chart.Contour`,
`Chart.Histogram2D`, and `Chart.Histogram2DContour`.

## Using encoded arrays with 3D charts

Encoded typed arrays work the same way on 3D traces. For example, `Chart.Scatter3D` accepts encoded x, y, and z coordinates:
*)

let scatter3DEncoded =
    Chart.Scatter3D(
        xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
        yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
        zEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
        mode = StyleParam.Mode.Markers,
        Name = "encoded scatter3d",
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
scatter3DEncoded
#endif // IPYNB

(***hide***)
scatter3DEncoded |> GenericChart.toChartHTML
(***include-it-raw***)

(**
For matrix-based 3D traces such as `Chart.Surface` and `Chart.Volume`, encoded arrays are also supported,
and `shape` must be set wherever plotly.js needs to reconstruct multi-dimensional data from a flat payload.

## Using encoded arrays with statistical charts

Distribution and statistical charts support encoded sample arrays as well. Here is a histogram example:
*)

let histogramEncoded =
    Chart.Histogram(
        dataEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 2.0; 3.0; 3.0; 3.0; 4.0 |],
        orientation = StyleParam.Orientation.Vertical,
        Name = "encoded histogram",
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
histogramEncoded
#endif // IPYNB

(***hide***)
histogramEncoded |> GenericChart.toChartHTML
(***include-it-raw***)

(**
The same pattern works for `Chart.BoxPlot`, `Chart.Violin`, and finance-style traces such as
`Chart.OHLC` and `Chart.Candlestick`.

## Using encoded arrays for error bars and trace-level styling

Some features are available through trace-level styling rather than only through chart-root overloads.
This is especially useful when you want encoded error bars, encoded metadata arrays, or other advanced options:
*)

open Plotly.NET.TraceObjects

let scatterWithEncodedErrorBars =
    let xErrorEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |]
    let yErrorEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5; 0.6 |]
    let yErrorMinusEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.2; 0.1 |]

    Trace2D.initScatter(
        Trace2DStyle.Scatter(
            Name = "encoded scatter + error bars",
            Mode = StyleParam.Mode.Lines_Markers,
            XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
            XError =
                Error.init(
                    Type = StyleParam.ErrorType.Data,
                    ArrayEncoded = xErrorEncoded
                ),
            YError =
                Error.init(
                    Type = StyleParam.ErrorType.Data,
                    ArrayEncoded = yErrorEncoded,
                    ArrayminusEncoded = yErrorMinusEncoded
                )
        )
    )
    |> GenericChart.ofTraceObject true
    |> Chart.withDisplayOptionsStyle(PlotlyJSReference = PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
scatterWithEncodedErrorBars
#endif // IPYNB

(***hide***)
scatterWithEncodedErrorBars |> GenericChart.toChartHTML
(***include-it-raw***)

(**
The trace-style modules (`Trace2DStyle`, `Trace3DStyle`, `TraceDomainStyle`, and others) also accept encoded arrays
for many metadata fields such as ids, custom data, selected points, text, dimensions, and trace-specific attributes.

For more advanced usage including encoded arrays on 3D, domain, and map traces, see the trace-level
style modules (`Trace2DStyle`, `Trace3DStyle`, `TraceDomainStyle`, etc.) which accept `*Encoded` optional parameters
for most data-array fields.
*)
