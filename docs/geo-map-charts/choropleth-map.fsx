(**
---
title: Choropleth maps
category: Geo map charts
categoryindex: 6
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
# Choropleth maps

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create choropleth map in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

// Pure alcohol consumption among adults (age 15+) in 2010
let locations, z =
    [ ("Belarus", 17.5)
      ("Moldova", 16.8)
      ("Lithuania", 15.4)
      ("Russia", 15.1)
      ("Romania", 14.4)
      ("Ukraine", 13.9)
      ("Andorra", 13.8)
      ("Hungary", 13.3)
      ("Czech Republic", 13.)
      ("Slovakia", 13.)
      ("Portugal", 12.9)
      ("Serbia", 12.6)
      ("Grenada", 12.5)
      ("Poland", 12.5)
      ("Latvia", 12.3)
      ("Finland", 12.3)
      ("South Korea", 12.3)
      ("France", 12.2)
      ("Australia", 12.2)
      ("Croatia", 12.2)
      ("Ireland", 11.9)
      ("Luxembourg", 11.9)
      ("Germany", 11.8)
      ("Slovenia", 11.6)
      ("United Kingdom", 11.6)
      ("Denmark", 11.4)
      ("Bulgaria", 11.4)
      ("Spain", 11.2)
      ("Belgium", 11.)
      ("South Africa", 11.)
      ("New Zealand", 10.9)
      ("Gabon", 10.9)
      ("Namibia", 10.8)
      ("Switzerland", 10.7)
      ("Saint Lucia", 10.4)
      ("Austria", 10.3)
      ("Estonia", 10.3)
      ("Greece", 10.3)
      ("Kazakhstan", 10.3)
      ("Canada", 10.2)
      ("Nigeria", 10.1)
      ("Netherlands", 9.9)
      ("Uganda", 9.8)
      ("Rwanda", 9.8)
      ("Chile", 9.6)
      ("Argentina", 9.3)
      ("Burundi", 9.3)
      ("United States", 9.2)
      ("Cyprus", 9.2)
      ("Sweden", 9.2)
      ("Venezuela", 8.9)
      ("Paraguay", 8.8)
      ("Brazil", 8.7)
      ("Sierra Leone", 8.7)
      ("Montenegro", 8.7)
      ("Belize", 8.5)
      ("Cameroon", 8.4)
      ("Botswana", 8.4)
      ("Saint Kitts and Nevis", 8.2)
      ("Guyana", 8.1)
      ("Peru", 8.1)
      ("Panama", 8.)
      ("Niue", 8.)
      ("Palau", 7.9)
      ("Norway", 7.7)
      ("Tanzania", 7.7)
      ("Georgia", 7.7)
      ("Uruguay", 7.6)
      ("Angola", 7.5)
      ("Laos", 7.3)
      ("Japan", 7.2)
      ("Mexico", 7.2)
      ("Ecuador", 7.2)
      ("Dominica", 7.1)
      ("Iceland", 7.1)
      ("Thailand", 7.1)
      ("Bosnia and Herzegovina", 7.1)
      ("Sao Tome and Principe", 7.1)
      ("Malta", 7.)
      ("Albania", 7.)
      ("Bahamas", 6.9)
      ("Dominican Republic", 6.9)
      ("Mongolia", 6.9)
      ("Cape Verde", 6.9)
      ("Barbados", 6.8)
      ("Burkina Faso", 6.8)
      ("Italy", 6.7)
      ("Trinidad and Tobago", 6.7)
      ("China", 6.7)
      ("Macedonia", 6.7)
      ("Saint Vincent and the Grenadines", 6.6)
      ("Equatorial Guinea", 6.6)
      ("Suriname", 6.6)
      ("Vietnam", 6.6)
      ("Lesotho", 6.5)
      ("Haiti", 6.4)
      ("Cook Islands", 6.4)
      ("Colombia", 6.2)
      ("Ivory Coast", 6.)
      ("Bolivia", 5.9)
      ("Swaziland", 5.7)
      ("Zimbabwe", 5.7)
      ("Seychelles", 5.6)
      ("Cambodia", 5.5)
      ("Puerto Rico", 5.4)
      ("Netherlands Antilles", 5.4)
      ("Philippines", 5.4)
      ("Costa Rica", 5.4)
      ("Armenia", 5.3)
      ("Cuba", 5.2)
      ("Nicaragua", 5.)
      ("Jamaica", 4.9)
      ("Ghana", 4.8)
      ("Liberia", 4.7)
      ("Uzbekistan", 4.6)
      ("Chad", 4.4)
      ("United Arab Emirates", 4.3)
      ("Kyrgyzstan", 4.3)
      ("India", 4.3)
      ("Turkmenistan", 4.3)
      ("Kenya", 4.3)
      ("Ethiopia", 4.2)
      ("Honduras", 4.)
      ("Guinea-Bissau", 4.)
      ("Zambia", 4.)
      ("Republic of the Congo", 3.9)
      ("Guatemala", 3.8)
      ("Central African Republic", 3.8)
      ("North Korea", 3.7)
      ("Sri Lanka", 3.7)
      ("Mauritius", 3.6)
      ("Samoa", 3.6)
      ("Democratic Republic of the Congo", 3.6)
      ("Nauru", 3.5)
      ("Gambia", 3.4)
      ("Federated States of Micronesia", 3.3)
      ("El Salvador", 3.2)
      ("Fiji", 3.)
      ("Papua New Guinea", 3.)
      ("Kiribati", 3.)
      ("Tajikistan", 2.8)
      ("Israel", 2.8)
      ("Sudan", 2.7)
      ("Malawi", 2.5)
      ("Lebanon", 2.4)
      ("Azerbaijan", 2.3)
      ("Mozambique", 2.3)
      ("Togo", 2.3)
      ("Nepal", 2.2)
      ("Brunei", 2.1)
      ("Benin", 2.1)
      ("Singapore", 2.)
      ("Turkey", 2.)
      ("Madagascar", 1.8)
      ("Solomon Islands", 1.7)
      ("Tonga", 1.6)
      ("Tunisia", 1.5)
      ("Tuvalu", 1.5)
      ("Qatar", 1.5)
      ("Vanuatu", 1.4)
      ("Djibouti", 1.3)
      ("Malaysia", 1.3)
      ("Syria", 1.2)
      ("Maldives", 1.2)
      ("Mali", 1.1)
      ("Eritrea", 1.1)
      ("Algeria", 1.)
      ("Iran", 1.)
      ("Oman", 0.9)
      ("Brunei", 0.9)
      ("Morocco", 0.9)
      ("Jordan", 0.7)
      ("Bhutan", 0.7)
      ("Guinea", 0.7)
      ("Burma", 0.7)
      ("Afghanistan", 0.7)
      ("Senegal", 0.6)
      ("Indonesia", 0.6)
      ("Timor-Leste", 0.6)
      ("Iraq", 0.5)
      ("Somalia", 0.5)
      ("Egypt", 0.4)
      ("Niger", 0.3)
      ("Yemen", 0.3)
      ("Comoros", 0.2)
      ("Saudi Arabia", 0.2)
      ("Bangladesh", 0.2)
      ("Kuwait", 0.1)
      ("Libya", 0.1)
      ("Mauritania", 0.1)
      ("Pakistan", 0.1) ]
    |> List.unzip

(**
Choropleth Maps display divided geographical areas or regions that are coloured, shaded or patterned in relation to 
a data variable. This provides a way to visualise values over a geographical area, which can show variation or 
patterns across the displayed location.
*)

let choroplethMap1 =
    Chart.ChoroplethMap(locations = locations, z = z, LocationMode = StyleParam.LocationFormat.CountryNames)

(*** condition: ipynb ***)
#if IPYNB
choroplethMap1
#endif // IPYNB

(***hide***)
choroplethMap1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Map styling

you can access various map styles via `Chart.withGeoStyle`, such as the projection type, lake/ocean color, and so on.
*)

