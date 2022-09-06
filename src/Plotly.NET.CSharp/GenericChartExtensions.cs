using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    /// <summary>
    /// Extension methods for fluid-style chart styling and creation API.
    /// </summary>
    public static class GenericChartExtensions
    {
        /// <summary>
        /// Returns the layout of the given chart
        /// </summary>
        /// <param name="gChart">The chart of which to get the layout</param>
        public static Plotly.NET.Layout GetLayout(this GenericChart.GenericChart gChart) => GenericChart.getLayout(gChart);

        /// <summary>
        /// Returns all traces of the given chart as an array
        /// </summary>
        /// <param name="gChart">The chart of which to get all traces</param>
        public static Trace [] GetTraces(this GenericChart.GenericChart gChart) => GenericChart.getTraces(gChart).ToArray();

        /// <summary>
        /// Saves the given Chart as html file at the given path (.html file extension is added if not present).
        /// Optionally opens the generated file in the browser.
        /// </summary>
        /// <param name="gChart">The chart to save as html file.</param>
        /// <param name="path">The path to save the chart html at.</param>
        /// <param name="OpenInBrowser">Wether or not to open the generated file in the browser (default: false)</param>
        public static void SaveHtml(
            this GenericChart.GenericChart gChart,
            string path,
            Optional<bool> OpenInBrowser = default
        ) =>
            Plotly.NET.Chart.SaveHtml(
                path: path,
                OpenInBrowser: OpenInBrowser.ToOption()
            ).Invoke(gChart);

        /// <summary>
        /// Saves the given chart as a temporary html file and opens it in the browser.
        /// </summary>
        /// <param name="gChart">The chart to show in the browser</param>
        public static void Show(this GenericChart.GenericChart gChart) => Plotly.NET.Chart.Show(gChart);

        /// <summary>
        /// Sets trace information on the given chart.
        /// </summary>
        /// <param name="gChart">The chart in which to change the trace info</param>
        /// <param name="Name">Sets the name of the chart's trace(s). When the chart is a multichart (it contains multiple traces), the name is suffixed by '_%i' where %i is the index of the trace.</param>
        /// <param name="Visible">Wether or not the chart's traces are visible</param>
        /// <param name="ShowLegend">Determines whether or not item(s) corresponding to this chart's trace(s) is/are shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for the chart's trace(s). Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for the chart's trace(s). Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the title for the chart's trace legend group </param>
        public static GenericChart.GenericChart WithTraceInfo(
            this GenericChart.GenericChart gChart,
            Optional<string> Name = default,
            Optional<StyleParam.Visible> Visible = default,
            Optional<bool> ShowLegend = default,
            Optional<int> LegendRank = default,
            Optional<string> LegendGroup = default,
            Optional<Title> LegendGroupTitle = default
        ) =>
            Plotly.NET.Chart.WithTraceInfo(
                Name: Name.ToOption(),
                Visible: Visible.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                LegendRank: LegendRank.ToOption(),
                LegendGroup: LegendGroup.ToOption(),
                LegendGroupTitle: LegendGroupTitle.ToOption()
            ).Invoke(gChart);

        /// Sets the size of a Chart (in pixels)
        public static GenericChart.GenericChart WithSize(
            this GenericChart.GenericChart gChart,
            Optional<int> Width = default,
            Optional<int> Height = default
        ) =>
            Plotly.NET.Chart.WithSize(Width: Width.ToOption(), Height: Height.ToOption()).Invoke(gChart);

        /// <summary>
        /// Sets the given x axis styles on the input chart's layout.
        ///
        /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
        /// </summary>
        /// <param name="gChart">The chart in which to change the X axis style</param>
        /// <param name="TitleText">Sets the text of the axis title.</param>
        /// <param name="TitleFont">Sets the font of the axis title.</param>
        /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
        /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
        /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
        /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
        /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
        /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
        /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
        /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
        /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
        /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
        /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
        /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
        /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
        /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="RangeSlider">Sets a range slider for this axis</param>
        /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
        /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
        /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
        /// <param name="Id">The target axis id on which the styles should be applied. Default is 1.</param>
        public static GenericChart.GenericChart WithXAxisStyle<MinType, MaxType, CategoryArrayType>(
            this GenericChart.GenericChart gChart,
            Optional<string> TitleText = default,
            Optional<Font> TitleFont = default,
            Optional<int> TitleStandoff = default,
            Optional<Title> Title = default,
            Optional<Color> Color = default,
            Optional<StyleParam.AxisType> AxisType = default,
            Optional<Tuple<MinType, MaxType>> MinMax = default,
            Optional<StyleParam.Mirror> Mirror = default,
            Optional<bool> ShowSpikes = default,
            Optional<Color> SpikeColor = default,
            Optional<int> SpikeThickness = default,
            Optional<bool> ShowLine = default,
            Optional<Color> LineColor = default,
            Optional<bool> ShowGrid = default,
            Optional<Color> GridColor = default,
            Optional<bool> ZeroLine = default,
            Optional<Color> ZeroLineColor = default,
            Optional<StyleParam.LinearAxisId> Anchor = default,
            Optional<StyleParam.Side> Side = default,
            Optional<StyleParam.LinearAxisId> Overlaying = default,
            Optional<Tuple<double, double>> Domain = default,
            Optional<double> Position = default,
            Optional<StyleParam.CategoryOrder> CategoryOrder = default,
            Optional<IEnumerable<CategoryArrayType>> CategoryArray = default,
            Optional<RangeSlider> RangeSlider = default,
            Optional<RangeSelector> RangeSelector = default,
            Optional<Color> BackgroundColor = default,
            Optional<bool> ShowBackground = default,
            Optional<StyleParam.SubPlotId> Id = default
        )
            where MinType : IConvertible
            where MaxType : IConvertible
            where CategoryArrayType : IConvertible
            =>
                Plotly.NET.Chart.WithXAxisStyle<MinType, MaxType, CategoryArrayType>(
                    TitleText: TitleText.ToOption(),
                    TitleFont: TitleFont.ToOption(),
                    TitleStandoff: TitleStandoff.ToOption(),
                    Title: Title.ToOption(),
                    Color: Color.ToOption(),
                    AxisType: AxisType.ToOption(),
                    MinMax: MinMax.ToOption(),
                    Mirror: Mirror.ToOption(),
                    ShowSpikes: ShowSpikes.ToOption(),
                    SpikeColor: SpikeColor.ToOption(),
                    SpikeThickness: SpikeThickness.ToOption(),
                    ShowLine: ShowLine.ToOption(),
                    LineColor: LineColor.ToOption(),
                    ShowGrid: ShowGrid.ToOption(),
                    GridColor: GridColor.ToOption(),
                    ZeroLine: ZeroLine.ToOption(),
                    ZeroLineColor: ZeroLineColor.ToOption(),
                    Anchor: Anchor.ToOption(),
                    Side: Side.ToOption(),
                    Overlaying: Overlaying.ToOption(),
                    Domain: Domain.ToOption(),
                    Position: Position.ToOption(),
                    CategoryOrder: CategoryOrder.ToOption(),
                    CategoryArray: CategoryArray.ToOption(),
                    RangeSlider: RangeSlider.ToOption(),
                    RangeSelector: RangeSelector.ToOption(),
                    BackgroundColor: BackgroundColor.ToOption(),
                    ShowBackground: ShowBackground.ToOption(),
                    Id: Id.ToOption()

                ).Invoke(gChart);

        /// <summary>
        /// Sets the given y axis styles on the input chart's layout.
        ///
        /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
        /// </summary>
        /// <param name="gChart">The chart in which to change the Y axis style</param>
        /// <param name="TitleText">Sets the text of the axis title.</param>
        /// <param name="TitleFont">Sets the font of the axis title.</param>
        /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
        /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
        /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
        /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
        /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
        /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
        /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
        /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
        /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
        /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
        /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
        /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
        /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
        /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="RangeSlider">Sets a range slider for this axis</param>
        /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
        /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
        /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
        /// <param name="Id">The target axis id on which the styles should be applied. Default is 1.</param>
        public static GenericChart.GenericChart WithYAxisStyle<MinType, MaxType, CategoryArrayType>(
            this GenericChart.GenericChart gChart,
            Optional<string> TitleText = default,
            Optional<Font> TitleFont = default,
            Optional<int> TitleStandoff = default,
            Optional<Title> Title = default,
            Optional<Color> Color = default,
            Optional<StyleParam.AxisType> AxisType = default,
            Optional<Tuple<MinType, MaxType>> MinMax = default,
            Optional<StyleParam.Mirror> Mirror = default,
            Optional<bool> ShowSpikes = default,
            Optional<Color> SpikeColor = default,
            Optional<int> SpikeThickness = default,
            Optional<bool> ShowLine = default,
            Optional<Color> LineColor = default,
            Optional<bool> ShowGrid = default,
            Optional<Color> GridColor = default,
            Optional<bool> ZeroLine = default,
            Optional<Color> ZeroLineColor = default,
            Optional<StyleParam.LinearAxisId> Anchor = default,
            Optional<StyleParam.Side> Side = default,
            Optional<StyleParam.LinearAxisId> Overlaying = default,
            Optional<Tuple<double, double>> Domain = default,
            Optional<double> Position = default,
            Optional<StyleParam.CategoryOrder> CategoryOrder = default,
            Optional<IEnumerable<CategoryArrayType>> CategoryArray = default,
            Optional<RangeSlider> RangeSlider = default,
            Optional<RangeSelector> RangeSelector = default,
            Optional<Color> BackgroundColor = default,
            Optional<bool> ShowBackground = default,
            Optional<StyleParam.SubPlotId> Id = default
        )
            where MinType : IConvertible
            where MaxType : IConvertible
            where CategoryArrayType : IConvertible
            =>
                Plotly.NET.Chart.WithYAxisStyle<MinType, MaxType, CategoryArrayType>(
                    TitleText: TitleText.ToOption(),
                    TitleFont: TitleFont.ToOption(),
                    TitleStandoff: TitleStandoff.ToOption(),
                    Title: Title.ToOption(),
                    Color: Color.ToOption(),
                    AxisType: AxisType.ToOption(),
                    MinMax: MinMax.ToOption(),
                    Mirror: Mirror.ToOption(),
                    ShowSpikes: ShowSpikes.ToOption(),
                    SpikeColor: SpikeColor.ToOption(),
                    SpikeThickness: SpikeThickness.ToOption(),
                    ShowLine: ShowLine.ToOption(),
                    LineColor: LineColor.ToOption(),
                    ShowGrid: ShowGrid.ToOption(),
                    GridColor: GridColor.ToOption(),
                    ZeroLine: ZeroLine.ToOption(),
                    ZeroLineColor: ZeroLineColor.ToOption(),
                    Anchor: Anchor.ToOption(),
                    Side: Side.ToOption(),
                    Overlaying: Overlaying.ToOption(),
                    Domain: Domain.ToOption(),
                    Position: Position.ToOption(),
                    CategoryOrder: CategoryOrder.ToOption(),
                    CategoryArray: CategoryArray.ToOption(),
                    RangeSlider: RangeSlider.ToOption(),
                    RangeSelector: RangeSelector.ToOption(),
                    BackgroundColor: BackgroundColor.ToOption(),
                    ShowBackground: ShowBackground.ToOption(),
                    Id: Id.ToOption()

                ).Invoke(gChart);

        /// <summary>
        /// Sets the Mapbox for the chart's layout
        ///
        /// If there is already a Mapbox set, the objects are combined.
        /// </summary>
        /// <param name="gChart">The chart in which to change the mapbox</param>
        /// <param name="mapbox">The Mapbox to set on the chart's layout</param>
        /// <param name="Id">The target mapbox id on which the Mapbox should be set. Default is 1.</param>
        public static GenericChart.GenericChart WithMabox(
            this GenericChart.GenericChart gChart,
            Mapbox mapbox, 
            Optional<int> Id = default
        )
            =>
                Plotly.NET.Chart.WithMapbox(
                    mapbox: mapbox,
                    Id: Id.ToOption()
                ).Invoke(gChart);

        /// <summary>
        /// Sets the given Mapbox styles on the target Mapbox object on the input chart's layout.
        ///
        /// If there is already a Mapbox set, the styles are applied to it. If there is no Mapbox present, a new Mapbox object with the given styles will be set.
        /// </summary>
        /// <param name="gChart">The chart in which to change the mapbox style</param>
        /// <param name="Domain">Sets the domain of the Mapbox subplot</param>
        /// <param name="AccessToken">Sets the mapbox access token to be used for this mapbox map. Alternatively, the mapbox access token can be set in the configuration options under `mapboxAccessToken`. Note that accessToken are only required when `style` (e.g with values : basic, streets, outdoors, light, dark, satellite, satellite-streets ) and/or a layout layer references the Mapbox server.</param>
        /// <param name="Style">Defines the map layers that are rendered by default below the trace layers defined in `data`, which are themselves by default rendered below the layers defined in `layout.mapbox.layers`. These layers can be defined either explicitly as a Mapbox Style object which can contain multiple layer definitions that load data from any public or private Tile Map Service (TMS or XYZ) or Web Map Service (WMS) or implicitly by using one of the built-in style objects which use WMSes which do not require any access tokens, or by using a default Mapbox style or custom Mapbox style URL, both of which require a Mapbox access token Note that Mapbox access token can be set in the `accesstoken` attribute or in the `mapboxAccessToken` config option. Mapbox Style objects are of the form described in the Mapbox GL JS documentation available at https://docs.mapbox.com/mapbox-gl-js/style-spec The built-in plotly.js styles objects are: carto-darkmatter, carto-positron, open-street-map, stamen-terrain, stamen-toner, stamen-watercolor, white-bg The built-in Mapbox styles are: basic, streets, outdoors, light, dark, satellite, satellite-streets Mapbox style URLs are of the form: mapbox://mapbox.mapbox/name/version</param>
        /// <param name="Center">Sets the (lon,lat) coordinates of the center of the map view</param>
        /// <param name="Zoom">Sets the zoom level of the map (mapbox.zoom).</param>
        /// <param name="Bearing">Sets the bearing angle of the map in degrees counter-clockwise from North (mapbox.bearing).</param>
        /// <param name="Pitch">Sets the pitch angle of the map (in degrees, where "0" means perpendicular to the surface of the map) (mapbox.pitch).</param>
        /// <param name="Layers">Sets the layers of this Mapbox</param>
        /// <param name="Id">The target mapbox id</param>
        public static GenericChart.GenericChart WithMaboxStyle(
            this GenericChart.GenericChart gChart,
            Optional<Domain> Domain = default, 
            Optional<string> AccessToken = default, 
            Optional<StyleParam.MapboxStyle> Style = default, 
            Optional<Tuple<double, double>> Center = default, 
            Optional<double> Zoom = default, 
            Optional<double> Bearing = default, 
            Optional<double> Pitch = default, 
            Optional<IEnumerable<MapboxLayer>> Layers = default, 
            Optional<int> Id = default
        )
            =>
                Plotly.NET.Chart.withMapboxStyle(
                    Domain: Domain.ToOption(),
                    AccessToken: AccessToken.ToOption(),
                    Style: Style.ToOption(),
                    Center: Center.ToOption(),
                    Zoom: Zoom.ToOption(),
                    Bearing: Bearing.ToOption(),
                    Pitch: Pitch.ToOption(),
                    Layers: Layers.ToOption(),
                    Id: Id.ToOption()
                ).Invoke(gChart);

        /// <summary>
        /// Sets the range slider for the xAxis
        /// </summary>
        /// <param name="gChart">The chart for which to set the x axis range slider</param>
        /// <param name="rangeSlider">The rangeslider to set</param>
        /// <param name="Id">The id of the respective x axis</param>
        /// <returns></returns>
        public static GenericChart.GenericChart WithXAxisRangeSlider(
            this GenericChart.GenericChart gChart,
            RangeSlider rangeSlider,
            Optional<StyleParam.SubPlotId> Id = default
        )
            =>
                Plotly.NET.Chart.WithXAxisRangeSlider(
                    rangeSlider: rangeSlider,
                    Id: Id.ToOption()
                ).Invoke(gChart);
    }
}