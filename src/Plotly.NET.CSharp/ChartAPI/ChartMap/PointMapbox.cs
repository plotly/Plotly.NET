using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
        /// <summary>
        /// Creates a PointMapbox chart, where data is visualized on a geographic map as points using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
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
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="EnableClustering">Whether or not to enable clustering for points</param>
        /// <param name="Cluster">Sets the clustering options (use this for more finegrained control than the other cluster-associated arguments)</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart PointMapbox<LongitudesType, LatitudesType, TextType>(
            IEnumerable<LongitudesType> longitudes,
            IEnumerable<LatitudesType> latitudes,
            Optional<string> Name = default,
            Optional<StyleParam.MapboxStyle> MapboxStyle = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<string> Below = default,
            Optional<bool> EnableClustering = default,
            Optional<MapboxCluster> Cluster = default,
            Optional<bool> UseDefaults = default
        )
            where LongitudesType : IConvertible
            where LatitudesType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartMap_Mapbox.Chart.PointMapbox<LongitudesType, LatitudesType, TextType>(
                    longitudes: longitudes,
                    latitudes: latitudes,
                    Name: Name.ToOption(),
                    MapboxStyle: MapboxStyle.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
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
                    Below: Below.ToOption(),
                    EnableClustering: EnableClustering.ToOption(),
                    Cluster: Cluster.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
