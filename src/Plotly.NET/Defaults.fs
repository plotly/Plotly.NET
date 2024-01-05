namespace Plotly.NET

open Plotly.NET
open Plotly.NET.LayoutObjects

open DynamicObj
open DynamicObj.Operators
open System.Runtime.InteropServices

open Giraffe.ViewEngine

/// Contains mutable global default values.
///
/// Changing these values will apply the default values to all consecutive Chart generations.
module Defaults =

    /// The default width of the chart container in generated html files. Default: 600 (px)
    let mutable DefaultWidth = 600

    /// The default height of the chart container in generated html files. Default: 600 (px)
    let mutable DefaultHeight = 600

    /// The default chart config. Default: Config.init (Responsive = true)
    let mutable DefaultConfig =
        Config.init (Responsive = true)

    let mutable DefaultDisplayOptions =
        DisplayOptions.init (
            DocumentTitle = "Plotly.NET Datavisualization",
            DocumentDescription = "A plotly.js graph generated with Plotly.NET",
            DocumentCharset = "UTF-8",
            DocumentFavicon = 
                (link [
                    _id "favicon"
                    _rel "shortcut icon"
                    _type "image/png"
                    _href $"data:image/png;base64,{Globals.LOGO_BASE64}"
                ]),
            PlotlyJSReference = CDN $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min.js"
        )

    /// The default chart template. Default: ChartTemplates.plotly
    let mutable DefaultTemplate =
        ChartTemplates.plotly

    /// reset global defaults to the initial values
    let reset () =
        DefaultWidth <- 600
        DefaultHeight <- 600
        DefaultConfig <- Config.init (Responsive = true)
        DefaultDisplayOptions <- DisplayOptions.initCDNOnly ()
        DefaultTemplate <- ChartTemplates.plotly
