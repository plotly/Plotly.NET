module ChartTernaryTestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open System

open TestUtils.DataGeneration
open Deedle

module ScatterTernary = ()

module PointTernary = 

    let ``Styled ternary point chart`` =
        Chart.PointTernary(abc = [1,2,3], UseDefaults = false)
        |> Chart.withAAxis(LinearAxis.init(Title = Title.init("A"), Color = Color.fromKeyword ColorKeyword.DarkOrchid))
        |> Chart.withBAxis(LinearAxis.init(Title = Title.init("B"), Color = Color.fromKeyword ColorKeyword.DarkRed))
        |> Chart.withCAxis(LinearAxis.init(Title = Title.init("C"), Color = Color.fromKeyword ColorKeyword.DarkCyan))

module LineTernary = 
    
    let ``Styled ternary line chart`` =
        Chart.LineTernary(
            A = [10; 20; 30; 40; 50; 60; 70; 80;],
            B = ([10; 20; 30; 40; 50; 60; 70; 80;] |> List.rev),
            Sum = 100,
            ShowMarkers = true,
            LineDash = StyleParam.DrawingStyle.DashDot, 
            UseDefaults = false
        )
        |> Chart.withTernary(
            Ternary.init(
                AAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkOrchid),
                BAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkRed),
                CAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkCyan)
            )
        )

module BubbleTernary = ()