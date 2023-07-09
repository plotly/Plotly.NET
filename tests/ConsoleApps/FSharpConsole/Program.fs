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

[<EntryPoint>]
let main argv =
    Chart.Point(
        [1,2],
        UseDefaults = false
    )
    |> Chart.withTitle(
        Title.init(
            Text = """Lorem ipsum dolor sit amet, <br>consetetur sadipscing elitr, sed diam nonumy eirmod <br>tempor invidunt ut labore et dolore magna aliquyam erat, <br>sed diam voluptua. At vero eos et accusam et justo <br>duo dolores et ea rebum. Stet clita kasd gubergren,<br>no sea takimata sanctus est Lorem ipsum dolor sit amet. <br>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, <br>sed diam nonumy eirmod tempor invidunt ut labore et <br>dolore magna aliquyam erat, sed diam voluptua. <br>At vero eos et accusam et justo duo dolores et ea rebum. <br>Stet clita kasd gubergren, no sea takimata sanctus est <br>Lorem ipsum dolor sit amet.""",
            AutoMargin = true
        )
    )
    |> Chart.show
    0