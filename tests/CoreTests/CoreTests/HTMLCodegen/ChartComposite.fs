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

module UpSet =
    [<Tests>]
    let ``UpSet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartComposite" [
            testList "UpSet" [
                testCase "Three set intersection size bars" ( fun () ->
                    // intersection sizes, sorted descending, drawn as vertical bars in the top right cell
                    """{"type":"bar","y":[4,3,3,2,2,1,1],"orientation":"v","marker":{"color":"rgba(0, 0, 139, 1.0)","pattern":{}},"showlegend":false,"xaxis":"x2","yaxis":"y2"}"""
                    |> chartGeneratedContains UpSet.``Three set upset plot``
                );
                testCase "Three set size bars" ( fun () ->
                    // per-set sizes drawn as horizontal bars in the bottom left cell
                    """{"type":"bar","x":[7,9,11],"y":["A","B","C"],"orientation":"h","marker":{"color":"rgba(0, 0, 139, 1.0)","pattern":{}},"showlegend":false,"xaxis":"x3","yaxis":"y3"}"""
                    |> chartGeneratedContains UpSet.``Three set upset plot``
                );
                testCase "Three set triple intersection matrix line" ( fun () ->
                    // the final intersection (A∩B∩C) connects all three set rows in the matrix
                    """{"type":"scatter","mode":"lines+markers","x":[6,6,6],"y":[0,1,2],"marker":{"size":25,"symbol":"0"},"line":{"color":"rgba(0, 0, 139, 1.0)","width":5.0,"dash":"solid"},"showlegend":false,"xaxis":"x4","yaxis":"y4"}"""
                    |> chartGeneratedContains UpSet.``Three set upset plot``
                );
                testCase "Three set grid layout" ( fun () ->
                    """"grid":{"rows":2,"columns":2,"roworder":"top to bottom","pattern":"independent"}"""
                    |> chartGeneratedContains UpSet.``Three set upset plot``
                );
                testCase "Three set set-size axis" ( fun () ->
                    // set size bars use a reversed x-range so they grow towards the matrix
                    """"xaxis3":{"title":{"text":"Set Size","font":{"family":"Arial","size":20.0}},"range":[11.0,0.0],"domain":[0.0,0.2]}"""
                    |> chartGeneratedContains UpSet.``Three set upset plot``
                );
                testCase "Three set matrix label axis" ( fun () ->
                    """"yaxis4":{"range":[-0.5,2.5],"tickmode":"array","tickvals":[0,1,2],"ticktext":["A","B","C"],"showticklabels":true,"tickfont":{"family":"Arial","size":20.0},"showline":false,"showgrid":false,"zeroline":false}"""
                    |> chartGeneratedContains UpSet.``Three set upset plot``
                );
            ]
        ]
