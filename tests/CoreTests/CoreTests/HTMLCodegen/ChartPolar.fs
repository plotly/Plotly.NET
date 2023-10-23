module CoreTests.HTMLCodegen.ChartPolar

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open ChartPolarTestCharts

module ScatterPolar = 
    [<Tests>]
    let ``ScatterPolar chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartPolar" [
            testList "ScatterPolar" [
            ]
        ]

module PointPolar = 
    [<Tests>]
    let ``PointPolar chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartPolar" [
            testList "PointPolar" [
                testCase "Polar Point data" ( fun () ->
                    """var data = [{"type":"scatterpolar","mode":"markers","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"marker":{}}];"""
                    |> chartGeneratedContains PointPolar.``Simple polar point chart``
                );
                testCase "Polar Point layout" ( fun () ->
                    emptyLayout PointPolar.``Simple polar point chart``
                );        
            ]
        ]

module LinePolar = 
    [<Tests>]
    let ``LinePolar chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartPolar" [
            testList "LinePolar" [
                testCase "Polar Line data" ( fun () ->
                    """var data = [{"type":"scatterpolar","mode":"lines","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"marker":{},"line":{"color":"purple","dash":"dashdot"}}];"""
                    |> chartGeneratedContains LinePolar.``Simple polar line chart with line style``
                );
                testCase "Polar Line layout" ( fun () ->
                    emptyLayout LinePolar.``Simple polar line chart with line style``
                );        
            ]
        ]

module SplinePolar = 
    [<Tests>]
    let ``SplinePolar chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartPolar" [
            testList "SplinePolar" [
                testCase "Polar Spline data" ( fun () ->
                    """var data = [{"type":"scatterpolar","mode":"lines+markers+text","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"text":["one","two","three","four","five","six","seven"],"textposition":"top center","marker":{},"line":{"shape":"spline"}}];"""
                    |> chartGeneratedContains SplinePolar.``styled polar spline chart``
                );
                testCase "Polar Spline layout" ( fun () ->
                    emptyLayout SplinePolar.``styled polar spline chart``
                );        
            ]
        ]

module BubblePolar = 
    [<Tests>]
    let ``BubblePolar chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartPolar" [
            testList "BubblePolar" [
            ]
        ]

module BarPolar = 
    [<Tests>]
    let ``BarPolar chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartPolar" [
            testList "BarPolar" [
                testCase "Polar Bar data" ( fun () ->
                    """var data = [{"type":"barpolar","name":"11-14 m/s","r":[77.5,72.5,70.0,45.0,22.5,42.5,40.0,62.5],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"marker":{"pattern":{"shape":"+"}}},{"type":"barpolar","name":"8-11 m/s","r":[57.5,50.0,45.0,35.0,20.0,22.5,37.5,55.0],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"marker":{"pattern":{"shape":"x"}}},{"type":"barpolar","name":"5-8 m/s","r":[40.0,30.0,30.0,35.0,7.5,7.5,32.5,40.0],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"marker":{"pattern":{"shape":"|"}}},{"type":"barpolar","name":"< 5 m/s","r":[20.0,7.5,15.0,22.5,2.5,2.5,12.5,22.5],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"marker":{"pattern":{"shape":"-"}}}];"""
                    |> chartGeneratedContains BarPolar.``Styled windrose chart``
                );
                testCase "Polar Bar layout" ( fun () ->
                    """var layout = {"polar":{"angularaxis":{"categoryorder":"array","categoryarray":["East","N-E","North","N-W","West","S-W","South","S-E"]}}};"""
                    |> chartGeneratedContains BarPolar.``Styled windrose chart``
                );
            ]
        ]