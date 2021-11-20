(**
---
title: single and sulti arguments
category: General
categoryindex: 1
index: 7
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
# Single and sulti arguments

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

Plotly.js has many properties that can be either a single value or a collection of values.

In Plotly.NET, this is modelled by 2 arguments in the constructors:

- The "single value version" (e.g. `Opacity`) that sets one value in the target property
- The "multi value version" (e.g. `MultiOpacity`) that sets a collection of values in the target property

**Multi-arguments always have precedent over single arguments, meaning setting both will always set the multi version**

Here is an example for bar charts:

*)
open Plotly.NET

let bar =
    Chart.Bar(
        [
            "first", 1
            "second", 2
            "third", 3
        ],
        MultiMarkerPatternShape = [ // individual pattern shape for each bar
            StyleParam.PatternShape.DiagonalAscending
            StyleParam.PatternShape.Dots
            StyleParam.PatternShape.HorizontalLines
        ],
        Opacity = 0.75, // opacity for the whole trace
        MultiText = [ // individual text associated with each bar
            "first bar"
            "second bar"
            "third bar"
        ],
        TextPosition = StyleParam.TextPosition.Outside // Textposition for every text item associated with this trace
    )

(*** condition: ipynb ***)
#if IPYNB
bar
#endif // IPYNB

(***hide***)
bar |> GenericChart.toChartHTML
(***include-it-raw***)
