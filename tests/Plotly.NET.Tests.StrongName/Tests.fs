module Tests

open System
open Xunit

open Plotly.NET
open Giraffe.ViewEngine

[<Fact>]
let ``Can use with Giraffe`` () =
    Chart.Point([1,2])
    |> Chart.withDescription [
        div [] [ str "Hello World" ]
    ]
