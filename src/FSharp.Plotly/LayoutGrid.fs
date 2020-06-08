namespace FSharp.Plotly

open System

/// A plot grid that can contain subplots with shared axes.
type LayoutGrid () =
    inherit DynamicObj ()

    /// Initializes LayoutGrid object
    ///
    ///
    ///SubPlots    : Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.
    ///
    ///XAxes       : Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.
    ///
    ///YAxes       : Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.
    ///
    ///Rows        : The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.
    ///
    ///Columns     : The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.
    ///
    ///RowOrder    : Is the first row the top or the bottom? Note that columns are always enumerated from left to right.
    ///
    ///Pattern     : If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.
    ///
    ///XGap        : Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.
    ///
    ///YGap        : Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.
    ///
    ///Domain      : Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.
    ///
    ///XSide       : Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.
    ///
    ///YSide       : Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.
    static member init
        (   
            ?SubPlots   : StyleParam.AxisId [] [],
            ?XAxes      : StyleParam.AxisId [],
            ?YAxes      : StyleParam.AxisId [],
            ?Rows       : int,
            ?Columns    : int,
            ?RowOrder   : StyleParam.LayoutGridRowOrder,
            ?Pattern    : StyleParam.LayoutGridPattern,
            ?XGap       : float,
            ?YGap       : float,
            ?Domain     : Domain,
            ?XSide      : StyleParam.LayoutGridXSide,
            ?YSide      : StyleParam.LayoutGridYSide
        ) =
        LayoutGrid () 
        |> LayoutGrid.style
            (
                ?SubPlots    = SubPlots,
                ?XAxes       = XAxes   ,
                ?YAxes       = YAxes   ,
                ?Rows        = Rows    ,
                ?Columns     = Columns ,
                ?RowOrder    = RowOrder,
                ?Pattern     = Pattern ,
                ?XGap        = XGap    ,
                ?YGap        = YGap    ,
                ?Domain      = Domain  ,
                ?XSide       = XSide   ,
                ?YSide       = YSide   

            )

    // Applies the styles to LayoutGrid()
    ///
    ///SubPlots    : Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.
    ///
    ///XAxes       : Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.
    ///
    ///YAxes       : Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.
    ///
    ///Rows        : The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.
    ///
    ///Columns     : The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.
    ///
    ///RowOrder    : Is the first row the top or the bottom? Note that columns are always enumerated from left to right.
    ///
    ///Pattern     : If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.
    ///
    ///XGap        : Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.
    ///
    ///YGap        : Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.
    ///
    ///Domain      : Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.
    ///
    ///XSide       : Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.
    ///
    ///YSide       : Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.
    static member style
        (   
            ?SubPlots   : StyleParam.AxisId [] [],
            ?XAxes      : StyleParam.AxisId [],
            ?YAxes      : StyleParam.AxisId [],
            ?Rows       : int,
            ?Columns    : int,
            ?RowOrder   : StyleParam.LayoutGridRowOrder,
            ?Pattern    : StyleParam.LayoutGridPattern,
            ?XGap       : float,
            ?YGap       : float,
            ?Domain     : Domain,
            ?XSide      : StyleParam.LayoutGridXSide,
            ?YSide      : StyleParam.LayoutGridYSide
        ) =
            (fun (layoutGrid: LayoutGrid) -> 
                SubPlots |> DynObj.setValueOptBy layoutGrid "subplots" (Array.map (Array.map StyleParam.AxisId.toString))
                XAxes    |> DynObj.setValueOptBy layoutGrid "xaxes"    (Array.map StyleParam.AxisId.toString)
                YAxes    |> DynObj.setValueOptBy layoutGrid "yaxes"    (Array.map StyleParam.AxisId.toString)
                Rows     |> DynObj.setValueOpt   layoutGrid "rows"    
                Columns  |> DynObj.setValueOpt   layoutGrid "columns" 
                RowOrder |> DynObj.setValueOptBy layoutGrid "roworder" StyleParam.LayoutGridRowOrder.toString
                Pattern  |> DynObj.setValueOptBy layoutGrid "pattern"  StyleParam.LayoutGridPattern.toString
                XGap     |> DynObj.setValueOpt   layoutGrid "xgap"    
                YGap     |> DynObj.setValueOpt   layoutGrid "ygap"    
                Domain   |> DynObj.setValueOpt   layoutGrid "domain"   
                XSide    |> DynObj.setValueOptBy layoutGrid "xside"   StyleParam.LayoutGridXSide.toString
                YSide    |> DynObj.setValueOptBy layoutGrid "yside"   StyleParam.LayoutGridYSide.toString

                layoutGrid
            )
