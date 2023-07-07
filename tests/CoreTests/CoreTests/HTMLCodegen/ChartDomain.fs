module CoreTests.HTMLCodegen.ChartDomain

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart

open TestUtils.HtmlCodegen
open ChartDomainTestCharts

module Pie =
    [<Tests>]
    let ``Pie chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Pie" [
                testCase "Pie data" ( fun () ->
                """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{"line":{}}}];"""
                |> chartGeneratedContains Pie.``Simple pie chart``
                );
                testCase "Pie layout" ( fun () ->
                    emptyLayout Pie.``Simple pie chart``
                );        
                testCase "Pie styled data" ( fun () ->
                    """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"pull":[0.0,0.3,0.0],"text":["Some","More","Stuff"],"textposition":["inside","outside","inside"],"marker":{"colors":["rgba(0, 255, 255, 1.0)","rgba(250, 128, 114, 1.0)","rgba(210, 180, 140, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":2.0}},"rotation":45.0}];"""
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
                    """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"text":["Residential","Non-Residential","Utility"],"marker":{"line":{}},"hole":0.3}];"""
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
                """var data = [{"type":"funnelarea","values":[5,4,3,2,1],"text":["The 1st","The 2nd","The 3rd","The 4th","The 5th"],"marker":{"line":{"color":"purple","width":3.0}}}];"""
                |> chartGeneratedContains FunnelArea.``Simple funnelarea chart``
                );
                testCase "Funnel area layout" ( fun () ->
                    emptyLayout FunnelArea.``Simple funnelarea chart``
                );        
                testCase "Funnel area styled data" ( fun () ->
                    """var data = [{"type":"funnelarea","values":[5,4,3],"labels":["The 1st","The 2nd","The 3rd"],"text":["The 1st","The 2nd","The 3rd"],"marker":{"colors":["rgba(0, 255, 255, 1.0)","rgba(250, 128, 114, 1.0)","rgba(210, 180, 140, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":2.0}},"aspectratio":0.75,"baseratio":0.1}];"""
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
            ]
        ]

module Treemap =
    [<Tests>]
    let ``Treemap chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Treemap" [
            ]
        ]

module ParralelCoord =
    [<Tests>]
    let ``ParralelCoord chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "ParralelCoord" [
            ]
        ]

module ParralelCategories =
    [<Tests>]
    let ``ParralelCategories chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "ParralelCategories" [
            ]
        ]

module Sankey =
    [<Tests>]
    let ``Sankey chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartDomain" [
            testList "Sankey" [
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
            ]
        ]
