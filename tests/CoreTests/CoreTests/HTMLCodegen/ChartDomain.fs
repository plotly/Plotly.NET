module CoreTests.HTMLCodegen.ChartDomain

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open ChartDomainTestCharts

module Pie =
    [<Tests>]
    let ``Pie chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Pie" [
                testCase "Pie data" ( fun () ->
                """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{"line":{},"pattern":{}}}];"""
                |> chartGeneratedContains Pie.``Simple pie chart``
                );
                testCase "Pie layout" ( fun () ->
                    emptyLayout Pie.``Simple pie chart``
                );        
                testCase "Pie styled data" ( fun () ->
                    """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"pull":[0.0,0.3,0.0],"text":["Some","More","Stuff"],"textposition":["inside","outside","inside"],"marker":{"colors":["rgba(0, 255, 255, 1.0)","rgba(250, 128, 114, 1.0)","rgba(210, 180, 140, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":2.0},"pattern":{}},"rotation":45.0}];"""
                    |> chartGeneratedContains Pie.``Styled pie chart``
                );
                testCase "Pie styled layout" ( fun () ->
                    emptyLayout Pie.``Styled pie chart``
                );
            ]
        ]

module Doughnut =
    [<Tests>]
    let ``Doughnut chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Doughnut" [
                testCase "Doughnut data" ( fun () ->
                    """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"text":["Residential","Non-Residential","Utility"],"marker":{"line":{},"pattern":{}},"hole":0.3}];"""
                    |> chartGeneratedContains Doughnut.``Simple doughnut chart``
                );
                testCase "Doughnut layout" ( fun () ->
                    emptyLayout Doughnut.``Simple doughnut chart``
                );
            ]
        ]

module FunnelArea =
    [<Tests>]
    let ``FunnelArea chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "FunnelArea" [
                testCase "Funnel area data" ( fun () ->
                """var data = [{"type":"funnelarea","values":[5,4,3,2,1],"text":["The 1st","The 2nd","The 3rd","The 4th","The 5th"],"marker":{"line":{"color":"purple","width":3.0},"pattern":{}}}];"""
                |> chartGeneratedContains FunnelArea.``Simple funnelarea chart``
                );
                testCase "Funnel area layout" ( fun () ->
                    emptyLayout FunnelArea.``Simple funnelarea chart``
                );        
                testCase "Funnel area styled data" ( fun () ->
                    """var data = [{"type":"funnelarea","values":[5,4,3],"labels":["The 1st","The 2nd","The 3rd"],"text":["The 1st","The 2nd","The 3rd"],"marker":{"colors":["rgba(0, 255, 255, 1.0)","rgba(250, 128, 114, 1.0)","rgba(210, 180, 140, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":2.0},"pattern":{}},"aspectratio":0.75,"baseratio":0.1}];"""
                    |> chartGeneratedContains FunnelArea.``Styled funnelarea chart``
                );
                testCase "Funnel area styled layout" ( fun () ->
                    emptyLayout FunnelArea.``Styled funnelarea chart``
                );
            ]
        ]

module Sunburst =
    [<Tests>]
    let ``Sunburst chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Sunburst" [
                testCase "Sunburst data" ( fun () ->
                    """var data = [{"type":"sunburst","parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"labels":["A","B","C","D","E"],"text":["At","Bt","Ct","Dt","Et"],"marker":{"line":{},"pattern":{}}}];"""
                    |> chartGeneratedContains Sunburst.``Simple sunburst chart``
                );
                testCase "Sunburst layout" ( fun () ->
                    emptyLayout Sunburst.``Simple sunburst chart``
                );       
                testCase "Sunburst styled data" ( fun () ->
                    """var data = [{"type":"sunburst","parents":["","","","","","A","A","B","AA","AA"],"values":[20,1,2,3,4,15,5,1,10,5],"labels":["A","B","C","D","E","AA","AB","BA","AAA","AAB"],"marker":{"colorscale":"Viridis","line":{"color":"rgba(0, 0, 0, 1.0)"},"pattern":{},"showscale":true},"branchvalues":"total","rotation":45}];"""
                    |> chartGeneratedContains Sunburst.``Styled sunburst chart``
                );
                testCase "Sunburst styled layout" ( fun () ->
                    emptyLayout Sunburst.``Styled sunburst chart``
                );
            ]
        ]

