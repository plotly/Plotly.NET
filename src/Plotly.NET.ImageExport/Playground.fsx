#r "nuget: FSharp.Data"
#r "nuget: Deedle"
#r "nuget: FSharpAux"
#r "nuget: Newtonsoft.Json, 12.0.3"

#load "../Plotly.NET/StyleParams.fs"
#load "../Plotly.NET/DynamicObj.fs"
#load "../Plotly.NET/Frame.fs"
#load "../Plotly.NET/Colors.fs"
#load "../Plotly.NET/StockData.fs"
#load "../Plotly.NET/Font.fs"
#load "../Plotly.NET/Pathbar.fs"
#load "../Plotly.NET/TreemapTiling.fs"
#load "../Plotly.NET/Colorbar.fs"
#load "../Plotly.NET/RangeSlider.fs"
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

Chart.Point([1.,1.])
|> Chart.saveJPG @"C:\Users\Kevin\source\test.jpg"

Chart.Point([1.,1.])
|> Chart.savePNG @"C:\Users\Kevin\source\test.png"

Chart.Point([1.,1.])
|> Chart.saveSVG @"C:\Users\Kevin\source\test.svg"

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
