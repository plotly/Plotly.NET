namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceTernary(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scatterternary" applying the given trace styling function
    static member initScatterTernary (applyStyle:TraceTernary -> TraceTernary) = 
        TraceTernary("scatterternary") |> applyStyle

type TraceTernaryStyle() =

    static member SetTernary
        (
            [<Optional;DefaultParameterValue(null)>] ?TernaryId:StyleParam.SubPlotId
        ) =  
            (fun (trace:TraceTernary) ->

                trace

                ++?? ("subplot", TernaryId, StyleParam.SubPlotId.toString)
            )