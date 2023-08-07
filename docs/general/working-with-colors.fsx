(**
---
title: Working with colors
category: General
categoryindex: 1
index: 8
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

# Working with colors

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

#### Table of contents
- [The Color type](#The-Color-type)
- [Setting single colors](#Setting-single-colors)
- [Setting individual colors](#Setting-individual-colors)
- [Mapping values to a color scale](#Mapping-values-to-a-color-scale)


## The Color type

There are many ways how plotly.js handles colors. In general, individual colors can be set the same way as in general html/css - so for example string representations of (a)rgb, hsl, or keywords such as "red".
Additionally to that, there are several ways of controlling color attributes of plotly objects:

- Setting a single color which will be used for all elements in a collection, for example all markers: `"rgb(r,g,b)"` or `"red"`
- Setting an array of colors to assign single colors for each individual item in a collection, for example each individual marker: `["red","blue"]`
- Mapping values to a color scale, for example coloring markers by intensity of the datum: `[6.9, 4.2]`
- These can also be mixed in collections.

To do this justice in Plotly.NET in a type-safe way, we provide the dedicated `Color` type that has methods to create all of these variants.

The `Color` type provides methods to initialize all of the above mentioned ways to control color attributes of plotly charts.
Color Keywords and ARGB are also wrapped in a typesafe way:
*)

open Plotly.NET

// single colors
let singleColor1 = Color.fromKeyword Red // using html color keywords
let singleColor2 = Color.fromARGB 255 42 13 1 // using type-safe argb
let singleColor3 = Color.fromHex "#FFFFFF" // parsing hex strings
let singleColor4 = Color.fromString "red" // you can also set any string value if you really need to

(**
The `Color` type is basically a container for boxed values that gets converted to correct plotly attributes internally:
*)

singleColor1.Value
(***include-it***)

open Newtonsoft.Json
singleColor3 |> JsonConvert.SerializeObject
(***include-it***)

(**
## Setting single colors

Here is an example on how to set a single color for a plotly color attribute:
*)

let colorChart1 =
    Chart.Bubble(
        xysizes = [ 1, 2, 15; 3, 4, 15; 5, 6, 15 ],
        MarkerColor = Color.fromKeyword Red // will make ALL markers red.
    )

(*** condition: ipynb ***)
#if IPYNB
colorChart1
#endif // IPYNB

(***hide***)
colorChart1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Setting individual colors

`Color.fromColors` takes a collection of colors and wraps them as a new `Color` object.
Here is an example on how to set individual colors in a collection for a plotly color attribute.
*)

let colorChart2 =
    Chart.Bubble(
        xysizes = [ 1, 2, 15; 3, 4, 15; 5, 6, 15 ],
        MarkerColor = Color.fromColors [ Color.fromKeyword Red; Color.fromKeyword Green; Color.fromKeyword Blue ]
    )

(*** condition: ipynb ***)
#if IPYNB
colorChart2
#endif // IPYNB

(***hide***)
colorChart2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Mapping values to a color scale

`Color.fromColorScaleValues` takes a collection of values that will be mapped onto a color scale (normalized between min and max value)
Here is an example on how to set up color scale mapping:
*)
let x = [ 1; 2; 3 ]
let y = [ 2; 3; 4 ] // we want to color the markers depending on their y value.
let sizes = [ 15; 15; 15 ]

let colorChart3 =
    Chart.Bubble(x = x, y = y, sizes = sizes, MarkerColor = Color.fromColorScaleValues y)
    |> Chart.withMarkerStyle (ShowScale = true) // we want to see the color scale we are mapping to

(*** condition: ipynb ***)
#if IPYNB
colorChart3
#endif // IPYNB

(***hide***)
colorChart3 |> GenericChart.toChartHTML
(***include-it-raw***)
