// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj

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
    //|> Chart.withYAxis(LinearAxis.init(),Id=StyleParam.SubPlotId.YAxis 1)
    //|> Chart.withYAxis(LinearAxis.init(Shift = 10, Anchor = StyleParam.LinearAxisId.Free),Id=StyleParam.SubPlotId.YAxis 2)
    |> Chart.show
    
    0