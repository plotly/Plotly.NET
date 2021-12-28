namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

[<RequireQualifiedAccess>]
type TraceID =
    | Cartesian2D
    | Cartesian3D
    | Polar
    | Geo
    | Mapbox
    | Ternary
    | Carpet
    | Domain
    | Multi

    static member ofTrace(t: Trace) : TraceID =
        match t with
        | :? Trace2D -> TraceID.Cartesian2D
        | :? Trace3D -> TraceID.Cartesian3D
        | :? TracePolar -> TraceID.Polar
        | :? TraceGeo -> TraceID.Geo
        | :? TraceMapbox -> TraceID.Mapbox
        | :? TraceTernary -> TraceID.Ternary
        | :? TraceCarpet -> TraceID.Carpet
        | :? TraceDomain -> TraceID.Domain
        | unknownTraceType -> failwith $"cannot get trace id for type {unknownTraceType.GetType()}"

    static member ofTraces(t: seq<Trace>) : TraceID =
        let traceIds =
            t |> Seq.map TraceID.ofTrace |> Seq.distinct |> Array.ofSeq

        match traceIds with
        | [| sameTraceID |] -> sameTraceID
        | [||] -> TraceID.Domain
        | _ -> TraceID.Multi
