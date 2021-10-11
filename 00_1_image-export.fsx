(**
// can't yet format YamlFrontmatter (["title: Static image export"; "category: General"; "categoryindex: 1"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=00_1_image-export.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/00_1_image-export.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/00_1_image-export.ipynb)

# Static image export

### Table of contents

- [Saving static images](#Saving-static-images)
- [Generating URIs for static chart images](#Generating-URIs-for-static-chart-images)
- [Including static images in dotnet interactive notebooks](#Including-static-images-in-dotnet-interactive-notebooks)

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
    Chart.Histogram2dContour(
        [1.;2.;2.;4.;5.],
        [1.;2.;2.;4.;5.]
    )
exampleChart
|> Chart.saveJPG(
    "/your/path/without/extension/here",
    Width=300,
    Height=300
)(* output: 
<img
    src= "data:image/jpeg;base64,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"
/>*)
(**
## Generating URIs for static chart images

By referencing the `Plotly.NET.ImageExport` package, you get access to:

 - jpg via `Chart.toBase64JPGString`
 - png via `Chart.toBase64PNGString`
 - svg via `Chart.toSVGString`

(and Extensions for C# style fluent interfaces by opening the `GenericChartExtensions` namespace)


*)
let base64JPG =
    exampleChart
    |> Chart.toBase64JPGString(
        Width=300,
        Height=300
    )
(**
It is very easy to construct a html tag that includes this image via a base64 uri. For SVGs, 
not even that is necessary and just the SVG string can be used.

*)
$"""<img
    src= "{base64JPG}"
/>"""(* output: 
<img
    src= "data:image/jpeg;base64,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"
/>*)
(**
SVGs can be included without the image tag:

*)
let svgString =
    exampleChart
    |> Chart.toSVGString(
        Width=300,
        Height=300
    )

svgString.Substring(0,300)
|> printfn "%s"(* output: 
<svg class="main-svg" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="300" height="300" style="" viewBox="0 0 300 300"><rect x="0" y="0" width="300" height="300" style="fill: rgb(255, 255, 255); fill-opacity: 1;"/><defs id="defs-f35748"><g class="clips"><clipPath*)
(**
In fact, the images shown on this site are included just the same way.

## Including static images in dotnet interactive notebooks

To include the images in dotnet interactive, convert them to html tags as above and include them via 
dotnet interactive's `DisplayAs` function. The content type for PNG/JPG is "text/html", and "image/svg+xml" for SVG.

*)
let base64PNGTag =
    let base64 =
        exampleChart
        |> Chart.toBase64PNGString(
            Width=300,
            Height=300
        )
    $"""<img src= "{base64JPG}"/>"""

let svgString2 =
    exampleChart
    |> Chart.toSVGString(
        Width=300,
        Height=300
    )

// DisplayExtensions.DisplayAs(base64PNG,"text/html")
// DisplayExtensions.DisplayAs(svgString2,"image/svg+xml")

