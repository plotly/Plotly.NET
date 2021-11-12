module Tests.CarpetCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

let a = [4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6.]
let b = [1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.]
let y = [2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10.]

let carpets = 
    [
        Chart.Carpet("carpet1",A = a, B = b, Y = y, UseDefaults = false)
        Chart.Carpet("carpet2",A = (a |> List.rev) , B = (b |> List.rev), Y = (y |> List.map (fun x -> x + 10.)), UseDefaults = false)
        Chart.Carpet("carpet3",A = a, B = b, Y = (y |> List.map (fun x -> x + 20.)), UseDefaults = false)
        Chart.Carpet("carpet4",A = (a |> List.rev) , B = (b |> List.rev), Y = (y |> List.map (fun x -> x + 30.)), UseDefaults = false)
        Chart.Carpet("carpet5",A = a, B = b, Y = (y |> List.map (fun x -> x + 40.)), UseDefaults = false)
    ]

let aData = [4.; 5.; 5.; 6.]
let bData = [1.; 1.; 2.; 3.]
let sizes = [5; 10; 15; 20]


let carpetCharts =
    [
        Chart.ScatterCarpet(
            aData,bData,
            StyleParam.Mode.Lines_Markers,
            "carpet1",
            Name = "Scatter",
            MultiMarkerSymbol =[
                StyleParam.MarkerSymbol.ArrowDown
                StyleParam.MarkerSymbol.TriangleNW
                StyleParam.MarkerSymbol.DiamondX
                StyleParam.MarkerSymbol.Hexagon2
            ],
            MultiSize = sizes,
            Color = Color.fromColors ([Red; Blue; Green; Yellow] |> List.map Color.fromKeyword), 
            UseDefaults = false
        )
        Chart.PointCarpet(aData,bData,"carpet2",Name = "Point", UseDefaults = false)
        Chart.LineCarpet(aData,bData,"carpet3",Name = "Line", UseDefaults = false)
        Chart.SplineCarpet(aData,bData,"carpet4",Name = "Spline", UseDefaults = false)
        Chart.BubbleCarpet((Seq.zip3 aData bData sizes),"carpet5",Name = "Bubble", UseDefaults = false)
    ]

let scatter = Chart.combine [carpets.[0]; carpetCharts.[0]]
let point   = Chart.combine [carpets.[1]; carpetCharts.[1]]
let line    = Chart.combine [carpets.[2]; carpetCharts.[2]]
let spline  = Chart.combine [carpets.[3]; carpetCharts.[3]]
let bubble  = Chart.combine [carpets.[4]; carpetCharts.[4]]


[<Tests>]
let ``ScatterCarpet and derived Charts`` =
    testList "CarpetCharts.ScatterCarpet and derived Charts" [
        testCase "ScatterCarpet data" ( fun () ->
            """var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpet1"},{"type":"scattercarpet","name":"Scatter","mode":"lines+markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpet1","marker":{"color":["rgba(255, 0, 0, 1.0)","rgba(0, 0, 255, 1.0)","rgba(0, 128, 0, 1.0)","rgba(255, 255, 0, 1.0)"],"size":[5,10,15,20],"symbol":["46","12","32","15"]},"line":{"color":["rgba(255, 0, 0, 1.0)","rgba(0, 0, 255, 1.0)","rgba(0, 128, 0, 1.0)","rgba(255, 255, 0, 1.0)"]}}];"""
            |> chartGeneratedContains scatter
        );
        testCase "ScatterCarpet layout" ( fun () ->
            emptyLayout scatter
        );
        testCase "PointCarpet data" ( fun () ->
            """var data = [{"type":"carpet","y":[12.0,13.5,14.0,13.0,14.5,15.0,15.5,16.5,17.5,18.0,18.5,20.0],"a":[6.0,6.0,6.0,5.0,5.0,5.0,4.5,4.5,4.5,4.0,4.0,4.0],"b":[3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0],"carpet":"carpet2"},{"type":"scattercarpet","name":"Point","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpet2","marker":{}}];"""
            |> chartGeneratedContains point
        );
        testCase "PointCarpet layout" ( fun () ->
            emptyLayout point
        );
        testCase "LineCarpet data" ( fun () ->
            """var data = [{"type":"carpet","y":[22.0,23.5,24.0,23.0,24.5,25.0,25.5,26.5,27.5,28.0,28.5,30.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpet3"},{"type":"scattercarpet","name":"Line","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpet3","marker":{},"line":{}}];"""
            |> chartGeneratedContains line
        );
        testCase "LineCarpet layout" ( fun () ->
            emptyLayout line
        );
        testCase "SplineCarpet data" ( fun () ->
            """var data = [{"type":"carpet","y":[32.0,33.5,34.0,33.0,34.5,35.0,35.5,36.5,37.5,38.0,38.5,40.0],"a":[6.0,6.0,6.0,5.0,5.0,5.0,4.5,4.5,4.5,4.0,4.0,4.0],"b":[3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0],"carpet":"carpet4"},{"type":"scattercarpet","name":"Spline","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpet4","marker":{},"line":{"shape":"spline"}}];"""
            |> chartGeneratedContains spline
        );
        testCase "SplineCarpet layout" ( fun () ->
            emptyLayout spline
        );
        testCase "BubbleCarpet data" ( fun () ->
            """var data = [{"type":"carpet","y":[42.0,43.5,44.0,43.0,44.5,45.0,45.5,46.5,47.5,48.0,48.5,50.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpet5"},{"type":"scattercarpet","name":"Bubble","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpet5","marker":{"size":[5,10,15,20]}}];"""
            |> chartGeneratedContains bubble
        );
        testCase "BubbleCarpet layout" ( fun () ->
            emptyLayout bubble
        );
        
    ]


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
            UseDefaults = false
        )    
        Chart.ContourCarpet(
            "contour",
            [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
            A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
            B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6], 
            UseDefaults = false
        )
    ]
    |> Chart.combine

[<Tests>]
let ``ContourCarpet Charts`` =
    testList "CarpetCharts.ContourCarpet Charts" [
        testCase "ScatterCarpet data" ( fun () ->
            """var data = [{"type":"carpet","x":[2.0,3.0,4.0,5.0,2.2,3.1,4.1,5.1,1.5,2.5,3.5,4.5],"y":[1.0,1.4,1.6,1.75,2.0,2.5,2.7,2.75,3.0,3.5,3.7,3.75],"a":[0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0],"b":[4.0,4.0,4.0,4.0,5.0,5.0,5.0,5.0,6.0,6.0,6.0,6.0],"aaxis":{"type":"linear","tickprefix":"a = ","minorgridcount":9,"smoothing":0.0},"baxis":{"type":"linear","tickprefix":"b = ","minorgridcount":9,"smoothing":0.0},"carpet":"contour"},{"type":"contourcarpet","z":[1.0,1.96,2.56,3.0625,4.0,5.0625,1.0,7.5625,9.0,12.25,15.21,14.0625],"a":[0,1,2,3,0,1,2,3,0,1,2,3],"b":[4,4,4,4,5,5,5,5,6,6,6,6],"carpet":"contour","line":{}}];"""
            |> chartGeneratedContains contour
        );
        testCase "ScatterCarpet layout" ( fun () ->
            emptyLayout contour
        );
    ]