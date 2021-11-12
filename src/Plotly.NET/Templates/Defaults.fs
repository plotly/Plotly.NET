namespace Plotly.NET

open Plotly.NET
open Plotly.NET.LayoutObjects

open DynamicObj
open DynamicObj.Operators
open System.Runtime.InteropServices

module Defaults =
    
    let mutable DefaultWidth = 600

    let mutable DefaultHeight = 600

    let mutable DefaultConfig = Config.init(Responsive = true)

    let mutable DefaultDisplayOptions = DisplayOptions.init()

    let mutable DefaultTemplate = ChartTemplates.plotly