(**
---
title: Waterfall Charts
category: Finance Charts
categoryindex: 7
index: 6
---
*)
 
(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Waterfall Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create waterfall charts in F#.

Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values.

In addition to the x and y values, a `WaterfallMeasure` can be passed, corresponding to each xy pair (there is also a constructor overload using a tripel of x,y,measure).
By default, the values are considered as 'relative'. However, it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.

*)

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects

let waterfall1 =
    Chart.Waterfall(
        x =
            [ "Sales"
              "Consulting"
              "Net revenue"
              "Purchases"
              "Other expenses"
              "Profit before tax" ],
        y = [ 60; 80; 0; -40; -20; 0 ],
        Measure =
            [ StyleParam.WaterfallMeasure.Relative
              StyleParam.WaterfallMeasure.Relative
              StyleParam.WaterfallMeasure.Total
              StyleParam.WaterfallMeasure.Relative
              StyleParam.WaterfallMeasure.Relative
              StyleParam.WaterfallMeasure.Total ]
    )

(*** condition: ipynb ***)
#if IPYNB
waterfall1
#endif // IPYNB

(***hide***)
waterfall1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Horizontal waterfall charts

Set the orientation argument to `Horizontal` to create a horizontal waterfall. Keep in mind to correctly assign x and y values (the values are switched on the axes in comparison to the chart example above)
To keep better track of which measure belongs to which datum, use 
*)

let waterfall2 =
    Chart.Waterfall(
        xymeasures =
            [ 60, "Sales", StyleParam.WaterfallMeasure.Relative
              80, "Consulting", StyleParam.WaterfallMeasure.Relative
              0, "Net revenue", StyleParam.WaterfallMeasure.Total
              -40, "Purchases", StyleParam.WaterfallMeasure.Relative
              -20, "Other expenses", StyleParam.WaterfallMeasure.Relative
              0, "Profit before tax", StyleParam.WaterfallMeasure.Total ],
        Orientation = StyleParam.Orientation.Horizontal
    )

(*** condition: ipynb ***)
#if IPYNB
waterfall2
#endif // IPYNB

(***hide***)
waterfall2 |> GenericChart.toChartHTML
(***include-it-raw***)
