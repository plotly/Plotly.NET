namespace Plotly.NET.ConfigObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// The Edits object holds information about which elements of the chart are editable.
type Edits() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Edits Object with the given styling.
    /// </summary>
    /// <param name="AnnotationPosition">Determines if the main anchor of the annotation is editable. The main anchor corresponds to the text (if no arrow) or the arrow (which drags the whole thing leaving the arrow length and direction unchanged).</param>
    /// <param name="AnnotationTail">Has only an effect for annotations with arrows. Enables changing the length and direction of the arrow.</param>
    /// <param name="AnnotationText">Enables editing annotation text.</param>
    /// <param name="AxisTitleText">Enables editing axis title text.</param>
    /// <param name="ColorbarPosition">Enables moving colorbars.</param>
    /// <param name="ColorbarTitleText">Enables moving colorbars.</param>
    /// <param name="LegendPosition">Enables moving colorbars.</param>
    /// <param name="LegendText">Enables editing the trace name fields from the legend</param>
    /// <param name="ShapePosition">Enables editing the trace name fields from the legend</param>
    /// <param name="TitleText">Enables editing the global layout title.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?AnnotationPosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?AnnotationTail: bool,
            [<Optional; DefaultParameterValue(null)>] ?AnnotationText: bool,
            [<Optional; DefaultParameterValue(null)>] ?AxisTitleText: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorbarPosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorbarTitleText: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendPosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendText: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShapePosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?TitleText: bool
        ) =
        Edits()
        |> Edits.style (
            ?AnnotationPosition = AnnotationPosition,
            ?AnnotationTail = AnnotationTail,
            ?AnnotationText = AnnotationText,
            ?AxisTitleText = AxisTitleText,
            ?ColorbarPosition = ColorbarPosition,
            ?ColorbarTitleText = ColorbarTitleText,
            ?LegendPosition = LegendPosition,
            ?LegendText = LegendText,
            ?ShapePosition = ShapePosition,
            ?TitleText = TitleText

        )

    /// <summary>
    /// Returns a function that apllioes the given styles to an Edits Object.
    /// </summary>
    /// <param name="AnnotationPosition">Determines if the main anchor of the annotation is editable. The main anchor corresponds to the text (if no arrow) or the arrow (which drags the whole thing leaving the arrow length and direction unchanged).</param>
    /// <param name="AnnotationTail">Has only an effect for annotations with arrows. Enables changing the length and direction of the arrow.</param>
    /// <param name="AnnotationText">Enables editing annotation text.</param>
    /// <param name="AxisTitleText">Enables editing axis title text.</param>
    /// <param name="ColorbarPosition">Enables moving colorbars.</param>
    /// <param name="ColorbarTitleText">Enables moving colorbars.</param>
    /// <param name="LegendPosition">Enables moving colorbars.</param>
    /// <param name="LegendText">Enables editing the trace name fields from the legend</param>
    /// <param name="ShapePosition">Enables editing the trace name fields from the legend</param>
    /// <param name="TitleText">Enables editing the global layout title.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?AnnotationPosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?AnnotationTail: bool,
            [<Optional; DefaultParameterValue(null)>] ?AnnotationText: bool,
            [<Optional; DefaultParameterValue(null)>] ?AxisTitleText: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorbarPosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorbarTitleText: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendPosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendText: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShapePosition: bool,
            [<Optional; DefaultParameterValue(null)>] ?TitleText: bool
        ) =
        fun (edits: Edits) ->
            AnnotationPosition |> DynObj.setValueOpt edits "annotationPosition"
            AnnotationTail |> DynObj.setValueOpt edits "annotationTail"
            AnnotationText |> DynObj.setValueOpt edits "annotationText"
            AxisTitleText |> DynObj.setValueOpt edits "axisTitleText"
            ColorbarPosition |> DynObj.setValueOpt edits "colorbarPosition"
            ColorbarTitleText |> DynObj.setValueOpt edits "colorbarTitleText"
            LegendPosition |> DynObj.setValueOpt edits "legendPosition"
            LegendText |> DynObj.setValueOpt edits "legendText"
            ShapePosition |> DynObj.setValueOpt edits "shapePosition"
            TitleText |> DynObj.setValueOpt edits "titleText"

            edits
