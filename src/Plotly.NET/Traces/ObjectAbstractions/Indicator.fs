namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type IndicatorSymbol() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: string
        ) =
        IndicatorSymbol() |> IndicatorSymbol.style (?Color = Color, ?Symbol = Symbol)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: string
        ) =
        (fun (indicatorDirection: IndicatorSymbol) ->

            ++? ("color", Color )
            ++? ("symbol", Symbol )

            indicatorDirection)

type IndicatorDelta() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Position: StyleParam.IndicatorDeltaPosition,
            [<Optional; DefaultParameterValue(null)>] ?Reference: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Relative: bool,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string
        ) =
        IndicatorDelta()
        |> IndicatorDelta.style (
            ?Decreasing = Decreasing,
            ?Font = Font,
            ?Increasing = Increasing,
            ?Position = Position,
            ?Reference = Reference,
            ?Relative = Relative,
            ?ValueFormat = ValueFormat
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Position: StyleParam.IndicatorDeltaPosition,
            [<Optional; DefaultParameterValue(null)>] ?Reference: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Relative: bool,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string
        ) =
        (fun (indicatorDelta: IndicatorDelta) ->

            ++? ("decreasing", Decreasing )
            ++? ("font", Font )
            ++? ("increasing", Increasing )
            ++?? ("position", Position , StyleParam.IndicatorDeltaPosition.convert)
            ++? ("reference", Reference )
            ++? ("relative", Relative )
            ++? ("valueformat", ValueFormat )

            indicatorDelta)

type IndicatorNumber() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string
        ) =
        IndicatorNumber()
        |> IndicatorNumber.style (?Font = Font, ?Prefix = Prefix, ?Suffix = Suffix, ?ValueFormat = ValueFormat)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string
        ) =
        (fun (indicatorNumber: IndicatorNumber) ->

            ++? ("font", Font )
            ++? ("prefix", Prefix )
            ++? ("suffix", Suffix )
            ++? ("valueformat", ValueFormat )

            indicatorNumber)


type IndicatorBar() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float
        ) =
        IndicatorBar() |> IndicatorBar.style (?Color = Color, ?Line = Line, ?Thickness = Thickness)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float
        ) =
        (fun (indicatorBar: IndicatorBar) ->

            ++? ("color", Color )
            ++? ("line", Line )
            ++? ("thickness", Thickness )

            indicatorBar)

type IndicatorStep() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float
        ) =
        IndicatorStep()
        |> IndicatorStep.style (
            ?Color = Color,
            ?Line = Line,
            ?Name = Name,
            ?Range = Range,
            ?TemplateItemName = TemplateItemName,
            ?Thickness = Thickness
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float
        ) =
        (fun (indicatorSteps: IndicatorStep) ->

            ++? ("color", Color )
            ++? ("line", Line )
            ++? ("name", Name )
            ++?? ("range", Range , StyleParam.Range.convert)
            ++? ("templateitemname", TemplateItemName )
            ++? ("thickness", Thickness )

            indicatorSteps)


type IndicatorThreshold() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Value: #IConvertible
        ) =
        IndicatorThreshold() |> IndicatorThreshold.style (?Line = Line, ?Thickness = Thickness, ?Value = Value)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Value: #IConvertible
        ) =
        (fun (indicatorThreshold: IndicatorThreshold) ->

            ++? ("line", Line )
            ++? ("thickness", Thickness )
            ++? ("value", Value )

            indicatorThreshold)


type IndicatorGauge() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Axis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Bar: IndicatorBar,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.IndicatorGaugeShape,
            [<Optional; DefaultParameterValue(null)>] ?Steps: seq<IndicatorStep>,
            [<Optional; DefaultParameterValue(null)>] ?Threshold: IndicatorThreshold
        ) =
        IndicatorGauge()
        |> IndicatorGauge.style (
            ?Axis = Axis,
            ?Bar = Bar,
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth,
            ?Shape = Shape,
            ?Steps = Steps,
            ?Threshold = Threshold
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Axis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Bar: IndicatorBar,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.IndicatorGaugeShape,
            [<Optional; DefaultParameterValue(null)>] ?Steps: seq<IndicatorStep>,
            [<Optional; DefaultParameterValue(null)>] ?Threshold: IndicatorThreshold
        ) =
        (fun (indicatorGauge: IndicatorGauge) ->

            ++? ("axis", Axis )
            ++? ("bar", Bar )
            ++? ("bgcolor", BGColor )
            ++? ("bordercolor", BorderColor )
            ++? ("borderwidth", BorderWidth )
            ++?? ("shape", Shape , StyleParam.IndicatorGaugeShape.convert)
            ++? ("steps", Steps )
            ++? ("threshold", Threshold )

            indicatorGauge)
