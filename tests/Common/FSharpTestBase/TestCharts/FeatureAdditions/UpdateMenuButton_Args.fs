module UpdateMenuButton_Args_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open DynamicObj

// https://github.com/plotly/Plotly.NET/issues/414

module ``UpdateMenuButton Args as DynamicObj collection #414`` = 

    let ``Simple point chart with update buttons triggerin relayout for x axis range`` =
        let buttons = 
            [ for i in 0 .. 9 -> 
                UpdateMenuButton.init(
                    Label = $"0 - {i}", 
                    Name = $"{i}", 
                    Visible = true, 
                    Method = StyleParam.UpdateMethod.Relayout,
                    Args = (
                        let tmp = DynamicObj()
                        tmp?("xaxis.range") <- [0; i]
                        [tmp]
                    )
                )
            ]

        Chart.Point(
            x = [0 .. 10],
            y = [0 .. 10],
            UseDefaults = false
        )
        |> Chart.withUpdateMenu(
            UpdateMenu.init(
                Buttons = buttons
            )
        )

    let ``Simple point chart with update buttons triggerin relayout for x and y axis range`` =
        
        let buttons = 
            [ for i in 0 .. 9 -> 
                UpdateMenuButton.init(
                    Label = $"0 - {i}", 
                    Name = $"{i}", 
                    Visible = true, 
                    Method = StyleParam.UpdateMethod.Relayout,
                    Args = (
                        let tmp = DynamicObj()
                        tmp?("xaxis.range") <- [0; i]
                        tmp?("yaxis.range") <- [0; i]
                        [tmp]
                    )
                )
            ]

        Chart.Point(

            x = [0 .. 10],
            y = [0 .. 10],
            UseDefaults = false
        )
        |> Chart.withUpdateMenu(
            UpdateMenu.init(
                Buttons = buttons
            )
        )