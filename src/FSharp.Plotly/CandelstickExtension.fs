namespace FSharp.Plotly

open Trace
open System
open System.Runtime.InteropServices

[<Obsolete("this type will be removed in favor of the 'StockData' type in 2.0.")>]
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

    type Chart with
        [<Obsolete("Function Name has a typo and will be removed in 2.0. use Chart.Candlestick")>]
        [<CompiledName("Candelstick")>]
        static member Candelstick
            (
                data            : (#IConvertible*Candle) seq,
                [<Optional;DefaultParameterValue(null)>] ?increasing     : Line,
                [<Optional;DefaultParameterValue(null)>] ?decreasing     : Line,
                [<Optional;DefaultParameterValue(null)>] ?line           : Line
            ) =
            Trace.initCandlestick(
                TraceStyle.Candlestick(
                    ``open``        = (data |> Seq.map (snd >> (fun x -> x.Open)))    ,
                    high            = (data |> Seq.map (snd >> (fun x -> x.High)))        ,
                    low             = (data |> Seq.map (snd >> (fun x -> x.Low)))         ,
                    close           = (data |> Seq.map (snd >> (fun x -> x.Close)))       ,
                    x               = (data |> Seq.map fst)            ,
                    ?Increasing     = increasing  ,
                    ?Decreasing     = decreasing  ,
                    ?Line           = line        
                )
            )
            |> GenericChart.ofTraceObject
