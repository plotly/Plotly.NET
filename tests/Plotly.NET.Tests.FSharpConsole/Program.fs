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
        Chart.Point([(1.,2.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
        Chart.Point([(2.,4.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
    ]
    |> Chart.combine
    |> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
    // include mathtex tags in <head>. pass true to append these scripts, false to ONLY include MathTeX.
    |> Chart.withMathTex(true)
    |> Chart.show
    0