module ChartCarpetTestCharts


open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open System

open TestUtils.DataGeneration
open Deedle

let internal a = [4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6.]
let internal b = [1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.]
let internal y = [2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10.]

let internal carpets = 
    [
        Chart.Carpet(carpetId = "carpet1",A = a, B = b, Y = y, UseDefaults = false)
        Chart.Carpet(carpetId = "carpet2",A = (a |> List.rev) , B = (b |> List.rev), Y = (y |> List.map (fun x -> x + 10.)), UseDefaults = false)
        Chart.Carpet(carpetId = "carpet3",A = a, B = b, Y = (y |> List.map (fun x -> x + 20.)), UseDefaults = false)
        Chart.Carpet(carpetId = "carpet4",A = (a |> List.rev) , B = (b |> List.rev), Y = (y |> List.map (fun x -> x + 30.)), UseDefaults = false)
        Chart.Carpet(carpetId = "carpet5",A = a, B = b, Y = (y |> List.map (fun x -> x + 40.)), UseDefaults = false)
    ]

let internal aData = [4.; 5.; 5.; 6.]
let internal bData = [1.; 1.; 2.; 3.]
let internal sizes = [5; 10; 15; 20]

let internal carpetCharts =
    [
        Chart.ScatterCarpet(
            a = aData,b = bData,
            mode = StyleParam.Mode.Lines_Markers,
            carpetAnchorId = "carpet1",
            Name = "Scatter",
            MultiMarkerSymbol =[
                StyleParam.MarkerSymbol.ArrowDown
                StyleParam.MarkerSymbol.TriangleNW
                StyleParam.MarkerSymbol.DiamondX
                StyleParam.MarkerSymbol.Hexagon2
            ],
            MarkerColor = Color.fromColors ([Red; Blue; Green; Yellow] |> List.map Color.fromKeyword), 
            UseDefaults = false
        )
        Chart.PointCarpet(a = aData, b = bData, carpetAnchorId = "carpet2",Name = "Point", UseDefaults = false)
        Chart.LineCarpet(a = aData, b = bData, carpetAnchorId = "carpet3",Name = "Line", UseDefaults = false)
        Chart.SplineCarpet(a = aData, b = bData, carpetAnchorId = "carpet4",Name = "Spline", UseDefaults = false)
        Chart.BubbleCarpet(absizes = (Seq.zip3 aData bData sizes), carpetAnchorId = "carpet5",Name = "Bubble", UseDefaults = false)
    ]

module Carpet = 

    let ``Base carpet chart`` = carpets[0]

module ScatterCarpet = 
    
        let ``Simple carpet scatter chart`` = Chart.combine [carpets.[0]; carpetCharts.[0]]
   
module PointCarpet = 
    
    let ``Simple carpet point chart`` = Chart.combine [carpets.[1]; carpetCharts.[1]]

module LineCarpet = 
    
    let ``Simple carpet line chart`` = Chart.combine [carpets.[2]; carpetCharts.[2]]

module SplineCarpet = 

    let ``Simple carpet spline chart`` = Chart.combine [carpets.[3]; carpetCharts.[3]]

module BubbleCarpet = 

    let ``Simple carpet bubble chart`` = Chart.combine [carpets.[4]; carpetCharts.[4]]

module ContourCarpet = 

    let ``Styled carpet contour chart`` =
        [
            Chart.Carpet(
                carpetId = "contour",
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
                z = [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
                carpetAnchorId = "contour",
                A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
                B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6], 
                UseDefaults = false,
                ContourLineColor = Color.fromKeyword White,
                ShowContourLabels = true
            )
        ]
        |> Chart.combine