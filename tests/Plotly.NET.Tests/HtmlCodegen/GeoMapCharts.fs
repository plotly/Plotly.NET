module Tests.GeoMapCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let basemapChart =
    Chart.PointGeo([]) // deliberately empty chart to show the base map only
    |> Chart.withMarginSize(0, 0, 0, 0)

let moreFeaturesBasemapChart =
    let myGeo =
        Geo.init(
            Resolution=StyleParam.GeoResolution.R50,
            ShowCoastLines=true, 
            CoastLineColor="RebeccaPurple",
            ShowLand=true, 
            LandColor="LightGreen",
            ShowOcean=true, 
            OceanColor="LightBlue",
            ShowLakes=true, 
            LakeColor="Blue",
            ShowRivers=true, 
            RiverColor="Blue"
        )
    Chart.PointGeo([])
    |> Chart.withMap myGeo
    |> Chart.withMarginSize(0, 0, 0, 0)

let cultureMapChart =
    let countryGeo =
        Geo.init(
            Visible=false, 
            Resolution=StyleParam.GeoResolution.R50,
            ShowCountries=true, 
            CountryColor="RebeccaPurple"
        )
    Chart.PointGeo([])
    |> Chart.withMap countryGeo
    |> Chart.withMarginSize(0, 0, 0, 0)

[<Tests>]
let ``Geo vs mapbox charts`` =
    testList "GeoMapCharts.Geo vs mapbox charts" [
        testCase "Basemap data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"marker\":{}}];"
            |> chartGeneratedContains basemapChart
        );
        testCase "Basemap layout" ( fun () ->
            "var layout = {\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains basemapChart
        );
        testCase "More features map data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"marker\":{}}];"
            |> chartGeneratedContains moreFeaturesBasemapChart
        );
        testCase "More features map layout" ( fun () ->
            "var layout = {\"geo\":{\"resolution\":\"50\",\"showcoastline\":true,\"coastlinecolor\":\"RebeccaPurple\",\"showland\":true,\"landcolor\":\"LightGreen\",\"showocean\":true,\"oceancolor\":\"LightBlue\",\"showlakes\":true,\"lakecolor\":\"Blue\",\"showrivers\":true,\"rivercolor\":\"Blue\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains moreFeaturesBasemapChart
        );
        testCase "Cultural map data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"marker\":{}}];"
            |> chartGeneratedContains cultureMapChart
        );
        testCase "Cultural map layout" ( fun () ->
            "var layout = {\"geo\":{\"resolution\":\"50\",\"visible\":false,\"showcountries\":true,\"countrycolor\":\"RebeccaPurple\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains cultureMapChart
        );
    ]