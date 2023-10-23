namespace Plotly.NET.ImageExport

open System
open System.IO

open Plotly.NET
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

/// Extensions methods from Plotly.NET.ImageExport for the Chart module, supporting the fluent pipeline style
[<AutoOpen>]
module ChartExtensions =

    type internal RenderOptions(?EngineType: ExportEngine, ?Width: int, ?Height: int, ?Scale:float) =
        member _.Engine =
            (defaultArg EngineType ExportEngine.PuppeteerSharp) |> ExportEngine.getEngine

        member _.Width = defaultArg Width 600
        member _.Height = defaultArg Height 600
        member _.Scale = defaultArg Scale 1.0

    type Chart with

        /// <summary>
        /// Returns an async function that converts a GenericChart to a base64 encoded JPG string
        /// </summary>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("ToBase64JPGStringAsync")>]
        static member toBase64JPGStringAsync
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =

            let opts =
                RenderOptions(?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)

            fun (gChart: GenericChart) -> opts.Engine.RenderJPGAsync(opts.Width, opts.Height, opts.Scale, gChart)

        /// <summary>
        /// Returns a function that converts a GenericChart to a base64 encoded JPG string
        /// </summary>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("ToBase64JPGString")>]
        static member toBase64JPGString
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            fun (gChart: GenericChart) ->
                gChart
                |> Chart.toBase64JPGStringAsync (?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)
                |> AsyncHelper.taskSync

        /// <summary>
        /// Returns an async function that saves a GenericChart as JPG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("SaveJPGAsync")>]
        static member saveJPGAsync
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =

            let opts =
                RenderOptions(?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)

            fun (gChart: GenericChart) -> opts.Engine.SaveJPGAsync(path, opts.Width, opts.Height, opts.Scale, gChart)

        /// <summary>
        /// Returns a function that saves a GenericChart as JPG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("SaveJPG")>]
        static member saveJPG
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            fun (gChart: GenericChart) ->
                gChart
                |> Chart.saveJPGAsync (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)
                |> AsyncHelper.taskSync

        /// <summary>
        /// Returns an async function that converts a GenericChart to a base64 encoded PNG string
        /// </summary>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("ToBase64PNGStringAsync")>]
        static member toBase64PNGStringAsync
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =

            let opts =
                RenderOptions(?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)

            fun (gChart: GenericChart) -> opts.Engine.RenderPNGAsync(opts.Width, opts.Height, opts.Scale, gChart)

        /// <summary>
        /// Returns a function that converts a GenericChart to a base64 encoded PNG string
        /// </summary>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("ToBase64PNGString")>]
        static member toBase64PNGString
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            fun (gChart: GenericChart) ->
                gChart
                |> Chart.toBase64PNGStringAsync (?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)
                |> AsyncHelper.taskSync

        /// <summary>
        /// Returns an async function that saves a GenericChart as PNG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("SavePNGAsync")>]
        static member savePNGAsync
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            let opts =
                RenderOptions(?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)

            fun (gChart: GenericChart) -> opts.Engine.SavePNGAsync(path, opts.Width, opts.Height, opts.Scale, gChart)


        /// <summary>
        /// Returns a function that saves a GenericChart as PNG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("SavePNG")>]
        static member savePNG
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            fun (gChart: GenericChart) ->
                gChart
                |> Chart.savePNGAsync (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)
                |> AsyncHelper.taskSync

        /// <summary>
        /// Returns an async function that converts a GenericChart to a SVG string
        /// </summary>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("ToSVGStringAsync")>]
        static member toSVGStringAsync
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            let opts =
                RenderOptions(?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)

            fun (gChart: GenericChart) -> opts.Engine.RenderSVGAsync(opts.Width, opts.Height, opts.Scale, gChart)

        /// <summary>
        /// Returns a function that converts a GenericChart to a SVG string
        /// </summary>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("ToSVGString")>]
        static member toSVGString
            (
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            fun (gChart: GenericChart) ->
                gChart
                |> Chart.toSVGStringAsync (?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)
                |> AsyncHelper.taskSync

        /// <summary>
        /// Returns an async function that saves a GenericChart as SVG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("SaveSVGAsync")>]
        static member saveSVGAsync
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            let opts =
                RenderOptions(?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)

            fun (gChart: GenericChart) -> opts.Engine.SaveSVGAsync(path, opts.Width, opts.Height, opts.Scale, gChart)

        /// <summary>
        /// Returns a function that saves a GenericChart as SVG image
        /// </summary>
        /// <param name="path">The path (without extension) where the image will be saved</param>
        /// <param name="EngineType">The Render engine to use</param>
        /// <param name="Width">width of the resulting image</param>
        /// <param name="Height">height of the resulting image</param>
        /// <param name="Scale">scale the resulting image by this factor. The DPI will stay the same, but the resolution will be scaled.</param>
        [<CompiledName("SaveSVG")>]
        static member saveSVG
            (
                path: string,
                [<Optional; DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional; DefaultParameterValue(null)>] ?Width: int,
                [<Optional; DefaultParameterValue(null)>] ?Height: int,
                [<Optional; DefaultParameterValue(null)>] ?Scale: float
            ) =
            fun (gChart: GenericChart) ->
                gChart
                |> Chart.saveSVGAsync (path, ?EngineType = EngineType, ?Width = Width, ?Height = Height, ?Scale = Scale)
                |> AsyncHelper.taskSync
