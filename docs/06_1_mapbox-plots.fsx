(**
---
title: Scatter and line plots on Mapbox maps
category: Mapbox map charts
categoryindex: 7
index: 2
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Scatter and line plots on Mapbox maps

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Point and Line charts on Mapbox maps in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET 

let cityNames = [
    "Montreal"; "Toronto"; "Vancouver"; "Calgary"; "Edmonton";
    "Ottawa"; "Halifax"; "Victoria"; "Winnepeg"; "Regina"
]

let lon = [
    -73.57; -79.24; -123.06; -114.1; -113.28;
    -75.43; -63.57; -123.21; -97.13; -104.6
]
let lat = [
    45.5; 43.4; 49.13; 51.1; 53.34; 45.24;
    44.64; 48.25; 49.89; 50.45
]

(**
The simplest type of geographic plot using Mapbox is plotting the (lon,lat) pairs of a location via `Chart.PointMapbox`. 
Here is an example using the location of Canadian cities:
*)
open Plotly.NET.LayoutObjects

let pointMapbox = 
    Chart.PointMapbox(
        lon,lat,
        MultiText = cityNames,
        TextPosition = StyleParam.TextPosition.TopCenter
    )
    |> Chart.withMapbox(
        Mapbox.init(
            Style=StyleParam.MapboxStyle.OpenStreetMap,
            Center=(-104.6,50.45)
        )
    )

(*** condition: ipynb ***)
#if IPYNB
pointMapbox
#endif // IPYNB

(***hide***)
pointMapbox |> GenericChart.toChartHTML
(***include-it-raw***)

(**
To connect the given (lon,lat) pairs via straight lines, use `Chart.LineGeo`. 
Below is an example that pulls external data as a Deedle data 
frame containing the source and target locations of American Airlines flights from Feb. 2011:
*)

#r "nuget: Deedle"
#r "nuget: FSharp.Data"
open Deedle
open FSharp.Data
open System.IO
open System.Text

let data = 
    Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/c34aaa0b1b3cddad335173cb7bc0181897201ee6/2011_february_aa_flight_paths.csv"
    |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
let coords = Series.zipInner startCoords endCoords |> Series.values

let flights = 
    coords 
    |> Seq.mapi (fun i (startCoords,endCoords) ->
        Chart.LineMapbox(
            [startCoords; endCoords],
            Opacity = opacityVals.[i],
            LineColor = Color.fromString "red"
        )
    )
    |> Chart.combine
    |> Chart.withLegend(false)
    |> Chart.withMapbox(
        Mapbox.init(
            Style=StyleParam.MapboxStyle.OpenStreetMap,
            Center=(-97.0372,32.8959)
        )
    )
    |> Chart.withMarginSize(0,0,50,0)
    |> Chart.withTitle "Feb. 2011 American Airline flights"

(*** condition: ipynb ***)
#if IPYNB
flights
#endif // IPYNB

(***hide***)
flights |> GenericChart.toChartHTML
(***include-it-raw***)
