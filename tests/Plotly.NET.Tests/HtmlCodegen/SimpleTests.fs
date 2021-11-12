module Tests.SimpleTests

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart

open TestUtils.HtmlCodegen

let simpleChart =
    let xData = [0. .. 10.]
    let yData = [0. .. 10.]
    Chart.Point(xData, yData, UseDefaults = false)
    |> Chart.withTitle "Hello world!"
    |> Chart.withXAxisStyle ("xAxis", ShowGrid=false)
    |> Chart.withYAxisStyle ("yAxis", ShowGrid=false)

[<Tests>]
let ``Html layout tests`` =
    testList "SimpleTests.Simple tests" [
        testCase "Expecting plotly js" ( fun () ->
            "https://cdn.plot.ly/plotly-2.4.2.min"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"marker":{}}];"""
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting layout info" (fun () ->
            """var layout = {"title":{"text":"Hello world!"},"xaxis":{"title":{"text":"xAxis"},"showgrid":false},"yaxis":{"title":{"text":"yAxis"},"showgrid":false}};"""
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting cloudflare link" (fun () ->
            "\"https://cdnjs.cloudflare.com/ajax/libs/require.js"
            |> chartGeneratedContains simpleChart
        );
        testCase "Expecting require config" (fun () ->
            "var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;"
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
        testCase "Passing args to the function" ( fun () ->
            "data, layout, config);"
            |> chartGeneratedContains simpleChart
        )
    ]
