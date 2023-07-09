module CoreTests.UpstreamFeatures.PlotlyJS_2_19

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart

open TestUtils.HtmlCodegen
open PlotlyJS_2_19_TestCharts

module ShapeLabel = 
    [<Tests>]
    let ``ShapeLabel chart HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_19" [
            testList "ShapeLabel" [
                testCase "Rectangular shape label data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ShapeLabel.``Rectangular shape with label``
                )
                testCase "Rectangular shape label layout" ( fun () ->
                    """var layout = {"shapes":[{"fillcolor":"rgba(211, 211, 211, 1.0)","label":{"text":"Rectangle"},"opacity":0.3,"type":"rect","x0":2.0,"x1":4.0,"y0":3.0,"y1":4.0}]};"""
                    |> chartGeneratedContains ShapeLabel.``Rectangular shape with label``
                )
                testCase "Circular shape label with padding data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ShapeLabel.``Circular shape with label and padding``
                )
                testCase "Circular shape label with padding layout" ( fun () ->
                    """var layout = {"shapes":[{"fillcolor":"rgba(211, 211, 211, 1.0)","label":{"padding":20,"text":"Circle"},"opacity":0.3,"type":"circle","x0":5.0,"x1":7.0,"y0":3.0,"y1":4.0}]};"""
                    |> chartGeneratedContains ShapeLabel.``Circular shape with label and padding``
                )                
                testCase "Line shape label data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ShapeLabel.``Line shape with label``
                )
                testCase "Line shape label layout" ( fun () ->
                    """var layout = {"shapes":[{"fillcolor":"rgba(211, 211, 211, 1.0)","label":{"text":"Line"},"opacity":0.3,"type":"line","x0":1.0,"x1":2.0,"y0":1.0,"y1":2.0}]};"""
                    |> chartGeneratedContains ShapeLabel.``Line shape with label``
                )                
                testCase "SVGPath angled shape label data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ShapeLabel.``SVGPath shape with angled label``
                )
                testCase "SVGPath angled shape label layout" ( fun () ->
                    """var layout = {"shapes":[{"label":{"text":"SVGPath","textangle":33.0},"path":" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z","type":"path"}]};"""
                    |> chartGeneratedContains ShapeLabel.``SVGPath shape with angled label``
                )
            ]
        ]