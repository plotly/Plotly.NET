namespace FSharp.Plotly

open Trace
open System
open System.Runtime.InteropServices

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

    type TraceStyle with
        [<CompiledName("Candlestick")>]
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
        [<CompiledName("Candlestick")>]
        static member Candlestick
            (
                data            : (#IConvertible*Candle) seq,
                [<Optional;DefaultParameterValue(null)>] ?increasing     : Line,
                [<Optional;DefaultParameterValue(null)>] ?decreasing     : Line,
                [<Optional;DefaultParameterValue(null)>] ?line           : Line
            ) =
            Trace.initCandlestick(TraceStyle.Candlestick
                (
                    data, 
                    ?increasing=increasing, 
                    ?decreasing=decreasing,
                    ?line=line
                ))
            |> GenericChart.ofTraceObject

        [<Obsolete("Function Name has a typo and will be removed in 2.0. use Chart.Candlestick")>]
        [<CompiledName("Candelstick")>]
        static member Candelstick
            (
                data            : (#IConvertible*Candle) seq,
                [<Optional;DefaultParameterValue(null)>] ?increasing     : Line,
                [<Optional;DefaultParameterValue(null)>] ?decreasing     : Line,
                [<Optional;DefaultParameterValue(null)>] ?line           : Line
            ) =
            Trace.initCandlestick(TraceStyle.Candlestick
                (
                    data, 
                    ?increasing=increasing, 
                    ?decreasing=decreasing,
                    ?line=line
                ))
            |> GenericChart.ofTraceObject
