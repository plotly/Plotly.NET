module Tests.ConfigObjects.Config

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.ConfigObjects
open DynamicObj

open TestUtils.Objects

let config = 
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
        GlobalTransforms        = box """function(x) => {return x}""",
        Locale                  = "de-DE",
        Locales                 = (DynamicObj() |> fun x -> x?yes <- "no"; x)
    )


[<Tests>]
let ``Config json tests`` =
    testList "ConfigObjects.Config JSON field tests" [
        testCase "active" (fun _ -> config |> jsonFieldIsSetWith  "staticPlot" "false")
        testCase "typesetMath" (fun _ -> config |> jsonFieldIsSetWith "typesetMath" "true")
        testCase "plotlyServerUrl" (fun _ -> config |> jsonFieldIsSetWith "plotlyServerUrl" "\"myserver.me.meme\"")
        testCase "editable" (fun _ -> config |> jsonFieldIsSetWith "editable" "true")
        testCase "edits" (fun _ -> config |> jsonFieldIsSetWith "edits" """{"annotationPosition":true,"shapePosition":true}""")
        testCase "editSelection" (fun _ -> config |> jsonFieldIsSetWith "editSelection" "true")
        testCase "autosizable" (fun _ -> config |> jsonFieldIsSetWith "autosizable" "true")
        testCase "responsive" (fun _ -> config |> jsonFieldIsSetWith "responsive" "true")
        testCase "fillFrame" (fun _ -> config |> jsonFieldIsSetWith "fillFrame" "true")
        testCase "frameMargins" (fun _ -> config |> jsonFieldIsSetWith "frameMargins" "1.337")
        testCase "scrollZoom" (fun _ -> config |> jsonFieldIsSetWith "scrollZoom" "true")
        testCase "doubleClick" (fun _ -> config |> jsonFieldIsSetWith "doubleClick" "\"reset\"")
        testCase "doubleClickDelay" (fun _ -> config |> jsonFieldIsSetWith "doubleClickDelay" "1337")
        testCase "showAxisDragHandles" (fun _ -> config |> jsonFieldIsSetWith "showAxisDragHandles" "true")
        testCase "showAxisRangeEntryBoxes" (fun _ -> config |> jsonFieldIsSetWith "showAxisRangeEntryBoxes" "true")
        testCase "showTips" (fun _ -> config |> jsonFieldIsSetWith "showTips" "true")
        testCase "showLink" (fun _ -> config |> jsonFieldIsSetWith "showLink" "true")
        testCase "linkText" (fun _ -> config |> jsonFieldIsSetWith "linkText" "\"never gonna give you up\"")
        testCase "sendData" (fun _ -> config |> jsonFieldIsSetWith "sendData" "true")
        testCase "showSources" (fun _ -> config |> jsonFieldIsSetWith "showSources" "true")
        testCase "displayModeBar" (fun _ -> config |> jsonFieldIsSetWith "displayModeBar" "true")
        testCase "showSendToCloud" (fun _ -> config |> jsonFieldIsSetWith "showSendToCloud" "true")
        testCase "showEditInChartStudio" (fun _ -> config |> jsonFieldIsSetWith "showEditInChartStudio" "true")
        testCase "modeBarButtonsToRemove" (fun _ -> config |> jsonFieldIsSetWith "modeBarButtonsToRemove" """["autoScale2d"]""")
        testCase "modeBarButtonsToAdd" (fun _ -> config |> jsonFieldIsSetWith "modeBarButtonsToAdd" """["drawcircle"]""")
        testCase "modeBarButtons" (fun _ -> config |> jsonFieldIsSetWith "modeBarButtons" """[["drawclosedpath","drawopenpath"],["orbitRotation"]]""")
        testCase "toImageButtonOptions" (fun _ -> config |> jsonFieldIsSetWith "toImageButtonOptions" """{"format":"svg","filename":"soos.svg"}""")
        testCase "displaylogo" (fun _ -> config |> jsonFieldIsSetWith "displaylogo" "true")
        testCase "watermark" (fun _ -> config |> jsonFieldIsSetWith "watermark" "true")
        testCase "plotGlPixelRatio" (fun _ -> config |> jsonFieldIsSetWith "plotGlPixelRatio" "1.0")
        testCase "setBackground" (fun _ -> config |> jsonFieldIsSetWith "setBackground" "\"function(x) => {return x}\"")
        testCase "topojsonURL" (fun _ -> config |> jsonFieldIsSetWith "topojsonURL" "\"myserver.me.meme\"")
        testCase "mapboxAccessToken" (fun _ -> config |> jsonFieldIsSetWith "mapboxAccessToken" "\"4Tw20BlzLT\"")
        testCase "logging" (fun _ -> config |> jsonFieldIsSetWith "logging" "2")
        testCase "notifyOnLogging" (fun _ -> config |> jsonFieldIsSetWith "notifyOnLogging" "2")
        testCase "queueLength" (fun _ -> config |> jsonFieldIsSetWith "queueLength" "1337")
        testCase "globalTransforms" (fun _ -> config |> jsonFieldIsSetWith "globalTransforms" "\"function(x) => {return x}\"")
        testCase "locale" (fun _ -> config |> jsonFieldIsSetWith "locale" "\"de-DE\"")
        testCase "locales" (fun _ -> config |> jsonFieldIsSetWith "locales" """{"yes":"no"}""")
    ]


let combined = 
    Config.combine 
        (Config.init(
            ModeBarButtonsToRemove = [StyleParam.ModeBarButton.AutoScale2d],
            ModeBarButtonsToAdd = [StyleParam.ModeBarButton.DrawCircle],
            ModeBarButtons = [[StyleParam.ModeBarButton.DrawClosedPath; StyleParam.ModeBarButton.DrawOpenPath]]
        )) 
        (Config.init(
            ModeBarButtonsToRemove = [StyleParam.ModeBarButton.DrawCircle],
            ModeBarButtonsToAdd = [StyleParam.ModeBarButton.AutoScale2d],
            ModeBarButtons = [[StyleParam.ModeBarButton.OrbitRotation]]
        ))

let expectedCombined = 
    Config.init(
        ModeBarButtonsToRemove = [StyleParam.ModeBarButton.AutoScale2d; StyleParam.ModeBarButton.DrawCircle],
        ModeBarButtonsToAdd = [StyleParam.ModeBarButton.DrawCircle; StyleParam.ModeBarButton.AutoScale2d],
        ModeBarButtons = [[StyleParam.ModeBarButton.DrawClosedPath; StyleParam.ModeBarButton.DrawOpenPath];[StyleParam.ModeBarButton.OrbitRotation]]
    )

[<Tests>]
let ``Config API tests`` =
    testList "ConfigObjects.Config API" [
        testCase "combine ModeBarButtonsToRemove" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<string>>("modeBarButtonsToRemove")).Value
                (expectedCombined.TryGetTypedValue<seq<string>>("modeBarButtonsToRemove")).Value
                "Config.combine did not return the correct object"
        )         
        testCase "combine ModeBarButtonsToAdd" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<string>>("modeBarButtonsToAdd")).Value
                (expectedCombined.TryGetTypedValue<seq<string>>("modeBarButtonsToAdd")).Value
                "Config.combine did not return the correct object"
        )         
        testCase "combine ModeBarButtons" (fun _ -> 
            Expect.sequenceEqual 
                (Seq.concat (combined.TryGetTypedValue<seq<seq<string>>>("modeBarButtons")).Value)
                (Seq.concat (expectedCombined.TryGetTypedValue<seq<seq<string>>>("modeBarButtons")).Value)
                "Config.combine did not return the correct object"
        ) 
    ]