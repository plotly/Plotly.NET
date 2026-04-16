namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartMap_Geo =

    [<Extension>]
    type Chart =
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
        [<Extension>]
        static member ChoroplethMap
            (
                locations,
                z,
                ?Name: string,
                ?ShowLegend: bool,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?LocationMode: StyleParam.LocationFormat,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            TraceGeo.initChoroplethMap (
                TraceGeoStyle.ChoroplethMap(
                    Locations = locations,
                    Z = z,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?LocationMode = LocationMode
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a choropleth map using plotly's base geo map from encoded color values.
        ///
        /// A choropleth map is a type of thematic map in which a set of pre-defined areas is colored or patterned in proportion to a statistical variable that represents an aggregate summary of a geographic characteristic within each area, such as population density or per-capita income.
        /// </summary>
        /// <param name="locations">Sets the locations which will be colored. See LocationMode for more info.</param>
        /// <param name="zEncoded">The color values for each location as an encoded typed array.</param>
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
        [<Extension>]
        static member ChoroplethMap
            (
                locations: seq<string>,
                zEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?LocationMode: StyleParam.LocationFormat,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            TraceGeo.initChoroplethMap (
                TraceGeoStyle.ChoroplethMap(
                    Locations = locations,
                    ZEncoded = zEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?LocationMode = LocationMode
                )
            )
            |> GenericChart.ofTraceObject useDefaults

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
        [<Extension>]
        static member ScatterGeo
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
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
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )


            TraceGeo.initScatterGeo (
                TraceGeoStyle.ScatterGeo(
                    Lon = longitudes,
                    Lat = latitudes,
                    Mode = mode,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?LocationMode = LocationMode,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey

                )
            )

            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a ScatterGeo chart from encoded longitude and latitude coordinates.
        /// </summary>
        /// <param name="longitudesEncoded">Sets the longitude coordinates (in degrees East) as an encoded typed array.</param>
        /// <param name="latitudesEncoded">Sets the latitude coordinates (in degrees North) as an encoded typed array.</param>
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
        [<Extension>]
        static member ScatterGeo
            (
                longitudesEncoded: EncodedTypedArray,
                latitudesEncoded: EncodedTypedArray,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
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
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )


            TraceGeo.initScatterGeo (
                TraceGeoStyle.ScatterGeo(
                    LonEncoded = longitudesEncoded,
                    LatEncoded = latitudesEncoded,
                    Mode = mode,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?LocationMode = LocationMode,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey

                )
            )

            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a ScatterGeo chart, where data is visualized using plotly's base geo map.
        ///
        /// In general, ScatterGeo Plots plot two-dimensional data on a geo map via (lat,lon) coordinates.
        ///
        /// ScatterGeo charts are the basis of PointGeo, LineGeo, and BubbleGeo Charts, and can be customized as such. We also provide abstractions for those: Chart.PointGeo, Chart.LineGeo, Chart.BubbleGeo
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
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
        [<Extension>]
        static member ScatterGeo
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.ScatterGeo(
                longitudes,
                latitudes,
                mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a ScatterGeo chart, where data is visualized using plotly's base geo map.
        ///
        /// In general, ScatterGeo Plots plot two-dimensional data on a geo map via (lat,lon) coordinates.
        ///
        /// ScatterGeo charts are the basis of PointGeo, LineGeo, and BubbleGeo Charts, and can be customized as such. We also provide abstractions for those: Chart.PointGeo, Chart.LineGeo, Chart.BubbleGeo
        /// </summary>
        /// <param name="locations">Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.</param>
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
        [<Extension>]
        static member ScatterGeo
            (
                locations: seq<string>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
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
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )


            TraceGeo.initScatterGeo (
                TraceGeoStyle.ScatterGeo(
                    Locations = locations,
                    Mode = mode,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?LocationMode = LocationMode,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey

                )
            )

            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a PointGeo chart.
        ///
        /// In general, PointGeo Plots plot two-dimensional data as points using plotly's base geo map.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointGeo
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterGeo(
                longitudes,
                latitudes,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults

            )

        /// <summary>Creates a PointGeo chart from encoded longitude and latitude coordinates.</summary>
        [<Extension>]
        static member PointGeo
            (
                longitudesEncoded: EncodedTypedArray,
                latitudesEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterGeo(
                longitudesEncoded,
                latitudesEncoded,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a PointGeo chart.
        ///
        /// In general, PointGeo Plots plot two-dimensional data as points using plotly's base geo map.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointGeo
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.PointGeo(
                longitudes,
                latitudes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a PointGeo chart.
        ///
        /// In general, PointGeo Plots plot two-dimensional data as points using plotly's base geo map.
        /// </summary>
        /// <param name="locations">Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointGeo
            (
                locations: seq<string>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterGeo(
                locations,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a LineGeo chart.
        ///
        /// In general, LineGeo Plots plot two-dimensional data connected by lines using plotly's base geo map.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="ShowMarkers"></param>
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
        [<Extension>]
        static member LineGeo
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.ScatterGeo(
                longitudes,
                latitudes,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>Creates a LineGeo chart from encoded longitude and latitude coordinates.</summary>
        [<Extension>]
        static member LineGeo
            (
                longitudesEncoded: EncodedTypedArray,
                latitudesEncoded: EncodedTypedArray,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.ScatterGeo(
                longitudesEncoded,
                latitudesEncoded,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a LineGeo chart.
        ///
        /// In general, LineGeo Plots plot two-dimensional data connected by lines using plotly's base geo map.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
        /// <param name="ShowMarkers"></param>
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
        [<Extension>]
        static member LineGeo
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.LineGeo(
                longitudes,
                latitudes,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a LineGeo chart.
        ///
        /// In general, LineGeo Plots plot two-dimensional data connected by lines using plotly's base geo map.
        /// </summary>
        /// <param name="locations">Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.</param>
        /// <param name="ShowMarkers"></param>
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
        [<Extension>]
        static member LineGeo
            (
                locations: seq<string>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.ScatterGeo(
                locations,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a BubbleGeo chart.
        ///
        /// In general, BubbleGeo Plots plot two-dimensional data as points using plotly's base geo map, additionally using the point size as a third dimension.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="sizes">Sets the size of the points.</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BubbleGeo
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

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
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            TraceGeo.initScatterGeo (
                TraceGeoStyle.ScatterGeo(
                    Lon = longitudes,
                    Lat = latitudes,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Marker = marker,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?LocationMode = LocationMode,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey
                )
            )

            |> GenericChart.ofTraceObject useDefaults

        /// <summary>Creates a BubbleGeo chart from encoded longitude and latitude coordinates.</summary>
        [<Extension>]
        static member BubbleGeo
            (
                longitudesEncoded: EncodedTypedArray,
                latitudesEncoded: EncodedTypedArray,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

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
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            TraceGeo.initScatterGeo (
                TraceGeoStyle.ScatterGeo(
                    LonEncoded = longitudesEncoded,
                    LatEncoded = latitudesEncoded,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Marker = marker,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?LocationMode = LocationMode,
                    ?GeoJson = GeoJson,
                    ?FeatureIdKey = FeatureIdKey
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a BubbleGeo chart.
        ///
        /// In general, BubbleGeo Plots plot two-dimensional data as points using plotly's base geo map, additionally using the point size as a third dimension.
        /// </summary>
        /// <param name="lonlatsizes">Sets the (longitude,latitude) coordinates (in degrees East, degrees North) together with the point sizes.</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BubbleGeo
            (
                lonlatsizes: seq<#IConvertible * #IConvertible * int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =

            let longitudes, latitudes, sizes =
                Seq.unzip3 lonlatsizes

            Chart.BubbleGeo(
                longitudes,
                latitudes,
                sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a BubbleGeo chart.
        ///
        /// In general, BubbleGeo Plots plot two-dimensional data as points using plotly's base geo map, additionally using the point size as a third dimension.
        /// </summary>
        /// <param name="locations">Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.</param>
        /// <param name="sizes">Sets the size of the points.</param>
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
        /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
        /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BubbleGeo
            (
                locations: seq<string>,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
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
                ?LocationMode: StyleParam.LocationFormat,
                ?GeoJson: obj,
                ?FeatureIdKey: string,
                ?UseDefaults: bool
            ) =
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.BubbleGeo(
                locations,
                sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LocationMode = LocationMode,
                ?GeoJson = GeoJson,
                ?FeatureIdKey = FeatureIdKey,
                ?UseDefaults = UseDefaults
            )


