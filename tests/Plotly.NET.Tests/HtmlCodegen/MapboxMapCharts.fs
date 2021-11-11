module Tests.MapboxMapCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.LayoutObjects
open System

open TestUtils.HtmlCodegen

let baseLayerOnlyChart = 
    let mb =
        Mapbox.init(
            Style = StyleParam.MapboxStyle.OpenStreetMap
        )
    Chart.PointMapbox([],[], UseDefaults = false) // deliberately empty chart to show the base map only
    |> Chart.withMapbox mb // add the mapBox

[<Tests>]
let ``Mapbox charts`` =
    testList "MapboxMapCharts.Mapbox charts" [
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
        TextPosition = StyleParam.TextPosition.TopCenter, 
        UseDefaults = false
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
            Color = Color.fromString "red",
            UseDefaults = false
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
            "var layout = {\"showlegend\":false,\"mapbox\":{\"style\":\"open-street-map\",\"center\":{\"lon\":-97.0372,\"lat\":32.8959}},\"margin\":{\"l\":0,\"r\":0,\"t\":50,\"b\":0},\"title\":{\"text\":\"Feb. 2011 American Airline flights\"}};"
            |> chartGeneratedContains flightsChart
        );
    ]


let densityMapboxChart = 
    let dataDensityMapbox = 
        "Date,Latitude,Longitude,Magnitude
01/02/1965,19.246,145.616,6.0
01/04/1965,1.8630000000000002,127.352,5.8
01/05/1965,-20.579,-173.972,6.2
01/08/1965,-59.076,-23.557,5.8
01/09/1965,11.937999999999999,126.427,5.8
01/10/1965,-13.405,166.62900000000002,6.7
01/12/1965,27.357,87.867,5.9
01/15/1965,-13.309000000000001,166.21200000000002,6.0
01/16/1965,-56.452,-27.043000000000003,6.0
01/17/1965,-24.563000000000002,178.487,5.8
01/17/1965,-6.807,108.988,5.9
01/24/1965,-2.608,125.95200000000001,8.2
01/29/1965,54.636,161.703,5.5
02/01/1965,-18.697,-177.864,5.6
02/02/1965,37.523,73.251,6.0
02/04/1965,-51.84,139.741,6.1
02/04/1965,51.251000000000005,178.715,8.7
02/04/1965,51.638999999999996,175.055,6.0
02/04/1965,52.528,172.007,5.7
02/04/1965,51.626000000000005,175.74599999999998,5.8
02/04/1965,51.037,177.84799999999998,5.9
02/04/1965,51.73,173.975,5.9
02/04/1965,51.775,173.058,5.7
02/04/1965,52.611000000000004,172.588,5.7
02/04/1965,51.831,174.368,5.7
02/04/1965,51.948,173.96900000000002,5.6
02/04/1965,51.443000000000005,179.605,7.3
02/04/1965,52.773,171.97400000000002,6.5
02/04/1965,51.772,174.696,5.6
02/04/1965,52.975,171.09099999999998,6.4
02/04/1965,52.99,170.87400000000002,5.8
02/04/1965,51.536,175.045,5.8
02/04/1965,13.245,-44.922,5.8
02/04/1965,51.812,174.206,5.7
02/05/1965,51.762,174.84099999999998,5.7
02/05/1965,52.438,174.321,6.3
02/05/1965,51.946000000000005,173.84,5.7
02/05/1965,51.738,174.56599999999997,6.0
02/05/1965,51.486999999999995,176.558,5.6
02/06/1965,53.008,-162.00799999999998,6.4
02/06/1965,52.184,175.505,6.2
02/06/1965,52.076,172.918,5.6
02/06/1965,51.744,175.213,5.7
02/06/1965,52.056999999999995,174.11599999999999,5.7
02/06/1965,53.191,-161.859,6.3
02/06/1965,51.446999999999996,176.46900000000002,5.8
02/07/1965,51.258,173.393,5.7
02/07/1965,52.031000000000006,175.41099999999997,5.7
02/07/1965,51.294,179.092,5.8
02/08/1965,55.223,165.426,5.9
02/09/1965,-18.718,169.386,5.6
02/09/1965,52.815,171.90400000000002,6.0
02/12/1965,52.188,172.752,5.8
02/15/1965,51.00899999999999,179.325,5.8
02/15/1965,3.0260000000000002,125.95100000000001,5.9
02/16/1965,38.908,142.095,5.7
02/17/1965,51.693999999999996,176.446,5.7
02/17/1965,21.526999999999997,143.08100000000002,5.6
02/18/1965,25.011,94.186,5.6"
        |> fun d -> Frame.ReadCsvString(d,true,separators=",")
    
    let lon = dataDensityMapbox.["Longitude"] |> Series.values
    let lat= dataDensityMapbox.["Latitude"] |> Series.values
    let magnitudes = dataDensityMapbox.["Magnitude"] |> Series.values
    Chart.DensityMapbox(
        lon,
        lat,
        Z = magnitudes,
        Radius=8.,
        Colorscale=StyleParam.Colorscale.Viridis,
        UseDefaults = false
    )
    |> Chart.withMapbox(
        Mapbox.init(
            Style = StyleParam.MapboxStyle.StamenTerrain,
            Center = (60.,30.)
        )
    )

