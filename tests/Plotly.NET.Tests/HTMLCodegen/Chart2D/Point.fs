namespace Plotly.NET.Tests.HTMLCodegen.Chart2D

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.Tests

open TestUtils.HtmlCodegen

module Point =
    [<Tests>]
    let ``Point tests`` =
        testList "HTMLCodegen.Chart2D" [
            testList "Point" [
                testCase "Text label data" ( fun () ->
                    """var data = [{"type":"scatter","name":"points","mode":"markers+text","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"text":["a","b","c","d","e","f","g","h","i","j"],"textposition":"top right","marker":{},"line":{}}];"""
                    |> chartGeneratedContains TestCharts.Chart2D.Point.``Point chart with text labels``
                )
                testCase "Text label layout" ( fun () ->
                    emptyLayout TestCharts.Chart2D.Point.``Point chart with text labels``
                )
            ]
        ]
