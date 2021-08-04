module Tests.SimpleTests

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart


let simpleChart =
    let xData = [0. .. 10.]
    let yData = [0. .. 10.]
    Chart.Point(xData, yData)
    |> Chart.withTitle "Hello world!"
    |> Chart.withX_AxisStyle ("xAxis", Showgrid=false)
    |> Chart.withY_AxisStyle ("yAxis", Showgrid=false)


[<Tests>]
let ``Simple tests`` =
    testList "Simple tests" [
        testCase "Expecting plotly js" ( fun () ->
            "https://cdn.plot.ly/plotly-latest.min"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"mode\":\"markers\",\"marker\":{}}];"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting layout info" (fun () ->
            "var layout = {\"title\":\"Hello world!\",\"xaxis\":{\"title\":\"xAxis\",\"showgrid\":false},\"yaxis\":{\"title\":\"yAxis\",\"showgrid\":false}};"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting cloudflare link" (fun () ->
            "\"https://cdnjs.cloudflare.com/ajax/libs/require.js"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting config" (fun () ->
            "var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting html tags in embedded page only" (fun () ->
            ["<html>"; "</html>"; "<head>"; "</head>"; "<body>"; "</body>"; "<script type=\"text/javascript\">"; "</script>"]
            |> substringListIsInChart simpleChart toEmbeddedHTML
        );
        testCase "Expecting some html tags in both embedded and not embedded" (fun () ->
            ["<script type=\"text/javascript\">"; "</script>"]
            |> chartGeneratedContainsList simpleChart
        );
    ]
