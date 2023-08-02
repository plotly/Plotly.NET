(**
---
title: DensityMapbox charts
category: Mapbox map charts
categoryindex: 7
index: 4
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../data/Deedle.dll"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# DensityMapbox charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create DensityMapbox charts in F#.

`Chart.DensityMapbox` draws a bivariate kernel density estimation with a Gaussian kernel from `lon` and `lat` coordinates and optional `z` values using a colorscale.
This Chart uses [Mapbox layers]({{root}}/6_0_geo-vs-mapbox.html) and might need a Mapbox API token depending on the desired base map layer style.

*)
// we are using the awesome FSharp.Data project here to perform a http request,
// and the awesome Deedle library to read the data as a data frame
open Deedle
 
let dataDensityMapbox =
    __SOURCE_DIRECTORY__ + "/../data/earthquakes-23k.csv"
    |> fun d -> Frame.ReadCsv(d, true, separators = ",")

let lon = dataDensityMapbox.["Longitude"] |> Series.values
let lat = dataDensityMapbox.["Latitude"] |> Series.values
let magnitudes = dataDensityMapbox.["Magnitude"] |> Series.values

open Plotly.NET
open Plotly.NET.LayoutObjects

let densityMapbox =
    Chart.DensityMapbox(
        longitudes = lon,
        latitudes = lat,
        Z = magnitudes,
        Radius = 8,
        ColorScale = StyleParam.Colorscale.Viridis
    )
    |> Chart.withMapbox (Mapbox.init (Style = StyleParam.MapboxStyle.StamenTerrain, Center = (60., 30.)))

(*** condition: ipynb ***)
#if IPYNB
densityMapbox
#endif // IPYNB

(***hide***)
densityMapbox |> GenericChart.toChartHTML
(***include-it-raw***)
