namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

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
            [<Optional;DefaultParameterValue(null)>] ?Line           : Line,
            [<Optional;DefaultParameterValue(null)>] ?Visible        : bool,
            [<Optional;DefaultParameterValue(null)>] ?ConnectorMode  : StyleParam.ConnectorMode
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
            [<Optional;DefaultParameterValue(null)>] ?Line           : Line,
            [<Optional;DefaultParameterValue(null)>] ?Visible        : bool,
            [<Optional;DefaultParameterValue(null)>] ?ConnectorMode  : StyleParam.ConnectorMode
        ) = 
            (fun (connector:WaterfallConnector) -> 
                
                ++? ("line", Line          )
                ++? ("visible", Visible       )
                ++?? ("mode", ConnectorMode , StyleParam.ConnectorMode.convert)

                connector
            )
