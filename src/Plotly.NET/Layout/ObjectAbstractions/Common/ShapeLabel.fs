namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


///<summary>
///The label of a shape.
///</summary>
type ShapeLabel() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new ShapeLabel object with the given styling.
    /// </summary>
    /// <param name="Font">Sets the shape label text font.</param>
    /// <param name="Padding">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="Text">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextAngle">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextPosition">Sets the position of the label text relative to the shape. Supported values for rectangles, circles and paths are "top left", "top center", "top right", "middle left", "middle center", "middle right", "bottom left", "bottom center", and "bottom right". Supported values for lines are "start", "middle", and "end". Default: "middle center" for rectangles, circles, and paths; "middle" for lines.</param>
    /// <param name="XAnchor">Sets the label's horizontal position anchor This anchor binds the specified `textposition` to the "left", "center" or "right" of the label text. For example, if `textposition` is set to "top right" and `xanchor` to "right" then the right-most portion of the label text lines up with the right-most edge of the shape.</param>
    /// <param name="YAnchor">Sets the label's vertical position anchor This anchor binds the specified `textposition` to the "top", "middle" or "bottom" of the label text. For example, if `textposition` is set to "top right" and `yanchor` to "top" then the top-most portion of the label text lines up with the top-most edge of the shape.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Padding: int,
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: StyleParam.TextAngle,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition
        ) =

        ShapeLabel()
        |> ShapeLabel.style (
            ?Font           = Font,
            ?Padding        = Padding,
            ?Text           = Text,
            ?TextAngle      = TextAngle,
            ?TextPosition   = TextPosition,
            ?XAnchor        = XAnchor,
            ?YAnchor        = YAnchor
        )

    /// <summary>
    /// Returns a function that applies the given styles to a ShapeLabel object
    /// </summary>
    /// <param name="Font">Sets the shape label text font.</param>
    /// <param name="Padding">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="Text">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextAngle">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextPosition">Sets the position of the label text relative to the shape. Supported values for rectangles, circles and paths are "top left", "top center", "top right", "middle left", "middle center", "middle right", "bottom left", "bottom center", and "bottom right". Supported values for lines are "start", "middle", and "end". Default: "middle center" for rectangles, circles, and paths; "middle" for lines.</param>
    /// <param name="XAnchor">Sets the label's horizontal position anchor This anchor binds the specified `textposition` to the "left", "center" or "right" of the label text. For example, if `textposition` is set to "top right" and `xanchor` to "right" then the right-most portion of the label text lines up with the right-most edge of the shape.</param>
    /// <param name="YAnchor">Sets the label's vertical position anchor This anchor binds the specified `textposition` to the "top", "middle" or "bottom" of the label text. For example, if `textposition` is set to "top right" and `yanchor` to "top" then the top-most portion of the label text lines up with the top-most edge of the shape.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Padding: int,
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: StyleParam.TextAngle,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition
        ) =

        (fun (shapeLabel: ShapeLabel) ->
        
            Font |> DynObj.setValueOpt shapeLabel "font" 
            Padding |> DynObj.setValueOpt shapeLabel "padding"
            Text |> DynObj.setValueOpt shapeLabel "text"
            TextAngle |> DynObj.setValueOptBy shapeLabel "textangle" StyleParam.TextAngle.convert
            TextPosition |> DynObj.setValueOptBy shapeLabel "textposition" StyleParam.TextPosition.convert
            XAnchor |> DynObj.setValueOptBy shapeLabel "xanchor" StyleParam.XAnchorPosition.convert
            YAnchor |> DynObj.setValueOptBy shapeLabel "yanchor" StyleParam.YAnchorPosition.convert

            shapeLabel
        )