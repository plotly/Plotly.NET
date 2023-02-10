// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open Giraffe.ViewEngine

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    [
        Chart.Line([1,2; 3,4]) 
        |> Chart.withAxisAnchor(Y=1)
        Chart.Spline([100,200; 300,400])
        |> Chart.withAxisAnchor(Y=2)
    ]
    |> Chart.combine
    |> Chart.withYAxis (LinearAxis.init(), Id = StyleParam.SubPlotId.YAxis 1)
    |> Chart.withYAxis (LinearAxis.init(Anchor = StyleParam.LinearAxisId.Free, Shift = -50, ShowLine = true), Id = StyleParam.SubPlotId.YAxis 2)
    |> Chart.withDescription [
        h1 [] [str "now look at this!"]
        ul [] [
            li [] [str "this"]
            li [] [str "is"]
            li [] [str "a"]
            li [] [img [_src "https://images.deepai.org/machine-learning-models/0c7ba850aa2443d7b40f9a45d9c86d3f/text2imgthumb.jpeg"]]
        ]
    ]
    |> Chart.withSize(1000,1000)
    |> Chart.show
    0