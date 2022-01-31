namespace Plotly.NET

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

            Enabled |> DynObj.setValueOpt tickFormatStop "enabled"
            DTickRange |> DynObj.setValueOpt tickFormatStop "dtickrange"
            Value |> DynObj.setValueOpt tickFormatStop "value"
            Name |> DynObj.setValueOpt tickFormatStop "name"
            TemplateItemName |> DynObj.setValueOpt tickFormatStop "templateitemname"


            tickFormatStop)
