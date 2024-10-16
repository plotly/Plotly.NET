namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ActiveShape() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =
        ActiveShape() |> ActiveShape.style (?FillColor = FillColor, ?Opacity = Opacity)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =
        (fun (activeShape: ActiveShape) ->

            activeShape
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withOptionalProperty "opacity" Opacity
        )
