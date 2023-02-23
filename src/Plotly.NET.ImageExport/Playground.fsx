#r "nuget: FSharp.Data"
#r "nuget: Deedle"
#r "nuget: FSharpAux"
#r "nuget: DynamicObj"
#r "nuget: Newtonsoft.Json, 13.0.1"

#load "../Plotly.NET/InternalUtils.fs"

#I "../Plotly.NET/CommonAbstractions"

#load "StyleParams.fs"
#load "ColorKeyword.fs"
#load "Colors.fs"
#load "Frame.fs"
#load "Font.fs"
#load "Title.fs"
#load "Line.fs"

#I "../Plotly.NET/Layout/ObjectAbstractions/Common"

#load "LayoutImage.fs"
#load "Button.fs"
#load "RangeSelector.fs"
#load "RangeSlider.fs"
#load "Transition.fs"
#load "ActiveShape.fs"
#load "ModeBar.fs"
#load "DefaultColorScales.fs"
#load "UniformText.fs"
#load "Margin.fs"
#load "Domain.fs"
#load "Shape.fs"
#load "Hoverlabel.fs"
#load "Annotation.fs"
#load "LayoutGrid.fs"
#load "Legend.fs"
#load "TickFormatStop.fs"
#load "ColorBar.fs"
#load "Rangebreak.fs"
#load "LinearAxis.fs"
#load "ColorAxis.fs"
#load "Padding.fs"

#I "../Plotly.NET/Layout/ObjectAbstractions/Map"

#load "GeoProjection.fs"
#load "Geo.fs"
#load "MapboxLayerSymbol.fs"
#load "MapboxLayer.fs"
#load "Mapbox.fs"

#I "../Plotly.NET/Layout/ObjectAbstractions/3D"

#load "Camera.fs"
#load "AspectRatio.fs"
#load "Scene.fs"

#I "../Plotly.NET/Layout/ObjectAbstractions/Polar"

#load "AngularAxis.fs"
#load "RadialAxis.fs"
#load "Polar.fs"

#I "../Plotly.NET/Layout/ObjectAbstractions/Ternary"

#load "Ternary.fs"

#I "../Plotly.NET/Layout/ObjectAbstractions/Common/Slider"

#load "SliderCurrentValue.fs"
#load "SliderStep.fs"
#load "Slider.fs"

#load "../Plotly.NET/Layout/Layout.fs"

#I "../Plotly.NET/Traces/ObjectAbstractions"

#load "Gradient.fs"
#load "Pattern.fs"
#load "Marker.fs"
#load "Projection.fs"
#load "Surface.fs"
#load "SpaceFrame.fs"
#load "Slices.fs"
#load "Caps.fs"
#load "StreamTubeStarts.fs"
#load "Lighting.fs"
#load "Selection.fs"
#load "StockData.fs"
#load "Pathbar.fs"
#load "TreemapTiling.fs"
#load "Contours.fs"
#load "Dimensions.fs"
#load "WaterfallConnector.fs"
#load "FunnelConnector.fs"
#load "Box.fs"
#load "MeanLine.fs"
#load "Bins.fs"
#load "Cumulative.fs"
#load "Error.fs"
#load "Table.fs"
#load "Indicator.fs"
#load "Icicle.fs"
#load "FinanceMarker.fs"
#load "SplomDiagonal.fs"

#I "../Plotly.NET/Traces"

#load "Trace.fs"
#load "Trace2D.fs"
#load "Trace3D.fs"
#load "TracePolar.fs"
#load "TraceGeo.fs"
#load "TraceMapbox.fs"
#load "TraceTernary.fs"
#load "TraceCarpet.fs"
#load "TraceDomain.fs"
#load "TraceID.fs"

#I "../Plotly.NET/Config/ObjectAbstractions"

#load "ToImageButtonOptions.fs"

#I "../Plotly.NET/Config"

#load "Config.fs"

#I "../Plotly.NET/DisplayOptions"

