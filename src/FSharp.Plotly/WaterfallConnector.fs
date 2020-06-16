namespace FSharp.Plotly

/// Styles for connector lines in Waterfall Charts.
///
/// Parameters:
///
/// Line          : Sets the Line style for this WaterfallConnector
///
/// Visible       : Wether or not connectors are visible
///
/// ConnectorMode : Sets the shape of connector lines.
type WaterfallConnector () =
    inherit DynamicObj ()

    static member init 
        (
            ?Line           : Line,
            ?Visible        : bool,
            ?ConnectorMode  : StyleParam.ConnectorMode
        ) = 

        WaterfallConnector() 
        |> WaterfallConnector.style 
            (
                ?Line          = Line         ,
                ?Visible       = Visible      ,
                ?ConnectorMode = ConnectorMode
            )

    static member style 
        (
            ?Line           : Line,
            ?Visible        : bool,
            ?ConnectorMode  : StyleParam.ConnectorMode
        ) = 
            (fun (connector:WaterfallConnector) -> 
                
                Line          |> DynObj.setValueOpt   connector "line"
                Visible       |> DynObj.setValueOpt   connector "visible"
                ConnectorMode |> DynObj.setValueOptBy connector "mode" StyleParam.ConnectorMode.convert

                connector
            )
