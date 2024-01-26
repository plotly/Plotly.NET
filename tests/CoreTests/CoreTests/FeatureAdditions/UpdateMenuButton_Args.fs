// https://github.com/plotly/Plotly.NET/issues/414

module CoreTests.UpdateMenuButton_Args

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open TestUtils.HtmlCodegen
open UpdateMenuButton_Args_TestCharts
    
module ``UpdateMenuButton Args as DynamicObj collection #414`` = 

    [<Tests>]
    let ``UpdateMenuButton Args as DynamicObj collection #414`` =
        testList "FeatureAddition.UpdateMenuButton Args must be DynamicObj collection" [
            test "relayout x axis range data" {
                """var data = [{"type":"scatter","mode":"markers","x":[0,1,2,3,4,5,6,7,8,9,10],"y":[0,1,2,3,4,5,6,7,8,9,10],"marker":{},"line":{}}];"""
                |> chartGeneratedContains ``UpdateMenuButton Args as DynamicObj collection #414``.``Simple point chart with update buttons triggerin relayout for x axis range``
            }
            test "relayout x axis range layout" {
                """var layout = {"updatemenus":[{"buttons":[{"args":[{"xaxis.range":[0,0]}],"label":"0 - 0","method":"relayout","name":"0","visible":true},{"args":[{"xaxis.range":[0,1]}],"label":"0 - 1","method":"relayout","name":"1","visible":true},{"args":[{"xaxis.range":[0,2]}],"label":"0 - 2","method":"relayout","name":"2","visible":true},{"args":[{"xaxis.range":[0,3]}],"label":"0 - 3","method":"relayout","name":"3","visible":true},{"args":[{"xaxis.range":[0,4]}],"label":"0 - 4","method":"relayout","name":"4","visible":true},{"args":[{"xaxis.range":[0,5]}],"label":"0 - 5","method":"relayout","name":"5","visible":true},{"args":[{"xaxis.range":[0,6]}],"label":"0 - 6","method":"relayout","name":"6","visible":true},{"args":[{"xaxis.range":[0,7]}],"label":"0 - 7","method":"relayout","name":"7","visible":true},{"args":[{"xaxis.range":[0,8]}],"label":"0 - 8","method":"relayout","name":"8","visible":true},{"args":[{"xaxis.range":[0,9]}],"label":"0 - 9","method":"relayout","name":"9","visible":true}]}]};"""
                |> chartGeneratedContains ``UpdateMenuButton Args as DynamicObj collection #414``.``Simple point chart with update buttons triggerin relayout for x axis range``
            }
            test "relayout x and y axis range data" {
                """var data = [{"type":"scatter","mode":"markers","x":[0,1,2,3,4,5,6,7,8,9,10],"y":[0,1,2,3,4,5,6,7,8,9,10],"marker":{},"line":{}}];"""
                |> chartGeneratedContains ``UpdateMenuButton Args as DynamicObj collection #414``.``Simple point chart with update buttons triggerin relayout for x and y axis range``
            }
            test "relayout x and y axis range layout" {
                """var layout = {"updatemenus":[{"buttons":[{"args":[{"xaxis.range":[0,0],"yaxis.range":[0,0]}],"label":"0 - 0","method":"relayout","name":"0","visible":true},{"args":[{"xaxis.range":[0,1],"yaxis.range":[0,1]}],"label":"0 - 1","method":"relayout","name":"1","visible":true},{"args":[{"xaxis.range":[0,2],"yaxis.range":[0,2]}],"label":"0 - 2","method":"relayout","name":"2","visible":true},{"args":[{"xaxis.range":[0,3],"yaxis.range":[0,3]}],"label":"0 - 3","method":"relayout","name":"3","visible":true},{"args":[{"xaxis.range":[0,4],"yaxis.range":[0,4]}],"label":"0 - 4","method":"relayout","name":"4","visible":true},{"args":[{"xaxis.range":[0,5],"yaxis.range":[0,5]}],"label":"0 - 5","method":"relayout","name":"5","visible":true},{"args":[{"xaxis.range":[0,6],"yaxis.range":[0,6]}],"label":"0 - 6","method":"relayout","name":"6","visible":true},{"args":[{"xaxis.range":[0,7],"yaxis.range":[0,7]}],"label":"0 - 7","method":"relayout","name":"7","visible":true},{"args":[{"xaxis.range":[0,8],"yaxis.range":[0,8]}],"label":"0 - 8","method":"relayout","name":"8","visible":true},{"args":[{"xaxis.range":[0,9],"yaxis.range":[0,9]}],"label":"0 - 9","method":"relayout","name":"9","visible":true}]}]};"""
                |> chartGeneratedContains ``UpdateMenuButton Args as DynamicObj collection #414``.``Simple point chart with update buttons triggerin relayout for x and y axis range``
            }
        ]