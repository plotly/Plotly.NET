# Plotly.NET.ImageExport

Render [Plotly.NET](https://plotly.net/) charts as PNG, JPEG, or SVG images using a headless browser powered by PuppeteerSharp.

## Install

```shell
dotnet add package Plotly.NET.ImageExport --version 7.0.0
```

Version 7 targets **.NET Standard 2.0** and depends on **Plotly.NET 6.x**, which NuGet installs automatically. Use a compatible .NET application runtime and an operating system that can run the browser described below.

## Export a chart

This F# script writes `chart.png` in the current directory:

```fsharp
#r "nuget: Plotly.NET.ImageExport, 7.0.0"

open Plotly.NET
open Plotly.NET.ImageExport

let chart =
    Chart.Line([ (1., 2.); (2., 4.); (3., 3.) ])
    |> Chart.withDisplayOptions(
        DisplayOptions.init(PlotlyJSReference = PlotlyJSReference.Full)
    )

chart |> Chart.savePNG("chart", Width = 800, Height = 450)
```

Pass a path **without an extension**; the save functions append `.png`, `.jpg`, or `.svg`. The output directory must already exist and be writable. The example embeds plotly.js so the browser does not need to fetch it from a CDN.

## Output formats

| Format | Save to a file | Return an image string |
| --- | --- | --- |
| PNG | `Chart.savePNG` | `Chart.toBase64PNGString` — PNG data URI |
| JPEG | `Chart.saveJPG` | `Chart.toBase64JPGString` — JPEG data URI |
| SVG | `Chart.saveSVG` | `Chart.toSVGString` — SVG markup |

These functions accept `Width`, `Height`, and `Scale` options, defaulting to 600, 600, and 1.0. Corresponding `Async` functions, such as `Chart.savePNGAsync`, return tasks that you can await.

## Browser requirements

The default renderer uses PuppeteerSharp 24.40.0 to download a compatible Chrome browser when needed and launch it for each export. Browser setup requires network access and a writable browser download/cache location. The host must permit browser processes and provide the required operating-system libraries; see the [PuppeteerSharp prerequisites](https://github.com/hardkoded/puppeteer-sharp#prerequisites).

To use a preinstalled compatible Chrome/Chromium executable and skip the automatic download, set `PuppeteerSharpRendererOptions.localBrowserExecutablePath` to `Some "/absolute/path/to/chrome"` before exporting. Launch and navigation settings are available through `PuppeteerSharpRendererOptions.launchOptions` and `PuppeteerSharpRendererOptions.navigationOptions`.

Charts that reference external images, fonts, map resources, or a plotly.js CDN may still need network access during rendering.

See the [image export guide](https://plotly.net/general/image-export.html) for more examples and the [release notes](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.ImageExport/RELEASE_NOTES.md) for version changes.

Licensed under the [MIT License](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).
