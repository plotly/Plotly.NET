(**
---
title: Static image export
category: General
categoryindex: 1
index: 2
---
*)


(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "nuget: PuppeteerSharp, 9.0.2"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"
#r "../../src/Plotly.NET.ImageExport/bin/Release/netstandard2.0/Plotly.NET.ImageExport.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.ImageExport, {{fsdocs-package-version}}"
#endif // IPYNB


(**
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

# Static image export

### Table of contents

- [Saving static images](#Saving-static-images)
- [Generating URIs for static chart images](#Generating-URIs-for-static-chart-images)

As Plotly.NET generates static html pages that contain charts rendered by plotly.js, static image export needs a lot more overhead under the hood 
than you might expect. The underlying renderer needs to execute javascript, leading to the usage of headless browsers.

The package `Plotly.NET.ImageExport` contains extensions for Plotly.NET to render static images. It is designed with extensibility in mind and
it is very easy to add a new rendering engine. The current engines are provided:

| Rendering engine | Type | Prerequisites |
|-|-|-|
| [PuppeteerSharp](https://github.com/hardkoded/puppeteer-sharp) | headless browser | [read more here](https://github.com/hardkoded/puppeteer-sharp#prerequisites) |

## Saving static images

By referencing the `Plotly.NET.ImageExport` package, you get access to:

 - jpg via `Chart.SaveJPG`
 - png via `Chart.SavePNG`
 - svg via `Chart.SaveSVG`

(and Extensions for C# style fluent interfaces by opening the `GenericChartExtensions` namespace)

The parameters for all three functions are exactly the same. 
*)

open Plotly.NET
open Plotly.NET.ImageExport

let exampleChart =
    Chart.Histogram2DContour([ 1.; 2.; 2.; 4.; 5. ], [ 1.; 2.; 2.; 4.; 5. ])

(***do-not-eval***)
exampleChart
|> Chart.saveJPG ("/your/path/without/extension/here", Width = 300, Height = 300)

(**
## Generating URIs for static chart images

By referencing the `Plotly.NET.ImageExport` package, you get access to:

 - jpg via `Chart.toBase64JPGString`
 - png via `Chart.toBase64PNGString`
 - svg via `Chart.toSVGString`

(and Extensions for C# style fluent interfaces by opening the `GenericChartExtensions` namespace)

*)

(***do-not-eval***)
let base64JPG = exampleChart |> Chart.toBase64JPGString (Width = 300, Height = 300)

(**
It is very easy to construct a html tag that includes this image via a base64 uri. For SVGs, 
not even that is necessary and just the SVG string can be used.
*)

(***do-not-eval***)
$"""<img
    src= "{base64JPG}"
/>"""
