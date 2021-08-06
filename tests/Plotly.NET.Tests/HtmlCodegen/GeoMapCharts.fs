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


let pointGeoChart =
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
    Chart.PointGeo(
        lon,
        lat,
        Labels=cityNames,
        TextPosition=StyleParam.TextPosition.TopCenter
    )
    |> Chart.withMapStyle(
        Scope=StyleParam.GeoScope.NorthAmerica, 
        Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
        CountryColor = "lightgrey"
    )
    |> Chart.withMarginSize(0, 0, 0, 0)

open Deedle
open FSharp.Data
open System.IO
open System.Text

let flightsMapChart =
    // this is not the original string, but its few first entries
    let data = 
        "start_lat,start_lon,end_lat,end_lon,airline,airport1,airport2,cnt
32.89595056,-97.0372,35.04022222,-106.6091944,AA,DFW,ABQ,444
41.979595,-87.90446417,30.19453278,-97.66987194,AA,ORD,AUS,166
32.89595056,-97.0372,41.93887417,-72.68322833,AA,DFW,BDL,162
18.43941667,-66.00183333,41.93887417,-72.68322833,AA,SJU,BDL,56
32.89595056,-97.0372,33.56294306,-86.75354972,AA,DFW,BHM,168
25.79325,-80.29055556,36.12447667,-86.67818222,AA,MIA,BNA,56
32.89595056,-97.0372,42.3643475,-71.00517917,AA,DFW,BOS,422
25.79325,-80.29055556,42.3643475,-71.00517917,AA,MIA,BOS,392
41.979595,-87.90446417,42.3643475,-71.00517917,AA,ORD,BOS,430
18.43941667,-66.00183333,42.3643475,-71.00517917,AA,SJU,BOS,56
18.33730556,-64.97336111,42.3643475,-71.00517917,AA,STT,BOS,44
25.79325,-80.29055556,39.17540167,-76.66819833,AA,MIA,BWI,112"
        |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

    let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
    let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
    let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
    let coords = Series.zipInner startCoords endCoords |> Series.values

    coords 
    |> Seq.mapi (fun i (startCoords,endCoords) ->
        Chart.LineGeo(
            [startCoords; endCoords],
            Opacity = opacityVals.[i],
            Color = "red"
        )
    )
    |> Chart.Combine
    |> Chart.withLegend(false)
    |> Chart.withMapStyle(
        Scope=StyleParam.GeoScope.NorthAmerica, 
        Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
        ShowLand=true,
        LandColor = "lightgrey"
    )
    |> Chart.withMarginSize(0,0,50,0)
    |> Chart.withTitle "Feb. 2011 American Airline flights"


[<Tests>]
let ``Scatter and line plots on Geo maps charts`` =
    testList "GeoMapCharts.Scatter and line plots on Geo maps charts" [
        testCase "Point geo data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers+text\",\"lon\":[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6],\"lat\":[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45],\"marker\":{},\"text\":[\"Montreal\",\"Toronto\",\"Vancouver\",\"Calgary\",\"Edmonton\",\"Ottawa\",\"Halifax\",\"Victoria\",\"Winnepeg\",\"Regina\"],\"textposition\":\"top center\"}];"
            |> chartGeneratedContains pointGeoChart
        );
        testCase "Point geo layout" ( fun () ->
            "var layout = {\"geo\":{\"scope\":\"north america\",\"projection\":{\"type\":\"azimuthal equal area\"},\"countrycolor\":\"lightgrey\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains pointGeoChart
        );
        testCase "Flight map data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-106.6091944],\"lat\":[32.89595056,35.04022222],\"opacity\":1.0,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-87.90446417,-97.66987194],\"lat\":[41.979595,30.19453278],\"opacity\":0.3738738738738739,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-72.68322833],\"lat\":[32.89595056,41.93887417],\"opacity\":0.36486486486486486,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-66.00183333,-72.68322833],\"lat\":[18.43941667,41.93887417],\"opacity\":0.12612612612612611,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-86.75354972],\"lat\":[32.89595056,33.56294306],\"opacity\":0.3783783783783784,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-80.29055556,-86.67818222],\"lat\":[25.79325,36.12447667],\"opacity\":0.12612612612612611,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-71.00517917],\"lat\":[32.89595056,42.3643475],\"opacity\":0.9504504504504504,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-80.29055556,-71.00517917],\"lat\":[25.79325,42.3643475],\"opacity\":0.8828828828828829,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-87.90446417,-71.00517917],\"lat\":[41.979595,42.3643475],\"opacity\":0.9684684684684685,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-66.00183333,-71.00517917],\"lat\":[18.43941667,42.3643475],\"opacity\":0.12612612612612611,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-64.97336111,-71.00517917],\"lat\":[18.33730556,42.3643475],\"opacity\":0.0990990990990991,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-80.29055556,-76.66819833],\"lat\":[25.79325,39.17540167],\"opacity\":0.25225225225225223,\"marker\":{\"color\":\"red\"}}];"
            |> chartGeneratedContains flightsMapChart
        );
        testCase "Flight map layout" ( fun () ->
            "var layout = {\"showlegend\":false,\"geo\":{\"scope\":\"north america\",\"projection\":{\"type\":\"azimuthal equal area\"},\"showland\":true,\"landcolor\":\"lightgrey\"},\"margin\":{\"l\":0,\"r\":0,\"t\":50,\"b\":0},\"title\":\"Feb. 2011 American Airline flights\"};"
            |> chartGeneratedContains flightsMapChart
        );
    ]