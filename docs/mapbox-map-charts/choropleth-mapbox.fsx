(**
---
title: ChoroplethMapbox
category: Mapbox map charts
categoryindex: 7
index: 3
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
# ChoroplethMapbox

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create choropleth maps using Mapbox layers in F#.

Choropleth Maps display divided geographical areas or regions that are coloured, shaded or patterned in relation to 
a data variable. This provides a way to visualise values over a geographical area, which can show variation or 
patterns across the displayed location.

This choropleth map version uses [Mapbox Layers]({{root}}/6_0_geo-vs-mapbox.html). For the Geo variant, head over [here]({{root}}/5_2_choropleth-map.html).

ChoroplethMapbox charts need GeoJSON formatted data.

[GeoJSON](https://en.wikipedia.org/wiki/GeoJSON) is an open standard format designed for representing simple geographical features, along with their non-spatial attributes.

GeoJSON, or at least the type of GeoJSON accepted by plotly.js are `FeatureCollection`s. A feature has for example the `geometry` field, which defines e.g. the coordinates of it (think for example the coordinates of a polygon on the map)
and the `properties` field, a key-value pair of properties of the feature. 

If you want to use GeoJSON with Plotly.NET (or any plotly flavor really), you have to know the property of the feature you are mapping your data to. In the following example, this is simply the `id` of a feature, but you can access any property by `property.key`.

Consider the following GeoJSON:
*)
 
// we are using the awesome FSharp.Data project here to perform a http request

open Newtonsoft.Json
open System.IO

let geoJson =
    (__SOURCE_DIRECTORY__ + "/../data/geojson-counties-fips.json")
    |> File.ReadAllText
    |> JsonConvert.DeserializeObject // the easiest way to use the GeoJSON object is deserializing the JSON string.

(**
it looks like this:

```JSON
{
    "type": "FeatureCollection", 
    "features": [{
        "type": "Feature", 
        "properties": {
            "GEO_ID": "0500000US01001", 
            "STATE": "01", 
            "COUNTY": "001", 
            "NAME": "Autauga", 
            "LSAD": "County", 
            "CENSUSAREA": 594.436
        }, 
        "geometry": {
            "type": "Polygon", 
            "coordinates": [[[-86.496774, 32.344437], [-86.717897, 32.402814], [-86.814912, 32.340803], [-86.890581, 32.502974], [-86.917595, 32.664169], [-86.71339, 32.661732], [-86.714219, 32.705694], [-86.413116, 32.707386], [-86.411172, 32.409937], [-86.496774, 32.344437]]]
        },
        "id": "01001"
    }, ... MANY more features.
```

It basically contains all US counties as polygons on the map. Note that the `id` property corresponds to the [**fips code**](https://en.wikipedia.org/wiki/FIPS_county_code).

To visualize some data using these counties as locations on a choropleth map, we need some example data:
*)

// we use the awesome Deedle data frame library to parse and extract our location and z data
open Deedle

let data =
    __SOURCE_DIRECTORY__ + "/../data/fips-unemp-16.csv"
    |> fun csv -> Frame.ReadCsv(csv, true, separators = ",", schema = "fips=string,unemp=float")

(**
The data looks like this:
*)

data.Print()

(*** include-output ***)

(**
As the data contains the fips code and associated unemployment data, we can use the fips codes as locations and the unemployment as z data:
*)

let locations: string[] =
    data |> Frame.getCol "fips" |> Series.values |> Array.ofSeq

let z: int[] = data |> Frame.getCol "unemp" |> Series.values |> Array.ofSeq


(**
And finally put together the chart using GeoJSON:
*)

open Plotly.NET
open Plotly.NET.LayoutObjects

let choroplethMapbox =
    Chart.ChoroplethMapbox(locations = locations, z = z, geoJson = geoJson, FeatureIdKey = "id")
    |> Chart.withMapbox (
        Mapbox.init (
            Style = StyleParam.MapboxStyle.OpenStreetMap, // Use the free open street map base map layer
            Center = (-104.6, 50.45)
        )
    )

(*** condition: ipynb ***)
#if IPYNB
choroplethMapbox
#endif // IPYNB

(***hide***)
choroplethMapbox |> GenericChart.toChartHTML
(***include-it-raw***)
