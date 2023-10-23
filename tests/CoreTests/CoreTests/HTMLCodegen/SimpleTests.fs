module Tests.SimpleTests

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open Chart2DTestCharts

[<Tests>]
let ``Html layout tests`` =
    testList "SimpleTests.Simple tests" [
        testCase "Expecting plotly js script reference in generated html document" ( fun () ->
            $"""https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"""
            |> substringIsInChart Chart2DTestCharts.Point.``Point chart with axis labels and title`` GenericChart.toEmbeddedHTML 
        );
        testCase "Expecting data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains Chart2DTestCharts.Point.``Point chart with axis labels and title``
        );
        testCase "Expecting layout info" (fun () ->
            """var layout = {"title":{"text":"Hello world!"},"xaxis":{"title":{"text":"xAxis"},"showgrid":false},"yaxis":{"title":{"text":"yAxis"},"showgrid":false}};"""
            |> chartGeneratedContains Chart2DTestCharts.Point.``Point chart with axis labels and title``
        );
        testCase "Expecting html tags in embedded page only" (fun () ->
            ["<html>"; "</html>"; "<head>"; "</head>"; "<body>"; "</body>"; "<script type=\"text/javascript\">"; "</script>"]
            |> substringListIsInChart Chart2DTestCharts.Point.``Point chart with axis labels and title`` GenericChart.toEmbeddedHTML
        );
        testCase "Expecting some html tags in both embedded and not embedded" (fun () ->
            ["<script type=\"text/javascript\">"; "</script>"]
            |> chartGeneratedContainsList Chart2DTestCharts.Point.``Point chart with axis labels and title``
        );
        testCase "Passing args to the function" ( fun () ->
            "data, layout, config);"
            |> chartGeneratedContains Chart2DTestCharts.Point.``Point chart with axis labels and title``
        )
    ]


[<Tests>]
let ``plotlyjs reference tests`` =
    testList "SimpleTests.plotlyjs reference" [
        testCase "full reference" (fun _ ->
            getFullPlotlyJS()
            |> substringIsInChart Chart2DTestCharts.Point.``Point chart with full plotly.js reference`` GenericChart.toEmbeddedHTML
        )
        testCase "cdn reference" (fun _ ->
            $"""https://cdn.plot.ly/plotly-2.0.0.min"""
            |> substringIsInChart Chart2DTestCharts.Point.``Point chart with plotly.js cdn reference`` GenericChart.toEmbeddedHTML 
        )
        testCase "require: Expecting cloudflare link" (fun () ->
            """https://cdnjs.cloudflare.com/ajax/libs/require.js"""
            |> chartGeneratedContains Chart2DTestCharts.Point.``Point chart referencing plotly.js using require.js``
        );
        testCase "require: Expecting require config" (fun () ->
            (sprintf """var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-%s.min'}}) || require;""" Globals.PLOTLYJS_VERSION)
            |> chartGeneratedContains Chart2DTestCharts.Point.``Point chart referencing plotly.js using require.js``
        );
    ]