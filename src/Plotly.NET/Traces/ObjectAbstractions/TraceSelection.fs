namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary>
/// Used to control selected/unselected trace item styles in supported traces.
/// </summary>
type TraceSelection() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new TraceSelection object with the given styles
    /// </summary>
    /// <param name="MarkerOpacity">Sets the opacity of the selected/unselected trace items</param>
    /// <param name="MarkerColor">Sets the color of the selected/unselected trace items</param>
    /// <param name="MarkerSize">Sets the size of the selected/unselected trace items</param>
    /// <param name="FontColor">Sets the opfont of the selected/unselected trace items</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerOpacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?MarkerSize: int,
            [<Optional; DefaultParameterValue(null)>] ?FontColor: Color
        ) =
        TraceSelection() 
        |> TraceSelection.style(
            ?MarkerOpacity = MarkerOpacity,
            ?MarkerColor   = MarkerColor,
            ?MarkerSize    = MarkerSize,
            ?FontColor     = FontColor
        )

    /// <summary>
    /// Returns a function that applies the given styles to a TraceSelection object
    /// </summary>
    /// <param name="MarkerOpacity">Sets the opacity of the selected/unselected trace items</param>
    /// <param name="MarkerColor">Sets the color of the selected/unselected trace items</param>
    /// <param name="MarkerSize">Sets the size of the selected/unselected trace items</param>
    /// <param name="FontColor">Sets the opfont of the selected/unselected trace items</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerOpacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?MarkerSize: int,
            [<Optional; DefaultParameterValue(null)>] ?FontColor: Color
        ) =
        (fun (traceSelection: TraceSelection) ->

            let markerSelectionStyle = 
                Marker.init(
                    ?Opacity = MarkerOpacity,
                    ?Color = MarkerColor,
                    ?Size = MarkerSize
                )

            let fontSelectionStyle = Font.init(?Color = FontColor)

            markerSelectionStyle |> DynObj.setValue traceSelection "marker"
            fontSelectionStyle |> DynObj.setValue traceSelection "textfont"

            traceSelection)
