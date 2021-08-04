module TestUtils

open Expecto
open Plotly.NET.GenericChart

let substringIsInChart chart htmlizer substring =
    chart
    |> htmlizer
    |> Expect.stringContains
    |> (fun expecting -> expecting substring $"Should've contained {substring}")


let substringListIsInChart chart htmlizer substringList =
    for substring in substringList do
        substringIsInChart chart htmlizer substring


let chartGeneratedContains chart substring =
    substringIsInChart chart toChartHTML substring
    substringIsInChart chart toEmbeddedHTML substring


let chartGeneratedContainsList chart substringList =
    for substring in substringList do
        chartGeneratedContains chart substring

