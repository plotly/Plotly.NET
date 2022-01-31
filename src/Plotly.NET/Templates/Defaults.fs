namespace Plotly.NET

open Plotly.NET
open Plotly.NET.LayoutObjects

open DynamicObj
open DynamicObj.Operators
open System.Runtime.InteropServices


/// Contains mutable global default values.
///
/// Changing these values will apply the default values to all consecutive Chart generations.
module Defaults =

    /// The default width of the chart container in generated html files. Default: 600 (px)
    let mutable DefaultWidth = 600

    /// The default height of the chart container in generated html files. Default: 600 (px)
    let mutable DefaultHeight = 600

    /// The default chart config. Default: Config.init (Responsive = true)
    let mutable DefaultConfig = Config.init (Responsive = true)

    /// The display options used for generating html. Default: DisplayOptions.init ()
    let mutable DefaultDisplayOptions = DisplayOptions.init ()

    /// The default chart template. Default: ChartTemplates.plotly
    let mutable DefaultTemplate = ChartTemplates.plotly

    /// reset global defaults to the initial values
    let reset () =
        DefaultWidth <- 600
        DefaultHeight <- 600
        DefaultConfig <- Config.init (Responsive = true)
        DefaultDisplayOptions <- DisplayOptions.init ()
        DefaultTemplate <- ChartTemplates.plotly