open Plotly.NET.LayoutObjects

let choroplethMap2 =
    Chart.ChoroplethMap(locations = locations, z = z, LocationMode = StyleParam.LocationFormat.CountryNames)
    |> Chart.withGeoStyle (
        Projection = GeoProjection.init (projectionType = StyleParam.GeoProjectionType.Mollweide),
        ShowLakes = true,
        ShowOcean = true,
        OceanColor = Color.fromString "lightblue",
        ShowRivers = true
    )
    |> Chart.withColorBarStyle (TitleText = "Alcohol consumption[l/y]", Len = 0.5)

(*** condition: ipynb ***)
#if IPYNB
choroplethMap2
#endif // IPYNB

(***hide***)
choroplethMap2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Using GeoJSON

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
It looks like this:

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

let locationsGeoJSON: string[] =
    data |> Frame.getCol "fips" |> Series.values |> Array.ofSeq

let zGeoJSON: int[] = data |> Frame.getCol "unemp" |> Series.values |> Array.ofSeq


(**
And finally put together the chart using GeoJSON:
*)

let choroplethGeoJSON =
    Chart.ChoroplethMap(
        locations = locationsGeoJSON,
        z = zGeoJSON,
        LocationMode = StyleParam.LocationFormat.GeoJson_Id,
        GeoJson = geoJson,
        FeatureIdKey = "id"
    )
    |> Chart.withGeo (
        Geo.init (
            Scope = StyleParam.GeoScope.NorthAmerica,
            Projection = GeoProjection.init (StyleParam.GeoProjectionType.AzimuthalEqualArea),
            ShowLand = true,
            LandColor = Color.fromString "lightgrey"
        )
    )
    |> Chart.withSize (800., 800.)

(*** condition: ipynb ***)
#if IPYNB
choroplethGeoJSON
#endif // IPYNB

(***hide***)
choroplethGeoJSON |> GenericChart.toChartHTML
(***include-it-raw***)
