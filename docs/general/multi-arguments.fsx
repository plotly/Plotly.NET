(**
---
title: Single and multi arguments
category: General
categoryindex: 1
index: 7
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
# Single and multi arguments

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

Plotly.js has many properties that can be either a single value or a collection of values.

In Plotly.NET, this is modelled by 2 arguments in the constructors:

- The "single value version" (e.g. `Opacity`) that sets one value in the target property
- The "multi value version" (e.g. `MultiOpacity`) that sets a collection of values in the target property

**Multi-arguments always have precedence over single arguments, meaning setting both will always set the multi version**

Here is an example for bar charts:

*)
open Plotly.NET

let bar1 =
    Chart.Bar(
        keysValues = [ "first", 1; "second", 2; "third", 3 ],
        MarkerColor =
            Color.fromColors
                [ // one color for each individual bar
                  Color.fromKeyword Salmon
                  Color.fromKeyword SteelBlue
                  Color.fromKeyword Azure ],
        MultiMarkerPatternShape =
            [ // individual pattern shape for each bar
              StyleParam.PatternShape.DiagonalAscending
              StyleParam.PatternShape.Dots
              StyleParam.PatternShape.HorizontalLines ],
        Opacity = 0.75, // opacity for the whole trace
        MultiText =
            [ // individual text associated with each bar
              "first bar"
              "second bar"
              "third bar" ],
        TextPosition = StyleParam.TextPosition.Inside // Textposition for every text item associated with this trace
    )

(*** condition: ipynb ***)
#if IPYNB
bar1
#endif // IPYNB

(***hide***)
bar1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
Here is the exact opposite chart to the above, with single values for multi and vice versa 
*)

let bar2 =
    Chart.Bar(
        keysValues = [ "first", 1; "second", 2; "third", 3 ],
        MarkerColor = Color.fromKeyword Salmon, // one color for every bar
        MarkerPatternShape = StyleParam.PatternShape.DiagonalAscending, // one pattern shape for the whole trace
        MultiOpacity = [ 0.75; 0.5; 0.25 ], //Different opacity for each bar
        Text = "its a bar", // one text item for the whole trace
        MultiTextPosition =
            [ // Textposition for every individual text item associated with this trace
              StyleParam.TextPosition.Outside
              StyleParam.TextPosition.Outside
              StyleParam.TextPosition.Inside ]
    )

(*** condition: ipynb ***)
#if IPYNB
bar2
#endif // IPYNB

(***hide***)
bar2 |> GenericChart.toChartHTML
(***include-it-raw***)
