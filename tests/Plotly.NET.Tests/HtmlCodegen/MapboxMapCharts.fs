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


let pointMapboxChart = 
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
    Chart.PointMapbox(
        lon,lat,
        Labels = cityNames,
        TextPosition = StyleParam.TextPosition.TopCenter
    )
    |> Chart.withMapbox(
        Mapbox.init(
            Style=StyleParam.MapboxStyle.OpenStreetMap,
            Center=(-104.6,50.45)
        )
    )


open Deedle
open FSharp.Data
open System.IO
open System.Text


let flightsChart =
    let data = 
        "start_lat,start_lon,end_lat,end_lon,airline,airport1,airport2,cnt
32.89595056,-97.0372,35.04022222,-106.6091944,AA,DFW,ABQ,444
41.979595,-87.90446417,30.19453278,-97.66987194,AA,ORD,AUS,166
32.89595056,-97.0372,41.93887417,-72.68322833,AA,DFW,BDL,162
18.43941667,-66.00183333,41.93887417,-72.68322833,AA,SJU,BDL,56
32.89595056,-97.0372,33.56294306,-86.75354972,AA,DFW,BHM,168
25.79325,-80.29055556,36.12447667,-86.67818222,AA,MIA,BNA,56
32.89595056,-97.0372,42.3643475,-71.00517917,AA,DFW,BOS,422
25.79325,-80.29055556,42.3643475,-71.00517917,AA,MIA,BOS,392"
        |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")
    
    let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
    let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
    let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
    let coords = Series.zipInner startCoords endCoords |> Series.values

    coords 
    |> Seq.mapi (fun i (startCoords,endCoords) ->
        Chart.LineMapbox(
            [startCoords; endCoords],
            Opacity = opacityVals.[i],
            Color = "red"
        )
    )
    |> Chart.Combine
    |> Chart.withLegend(false)
    |> Chart.withMapbox(
        Mapbox.init(
            Style=StyleParam.MapboxStyle.OpenStreetMap,
            Center=(-97.0372,32.8959)
        )
    )
    |> Chart.withMarginSize(0,0,50,0)
    |> Chart.withTitle "Feb. 2011 American Airline flights"

[<Tests>]
let ``Scatter and line plots on Mapbox maps charts`` =
    testList "MapboxMapCharts.Scatter and line plots on Mapbox maps charts" [
        testCase "Point mapbox data" ( fun () ->
            "var data = [{\"type\":\"scattermapbox\",\"mode\":\"markers+text\",\"lon\":[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6],\"lat\":[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45],\"line\":{},\"marker\":{},\"text\":[\"Montreal\",\"Toronto\",\"Vancouver\",\"Calgary\",\"Edmonton\",\"Ottawa\",\"Halifax\",\"Victoria\",\"Winnepeg\",\"Regina\"],\"textposition\":\"top center\"}];"
            |> chartGeneratedContains pointMapboxChart
        );
        testCase "Point mapbox layout" ( fun () ->
            "var layout = {\"mapbox\":{\"style\":\"open-street-map\",\"center\":{\"lon\":-104.6,\"lat\":50.45}}};"
            |> chartGeneratedContains pointMapboxChart
        );
        testCase "Flights mapbox data" ( fun () ->
            "var data = [{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-97.0372,-106.6091944],\"lat\":[32.89595056,35.04022222],\"opacity\":1.0,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-87.90446417,-97.66987194],\"lat\":[41.979595,30.19453278],\"opacity\":0.3738738738738739,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-97.0372,-72.68322833],\"lat\":[32.89595056,41.93887417],\"opacity\":0.36486486486486486,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-66.00183333,-72.68322833],\"lat\":[18.43941667,41.93887417],\"opacity\":0.12612612612612611,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-97.0372,-86.75354972],\"lat\":[32.89595056,33.56294306],\"opacity\":0.3783783783783784,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-80.29055556,-86.67818222],\"lat\":[25.79325,36.12447667],\"opacity\":0.12612612612612611,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-97.0372,-71.00517917],\"lat\":[32.89595056,42.3643475],\"opacity\":0.9504504504504504,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}},{\"type\":\"scattermapbox\",\"mode\":\"lines\",\"lon\":[-80.29055556,-71.00517917],\"lat\":[25.79325,42.3643475],\"opacity\":0.8828828828828829,\"line\":{\"color\":\"red\"},\"marker\":{\"color\":\"red\"}}];"
            |> chartGeneratedContains flightsChart
        );
        testCase "Flights mapbox layout" ( fun () ->
            "var layout = {\"showlegend\":false,\"mapbox\":{\"style\":\"open-street-map\",\"center\":{\"lon\":-97.0372,\"lat\":32.8959}},\"margin\":{\"l\":0,\"r\":0,\"t\":50,\"b\":0},\"title\":\"Feb. 2011 American Airline flights\"};"
            |> chartGeneratedContains flightsChart
        );
    ]