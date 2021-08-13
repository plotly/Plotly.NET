#r "nuget: FSharp.Data"
#r "nuget: Deedle"
#r "nuget: FSharpAux"
#r "nuget: Newtonsoft.Json, 12.0.3"
#r "nuget: DynamicObj"

#load "../Plotly.NET/StyleParams.fs"
#load "../Plotly.NET/Colors.fs"
#load "../Plotly.NET/Rangebreak.fs"
#load "../Plotly.NET/TickFormatStop.fs"
#load "../Plotly.NET/Selection.fs"
#load "../Plotly.NET/Frame.fs"
#load "../Plotly.NET/StockData.fs"
#load "../Plotly.NET/Font.fs"
#load "../Plotly.NET/Title.fs"
#load "../Plotly.NET/Pathbar.fs"
#load "../Plotly.NET/TreemapTiling.fs"
#load "../Plotly.NET/Colorbar.fs"
#load "../Plotly.NET/RangeSlider.fs"
#load "../Plotly.NET/Button.fs"
#load "../Plotly.NET/RangeSelector.fs"
#load "../Plotly.NET/Light.fs"
#load "../Plotly.NET/Legend.fs"
#load "../Plotly.NET/Contours.fs"
#load "../Plotly.NET/Dimensions.fs"
#load "../Plotly.NET/Domain.fs"
#load "../Plotly.NET/Line.fs"
#load "../Plotly.NET/WaterfallConnector.fs"
#load "../Plotly.NET/FunnelConnector.fs"
#load "../Plotly.NET/Box.fs"
#load "../Plotly.NET/Meanline.fs"
#load "../Plotly.NET/Marker.fs"
#load "../Plotly.NET/Hoverlabel.fs"
#load "../Plotly.NET/Axis.fs"
#load "../Plotly.NET/Polar.fs"
#load "../Plotly.NET/Bins.fs"
#load "../Plotly.NET/Cumulative.fs"
#load "../Plotly.NET/Scene.fs"
#load "../Plotly.NET/Selected.fs"
#load "../Plotly.NET/Shape.fs"
#load "../Plotly.NET/Error.fs"
#load "../Plotly.NET/Table.fs"
#load "../Plotly.NET/Trace.fs"
#load "../Plotly.NET/Trace3d.fs"
#load "../Plotly.NET/GeoProjection.fs"
#load "../Plotly.NET/Geo.fs"
#load "../Plotly.NET/MapboxLayerSymbol.fs"
#load "../Plotly.NET/MapboxLayer.fs"
#load "../Plotly.NET/Mapbox.fs"
#load "../Plotly.NET/LayoutGrid.fs"
#load "../Plotly.NET/Annotation.fs"
#load "../Plotly.NET/Layout.fs"
#load "../Plotly.NET/Template.fs"
#load "../Plotly.NET/Config.fs"
#load "../Plotly.NET/DisplayOptions.fs"
#load "../Plotly.NET/GenericChart.fs"
#load "../Plotly.NET/Chart.fs"
#load "../Plotly.NET/ChartExtensions.fs"
#load "../Plotly.NET/GenericChartExtensions.fs"
#load "../Plotly.NET/CandelstickExtension.fs"
#load "../Plotly.NET/SankeyExtension.fs"


open Plotly.NET
open GenericChart

open FSharp.Data
open Newtonsoft.Json
open System.Text
open System.IO
open Deedle
open FSharpAux


#r "nuget: PuppeteerSharp"

open PuppeteerSharp

#load "IGenericChartRenderer.fs"
#load "PuppeteerSharpRenderer.fs"
#load "ExportEngine.fs"
#load "ChartExtensions.fs"
#load "GenericChartExtensions.fs"

open Plotly.NET.ImageExport
open GenericChartExtensions

let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let xyz = Seq.zip3 x y x

let simpleChart = Chart.Point([1.,1.])

let complexChart = 
    Chart.Grid(
        [
            [Chart.Line(x,y); Chart.Line(x,y); Chart.Line(x,y)]
            [Chart.Histogram2dContour(x,y); Chart.Point(x,y); Chart.Point(x,y)]
            [Chart.Spline(x,y); Chart.Spline(x,y); Chart.Spline(x,y)]
        ]
    )

complexChart
|> Chart.Show

simpleChart
|> Chart.saveJPG (
    __SOURCE_DIRECTORY__ + "/testrenders/simple",
    EngineType = ExportEngine.PuppeteerSharp,
    Width= 1000,
    Height= 1000
)

open FSharp.Data
open Deedle

let dataDensityMapbox = 
    Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/master/earthquakes-23k.csv"
    |> fun d -> Frame.ReadCsvString(d,true,separators=",")

dataDensityMapbox.Print()

let lonDensity = dataDensityMapbox.["Longitude"] |> Series.values
let latDensity = dataDensityMapbox.["Latitude"] |> Series.values
let magnitudes = dataDensityMapbox.["Magnitude"] |> Series.values

let map =
    Chart.DensityMapbox(
        lonDensity,
        latDensity,
        Z = magnitudes,
        Radius=8.,
        Colorscale=StyleParam.Colorscale.Viridis
    )
    |> Chart.withMapbox(
        Mapbox.init(
            Style = StyleParam.MapboxStyle.StamenTerrain,
            Center = (60.,30.)
        )
    )


map.SaveSVG(__SOURCE_DIRECTORY__ + "/testrenders/map")

complexChart.SaveJPG (__SOURCE_DIRECTORY__ + "/testrenders/complex")

simpleChart
|> Chart.savePNG (__SOURCE_DIRECTORY__ + "/testrenders/simple")

complexChart
    .WithTitle("soos")
    .SavePNG(__SOURCE_DIRECTORY__ + "/testrenders/complex")

simpleChart
|> Chart.saveSVG (__SOURCE_DIRECTORY__ + "/testrenders/simple")

complexChart.SaveSVG (__SOURCE_DIRECTORY__ + "/testrenders/complex")

let jpgString =
    Chart.Point([1.,1.])

    |> Chart.toBase64JPGString()
    |> fun f -> File.WriteAllText(@"C:\Users\Kevin\source\repos\plotly\Plotly.NET\tests\Plotly.NET.Tests\data\testBase64JPG.txt", f)

let pngString =
    Chart.Point([1.,1.])
    |> Chart.toBase64PNGString()
    |> fun f -> File.WriteAllText(@"C:\Users\Kevin\source\repos\plotly\Plotly.NET\tests\Plotly.NET.Tests\data\testBase64PNG.txt", f)

let svgString = 
    Chart.Point([1.,1.])
    |> Chart.toSVGString()
    |> fun f -> File.WriteAllText(@"C:\Users\Kevin\source\repos\plotly\Plotly.NET\tests\Plotly.NET.Tests\data\testSVGURI.txt", f)