[<Tests>]
let ``DensityMapbox charts`` =
    testList "MapboxMapCharts.DensityMapbox charts charts" [
        testCase "Density Mapbox data" ( fun () ->
            "var data = [{\"type\":\"densitymapbox\",\"z\":[6.0,5.8,6.2,5.8,5.8,6.7,5.9,6.0,6.0,5.8,5.9,8.2,5.5,5.6,6.0,6.1,8.7,6.0,5.7,5.8,5.9,5.9,5.7,5.7,5.7,5.6,7.3,6.5,5.6,6.4,5.8,5.8,5.8,5.7,5.7,6.3,5.7,6.0,5.6,6.4,6.2,5.6,5.7,5.7,6.3,5.8,5.7,5.7,5.8,5.9,5.6,6.0,5.8,5.8,5.9,5.7,5.7,5.6,5.6],\"radius\":8.0,\"lon\":[145.616,127.352,-173.972,-23.557,126.427,166.62900000000002,87.867,166.21200000000002,-27.043000000000003,178.487,108.988,125.952,161.703,-177.864,73.251,139.741,178.715,175.055,172.007,175.74599999999998,177.84799999999998,173.975,173.058,172.588,174.368,173.96900000000002,179.605,171.97400000000002,174.696,171.09099999999998,170.87400000000002,175.045,-44.922,174.206,174.84099999999998,174.321,173.84,174.56599999999997,176.558,-162.00799999999998,175.505,172.918,175.213,174.116,-161.859,176.46900000000002,173.393,175.41099999999997,179.092,165.426,169.386,171.90400000000002,172.752,179.325,125.951,142.095,176.446,143.08100000000002,94.186],\"lat\":[19.246,1.863,-20.579,-59.076,11.938,-13.405,27.357,-13.309,-56.452,-24.563,-6.807,-2.608,54.636,-18.697,37.523,-51.84,51.251000000000005,51.639,52.528,51.626000000000005,51.037,51.73,51.775,52.611,51.831,51.948,51.443000000000005,52.773,51.772,52.975,52.99,51.536,13.245,51.812,51.762,52.438,51.946000000000005,51.738,51.486999999999995,53.008,52.184,52.076,51.744,52.056999999999995,53.191,51.447,51.258,52.031000000000006,51.294,55.223,-18.718,52.815,52.188,51.00899999999999,3.026,38.908,51.694,21.526999999999997,25.011],\"colorscale\":\"Viridis\"}];"
            |> chartGeneratedContains densityMapboxChart
        );
        testCase "Density Mapbox layout" ( fun () ->
            "var layout = {\"mapbox\":{\"style\":\"stamen-terrain\",\"center\":{\"lon\":60.0,\"lat\":30.0}}};"
            |> chartGeneratedContains densityMapboxChart
        );
    ]