namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices


/// Dimensions type inherits from dynamic object
type RangeSelector() =
    inherit ImmutableDynamicObj()

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

            rangeSelector

            ++? ("visible", Visible )
            ++? ("buttons", Buttons )
            ++? ("x", X )
            ++?? ("xanchor", XAnchor , StyleParam.XAnchorPosition.convert)
            ++? ("y", Y )
            ++?? ("yanchor", YAnchor , StyleParam.YAnchorPosition.convert)
            ++? ("font", Font )
            ++? ("bgcolor", BGColor )
            ++? ("activecolor", ActiveColor )
            ++? ("bordercolor", BorderColor )
            ++? ("borderwidth", BorderWidth ))
