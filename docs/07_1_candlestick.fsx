

(**
---
title: Candlestick Charts
category: Finance Charts
categoryindex: 8
index: 2
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Candlestick Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create candlestick charts in F#.

let's first create some data for the purpose of creating example charts:
*)

#r "nuget: FSharp.Data"
#r "nuget: Deedle"

open FSharp.Data
open Deedle

open Plotly.NET
open Plotly.NET.TraceObjects

let data = 
    Http.RequestString @"https://raw.githubusercontent.com/plotly/datasets/master/finance-charts-apple.csv"
    |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

let openData = data.["AAPL.Open"] |> Series.values |> Array.ofSeq
let highData = data.["AAPL.High"] |> Series.values |> Array.ofSeq
let lowData = data.["AAPL.Low"] |> Series.values |> Array.ofSeq
let closeData = data.["AAPL.Close"] |> Series.values |> Array.ofSeq
let dateData = data |> Frame.getCol "Date" |> Series.values |> Seq.map System.DateTime.Parse |> Array.ofSeq
 
let candles = [for i in 0 .. 29 -> dateData.[i], StockData.create openData.[i] highData.[i] lowData.[i] closeData.[i]]
(**
A candlestick chart is useful for plotting stock prices over time. A candle
is a group of high, open, close and low values over a period of time, e.g. 1 minute, 5 minute, hour, day, etc..
The x-axis is usually dateime values and y is a sequence of candle structures.
*)

let candles1 = Chart.Candlestick candles

(*** condition: ipynb ***)
#if IPYNB
candles1
#endif // IPYNB

(***hide***)
candles1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
If you want to hide the rangeslider, use `withXAxisRangeSlider` and hide it:
*)

open Plotly.NET.LayoutObjects

let rangeslider = RangeSlider.init(Visible=false)

let candles2 = 
    Chart.Candlestick candles
    |> Chart.withXAxisRangeSlider rangeslider

(*** condition: ipynb ***)
#if IPYNB
candles2
#endif // IPYNB

(***hide***)
candles2 |> GenericChart.toChartHTML
(***include-it-raw***)

