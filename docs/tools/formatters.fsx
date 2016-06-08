module Formatters
#I "../../packages/build/FSharp.Formatting/lib/net40"
#r "FSharp.Markdown.dll"
#r "FSharp.Literate.dll"

#r "FSharp.CodeFormat.dll"
#r "RazorEngine.dll"
#r "../../packages/build/FAKE/tools/FakeLib.dll"

//#I "../../bin"
#r "../../bin/FSharp.Plotly.dll"


open Fake
open System.IO
open FSharp.Literate
open FSharp.Markdown

open FSharp.Plotly

// --------------------------------------------------------------------------------------
// Build FSI evaluator
// --------------------------------------------------------------------------------------

/// Builds FSI evaluator that can render System.Image, F# Charts, series & frames
let createFsiEvaluator root output =

  /// Counter for saving files
  let imageCounter = 
    let count = ref 0
    (fun () -> incr count; !count)

  let transformation (value:obj, typ:System.Type) =
    match value with 
    | :? System.Drawing.Image as img ->
        // Pretty print image - save the image to the "images" directory 
        // and return a DirectImage reference to the appropriate location
        let id = imageCounter().ToString()
        let file = "chart" + id + ".png"
        ensureDirectory (output @@ "images")
        img.Save(output @@ "images" @@ file, System.Drawing.Imaging.ImageFormat.Png) 
        Some [ Paragraph [DirectImage ("", (root + "/images/" + file, None))]  ]

    | :? GenericChart.GenericChart as ch ->
        // Just return the inline HTML for a Plotly chart        
        let html = GenericChart.toInnerHTML ch
        Some [InlineBlock <| html]

    | _ -> None 
    
  // Create FSI evaluator, register transformations & return
  let fsiEvaluator = FsiEvaluator()
  fsiEvaluator.RegisterTransformation(transformation)
  fsiEvaluator