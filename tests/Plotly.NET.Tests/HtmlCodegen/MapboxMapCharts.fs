module Tests.MapboxMapCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let baseLayerOnlyChart = 
    let mb =
        Mapbox.init(
            Style = StyleParam.MapboxStyle.OpenStreetMap
        )
    Chart.PointMapbox([],[]) // deliberately empty chart to show the base map only
    |> Chart.withMapbox mb // add the mapBox

[<Tests>]
let `` charts`` =
    testList "MapboxMapCharts. charts" [
        testCase "Base layour only data" ( fun () ->
            "var data = [{\"type\":\"scattermapbox\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains baseLayerOnlyChart
        );
        testCase "Base layour only layout" ( fun () ->
            "var layout = {\"mapbox\":{\"style\":\"open-street-map\"}};"
            |> chartGeneratedContains baseLayerOnlyChart
        );
    ]