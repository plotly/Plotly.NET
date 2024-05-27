namespace Plotly.NET.ImageExport

open System.Threading
open System.Threading.Tasks
open Plotly.NET
open PuppeteerSharp

open System
open System.IO
open System.Text
open System.Text.RegularExpressions
open DynamicObj

module PuppeteerSharpRendererOptions =

    let mutable launchOptions = LaunchOptions()

    launchOptions.Timeout <- 60000

    let mutable localBrowserExecutablePath =
        None

    let mutable navigationOptions = NavigationOptions()

type PuppeteerSharpRenderer() =

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    ///
    /// creates a full screen html site for the given chart
    let toFullScreenHtml (gChart: GenericChart) =

        gChart
        |> GenericChart.mapConfig (fun c ->
            DynObj.setValue c "responsive" true
            c)
        |> GenericChart.mapLayout (fun l ->
            DynObj.setValue l "width" "100%"
            DynObj.setValue l "height" "100%"
            l)
        |> GenericChart.toEmbeddedHTML
        // this should be done via regex, as this only captures the default width and height.
        |> fun html -> html.Replace("width: 600px; height: 600px;", "width: 100%; height: 100%;")

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    ///
    /// adds the necessary js function calls to render an image with plotly.js
    let patchHtml width height (scale: float) (format: StyleParam.ImageFormat) html =
        let regex =
            Regex(@"(Plotly\.newPlot\(.+?\))")

        let patchedHtml =
            regex.Replace(
                html,
                (fun (x: Match) ->
                    x.Result(
                        "$1"
                        + $".then(x => Plotly.toImage(x, {{ format: '{StyleParam.ImageFormat.toString format}', scale: {scale}, width: {width}, height: {height} }}))"
                        + ".then(img => window.plotlyImage = img)"
                    ))
            )

        patchedHtml

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    ///
    /// attempts to render a chart as static image of the given format with the given dimensions from the given html string
    let tryRenderAsync (browser: IBrowser) (width: int) (height: int) (scale: float) (format: StyleParam.ImageFormat) (html: string) =
        task {
            let! page = browser.NewPageAsync() |> Async.AwaitTask

            try
                let! _ = 
                    page.SetContentAsync(
                        html = patchHtml width height scale format html,
                        options = PuppeteerSharpRendererOptions.navigationOptions
                    ) 
                    |> Async.AwaitTask
                let! imgHandle = page.WaitForExpressionAsync("window.plotlyImage") |> Async.AwaitTask
                let! imgStr = imgHandle.JsonValueAsync<string>() |> Async.AwaitTask
                return imgStr

            finally
                page.CloseAsync() |> AsyncHelper.taskSyncUnit
        }

    /// Initalizes headless browser
    let fetchAndLaunchBrowserAsync () =
        task {
            match PuppeteerSharpRendererOptions.localBrowserExecutablePath with
            | None ->
                let browserFetcher = new BrowserFetcher()

                let! revision = browserFetcher.DownloadAsync()

                let launchOptions =
                    PuppeteerSharpRendererOptions.launchOptions

                launchOptions.ExecutablePath <- revision.GetExecutablePath()

                return! Puppeteer.LaunchAsync(launchOptions)
            | Some p ->
                let launchOptions =
                    PuppeteerSharpRendererOptions.launchOptions

                launchOptions.ExecutablePath <- p

                return! Puppeteer.LaunchAsync(launchOptions)
        }

    /// skips the data type part of the given URI
    let skipDataTypeString (base64: string) =
        let imgBase64StartIdx =
            base64.IndexOf(",", StringComparison.Ordinal) + 1

        base64.Substring(imgBase64StartIdx)

    /// converst a base64 encoded string URI to a byte array
    let getBytesFromBase64String (base64: string) =
        base64 |> skipDataTypeString |> Convert.FromBase64String

    interface IGenericChartRenderer with

        member this.RenderJPGAsync(width: int, height: int, scale: float, gChart: GenericChart) =
            task {
                use! browser = fetchAndLaunchBrowserAsync ()

                return! tryRenderAsync browser width height scale StyleParam.ImageFormat.JPEG (gChart |> toFullScreenHtml)
            }

        member this.RenderJPG(width: int, height: int, scale: float, gChart: GenericChart) =
            (this :> IGenericChartRenderer)
                .RenderJPGAsync(width, height, scale, gChart)
            |> AsyncHelper.taskSync

        member this.SaveJPGAsync(path: string, width: int, height: int, scale: float, gChart: GenericChart) =
            task {
                let! rendered =
                    (this :> IGenericChartRenderer)
                        .RenderJPGAsync(width, height, scale, gChart)

                return rendered |> getBytesFromBase64String |> (fun base64 -> File.WriteAllBytes($"{path}.jpg", base64))
            }

        member this.SaveJPG(path: string, width: int, height: int, scale: float, gChart: GenericChart) =
            (this :> IGenericChartRenderer)
                .SaveJPGAsync(path, width, height, scale, gChart)
            |> AsyncHelper.taskSync

        member this.RenderPNGAsync(width: int, height: int, scale: float, gChart: GenericChart) =
            task {
                use! browser = fetchAndLaunchBrowserAsync ()

                return! tryRenderAsync browser width height scale StyleParam.ImageFormat.PNG (gChart |> toFullScreenHtml)
            }

        member this.RenderPNG(width: int, height: int, scale: float, gChart: GenericChart) =
            (this :> IGenericChartRenderer)
                .RenderPNGAsync(width, height, scale, gChart)
            |> AsyncHelper.taskSync

        member this.SavePNGAsync(path: string, width: int, height: int, scale: float, gChart: GenericChart) =
            task {
                let! rendered =
                    (this :> IGenericChartRenderer)
                        .RenderPNGAsync(width, height, scale, gChart)

                return rendered |> getBytesFromBase64String |> (fun base64 -> File.WriteAllBytes($"{path}.png", base64))
            }

        member this.SavePNG(path: string, width: int, height: int, scale: float, gChart: GenericChart) =
            (this :> IGenericChartRenderer)
                .SavePNGAsync(path, width, height, scale, gChart)
            |> AsyncHelper.taskSync

        member this.RenderSVGAsync(width: int, height: int, scale: float, gChart: GenericChart) =
            task {
                use! browser = fetchAndLaunchBrowserAsync ()

                let! renderedString =
                    tryRenderAsync browser width height scale StyleParam.ImageFormat.SVG (gChart |> toFullScreenHtml)

                return renderedString |> fun svg -> System.Uri.UnescapeDataString(svg) |> skipDataTypeString
            }

        member this.RenderSVG(width: int, height: int, scale: float, gChart: GenericChart) =
            (this :> IGenericChartRenderer)
                .RenderSVGAsync(width, height, scale, gChart)
            |> AsyncHelper.taskSync

        member this.SaveSVGAsync(path: string, width: int, height: int, scale: float, gChart: GenericChart) =
            task {
                let! rendered =
                    (this :> IGenericChartRenderer)
                        .RenderSVGAsync(width, height, scale, gChart)

                return rendered |> fun svg -> File.WriteAllText($"{path}.svg", svg)
            }

        member this.SaveSVG(path: string, width: int, height: int, scale: float, gChart: GenericChart) =
            (this :> IGenericChartRenderer)
                .SaveSVGAsync(path, width, height, scale, gChart)
            |> AsyncHelper.taskSync
