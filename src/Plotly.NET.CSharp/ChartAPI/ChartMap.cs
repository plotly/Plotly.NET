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
        /// Creates a ScatterGeo chart, where data is visualized using plotly's base geo map.
        ///
        /// In general, ScatterGeo Plots plot two-dimensional data on a geo map via (lat,lon) coordinates.
        ///
        /// ScatterGeo charts are the basis of PointGeo, LineGeo, and BubbleGeo Charts, and can be customized as such. We also provide abstractions for those: Chart.PointGeo, Chart.LineGeo, Chart.BubbleGeo
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart ScatterGeo<LongitudesType, LatitudesType, TextType>(
            IEnumerable<LongitudesType> longitudes,
            IEnumerable<LatitudesType> latitudes,
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
            [Optional] StyleParam.LocationFormat? LocationMode,
            [Optional] Object? GeoJson,
            [Optional] string? FeatureIdKey,
            [Optional] bool? UseDefaults
        )
            where LongitudesType : IConvertible
            where LatitudesType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartMap.Chart.ScatterGeo<LongitudesType, LatitudesType, TextType>(
                    longitudes: longitudes,
                    latitudes: latitudes,
                    mode: mode,
                    Name: Helpers.ToOption(Name),
                    ShowLegend: Helpers.ToOptionV(ShowLegend),
                    Opacity: Helpers.ToOptionV(Opacity),
                    MultiOpacity: Helpers.ToOption(MultiOpacity),
                    Text: Helpers.ToOption(Text),
                    MultiText: Helpers.ToOption(MultiText),
                    TextPosition: Helpers.ToOption(TextPosition),
                    MultiTextPosition: Helpers.ToOption(MultiTextPosition),
                    MarkerColor: Helpers.ToOption(MarkerColor),
                    MarkerColorScale: Helpers.ToOption(MarkerColorScale),
                    MarkerOutline: Helpers.ToOption(MarkerOutline),
                    MarkerSymbol: Helpers.ToOption(MarkerSymbol),
                    MultiMarkerSymbol: Helpers.ToOption(MultiMarkerSymbol),
                    Marker: Helpers.ToOption(Marker),
                    LineColor: Helpers.ToOption(LineColor),
                    LineColorScale: Helpers.ToOption(LineColorScale),
                    LineWidth: Helpers.ToOptionV(LineWidth),
                    LineDash: Helpers.ToOption(LineDash),
                    Line: Helpers.ToOption(Line),
                    LocationMode: Helpers.ToOption(LocationMode),
                    GeoJson: Helpers.ToOption(GeoJson),
                    FeatureIdKey: Helpers.ToOption(FeatureIdKey),
                    UseDefaults: Helpers.ToOptionV(UseDefaults)
                );

        /// <summary>
        /// Creates a DensityMapbox Chart that draws a bivariate kernel density estimation with a Gaussian kernel from `lon` and `lat` coordinates and optional `z` values using a colorscale.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opacity of the trace</param>
        /// <param name="Z">Sets the points' weight. For example, a value of 10 would be equivalent to having 10 points of weight 1 in the same spot</param>
        /// <param name="Radius">Sets the radius of influence of one `lon` / `lat` point in pixels. Increasing the value makes the densitymapbox trace smoother, but less detailed.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar.</param>
        /// <param name="ColorScale">Sets the colorscale.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart DensityMapbox<LongitudesType, LatitudesType, ZType, TextType>(
            IEnumerable<LongitudesType> longitudes,
            IEnumerable<LatitudesType> latitudes,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<ZType>? Z,
            [Optional] int? Radius,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] ColorBar? ColorBar,
            [Optional] StyleParam.Colorscale? ColorScale,
            [Optional] bool? ShowScale,
            [Optional] bool? ReverseScale,
            [Optional] string? Below,
            [Optional] bool? UseDefaults
        )
            where LongitudesType: IConvertible
            where LatitudesType: IConvertible
            where ZType: IConvertible
            where TextType: IConvertible
            =>
                Plotly.NET.ChartMap.Chart.DensityMapbox<LongitudesType, LatitudesType, ZType, TextType>(
                    longitudes: longitudes,
                    latitudes: latitudes,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    Z: Z.ToOption(),
                    Radius: Radius.ToOptionV(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOptionV(),
                    ReverseScale: ReverseScale.ToOptionV(),
                    Below: Below.ToOption(),
                    UseDefaults: UseDefaults.ToOptionV()
                );
    }
}
