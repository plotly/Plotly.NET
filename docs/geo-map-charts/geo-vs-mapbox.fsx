(**
---
title: Geo vs. Mapbox
category: Geo map charts
categoryindex: 6
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
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This introduction shows the differences between Geo and Mapbox based geographical charts.

Plotly and therefore Plotly.NET supports two different kinds of maps:

- **Mapbox maps** are tile-based maps. If your figure is created with a `Chart.*Mapbox` function or otherwise contains one or more traces of type `scattermapbox`, 
    `choroplethmapbox` or `densitymapbox`, the layout.mapbox object in your figure contains configuration information for the map itself.
    
- **Geo maps** are outline-based maps. If your figure is created with a `Chart.ScatterGeo`, `Chart.PointGeo`, `Chart.LineGeo` or `Chart.Choropleth` function or 
    otherwise contains one or more traces of type `scattergeo` or `choropleth`, the layout.geo object in your figure contains configuration information for the map itself.
    
_This page documents Geo outline-based maps, and the [Mapbox Layers documentation]({{root}}mapbox-map-charts/geo-vs-mapbox.html) describes how to configure Mapbox tile-based maps._

## Physical Base Maps

Plotly Geo maps have a built-in base map layer composed of "physical" and "cultural" (i.e. administrative border) data from the Natural Earth Dataset. 
Various lines and area fills can be shown or hidden, and their color and line-widths specified. 
In the default plotly template, a map frame and physical features such as a coastal outline and filled land areas are shown, at a small-scale 1:110m resolution:

*)

open Plotly.NET

let baseMapOnly =
    Chart.PointGeo(locations = []) // deliberately empty chart to show the base map only
    |> Chart.withMarginSize (0, 0, 0, 0)

(*** condition: ipynb ***)
#if IPYNB
baseLayerOnly
#endif // IPYNB

(***hide***)
baseMapOnly |> GenericChart.toChartHTML
(***include-it-raw***)

(**
To control the features of the map, a `Geo` object is used that can be associated with a given chart using the `Chart.WithGeo` function.
Here is a map with all physical features enabled and styled, at a larger-scale 1:50m resolution:
*)
open Plotly.NET.LayoutObjects

let myGeo =
    Geo.init (
        Resolution = StyleParam.GeoResolution.R50,
        ShowCoastLines = true,
        CoastLineColor = Color.fromString "RebeccaPurple",
        ShowLand = true,
        LandColor = Color.fromString "LightGreen",
        ShowOcean = true,
        OceanColor = Color.fromString "LightBlue",
        ShowLakes = true,
        LakeColor = Color.fromString "Blue",
        ShowRivers = true,
        RiverColor = Color.fromString "Blue"
    )

let moreFeaturesBaseMap =
    Chart.PointGeo(locations = [])
    |> Chart.withGeo myGeo
    |> Chart.withMarginSize (0, 0, 0, 0)

(*** condition: ipynb ***)
#if IPYNB
moreFeaturesBaseMap
#endif // IPYNB

(***hide***)
moreFeaturesBaseMap |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Cultural Base Maps

In addition to physical base map features, a "cultural" base map is included which is composed of country borders and selected sub-country borders such as states.

_Note and disclaimer: cultural features are by definition subject to change, debate and dispute. Plotly includes data from Natural Earth "as-is" and defers to the Natural Earth policy regarding disputed borders which read:_

> Natural Earth Vector draws boundaries of countries according to defacto status. We show who actually controls the situation on the ground.

Here is a map with only cultural features enabled and styled, at a 1:50m resolution, which includes only country boundaries. See below for country sub-unit cultural base map features:
*)

let countryGeo =
    Geo.init (
        Visible = false,
        Resolution = StyleParam.GeoResolution.R50,
        ShowCountries = true,
        CountryColor = Color.fromString "RebeccaPurple"
    )


let countryBaseMap =
    Chart.PointGeo(locations = [])
    |> Chart.withGeo countryGeo
    |> Chart.withMarginSize (0, 0, 0, 0)

(*** condition: ipynb ***)
#if IPYNB
countryBaseMap
#endif // IPYNB

(***hide***)
countryBaseMap |> GenericChart.toChartHTML
(***include-it-raw***)
