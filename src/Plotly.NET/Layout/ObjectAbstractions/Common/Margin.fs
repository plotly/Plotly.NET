namespace Plotly.NET.LayoutObjects

open DynamicObj
open System.Runtime.InteropServices

/// Margin
type Margin() =
    inherit DynamicObj()

    /// Init Margin type
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Left,
            [<Optional; DefaultParameterValue(null)>] ?Right,
            [<Optional; DefaultParameterValue(null)>] ?Top,
            [<Optional; DefaultParameterValue(null)>] ?Bottom,
            [<Optional; DefaultParameterValue(null)>] ?Pad,
            [<Optional; DefaultParameterValue(null)>] ?Autoexpand
        ) =
        Margin()
        |> Margin.style (
            ?Left = Left,
            ?Right = Right,
            ?Top = Top,
            ?Bottom = Bottom,
            ?Pad = Pad,
            ?Autoexpand = Autoexpand
        )


    // Applies the styles to Margin()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Left,
            [<Optional; DefaultParameterValue(null)>] ?Right,
            [<Optional; DefaultParameterValue(null)>] ?Top,
            [<Optional; DefaultParameterValue(null)>] ?Bottom,
            [<Optional; DefaultParameterValue(null)>] ?Pad,
            [<Optional; DefaultParameterValue(null)>] ?Autoexpand
        ) =
        (fun (margin: Margin) ->
            Left |> DynObj.setOptionalProperty margin "l"
            Right |> DynObj.setOptionalProperty margin "r"
            Top |> DynObj.setOptionalProperty margin "t"
            Bottom |> DynObj.setOptionalProperty margin "b"

            Pad |> DynObj.setOptionalProperty margin "pad"
            Autoexpand |> DynObj.setOptionalProperty margin "autoexpand"

            margin)
