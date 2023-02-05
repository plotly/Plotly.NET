namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ActiveSelection() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =
        ActiveSelection() |> ActiveSelection.style (?FillColor = FillColor, ?Opacity = Opacity)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =
        (fun (activeSelection: ActiveSelection) ->

            FillColor |> DynObj.setValueOpt activeSelection "fillcolor"
            Opacity |> DynObj.setValueOpt activeSelection "opacity"

            activeSelection)
