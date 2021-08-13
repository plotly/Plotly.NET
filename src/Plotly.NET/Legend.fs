namespace Plotly.NET

open DynamicObj

/// Legend 
type Legend() = 
    inherit DynamicObj ()

    /// Init Legend type
    static member init 
        (
            ?BGColor: string,
            ?BorderColor: string,
            ?Borderwidth: float,
            ?Orientation: StyleParam.Orientation,
            ?TraceOrder: StyleParam.TraceOrder,
            ?TraceGroupGap: float,
            ?ItemSizing: StyleParam.TraceItemSizing,
            ?ItemWidth: int,
            ?ItemClick: StyleParam.TraceItemClickOptions,
            ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?VerticalAlign  : StyleParam.VerticalAlign,
            ?Title: string
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
            ?BGColor: string,
            ?BorderColor: string,
            ?Borderwidth: float,
            ?Orientation: StyleParam.Orientation,
            ?TraceOrder: StyleParam.TraceOrder,
            ?TraceGroupGap: float,
            ?ItemSizing: StyleParam.TraceItemSizing,
            ?ItemWidth: int,
            ?ItemClick: StyleParam.TraceItemClickOptions,
            ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?VerticalAlign  : StyleParam.VerticalAlign,
            ?Title: string
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