(**
---
title: Geo vs. Mapbox
category: Mapbox map charts
categoryindex: 7
index: 1
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
# Mapbox Maps vs Geo Maps

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This introduction shows the differences between Geo and Mapbox based geographical charts.

Plotly and therefore Plotly.NET supports two different kinds of maps:

- **Mapbox maps** are tile-based maps. If your figure is created with a `Chart.*Mapbox` function or otherwise contains one or more traces of type `scattermapbox`, 
    `choroplethmapbox` or `densitymapbox`, the layout.mapbox object in your figure contains configuration information for the map itself.
    
- **Geo maps** are outline-based maps. If your figure is created with a `Chart.ScatterGeo`, `Chart.PointGeo`, `Chart.LineGeo` or `Chart.Choropleth` function or 
    otherwise contains one or more traces of type `scattergeo` or `choropleth`, the layout.geo object in your figure contains configuration information for the map itself.
    
_This page documents Mapbox tile-based maps, and the [Geo map documentation]({{root}}geo-map-charts/geo-vs-mapbox.html) describes how to configure outline-based maps_

## How Layers Work in Mapbox Tile Maps

Mapbox tile maps are composed of various layers, of three different types:

- the `style` property of the `Mapbox` object defines is the lowest layers, also known as your "base map"
- The various traces in data are by default rendered above the base map (although this can be controlled via the below attribute).
- the `layers` property of the `Mapbox` object is an array that defines more layers that are by default rendered above the traces in data (although this can also be controlled via the below attribute).
    
a `Mapbox` object where these properties can be set can be initialized via `Mapbox.init`. To use it in a chart, use the `Chart.withMapbox` function:
*)
open Plotly.NET
open Plotly.NET.LayoutObjects

// a simple Mapbox with a OpenStreetMap base layer.
let mb = Mapbox.init (Style = StyleParam.MapboxStyle.OpenStreetMap)

let baseLayerOnly =
    Chart.PointMapbox(lonlat = []) // deliberately empty chart to show the base map only
    |> Chart.withMapbox mb // add the mapBox

(*** condition: ipynb ***)
#if IPYNB
baseLayerOnly
#endif // IPYNB

(***hide***)
baseLayerOnly |> GenericChart.toChartHTML
(***include-it-raw***)

(**

## Mapbox Access Tokens and When You Need Them

The word "mapbox" in the trace names and layout.mapbox refers to the Mapbox GL JS open-source library, which is integrated into Plotly.NET. 

If your basemap uses data from the Mapbox service, then you will need to register for a free account at https://mapbox.com/ 
and obtain a Mapbox Access token. 

This token should be provided via the `AccessToken` property:
*)

let mbWithToken =
    Mapbox.init (Style = StyleParam.MapboxStyle.OpenStreetMap, AccessToken = "your_token_here")

(**

If your base map does not use data from the Mapbox service, you do not need to register for a Mapbox account.

## Base Maps

- `WhiteBG` yields an empty white canvas which results in no external HTTP requests
- The plotly presets yield maps composed of raster tiles from various public tile servers which do not require signups or access tokens
- The Mapbox presets yield maps composed of vector tiles from the Mapbox service, and do require a Mapbox Access Token or an on-premise Mapbox installation.
- Use `StyleParam.MapboxStyle.Custom` for:
    - Mapbox service style URL, which requires a Mapbox Access Token or an on-premise Mapbox installation.
    - A Mapbox Style object as defined at https://docs.mapbox.com/mapbox-gl-js/style-spec/


The accepted values for the `style` property of the `Mapbox` object are represented in `StyleParam.MapboxStyle`:

```
type MapboxStyle =
    // plotly presets, no token needed
    | WhiteBG
    | OpenStreetMap
    | CartoPositron
    | CartoDarkmatter
    | StamenTerrain
    | StamenToner
    | StamenWatercolor

    // Mapbox presets, you might need a free token
    | MapboxBasic
    | MapboxStreets
    | MapboxOutdoors
    | MapboxLight
    | MapboxDark
    | MapboxSatellite
    | MapboxSatelliteStreets

    //Custom - provide custom maps
    | Custom of string
```
*)
