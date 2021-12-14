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

            Color |> DynObj.setValueOpt indicatorDirection "color"
            Symbol |> DynObj.setValueOpt indicatorDirection "symbol"

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

            Decreasing |> DynObj.setValueOpt indicatorDelta "decreasing"
            Font |> DynObj.setValueOpt indicatorDelta "font"
            Increasing |> DynObj.setValueOpt indicatorDelta "increasing"
            Position |> DynObj.setValueOptBy indicatorDelta "position" StyleParam.IndicatorDeltaPosition.convert
            Reference |> DynObj.setValueOpt indicatorDelta "reference"
            Relative |> DynObj.setValueOpt indicatorDelta "relative"
            ValueFormat |> DynObj.setValueOpt indicatorDelta "valueformat"

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

            Font |> DynObj.setValueOpt indicatorNumber "font"
            Prefix |> DynObj.setValueOpt indicatorNumber "prefix"
            Suffix |> DynObj.setValueOpt indicatorNumber "suffix"
            ValueFormat |> DynObj.setValueOpt indicatorNumber "valueformat"

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

            Color |> DynObj.setValueOpt indicatorBar "color"
            Line |> DynObj.setValueOpt indicatorBar "line"
            Thickness |> DynObj.setValueOpt indicatorBar "thickness"

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

            Color |> DynObj.setValueOpt indicatorSteps "color"
            Line |> DynObj.setValueOpt indicatorSteps "line"
            Name |> DynObj.setValueOpt indicatorSteps "name"
            Range |> DynObj.setValueOptBy indicatorSteps "range" StyleParam.Range.convert
            TemplateItemName |> DynObj.setValueOpt indicatorSteps "templateitemname"
            Thickness |> DynObj.setValueOpt indicatorSteps "thickness"

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

            Line |> DynObj.setValueOpt indicatorThreshold "line"
            Thickness |> DynObj.setValueOpt indicatorThreshold "thickness"
            Value |> DynObj.setValueOpt indicatorThreshold "value"

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

            Axis |> DynObj.setValueOpt indicatorGauge "axis"
            Bar |> DynObj.setValueOpt indicatorGauge "bar"
            BGColor |> DynObj.setValueOpt indicatorGauge "bgcolor"
            BorderColor |> DynObj.setValueOpt indicatorGauge "bordercolor"
            BorderWidth |> DynObj.setValueOpt indicatorGauge "borderwidth"
            Shape |> DynObj.setValueOptBy indicatorGauge "shape" StyleParam.IndicatorGaugeShape.convert
            Steps |> DynObj.setValueOpt indicatorGauge "steps"
            Threshold |> DynObj.setValueOpt indicatorGauge "threshold  "

            indicatorGauge)
