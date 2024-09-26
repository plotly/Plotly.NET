namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


/// Dimensions type inherits from dynamic object
type RangeSelector() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Buttons: seq<Button>,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ActiveColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: int
        ) =
        RangeSelector()
        |> RangeSelector.style (
            ?Visible = Visible,
            ?Buttons = Buttons,
            ?X = X,
            ?XAnchor = XAnchor,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?Font = Font,
            ?BGColor = BGColor,
            ?ActiveColor = ActiveColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Buttons: seq<Button>,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ActiveColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: int
        ) =
        (fun (rangeSelector: RangeSelector) ->

            Visible |> DynObj.setOptionalProperty rangeSelector "visible"
            Buttons |> DynObj.setOptionalProperty rangeSelector "buttons"
            X |> DynObj.setOptionalProperty rangeSelector "x"
            XAnchor |> DynObj.setOptionalPropertyBy rangeSelector "xanchor" StyleParam.XAnchorPosition.convert
            Y |> DynObj.setOptionalProperty rangeSelector "y"
            YAnchor |> DynObj.setOptionalPropertyBy rangeSelector "yanchor" StyleParam.YAnchorPosition.convert
            Font |> DynObj.setOptionalProperty rangeSelector "font"
            BGColor |> DynObj.setOptionalProperty rangeSelector "bgcolor"
            ActiveColor |> DynObj.setOptionalProperty rangeSelector "activecolor"
            BorderColor |> DynObj.setOptionalProperty rangeSelector "bordercolor"
            BorderWidth |> DynObj.setOptionalProperty rangeSelector "borderwidth"

            rangeSelector)
