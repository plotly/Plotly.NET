namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type TickFormatStop() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Enabled: bool,
            [<Optional; DefaultParameterValue(null)>] ?DTickRange: seq<string * string>,
            [<Optional; DefaultParameterValue(null)>] ?Value: string,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string
        ) =
        TickFormatStop()
        |> TickFormatStop.style (
            ?Enabled = Enabled,
            ?DTickRange = DTickRange,
            ?Value = Value,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Enabled: bool,
            [<Optional; DefaultParameterValue(null)>] ?DTickRange: seq<string * string>,
            [<Optional; DefaultParameterValue(null)>] ?Value: string,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string
        ) =
        (fun (tickFormatStop: TickFormatStop) ->


            tickFormatStop

            ++? ("enabled", Enabled )
            ++? ("dtickrange", DTickRange )
            ++? ("value", Value )
            ++? ("name", Name )
            ++? ("templateitemname", TemplateItemName ))
