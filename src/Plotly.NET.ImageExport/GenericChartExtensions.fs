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
        member this.ToBase64JPGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toBase64JPGString(?Engine=Engine, ?Width=Width, ?Height=Height)

        [<CompiledName("SaveJPG")>]
        [<Extension>]
        member this.SaveJPG 
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.saveJPG(path, ?Engine=Engine, ?Width=Width, ?Height=Height)

        [<CompiledName("ToBase64PNGString")>]
        [<Extension>]
        member this.ToBase64PNGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toBase64PNGString(?Width=Width, ?Height=Height)

        [<CompiledName("SavePNG")>]
        [<Extension>]
        member this.SavePNG
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.savePNG(path, ?Engine=Engine, ?Width=Width, ?Height=Height)
        
        [<CompiledName("ToSVGString")>]
        [<Extension>]
        member this.ToSVGString
            (
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                this |> Chart.toSVGString(?Width=Width, ?Height=Height)

        [<CompiledName("SaveSVG")>]
        [<Extension>]
        member this.SaveSVG
            (
                path:string,
                [<Optional;DefaultParameterValue(null)>] ?Engine: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) =
                this |> Chart.saveSVG(path, ?Engine=Engine, ?Width=Width, ?Height=Height)