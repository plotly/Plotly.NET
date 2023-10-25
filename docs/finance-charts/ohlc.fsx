(**
---
title: OHLC Charts
category: Finance Charts
categoryindex: 8
index: 1
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
# OHLC Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create ohlc charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

open Deedle

let data =
    __SOURCE_DIRECTORY__ + "/../data/finance-charts-apple.csv"
    |> fun csv -> Frame.ReadCsv(csv, true, separators = ",")

let openData: seq<float> = data.["AAPL.Open"] |> Series.values
let highData: seq<float> = data.["AAPL.High"] |> Series.values
let lowData: seq<float> = data.["AAPL.Low"] |> Series.values
let closeData: seq<float> = data.["AAPL.Close"] |> Series.values

let dateData =
    data |> Frame.getCol "Date" |> Series.values |> Seq.map System.DateTime.Parse

(**
An open-high-low-close chart (also OHLC) is a type of chart typically used to illustrate movements in the price of a financial instrument over time. 
Each vertical line on the chart shows the price range (the highest and lowest prices) over one unit of time. 
Tick marks project from each side of the line indicating the opening price (e.g., for a daily bar chart, this would be the starting price for that day) on the left, and the closing price for that time period on the right. 
The bars may be shown in different hues depending on whether prices rose or fell in that period.

You can create an OHLC chart using `Chart.OHLC`:
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let ohlc1 =
    Chart.OHLC(
        ``open`` = (openData |> Seq.take 30),
        high = (highData |> Seq.take 30),
        low = (lowData |> Seq.take 30),
        close = (closeData |> Seq.take 30),
        x = (dateData |> Seq.take 30)
    )

(*** condition: ipynb ***)
#if IPYNB
ohlc1
#endif // IPYNB

(***hide***)
ohlc1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Changing the increasing/decreasing colors
*)

let ohlc2 =
    Chart.OHLC(
        ``open`` = openData,
        high = highData,
        low = lowData,
        close = closeData,
        x = dateData,
        IncreasingColor = Color.fromKeyword Cyan,
        DecreasingColor = Color.fromKeyword Gray
    )

(*** condition: ipynb ***)
#if IPYNB
ohlc2
#endif // IPYNB

(***hide***)
ohlc2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Removing the rangeslider

If you want to hide the rangeslider, set the `ShowXAxisRangeSlider` to false:
*)
open Plotly.NET.LayoutObjects

let ohlc3 =
    Chart.OHLC(
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
ohlc3
#endif // IPYNB

(***hide***)
ohlc3 |> GenericChart.toChartHTML
(***include-it-raw***)