module Treemap =
    [<Tests>]
    let ``Treemap chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Treemap" [
                testCase "Treemap styled data" ( fun () ->
                    """var data = [{"type":"treemap","parents":["","","","","","A","A","B","AA","AA"],"values":[20,1,2,3,4,15,5,1,10,5],"labels":["A","B","C","D","E","AA","AB","BA","AAA","AAB"],"marker":{"colorscale":"Viridis","line":{"color":"rgba(0, 0, 0, 1.0)"},"pattern":{},"showscale":true},"branchvalues":"total","tiling":{"packing":"slice-dice"}}];"""
                    |> chartGeneratedContains Treemap.``Styled treemap chart``
                );
                testCase "Treemap styled layout" ( fun () ->
                    emptyLayout Treemap.``Styled treemap chart``
                );
            ]
        ]

module ParallelCoord =
    [<Tests>]
    let ``ParallelCoord chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "ParallelCoord" [
                 testCase "Parallel coordinates data" ( fun () ->
                    """var data = [{"type":"parcoords","dimensions":[{"label":"A","values":[1.0,4.0,3.4,0.7],"axis":{}},{"label":"B","values":[3.0,1.5,1.7,2.3],"axis":{}},{"label":"C","values":[2.0,4.0,3.1,5.0],"axis":{}},{"label":"D","values":[4.0,2.0,2.0,4.0],"axis":{}}],"line":{"color":"blue"}}];"""
                    |> chartGeneratedContains ParallelCoord.``Simple parallel coordinates chart``
                );
                testCase "Parallel coordinates layout" ( fun () ->
                    emptyLayout ParallelCoord.``Simple parallel coordinates chart``
                );
                testCase "Parallel coordinates styled data" ( fun () ->
                    """var data = [{"type":"parcoords","dimensions":[{"label":"1","values":[1,2,3,4],"range":[0.0,8.0],"axis":{}},{"label":"2","values":[4,3,2,1],"range":[0.0,8.0],"axis":{}},{"label":"3","values":[1,2,3,4],"range":[0.0,8.0],"axis":{}},{"label":"4","values":[4,3,2,1],"range":[0.0,8.0],"axis":{}}],"line":{"color":[1,2,3,4],"colorscale":"Viridis"}}];"""
                    |> chartGeneratedContains ParallelCoord.``Styled parallel coordinates chart``
                );
                testCase "Parallel coordinates styled layout" ( fun () ->
                    emptyLayout ParallelCoord.``Styled parallel coordinates chart``
                );
            ]
        ]

module ParallelCategories =
    [<Tests>]
    let ``ParallelCategories chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "ParallelCategories" [
                testCase "Parallel categories data" ( fun () ->
                    """var data = [{"type":"parcats","dimensions":[{"label":"A","values":["Cat1","Cat1","Cat1","Cat1","Cat2","Cat2","Cat3"],"axis":{}},{"label":"B","values":[0,1,0,1,0,0,0],"ticktext":["YES","NO"],"axis":{}}],"line":{"color":[0.0,1.0,0.0,1.0,0.0,0.0,0.0],"colorscale":"Blackbody"}}];"""
                    |> chartGeneratedContains ParallelCategories.``Simple parallel categories chart``
                );
                testCase "Parallel categories layout" ( fun () ->
                    emptyLayout ParallelCategories.``Simple parallel categories chart``
                );        
                testCase "Parallel categories styled data" ( fun () ->
                    """var data = [{"type":"parcats","dimensions":[{"label":"Lvl1","values":["A","A","A","B","B","B","C","D"],"axis":{}},{"label":"Lvl2","values":["AA","AA","AB","AB","AB","AB","AB","AB"],"axis":{}},{"label":"Lvl3","values":["AAA","AAB","AAC","AAC","AAB","AAB","AAA","AAA"],"axis":{}}],"line":{"color":[0,1,2,2,1,1,0,0],"colorscale":"Viridis"},"bundlecolors":false}];"""
                    |> chartGeneratedContains ParallelCategories.``Styled parallel categories chart``
                );
                testCase "Parallel categories styled layout" ( fun () ->
                    emptyLayout ParallelCategories.``Styled parallel categories chart``
                );
            ]
        ]

