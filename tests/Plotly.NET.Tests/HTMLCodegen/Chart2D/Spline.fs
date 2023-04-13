namespace Plotly.NET.Tests.HTMLCodegen.Chart2D

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.Tests

open TestUtils.HtmlCodegen
module Spline =
    [<Tests>]
    let ``Spline tests`` =
        testList "Spline" [
            testCase "Spline chart data" ( fun () ->
                """var data = [{"type":"scatter","name":"spline","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{"shape":"spline"}}];"""
                |> chartGeneratedContains TestCharts.Chart2D.Spline.``Simple spline chart``
            )
            testCase "Spline chart layout" ( fun () ->
                emptyLayout TestCharts.Chart2D.Spline.``Simple spline chart``
            )
        ]
