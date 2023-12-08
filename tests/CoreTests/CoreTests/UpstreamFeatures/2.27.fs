module CoreTests.UpstreamFeatures.PlotlyJS_2_27

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open TestUtils.HtmlCodegen
open PlotlyJS_2_27_TestCharts
    
module ``InsideRange for linear axes`` = 
    [<Tests>]
    let ``InsideRange for linear axes tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_27" [
            testList "InsideRange for linear axes" [
                testCase "Inside range for x axis data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"lines","x":[1,2,3,4],"y":[1,1,2,3],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``InsideRange for linear axes``.``Inside range for x axis``
                )
                testCase "Inside range for x axis layout" ( fun () ->
                    """var layout = {"xaxis":{"insiderange":[1,3],"anchor":"y"},"yaxis":{"ticks":"inside","ticklabelposition":"inside","anchor":"x"}};"""
                    |> chartGeneratedContains ``InsideRange for linear axes``.``Inside range for x axis``
                )
                testCase "Inside range for y axis data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"lines","x":[1,2,3,4],"y":[1,1,2,3],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``InsideRange for linear axes``.``Inside range for y axis``
                )
                testCase "Inside range for y axis layout" ( fun () ->
                    """var layout = {"xaxis":{"ticks":"inside","ticklabelposition":"inside","anchor":"y"},"yaxis":{"insiderange":[1,3],"anchor":"x"}};"""
                    |> chartGeneratedContains ``InsideRange for linear axes``.``Inside range for y axis``
                )
            ]
        ]