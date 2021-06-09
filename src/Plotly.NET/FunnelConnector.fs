namespace Plotly.NET

/// Styles for connector lines in Funnel Charts.
///
/// Parameters:
///
/// Line          : Sets the Line style for this WaterfallConnector
///
/// Visible       : Wether or not connectors are visible
///
/// ConnectorMode : Sets the shape of connector lines.
type FunnelConnector () =
    inherit DynamicObj ()

    static member init 
        (
            ?Fillcolor      : string,
            ?Line           : Line,
            ?Visible        : bool
        ) = 

        FunnelConnector() 
        |> FunnelConnector.style 
            (
                ?Fillcolor     = Fillcolor,
                ?Line          = Line     ,
                ?Visible       = Visible
            )

    static member style 
        (
            ?Fillcolor            ,
            ?Line           : Line,
            ?Visible        : bool
        ) = 
            (fun (connector:FunnelConnector) -> 
                
                Fillcolor     |> DynObj.setValueOpt connector "fillcolor"
                Line          |> DynObj.setValueOpt connector "line"
                Visible       |> DynObj.setValueOpt connector "visible"

                connector
            )
