(**
---
title: Styling Markers
category: General
categoryindex: 1
index: 9
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(**
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

# Styling Markers

#### Table of contents
- [Basics](#Basics)
- [Marker Symbols](#Marker-Symbols)
    - [2D Marker Symbols](#2D-Marker-Symbols)
    - [3D Marker Symbols](#3D-Marker-Symbols)

## Basics

You can control marker size, color, symbol, and other aesthetics by styling the `Marker` object associated with a chart.

This can be done by either setting the `Marker` argument of the chart constructor: 
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let byConstructor = 
    Chart.Point(
        xy = [1,2], 
        Marker = Marker.init(
            Color=Color.fromKeyword Red, 
            Size=20
        )
    )

(*** condition: ipynb ***)
#if IPYNB
byConstructor
#endif // IPYNB

(***hide***)
byConstructor |> GenericChart.toChartHTML
(***include-it-raw***)

(**
or after chart creation with `withMarkerStyle`:
*)

let byStyle = 
    Chart.Point(xy=[1,2])
    |> Chart.withMarkerStyle(
        Color=Color.fromKeyword Blue, 
        Size=50
    )

(*** condition: ipynb ***)
#if IPYNB
byStyle
#endif // IPYNB

(***hide***)
byStyle |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Marker Symbols

Marker symbols control the appearance of points in a plot. There are some things to keep in mind when working with marker symbols:

- 2D and 3D Markers are different types
- 2D Markers can be modified using modification syntax
- 3D Markers cannot be modified

### 2D Marker Symbols

2D Marker symbols are set using `StyleParam.MarkerSymbol`.
*)

let cross2D = 
    Chart.Point(xy=[1,2])
    |> Chart.withMarkerStyle(
        Color=Color.fromKeyword Blue, 
        Size=50,
        Symbol=StyleParam.MarkerSymbol.Cross
    )

(*** condition: ipynb ***)
#if IPYNB
cross2D
#endif // IPYNB

(***hide***)
cross2D |> GenericChart.toChartHTML
(***include-it-raw***)

(**
To modify a symbol, use `StyleParam.MarkerSymbol.Modified`, which takes a MarkerSymbol and a SymbolStyle.

The following code modifies `StyleParam.MarkerSymbol.Circle` with `StyleParam.SymbolStyle.Open` to create an open circle symbol:
*)

let circle2DOpen = 
    Chart.Point(xy=[1,2])
    |> Chart.withMarkerStyle(
        Color=Color.fromKeyword Blue, 
        Size=50,
        Symbol=StyleParam.MarkerSymbol.Modified(
            StyleParam.MarkerSymbol.Circle,
            StyleParam.SymbolStyle.Open
        )
    )

(*** condition: ipynb ***)
#if IPYNB
circle2DOpen
#endif // IPYNB

(***hide***)
circle2DOpen |> GenericChart.toChartHTML
(***include-it-raw***)

(**
### 3D Marker Symbols

2D Marker symbols are set using `StyleParam.MarkerSymbol3D`.

Keep in mind that these must also be set on the `Symbol3D` property of the `Marker` object, not the `Symbol` property.
*)

let cross3D = 
    Chart.Point3D(xyz=[1,2,3])
    |> Chart.withMarkerStyle(
        Color=Color.fromKeyword Blue, 
        Size=50,
        Symbol3D=StyleParam.MarkerSymbol3D.Cross
    )

(*** condition: ipynb ***)
#if IPYNB
cross3D
#endif // IPYNB

(***hide***)
cross3D |> GenericChart.toChartHTML
(***include-it-raw***)