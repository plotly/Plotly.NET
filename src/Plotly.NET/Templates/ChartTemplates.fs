namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open DynamicObj.Operators
open System.Runtime.InteropServices

module ChartTemplates =
    
    /// A colorway is an array of colors that contains the default colors for traces
    module ColorWays = 
           
        let plotly = Color.fromColors[|
            Color.fromHex "#636efa"
            Color.fromHex "#EF553B" 
            Color.fromHex "#00cc96"
            Color.fromHex "#ab63fa"
            Color.fromHex "#FFA15A"
            Color.fromHex "#19d3f3"
            Color.fromHex "#FF6692"
            Color.fromHex "#B6E880"
            Color.fromHex "#FF97FF"
            Color.fromHex "#FECB52"
        |]

        let fslab = Color.fromColors[|
            Color.fromHex "#A00975" // darkmagenta
            Color.fromHex "#D12F67" // rose
            Color.fromHex "#44d57f" // green
            Color.fromHex "#438AFE" // aquamarine
            Color.fromHex "#d59a1b" // dark yellow
            Color.fromHex "#F99BDE" // lightmagenta
            Color.fromHex "#ff9b9b" // light rose
            Color.fromHex "#c6ffdd" // light green
            Color.fromHex "#00d4ff" // light aquamarine
            Color.fromHex "#d2c572" // yellow
        |]

    let light = 
        let initLightAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = Color.fromString "white",
                PlotBGColor =  Color.fromString "white"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initLightAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initLightAxisTemplate()))

        Template.init(defaultLayout)

    let lightMirrored = 
        let initLightAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true,
                Mirror   =      StyleParam.Mirror.All,
                Ticks    =      StyleParam.TickOptions.Inside
                //Showgrid =      false
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = Color.fromString "white",
                PlotBGColor =  Color.fromString "white"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initLightAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initLightAxisTemplate()))

        Template.init(defaultLayout)

    let dark = 

        let initDarkAxisTemplate() =
            LinearAxis.init(
                LineColor = Color.fromString "rgb(204, 204, 204)", 
                ZeroLineColor = Color.fromString "rgb(204, 204, 204)",
                GridColor = Color.fromString "rgba(204, 204, 204, 0.3)",
                TickColor = Color.fromString"rgba(204, 204, 204, 0.5)",
                Ticks     = StyleParam.TickOptions.Inside,
                ShowLine  = true,
                ZeroLine  = true
            )

        let darkLayoutTemplate =
            Layout.init(
                PaperBGColor = Color.fromString "rgb(55, 55, 61)",
                PlotBGColor= Color.fromString "rgb(55, 55, 61)",
                Font = Font.init(Color = Color.fromString "rgb(204, 204, 204)")
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initDarkAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initDarkAxisTemplate()))

        Template.init(darkLayoutTemplate)

    let darkMirrored =
        dark
        |> Template.mapLayoutTemplate (fun l ->
            l.TryGetTypedValue<LinearAxis>("xaxis")
            |> Option.map (LinearAxis.style (Mirror=StyleParam.Mirror.AllTicks))
            |> DynObj.setValueOpt l "xaxis"

            l.TryGetTypedValue<LinearAxis>("yaxis")
            |> Option.map (LinearAxis.style (Mirror=StyleParam.Mirror.AllTicks))
            |> DynObj.setValueOpt l "yaxis"

            l
        )

    let fslab = 

        let initFslabAxisTemplate() =
            LinearAxis.init(
                LineColor = Color.fromString "white", 
                ZeroLineColor = Color.fromString"rgba(67, 138, 254, 0.5)",
                GridColor = Color.fromString "rgba(67, 138, 254, 0.5)",
                TickColor = Color.fromString "rgba(67, 138, 254, 0.5)",
                Ticks     = StyleParam.TickOptions.Inside,
                ShowLine  = true,
                ZeroLine  = true
            )

        let fslabLayoutTemplate =
            Layout.init(
                PaperBGColor = Color.fromString "#200117",
                PlotBGColor  = Color.fromString "#200117",
                Font = Font.init(Color = Color.fromString "white")
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initFslabAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initFslabAxisTemplate()))

        Template.init(fslabLayoutTemplate)
        |> Template.withColorWay ColorWays.fslab


    let transparent = 
        let initTransparentAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = Color.fromString "rgba(255, 255, 255, 0)",
                PlotBGColor =  Color.fromString "rgba(255, 255, 255, 0)"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initTransparentAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initTransparentAxisTemplate()))

        Template.init(defaultLayout)

    let transparentMirrored = 
        let initTransparentAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true,
                Mirror   =      StyleParam.Mirror.All,
                Ticks    =      StyleParam.TickOptions.Inside
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = Color.fromString "rgba(255, 255, 255, 0)",
                PlotBGColor =  Color.fromString "rgba(255, 255, 255, 0)"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initTransparentAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initTransparentAxisTemplate()))

        Template.init(defaultLayout)

    /// the default template, as used in the python lib by default.
    let plotly =

        // non-standard props, may change in the future
        let annotationdefaults = 
            let tmp = DynamicObj() 
            tmp?arrowcolor  <- "#2a3f5f"
            tmp?arrowhead   <- 0
            tmp?arrowwidth  <- 1
            tmp        
            
        let shapedefaults = 
            let tmp = DynamicObj() 
            tmp?line <- Line.init(Color = Color.fromHex "#2a3f5f")
            tmp

        let layoutTempplate = 
            Layout.init(
                AutoTypeNumbers = StyleParam.AutoTypeNumbers.Strict,
                Colorscale = DefaultColorScales.init(
                    Diverging = StyleParam.Colorscale.Custom [
                        0. , "#8e0152"
                        0.1, "#c51b7d"
                        0.2, "#de77ae"
                        0.3, "#f1b6da"
                        0.4, "#fde0ef"
                        0.5, "#f7f7f7"
                        0.6, "#e6f5d0"
                        0.7, "#b8e186"
                        0.8, "#7fbc41"
                        0.9, "#4d9221"
                        1. , "#276419"
                    ],
                    Sequential = StyleParam.Colorscale.Custom [
                        0.0                 , "#0d0887"
                        0.1111111111111111  , "#46039f"
                        0.2222222222222222  , "#7201a8"
                        0.3333333333333333  , "#9c179e"
                        0.4444444444444444  , "#bd3786"
                        0.5555555555555556  , "#d8576b"
                        0.6666666666666666  , "#ed7953"
                        0.7777777777777778  , "#fb9f3a"
                        0.8888888888888888  , "#fdca26"
                        1.0                 , "#f0f921"
                    ],
                    SequentialMinus = StyleParam.Colorscale.Custom [
                        0.0                , "#0d0887"
                        0.1111111111111111 , "#46039f"
                        0.2222222222222222 , "#7201a8"
                        0.3333333333333333 , "#9c179e"
                        0.4444444444444444 , "#bd3786"
                        0.5555555555555556 , "#d8576b"
                        0.6666666666666666 , "#ed7953"
                        0.7777777777777778 , "#fb9f3a"
                        0.8888888888888888 , "#fdca26"
                        1.0                , "#f0f921"
                    ]
                ),
                Font = Font.init(Color = Color.fromHex "#2a3f5f"),
                Hoverlabel = Hoverlabel.init(Align = StyleParam.Align.Left),
                HoverMode = StyleParam.HoverMode.Closest,
                PaperBGColor = Color.fromKeyword White,
                PlotBGColor = Color.fromHex "#E5ECF6",
                Title = Title.init(X = 0.05)
            )
            //set axes/subplot templates (these are no direct Layout props in our model)
            |> Layout.updateColorAxisById(
                StyleParam.SubPlotId.ColorAxis 1,
                ColorAxis.init(ColorBar = ColorBar.init(OutlineWidth=0., Ticks= StyleParam.TickOptions.Empty))
            )
            |> Layout.UpdateGeoById(
                StyleParam.SubPlotId.Geo 1,
                Geo.init(
                    BgColor     = Color.fromKeyword White,
                    LakeColor   = Color.fromKeyword White,
                    LandColor   = Color.fromHex "#E5ECF6",
                    ShowLakes   = true,
                    ShowLand    = true,
                    SubunitColor= Color.fromKeyword White
                )
            )            
            |> Layout.UpdateMapboxById(
                StyleParam.SubPlotId.Mapbox 1,
                Mapbox.init(
                    Style = StyleParam.MapboxStyle.MapboxLight
                )
            )            
            |> Layout.updatePolarById(
                StyleParam.SubPlotId.Polar 1,
                Polar.init(
                    AngularAxis = AngularAxis.init(
                        GridColor = Color.fromKeyword White,
                        LineColor = Color.fromKeyword White,
                        Ticks = StyleParam.TickOptions.Empty
                    ),
                    RadialAxis = RadialAxis.init(
                        GridColor = Color.fromKeyword White,
                        LineColor = Color.fromKeyword White,
                        Ticks = StyleParam.TickOptions.Empty
                    ),
                    BGColor = Color.fromHex "#E5ECF6"
                )
            )
            |> Layout.updateSceneById(
                StyleParam.SubPlotId.Scene 1,
                Scene.init(
                    XAxis = LinearAxis.init(
                        BackgroundColor = Color.fromHex "#E5ECF6",
                        GridColor = Color.fromKeyword White,
                        GridWidth = 2.,
                        LineColor = Color.fromKeyword White,
                        ShowBackground = true,
                        Ticks = StyleParam.TickOptions.Empty,
                        ZeroLineColor = Color.fromKeyword White
                    ),
                    YAxis = LinearAxis.init(
                        BackgroundColor = Color.fromHex "#E5ECF6",
                        GridColor = Color.fromKeyword White,
                        GridWidth = 2.,
                        LineColor = Color.fromKeyword White,
                        ShowBackground = true,
                        Ticks = StyleParam.TickOptions.Empty,
                        ZeroLineColor = Color.fromKeyword White
                    ),
                    ZAxis = LinearAxis.init(
                        BackgroundColor = Color.fromHex "#E5ECF6",
                        GridColor = Color.fromKeyword White,
                        GridWidth = 2.,
                        LineColor = Color.fromKeyword White,
                        ShowBackground = true,
                        Ticks = StyleParam.TickOptions.Empty,
                        ZeroLineColor = Color.fromKeyword White
                    )
                )
            )
            |> Layout.updateTernaryById(
                StyleParam.SubPlotId.Ternary 1,
                Ternary.init(
                    AAxis = LinearAxis.init(
                        GridColor = Color.fromKeyword White,
                        LineColor = Color.fromKeyword White,
                        Ticks = StyleParam.TickOptions.Empty
                    ),
                    BAxis = LinearAxis.init(
                        GridColor = Color.fromKeyword White,
                        LineColor = Color.fromKeyword White,
                        Ticks = StyleParam.TickOptions.Empty
                    ),
                    CAxis = LinearAxis.init(
                        GridColor = Color.fromKeyword White,
                        LineColor = Color.fromKeyword White,
                        Ticks = StyleParam.TickOptions.Empty
                    ),
                    BGColor = Color.fromHex "#E5ECF6"
                )
            )
            |> Layout.UpdateLinearAxisById(
                StyleParam.SubPlotId.XAxis 1,
                LinearAxis.init(
                    AutoMargin = true,
                    GridColor = Color.fromKeyword White,
                    LineColor = Color.fromKeyword White,
                    Ticks = StyleParam.TickOptions.Empty,
                    Title = Title.init(Standoff = 15),
                    ZeroLineColor = Color.fromKeyword White,
                    ZeroLineWidth = 2.
                )
            )            
            |> Layout.UpdateLinearAxisById(
                StyleParam.SubPlotId.YAxis 1,
                LinearAxis.init(
                    AutoMargin = true,
                    GridColor = Color.fromKeyword White,
                    LineColor = Color.fromKeyword White,
                    Ticks = StyleParam.TickOptions.Empty,
                    Title = Title.init(Standoff = 15),
                    ZeroLineColor = Color.fromKeyword White,
                    ZeroLineWidth = 2.
                )
            )
            |> fun l ->
                // set non-standard props
                l?annotationdefaults <- annotationdefaults
                l?shapedefaults <- shapedefaults

                l

        let traceTemplates : Trace list = [
            Trace2D.initBar(Trace2DStyle.Bar(
                ErrorX = Error.init(Color = Color.fromHex "#2a3f5f"),
                ErrorY = Error.init(Color = Color.fromHex "#2a3f5f"),
                Marker = Marker.init(
                    Outline = Line.init(Color = Color.fromHex "#E5ECF6", Width = 0.5),
                    Pattern = Pattern.init(FillMode = StyleParam.PatternFillMode.Overlay, Size = 10, Solidity = 0.2)
                )
            ))

            TracePolar.initBarPolar(TracePolarStyle.BarPolar(
                Marker = Marker.init(
                    Outline = Line.init(Color = Color.fromHex "#E5ECF6", Width = 0.5),
                    Pattern = Pattern.init(FillMode = StyleParam.PatternFillMode.Overlay, Size = 10, Solidity = 0.2)
                )
            ))

            TraceCarpet.initCarpet(TraceCarpetStyle.Carpet(
                AAxis = LinearAxis.initCarpet(
                    EndLineColor    = Color.fromHex "#2a3f5f",
                    GridColor       = Color.fromKeyword White,
                    LineColor       = Color.fromKeyword White,
                    MinorGridColor  = Color.fromKeyword White,
                    StartLineColor  = Color.fromHex "#2a3f5f"
                ),
                BAxis = LinearAxis.initCarpet(
                    EndLineColor    = Color.fromHex "#2a3f5f",
                    GridColor       = Color.fromKeyword White,
                    LineColor       = Color.fromKeyword White,
                    MinorGridColor  = Color.fromKeyword White,
                    StartLineColor  = Color.fromHex "#2a3f5f"
                )
            ))

            TraceGeo.initChoroplethMap(TraceGeoStyle.ChoroplethMap(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                )
            ))

            Trace2D.initContour(Trace2DStyle.Contour(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                ),
                Colorscale = StyleParam.Colorscale.Custom [
                    0.0                , "#0d0887"
                    0.1111111111111111 , "#46039f"
                    0.2222222222222222 , "#7201a8"
                    0.3333333333333333 , "#9c179e"
                    0.4444444444444444 , "#bd3786"
                    0.5555555555555556 , "#d8576b"
                    0.6666666666666666 , "#ed7953"
                    0.7777777777777778 , "#fb9f3a"
                    0.8888888888888888 , "#fdca26"
                    1.0                , "#f0f921"
                ]
            ))
                        
            TraceCarpet.initContourCarpet(TraceCarpetStyle.ContourCarpet(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                )
            ))

            Trace2D.initHeatmap(Trace2DStyle.Heatmap(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                ),
                Colorscale = StyleParam.Colorscale.Custom [
                    0.0                , "#0d0887"
                    0.1111111111111111 , "#46039f"
                    0.2222222222222222 , "#7201a8"
                    0.3333333333333333 , "#9c179e"
                    0.4444444444444444 , "#bd3786"
                    0.5555555555555556 , "#d8576b"
                    0.6666666666666666 , "#ed7953"
                    0.7777777777777778 , "#fb9f3a"
                    0.8888888888888888 , "#fdca26"
                    1.0                , "#f0f921"
                ]
            ))
                        
            Trace2D.initHeatmapGL(Trace2DStyle.Heatmap(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                ),
                Colorscale = StyleParam.Colorscale.Custom [
                    0.0                , "#0d0887"
                    0.1111111111111111 , "#46039f"
                    0.2222222222222222 , "#7201a8"
                    0.3333333333333333 , "#9c179e"
                    0.4444444444444444 , "#bd3786"
                    0.5555555555555556 , "#d8576b"
                    0.6666666666666666 , "#ed7953"
                    0.7777777777777778 , "#fb9f3a"
                    0.8888888888888888 , "#fdca26"
                    1.0                , "#f0f921"
                ]
            ))
                        
            Trace2D.initHistogram(Trace2DStyle.Histogram(
                Marker = Marker.init(
                    Pattern = Pattern.init(FillMode = StyleParam.PatternFillMode.Overlay, Size = 10, Solidity = 0.2)
                )
            ))
                        
            Trace2D.initHistogram2D(Trace2DStyle.Histogram2D(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                ),
                ColorScale = StyleParam.Colorscale.Custom [
                    0.0                , "#0d0887"
                    0.1111111111111111 , "#46039f"
                    0.2222222222222222 , "#7201a8"
                    0.3333333333333333 , "#9c179e"
                    0.4444444444444444 , "#bd3786"
                    0.5555555555555556 , "#d8576b"
                    0.6666666666666666 , "#ed7953"
                    0.7777777777777778 , "#fb9f3a"
                    0.8888888888888888 , "#fdca26"
                    1.0                , "#f0f921"
                ]
            ))

            Trace2D.initHistogram2DContour(Trace2DStyle.Histogram2DContour(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                ),
                ColorScale = StyleParam.Colorscale.Custom [
                    0.0                , "#0d0887"
                    0.1111111111111111 , "#46039f"
                    0.2222222222222222 , "#7201a8"
                    0.3333333333333333 , "#9c179e"
                    0.4444444444444444 , "#bd3786"
                    0.5555555555555556 , "#d8576b"
                    0.6666666666666666 , "#ed7953"
                    0.7777777777777778 , "#fb9f3a"
                    0.8888888888888888 , "#fdca26"
                    1.0                , "#f0f921"
                ]
            ))
            
            Trace3D.initMesh3d(Trace3DStyle.Mesh3d(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                )
            ))  
            

            TraceDomain.initParallelCoord(TraceDomainStyle.ParallelCoord(
                Line = Line.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))
                        
            TraceDomain.initPie(TraceDomainStyle.Pie(
                AutoMargin = true
            ))
            
            Trace2D.initScatter(Trace2DStyle.Scatter(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            Trace3D.initScatter3d(Trace3DStyle.Scatter3d(
                Line = Line.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                ),
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))
            
            TraceCarpet.initScatterCarpet(TraceCarpetStyle.ScatterCarpet(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            TraceGeo.initScatterGeo(TraceGeoStyle.ScatterGeo(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            Trace2D.initScatterGL(Trace2DStyle.Scatter(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            TraceMapbox.initScatterMapbox(TraceMapboxStyle.ScatterMapbox(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            TracePolar.initScatterPolar(TracePolarStyle.ScatterPolar(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            TracePolar.initScatterPolarGL(TracePolarStyle.ScatterPolar(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            TraceTernary.initScatterTernary(TraceTernaryStyle.ScatterTernary(
                Marker = Marker.init(
                    ColorBar = ColorBar.init(
                        OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                    )
                )
            ))

            Trace3D.initSurface(Trace3DStyle.Surface(
                ColorBar = ColorBar.init(
                    OutlineWidth = 0., Ticks = StyleParam.TickOptions.Empty
                ),
                ColorScale = StyleParam.Colorscale.Custom [
                    0.0                , "#0d0887"
                    0.1111111111111111 , "#46039f"
                    0.2222222222222222 , "#7201a8"
                    0.3333333333333333 , "#9c179e"
                    0.4444444444444444 , "#bd3786"
                    0.5555555555555556 , "#d8576b"
                    0.6666666666666666 , "#ed7953"
                    0.7777777777777778 , "#fb9f3a"
                    0.8888888888888888 , "#fdca26"
                    1.0                , "#f0f921"
                ]
            ))
        ]

        Template.init(layoutTempplate,traceTemplates)
        |> Template.withColorWay ColorWays.plotly