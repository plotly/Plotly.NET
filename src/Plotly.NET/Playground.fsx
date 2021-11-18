#r "nuget: FSharp.Data"
#r "nuget: Deedle"
#r "nuget: FSharpAux"
#r "nuget: DynamicObj"
#r "nuget: Newtonsoft.Json, 13.0.1"

#load "InternalUtils.fs"

#I "CommonAbstractions"

#load "StyleParams.fs"
#load "ColorKeyword.fs"
#load "Colors.fs"
#load "Frame.fs"
#load "Font.fs"
#load "Title.fs"
#load "Line.fs"

#I "Layout/ObjectAbstractions/Common"

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

#I "Layout/ObjectAbstractions/Map"

#load "GeoProjection.fs"
#load "Geo.fs"
#load "MapboxLayerSymbol.fs"
#load "MapboxLayer.fs"
#load "Mapbox.fs"

#I "Layout/ObjectAbstractions/3D"

#load "Camera.fs"
#load "AspectRatio.fs"
#load "Scene.fs"

#I "Layout/ObjectAbstractions/Polar"

#load "AngularAxis.fs"
#load "RadialAxis.fs"
#load "Polar.fs"

#I "Layout/ObjectAbstractions/Ternary"

#load "Ternary.fs"

#I "Layout/ObjectAbstractions/Common/Slider"

#load "SliderCurrentValue.fs"
#load "SliderStep.fs"
#load "Slider.fs"

#load "Layout/Layout.fs"

#I "Traces/ObjectAbstractions"

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

#I "Traces"

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

#I "Config/ObjectAbstractions"

#load "ToImageButtonOptions.fs"

#I "Config"

#load "Config.fs"

#I "DisplayOptions"

#load "DisplayOptions.fs"

#I "Templates"

#load "Template.fs"
#load "ChartTemplates.fs"
#load "Defaults.fs"

#I "ChartAPI"

#load "GenericChart.fs"
#load "Chart.fs"
#load "Chart2D.fs"
#load "Chart3D.fs"
#load "ChartPolar.fs"
#load "ChartMap.fs"
#load "ChartTernary.fs"
#load "ChartCarpet.fs"
#load "ChartDomain.fs"

#I "CSharpLayer"

#load "GenericChartExtensions.fs"

#I "Extensions"

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

open FSharp.Data
open Deedle

Chart.Bubble3D(
    [for i in 0..10 do yield (i,i,i)],
    [0 .. 10 .. 100],
    MarkerColor = Color.fromColorScaleValues [0..10],
    MarkerSymbol = StyleParam.MarkerSymbol3D.Diamond
)

|> Chart.show


let data = 
    Http.RequestString @"https://raw.githubusercontent.com/plotly/datasets/master/iris-data.csv"
    |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

let sepalLengthData = data.["sepal length"] |> Series.values
let sepalWidthData = data.["sepal width"]  |> Series.values
let petalLengthData = data.["petal length"] |> Series.values
let petalWidthData = data.["petal width"]  |> Series.values


let colors = 
    data
    |> Frame.getCol "class"
    |> Series.values
    |> Seq.cast<string>
    |> Seq.map (fun x ->
        match x with
        | "Iris-setosa" -> 0.
        | "Iris-versicolor" -> 0.5
        | _ -> 1
    )
    |> Color.fromColorScaleValues

Chart.Splom(
    [
        "sepal length" , sepalLengthData
        "sepal width"  , sepalWidthData
        "petal length" , petalLengthData
        "petal width"  , petalWidthData
    ],
    MarkerColor = colors
)
|> Chart.withLayout(
    Layout.init(
        HoverMode = StyleParam.HoverMode.Closest,
        DragMode = StyleParam.DragMode.Select
    )
)
|> Chart.withSize (1000,1000)
|> Chart.show


Chart.Splom(
    [
        "sepal length" , sepalLengthData
        "sepal width"  , sepalWidthData
        "petal length" , petalLengthData
        "petal width"  , petalWidthData
    ],
    MarkerColor = colors,
    ShowDiagonal = false
)
|> Chart.withLayout(
    Layout.init(
        HoverMode = StyleParam.HoverMode.Closest,
        DragMode = StyleParam.DragMode.Select
    )
)
|> Chart.withSize (1000,1000)
|> Chart.show

Chart.Splom(
    [
        "sepal length" , sepalLengthData
        "sepal width"  , sepalWidthData
        "petal length" , petalLengthData
        "petal width"  , petalWidthData
    ],
    MarkerColor = colors,
    ShowLowerHalf = false
)
|> Chart.withLayout(
    Layout.init(
        HoverMode = StyleParam.HoverMode.Closest,
        DragMode = StyleParam.DragMode.Select
    )
)
|> Chart.withSize (1000,1000)
|> Chart.show