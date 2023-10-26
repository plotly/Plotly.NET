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
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../data/Deedle.dll"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Candlestick Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create candlestick charts in F#.

Let's first create some data for the purpose of creating example charts:
*)
 
open Deedle
open Plotly.NET
open Plotly.NET.TraceObjects

let data =
    __SOURCE_DIRECTORY__ + "/../data/finance-charts-apple.csv"
    |> fun csv -> Frame.ReadCsv(csv, true, separators = ",")


let openData = data.["AAPL.Open"] |> Series.values |> Array.ofSeq
let highData = data.["AAPL.High"] |> Series.values |> Array.ofSeq
let lowData = data.["AAPL.Low"] |> Series.values |> Array.ofSeq
let closeData = data.["AAPL.Close"] |> Series.values |> Array.ofSeq

let dateData =
    data
    |> Frame.getCol "Date"
    |> Series.values
    |> Seq.map System.DateTime.Parse
    |> Array.ofSeq

let candles =
    [ for i in 0..29 -> dateData.[i], StockData.create openData.[i] highData.[i] lowData.[i] closeData.[i] ]
(**
A candlestick chart is useful for plotting stock prices over time. A candle
is a group of high, open, close and low values over a period of time, e.g. 1 minute, 5 minute, hour, day, etc..
The x-axis is usually datetime values and y is a sequence of candle structures.
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let candles1 =
    Chart.Candlestick(
        ``open`` = (openData |> Seq.take 30),
        high = (highData |> Seq.take 30),
        low = (lowData |> Seq.take 30),
        close = (closeData |> Seq.take 30),
        x = (dateData |> Seq.take 30)
    )

(*** condition: ipynb ***)
#if IPYNB
candles1
#endif // IPYNB

(***hide***)
candles1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Changing the increasing/decreasing colors
*)

let candles2 =
    Chart.Candlestick(
        stockTimeSeries = candles,
        IncreasingColor = Color.fromKeyword Cyan,
        DecreasingColor = Color.fromKeyword Gray
    )

(*** condition: ipynb ***)
#if IPYNB
candles2
#endif // IPYNB

(***hide***)
candles2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Removing the rangeslider

If you want to hide the rangeslider, set the `ShowXAxisRangeSlider` to false:
*)
open Plotly.NET.LayoutObjects

let candles3 =
    Chart.Candlestick(
        ``open`` = openData,
        high = highData,
        low = lowData,
        close = closeData,
        x = dateData,
        IncreasingColor = Color.fromKeyword Cyan,
        DecreasingColor = Color.fromKeyword Gray,
        ShowXAxisRangeSlider = false
    )


(*** condition: ipynb ***)
#if IPYNB
candles3
#endif // IPYNB

(***hide***)
candles3 |> GenericChart.toChartHTML
(***include-it-raw***)
