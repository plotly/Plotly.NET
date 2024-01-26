open System
open Deedle
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine
open Newtonsoft.Json

let getZeroCollection n : float []=
    Array.zeroCreate n 

[<EntryPoint>]
let main argv =

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
    |> Chart.show
    0