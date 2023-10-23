module CoreTests.UpstreamFeatures.PlotlyJS_2_19

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


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

module LabelAlias =
    [<Tests>]
    let ``LabelAlias chart HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_19" [
            testList "LabelAlias" [
                testCase "point chart with label alias data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[1],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains LabelAlias.``Point chart with label alias``
                )
                testCase "point chart with label alias layout" ( fun () ->
                    """var layout = {"xaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"yaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}};"""
                    |> chartGeneratedContains LabelAlias.``Point chart with label alias``
                )
                testCase "3D point chart with label alias data" ( fun () ->
                    """var data = [{"type":"scatter3d","mode":"markers","x":[1],"y":[1],"z":[1],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains LabelAlias.``3D point chart with label alias``
                )
                testCase "3D point chart with label alias layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}},"xaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"yaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"zaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}}};"""
                    |> chartGeneratedContains LabelAlias.``3D point chart with label alias``
                )
                testCase "polar point chart with label alias data" ( fun () ->
                    """var data = [{"type":"scatterpolar","mode":"markers","r":[1],"theta":[1],"marker":{}}];"""
                    |> chartGeneratedContains LabelAlias.``Polar point chart with leabel alias``
                )
                testCase "polar point chart with label alias layout" ( fun () ->
                    """var layout = {"polar":{"angularaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"radialaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}}};"""
                    |> chartGeneratedContains LabelAlias.``Polar point chart with leabel alias``
                )
                testCase "ternary point chart with label alias data" ( fun () ->
                    """var data = [{"type":"scatterternary","mode":"markers","a":[1],"b":[1],"c":[1],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains LabelAlias.``Ternary point chart with label alias``
                )
                testCase "ternary point chart with label alias layout" ( fun () ->
                    """var layout = {"ternary":{"aaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"baxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"caxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}}};"""
                    |> chartGeneratedContains LabelAlias.``Ternary point chart with label alias``
                )
                testCase "carpet chart with label alias data" ( fun () ->
                    """var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"aaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"baxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"carpet":"carpet1"}];"""
                    |> chartGeneratedContains LabelAlias.``Carpet chart with label alias``
                )
                testCase "carpet chart with label alias layout" ( fun () ->
                    emptyLayout LabelAlias.``Carpet chart with label alias``
                )
                testCase "heatmap chart with label alias data" ( fun () ->
                    """var data = [{"type":"heatmap","z":[[1,2],[3,4]],"colorbar":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}}];"""
                    |> chartGeneratedContains LabelAlias.``Heatmap chart with label alias``
                )
                testCase "heatmap chart with label alias layout" ( fun () ->
                    """var layout = {"xaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"yaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}};"""
                    |> chartGeneratedContains LabelAlias.``Heatmap chart with label alias``
                )
                testCase "point smith chart with label alias data" ( fun () ->
                    """var data = [{"type":"scattersmith","mode":"markers","imag":[2],"real":[1],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains LabelAlias.``Point smith chart with label alias``
                )
                testCase "point smith chart with label alias layout" ( fun () ->
                    """var layout = {"smith":{"imaginaryaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}},"realaxis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"}}}};"""
                    |> chartGeneratedContains LabelAlias.``Point smith chart with label alias``
                )
                testCase "bullet gauge indicator chart with label alias data" ( fun () ->
                    """var data = [{"type":"indicator","mode":"number+delta+gauge","value":1,"delta":{"reference":0},"gauge":{"axis":{"labelalias":{"1":"<b>ONE</b>","0°":"<b>ZERO</b>"},"visible":true,"range":[-1.0,1.0]},"shape":"bullet"}}];"""
                    |> chartGeneratedContains LabelAlias.``Bullet gauge indicator chart with label alias``
                )
                testCase "bullet gauge indicator chart label alias layout" ( fun () ->
                    emptyLayout LabelAlias.``Bullet gauge indicator chart with label alias``
                )
            ]
        ]