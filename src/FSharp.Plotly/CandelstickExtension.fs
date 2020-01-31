namespace FSharp.Plotly

open Trace
open System

type Candle = 
    {
        High           : float
        Low            : float
        Close          : float
        Open           : float
    }
    with
    static member Create(o,h,l,c) = 
        {
            High           = h
            Low            = l
            Close          = c
            Open           = o
        }

[<AutoOpen>]
module CandelstickExtension =

    module Trace =
        let initCandelstick (applyStyle:Trace->Trace) = 
            FSharp.Plotly.Trace("candlestick") |> applyStyle


    type TraceStyle with
        static member Candlestick
            (
                data            : (#IConvertible*Candle) seq,
                ?increasing     : Line,
                ?decreasing     : Line,
                ?line           : Line
            ) =
            (fun (trace:('T :> Trace)) ->
                DynObj.setValue trace "open"  (data |> Seq.map snd |> Seq.map(fun x->x.Open))
                DynObj.setValue trace "high"  (data |> Seq.map snd |> Seq.map(fun x->x.High))
                DynObj.setValue trace "low"   (data |> Seq.map snd |> Seq.map(fun x->x.Low))
                DynObj.setValue trace "close" (data |> Seq.map snd |> Seq.map(fun x->x.Close))
                DynObj.setValue trace "x" (data |> Seq.map fst)
                DynObj.setValue trace "xaxis" "x"
                DynObj.setValue trace "yaxis" "y"
                DynObj.setValueOpt trace "line" line
                DynObj.setValueOpt trace "increasing" increasing
                DynObj.setValueOpt trace "decreasing" decreasing
                trace
            )

    type Chart with
        static member Candelstick
            (
                data            : (#IConvertible*Candle) seq,
                ?increasing     : Line,
                ?decreasing     : Line,
                ?line           : Line
            ) =
            Trace.initCandelstick(TraceStyle.Candlestick
                (
                    data, 
                    ?increasing=increasing, 
                    ?decreasing=decreasing,
                    ?line=line
                ))
            |> GenericChart.ofTraceObject
