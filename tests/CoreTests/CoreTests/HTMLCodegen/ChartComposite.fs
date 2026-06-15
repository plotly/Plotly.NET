module CoreTests.HTMLCodegen.ChartComposite

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils
open TestUtils.HtmlCodegen
open ChartCompositeTestCharts

module Venn =
    [<Tests>]
    let ``Venn chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartComposite" [
            testList "Venn" [
                testCase "Two set data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"text","x":[1.0,2.5,1.75],"y":[1.0,1.0,1.0],"text":["A<br>2","B<br>2","2"],"textfont":{"family":"Arial","size":18.0,"color":"rgba(0, 0, 0, 1.0)"}}];"""
                    |> chartGeneratedContains Venn.``Two set venn diagram``
                );
                testCase "Two set layout" ( fun () ->
                    """var layout = {"margin":{"l":20,"r":20,"b":100},"shapes":[{"fillcolor":"rgba(0, 0, 255, 1.0)","line":{"color":"rgba(0, 0, 255, 1.0)"},"opacity":0.3,"type":"circle","x0":0.0,"x1":2.0,"xref":"x","y0":0.0,"y1":2.0,"yref":"y"},{"fillcolor":"rgba(255, 0, 0, 1.0)","line":{"color":"rgba(255, 0, 0, 1.0)"},"opacity":0.3,"type":"circle","x0":1.5,"x1":3.5,"xref":"x","y0":0.0,"y1":2.0,"yref":"y"}],"xaxis":{"showticklabels":false,"showgrid":false,"zeroline":false},"yaxis":{"scaleanchor":"x","scaleratio":1.0,"showticklabels":false,"showgrid":false,"zeroline":false}};"""
                    |> chartGeneratedContains Venn.``Two set venn diagram``
                );
                testCase "Three set data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"text","x":[1.0,2.5,1.75,1.75,1.325,2.125,1.75],"y":[1.0,1.0,2.25,1.0,1.6625,1.6625,1.45],"text":["A<br>1","B<br>2","C<br>3","2","3","4","1"],"textfont":{"family":"Arial","size":18.0,"color":"rgba(0, 0, 0, 1.0)"}}];"""
                    |> chartGeneratedContains Venn.``Three set venn diagram``
                );
                testCase "Three set layout" ( fun () ->
                    """var layout = {"margin":{"l":20,"r":20,"b":100},"shapes":[{"fillcolor":"rgba(0, 0, 255, 1.0)","line":{"color":"rgba(0, 0, 255, 1.0)"},"opacity":0.3,"type":"circle","x0":0.0,"x1":2.0,"xref":"x","y0":0.0,"y1":2.0,"yref":"y"},{"fillcolor":"rgba(255, 0, 0, 1.0)","line":{"color":"rgba(255, 0, 0, 1.0)"},"opacity":0.3,"type":"circle","x0":1.5,"x1":3.5,"xref":"x","y0":0.0,"y1":2.0,"yref":"y"},{"fillcolor":"rgba(0, 128, 0, 1.0)","line":{"color":"rgba(0, 128, 0, 1.0)"},"opacity":0.3,"type":"circle","x0":0.75,"x1":2.75,"xref":"x","y0":1.3,"y1":3.3,"yref":"y"}],"xaxis":{"showticklabels":false,"showgrid":false,"zeroline":false},"yaxis":{"scaleanchor":"x","scaleratio":1.0,"showticklabels":false,"showgrid":false,"zeroline":false}};"""
                    |> chartGeneratedContains Venn.``Three set venn diagram``
                );
                testCase "Styled two set data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"text","x":[1.0,2.5,1.75],"y":[1.0,1.0,1.0],"text":["A<br>2","B<br>2","2"],"textfont":{"family":"Courier New","size":20.0,"color":"rgba(128, 0, 128, 1.0)"}}];"""
                    |> chartGeneratedContains Venn.``Styled two set venn diagram``
                );
                testCase "Styled two set layout" ( fun () ->
                    """var layout = {"margin":{"l":20,"r":20,"b":100},"shapes":[{"fillcolor":"rgba(0, 255, 255, 1.0)","line":{"color":"rgba(0, 255, 255, 1.0)"},"opacity":0.3,"type":"circle","x0":0.0,"x1":2.0,"xref":"x","y0":0.0,"y1":2.0,"yref":"y"},{"fillcolor":"rgba(250, 128, 114, 1.0)","line":{"color":"rgba(250, 128, 114, 1.0)"},"opacity":0.3,"type":"circle","x0":1.5,"x1":3.5,"xref":"x","y0":0.0,"y1":2.0,"yref":"y"}],"xaxis":{"showticklabels":false,"showgrid":false,"zeroline":false},"yaxis":{"scaleanchor":"x","scaleratio":1.0,"showticklabels":false,"showgrid":false,"zeroline":false}};"""
                    |> chartGeneratedContains Venn.``Styled two set venn diagram``
                );
            ]
        ]
