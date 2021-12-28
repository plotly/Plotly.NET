namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// Legend
type Legend() =
    inherit ImmutableDynamicObj()

    /// Init Legend type
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Borderwidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?TraceOrder: StyleParam.TraceOrder,
            [<Optional; DefaultParameterValue(null)>] ?TraceGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?ItemSizing: StyleParam.TraceItemSizing,
            [<Optional; DefaultParameterValue(null)>] ?ItemWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?ItemClick: StyleParam.TraceItemClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?VerticalAlign: StyleParam.VerticalAlign,
            [<Optional; DefaultParameterValue(null)>] ?Title: string
        ) =
        Legend()
        |> Legend.style (
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?Borderwidth = Borderwidth,
            ?TraceGroupGap = TraceGroupGap,
            ?ItemWidth = ItemWidth,
            ?X = X,
            ?Y = Y,
            ?Title = Title,
            ?Orientation = Orientation,
            ?TraceOrder = TraceOrder,
            ?ItemSizing = ItemSizing,
            ?ItemClick = ItemClick,
            ?ItemDoubleClick = ItemDoubleClick,
            ?XAnchor = XAnchor,
            ?YAnchor = YAnchor,
            ?VerticalAlign = VerticalAlign
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Borderwidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?TraceOrder: StyleParam.TraceOrder,
            [<Optional; DefaultParameterValue(null)>] ?TraceGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?ItemSizing: StyleParam.TraceItemSizing,
            [<Optional; DefaultParameterValue(null)>] ?ItemWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?ItemClick: StyleParam.TraceItemClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?VerticalAlign: StyleParam.VerticalAlign,
            [<Optional; DefaultParameterValue(null)>] ?Title: string
        ) =
        (fun (legend: Legend) ->

            legend
            ++? ("bgcolor", BGColor )
            ++? ("bordercolor", BorderColor )
            ++? ("borderwidth", Borderwidth )
            ++? ("tracegroupgap", TraceGroupGap )
            ++? ("itemwidth", ItemWidth )
            ++? ("x", X )
            ++? ("y", Y )
            ++? ("Title", Title )

            ++?? ("orientation", Orientation , StyleParam.Orientation.convert)
            ++?? ("traceorder", TraceOrder , StyleParam.TraceOrder.convert)
            ++?? ("itemsizing", ItemSizing , StyleParam.TraceItemSizing.convert)
            ++?? ("itemclick", ItemClick , StyleParam.TraceItemClickOptions.convert)
            ++?? ("itemdoubleclick", ItemDoubleClick , StyleParam.TraceItemClickOptions.convert)
            ++?? ("yanchor", XAnchor , StyleParam.XAnchorPosition.convert)
            ++?? ("yanchor", YAnchor , StyleParam.YAnchorPosition.convert)
            ++?? ("valign", VerticalAlign , StyleParam.VerticalAlign.convert))
