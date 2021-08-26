namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

/// Dimensions type inherits from dynamic object
type RangeSelector () =
    inherit DynamicObj ()

    static member init
        (
            ?Visible    : bool,
            ?Buttons    : seq<Button>,
            ?X          : float,
            ?XAnchor    : StyleParam.XAnchorPosition,
            ?Y          : float,
            ?YAnchor    : StyleParam.YAnchorPosition,
            ?Font       : Font,
            ?BGColor    : string,
            ?ActiveColor: string,
            ?BorderColor: string,
            ?BorderWidth: int
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
            ?Visible    : bool,
            ?Buttons    : seq<Button>,
            ?X          : float,
            ?XAnchor    : StyleParam.XAnchorPosition,
            ?Y          : float,
            ?YAnchor    : StyleParam.YAnchorPosition,
            ?Font       : Font,
            ?BGColor    : string,
            ?ActiveColor: string,
            ?BorderColor: string,
            ?BorderWidth: int
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