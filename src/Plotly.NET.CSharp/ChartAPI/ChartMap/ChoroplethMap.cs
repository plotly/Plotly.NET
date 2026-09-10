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
        /// Creates a choropleth map using plotly's base geo map.
        ///
        /// A choropleth map is a type of thematic map in which a set of pre-defined areas is colored or patterned in proportion to a statistical variable that represents an aggregate summary of a geographic characteristic within each area, such as population density or per-capita income.
        /// </summary>
        /// <param name="locations">Sets the locations which will be colored. See LocationMode for more info.</param>
        /// <param name="z">The color values for each location</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="Text">Sets the text elements associated with each location.</param>
        /// <param name="MultiText">Sets the text elements associated with each location.</param>
        /// <param name="ColorBar">Sets the colorbar.</param>
        /// <param name="ColorScale">Sets the colorscale.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ChoroplethMap<ZType, TextType>(
            IEnumerable<string> locations, 
            IEnumerable<ZType> z, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<object> GeoJson = default, 
            Optional<string> FeatureIdKey = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default, 
            Optional<bool> ReverseScale = default,
            Optional<StyleParam.LocationFormat> LocationMode = default,
            Optional<bool> UseDefaults = default
        )
            where ZType: IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartMap_Geo.Chart.ChoroplethMap<ZType, TextType>(
                    locations: locations,
                    z: z,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    GeoJson: GeoJson.ToOption(),
                    FeatureIdKey: FeatureIdKey.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    LocationMode: LocationMode.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
