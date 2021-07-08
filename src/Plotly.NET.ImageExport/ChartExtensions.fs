namespace Plotly.NET.ImageExport

open System
open System.IO

open Plotly.NET
open GenericChart
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

/// Extensions methods from Plotly.NET.ImageExport for the Chart module, supporting the fluent pipeline style
[<AutoOpen>]
module ChartExtensions =
    
    type Chart with
        
        [<CompiledName("ToBase64JPGString")>]
        static member toBase64JPGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) : GenericChart -> string = 
            
                let engineType = defaultArg Engine ExportEngine.PuppeteerSharp
                let width  = defaultArg Width 600
                let height = defaultArg Height 600

                let engine = ExportEngine.getEngine engineType

                (fun (gChart:GenericChart) ->
                    engine.RenderJPG(width, height, gChart)
                )

        [<CompiledName("SaveJPG")>]
        static member saveJPG 
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) : GenericChart -> unit = 
            
                let engineType = defaultArg Engine ExportEngine.PuppeteerSharp
                let width  = defaultArg Width 600
                let height = defaultArg Height 600

                let engine = ExportEngine.getEngine engineType
                
                (fun (gChart:GenericChart) ->
                    engine.SaveJPG(path, width, height, gChart)
                )

        
        [<CompiledName("ToBase64PNGString")>]
        static member toBase64PNGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) : GenericChart -> string = 
            
                let engineType = defaultArg Engine ExportEngine.PuppeteerSharp
                let width  = defaultArg Width 600
                let height = defaultArg Height 600

                let engine = ExportEngine.getEngine engineType

                (fun (gChart:GenericChart) ->
                    engine.RenderPNG(width, height, gChart)
                )

        [<CompiledName("SavePNG")>]
        static member savePNG
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) : GenericChart -> unit = 
            
                let engineType = defaultArg Engine ExportEngine.PuppeteerSharp
                let width  = defaultArg Width 600
                let height = defaultArg Height 600

                let engine = ExportEngine.getEngine engineType

                (fun (gChart:GenericChart) ->
                    engine.SavePNG(path, width, height, gChart)
                )

        
        [<CompiledName("ToSVGString")>]
        static member toSVGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) : GenericChart -> string = 
            
                let engineType = defaultArg Engine ExportEngine.PuppeteerSharp
                let width  = defaultArg Width 600
                let height = defaultArg Height 600

                let engine = ExportEngine.getEngine engineType

                (fun (gChart:GenericChart) ->
                    engine.RenderSVG(width, height, gChart)
                )

        [<CompiledName("SaveSVG")>]
        static member saveSVG
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) : GenericChart -> unit = 
            
                let engineType = defaultArg Engine ExportEngine.PuppeteerSharp
                let width  = defaultArg Width 600
                let height = defaultArg Height 600

                let engine = ExportEngine.getEngine engineType

                (fun (gChart:GenericChart) ->
                    engine.SaveSVG(path, width, height, gChart)
                )