module Sankey =
    [<Tests>]
    let ``Sankey chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Sankey" [
                testCase "Sankey data" ( fun () ->
                    """var data = [{"type":"sankey","node":{"label":["A1","A2","B1","B2","C1","C2","D1"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0}},"link":{"color":["rgba(130, 139, 251, 1.0)","rgba(130, 139, 251, 1.0)","rgba(242, 119, 98, 1.0)","rgba(51, 214, 171, 1.0)","rgba(188, 130, 251, 1.0)","rgba(188, 130, 251, 1.0)","rgba(255, 180, 123, 1.0)","rgba(71, 220, 245, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0},"source":[0,0,1,2,3,3,4,5],"target":[2,3,3,4,4,5,6,6],"value":[8,4,2,7,3,2,5,2]}}];"""
                    |> chartGeneratedContains Sankey.``Styled sankey chart``
                )
                testCase "Sankey layout" ( fun () ->
                    emptyLayout Sankey.``Styled sankey chart``
                )
            ]
        ]

module Table =
    [<Tests>]
    let ``Table chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Table" [
                testCase "First table data" ( fun () ->
                    """var data = [{"type":"table","cells":{"fill":{},"line":{},"values":[["0","1"],["I","little"],["am","example"],["a","!"]]},"header":{"fill":{},"line":{},"values":["<b>RowIndex</b>","A","simple","table"]}}];"""
                    |> chartGeneratedContains Table.``Simple table chart``
                );
                testCase "First table layout" ( fun () ->
                    emptyLayout Table.``Simple table chart``
                );
                testCase "Styled table data" ( fun () ->
                    """var data = [{"type":"table","columnorder":[1,2,3,4],"columnwidth":[70.0,50.0,100.0,70.0],"cells":{"align":["left","center","right"],"fill":{"color":["#deebf7","lightgrey","#deebf7","lightgrey"]},"line":{},"values":[["0","1"],["I","little"],["am","example"],["a","!"]]},"header":{"align":"center","fill":{"color":"#45546a"},"height":30,"line":{"color":"black","width":2.0},"values":["<b>RowIndex</b>","A","simple","table"]}}];"""
                    |> chartGeneratedContains Table.``Styled table chart``
                );
                testCase "Styled table layout" ( fun () ->
                    emptyLayout Table.``Styled table chart``
                );
                testCase "Color dependent chart data" ( fun () ->
                    """var data = [{"type":"table","cells":{"fill":{"color":[["white","white","white","white","white","white","white"],["rgba(255, 255, 0, 1.0)","rgba(255, 245, 10, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 26, 229, 1.0)"],["rgba(255, 250, 5, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 174, 81, 1.0)","rgba(255, 215, 40, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 102, 153, 1.0)"],["rgba(255, 240, 15, 1.0)","rgba(255, 51, 204, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 179, 76, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 153, 102, 1.0)"],["rgba(255, 245, 10, 1.0)","rgba(255, 0, 255, 1.0)","rgba(255, 143, 112, 1.0)","rgba(255, 220, 35, 1.0)","rgba(255, 159, 96, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 128, 127, 1.0)"]]},"line":{},"values":[[10004.0,10001.0,10005.0,10006.0,10007.0,10002.0,10003.0],[0.0,0.2,1.0,1.0,2.0,2.1,4.5],[0.1,2.0,1.6,0.8,2.0,2.0,3.0],[0.3,4.0,1.8,1.5,2.1,1.8,2.0],[0.2,5.0,2.2,0.7,1.9,2.1,2.5]]},"header":{"fill":{},"line":{},"values":["Identifier","T0","T1","T2","T3"]}}];"""
                    |> chartGeneratedContains Table.``Cell color dependent table chart``
                );
                testCase "Color dependent chart layout" ( fun () ->
                    emptyLayout Table.``Cell color dependent table chart``
                );
                testCase "Sequence presentation table data" ( fun () ->
                    """var data = [{"type":"table","columnwidth":[50.0,10.0],"cells":{"align":["right","center"],"fill":{"color":[["white","white","white","white","white"],["#5050FF","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E00000","#E6E600","#E00000","white"],["#00C000","#00C000","#E00000","#00C000","white"],["#5050FF","#E6E600","#00C000","#E6E600","white"],["#00C000","#E00000","#5050FF","#E00000","white"],["#5050FF","#00C000","#E6E600","#00C000","white"],["#E00000","#5050FF","#5050FF","#5050FF","white"],["#00C000","#E6E600","#00C000","#E6E600","white"],["#E6E600","#5050FF","#5050FF","#5050FF","white"],["#E00000","#00C000","#E00000","#00C000","white"],["#00C000","#5050FF","#00C000","#5050FF","white"],["#5050FF","#E00000","#E6E600","#E00000","white"],["#00C000","#00C000","#E00000","#E00000","white"],["#5050FF","#E6E600","#00C000","#00C000","white"],["#E00000","#E00000","#5050FF","#E6E600","white"],["#E6E600","#00C000","#E6E600","#5050FF","white"],["#00C000","#5050FF","#5050FF","#00C000","white"],["#5050FF","#E6E600","#00C000","#5050FF","white"],["#E6E600","#5050FF","#5050FF","#E00000","white"],["#5050FF","#00C000","#00C000","#00C000","white"],["#00C000","#5050FF","#5050FF","#E6E600","white"],["#5050FF","#00C000","#E6E600","#E00000","white"],["#E00000","#E6E600","#5050FF","#00C000","white"],["#00C000","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E6E600","#5050FF","#E6E600","white"],["#E00000","#5050FF","#E00000","#5050FF","white"],["#00C000","#00C000","#00C000","#00C000","white"],["#5050FF","#5050FF","#E6E600","#5050FF","white"],["#E6E600","#E00000","#E00000","#E00000","white"],["#5050FF","#E00000","#00C000","#00C000","white"],["#00C000","#00C000","#5050FF","#E6E600","white"],["#5050FF","#E6E600","#E6E600","#E00000","white"],["#E00000","#00C000","#5050FF","#00C000","white"],["#00C000","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E6E600","#5050FF","#E6E600","white"],["#E00000","#5050FF","#E00000","#5050FF","white"],["#00C000","#00C000","#E00000","#00C000","white"],["#5050FF","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E00000","#E6E600","#E00000","white"],["#5050FF","#00C000","#5050FF","#E00000","white"],["#00C000","#E6E600","#E6E600","#00C000","white"],["#5050FF","#E00000","#5050FF","#E6E600","white"],["#E00000","#00C000","#00C000","white"],["#E00000","#5050FF","#5050FF","white"],["#00C000","#00C000","#5050FF","white"],["#5050FF","#5050FF","#00C000","white"],["#E6E600","#5050FF","#5050FF","white"],["#5050FF","#00C000","#E00000","white"],["#00C000","#5050FF","#00C000","white"],["#5050FF","#E00000","#E6E600","white"],["#E00000","#00C000","#E00000","white"],["#E6E600","#E6E600","#00C000","white"],["#E00000","#E00000","#5050FF","white"],["#00C000","#00C000","#E6E600","white"],["#E6E600","#5050FF","#5050FF","white"],["#00C000","#E6E600","#00C000","white"],["#5050FF","#5050FF","#5050FF","white"],["#E6E600","#00C000","#E6E600","white"],["#5050FF","#5050FF","#5050FF","white"],["#00C000","#E00000","#00C000","white"]]},"height":20,"line":{"color":"white","width":0.0},"values":[["0","60","120","180"],["A","A","G","A"],["T","C","T","C"],["G","G","C","G"],["A","T","G","T"],["G","C","A","C"],["A","G","T","G"],["C","A","A","A"],["G","T","G","T"],["T","A","A","A"],["C","G","C","G"],["G","A","G","A"],["A","C","T","C"],["G","G","C","C"],["A","T","G","G"],["C","C","A","T"],["T","G","T","A"],["G","A","A","G"],["A","T","G","A"],["T","A","A","C"],["A","G","G","G"],["G","A","A","T"],["A","G","T","C"],["C","T","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","G","G"],["A","A","T","A"],["T","C","C","C"],["A","C","G","G"],["G","G","A","T"],["A","T","T","C"],["C","G","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","C","G"],["A","A","G","A"],["T","C","T","C"],["A","G","A","C"],["G","T","T","G"],["A","C","A","T"],["C","G","G"],["C","A","A"],["G","G","A"],["A","A","G"],["T","A","A"],["A","G","C"],["G","A","G"],["A","C","T"],["C","G","C"],["T","T","G"],["C","C","A"],["G","G","T"],["T","A","A"],["G","T","G"],["A","A","A"],["T","G","T"],["A","A","A"],["G","C","G"]]},"header":{"fill":{},"line":{"color":"white","width":0.0},"values":["","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|"]}}];"""
                    |> chartGeneratedContains Table.``Sequence representation table chart``
                );
                testCase "Sequence presentation table  layout" ( fun () ->
                    "var layout = {\"width\":650,\"title\":{\"text\":\"Sequence A\"}};"
                    |> chartGeneratedContains Table.``Sequence representation table chart``
                );
            ]
        ]

