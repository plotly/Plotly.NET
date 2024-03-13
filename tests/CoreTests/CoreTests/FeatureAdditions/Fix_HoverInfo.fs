module CoreTests.Fix_HoverInfo

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open TestUtils.HtmlCodegen
open Fix_HoverInfo_TestCharts

module ``Fix missing HoverInfo bindings #446`` = 

    [<Tests>]
    let ``Implement all HoverInfo options for #446`` =
        testList "FeatureAddition.Fix missing HoverInfo bindings" [
            test "all hoverinfo options combined data" {
                """var data = [{"type":"scatter3d","name":"NAME: trace with x","mode":"markers","x":[1],"y":[2],"z":[3],"text":"TEXT: trace with x","marker":{},"line":{},"hoverinfo":"x"},{"type":"scatter3d","name":"NAME: trace with x+y","mode":"markers","x":[2],"y":[3],"z":[4],"text":"TEXT: trace with x+y","marker":{},"line":{},"hoverinfo":"x+y"},{"type":"scatter3d","name":"NAME: trace with x+y+z","mode":"markers","x":[3],"y":[4],"z":[5],"text":"TEXT: trace with x+y+z","marker":{},"line":{},"hoverinfo":"x+y+z"},{"type":"scatter3d","name":"NAME: trace with x+y+z+text","mode":"markers","x":[4],"y":[5],"z":[6],"text":"TEXT: trace with x+y+z+text","marker":{},"line":{},"hoverinfo":"x+y+z+text"},{"type":"scatter3d","name":"NAME: trace with x+y+z+text+name","mode":"markers","x":[5],"y":[6],"z":[7],"text":"TEXT: trace with x+y+z+text+name","marker":{},"line":{},"hoverinfo":"x+y+z+text+name"},{"type":"scatter3d","name":"NAME: trace with y","mode":"markers","x":[6],"y":[7],"z":[8],"text":"TEXT: trace with y","marker":{},"line":{},"hoverinfo":"y"},{"type":"scatter3d","name":"NAME: trace with y+z","mode":"markers","x":[7],"y":[8],"z":[9],"text":"TEXT: trace with y+z","marker":{},"line":{},"hoverinfo":"y+z"},{"type":"scatter3d","name":"NAME: trace with y+z+text","mode":"markers","x":[8],"y":[9],"z":[10],"text":"TEXT: trace with y+z+text","marker":{},"line":{},"hoverinfo":"y+z+text"},{"type":"scatter3d","name":"NAME: trace with y+z+text+name","mode":"markers","x":[9],"y":[10],"z":[11],"text":"TEXT: trace with y+z+text+name","marker":{},"line":{},"hoverinfo":"y+z+text+name"},{"type":"scatter3d","name":"NAME: trace with z","mode":"markers","x":[10],"y":[11],"z":[12],"text":"TEXT: trace with z","marker":{},"line":{},"hoverinfo":"z"},{"type":"scatter3d","name":"NAME: trace with z+text","mode":"markers","x":[11],"y":[12],"z":[13],"text":"TEXT: trace with z+text","marker":{},"line":{},"hoverinfo":"z+text"},{"type":"scatter3d","name":"NAME: trace with z+text+name","mode":"markers","x":[12],"y":[13],"z":[14],"text":"TEXT: trace with z+text+name","marker":{},"line":{},"hoverinfo":"z+text+name"},{"type":"scatter3d","name":"NAME: trace with text","mode":"markers","x":[13],"y":[14],"z":[15],"text":"TEXT: trace with text","marker":{},"line":{},"hoverinfo":"text"},{"type":"scatter3d","name":"NAME: trace with text+name","mode":"markers","x":[14],"y":[15],"z":[16],"text":"TEXT: trace with text+name","marker":{},"line":{},"hoverinfo":"text+name"},{"type":"scatter3d","name":"NAME: trace with name","mode":"markers","x":[15],"y":[16],"z":[17],"text":"TEXT: trace with name","marker":{},"line":{},"hoverinfo":"name"},{"type":"scatter3d","name":"NAME: trace with all","mode":"markers","x":[16],"y":[17],"z":[18],"text":"TEXT: trace with all","marker":{},"line":{},"hoverinfo":"all"},{"type":"scatter3d","name":"NAME: trace with none","mode":"markers","x":[17],"y":[18],"z":[19],"text":"TEXT: trace with none","marker":{},"line":{},"hoverinfo":"none"},{"type":"scatter3d","name":"NAME: trace with skip","mode":"markers","x":[18],"y":[19],"z":[20],"text":"TEXT: trace with skip","marker":{},"line":{},"hoverinfo":"skip"}];"""
                |> chartGeneratedContains ``Fix missing HoverInfo bindings #446``.``Point3D charts with all possible hoverinfo combinations``
            }
            test "all hoverinfo options combined layout" {
                """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}},"width":1000,"height":1000};"""
                |> chartGeneratedContains ``Fix missing HoverInfo bindings #446``.``Point3D charts with all possible hoverinfo combinations`` 
            }
        ]