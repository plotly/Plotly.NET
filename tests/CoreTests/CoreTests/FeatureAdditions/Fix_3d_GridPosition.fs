module CoreTests.Fix_3d_GridPosition

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open TestUtils.HtmlCodegen
open Fix_3d_GridPosition

// https://github.com/plotly/Plotly.NET/issues/413

module ``Remove all existing subplots from individual charts on grid creation #413`` = 

    [<Tests>]
    let ``Add subplot titles`` =
        testList "FeatureAddition.Fix 3D chart position in Grid" [
            test "2x2 3d charts data" {
                """var data = [{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene2"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene3"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene4"}];"""
                |> chartGeneratedContains ``Remove all existing subplots from individual charts on grid creation #413``.``2x2 grid with only 3D charts and correct scene positioning``
            }
            test "2x2 3d charts layout" {
                """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":0,"column":0}},"scene2":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":0,"column":1}},"scene3":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":1,"column":0}},"scene4":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":1,"column":1}},"annotations":[{"x":0.22222222222222224,"y":1.0,"showarrow":false,"text":"1","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"},{"x":0.7777777777777778,"y":1.0,"showarrow":false,"text":"2","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"},{"x":0.22222222222222224,"y":0.4117647058823529,"showarrow":false,"text":"3","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"},{"x":0.7777777777777778,"y":0.4117647058823529,"showarrow":false,"text":"4","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"}],"grid":{"rows":2,"columns":2,"roworder":"top to bottom","pattern":"independent"}};"""
                |> chartGeneratedContains ``Remove all existing subplots from individual charts on grid creation #413``.``2x2 grid with only 3D charts and correct scene positioning``
            }
            test "2x2 3d charts ignores additional scenes data" {
                """var data = [{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene2"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene3"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene4"}];"""
                |> chartGeneratedContains ``Remove all existing subplots from individual charts on grid creation #413``.``2x2 grid chart creation ignores other scenes``
            }
            test "2x2 3d charts ignores additional scenes layout" {
                """var layout = {"scene2":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":0,"column":1}},"scene":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":0,"column":0}},"scene3":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":1,"column":0}},"scene4":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":1,"column":1}},"annotations":[{"x":0.22222222222222224,"y":1.0,"showarrow":false,"text":"1","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"},{"x":0.7777777777777778,"y":1.0,"showarrow":false,"text":"2","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"},{"x":0.22222222222222224,"y":0.4117647058823529,"showarrow":false,"text":"3","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"},{"x":0.7777777777777778,"y":0.4117647058823529,"showarrow":false,"text":"4","xanchor":"center","xref":"paper","yanchor":"bottom","yref":"paper"}],"grid":{"rows":2,"columns":2,"roworder":"top to bottom","pattern":"independent"}};"""
                |> chartGeneratedContains ``Remove all existing subplots from individual charts on grid creation #413``.``2x2 grid chart creation ignores other scenes``
            }
        ]