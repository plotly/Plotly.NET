namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Splom =
    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a scatter plot matrix (SPLOM) from multiple input dimensions.
        ///
        /// Each splom `dimensions` items correspond to a generated axis. Values for each of those dimensions are set in `dimensions[i].values`. Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
        /// </summary>
        /// <param name="dimensions">Sets the dimensions of the scatter plot matrix, where each item corresponds to a generated axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the marker.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
        /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
        /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
        /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
        /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
        /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Splom
            (
                dimensions: seq<Dimension>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?ShowDiagonal: bool,
                ?Diagonal: SplomDiagonal,
                ?ShowLowerHalf: bool,
                ?ShowUpperHalf: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale
                )

            let diagonal =
                Diagonal
                |> Option.defaultValue (TraceObjects.SplomDiagonal.init ())
                |> TraceObjects.SplomDiagonal.style (?Visible = ShowDiagonal)

            Trace2D.initSplom (
                Trace2DStyle.Splom(
                    Dimensions = dimensions,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    Marker = marker,
                    Diagonal = diagonal,
                    ?ShowLowerHalf = ShowLowerHalf,
                    ?ShowUpperHalf = ShowUpperHalf
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a scatter plot matrix (SPLOM) from multiple input dimensions.
        ///
        /// Each splom `dimensions` items correspond to a generated axis. Values for each of those dimensions are set in `dimensions[i].values`. Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
        /// </summary>
        /// <param name="keyValues">Sets the dimensions of the scatter plot matrix as (dimensionKey,dimensionValues) pairs, where each such pair corresponds to a generated axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the marker.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
        /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
        /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
        /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
        /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
        /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Splom
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?ShowDiagonal: bool,
                ?Diagonal: SplomDiagonal,
                ?ShowLowerHalf: bool,
                ?ShowUpperHalf: bool,
                ?UseDefaults: bool
            ) =

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initSplom (Label = key, Values = vals))

            Chart.Splom(
                dims,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?ShowDiagonal = ShowDiagonal,
                ?Diagonal = Diagonal,
                ?ShowLowerHalf = ShowLowerHalf,
                ?ShowUpperHalf = ShowUpperHalf,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a scatter plot matrix (SPLOM) from multiple encoded input dimensions.
        ///
        /// Each splom dimension is provided as a pair of a dimension label and an encoded typed array containing that dimension's values.
        /// Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
        /// </summary>
        /// <param name="keyValuesEncoded">Sets the dimensions of the scatter plot matrix as (dimensionKey, encodedDimensionValues) pairs, where each such pair corresponds to a generated axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the marker.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
        /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
        /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
        /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
        /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
        /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Splom
            (
                keyValuesEncoded: seq<string * EncodedTypedArray>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?ShowDiagonal: bool,
                ?Diagonal: SplomDiagonal,
                ?ShowLowerHalf: bool,
                ?ShowUpperHalf: bool,
                ?UseDefaults: bool
            ) =

            let dims =
                keyValuesEncoded
                |> Seq.map (fun (key, encodedVals) -> Dimension.initSplom (Label = key, ValuesEncoded = encodedVals))

            Chart.Splom(
                dims,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?ShowDiagonal = ShowDiagonal,
                ?Diagonal = Diagonal,
                ?ShowLowerHalf = ShowLowerHalf,
                ?ShowUpperHalf = ShowUpperHalf,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a point density plot - a combination of a Scatter plot and Histogram2DContour.
        ///
        /// Additionally to plotting the (x,y) data as points on a 2D plane, a density contour plot is computed by grouping a set of points specified by their x and y coordinates into bins, and applying a count aggregation function to compute the value to be used to compute contours.
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case). The resulting distribution is visualized as a contour plot.
        ///
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data as well as the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the y coordinates of the plotted data as well as the sample data to be binned on the y axis.</param>
        /// <param name="PointOpacity">Sets the opacity of the point trace.</param>
        /// <param name="PointMarkerColor">Sets the marker color of the point trace.</param>
        /// <param name="PointMarkerSymbol">Sets the marker symbol of the point trace.</param>
        /// <param name="PointMarkerSize">Sets the marker size of the point trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="ContourOpacity">Sets the opacity of the histogram2dcontour trace.</param>
        /// <param name="ColorBar">Sets the color bar.</param>
        /// <param name="ColorScale">Sets the colorscale of the histogram2dcontour trace.</param>
        /// <param name="ShowScale">whether or not to show the colorbar</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointDensity
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?PointOpacity: float,
                ?PointMarkerColor: Color,
                ?PointMarkerSymbol: StyleParam.MarkerSymbol,
                ?PointMarkerSize: int,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?NContours: int,
                ?HistNorm: StyleParam.HistNorm,
                ?ContourOpacity: float,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?UseDefaults: bool
            ) =

            let showContourLines =
                defaultArg ShowContourLines false

            let pointOpacity =
                defaultArg PointOpacity 0.3

            let contoursColoring =
                defaultArg ContoursColoring StyleParam.ContourColoring.Fill

            let useDefaults =
                defaultArg UseDefaults true

            let contourLinesWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let marker =
                Marker.init (?Color = PointMarkerColor, ?Symbol = PointMarkerSymbol, ?Size = PointMarkerSize)

            let pointTrace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = y,
                        Mode = StyleParam.Mode.Markers,
                        Marker = marker,
                        Opacity = pointOpacity
                    )
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLinesWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    Coloring = contoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let densityContourTrace =
                Trace2D.initHistogram2DContour (
                    Trace2DStyle.Histogram2DContour(
                        X = x,
                        Y = y,
                        Contours = contours,
                        Line = contourLines,
                        ?NContours = NContours,
                        ?ColorBar = ColorBar,
                        ?ColorScale = ColorScale,
                        ?ShowScale = ShowScale,
                        ?HistNorm = HistNorm,
                        ?Opacity = ContourOpacity
                    )
                )

            [
                densityContourTrace :> Trace
                pointTrace :> Trace
            ]
            |> GenericChart.ofTraceObjects useDefaults

        /// <summary>Creates a point density plot from encoded x and y coordinates.</summary>
        [<Extension>]
        static member PointDensity
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?PointOpacity: float,
                ?PointMarkerColor: Color,
                ?PointMarkerSymbol: StyleParam.MarkerSymbol,
                ?PointMarkerSize: int,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?NContours: int,
                ?HistNorm: StyleParam.HistNorm,
                ?ContourOpacity: float,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?UseDefaults: bool
            ) =

            let showContourLines =
                defaultArg ShowContourLines false

            let pointOpacity =
                defaultArg PointOpacity 0.3

            let contoursColoring =
                defaultArg ContoursColoring StyleParam.ContourColoring.Fill

            let useDefaults =
                defaultArg UseDefaults true

            let contourLinesWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let marker =
                Marker.init (?Color = PointMarkerColor, ?Symbol = PointMarkerSymbol, ?Size = PointMarkerSize)

            let pointTrace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        XEncoded = xEncoded,
                        YEncoded = yEncoded,
                        Mode = StyleParam.Mode.Markers,
                        Marker = marker,
                        Opacity = pointOpacity
                    )
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLinesWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    Coloring = contoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let densityContourTrace =
                Trace2D.initHistogram2DContour (
                    Trace2DStyle.Histogram2DContour(
                        XEncoded = xEncoded,
                        YEncoded = yEncoded,
                        Contours = contours,
                        Line = contourLines,
                        ?NContours = NContours,
                        ?ColorBar = ColorBar,
                        ?ColorScale = ColorScale,
                        ?ShowScale = ShowScale,
                        ?HistNorm = HistNorm,
                        ?Opacity = ContourOpacity
                    )
                )

            [
                densityContourTrace :> Trace
                pointTrace :> Trace
            ]
            |> GenericChart.ofTraceObjects useDefaults

