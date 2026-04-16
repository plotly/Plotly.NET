namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartCarpet_Contour =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a contour chart that lies on a specified carpet.
        ///
        /// Plots contours on either the first carpet axis or the carpet axis with a matching `carpet` attribute. Data `z` is interpreted as matching that of the corresponding carpet axis.
        /// </summary>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="z">Sets the z data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="A">Sets the a coordinates.</param>
        /// <param name="B">Sets the b coordinates.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="ColorScale">Sets the colorscale of this trace.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLineDash">Sets the contour line dash style</param>
        /// <param name="ContourLineColor">Sets the contour line color</param>
        /// <param name="ContourLineSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLine">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContourLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member ContourCarpet
            (
                z: seq<#IConvertible>,
                carpetAnchorId: string,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?A: seq<#IConvertible>,
                ?B: seq<#IConvertible>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Transpose: bool,
                ?ContourLineColor: Color,
                ?ContourLineDash: StyleParam.DrawingStyle,
                ?ContourLineSmoothing: float,
                ?ContourLine: Line,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContourLabels: bool,
                ?ContourLabelFont: Font,
                ?Contours: Contours,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let line =
                ContourLine
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = ContourLineColor,
                    ?Dash = ContourLineDash,
                    ?Smoothing = ContourLineSmoothing
                )

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContourLabels,
                    ?LabelFont = ContourLabelFont
                )

            TraceCarpet.initContourCarpet (
                TraceCarpetStyle.ContourCarpet(
                    Z = z,
                    ?A = A,
                    ?B = B,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Contours = contours,
                    Line = line
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a contour chart that lies on a specified carpet from encoded z data.
        /// </summary>
        /// <param name="zEncoded">Sets the z data as an encoded typed array.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="aEncoded">Sets the a coordinates as an encoded typed array.</param>
        /// <param name="bEncoded">Sets the b coordinates as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="ColorScale">Sets the colorscale of this trace.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLineDash">Sets the contour line dash style</param>
        /// <param name="ContourLineColor">Sets the contour line color</param>
        /// <param name="ContourLineSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLine">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContourLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member ContourCarpet
            (
                zEncoded: EncodedTypedArray,
                carpetAnchorId: string,
                ?aEncoded: EncodedTypedArray,
                ?bEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Transpose: bool,
                ?ContourLineColor: Color,
                ?ContourLineDash: StyleParam.DrawingStyle,
                ?ContourLineSmoothing: float,
                ?ContourLine: Line,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContourLabels: bool,
                ?ContourLabelFont: Font,
                ?Contours: Contours,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let line =
                ContourLine
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = ContourLineColor,
                    ?Dash = ContourLineDash,
                    ?Smoothing = ContourLineSmoothing
                )

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContourLabels,
                    ?LabelFont = ContourLabelFont
                )

            TraceCarpet.initContourCarpet (
                TraceCarpetStyle.ContourCarpet(
                    ZEncoded = zEncoded,
                    ?AEncoded = aEncoded,
                    ?BEncoded = bEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Contours = contours,
                    Line = line
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a contour chart that lies on a specified carpet.
        ///
        /// Plots contours on either the first carpet axis or the carpet axis with a matching `carpet` attribute. Data `z` is interpreted as matching that of the corresponding carpet axis.
        /// </summary>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="abz">Sets the a and b coordinates together with the respective z value</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="ColorScale">Sets the colorscale of this trace.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLineDash">Sets the contour line dash style</param>
        /// <param name="ContourLineColor">Sets the contour line color</param>
        /// <param name="ContourLineSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLine">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContourLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member ContourCarpet
            (
                abz: seq<#IConvertible * #IConvertible * #IConvertible>,
                carpetAnchorId: string,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Transpose: bool,
                ?ContourLineColor: Color,
                ?ContourLineDash: StyleParam.DrawingStyle,
                ?ContourLineSmoothing: float,
                ?ContourLine: Line,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContourLabels: bool,
                ?ContourLabelFont: Font,
                ?Contours: Contours,
                ?UseDefaults: bool
            ) =

            let a, b, z = Seq.unzip3 abz

            Chart.ContourCarpet(
                z,
                carpetAnchorId,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                A = a,
                B = b,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?Transpose = Transpose,
                ?ContourLineColor = ContourLineColor,
                ?ContourLineDash = ContourLineDash,
                ?ContourLineSmoothing = ContourLineSmoothing,
                ?ContourLine = ContourLine,
                ?ContoursColoring = ContoursColoring,
                ?ContoursOperation = ContoursOperation,
                ?ContoursType = ContoursType,
                ?ShowContourLabels = ShowContourLabels,
                ?ContourLabelFont = ContourLabelFont,
                ?Contours = Contours,
                ?UseDefaults = UseDefaults
            )
