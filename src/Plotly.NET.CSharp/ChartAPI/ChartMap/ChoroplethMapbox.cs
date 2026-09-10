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
        /// Creates a choropleth map using mapbox.
        ///
        /// A choropleth map is a type of thematic map in which a set of pre-defined areas is colored or patterned in proportion to a statistical variable that represents an aggregate summary of a geographic characteristic within each area, such as population density or per-capita income.
        ///
        /// GeoJSON features to be filled are set in `geojson` The data that describes the choropleth value-to-color mapping is set in `locations` and `z`.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="locations">Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.</param>
        /// <param name="z">The color values for each location</param>
        /// <param name="geoJson">Sets the GeoJSON data associated with this trace. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Support nested property, for example "properties.name".</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar.</param>
        /// <param name="ColorScale">Sets the colorscale.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ChoroplethMapbox<ZType, TextType>(
            IEnumerable<string> locations,
            IEnumerable<ZType> z,
            object geoJson,
            Optional<string> Name = default,
            Optional<StyleParam.MapboxStyle> MapboxStyle = default,
            Optional<bool> ShowLegend = default,
            Optional<string> FeatureIdKey = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<string> Below = default,
            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartMap_Density.Chart.ChoroplethMapbox<ZType, TextType>(
                    locations: locations,
                    z: z,
                    Name: Name.ToOption(),
                    MapboxStyle: MapboxStyle.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    geoJson: geoJson,
                    FeatureIdKey: FeatureIdKey.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    Below: Below.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
