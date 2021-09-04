namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


/// Dimensions type inherits from dynamic object
type RangeSelector () =
    inherit DynamicObj ()

    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible    : bool,
            [<Optional;DefaultParameterValue(null)>] ?Buttons    : seq<Button>,
            [<Optional;DefaultParameterValue(null)>] ?X          : float,
            [<Optional;DefaultParameterValue(null)>] ?XAnchor    : StyleParam.XAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?Y          : float,
            [<Optional;DefaultParameterValue(null)>] ?YAnchor    : StyleParam.YAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?Font       : Font,
            [<Optional;DefaultParameterValue(null)>] ?BGColor    : Color,
            [<Optional;DefaultParameterValue(null)>] ?ActiveColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderWidth: int
        ) =
            RangeSelector () 
            |> RangeSelector.style
                (
                    ?Visible     = Visible    ,
                    ?Buttons     = Buttons    ,
                    ?X           = X          ,
                    ?XAnchor     = XAnchor    ,
                    ?Y           = Y          ,
                    ?YAnchor     = YAnchor    ,
                    ?Font        = Font       ,
                    ?BGColor     = BGColor    ,
                    ?ActiveColor = ActiveColor,
                    ?BorderColor = BorderColor,
                    ?BorderWidth = BorderWidth
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible    : bool,
            [<Optional;DefaultParameterValue(null)>] ?Buttons    : seq<Button>,
            [<Optional;DefaultParameterValue(null)>] ?X          : float,
            [<Optional;DefaultParameterValue(null)>] ?XAnchor    : StyleParam.XAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?Y          : float,
            [<Optional;DefaultParameterValue(null)>] ?YAnchor    : StyleParam.YAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?Font       : Font,
            [<Optional;DefaultParameterValue(null)>] ?BGColor    : Color,
            [<Optional;DefaultParameterValue(null)>] ?ActiveColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderWidth: int
        ) =
            (fun (rangeSelector:RangeSelector) -> 

                Visible     |> DynObj.setValueOpt rangeSelector "visible"
                Buttons     |> DynObj.setValueOpt rangeSelector "buttons"
                X           |> DynObj.setValueOpt rangeSelector "x"
                XAnchor     |> DynObj.setValueOptBy rangeSelector "xanchor" StyleParam.XAnchorPosition.convert
                Y           |> DynObj.setValueOpt rangeSelector "y"
                YAnchor     |> DynObj.setValueOptBy rangeSelector "yanchor" StyleParam.YAnchorPosition.convert
                Font        |> DynObj.setValueOpt rangeSelector "font"
                BGColor     |> DynObj.setValueOpt rangeSelector "bgcolor"
                ActiveColor |> DynObj.setValueOpt rangeSelector "activecolor"
                BorderColor |> DynObj.setValueOpt rangeSelector "bordercolor"
                BorderWidth |> DynObj.setValueOpt rangeSelector "borderwidth"

                rangeSelector
            )