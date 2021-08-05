module Tests.DistributionCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let histoChart =
    let rnd = System.Random(5)
    let x = [for i=0 to 500 do yield rnd.NextDouble() ]
    x
    |> Chart.Histogram
    |> Chart.withSize(500., 500.)

[<Tests>]
let ``Histogram charts`` =
    testList "DistributionCharts.Histogram charts" [
        testCase "Histo data" ( fun () ->
            // the string is too big to be here fully.
            [
                "var data = [{\"type\":\"histogram\",\"x\":[0.33836984091362443,0.2844184475412678,0.2629626417825756,0.6253758443637638,0.46346185284827923,0.9283738280312968,0.1463105539541275,0.9505998873853124,0.5961332552116985"
                "0.7608672612164483,0.8280196519699039,0.040246858280267035,0.0017312127173557937],\"marker\":{}}];"
            ]
            |> chartGeneratedContainsList histoChart
        );
        testCase "Histo layout" ( fun () ->
            "var layout = {\"width\":500.0,\"height\":500.0};"
            |> chartGeneratedContains histoChart
        );
    ]