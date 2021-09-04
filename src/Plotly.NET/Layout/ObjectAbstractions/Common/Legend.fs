namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Legend 
type Legend() = 
    inherit DynamicObj ()

    /// Init Legend type
    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?Borderwidth: float,
            [<Optional;DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional;DefaultParameterValue(null)>] ?TraceOrder: StyleParam.TraceOrder,
            [<Optional;DefaultParameterValue(null)>] ?TraceGroupGap: float,
            [<Optional;DefaultParameterValue(null)>] ?ItemSizing: StyleParam.TraceItemSizing,
            [<Optional;DefaultParameterValue(null)>] ?ItemWidth: int,
            [<Optional;DefaultParameterValue(null)>] ?ItemClick: StyleParam.TraceItemClickOptions,
            [<Optional;DefaultParameterValue(null)>] ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            [<Optional;DefaultParameterValue(null)>] ?X: float,
            [<Optional;DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?Y: float,
            [<Optional;DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?VerticalAlign  : StyleParam.VerticalAlign,
            [<Optional;DefaultParameterValue(null)>] ?Title: string
        ) =
            Legend()
            |> Legend.style(
                ?BGColor         = BGColor        ,
                ?BorderColor     = BorderColor    ,
                ?Borderwidth     = Borderwidth    ,
                ?TraceGroupGap   = TraceGroupGap  ,
                ?ItemWidth       = ItemWidth      ,
                ?X               = X              ,
                ?Y               = Y              ,
                ?Title           = Title          ,
                ?Orientation     = Orientation    ,
                ?TraceOrder      = TraceOrder     ,
                ?ItemSizing      = ItemSizing     ,
                ?ItemClick       = ItemClick      ,
                ?ItemDoubleClick = ItemDoubleClick,
                ?XAnchor         = XAnchor        ,
                ?YAnchor         = YAnchor        ,
                ?VerticalAlign   = VerticalAlign  
            )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?Borderwidth: float,
            [<Optional;DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional;DefaultParameterValue(null)>] ?TraceOrder: StyleParam.TraceOrder,
            [<Optional;DefaultParameterValue(null)>] ?TraceGroupGap: float,
            [<Optional;DefaultParameterValue(null)>] ?ItemSizing: StyleParam.TraceItemSizing,
            [<Optional;DefaultParameterValue(null)>] ?ItemWidth: int,
            [<Optional;DefaultParameterValue(null)>] ?ItemClick: StyleParam.TraceItemClickOptions,
            [<Optional;DefaultParameterValue(null)>] ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            [<Optional;DefaultParameterValue(null)>] ?X: float,
            [<Optional;DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?Y: float,
            [<Optional;DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional;DefaultParameterValue(null)>] ?VerticalAlign  : StyleParam.VerticalAlign,
            [<Optional;DefaultParameterValue(null)>] ?Title: string
        ) =
            (fun (legend:Legend) -> 
                BGColor         |> DynObj.setValueOpt legend "bgcolor"
                BorderColor     |> DynObj.setValueOpt legend "bordercolor"
                Borderwidth     |> DynObj.setValueOpt legend "borderwidth"
                TraceGroupGap   |> DynObj.setValueOpt legend "tracegroupgap"
                ItemWidth       |> DynObj.setValueOpt legend "itemwidth"
                X               |> DynObj.setValueOpt legend "x"
                Y               |> DynObj.setValueOpt legend "y"
                Title           |> DynObj.setValueOpt legend "Title"

                Orientation     |> DynObj.setValueOptBy legend "orientation"        StyleParam.Orientation.convert
                TraceOrder      |> DynObj.setValueOptBy legend "traceorder"         StyleParam.TraceOrder.convert
                ItemSizing      |> DynObj.setValueOptBy legend "itemsizing"         StyleParam.TraceItemSizing.convert
                ItemClick       |> DynObj.setValueOptBy legend "itemclick"          StyleParam.TraceItemClickOptions.convert
                ItemDoubleClick |> DynObj.setValueOptBy legend "itemdoubleclick"    StyleParam.TraceItemClickOptions.convert
                XAnchor         |> DynObj.setValueOptBy legend "yanchor"            StyleParam.XAnchorPosition.convert
                YAnchor         |> DynObj.setValueOptBy legend "yanchor"            StyleParam.YAnchorPosition.convert
                VerticalAlign   |> DynObj.setValueOptBy legend "valign"             StyleParam.VerticalAlign.convert

                legend
            )