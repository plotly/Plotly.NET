namespace Plotly.NET

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type AutoRangeOptions() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new AutoRangeOptions object with the given styling.
    /// </summary>
    /// <param name="ClipMax">Clip autorange maximum if it goes beyond this value. Has no effect when `autorangeoptions.maxallowed` is provided.</param>
    /// <param name="ClipMin">Clip autorange minimum if it goes beyond this value. Has no effect when `autorangeoptions.minallowed` is provided.</param>
    /// <param name="Include">Ensure this value is included in autorange.</param>
    /// <param name="MaxAllowed">Use this value exactly as autorange maximum.</param>
    /// <param name="MinAllowed">Use this value exactly as autorange minimum.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?ClipMax: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ClipMin: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Include: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MaxAllowed: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MinAllowed: #IConvertible
        ) =
        AutoRangeOptions()
        |> AutoRangeOptions.style (
            ?ClipMax = ClipMax,
            ?ClipMin = ClipMin,
            ?Include = Include,
            ?MaxAllowed = MaxAllowed,
            ?MinAllowed = MinAllowed
        )

    /// <summary>
    /// Returns a function that applies the given styles to a AutoRangeOptions object.
    /// </summary>
    /// <param name="ClipMax">Clip autorange maximum if it goes beyond this value. Has no effect when `autorangeoptions.maxallowed` is provided.</param>
    /// <param name="ClipMin">Clip autorange minimum if it goes beyond this value. Has no effect when `autorangeoptions.minallowed` is provided.</param>
    /// <param name="Include">Ensure this value is included in autorange.</param>
    /// <param name="MaxAllowed">Use this value exactly as autorange maximum.</param>
    /// <param name="MinAllowed">Use this value exactly as autorange minimum.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?ClipMax: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ClipMin: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Include: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MaxAllowed: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MinAllowed: #IConvertible

        ) =
        (fun (autoRangeOptions: AutoRangeOptions) ->

            ClipMax |> DynObj.setValueOpt autoRangeOptions "clipmax"
            ClipMin |> DynObj.setValueOpt autoRangeOptions "clipmin"
            Include |> DynObj.setValueOpt autoRangeOptions "include"
            MaxAllowed |> DynObj.setValueOpt autoRangeOptions "maxallowed"
            MinAllowed |> DynObj.setValueOpt autoRangeOptions "minallowed"

            autoRangeOptions)