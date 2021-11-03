// Learn more about F# at http://fsharp.org

open System
open Plotly.NET
open Plotly.NET.ChartStudio

[<EntryPoint>]
let main argv =

    ChartStudio.Credentials.setCredentialsFile (Username = "XXXX", APIKEY = "XXXXX")

    let chart =
        Chart.Scatter(x = [ 0; 2; 3 ], y = [ 1; 2; 3 ], mode = StyleParam.Mode.Lines_Markers)
        |> Chart.postToCloud ("base-line", true)

    printf "%A" chart
    0 // return an integer exit code
