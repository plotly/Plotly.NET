namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Styles for connector lines in Funnel Charts.
///
/// Parameters:
///
/// Line          : Sets the Line style for this WaterfallConnector
///
/// Visible       : Whether or not connectors are visible
///
/// ConnectorMode : Sets the shape of connector lines.
type FunnelConnector() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =

        FunnelConnector() |> FunnelConnector.style (?FillColor = FillColor, ?Line = Line, ?Visible = Visible)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        (fun (connector: FunnelConnector) ->

            FillColor |> DynObj.setValueOpt connector "fillcolor"
            Line |> DynObj.setValueOpt connector "line"
            Visible |> DynObj.setValueOpt connector "visible"

            connector)
