namespace Plotly.NET.ImageExport

open Plotly.NET
open System
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

///<summary>Extension methods for providing a Plotly.NET.ImageExport fluent interface pattern for C#</summary>
[<Extension>]
module GenericChartExtensions =

    type GenericChart with

        /// <summary>
        /// Converts the GenericChart to a base64 encoded JPG string (async)
        /// </summary>
        /// <param name="EngineType"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        [<CompiledName("ToBase64JPGStringAsync")>]
        [<Extension>]
        member this.ToBase64JPGStringAsync
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =

            this |> Chart.toBase64JPGStringAsync (?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Converts the GenericChart to a base64 encoded JPG string
        /// </summary>
        /// <param name="EngineType"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        [<CompiledName("ToBase64JPGString")>]
        [<Extension>]
        member this.ToBase64JPGString
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =

            this |> Chart.toBase64JPGString (?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Saves the GenericChart as JPG image (async)
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        [<CompiledName("SaveJPGAsync")>]
        [<Extension>]
        member this.SaveJPGAsync
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =
            this |> Chart.saveJPGAsync (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Saves the GenericChart as JPG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        [<CompiledName("SaveJPG")>]
        [<Extension>]
        member this.SaveJPG
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =
            this |> Chart.saveJPG (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Converts the GenericChart to a base64 encoded PNG string (async)
        /// </summary>
        /// <param name="EngineType"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        [<CompiledName("ToBase64PNGStringAsync")>]
        [<Extension>]
        member this.ToBase64PNGStringAsync
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =

            this |> Chart.toBase64PNGStringAsync (?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Converts the GenericChart to a base64 encoded PNG string
        /// </summary>
        /// <param name="EngineType"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        [<CompiledName("ToBase64PNGString")>]
        [<Extension>]
        member this.ToBase64PNGString
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =

            this |> Chart.toBase64PNGString (?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Saves the GenericChart as PNG image (async)
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        [<CompiledName("SavePNGAsync")>]
        [<Extension>]
        member this.SavePNGAsync
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =
            this |> Chart.savePNGAsync (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Saves the GenericChart as PNG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        [<CompiledName("SavePNG")>]
        [<Extension>]
        member this.SavePNG
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =
            this |> Chart.savePNG (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Converts the GenericChart to a SVG string (async)
        /// </summary>
        /// <param name="EngineType"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        [<CompiledName("ToSVGStringAsync")>]
        [<Extension>]
        member this.ToSVGStringAsync
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =

            this |> Chart.toSVGStringAsync (?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Converts the GenericChart to a SVG string
        /// </summary>
        /// <param name="EngineType"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        [<CompiledName("ToSVGString")>]
        [<Extension>]
        member this.ToSVGString
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =

            this |> Chart.toSVGString (?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Saves the GenericChart as SVG image (async)
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        [<CompiledName("SaveSVGAsync")>]
        [<Extension>]
        member this.SaveSVGAsync
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =
            this |> Chart.saveSVGAsync (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height)

        /// <summary>
        /// Saves the GenericChart as SVG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        [<CompiledName("SaveSVG")>]
        [<Extension>]
        member this.SaveSVG
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int
            ) =
            this |> Chart.saveSVG (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height)
