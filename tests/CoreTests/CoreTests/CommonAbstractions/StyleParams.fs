module Tests.CommonAbstractions.StyleParams

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open Newtonsoft.Json

let cScale = StyleParam.Colorscale.Custom [0., Color.fromKeyword Red; 1., Color.fromKeyword Blue]

let correctJson = """[[0.0,"rgba(255, 0, 0, 1.0)"],[1.0,"rgba(0, 0, 255, 1.0)"]]"""

[<Tests>]
let ``StyleParams tests`` =
    testList "CommonAbstractions.StyleParams tests" [
        testList "ColorScale" [
            testCase "JSON serialization" (fun () ->
                let actual = cScale |> StyleParam.Colorscale.convert |> JsonConvert.SerializeObject
                Expect.equal actual correctJson "Custom colorscale not converted properly"
            )        
        ]
    ]
    