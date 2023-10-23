module CoreTests.UpstreamFeatures.PlotlyJS_2_21

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open PlotlyJS_2_21_TestCharts

module ShapeLabelTextTemplate = 

    [<Tests>]
    let ``ShapeLabel TextTemplate chart HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_21" [
            testList "ShapeLabelTextTemplate" [
                testCase "Line shape with all template item variables accessed data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"markers","x":[0,10],"y":[10,10],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ShapeLabelTextTemplate.``Line shape with all template item variables accessed``
                )
                testCase "Line shape with all template item variables accessed layout" ( fun () ->
                    """var layout = {"shapes":[{"label":{"texttemplate":"Here are the values i can access:<br><b>Raw variables (from shape definition):</b><br><br>x0: %{x0}<br>x1: %{x1}<br>y0: %{y0}<br>y1: %{y1}<br><br><b>Calculated variables:</b><br><br>xcenter (calculated as (x0+x1)/2): %{xcenter}<br>ycenter (calculated as (y0+y1)/2): %{ycenter}<br>dx (calculated as x1-x0): %{dx}<br>dy (calculated as y1-y0): %{dy}<br>width (calculated as abs(x1-x0)): %{width}<br>height (calculated as abs(y1-y0)): %{height}<br>length (calculated as sqrt(dx^2+dy^2)) -- for lines only: %{length}<br>slope (calculated as (y1-y0)/(x1-x0)): %{slope}<br>"},"type":"line","x0":0,"x1":10,"y0":10,"y1":10}],"width":1000,"height":1000};"""
                    |> chartGeneratedContains ShapeLabelTextTemplate.``Line shape with all template item variables accessed``
                )
            ]
        ]