module Indicator =
    [<Tests>]
    let ``Indicator chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Indicator" [
                testCase "Angular gauge indicator data" ( fun () ->
                    """var data = [{"type":"indicator","mode":"number+delta+gauge","value":200.0,"domain":{"row":0,"column":0},"delta":{"reference":160},"gauge":{"axis":{"range":[0.0,250.0]}}}];"""
                    |> chartGeneratedContains Indicator.``Angular gauge indicator``
                );
                testCase "Angular gauge indicator layout" ( fun () ->
                    emptyLayout Indicator.``Angular gauge indicator``
                );
                testCase "Bullet gauge indicator data" ( fun () ->
                    """var data = [{"type":"indicator","mode":"number+delta+gauge","value":120,"domain":{"row":0,"column":1},"delta":{"reference":90},"gauge":{"axis":{"visible":false,"range":[-200.0,200.0]},"shape":"bullet"}}];"""
                    |> chartGeneratedContains Indicator.``Bullet gauge indicator``
                );
                testCase "Bullet gauge indicator layout" ( fun () ->
                    emptyLayout Indicator.``Bullet gauge indicator``
                );
                testCase "Delta indicator with reference data" ( fun () ->
                    """var data = [{"type":"indicator","mode":"number+delta","value":"300","domain":{"row":1,"column":0},"delta":{"reference":90.0},"gauge":{"axis":{}}}];"""
                    |> chartGeneratedContains Indicator.``Delta indicator with reference``
                );
                testCase "Delta indicator with reference layout" ( fun () ->
                    emptyLayout Indicator.``Delta indicator with reference``
                );
                testCase "Delta indicator data" ( fun () ->
                    """var data = [{"type":"indicator","mode":"delta","value":40.0,"domain":{"row":1,"column":1},"delta":{"reference":90.0},"gauge":{"axis":{}}}];"""
                    |> chartGeneratedContains Indicator.``Delta indicator``
                );
                testCase "Delta indicator layout" ( fun () ->
                    emptyLayout Indicator.``Delta indicator``
                );
            ]
        ]

