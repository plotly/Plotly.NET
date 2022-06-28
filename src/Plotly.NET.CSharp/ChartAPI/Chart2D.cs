using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Scatter<XType,YType,TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            StyleParam.Mode mode,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] Color? MarkerColor,
            [Optional] StyleParam.Colorscale? MarkerColorScale,
            [Optional] Line? MarkerOutline,
            [Optional] StyleParam.MarkerSymbol? MarkerSymbol,
            [Optional] IEnumerable<StyleParam.MarkerSymbol>? MultiMarkerSymbol,
            [Optional] Marker? Marker,
            [Optional] Color? LineColor,
            [Optional] StyleParam.Colorscale? LineColorScale,
            [Optional] double? LineWidth,
            [Optional] StyleParam.DrawingStyle? LineDash,
            [Optional] Line? Line,
            [Optional] string? StackGroup,
            [Optional] StyleParam.Orientation? Orientation,
            [Optional] StyleParam.GroupNorm? GroupNorm,
            [Optional] StyleParam.Fill? Fill,
            [Optional] Color? FillColor,
            [Optional] bool? UseWebGL,
            [Optional] bool? UseDefaults
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Scatter(
                x: x, 
                y: y, 
                mode: mode,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOptionV(),
                Opacity: Opacity.ToOptionV(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOptionV(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                Fill: Fill.ToOption(),
                FillColor: FillColor.ToOption(),
                UseWebGL: UseWebGL.ToOptionV(),
                UseDefaults: UseDefaults.ToOptionV()
            );

        /// <summary>
        /// Creates a Point chart, which uses Points in a 2D space to visualize data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Point<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] Color? MarkerColor,
            [Optional] StyleParam.Colorscale? MarkerColorScale,
            [Optional] Line? MarkerOutline,
            [Optional] StyleParam.MarkerSymbol? MarkerSymbol,
            [Optional] IEnumerable<StyleParam.MarkerSymbol>? MultiMarkerSymbol,
            [Optional] Marker? Marker,
            [Optional] string? StackGroup,
            [Optional] StyleParam.Orientation? Orientation,
            [Optional] StyleParam.GroupNorm? GroupNorm,
            [Optional] bool? UseWebGL,
            [Optional] bool? UseDefaults
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Point(
                x: x,
                y: y,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOptionV(),
                Opacity: Opacity.ToOptionV(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                UseWebGL: UseWebGL.ToOptionV(),
                UseDefaults: UseDefaults.ToOptionV()
            );

        /// <summary> Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Wether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Line<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            [Optional] bool? ShowMarkers,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] Color? MarkerColor,
            [Optional] StyleParam.Colorscale? MarkerColorScale,
            [Optional] Line? MarkerOutline,
            [Optional] StyleParam.MarkerSymbol? MarkerSymbol,
            [Optional] IEnumerable<StyleParam.MarkerSymbol>? MultiMarkerSymbol,
            [Optional] Marker? Marker,
            [Optional] Color? LineColor,
            [Optional] StyleParam.Colorscale? LineColorScale,
            [Optional] double? LineWidth,
            [Optional] StyleParam.DrawingStyle? LineDash,
            [Optional] Line? Line,
            [Optional] string? StackGroup,
            [Optional] StyleParam.Orientation? Orientation,
            [Optional] StyleParam.GroupNorm? GroupNorm,
            [Optional] StyleParam.Fill? Fill,
            [Optional] Color? FillColor,
            [Optional] bool? UseWebGL,
            [Optional] bool? UseDefaults
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Line(
                x: x,
                y: y,
                ShowMarkers: ShowMarkers.ToOptionV(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOptionV(),
                Opacity: Opacity.ToOptionV(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOptionV(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                Fill: Fill.ToOption(),
                FillColor: FillColor.ToOption(),
                UseWebGL: UseWebGL.ToOptionV(),
                UseDefaults: UseDefaults.ToOptionV()
            );

        /// <summary>
        /// Creates a bar chart, with bars plotted horizontally
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Bar<ValuesType, KeysType, TextType>(
            IEnumerable<ValuesType> values, 
            IEnumerable<KeysType>? Keys, 
            [Optional] string? Name, 
            [Optional] bool? ShowLegend, 
            [Optional] double? Opacity, 
            [Optional] IEnumerable<double>? MultiOpacity, 
            [Optional] TextType? Text, 
            [Optional] IEnumerable<TextType>? MultiText, 
            [Optional] Color? MarkerColor, 
            [Optional] StyleParam.Colorscale? MarkerColorScale, 
            [Optional] Line? MarkerOutline, 
            [Optional] StyleParam.PatternShape? MarkerPatternShape, 
            [Optional] IEnumerable<StyleParam.PatternShape>? MultiMarkerPatternShape, 
            [Optional] Pattern? MarkerPattern, 
            [Optional] Marker? Marker,
            [Optional] IConvertible? Base,
            [Optional] IConvertible? Width, 
            [Optional] IEnumerable<IConvertible>? MultiWidth, 
            [Optional] StyleParam.TextPosition? TextPosition, 
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] bool? UseDefaults
        )
            where ValuesType : IConvertible
            where KeysType : IConvertible
            where TextType: IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Bar<ValuesType, KeysType, TextType, IConvertible, IConvertible>(
                    values: values,
                    Keys: Keys.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    UseDefaults: UseDefaults.ToOptionV()
                );
        /// <summary>
        /// Creates a column chart, with bars plotted vertically
        ///
        /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Column<ValuesType, KeysType, TextType>(
            IEnumerable<ValuesType> values,
            [Optional] IEnumerable<KeysType>? Keys,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] Color? MarkerColor,
            [Optional] StyleParam.Colorscale? MarkerColorScale,
            [Optional] Line? MarkerOutline ,
            [Optional] StyleParam.PatternShape? MarkerPatternShape,
            [Optional] IEnumerable<StyleParam.PatternShape>? MultiMarkerPatternShape,
            [Optional] Pattern? MarkerPattern,
            [Optional] Marker? Marker,
            [Optional] ValuesType? Base,
            [Optional] ValuesType? Width,
            [Optional] IEnumerable<ValuesType>? MultiWidth,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] bool? UseDefaults
        )
            where ValuesType : IConvertible
            where KeysType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Column<ValuesType, KeysType, TextType, ValuesType, ValuesType>(
                    values: values,
                    Keys: Keys.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    UseDefaults: UseDefaults.ToOptionV()
                );
        /// <summary>
        /// Visualizes the distribution of the input data as a histogram.
        ///
        /// A histogram is an approximate representation of the distribution of numerical data. To construct a histogram, the first step is to "bin"  the range of values - that is, divide the entire range of values into a series of intervals - and then count how many values fall into each interval.
        /// The bins are usually specified as consecutive, non-overlapping intervals of a variable.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning histograms and in `y` for horizontally spanning histograms. Binning options are set `xbins` and `ybins` respectively if no aggregation data is provided.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="Orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the histogram's bars.</param>
        /// <param name="Marker">Sets the marker for the histogram's bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets wether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Histogram<XType, YType, TextType>(
            [Optional] IEnumerable<XType>? X,
            [Optional] IEnumerable<YType>? Y,
            [Optional] StyleParam.Orientation? Orientation,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] TextType Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.HistFunc? HistFunc,
            [Optional] StyleParam.HistNorm? HistNorm,
            [Optional] string? AlignmentGroup,
            [Optional] string? OffsetGroup,
            [Optional] int? NBinsX,
            [Optional] int? NBinsY,
            [Optional] string? BinGroup,
            [Optional] Bins? XBins,
            [Optional] Bins? YBins,
            [Optional] Color? MarkerColor,
            [Optional] Marker? Marker,
            [Optional] Line? Line,
            [Optional] Error? XError,
            [Optional] Error? YError,
            [Optional] Cumulative? Cumulative,
            [Optional] Hoverlabel? HoverLabel,
            [Optional] bool? UseDefaults
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Histogram<XType, YType, TextType>(
                    X: X.ToOption(),
                    Y: Y.ToOption(),
                    Orientation: Orientation.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    HistFunc: HistFunc.ToOption(),
                    HistNorm: HistNorm.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    NBinsX: NBinsX.ToOptionV(),
                    NBinsY: NBinsY.ToOptionV(),
                    BinGroup: BinGroup.ToOption(),
                    XBins: XBins.ToOption(),
                    YBins: YBins.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    Marker: Marker.ToOption(),
                    Line: Line.ToOption(),
                    XError: XError.ToOption(),
                    YError: YError.ToOption(),
                    Cumulative: Cumulative.ToOption(),
                    HoverLabel: HoverLabel.ToOption(),
                    UseDefaults: UseDefaults.ToOptionV()
                );
    };
}
