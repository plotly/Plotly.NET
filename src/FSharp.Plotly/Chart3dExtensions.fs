namespace FSharp.Plotly

open System
open System.IO

open GenericChart3d

/// Extensions methods for 3d-Charts supporting the fluent pipeline style 'Chart3d.WithXYZ(...)'.
[<AutoOpen>]
module Chart3dExtensions =

    /// Provides a set of static methods for creating charts.
    type Chart3d with 

        static member withSize(width,heigth) =            
            (fun (ch:GenericChart3d) -> 
                let layout = Options.Layout(Width=width,Height=heigth)
                GenericChart3d.addLayout layout ch)  
    
        // ####################### 
        /// Create a combined chart with the given charts merged   
        static member Combine(gCharts:seq<GenericChart3d>) =
            GenericChart3d.combine gCharts
        
        /// Show chart in browser            
        static member Show (ch:GenericChart3d) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart3d.toEmbeddedHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore

