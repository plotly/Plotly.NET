module Formatters
#load "../../packages/formatting/FSharp.Formatting/FSharp.Formatting.fsx"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"
#r "../../packages/formatting/FSharp.Compiler.Service/lib/netstandard2.0/FSharp.Compiler.Service.dll"

// --------------------------------------------------------------------------------------
// NOTE: Most of this file is the same as in FsLab (https://github.com/fslaborg/FsLab)
// --------------------------------------------------------------------------------------

open FSharp.Literate
open FSharp.Markdown
open Plotly.NET

// --------------------------------------------------------------------------------------
// Build FSI evaluator
// --------------------------------------------------------------------------------------

/// Builds FSI evaluator that can render System.Image, F# Charts, series & frames
let createFsiEvaluator root output =

  let transformation (value:obj, typ:System.Type) =
    match value with 
    | :? GenericChart.GenericChart as ch ->
        // Just return the inline HTML for a Plotly chart        
        let html = GenericChart.toChartHtmlWithSize 700 500 ch
        Some [InlineBlock (html,None)]

    | _ -> None 
    
  // Create FSI evaluator, register transformations & return
  let fsiEvaluator = FsiEvaluator()
  fsiEvaluator.RegisterTransformation(transformation)
  fsiEvaluator