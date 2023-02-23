namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary>Controls the style of selected markers in supported traces</summary>
type MarkerSelectionStyle() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new MarkerSelectionStyle object with the given styles
    /// </summary>
    /// <param name="Opacity">Sets the opacity of the selected/unselected markers</param>
    /// <param name="Color">Sets the color of the selected/unselected markers</param>
    /// <param name="Size">Sets the size of the selected/unselected markers</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Size: int
        ) =
        MarkerSelectionStyle() |> MarkerSelectionStyle.style (?Opacity = Opacity, ?Color = Color, ?Size = Size)

    /// <summary>
    /// Returns a function that applies the given styles to a MarkerSelectionStyle object
    /// </summary>
    /// <param name="Opacity">Sets the opacity of the selected/unselected markers</param>
    /// <param name="Color">Sets the color of the selected/unselected markers</param>
    /// <param name="Size">Sets the size of the selected/unselected markers</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Size: int
        ) =
        (fun (markerSelectionStyle: MarkerSelectionStyle) ->

            Opacity |> DynObj.setValueOpt markerSelectionStyle "opacity"
            Color |> DynObj.setValueOpt markerSelectionStyle "color"
            Size |> DynObj.setValueOpt markerSelectionStyle "size"

            markerSelectionStyle)

/// <summary>Controls the style of selected lines in supported traces</summary>
type LineSelectionStyle() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new LineSelectionStyle object with the given styles
    /// </summary>
    /// <param name="Opacity">Sets the opacity of the selected/unselected lines</param>
    /// <param name="Color">Sets the color of the selected/unselected lines</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color
        ) =
        LineSelectionStyle() |> LineSelectionStyle.style (?Opacity = Opacity, ?Color = Color)

    /// <summary>
    /// Returns a function that applies the given styles to a LineSelectionStyle object
    /// </summary>
    /// <param name="Opacity">Sets the opacity of the selected/unselected lines</param>
    /// <param name="Color">Sets the color of the selected/unselected lines</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color
        ) =
        (fun (lineSelectionStyle: LineSelectionStyle) ->

            Opacity |> DynObj.setValueOpt lineSelectionStyle "opacity"
            Color |> DynObj.setValueOpt lineSelectionStyle "color"

            lineSelectionStyle)

/// <summary>Controls the style of selected text in supported traces</summary>
type FontSelectionStyle() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new FontSelectionStyle object with the given styles
    /// </summary>
    /// <param name="Color">Sets the color of the selected/unselected text</param>
    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        FontSelectionStyle() |> FontSelectionStyle.style (?Color = Color)

    /// <summary>
    /// Returns a function that applies the given styles to a FontSelectionStyle object
    /// </summary>
    /// <param name="Color">Sets the color of the selected/unselected text</param>
    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        (fun (fontSelectionStyle: FontSelectionStyle) ->

            Color |> DynObj.setValueOpt fontSelectionStyle "color"

            fontSelectionStyle)

/// <summary>
/// Used to control selected/unselected trace item styles in supported traces.
/// </summary>
type TraceSelection() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new TraceSelection object with the given styles
    /// </summary>
    /// <param name="MarkerSelectionStyle">Sets the styles of the selected/unselected markers</param>
    /// <param name="LineSelectionStyle">Sets the styles of the selected/unselected lines</param>
    /// <param name="FontSelectionStyle">Sets the styles of the selected/unselected texts</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerSelectionStyle: MarkerSelectionStyle,
            [<Optional; DefaultParameterValue(null)>] ?LineSelectionStyle: LineSelectionStyle,
            [<Optional; DefaultParameterValue(null)>] ?FontSelectionStyle: FontSelectionStyle
        ) =
        TraceSelection()
        |> TraceSelection.style (
            ?MarkerSelectionStyle = MarkerSelectionStyle,
            ?LineSelectionStyle = LineSelectionStyle,
            ?FontSelectionStyle = FontSelectionStyle
        )

    /// <summary>
    /// Returns a function that applies the given styles to a TraceSelection object
    /// </summary>
    /// <param name="MarkerSelectionStyle">Sets the styles of the selected/unselected markers</param>
    /// <param name="LineSelectionStyle">Sets the styles of the selected/unselected lines</param>
    /// <param name="FontSelectionStyle">Sets the styles of the selected/unselected texts</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerSelectionStyle: MarkerSelectionStyle,
            [<Optional; DefaultParameterValue(null)>] ?LineSelectionStyle: LineSelectionStyle,
            [<Optional; DefaultParameterValue(null)>] ?FontSelectionStyle: FontSelectionStyle
        ) =
        (fun (traceSelection: TraceSelection) ->

            MarkerSelectionStyle |> DynObj.setValueOpt traceSelection "marker"
            LineSelectionStyle |> DynObj.setValueOpt traceSelection "line"
            FontSelectionStyle |> DynObj.setValueOpt traceSelection "font"

            traceSelection)
