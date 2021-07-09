(**
---
title: Basics 
category: General
categoryindex: 1
index: 2
---
*)


(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: PuppeteerSharp"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"
#r "../bin/Plotly.NET.ImageExport/netstandard2.0/Plotly.NET.ImageExport.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.ImageExport, {{fsdocs-package-version}}"
#endif // IPYNB


(**
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

# Static image export

The supported image types are: 
- jpg via `Chart.SaveJPG`
- png via `Chart.SavePNG`
- svg via `Chart.SaveSVG`

The parameters for all three functions are exactly the same. 
*)

open Plotly.NET
open Plotly.NET.ImageExport

let exampleChart = 
    Chart.Histogram2dContour(
        [1.;2.;2.;4.;5.],
        [1.;2.;2.;4.;5.]
    )

(***do-not-eval***)
exampleChart
|> Chart.saveJPG(
    "/your/path/without/extension/here",
    Width=300,
    Height=300
)

#if IPYNB

let imgString = $"""<img
    src= "{exampleChart|> Chart.toBase64JPGString(Width=300,Height=300)}"
/>"""

DisplayExtensions.DisplayAs(imgString,"text/html")

#endif // IPYNB

(***hide***)
$"""<img
    src= "{exampleChart|> Chart.toBase64JPGString(Width=300,Height=300)}"
/>"""

(***include-it-raw***)

(**

*)

let base64JPG =
    exampleChart
    |> Chart.toBase64PNGString(
        Width=300,
        Height=300
    )

#if IPYNB

let imgString = $"""<img
    src= "{base64JPG}"
/>"""

DisplayExtensions.DisplayAs(imgString,"text/html")

#endif // IPYNB

$"""<img
    src= "{base64JPG}"
/>"""
(***include-it-raw***)


(** 
*)

let svgString =
    exampleChart
    |> Chart.toSVGString(
        Width=300,
        Height=300
    )

#if IPYNB
DisplayExtensions.DisplayAs(svgString,"image/svg+xml")
#endif // IPYNB

svgString
(***include-it-raw***)