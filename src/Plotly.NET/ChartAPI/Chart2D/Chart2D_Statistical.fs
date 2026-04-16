namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Statistical =
    [<Extension>]
    type Chart =
        /// <summary> Creates a Pareto chart. </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Label">Sets the y axis label.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
        [<Extension>]
        static member Pareto
            (
                keysValues: seq<#IConvertible * float>
                , ?Name: string
                , ?Label: string
                , ?ShowGrid: bool
            ) =
            let orderedLabels, orderedValues =
                keysValues
                |> Seq.sortByDescending snd
                |> Seq.unzip
               
            let sum = orderedValues |> Seq.sum
            let topPaddingRatio = 0.05
            let cumulativeSum = 
                Seq.scan (+) 0. orderedValues
                |> Seq.skip 1
               
            let paretoValues = 
               Seq.zip orderedLabels cumulativeSum
               |> Seq.map (fun (label,value) -> label, value / sum * 100.) 
               
            let bars = Chart.Column(Seq.zip orderedLabels orderedValues,?Name=Name)
            
            let lines = 
                Chart.Line(
                    paretoValues
                    , Name        = "Cumulative %"
                    , ShowLegend  = true
                    , ShowMarkers = true
                    , Marker      = Marker.init(Size = 8, Symbol = StyleParam.MarkerSymbol.Cross, Angle = 45.)
                ) 
                |> Chart.withAxisAnchor (Y = 2)
                   
            [bars;lines] 
            |> Chart.combine 
            |> Chart.withYAxisStyle (
                    ?TitleText = Label
                    , Id       = StyleParam.SubPlotId.YAxis 1
                    , ShowGrid = false
                    , MinMax   = (0.,sum * (1.+topPaddingRatio))
                )
            |> Chart.withYAxisStyle (
                    TitleText    = "%"
                    , Side       = StyleParam.Side.Right
                    , Id         = StyleParam.SubPlotId.YAxis 2
                    , MinMax     = (0.,100. * (1.+topPaddingRatio))
                    , Overlaying = StyleParam.LinearAxisId.Y 1
                    , ?ShowGrid  = ShowGrid
                )     
            
        /// <summary> Creates a Pareto chart. </summary>
        /// <param name="labels">Sets the labels that are matching the <see paramref="values"/>.</param>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Label">Sets the y axis label.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
        static member Pareto
            (
                labels: seq<#IConvertible>
                , values: seq<float>
                , ?Name: string
                , ?Label: string
                , ?ShowGrid: bool
            ) =
            Chart.Pareto(Seq.zip labels values, ?Name=Name, ?Label=Label, ?ShowGrid=ShowGrid)

        /// <summary>Displays a residue Chart by displaying the y values in relation to the provided reference Values. </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data for the Y value.</param>
        /// <param name="reference">Sets the y coordinates for reference Y value.</param>
        /// <param name="Name">Sets the trace name of the Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="ReferenceName">Sets the trace name of the reference Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="LegendGroupData">Sets the name of the legendgroup for the data distribution trace of this plot.</param>
        /// <param name="LegendGroupReference">Sets the name of the legendgroup for the reference trace of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the Y values.</param>
        /// <param name="MarkerSize">Sets the size of the datapoint markers for the Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the Y values.</param>
        /// <param name="ShowReference">Sets if the reference Line should be visible.</param>
        /// <param name="ReferenceLine">Sets the line (use this for more finegrained control than the other line-associated arguments) for the reference Y values.</param>
        /// <param name="ReferenceWidth">Sets the width of the line for the reference Y values.</param>
        /// <param name="ReferenceColor">Sets the color of the line for the reference Y values.</param>
        /// <param name="ReferenceText">Sets a text associated with each datum for the reference Y values.</param>
        /// <param name="MultiReferenceText">Sets individual text for each datum for the reference Y values.</param>
        /// <param name="ReferenceTextPosition">Sets the position of text associated with each reference datum.</param>
        /// <param name="MultiReferenceTextPosition">Sets the position of text associated with each individual reference datum</param>
        /// <param name="TextFont">Sets the font used for `text` in Text.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Residual
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                reference: seq<#IConvertible>,
                ?Name: string,
                ?ReferenceName: string,
                ?LegendGroupData: string,
                ?LegendGroupReference: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?MarkerSize: int,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?ShowReference: bool,
                ?ReferenceLine: Line,
                ?ReferenceWidth: int,
                ?ReferenceColor: Color,
                ?ReferenceText: #IConvertible,
                ?MultiReferenceText: seq<#IConvertible>,
                ?ReferenceTextPosition: StyleParam.TextPosition,
                ?MultiReferenceTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let referenceName = defaultArg ReferenceName "Reference Line"

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let showReference = 
                let showBool = 
                    match ShowReference with
                    | Some showRef   -> showRef
                    | None                  -> true
                if showBool then 
                    StyleParam.Visible.True
                else
                    StyleParam.Visible.False

            let markerSize = defaultArg MarkerSize 10
            
            let (data,pointS) = 
                Seq.zip3 x y reference
                |> Seq.collect(fun (x,y,refV) ->
                    [
                        (x,refV),0
                        (x,y),markerSize
                        (x,refV),0
                    ]
                )
                |> Array.ofSeq
                |> Array.unzip
 
            let (x1,y1) = Array.unzip data
            
            let marker = 
                defaultArg 
                    Marker 
                    (TraceObjects.Marker.init(
                        MultiSize=pointS,
                        Opacity=1.,
                        ?Color = MarkerColor,
                        ?Colorscale = MarkerColorScale,
                        ?Outline = MarkerOutline,
                        ?Symbol = MarkerSymbol,
                        ?MultiSymbol = MultiMarkerSymbol
                    ))

            let trace =
                Chart.Scatter(
                    x = x1,
                    y = y1,
                    mode = changeMode StyleParam.Mode.Lines_Markers,
                    Opacity = 1.,
                    Marker = marker,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?LineColor = LineColor,
                    ?LineColorScale = LineColorScale,
                    ?LineWidth = LineWidth,
                    ?LineDash = LineDash,
                    ?Line = Line
                )
                |> GenericChart.mapTrace (
                    Trace2DStyle.Scatter(
                        ?LegendGroup        = LegendGroupData
                    )
                )

            let referenceLine = 
                Trace2D.initScatter(
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = reference,
                        Mode = StyleParam.Mode.Lines,
                        ?Name = Some referenceName,
                        ?Visible = Some showReference,
                        ?ShowLegend = ShowLegend,
                        ?Text = ReferenceText,
                        ?MultiText = MultiReferenceText,
                        ?TextPosition = ReferenceTextPosition,
                        ?MultiTextPosition = MultiReferenceTextPosition,
                        ?Line = ReferenceLine,
                        ?LegendGroup        = LegendGroupReference
                    )
                )
                |> TraceStyle.Marker(
                    Color = defaultArg ReferenceColor (Plotly.NET.Color.fromString "rgba(0, 0, 0, 1)"),
                    Size = defaultArg ReferenceWidth 10
                )

            GenericChart.ofTraceObjects
                useDefaults
                [
                    yield! (GenericChart.getTraces trace)
                    referenceLine
                ]


        /// <summary>Displays a residue Chart by displaying the y values in relation to the provided reference Values. </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="reference">Sets the y coordinates for reference Y value.</param>
        /// <param name="Name">Sets the trace name of the Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="ReferenceName">Sets the trace name of the reference Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="LegendGroupData">Sets the name of the legendgroup for the data distribution trace of this plot.</param>
        /// <param name="LegendGroupReference">Sets the name of the legendgroup for the reference trace of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the Y values.</param>
        /// <param name="MarkerSize">Sets the size of the datapoint markers for the Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the Y values.</param>
        /// <param name="ShowReference">Sets if the reference Line should be visible.</param>
        /// <param name="ReferenceLine">Sets the line (use this for more finegrained control than the other line-associated arguments) for the reference Y values.</param>
        /// <param name="ReferenceWidth">Sets the width of the line for the reference Y values.</param>
        /// <param name="ReferenceColor">Sets the color of the line for the reference Y values.</param>
        /// <param name="ReferenceText">Sets a text associated with each datum for the reference Y values.</param>
        /// <param name="MultiReferenceText">Sets individual text for each datum for the reference Y values.</param>
        /// <param name="ReferenceTextPosition">Sets the position of text associated with each reference datum.</param>
        /// <param name="MultiReferenceTextPosition">Sets the position of text associated with each individual reference datum</param>
        /// <param name="TextFont">Sets the font used for `text` in Text.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Residual
            (
                xy: seq<#IConvertible*#IConvertible>,
                reference: seq<#IConvertible>,
                ?Name: string,
                ?ReferenceName: string,
                ?LegendGroupData: string,
                ?LegendGroupReference: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?MarkerSize: int,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?ShowReference: bool,
                ?ReferenceLine: Line,
                ?ReferenceWidth: int,
                ?ReferenceColor: Color,
                ?ReferenceText: #IConvertible,
                ?MultiReferenceText: seq<#IConvertible>,
                ?ReferenceTextPosition: StyleParam.TextPosition,
                ?MultiReferenceTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?UseDefaults: bool
            ) =
            
            let (x,y) = Seq.unzip xy
            Chart.Residual
                (
                    x = x,
                    y = y,
                    reference = reference,
                    ?Name                       = Name,
                    ?ReferenceName              = ReferenceName,
                    ?LegendGroupData            = LegendGroupData,
                    ?LegendGroupReference       = LegendGroupReference,
                    ?ShowMarkers                = ShowMarkers,
                    ?ShowLegend                 = ShowLegend,
                    ?Text                       = Text,
                    ?MultiText                  = MultiText,
                    ?TextPosition               = TextPosition,
                    ?MultiTextPosition          = MultiTextPosition,
                    ?MarkerColor                = MarkerColor,
                    ?MarkerColorScale           = MarkerColorScale,
                    ?MarkerOutline              = MarkerOutline,
                    ?MarkerSymbol               = MarkerSymbol,
                    ?MultiMarkerSymbol          = MultiMarkerSymbol,
                    ?Marker                     = Marker,
                    ?MarkerSize                 = MarkerSize,
                    ?LineColor                  = LineColor,
                    ?LineColorScale             = LineColorScale,
                    ?LineWidth                  = LineWidth,
                    ?LineDash                   = LineDash,
                    ?Line                       = Line,
                    ?ShowReference              = ShowReference,
                    ?ReferenceLine              = ReferenceLine,
                    ?ReferenceWidth             = ReferenceWidth,
                    ?ReferenceColor             = ReferenceColor,
                    ?ReferenceText              = ReferenceText,
                    ?MultiReferenceText         = MultiReferenceText,
                    ?ReferenceTextPosition      = ReferenceTextPosition,
                    ?MultiReferenceTextPosition = MultiReferenceTextPosition,
                    ?TextFont                   = TextFont,
                    ?UseDefaults                = UseDefaults
                )


        /// <summary>Displays a residue Chart by displaying the y values in relation to the provided reference Values. </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="referenceValue">Sets the y coordinate for reference Y value.</param>
        /// <param name="Name">Sets the trace name of the Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="ReferenceName">Sets the trace name of the reference Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="LegendGroupData">Sets the name of the legendgroup for the data distribution trace of this plot.</param>
        /// <param name="LegendGroupReference">Sets the name of the legendgroup for the reference trace of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the Y values.</param>
        /// <param name="MarkerSize">Sets the size of the datapoint markers for the Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the Y values.</param>
        /// <param name="ShowReference">Sets if the reference Line should be visible.</param>
        /// <param name="ReferenceLine">Sets the line (use this for more finegrained control than the other line-associated arguments) for the reference Y values.</param>
        /// <param name="ReferenceWidth">Sets the width of the line for the reference Y values.</param>
        /// <param name="ReferenceColor">Sets the color of the line for the reference Y values.</param>
        /// <param name="ReferenceText">Sets a text associated with each datum for the reference Y values.</param>
        /// <param name="MultiReferenceText">Sets individual text for each datum for the reference Y values.</param>
        /// <param name="ReferenceTextPosition">Sets the position of text associated with each reference datum.</param>
        /// <param name="MultiReferenceTextPosition">Sets the position of text associated with each individual reference datum</param>
        /// <param name="TextFont">Sets the font used for `text` in Text.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Residual
            (
                xy: seq<#IConvertible*#IConvertible>,
                referenceValue: #IConvertible,
                ?Name: string,
                ?ReferenceName: string,
                ?LegendGroupData :string,                
                ?LegendGroupReference :string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?MarkerSize: int,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?ShowReference: bool,
                ?ReferenceLine: Line,
                ?ReferenceWidth: int,
                ?ReferenceColor: Color,
                ?ReferenceText: #IConvertible,
                ?MultiReferenceText: seq<#IConvertible>,
                ?ReferenceTextPosition: StyleParam.TextPosition,
                ?MultiReferenceTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?UseDefaults: bool
            ) =
            
            let (x,y) = Seq.unzip xy
            let reference = Seq.map(fun x -> referenceValue) x
            Chart.Residual
                (
                    x = x,
                    y = y,
                    reference = reference,
                    ?Name                       = Name,
                    ?ReferenceName              = ReferenceName,
                    ?LegendGroupData            = LegendGroupData,
                    ?LegendGroupReference       = LegendGroupReference,    
                    ?ShowMarkers                = ShowMarkers,
                    ?ShowLegend                 = ShowLegend,
                    ?Text                       = Text,
                    ?MultiText                  = MultiText,
                    ?TextPosition               = TextPosition,
                    ?MultiTextPosition          = MultiTextPosition,
                    ?MarkerColor                = MarkerColor,
                    ?MarkerColorScale           = MarkerColorScale,
                    ?MarkerOutline              = MarkerOutline,
                    ?MarkerSymbol               = MarkerSymbol,
                    ?MultiMarkerSymbol          = MultiMarkerSymbol,
                    ?Marker                     = Marker,
                    ?MarkerSize                 = MarkerSize,
                    ?LineColor                  = LineColor,
                    ?LineColorScale             = LineColorScale,
                    ?LineWidth                  = LineWidth,
                    ?LineDash                   = LineDash,
                    ?Line                       = Line,
                    ?ShowReference              = ShowReference,
                    ?ReferenceLine              = ReferenceLine,
                    ?ReferenceWidth             = ReferenceWidth,
                    ?ReferenceColor             = ReferenceColor,
                    ?ReferenceText              = ReferenceText,
                    ?MultiReferenceText         = MultiReferenceText,
                    ?ReferenceTextPosition      = ReferenceTextPosition,
                    ?MultiReferenceTextPosition = MultiReferenceTextPosition,
                    ?TextFont                   = TextFont,
                    ?UseDefaults                = UseDefaults
                )


        /// <summary>
        /// Displays a residue Chart by displaying the y values in relation to the provided reference Values.
        ///
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="referenceValue">Sets the y coordinate for reference Y value.</param>
        /// <param name="Name">Sets the trace name of the Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="ReferenceName">Sets the trace name of the reference Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="LegendGroupData">Sets the name of the legendgroup for the data distribution trace of this plot.</param>
        /// <param name="LegendGroupReference">Sets the name of the legendgroup for the reference trace of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the Y values.</param>
        /// <param name="MarkerSize">Sets the size of the datapoint markers for the Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the Y values.</param>
        /// <param name="ShowReference">Sets if the reference Line should be visible.</param>
        /// <param name="ReferenceLine">Sets the line (use this for more finegrained control than the other line-associated arguments) for the reference Y values.</param>
        /// <param name="ReferenceWidth">Sets the width of the line for the reference Y values.</param>
        /// <param name="ReferenceColor">Sets the color of the line for the reference Y values.</param>
        /// <param name="ReferenceText">Sets a text associated with each datum for the reference Y values.</param>
        /// <param name="MultiReferenceText">Sets individual text for each datum for the reference Y values.</param>
        /// <param name="ReferenceTextPosition">Sets the position of text associated with each reference datum.</param>
        /// <param name="MultiReferenceTextPosition">Sets the position of text associated with each individual reference datum</param>
        /// <param name="TextFont">Sets the font used for `text` in Text.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Residual
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                referenceValue: #IConvertible,
                ?Name: string,
                ?ReferenceName: string,
                ?LegendGroupData: string,
                ?LegendGroupReference: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?MarkerSize: int,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?ShowReference: bool,
                ?ReferenceLine: Line,
                ?ReferenceWidth: int,
                ?ReferenceColor: Color,
                ?ReferenceText: #IConvertible,
                ?MultiReferenceText: seq<#IConvertible>,
                ?ReferenceTextPosition: StyleParam.TextPosition,
                ?MultiReferenceTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?UseDefaults: bool
            ) =
            
            let reference = Seq.map(fun x -> referenceValue) x
            Chart.Residual
                (
                    x = x,
                    y = y,
                    reference = reference,
                    ?Name                       = Name,
                    ?ReferenceName              = ReferenceName,
                    ?LegendGroupData            = LegendGroupData,    
                    ?LegendGroupReference       = LegendGroupReference,        
                    ?ShowMarkers                = ShowMarkers,
                    ?ShowLegend                 = ShowLegend,
                    ?Text                       = Text,
                    ?MultiText                  = MultiText,
                    ?TextPosition               = TextPosition,
                    ?MultiTextPosition          = MultiTextPosition,
                    ?MarkerColor                = MarkerColor,
                    ?MarkerColorScale           = MarkerColorScale,
                    ?MarkerOutline              = MarkerOutline,
                    ?MarkerSymbol               = MarkerSymbol,
                    ?MultiMarkerSymbol          = MultiMarkerSymbol,
                    ?Marker                     = Marker,
                    ?MarkerSize                 = MarkerSize,
                    ?LineColor                  = LineColor,
                    ?LineColorScale             = LineColorScale,
                    ?LineWidth                  = LineWidth,
                    ?LineDash                   = LineDash,
                    ?Line                       = Line,
                    ?ShowReference              = ShowReference,
                    ?ReferenceLine              = ReferenceLine,
                    ?ReferenceWidth             = ReferenceWidth,
                    ?ReferenceColor             = ReferenceColor,
                    ?ReferenceText              = ReferenceText,
                    ?MultiReferenceText         = MultiReferenceText,
                    ?ReferenceTextPosition      = ReferenceTextPosition,
                    ?MultiReferenceTextPosition = MultiReferenceTextPosition,
                    ?TextFont                   = TextFont,
                    ?UseDefaults                = UseDefaults
                )
