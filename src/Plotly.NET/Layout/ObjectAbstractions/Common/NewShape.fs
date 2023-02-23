namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type NewShape() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new NewShape object with the given styling.
    /// </summary>
    ///<param name="DrawDirection">When `dragmode` is set to "drawrect", "drawline" or "drawcircle" this limits the drag to be horizontal, vertical or diagonal. Using "diagonal" there is no limit e.g. in drawing lines in any direction. "ortho" limits the draw to be either horizontal or vertical. "horizontal" allows horizontal extend. "vertical" allows vertical extend.</param>
    ///<param name="FillColor">Sets the color filling new shapes' interior. Please note that if using a fillcolor with alpha greater than half, drag inside the active shape starts moving the shape underneath, otherwise a new shape could be started over.</param>
    ///<param name="FillRule">Determines the path's interior. For more info please visit https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule</param>
    ///<param name="Layer">Specifies whether new shapes are drawn below or above traces.</param>
    ///<param name="Line">Sets the outline of new shapes.</param>
    ///<param name="Opacity">Sets the opacity of new shapes.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?DrawDirection: StyleParam.DrawDirection,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillRule: StyleParam.FillRule,
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float

        ) =
        NewShape()
        |> NewShape.style (
            ?DrawDirection = DrawDirection,
            ?FillColor = FillColor,
            ?FillRule = FillRule,
            ?Layer = Layer,
            ?Line = Line,
            ?Opacity = Opacity
        )

    /// <summary>
    /// Returns a function that applies the given styles to a NewShape object
    /// </summary>
    ///<param name="DrawDirection">When `dragmode` is set to "drawrect", "drawline" or "drawcircle" this limits the drag to be horizontal, vertical or diagonal. Using "diagonal" there is no limit e.g. in drawing lines in any direction. "ortho" limits the draw to be either horizontal or vertical. "horizontal" allows horizontal extend. "vertical" allows vertical extend.</param>
    ///<param name="FillColor">Sets the color filling new shapes' interior. Please note that if using a fillcolor with alpha greater than half, drag inside the active shape starts moving the shape underneath, otherwise a new shape could be started over.</param>
    ///<param name="FillRule">Determines the path's interior. For more info please visit https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule</param>
    ///<param name="Layer">Specifies whether new shapes are drawn below or above traces.</param>
    ///<param name="Line">Sets the outline of new shapes.</param>
    ///<param name="Opacity">Sets the opacity of new shapes.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?DrawDirection: StyleParam.DrawDirection,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillRule: StyleParam.FillRule,
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =
        (fun (newShape: NewShape) ->

            DrawDirection |> DynObj.setValueOptBy newShape "drawdirection" StyleParam.DrawDirection.convert
            FillColor |> DynObj.setValueOpt newShape "fillcolor"
            FillRule |> DynObj.setValueOptBy newShape "fillrule" StyleParam.FillRule.convert
            Layer |> DynObj.setValueOptBy newShape "layer" StyleParam.Layer.convert
            Line |> DynObj.setValueOpt newShape "line"
            Opacity |> DynObj.setValueOpt newShape "opacity"

            newShape)