module Icicle =
    [<Tests>]
    let ``Icicle chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Icicle" [
                testCase "Icicle data" ( fun () ->
                    """var data = [{"type":"icicle","parents":["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"],"labels":["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"],"marker":{"colorscale":"Viridis","line":{},"pattern":{},"showscale":true},"tiling":{"flip":"y","orientation":"v"},"pathbar":{"edgeshape":"\\"}}];"""
                    |> chartGeneratedContains Icicle.``Simple icicle chart``
                )
                testCase "Icicle layout" ( fun () ->
                    emptyLayout Icicle.``Simple icicle chart``
                )        
                testCase "Icicle styled data" ( fun () ->
                    """var data = [{"type":"icicle","parents":["","","","","","A","A","B","AA","AA"],"values":[20,1,2,3,4,15,5,1,10,5],"labels":["A","B","C","D","E","AA","AB","BA","AAA","AAB"],"marker":{"colorscale":"Viridis","line":{"color":"rgba(0, 0, 0, 1.0)"},"pattern":{},"showscale":true},"branchvalues":"total","tiling":{"flip":"x+y"},"pathbar":{}}];"""
                    |> chartGeneratedContains Icicle.``Styled icicle chart``
                )
                testCase "Icicle styled layout" ( fun () ->
                    emptyLayout Icicle.``Styled icicle chart``
                )
            ]
        ]
