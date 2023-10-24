module ChartMapTestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open System

open TestUtils.DataGeneration
open Deedle

module GeoBaseMap =

    let ``Base map only`` =
        Chart.PointGeo(locations = [], UseDefaults = false) // deliberately empty chart to show the base map only
        |> Chart.withMarginSize(0, 0, 0, 0)

    let ``styled base map only`` =
        let myGeo =
            Geo.init(
                Resolution=StyleParam.GeoResolution.R50,
                ShowCoastLines=true, 
                CoastLineColor=Color.fromString "RebeccaPurple",
                ShowLand=true, 
                LandColor=Color.fromString "LightGreen",
                ShowOcean=true, 
                OceanColor=Color.fromString "LightBlue",
                ShowLakes=true, 
                LakeColor=Color.fromString "Blue",
                ShowRivers=true, 
                RiverColor=Color.fromString "Blue"
            )
        Chart.PointGeo(locations = [], UseDefaults = false)
        |> Chart.withGeo myGeo
        |> Chart.withMarginSize(0, 0, 0, 0)

    let ``Base map country borders at 1:50m resolution`` =
        let countryGeo =
            Geo.init(
                Visible=false, 
                Resolution=StyleParam.GeoResolution.R50,
                ShowCountries=true, 
                CountryColor=Color.fromString "RebeccaPurple"
            )
        Chart.PointGeo(locations = [], UseDefaults = false)
        |> Chart.withGeo countryGeo
        |> Chart.withMarginSize(0, 0, 0, 0)

module ChoroplethMap = 

    let ``ChoroplethMap chart of top beverage consumption countries`` =
        let locations,z = 
            beverageConsumptionLocationData
            |> List.unzip

        Chart.ChoroplethMap(
            locations = locations,z = z,
            LocationMode=StyleParam.LocationFormat.CountryNames,
            UseDefaults = false
        )

    let ``ChoroplethMap chart of top beverage consumption countries with styled map and projecton`` =
        let locations,z = 
            beverageConsumptionLocationData
            |> List.unzip

        Chart.ChoroplethMap(
            locations = locations,z = z,
            LocationMode=StyleParam.LocationFormat.CountryNames, 
            UseDefaults = false
        )
        |> Chart.withGeoStyle(
            Projection=GeoProjection.init(projectionType=StyleParam.GeoProjectionType.Mollweide),
            ShowLakes=true,
            ShowOcean=true,
            OceanColor= Color.fromString "lightblue",
            ShowRivers=true)
        |> Chart.withColorBarStyle (
            TitleText="Alcohol consumption[l/y]",Len=0.5
        )

module ScatterGeo = ()

module PointGeo = 

    let ``Point geo chart of canadian cities`` =

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
            longitudes = lon,
            latitudes = lat,
            MultiText=cityNames,
            TextPosition=StyleParam.TextPosition.TopCenter, 
            UseDefaults = false
        )
        |> Chart.withGeoStyle(
            Scope=StyleParam.GeoScope.NorthAmerica, 
            Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
            CountryColor = Color.fromString "lightgrey"
        )
        |> Chart.withMarginSize(0, 0, 0, 0)


module LineGeo = 

    let ``LineGeo plot of feb. 2011 American Airline flights`` =
        let data = 
            FlightData
            |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

        let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
        let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
        let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
        let coords = Series.zipInner startCoords endCoords |> Series.values

        coords 
        |> Seq.mapi (fun i (startCoords,endCoords) ->
            Chart.LineGeo(
                lonlat = [startCoords; endCoords],
                Opacity = opacityVals.[i],
                MarkerColor = Color.fromString  "red",
                UseDefaults = false
            )
        )
        |> Chart.combine
        |> Chart.withLayoutStyle(ShowLegend = false)
        |> Chart.withGeoStyle(
            Scope=StyleParam.GeoScope.NorthAmerica, 
            Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
            ShowLand=true,
            LandColor = Color.fromString "lightgrey"
        )
        |> Chart.withMarginSize(0,0,50,0)
        |> Chart.withTitle "Feb. 2011 American Airline flights"

module MapboxBaseMap =
    let ``Open streetmap layer only`` =

        Chart.PointMapbox(
            longitudes = [], 
            latitudes = [], 
            UseDefaults = false
        )
        // open street map is default layer

module ScatterMapbox = ()

module PointMapbox = 
    
    let ``Point mapbox chart of canadian cities`` =
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
            longitudes = lon,
            latitudes = lat,
            MultiText = cityNames,
            TextPosition = StyleParam.TextPosition.TopCenter, 
            UseDefaults = false
        )
        |> Chart.withMapbox(
            Mapbox.init(
                Center=(-104.6,50.45)
            )
        )

module LineMapbox = 

    let ``LineMapbox plot of feb. 2011 American Airline flights`` =
        
        let data = 
            FlightData
            |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")
    
        let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
        let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
        let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
        let coords = Series.zipInner startCoords endCoords |> Series.values

        coords 
        |> Seq.mapi (fun i (startCoords,endCoords) ->
            Chart.LineMapbox(
                lonlat = [startCoords; endCoords],
                Opacity = opacityVals.[i],
                LineColor = Color.fromString "red",
                UseDefaults = false
            )
        )
        |> Chart.combine
        |> Chart.withLayoutStyle(ShowLegend = false)
        |> Chart.withMapbox(
            Mapbox.init(
                Center=(-97.0372,32.8959)
            )
        )
        |> Chart.withMarginSize(0,0,50,0)
        |> Chart.withTitle "Feb. 2011 American Airline flights"
    

module BubbleMapbox = ()

module ChoroplethMapbox = ()

module DensityMapbox = 

    let ``Density mapbox chart of earthquakes`` =
        let dataDensityMapbox = 
            EarthquakeData
            |> fun d -> Frame.ReadCsvString(d,true,separators=",")
    
        let lon = dataDensityMapbox.["Longitude"] |> Series.values
        let lat= dataDensityMapbox.["Latitude"] |> Series.values
        let magnitudes = dataDensityMapbox.["Magnitude"] |> Series.values
        Chart.DensityMapbox(
            longitudes = lon,
            latitudes = lat,
            Z = magnitudes,
            Radius=8,
            ColorScale=StyleParam.Colorscale.Viridis,
            UseDefaults = false
        )
        |> Chart.withMapbox(
            Mapbox.init(
                Style = StyleParam.MapboxStyle.StamenTerrain,
                Center = (60.,30.)
            )
        )