#load "DisplayOptions.fs"

#I "../Plotly.NET/Templates"

#load "Template.fs"
#load "ChartTemplates.fs"
#load "Defaults.fs"

#I "../Plotly.NET/ChartAPI"

#load "GenericChart.fs"
#load "Chart.fs"
#load "Chart2D.fs"
#load "Chart3D.fs"
#load "ChartPolar.fs"
#load "ChartMap.fs"
#load "ChartTernary.fs"
#load "ChartCarpet.fs"
#load "ChartDomain.fs"

#I "../Plotly.NET/CSharpLayer"

#load "GenericChartExtensions.fs"

#I "../Plotly.NET/Extensions"

#load "SankeyExtension.fs"

open DynamicObj

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects

open FSharp.Data
open Newtonsoft.Json
open System.Text
open System.IO
open Deedle
open FSharpAux

open System
open System.IO

open Plotly.NET

open System
open Plotly.NET

#r "nuget: FSharp.Data"
#r "nuget: Deedle"


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

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]
let xyz = Seq.zip3 x y x

let simpleChart = Chart.Point([ 1., 1. ])

let complexChart =
    [ [ Chart.Line(x, y); Chart.Line(x, y); Chart.Line(x, y) ]
      [ Chart.Histogram2DContour(x, y); Chart.Point(x, y); Chart.Point(x, y) ]
      [ Chart.Spline(x, y); Chart.Spline(x, y); Chart.Spline(x, y) ] ]
    |> Chart.Grid()



complexChart |> Chart.show

simpleChart
|> Chart.saveJPG (
    __SOURCE_DIRECTORY__ + "/testrenders/simple",
    EngineType = ExportEngine.PuppeteerSharp,
    Width = 1000,
    Height = 1000
)

open FSharp.Data
open Deedle

let dataDensityMapbox =
    Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/master/earthquakes-23k.csv"
    |> fun d -> Frame.ReadCsvString(d, true, separators = ",")

dataDensityMapbox.Print()

let lonDensity = dataDensityMapbox.["Longitude"] |> Series.values
let latDensity = dataDensityMapbox.["Latitude"] |> Series.values
let magnitudes = dataDensityMapbox.["Magnitude"] |> Series.values

let map =
    Chart.DensityMapbox(lonDensity, latDensity, Z = magnitudes, Radius = 8., Colorscale = StyleParam.Colorscale.Viridis)
    |> Chart.withMapbox (Mapbox.init (Style = StyleParam.MapboxStyle.StamenTerrain, Center = (60., 30.)))


let jpgString =
    Chart.Point([ 1., 1. ])

    |> Chart.toBase64JPGString ()
    |> fun f ->
        File.WriteAllText(
            @"C:\Users\schne\source\repos\plotly\Plotly.NET\tests\Plotly.NET.ImageExport.Tests\data\testBase64JPG.txt",
            f
        )

let pngString =
    Chart.Point([ 1., 1. ])
    |> Chart.toBase64PNGString ()
    |> fun f ->
        File.WriteAllText(
            @"C:\Users\schne\source\repos\plotly\Plotly.NET\tests\Plotly.NET.ImageExport.Tests\data\testBase64PNG.txt",
            f
        )

let a =
    File.ReadAllBytes(
        @"C:\Users\schne\source\repos\plotly\Plotly.NET\tests\Plotly.NET.ImageExport.Tests\data\testPNG.png"
    )
    |> Convert.ToBase64String

Chart.Point([ 1., 1. ])
|> Chart.toBase64PNGString ()
|> fun x -> x.Contains(a)

let svgString =
    Chart.Point([ 1., 1. ])
    |> Chart.toSVGString ()
    |> fun f ->
        File.WriteAllText(
            @"C:\Users\schne\source\repos\plotly\Plotly.NET\tests\Plotly.NET.ImageExport.Tests\data\testSVGURI.txt",
            f
        )
