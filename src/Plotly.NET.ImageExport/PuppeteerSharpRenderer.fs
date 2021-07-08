namespace Plotly.NET.ImageExport

open Plotly.NET
open PuppeteerSharp

open System
open System.IO
open System.Text
open System.Text.RegularExpressions

type PuppeteerSharpRenderer() =

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    let toFullScreenHtml (gChart: GenericChart.GenericChart) =
        
        gChart
        |> GenericChart.mapConfig(fun c ->
            DynObj.setValue c "responsive" true
            c
        )
        |> GenericChart.mapLayout(fun l ->
            DynObj.setValue l "width" "100%"
            DynObj.setValue l "height" "100%"
            l
        )
        |> GenericChart.toChartHTML
        |> fun html -> html.Replace("width: 600px; height: 600px;", "width: 100%; height: 100%;")

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    let patchHtml width height (format: StyleParam.ImageFormat) html =
        let regex = Regex(@"(Plotly\.newPlot\(.+?\))")
        let patchedHtml = 
            regex.Replace(
                html,
                (
                    fun (x:Match) -> 
                        x.Result(
                            "$1" 
                            + $".then(x => Plotly.toImage(x, {{ format: '{StyleParam.ImageFormat.toString format}', scale: 2, width: {width}, height: {height} }}))" 
                            + ".then(img => window.plotlyImage = img)"
                        )
                )
            )
        patchedHtml

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    let tryRender (browser:Browser) (width: int) (height: int) (format: StyleParam.ImageFormat) (html: string) =
        let page = browser.NewPageAsync() |> Async.AwaitTask |> Async.RunSynchronously
        try 
            page.SetContentAsync(patchHtml width height format html) |> Async.AwaitTask |> Async.RunSynchronously
            let imgHandle = page.WaitForExpressionAsync("window.plotlyImage") |> Async.AwaitTask |> Async.RunSynchronously
            let imgStr = imgHandle.JsonValueAsync<string>() |> Async.AwaitTask |> Async.RunSynchronously
            imgStr
        
        finally 
            page.CloseAsync() |> Async.AwaitTask |> Async.RunSynchronously

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    let fetchAndLaunchBrowser() =

        let browserFetcher = BrowserFetcher()

        let revision = 
            browserFetcher.DownloadAsync() 
            |> Async.AwaitTask 
            |> Async.RunSynchronously

        let launchOptions = LaunchOptions()
        launchOptions.ExecutablePath <- revision.ExecutablePath
        launchOptions.Timeout <- 60000

        Puppeteer.LaunchAsync(launchOptions)
        |> Async.AwaitTask 
        |> Async.RunSynchronously

    let skipDataTypeString (base64:string) =
        let imgBase64StartIdx =base64.IndexOf(",", StringComparison.Ordinal) + 1
        base64.Substring(imgBase64StartIdx)

    let getBytesFromBase64String (base64:string) =
        base64
        |> skipDataTypeString
        |> Convert.FromBase64String

    interface IGenericChartRenderer with
        
        member this.RenderJPG (width:int, height: int, gChart:GenericChart.GenericChart) : string = 
            
            use browser = fetchAndLaunchBrowser()

            tryRender 
                browser 
                width 
                height 
                StyleParam.ImageFormat.JPEG 
                (gChart |> toFullScreenHtml)

        member this.SaveJPG (path:string, width:int, height: int, gChart:GenericChart.GenericChart) : unit = 
            
            (this :> IGenericChartRenderer).RenderJPG(width, height, gChart)
            |> getBytesFromBase64String
            |> fun base64 -> File.WriteAllBytes(path, base64)

        member this.RenderPNG (width:int, height: int, gChart:GenericChart.GenericChart) : string = 
            
            use browser = fetchAndLaunchBrowser()

            tryRender 
                browser 
                width 
                height 
                StyleParam.ImageFormat.PNG 
                (gChart |> toFullScreenHtml)

        member this.SavePNG (path:string, width:int, height: int, gChart:GenericChart.GenericChart) : unit = 

            (this :> IGenericChartRenderer).RenderPNG(width, height, gChart)
            |> getBytesFromBase64String
            |> fun base64 -> File.WriteAllBytes(path, base64)
        
        member this.RenderSVG (width:int, height: int, gChart:GenericChart.GenericChart) : string = 
            
            use browser = fetchAndLaunchBrowser()

            tryRender 
                browser 
                width 
                height 
                StyleParam.ImageFormat.SVG 
                (gChart |> toFullScreenHtml)
            |> fun svg -> System.Uri.UnescapeDataString(svg)
            |> skipDataTypeString

        member this.SaveSVG(path:string, width:int, height: int, gChart:GenericChart.GenericChart) : unit =

            (this :> IGenericChartRenderer).RenderSVG(width, height, gChart)
            |> fun svg -> File.WriteAllText(path, svg)