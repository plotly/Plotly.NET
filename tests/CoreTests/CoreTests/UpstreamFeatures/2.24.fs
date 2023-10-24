module CoreTests.UpstreamFeatures.PlotlyJS_2_24

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open PlotlyJS_2_24_TestCharts

module ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces`` =

    [<Tests>]
    let ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_24" [
            testList "pie marker pattern" [
                testCase "pie marker pattern data" ( fun () ->
                    """var data = [{"type":"pie","values":[20,30],"labels":["yes","nope"],"marker":{"line":{},"pattern":{"shape":["+","."]}}}];"""
                    |> chartGeneratedContains ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Pie chart with section patterns``
                )
                testCase "pie marker pattern layout" ( fun () ->
                    emptyLayout ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Pie chart with section patterns``
                )
            ]
            testList "donut marker pattern" [
                testCase "donut marker pattern data" ( fun () ->
                    """var data = [{"type":"pie","values":[20,30],"labels":["yes","nope"],"marker":{"line":{},"pattern":{"shape":["+","."]}},"hole":0.4}];"""
                    |> chartGeneratedContains ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Donut chart with section patterns``
                )
                testCase "donut marker pattern layout" ( fun () ->
                    emptyLayout ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Donut chart with section patterns``
                )
            ]
            testList "funnelarea marker pattern" [
                testCase "funnelarea marker pattern data" ( fun () ->
                    """var data = [{"type":"funnelarea","values":[20,30],"labels":["yes","nope"],"marker":{"line":{},"pattern":{"shape":["+","."]}}}];"""
                    |> chartGeneratedContains ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``FunnelArea chart with section patterns``
                )
                testCase "funnelarea marker pattern layout" ( fun () ->
                    emptyLayout ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``FunnelArea chart with section patterns``
                )
            ]
            testList "sunburst marker pattern" [
                testCase "sunburst marker pattern data" ( fun () ->
                    """var data = [{"type":"sunburst","parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"labels":["A","B","C","D","E"],"text":["At","Bt","Ct","Dt","Et"],"marker":{"line":{},"pattern":{"shape":["+",".","x","-",""]}}}];"""
                    |> chartGeneratedContains ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Sunburst chart with section patterns``
                )
                testCase "sunburst marker pattern layout" ( fun () ->
                    emptyLayout ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Sunburst chart with section patterns``
                )
            ]
            testList "treemap marker pattern" [
                testCase "treemap marker pattern data" ( fun () ->
                    """var data = [{"type":"treemap","parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"labels":["A","B","C","D","E"],"text":["At","Bt","Ct","Dt","Et"],"marker":{"line":{},"pattern":{"shape":["+",".","x","-",""]}}}];"""
                    |> chartGeneratedContains ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Treemap chart with section patterns``
                )
                testCase "treemap marker pattern layout" ( fun () ->
                    emptyLayout ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Treemap chart with section patterns``
                )
            ]
            testList "icicle marker pattern" [
                testCase "icicle marker pattern data" ( fun () ->
                    """var data = [{"type":"icicle","parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"labels":["A","B","C","D","E"],"text":["At","Bt","Ct","Dt","Et"],"marker":{"line":{},"pattern":{"shape":["+",".","x","-",""]}},"tiling":{},"pathbar":{}}];"""
                    |> chartGeneratedContains ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Icicle chart with section patterns``
                )
                testCase "icicle marker pattern layout" ( fun () ->
                    emptyLayout ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces``.``Icicle chart with section patterns``
                )
            ]
        ]