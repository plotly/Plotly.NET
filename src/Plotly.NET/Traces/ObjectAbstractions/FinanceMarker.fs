namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type FinanceMarker() =
    inherit DynamicObj()

    [<Obsolete("the argument 'MarkerColor' is obsolete and will be dropped in the next major release")>]
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle
        ) =
        FinanceMarker()
        |> FinanceMarker.style (
            ?MarkerColor = MarkerColor,
            ?FillColor = FillColor,
            ?LineColor = LineColor,
            ?LineWidth = LineWidth,
            ?LineDash = LineDash

        )

    [<Obsolete("the argument 'MarkerColor' is obsolete and will be dropped in the next major release")>]
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle
        ) =
        (fun (financeMarker: FinanceMarker) ->

            let line =
                financeMarker.TryGetTypedValue<Line>("line")
                |> Option.defaultValue(Plotly.NET.Line.init())
                |> Line.style (?Color = LineColor, ?Width = LineWidth, ?Dash = LineDash)

            FillColor |> DynObj.setValueOpt financeMarker "fillcolor"
            line |> DynObj.setValue financeMarker "line"

            financeMarker)
