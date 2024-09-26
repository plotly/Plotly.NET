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

            Diverging |> DynObj.setOptionalPropertyBy defaultColorScales "diverging" StyleParam.Colorscale.convert
            Sequential |> DynObj.setOptionalPropertyBy defaultColorScales "sequential" StyleParam.Colorscale.convert
            SequentialMinus |> DynObj.setOptionalPropertyBy defaultColorScales "sequentialminus" StyleParam.Colorscale.convert

            defaultColorScales)
