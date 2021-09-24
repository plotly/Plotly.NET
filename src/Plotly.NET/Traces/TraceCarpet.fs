namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceCarpet(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "carpet" applying the given trace styling function
    static member initCarpet (applyStyle: TraceCarpet -> TraceCarpet) = 
        TraceCarpet("carpet") |> applyStyle

    ///initializes a trace of type "scattercarpet" applying the given trace styling function
    static member initScatterCarpet (applyStyle: TraceCarpet -> TraceCarpet) = 
        TraceCarpet("scattercarpet") |> applyStyle

    ///initializes a trace of type "contourcarpet" applying the given trace styling function
    static member initContourCarpet (applyStyle: TraceCarpet -> TraceCarpet) = 
        TraceCarpet("contourcarpet") |> applyStyle

type TraceCarpetStyle() =

    static member SetCarpet
        (
            [<Optional;DefaultParameterValue(null)>] ?CarpetId:StyleParam.SubPlotId
        ) =  
            (fun (trace:TraceCarpet) ->

                CarpetId |> DynObj.setValueOptBy trace "carpet" StyleParam.SubPlotId.toString

                trace
            )

    static member Carpet 
        (
            [<Optional;DefaultParameterValue(null)>] ?Name              : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible           : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank        : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup       : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle  : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,  
            [<Optional;DefaultParameterValue(null)>] ?Ids               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?MultiX            : seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>] ?Y                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?MultiY            : seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>] ?A                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?A0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DA                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?B                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?B0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DB                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Meta              : string,
            [<Optional;DefaultParameterValue(null)>] ?CustomData        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?AAxis             : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?BAxis             : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?XAxis             : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?YAxis             : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
            [<Optional;DefaultParameterValue(null)>] ?Carpet            : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?CheaterSlope      : float,
            [<Optional;DefaultParameterValue(null)>] ?Font              : Font,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision        : string

        ) =
            fun (trace: #Trace) ->

                Name            |> DynObj.setValueOpt trace "name" 
                Visible         |> DynObj.setValueOptBy trace "visible"  StyleParam.Visible.convert
                ShowLegend      |> DynObj.setValueOpt trace "showlegend" 
                LegendRank      |> DynObj.setValueOpt trace "legendrank" 
                LegendGroup     |> DynObj.setValueOpt trace "opacity" 
                LegendGroupTitle|> DynObj.setValueOpt trace "legendgrouptitle" 
                Opacity         |> DynObj.setValueOpt trace "opacity" 
                Ids             |> DynObj.setValueOpt trace "ids" 
                (X, MultiX)     |> DynObj.setSingleOrAnyOpt trace "x" 
                (Y, MultiY)     |> DynObj.setSingleOrAnyOpt trace "y" 
                A               |> DynObj.setValueOpt trace "a" 
                A0              |> DynObj.setValueOpt trace "a0" 
                DA              |> DynObj.setValueOpt trace "da" 
                B               |> DynObj.setValueOpt trace "b" 
                B0              |> DynObj.setValueOpt trace "b0" 
                DB              |> DynObj.setValueOpt trace "db" 
                Meta            |> DynObj.setValueOpt trace "meta" 
                CustomData      |> DynObj.setValueOpt trace "customdata" 
                AAxis           |> DynObj.setValueOpt trace "aaxis" 
                BAxis           |> DynObj.setValueOpt trace "baxis" 
                XAxis           |> DynObj.setValueOptBy trace "xaxis" StyleParam.SubPlotId.convert
                YAxis           |> DynObj.setValueOptBy trace "yaxis" StyleParam.SubPlotId.convert
                Color           |> DynObj.setValueOpt trace "color" 
                Carpet          |> DynObj.setValueOptBy trace "carpet" StyleParam.SubPlotId.convert
                CheaterSlope    |> DynObj.setValueOpt trace "cheaterslope" 
                Font            |> DynObj.setValueOpt trace "font" 
                UIRevision      |> DynObj.setValueOpt trace "uirevision" 

                trace