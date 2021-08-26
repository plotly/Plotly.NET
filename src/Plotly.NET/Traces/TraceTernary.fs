namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System

type TraceTernary(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scatterternary" applying the given trace styling function
    static member initScatterTernary (applyStyle:TraceTernary -> TraceTernary) = 
        TraceTernary("scatterternary") |> applyStyle