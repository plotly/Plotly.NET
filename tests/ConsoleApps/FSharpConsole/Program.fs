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

    let charts = 
        [
            Chart.Point3D([1,2,3], UseDefaults = false)
            Chart.Point3D([1,2,3], UseDefaults = false)
            Chart.Point3D([1,2,3], UseDefaults = false)
            Chart.Point3D([1,2,3], UseDefaults = false)
        ]

    printfn "Individual Charts:"
    printfn "Layout:"
    charts
    |> Seq.iter (fun c ->
        GenericChart.getLayout c
        |> DynamicObj.DynObj.print
    )
    printfn "Traces:"
    charts
    |> Seq.iter (fun c ->
        GenericChart.getTraces c
        |> Seq.iter DynamicObj.DynObj.print
    )

    let grid = 
        charts
        |> Chart.Grid(2,2)

    printfn "Grid:"
    printfn "Layout:"
    grid
    |> GenericChart.getLayout
    |> DynamicObj.DynObj.print
    printfn "Traces:"
    grid
    |> GenericChart.getTraces
    |> Seq.iter DynamicObj.DynObj.print

    grid
    |> Chart.show

    0