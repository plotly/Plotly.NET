namespace Plotly.NET.ImageExport

open Plotly.NET
open GenericChart
open System
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

///<summary>Extension methods for providing a Plotly.NET.ImageExport fluent interface pattern for C#</summary>
[<Extension>]
module GenericChartExtensions =

    type GenericChart with

        [<CompiledName("ToBase64JPGString")>]
        [<Extension>]
        member this.ToBase64JPGStringAsync
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toBase64JPGStringAsync(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
        [<CompiledName("ToBase64JPGString")>]
        [<Extension>]
        member this.ToBase64JPGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toBase64JPGString(?EngineType=EngineType, ?Width=Width, ?Height=Height)

        [<CompiledName("SaveJPGAsync")>]
        [<Extension>]
        member this.SaveJPGAsync
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.saveJPGAsync(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
        
        [<CompiledName("SaveJPG")>]
        [<Extension>]
        member this.SaveJPG 
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.saveJPG(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)

        [<CompiledName("ToBase64PNGStringAsync")>]
        [<Extension>]
        member this.ToBase64PNGStringAsync
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toBase64PNGStringAsync(?EngineType = EngineType, ?Width=Width, ?Height=Height)
                
        [<CompiledName("ToBase64PNGString")>]
        [<Extension>]
        member this.ToBase64PNGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toBase64PNGString(?EngineType = EngineType, ?Width=Width, ?Height=Height)

        [<CompiledName("SavePNG")>]
        [<Extension>]
        member this.SavePNG
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.savePNG(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
        
        [<CompiledName("SavePNGAsync")>]
        [<Extension>]
        member this.SavePNGAsync
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.savePNG(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
        
        [<CompiledName("ToSVGString")>]
        [<Extension>]

        member this.ToSVGString
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toSVGString(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
        [<CompiledName("ToSVGStringAsync")>]
        [<Extension>]

        member this.ToSVGStringAsync
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toSVGStringAsync(?EngineType=EngineType, ?Width=Width, ?Height=Height)

        [<CompiledName("SaveSVG")>]
        [<Extension>]
        member this.SaveSVG
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.saveSVG(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
        [<CompiledName("SaveSVGAsync")>]
        [<Extension>]
        member this.SaveSVGAsync
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.saveSVGAsync(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
