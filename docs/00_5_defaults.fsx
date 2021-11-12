(**
---
title: Global default values
category: General
categoryindex: 1
index: 6
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
# Global default values

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

Plotly.NET provides mutable global default values in the `Defaults` module.

These values are always used in Chart generation. The default values are:

|Value name|Value|
|---|---|
| DefaultWidth | `600` |
| DefaultHeight | `600` |
| DefaultConfig | `Config.init(Responsive = true)` |
| DefaultDisplayOptions | `DisplayOptions.init()` |
| DefaultTemplate | `ChartTemplates.plotly` |

## Changing default values

The following code replaces the default template from the global defaults:
*)
open Plotly.NET

let before = Chart.Point([1,2])

(*** condition: ipynb ***)
#if IPYNB
before
#endif // IPYNB

(***hide***)
before |> GenericChart.toChartHTML
(***include-it-raw***)

Defaults.DefaultTemplate <- ChartTemplates.lightMirrored

let after = Chart.Point([1,2])

(*** condition: ipynb ***)
#if IPYNB
after
#endif // IPYNB

(***hide***)
after |> GenericChart.toChartHTML
(***include-it-raw***)

(**
To use the default template again:
*)

Defaults.DefaultTemplate <- ChartTemplates.plotly

(**
## Ignoring global defaults

All Chart functions have a `UseDefaults` argument, which when set to `false` will ignore all global defaults:
*)


let noDefaults = Chart.Point([1,2], UseDefaults = false)

(*** condition: ipynb ***)
#if IPYNB
noDefaults
#endif // IPYNB

(***hide***)
noDefaults |> GenericChart.toChartHTML
(***include-it-raw***)