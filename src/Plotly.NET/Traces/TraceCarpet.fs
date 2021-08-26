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