open System
open Deedle
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine
open Newtonsoft.Json

[<EntryPoint>]
let main argv =
    Config.init(
        StaticPlot              = false,
        TypesetMath             = true,
        PlotlyServerUrl         = "myserver.me.meme",
        Editable                = true,
        Edits                   = Edits.init(AnnotationPosition = true, ShapePosition = true),
        EditSelection           = true,
        Autosizable             = true,
        Responsive              = true,
        FillFrame               = true,
        FrameMargins            = 1.337,
        ScrollZoom              = StyleParam.ScrollZoom.All,
        DoubleClick             = StyleParam.DoubleClick.Reset,
        DoubleClickDelay        = 1337,
        ShowAxisDragHandles     = true,
        ShowAxisRangeEntryBoxes = true,
        ShowTips                = true,
        ShowLink                = true,
        LinkText                = "never gonna give you up",
        SendData                = true,
        ShowSources             = true,
        DisplayModeBar          = true,
        ShowSendToCloud         = true,
        ShowEditInChartStudio   = true,
        ModeBarButtonsToRemove  = [StyleParam.ModeBarButton.AutoScale2d],
        ModeBarButtonsToAdd     = [StyleParam.ModeBarButton.DrawCircle],
        ModeBarButtons          = [[StyleParam.ModeBarButton.DrawClosedPath; StyleParam.ModeBarButton.DrawOpenPath];[StyleParam.ModeBarButton.OrbitRotation]],
        ToImageButtonOptions    = ToImageButtonOptions.init(Format = StyleParam.ImageFormat.SVG, Filename="soos.svg"),
        Displaylogo             = true,
        Watermark               = true,
        plotGlPixelRatio        = 1.0,
        SetBackground           = box "function(x) => {return x}",
        TopojsonURL             = "myserver.me.meme",
        MapboxAccessToken       = "4Tw20BlzLT",
        Logging                 = 2,
        NotifyOnLogging         = 2,
        QueueLength             = 1337,
        GlobalTransforms        = box "function(x) => {return x}",
        Locale                  = "de-DE",
        Locales                 = box """{"yes": "no"}"""
    )
    :> DynamicObj 
    |> JsonConvert.SerializeObject
    |> printfn "%A"
    0