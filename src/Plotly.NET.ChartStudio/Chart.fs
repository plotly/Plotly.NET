namespace Plotly.NET.ChartStudio

open Plotly.NET
open Plotly.NET.GenericChart
open System.Runtime.InteropServices
open Newtonsoft.Json
open System.Collections

/// Extensions methods from Plotly.NET.ImageExport for the Chart module, supporting the fluent pipeline style
[<AutoOpen>]
module ChartExtensions =
    let internal jsonConfig = JsonSerializerSettings()
    jsonConfig.ReferenceLoopHandling <- ReferenceLoopHandling.Serialize

    type Chart with

        [<CompiledName("PostToCloud")>]
        static member postToCloud
            (
                [<Optional; DefaultParameterValue(null)>] ?FileName: string,
                [<Optional; DefaultParameterValue(null)>] ?AutoOpen: bool,
                [<Optional; DefaultParameterValue(null)>] ?Sharing: string
            ) =

            let extractGridFromFigure (gChart: GenericChart) =
                let traces = getTraces gChart

                let dataArrays =
                    [ for trace in traces ->
                          trace.GetProperties(true)
                          |> Seq.filter (fun x -> (x.Value :? IEnumerable && not (x.Value :? string))) ]

                    |> Seq.mapi
                        (fun i data ->
                            data
                            |> Seq.map
                                (fun kvp ->
                                    {| Name = $"data.{i}.{kvp.Key}"
                                       Data = kvp.Value |}))

                printf "%A" dataArrays
                ()



            fun (gChart: GenericChart) ->

                extractGridFromFigure gChart

                let figure = GenericChart.toFigure gChart

                let payload =
                    JsonConvert.SerializeObject({| figure = figure |}, jsonConfig)

                API.create payload
