module Tests.MulticategoryData

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open System

open TestUtils.HtmlCodegen

let multicategoryScatter = 
    Chart.Scatter(
        MultiX = [["A";"A";"B";"B"];["AA"; "AB"; "BA"; "BB"]],
        MultiY = [
            ["A";"A";"B";"B"] |> Seq.map (fun x -> x :> IConvertible)
            [1; 2; -1; -2] |> Seq.map (fun x -> x :> IConvertible)
        ],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory scatter tests`` =
    testList "MulticategoryData.Scatter" [
        testCase "Multicategory scatter data" ( fun () ->
            """var data = [{"type":"scatter","x":[["A","A","B","B"],["AA","AB","BA","BB"]],"y":[["A","A","B","B"],[1,2,-1,-2]],"marker":{},"line":{}}];"""
            |> chartGeneratedContains multicategoryScatter
        );
        testCase "Multicategory scatter layout" ( fun () ->
            emptyLayout multicategoryScatter
        );
    ]

let multiCategoryBar =
    Chart.Bar(
        values = [1; 2; -1; -2],
        MultiKeys = [["A";"A";"B";"B"];["AA"; "AB"; "BA"; "BB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory bar tests`` =
    testList "MulticategoryData.Bar" [
        testCase "Multicategory bar data" ( fun () ->
            """var data = [{"type":"bar","x":[1,2,-1,-2],"y":[["A","A","B","B"],["AA","AB","BA","BB"]],"orientation":"h","marker":{"pattern":{}}}];"""
            |> chartGeneratedContains multiCategoryBar
        );
        testCase "Multicategory bar layout" ( fun () ->
            emptyLayout multiCategoryBar
        );
    ]

let multiCategoryColumn =
    Chart.Column(
        values = [1; 2; -1; -2],
        MultiKeys = [["A";"A";"B";"B"];["AA"; "AB"; "BA"; "BB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory column tests`` =
    testList "MulticategoryData.Column" [
        testCase "Multicategory column data" ( fun () ->
            """var data = [{"type":"bar","x":[["A","A","B","B"],["AA","AB","BA","BB"]],"y":[1,2,-1,-2],"orientation":"v","marker":{"pattern":{}}}];"""
            |> chartGeneratedContains multiCategoryColumn
        );
        testCase "Multicategory column layout" ( fun () ->
            emptyLayout multiCategoryColumn
        );
    ]

let multicategoryHistogram =
    Chart.Histogram(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory histogram tests`` =
    testList "MulticategoryData.Histogram" [
        testCase "Multicategory histogram data" ( fun () ->
            """var data = [{"type":"histogram","x":[["A","A","A","B","B"],["AA","AA","AB","BA","BB"]],"marker":{"pattern":{}}}];"""
            |> chartGeneratedContains multicategoryHistogram
        );
        testCase "Multicategory histogram layout" ( fun () ->
            emptyLayout multicategoryHistogram
        );
    ]

let multicategoryHistogram2D =
    Chart.Histogram2D(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        MultiY = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory histogram2D tests`` =
    testList "MulticategoryData.Histogram2D" [
        testCase "Multicategory histogram2D data" ( fun () ->
            """var data = [{"type":"histogram2d","x":[["A","A","A","B","B"],["AA","AA","AB","BA","BB"]],"y":[["A","A","A","B","B"],["AA","AA","AB","BA","BB"]]}];"""
            |> chartGeneratedContains multicategoryHistogram2D
        );
        testCase "Multicategory histogram2D layout" ( fun () ->
            emptyLayout multicategoryHistogram2D
        );
    ]

let multicategoryBoxPlot =
    [
        Chart.BoxPlot(
            Y = [1;1;2;3;4;3;2],
            MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AA"; "AA"; "AA"; "AA"; "AA"; "AA"; "AA"]],
            UseDefaults = false
        )
        Chart.BoxPlot(
            Y = [1;1;2;3;4;3;2],
            MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AB"; "AB"; "AB"; "AB"; "AB"; "AB"; "AB"]],
            UseDefaults = false
        )
    ]
    |> Chart.combine

[<Tests>]
let ``Multicategory boxplot tests`` =
    testList "MulticategoryData.BoxPlot" [
        testCase "Multicategory boxplot data" ( fun () ->
            """var data = [{"type":"box","x":[["A","A","A","A","A","A","A"],["AA","AA","AA","AA","AA","AA","AA"]],"y":[1,1,2,3,4,3,2],"marker":{},"line":{}},{"type":"box","x":[["A","A","A","A","A","A","A"],["AB","AB","AB","AB","AB","AB","AB"]],"y":[1,1,2,3,4,3,2],"marker":{},"line":{}}];"""
            |> chartGeneratedContains multicategoryBoxPlot
        );
        testCase "Multicategory boxplot layout" ( fun () ->
            emptyLayout multicategoryBoxPlot
        );
    ]

let multicategoryViolin =
    [
        Chart.Violin(
            Y = [1;1;2;3;4;3;2],
            MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AA"; "AA"; "AA"; "AA"; "AA"; "AA"; "AA"]],
            UseDefaults = false
        )
        Chart.Violin(
            Y = [1;1;2;3;4;3;2],
            MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AB"; "AB"; "AB"; "AB"; "AB"; "AB"; "AB"]],
            UseDefaults = false
        )
    ]
    |> Chart.combine

[<Tests>]
let ``Multicategory violin tests`` =
    testList "MulticategoryData.Violin" [
        testCase "Multicategory violin data" ( fun () ->
            """[{"type":"violin","x":[["A","A","A","A","A","A","A"],["AA","AA","AA","AA","AA","AA","AA"]],"y":[1,1,2,3,4,3,2],"marker":{},"line":{},"box":{}},{"type":"violin","x":[["A","A","A","A","A","A","A"],["AB","AB","AB","AB","AB","AB","AB"]],"y":[1,1,2,3,4,3,2],"marker":{},"line":{},"box":{}}];"""
            |> chartGeneratedContains multicategoryViolin
        );
        testCase "Multicategory violin layout" ( fun () ->
            emptyLayout multicategoryViolin
        );
    ]

let multicategoryHistogram2DContour =
    Chart.Histogram2DContour(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        MultiY = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory histogram2Dcontour tests`` =
    testList "MulticategoryData.Histogram2DContour" [
        testCase "Multicategory histogram2Dcontour data" ( fun () ->
            """var data = [{"type":"histogram2dcontour","x":[["A","A","A","B","B"],["AA","AA","AB","BA","BB"]],"y":[["A","A","A","B","B"],["AA","AA","AB","BA","BB"]],"line":{"width":0.0},"contours":{}}];"""
            |> chartGeneratedContains multicategoryHistogram2DContour
        );
        testCase "Multicategory histogram2Dcontour layout" ( fun () ->
            emptyLayout multicategoryHistogram2DContour
        );
    ]

let multicategoryHeatmap = 
    Chart.Heatmap(
        zData = [
            [1;2;3]
            [2;3;1]
            [3;1;2]
        ],
        MultiX = [["A";"A";"B"];["AA";"AB";"BA"]],
        MultiY = [["A";"A";"B"];["AA";"AB";"BA"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory heatmap tests`` =
    testList "Multicategory.Heatmap" [
        testCase "Multicategory heatmap data" ( fun () ->
            """var data = [{"type":"heatmap","x":[["A","A","B"],["AA","AB","BA"]],"y":[["A","A","B"],["AA","AB","BA"]],"z":[[1,2,3],[2,3,1],[3,1,2]]}];"""
            |> chartGeneratedContains multicategoryHeatmap
        );
        testCase "Multicategory heatmap layout" ( fun () ->
            emptyLayout multicategoryHeatmap
        );
    ]

let multicategoryAnnotatedHeatmap = 
    Chart.AnnotatedHeatmap(
        zData = [
            [1;2;3]
            [2;3;1]
            [3;1;2]
        ],
        annotationText = [
            ["A;AA x A;AA";"A;AA x A;AB";"A;AA x B;BA"]
            ["A;AB x A;AA";"A;AB x A;AB";"A;AB x B;BA"]
            ["B;BA x A;AA";"B;BA x A;AB";"B;BA x B;BA"]
        ],
        MultiX = [["A";"A";"B"];["AA";"AB";"BA"]],
        MultiY = [["A";"A";"B"];["AA";"AB";"BA"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory annotated heatmap tests`` =
    testList "MulticategoryData.AnnotatedHeatmap" [
        testCase "Multicategory annotated heatmap data" ( fun () ->
            """var data = [{"type":"heatmap","x":[["A","A","B"],["AA","AB","BA"]],"y":[["A","A","B"],["AA","AB","BA"]],"z":[[1,2,3],[2,3,1],[3,1,2]]}];"""
            |> chartGeneratedContains multicategoryAnnotatedHeatmap
        );
        testCase "Multicategory annotated heatmap layout" ( fun () ->
            """var layout = {"annotations":[{"x":0,"y":0,"showarrow":false,"text":"A;AA x A;AA"},{"x":1,"y":0,"showarrow":false,"text":"A;AA x A;AB"},{"x":2,"y":0,"showarrow":false,"text":"A;AA x B;BA"},{"x":0,"y":1,"showarrow":false,"text":"A;AB x A;AA"},{"x":1,"y":1,"showarrow":false,"text":"A;AB x A;AB"},{"x":2,"y":1,"showarrow":false,"text":"A;AB x B;BA"},{"x":0,"y":2,"showarrow":false,"text":"B;BA x A;AA"},{"x":1,"y":2,"showarrow":false,"text":"B;BA x A;AB"},{"x":2,"y":2,"showarrow":false,"text":"B;BA x B;BA"}]};"""
            |> chartGeneratedContains multicategoryAnnotatedHeatmap
        );
    ]

let multicategoryContour =
    Chart.Contour(
        zData = [
            [1;2;3]
            [2;3;1]
            [3;1;2]
        ],
        MultiX = [["A";"A";"B"];["AA";"AB";"BA"]],
        MultiY = [["A";"A";"B"];["AA";"AB";"BA"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory contour tests`` =
    testList "MulticategoryData.Contour" [
        testCase "Multicategory contour data" ( fun () ->
            """var data = [{"type":"contour","x":[["A","A","B"],["AA","AB","BA"]],"y":[["A","A","B"],["AA","AB","BA"]],"z":[[1,2,3],[2,3,1],[3,1,2]],"line":{"width":0.0},"contours":{}}];"""
            |> chartGeneratedContains multicategoryContour
        );
        testCase "Multicategory contour layout" ( fun () ->
            emptyLayout multicategoryContour
        );
    ]

let multicategoryOHLC =
    Chart.OHLC(
        ``open`` = [1;2],
        high = [3;4],
        low = [0;1],
        close = [0.5;1.],
        MultiX = [["A";"A"];["AA";"AB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory ohlc tests`` =
    testList "MulticategoryData.OHLC" [
        testCase "Multicategory ohlc data" ( fun () ->
            """var data = [{"type":"ohlc","x":[["A","A"],["AA","AB"]],"close":[0.5,1.0],"open":[1,2],"high":[3,4],"low":[0,1],"increasing":{"line":{}},"decreasing":{"line":{}}}];"""
            |> chartGeneratedContains multicategoryOHLC
        );
        testCase "Multicategory ohlc layout" ( fun () ->
            """var layout = {"xaxis":{"rangeslider":{"yaxis":{}}}};""" 
            |> chartGeneratedContains multicategoryOHLC
        );
    ]

let multicategoryCandlestick =
    Chart.Candlestick(
        ``open`` = [1;2],
        high = [3;4],
        low = [0;1],
        close = [0.5;1.],
        MultiX = [["A";"A"];["AA";"AB"]],
        UseDefaults = false
    )

[<Tests>]
let ``Multicategory candlestick tests`` =
    testList "MulticategoryData.Candlestick" [
        testCase "Multicategory candlestick data" ( fun () ->
            """var data = [{"type":"candlestick","x":[["A","A"],["AA","AB"]],"close":[0.5,1.0],"open":[1,2],"high":[3,4],"low":[0,1],"increasing":{"line":{}},"decreasing":{"line":{}}}];"""
            |> chartGeneratedContains multicategoryCandlestick
        );
        testCase "Multicategory candlestick layout" ( fun () ->
            """var layout = {"xaxis":{"rangeslider":{"yaxis":{}}}};""" 
            |> chartGeneratedContains multicategoryCandlestick
        );
    ]
