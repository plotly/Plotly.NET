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

*Summary:* This page explains numeric encoded arrays in Plotly.NET and the selected C# chart overloads, using plotly.js 2.28.0.

### Table of contents

- [What are encoded typed arrays?](#What-are-encoded-typed-arrays)
- [Creating EncodedTypedArray values](#Creating-EncodedTypedArray-values)
- [Using encoded arrays with Scatter](#Using-encoded-arrays-with-Scatter)
- [Using encoded arrays with Bar and Column charts](#Using-encoded-arrays-with-Bar-and-Column-charts)
- [Using encoded arrays with Heatmap](#Using-encoded-arrays-with-Heatmap)
- [Using encoded arrays with 3D charts](#Using-encoded-arrays-with-3D-charts)
- [Using encoded arrays with statistical charts](#Using-encoded-arrays-with-statistical-charts)
- [Using encoded arrays for error bars and trace-level styling](#Using-encoded-arrays-for-error-bars-and-trace-level-styling)
- [Using encoded arrays from C#](#Using-encoded-arrays-from-C)
- [Nested data and precedence](#Nested-data-and-precedence)
- [Supported scope and limitations](#Supported-scope-and-limitations)
- [Loading Virtual-WebGL](#Loading-Virtual-WebGL)

## What are encoded typed arrays?

plotly.js 2.28.0 introduced support for passing data arrays as **base64-encoded typed arrays** instead of plain JSON arrays.
The representation contains a base64 byte payload (`bdata`), a numeric type tag (`dtype`), and an optional
matrix shape (`shape`). Its size and parsing cost depend on the data and dtype; this release does not
provide a benchmark or guarantee that it is smaller or faster than JSON arrays.

The core Plotly.NET assembly owns `EncodedTypedArray`, its factories, and serialization. Both F# and C#
use this same representation.

## Creating EncodedTypedArray values

`EncodedTypedArray` can be constructed from the supported numeric arrays listed below:
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

| Constructor | F# array type | plotly.js dtype |
|---|---|---|
| `EncodedTypedArray.ofFloat64Array` | `float[]` | `f8` (64-bit float) |
| `EncodedTypedArray.ofFloat32Array` | `float32[]` | `f4` (32-bit float) |
| `EncodedTypedArray.ofInt32Array` | `int[]` | `i4` (32-bit int) |
| `EncodedTypedArray.ofInt16Array` | `int16[]` | `i2` (16-bit int) |
| `EncodedTypedArray.ofInt8Array` | `sbyte[]` | `i1` (8-bit int) |
| `EncodedTypedArray.ofUInt32Array` | `uint32[]` | `u4` (unsigned 32-bit) |
| `EncodedTypedArray.ofUInt16Array` | `uint16[]` | `u2` (unsigned 16-bit) |
| `EncodedTypedArray.ofUInt8Array` | `byte[]` | `u1` (unsigned 8-bit) |
| `EncodedTypedArray.ofUInt8ClampedArray` | `byte[]` | `u1c` (clamped unsigned 8-bit) |

There are no factories for strings, arbitrary objects, decimal, or signed/unsigned 64-bit integers.
Choose a supported dtype explicitly when converting data, accounting for its range and precision.

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
        Name = "encoded bar",
        UseDefaults = false
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
        zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
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
// Row-major 2x3 matrix: [[1; 2; 3]; [4; 5; 6]]
let z2x3 =
    EncodedTypedArray.ofFloat64Array([| 1.0 .. 6.0 |], shape = [ 2; 3 ])
```

Supply a matching row count and column count for matrix-valued inputs such as the z grid of
`Chart.Surface` or `Chart.Contour`. The factories preserve the supplied shape; they do not validate
that its dimensions match the payload length.

`Chart.Histogram2D` and `Chart.Histogram2DContour` instead consume one-dimensional x/y samples and
optional z aggregation values, one per sample. Do not reshape those sample arrays into a matrix;
plotly.js computes the bins.

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
`Chart.Surface` uses a two-dimensional z grid. `Chart.Volume` and `Chart.IsoSurface` use parallel
one-dimensional x/y/z/value arrays describing samples in space; their coordinates and values do not
require a matrix shape simply because the chart is three-dimensional.

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
    |> GenericChart.ofTraceObject false
    |> Chart.withDisplayOptions(DisplayOptions.init(PlotlyJSReference = PlotlyJSReference.NoReference))

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
for selected data-array fields. An encoded option only changes the transport representation; the
underlying plotly.js field must still accept the resulting values.
*)

(**
## Using encoded arrays from C#

Reference both `Plotly.NET` and `Plotly.NET.CSharp`. The factories are F# methods in the shared core:
C# supplies `shape: default` for a one-dimensional array, or an explicit
`FSharpOption<IEnumerable<int>>` for a matrix. The remaining generic type argument on Scatter/Heatmap
describes optional text; specify it even when no text is supplied.

This 1D example is compiled and checked in `EncodedArrayExamplesTests`:

```csharp
[lang=csharp]
using Plotly.NET;
using Chart = Plotly.NET.CSharp.Chart;

var x = EncodedTypedArray.ofInt32Array(new[] { 0, 1, 2 }, shape: default);
var y = EncodedTypedArray.ofFloat32Array(new[] { 1.5f, 4.5f, 2.5f }, shape: default);
var scatter = Chart.Scatter<string>(
    xEncoded: x, yEncoded: y, mode: StyleParam.Mode.Markers,
    Name: "encoded scatter", UseDefaults: false);
```

For a 2-by-3 heatmap, flatten the rows in order and supply three x coordinates and two y coordinates.
This example is also compiled and checked in the C# tests:

```csharp
[lang=csharp]
using System.Collections.Generic;
using Microsoft.FSharp.Core;
using Plotly.NET;
using Chart = Plotly.NET.CSharp.Chart;

var z = EncodedTypedArray.ofFloat32Array(
    new[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f },
    shape: new FSharpOption<IEnumerable<int>>(new[] { 2, 3 }));
var heatmap = Chart.Heatmap<string>(
    zEncoded: z,
    xEncoded: EncodedTypedArray.ofInt32Array(new[] { 10, 20, 30 }, shape: default),
    yEncoded: EncodedTypedArray.ofInt32Array(new[] { 100, 200 }, shape: default),
    ReverseYAxis: true, ShowScale: false, UseDefaults: false);
```

## Nested data and precedence

Use `Dimension.initSplom` / `Dimension.initParallel` with `ValuesEncoded` for nested dimension data.
Existing F# and C# SPLOM/parallel chart wrappers accept these objects. ParallelCoord and
ParallelCategories also offer label/encoded-value pair conveniences.

For Sankey, use `SankeyNodes.init` with `XEncoded` / `YEncoded` and `SankeyLinks.init` with
`SourceEncoded` / `TargetEncoded` / `ValueEncoded`, then pass the objects to `Chart.Sankey(nodes, links, ...)`.
Labels remain plain strings. These shared object APIs also expose numeric `CustomDataEncoded` and
`ColorEncoded`; numeric encoding does not turn color names or other strings into supported typed arrays,
and each field retains its plotly.js value requirements.

At the trace/object layer, if one init/style call supplies both the plain and encoded parameter for
the same property, the encoded value wins. For example, `Value = [ 99.0 ]` together with
`ValueEncoded = EncodedTypedArray.ofFloat64Array [| 8.0 |]` serializes a single encoded `value` property.
A later style call can replace that property again. The explicit chart overloads instead take
encoded primary inputs directly.

## Supported scope and limitations

The examples earlier on this page use the F# API. Direct encoded C# chart overloads currently cover:

- `Scatter`, `Bar`, `StackedBar`, `Column`, `StackedColumn`, `Heatmap`, `Histogram2D`, and `Scatter3D`.
- `ParallelCoord` / `ParallelCategories` label/encoded-value pairs.
- Nested objects through existing wrappers, including SPLOM and Sankey.

Other direct C# wrappers, including Histogram, Surface, and map/polar/carpet families, are a later
milestone. C# can also use the shared low-level core types. Existing plain overloads remain available.

Encoded primary arrays do not make every accompanying input encoded. For example, the encoded F#
Bubble convenience still takes plain sizes, and labels/styles stay plain where the signature says so.
Bar keys and Heatmap axes in these encoded overloads are numeric encoded arrays; there is no matching
plain string-key argument on those overloads. Use existing plain chart overloads when needed, or
compose the supported fields through the shared trace API.

Image pixel arrays and helpers that compute from the input values, such as Pareto, Residual, and
AnnotatedHeatmap, are outside the direct encoded-overload scope. Neither a metadata option nor the
existence of a numeric factory establishes support for every field or chart type.

## Loading Virtual-WebGL

Virtual-WebGL is a separate plotly.js 2.28 feature for sharing WebGL contexts. It is optional and
does not enable encoded arrays. To use the WebGL 1 script (`src/virtual-webgl.js` from Virtual-WebGL
1.0.6, the version used for this integration check), serve the files below with your page
and load Virtual-WebGL before plotly.js, as described by the
[Virtual-WebGL project](https://github.com/greggman/virtual-webgl#how-to-use).

Existing display options can set that order without a new wrapper API:

```fsharp
open Giraffe.ViewEngine

let displayOptions =
    DisplayOptions.init(
        PlotlyJSReference = PlotlyJSReference.NoReference,
        AdditionalHeadTags = [
            script [ _src "/lib/virtual-webgl.js" ] []
            script [ _src "/lib/plotly-2.28.0.min.js" ] []
        ]
    )

let standaloneHtml =
    Chart.Scatter(
        xEncoded = EncodedTypedArray.ofInt32Array [| 0; 1; 2 |],
        yEncoded = EncodedTypedArray.ofFloat32Array [| 1.5f; 4.5f; 2.5f |],
        mode = StyleParam.Mode.Markers,
        UseWebGL = true,
        UseDefaults = false
    )
    |> Chart.withDisplayOptions displayOptions
    |> GenericChart.toEmbeddedHTML
```

`NoReference` prevents an earlier automatic plotly.js script tag. Replace the paths with your
hosted files and use a WebGL chart, such as Scatter with `UseWebGL = true`, when exercising the
virtualized contexts. `toEmbeddedHTML` emits the head tags; `toChartHTML` emits only a fragment
and requires the host page to supply the scripts.
*)
