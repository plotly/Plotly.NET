namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Distribution =
    [<Extension>]
    type Chart =
        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="X">Sets the x sample data or coordinates</param>
        /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y sample data or coordinates</param>
        /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                Outline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (?Color = OutlineColor, ?Width = OutlineWidth)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor)


            Trace2D.initBoxPlot (
                Trace2DStyle.BoxPlot(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?WhiskerWidth = WhiskerWidth,
                    ?BoxPoints = BoxPoints,
                    ?BoxMean = BoxMean,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Orientation = Orientation,
                    ?FillColor = FillColor,
                    Marker = marker,
                    Line = outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Notched = Notched,
                    ?NotchWidth = NotchWidth,
                    ?QuartileMethod = QuartileMethod,
                    ?SizeMode = SizeMode
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="data">Sets the sample data or coordinates</param>
        /// <param name="orientation">Sets the orientation of the box.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let boxplot =
                Chart.BoxPlot(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?MarkerColor = MarkerColor,
                    ?Marker = Marker,
                    ?Opacity = Opacity,
                    ?WhiskerWidth = WhiskerWidth,
                    ?BoxPoints = BoxPoints,
                    ?BoxMean = BoxMean,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?OutlineColor = OutlineColor,
                    ?OutlineWidth = OutlineWidth,
                    ?Outline = Outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Notched = Notched,
                    ?NotchWidth = NotchWidth,
                    ?QuartileMethod = QuartileMethod,
                    ?SizeMode = SizeMode,
                    ?UseDefaults = UseDefaults
                )

            match orientation with
            | StyleParam.Orientation.Horizontal -> boxplot |> GenericChart.mapTrace (Trace2DStyle.BoxPlot(X = data))
            | StyleParam.Orientation.Vertical -> boxplot |> GenericChart.mapTrace (Trace2DStyle.BoxPlot(Y = data))

        /// <summary>
        /// Visualizes the distribution of the input data as a box plot using an encoded typed array.
        /// </summary>
        /// <param name="dataEncoded">Sets the sample data or coordinates as an encoded typed array.</param>
        /// <param name="orientation">Sets the orientation of the box.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box.</param>
        /// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width.</param>
        /// <param name="BoxPoints">Controls which sample points are shown.</param>
        /// <param name="BoxMean">Controls whether and how the mean is displayed.</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn.</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width.</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles.</param>
        /// <param name="SizeMode">Sets how box sizes are derived.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                dataEncoded: EncodedTypedArray,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let boxplot =
                Chart.BoxPlot(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?MarkerColor = MarkerColor,
                    ?Marker = Marker,
                    ?Opacity = Opacity,
                    ?WhiskerWidth = WhiskerWidth,
                    ?BoxPoints = BoxPoints,
                    ?BoxMean = BoxMean,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?OutlineColor = OutlineColor,
                    ?OutlineWidth = OutlineWidth,
                    ?Outline = Outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Notched = Notched,
                    ?NotchWidth = NotchWidth,
                    ?QuartileMethod = QuartileMethod,
                    ?SizeMode = SizeMode,
                    ?UseDefaults = UseDefaults
                )

            match orientation with
            | StyleParam.Orientation.Horizontal -> boxplot |> GenericChart.mapTrace (Trace2DStyle.BoxPlot(XEncoded = dataEncoded))
            | StyleParam.Orientation.Vertical -> boxplot |> GenericChart.mapTrace (Trace2DStyle.BoxPlot(YEncoded = dataEncoded))


        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="xy">Sets the xy sample data or coordinate pairs</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.BoxPlot(
                X = x,
                Y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?FillColor = FillColor,
                ?MarkerColor = MarkerColor,
                ?Marker = Marker,
                ?Opacity = Opacity,
                ?WhiskerWidth = WhiskerWidth,
                ?BoxPoints = BoxPoints,
                ?BoxMean = BoxMean,
                ?Jitter = Jitter,
                ?PointPos = PointPos,
                ?Orientation = Orientation,
                ?OutlineColor = OutlineColor,
                ?OutlineWidth = OutlineWidth,
                ?Outline = Outline,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?Notched = Notched,
                ?NotchWidth = NotchWidth,
                ?QuartileMethod = QuartileMethod,
                ?SizeMode = SizeMode,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="X">Sets the x sample data or coordinates</param>
        /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y sample data or coordinates</param>
        /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let box =
                Box
                |> Option.defaultValue (TraceObjects.Box.init ())
                |> TraceObjects.Box.style (?Visible = ShowBox, ?Width = BoxWidth, ?FillColor = BoxFillColor)

            let outline =
                Outline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (?Color = OutlineColor, ?Width = OutlineWidth)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor)

            Trace2D.initViolin (
                Trace2DStyle.Violin(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?Points = Points,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Orientation = Orientation,
                    ?Width = Width,
                    Marker = marker,
                    Line = outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    Box = box,
                    ?BandWidth = BandWidth,
                    ?MeanLine = MeanLine,
                    ?ScaleGroup = ScaleGroup,
                    ?ScaleMode = ScaleMode,
                    ?Side = Side,
                    ?Span = Span,
                    ?SpanMode = SpanMode
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="data">Sets the sample data or coordinate pairs</param>
        /// <param name="orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let violin =
                Chart.Violin(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?Opacity = Opacity,
                    ?Points = Points,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Width = Width,
                    ?MarkerColor = MarkerColor,
                    ?Marker = Marker,
                    ?OutlineColor = OutlineColor,
                    ?OutlineWidth = OutlineWidth,
                    ?Outline = Outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?ShowBox = ShowBox,
                    ?BoxWidth = BoxWidth,
                    ?BoxFillColor = BoxFillColor,
                    ?Box = Box,
                    ?BandWidth = BandWidth,
                    ?MeanLine = MeanLine,
                    ?ScaleGroup = ScaleGroup,
                    ?ScaleMode = ScaleMode,
                    ?Side = Side,
                    ?Span = Span,
                    ?SpanMode = SpanMode,
                    ?UseDefaults = UseDefaults
                )

            match orientation with
            | StyleParam.Orientation.Horizontal -> violin |> GenericChart.mapTrace (Trace2DStyle.Violin(X = data))
            | StyleParam.Orientation.Vertical -> violin |> GenericChart.mapTrace (Trace2DStyle.Violin(Y = data))

        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot using an encoded typed array.
        /// </summary>
        /// <param name="dataEncoded">Sets the sample data or coordinates as an encoded typed array.</param>
        /// <param name="orientation">Sets the orientation of the violin(s).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Points">Controls which sample points are shown.</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn.</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es).</param>
        /// <param name="Width">Sets the width of the violin in data coordinates.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin.</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot.</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">Links violins that should be sized according to the same metric.</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined.</param>
        /// <param name="Side">Determines on which side of the position value one half of a violin is plotted.</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed.</param>
        /// <param name="SpanMode">Sets the method by which the span in data space is computed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                dataEncoded: EncodedTypedArray,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let violin =
                Chart.Violin(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?Opacity = Opacity,
                    ?Points = Points,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Width = Width,
                    ?MarkerColor = MarkerColor,
                    ?Marker = Marker,
                    ?OutlineColor = OutlineColor,
                    ?OutlineWidth = OutlineWidth,
                    ?Outline = Outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?ShowBox = ShowBox,
                    ?BoxWidth = BoxWidth,
                    ?BoxFillColor = BoxFillColor,
                    ?Box = Box,
                    ?BandWidth = BandWidth,
                    ?MeanLine = MeanLine,
                    ?ScaleGroup = ScaleGroup,
                    ?ScaleMode = ScaleMode,
                    ?Side = Side,
                    ?Span = Span,
                    ?SpanMode = SpanMode,
                    ?UseDefaults = UseDefaults
                )

            match orientation with
            | StyleParam.Orientation.Horizontal -> violin |> GenericChart.mapTrace (Trace2DStyle.Violin(XEncoded = dataEncoded))
            | StyleParam.Orientation.Vertical -> violin |> GenericChart.mapTrace (Trace2DStyle.Violin(YEncoded = dataEncoded))

        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="xy">Sets the xy sample data or coordinate pairs</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Violin(
                X = x,
                Y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?FillColor = FillColor,
                ?Opacity = Opacity,
                ?Points = Points,
                ?Jitter = Jitter,
                ?PointPos = PointPos,
                ?Orientation = Orientation,
                ?Width = Width,
                ?MarkerColor = MarkerColor,
                ?Marker = Marker,
                ?OutlineColor = OutlineColor,
                ?OutlineWidth = OutlineWidth,
                ?Outline = Outline,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?ShowBox = ShowBox,
                ?BoxWidth = BoxWidth,
                ?BoxFillColor = BoxFillColor,
                ?Box = Box,
                ?BandWidth = BandWidth,
                ?MeanLine = MeanLine,
                ?ScaleGroup = ScaleGroup,
                ?ScaleMode = ScaleMode,
                ?Side = Side,
                ?Span = Span,
                ?SpanMode = SpanMode,
                ?UseDefaults = UseDefaults
            )


