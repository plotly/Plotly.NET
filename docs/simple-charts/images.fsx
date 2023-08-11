(**
---
title: Images
category: Simple Charts
categoryindex: 3
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
# Images

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create image charts in F#.

There are multiple ways of generating image charts:

- From three-dimensional color collections, where the inner arrays contain 3 (color dimensions without alpha channel) or 4 (color dimensions and alpha channel) values. The color model can be set separately as shown below.
- From a two-dimensional collection Plotly.NETs `ARGB` type that represents rgba values
- From a base64 encoded image data source

## Creating Image charts from raw color arrays
*)

// 3d collection containing color values
open Plotly.NET

let colors =
    [ [ [ 0; 0; 255 ]; [ 255; 255; 0 ]; [ 0; 0; 255 ] ]
      [ [ 255; 0; 0 ]; [ 255; 0; 255 ]; [ 255; 0; 255 ] ]
      [ [ 0; 255; 0 ]; [ 0; 255; 255 ]; [ 255; 0; 0 ] ] ]

let imageRaw =
    Chart.Image(Z = colors)
    |> Chart.withTitle "Image chart from raw color component arrays"

(*** condition: ipynb ***)
#if IPYNB
imageRaw
#endif // IPYNB

(***hide***)
imageRaw |> GenericChart.toChartHTML
(***include-it-raw***)

(**
To change the color model to HSL, for example, add the `ColorModel` argument:
*)

let imageRawHSL =
    Chart.Image(Z = colors, ColorModel = StyleParam.ColorModel.HSL)
    |> Chart.withTitle "HSL color model"

(*** condition: ipynb ***)
#if IPYNB
imageRawHSL
#endif // IPYNB

(***hide***)
imageRawHSL |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Creating Image charts from ARGB arrays

Note that this way of creating image charts uses the RGBA color model.
*)

let argbs =
    [ [ ColorKeyword.AliceBlue; ColorKeyword.CornSilk; ColorKeyword.LavenderBlush ]
      |> List.map ARGB.fromKeyword
      [ ColorKeyword.DarkGray; ColorKeyword.Snow; ColorKeyword.MidnightBlue ]
      |> List.map ARGB.fromKeyword
      [ ColorKeyword.LightSteelBlue
        ColorKeyword.DarkKhaki
        ColorKeyword.LightAkyBlue ]
      |> List.map ARGB.fromKeyword ]

let imageARGB = Chart.Image(z = argbs) |> Chart.withTitle "ARGB image chart"

(*** condition: ipynb ***)
#if IPYNB
imageARGB
#endif // IPYNB

(***hide***)
imageARGB |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Creating Image charts from base64 encoded images
*)
open System
open System.IO

let imageSource = $@"{__SOURCE_DIRECTORY__}/../img/logo.png"

let base64String = imageSource |> File.ReadAllBytes |> System.Convert.ToBase64String

let logoImage =
    Chart.Image(Source = ($"data:image/jpg;base64,{base64String}"))
    |> Chart.withTitle "This is Plotly.NET:"

(*** condition: ipynb ***)
#if IPYNB
logoImage
#endif // IPYNB

(***hide***)
logoImage |> GenericChart.toChartHTML
(***include-it-raw***)
