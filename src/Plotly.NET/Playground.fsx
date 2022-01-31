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
#load "TickFormatStop.fs"
#load "Frame.fs"
#load "Font.fs"
#load "Title.fs"
#load "ColorBar.fs"
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
#load "Rangebreak.fs"
#load "LinearAxis.fs"
#load "ColorAxis.fs"
#load "Padding.fs"
#load "Updatemenu.fs"

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
#load "Treemap.fs"
#load "Sunburst.fs"
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
#load "Sankey.fs"

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


let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]

let y2 =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x2 = ["bin3";"bin4";"bin3";"bin4";"bin3";"bin4";"bin3";"bin3";"bin4";"bin3"]

let violin1 =
    Chart.Violin (
        x,y,
        ShowBox = true,
        BoxFillColor = Color.fromKeyword ColorKeyword.Red)

let violin2 =
    Chart.Violin (
        x2,y2,
        ShowBox = true,
        BoxFillColor = Color.fromKeyword ColorKeyword.Green)

[
    violin1
    violin2
]
|> Chart.combine
|> Chart.withTraceInfo(
    Name = "violins",
    LegendGroup = "violins",
    LegendGroupTitle = Title.init("Some violins m8")
)
|> Chart.show

let table1 =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
        [
         ["0";"I"     ;"am"     ;"a"]        
         ["1";"little";"example";"!"]       
        ]
    Chart.Table(header, rows)
    |> Chart.show

Trace2D.initHistogram(
    Trace2DStyle.Histogram(
        Y = [1;2;3;3;4;4;4;5;6;6;7]
    )
)
|> GenericChart.ofTraceObject true
|> Chart.show

let contour = 
    [
        Chart.Carpet(
            "contour",
            A = [0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.],
            B = [4.; 4.; 4.; 4.; 5.; 5.; 5.; 5.; 6.; 6.; 6.; 6.],
            X = [2.; 3.; 4.; 5.; 2.2; 3.1; 4.1; 5.1; 1.5; 2.5; 3.5; 4.5],
            Y = [1.; 1.4; 1.6; 1.75; 2.; 2.5; 2.7; 2.75; 3.; 3.5; 3.7; 3.75],
            AAxis = LinearAxis.initCarpet(
                TickPrefix = "a = ",
                Smoothing = 0.,
                MinorGridCount = 9,
                AxisType = StyleParam.AxisType.Linear
            ),
            BAxis = LinearAxis.initCarpet(
                TickPrefix = "b = ",
                Smoothing = 0.,
                MinorGridCount = 9,
                AxisType = StyleParam.AxisType.Linear
            ), 
            UseDefaults = false,
            Opacity = 0.75
        )    
        Chart.ContourCarpet(
            [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
            "contour",
            A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
            B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6], 
            UseDefaults = false,
            ContourLineColor = Color.fromKeyword White,
            ShowContourLabels = true
        )
    ]
    |> Chart.combine
    |> Chart.show

Chart.BubbleTernary(
    [
        1,2,3,5
        2,2,2,15
        3,2,1,25
    ]
)
|> Chart.show

let multiTraceGrid = 
    [
        Chart.Point([1,2; 2,3], UseDefaults = false)
        Chart.PointTernary([1,2,3; 2,3,4], UseDefaults = false)
        Chart.Heatmap([[1; 2];[3; 4]], ShowScale=false, UseDefaults = false)
        Chart.Point3D([1,3,2], UseDefaults = false)
        Chart.PointMapbox([1,2], UseDefaults = false) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
        [
            // you can use nested combined charts, but they have to have the same trace type (Cartesian2D in this case)
            let y =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
            Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
            Chart.BoxPlot("y'",y,Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
        ]
        |> Chart.combine
    ]
    |> Chart.Grid(2,3)
    |> Chart.withSize(1000,1000)
    |> Chart.show

let multiTraceSingleStack = 
    [
        Chart.Point([1,2; 2,3], UseDefaults = false)
        Chart.PointTernary([1,2,3; 2,3,4], UseDefaults = false)
        Chart.Heatmap([[1; 2];[3; 4]], ShowScale=false, UseDefaults = false)
        Chart.Point3D([1,3,2], UseDefaults = false)
        Chart.PointMapbox([1,2], UseDefaults = false) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
        [
            // you can use nested combined charts, but they have to have the same trace type (Cartesian2D in this case)
            let y =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
            Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
            Chart.BoxPlot("y'",y,Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
        ]
        |> Chart.combine
    ]
    |> Chart.SingleStack()
    |> Chart.withSize(1000,1000)
    |> Chart.show