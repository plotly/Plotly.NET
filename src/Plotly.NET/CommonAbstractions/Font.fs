namespace Plotly.NET

open System.Runtime.InteropServices

open DynamicObj

/// Font type inherits from dynamic object
type Font() =
    inherit DynamicObj()

    /// Init Font()
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Family: StyleParam.FontFamily,
            [<Optional; DefaultParameterValue(null)>] ?Size: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color
        ) =
        Font() |> Font.style (?Family = Family, ?Size = Size, ?Color = Color)


    // Applies the styles to Font()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Family: StyleParam.FontFamily,
            [<Optional; DefaultParameterValue(null)>] ?Size: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color
        ) =
        (fun (font: Font) ->
            font
            |> DynObj.withOptionalPropertyBy "family" Family StyleParam.FontFamily.toString
            |> DynObj.withOptionalProperty "size" Size
            |> DynObj.withOptionalProperty "color" Color
        )
