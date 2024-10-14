namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type DefaultColorScales() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Diverging: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?Sequential: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?SequentialMinus: StyleParam.Colorscale
        ) =
        DefaultColorScales()
        |> DefaultColorScales.style (
            ?Diverging = Diverging,
            ?Sequential = Sequential,
            ?SequentialMinus = SequentialMinus
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Diverging: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?Sequential: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?SequentialMinus: StyleParam.Colorscale
        ) =
        (fun (defaultColorScales: DefaultColorScales) ->

            defaultColorScales
            |> DynObj.withOptionalPropertyBy "diverging" Diverging StyleParam.Colorscale.convert
            |> DynObj.withOptionalPropertyBy "sequential" Sequential StyleParam.Colorscale.convert
            |> DynObj.withOptionalPropertyBy "sequentialminus" SequentialMinus StyleParam.Colorscale.convert
        )
