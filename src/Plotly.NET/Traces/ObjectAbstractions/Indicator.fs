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

    /// <summary>
    /// Returns a new IndicatorDelta object with the given styles
    /// </summary>
    /// <param name="Decreasing">Sets the style of decreasing deltas.</param>
    /// <param name="Font">Set the font used to display the delta</param>
    /// <param name="Increasing">Sets the style of increasing deltas.</param>
    /// <param name="Position">Sets the position of delta with respect to the number.</param>
    /// <param name="Prefix">Sets a prefix appearing before the delta.</param>
    /// <param name="Reference">Sets the reference value to compute the delta. By default, it is set to the current value.</param>
    /// <param name="Relative">Show relative change</param>
    /// <param name="Suffix">Sets a suffix appearing next to the delta.</param>
    /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Position: StyleParam.IndicatorDeltaPosition,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?Reference: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Relative: bool,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string
        ) =
        IndicatorDelta()
        |> IndicatorDelta.style (
            ?Decreasing = Decreasing,
            ?Font = Font,
            ?Increasing = Increasing,
            ?Position = Position,
            ?Prefix = Prefix,
            ?Reference = Reference,
            ?Relative = Relative,
            ?Suffix = Suffix,
            ?ValueFormat = ValueFormat
        )

    /// <summary>
    /// Returns a function that applies the given styles to an IndicatorDelta object
    /// </summary>
    /// <param name="Decreasing">Sets the style of decreasing deltas.</param>
    /// <param name="Font">Set the font used to display the delta</param>
    /// <param name="Increasing">Sets the style of increasing deltas.</param>
    /// <param name="Position">Sets the position of delta with respect to the number.</param>
    /// <param name="Prefix">Sets a prefix appearing before the delta.</param>
    /// <param name="Reference">Sets the reference value to compute the delta. By default, it is set to the current value.</param>
    /// <param name="Relative">Show relative change</param>
    /// <param name="Suffix">Sets a suffix appearing next to the delta.</param>
    /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: IndicatorSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Position: StyleParam.IndicatorDeltaPosition,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?Reference: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Relative: bool,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string
        ) =
        (fun (indicatorDelta: IndicatorDelta) ->

            Decreasing |> DynObj.setValueOpt indicatorDelta "decreasing"
            Font |> DynObj.setValueOpt indicatorDelta "font"
            Increasing |> DynObj.setValueOpt indicatorDelta "increasing"
            Position |> DynObj.setValueOptBy indicatorDelta "position" StyleParam.IndicatorDeltaPosition.convert
            Prefix |> DynObj.setValueOpt indicatorDelta "prefix"
            Reference |> DynObj.setValueOpt indicatorDelta "reference"
            Relative |> DynObj.setValueOpt indicatorDelta "relative"
            Suffix |> DynObj.setValueOpt indicatorDelta "suffix"
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
            Threshold |> DynObj.setValueOpt indicatorGauge "threshold"

            indicatorGauge)
