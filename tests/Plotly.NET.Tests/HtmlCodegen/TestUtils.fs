module TestUtils

open Expecto
open Plotly.NET
open Plotly.NET.GenericChart

let chartGeneratedContains chart substring =
    let substringIsInChart htmlizer =
        chart
        |> htmlizer
        |> Expect.stringContains
        |> (fun expecting -> expecting substring $"Should've contained {substring}")

    substringIsInChart toChartHTML
    substringIsInChart toEmbeddedHTML