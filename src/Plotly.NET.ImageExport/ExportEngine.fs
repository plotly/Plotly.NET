namespace Plotly.NET.ImageExport

///<summary>DU containing the available static image export engines for Plotly.NET</summary>
type ExportEngine =
    /// <summary>Using this engine will use PuppeteerSharp with a Chromium headless browser to render GenericCharts from Plotly.NET.</summary>
    | PuppeteerSharp

    static member getEngine (engineType: ExportEngine) =
        match engineType with
        | PuppeteerSharp ->
            PuppeteerSharpRenderer() :> IGenericChartRenderer