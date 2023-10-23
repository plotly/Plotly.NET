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
module ChartMap =

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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
                [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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


        /// <summary>
        /// Creates a ScatterMapbox chart, where data is visualized on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        ///
        /// ScatterMapbox charts are the basis of PointMapbox, LineMapbox, and BubbleMapbox Charts, and can be customized as such. We also provide abstractions for those: Chart.PointMapbox, Chart.LineMapbox, Chart.BubbleMapbox
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
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
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="EnableClustering">Whether or not to enable clustering for points</param>
        /// <param name="Cluster">Sets the clustering options (use this for more finegrained control than the other cluster-associated arguments)</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ScatterMapbox
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                mode: StyleParam.Mode,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?EnableClustering: bool,
                [<Optional; DefaultParameterValue(true)>] ?Cluster: MapboxCluster,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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

            let cluster =
                Cluster
                |> Option.defaultValue (MapboxCluster.init ())
                |> MapboxCluster.style (?Enabled = EnableClustering)

            let mapboxStyle =
                defaultArg MapboxStyle StyleParam.MapboxStyle.OpenStreetMap

            let mapbox =
                Mapbox.init (Style = mapboxStyle)

            TraceMapbox.initScatterMapbox (
                TraceMapboxStyle.ScatterMapbox(
                    Lon = longitudes,
                    Lat = latitudes,
                    Cluster = cluster,
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
                    ?Below = Below
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (Layout.init () |> Layout.setMapbox (StyleParam.SubPlotId.Mapbox 1, mapbox))

        /// <summary>
        /// Creates a ScatterMapbox chart, where data is visualized on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        ///
        /// ScatterMapbox charts are the basis of PointMapbox, LineMapbox, and BubbleMapbox Charts, and can be customized as such. We also provide abstractions for those: Chart.PointMapbox, Chart.LineMapbox, Chart.BubbleMapbox
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
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
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="EnableClustering">Whether or not to enable clustering for points</param>
        /// <param name="Cluster">Sets the clustering options (use this for more finegrained control than the other cluster-associated arguments)</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ScatterMapbox
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?EnableClustering: bool,
                [<Optional; DefaultParameterValue(true)>] ?Cluster: MapboxCluster,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.ScatterMapbox(
                longitudes,
                latitudes,
                mode,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
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
                ?Below = Below,
                ?EnableClustering = EnableClustering,
                ?Cluster = Cluster,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member PointMapbox
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?EnableClustering: bool,
                [<Optional; DefaultParameterValue(true)>] ?Cluster: MapboxCluster,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterMapbox(
                longitudes,
                latitudes,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
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
                ?Below = Below,
                ?EnableClustering = EnableClustering,
                ?Cluster = Cluster,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a PointMapbox chart, where data is visualized on a geographic map as points using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
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
        [<Extension>]
        static member PointMapbox
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?EnableClustering: bool,
                [<Optional; DefaultParameterValue(true)>] ?Cluster: MapboxCluster,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.PointMapbox(
                longitudes,
                latitudes,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
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
                ?Below = Below,
                ?EnableClustering = EnableClustering,
                ?Cluster = Cluster,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a LineMapbox chart, where data is visualized on a geographic map connected by a line using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="ShowMarkers"></param>
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
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member LineMapbox
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.ScatterMapbox(
                longitudes,
                latitudes,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
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
                ?Below = Below,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a LineMapbox chart, where data is visualized on a geographic map connected by a line using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
        /// <param name="ShowMarkers"></param>
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
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member LineMapbox
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.LineMapbox(
                longitudes,
                latitudes,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
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
                ?Below = Below,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a BubbleMapbox chart, where data is visualized on a geographic map as points using mapbox, additionally using the point size as a third dimension.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="sizes">Sets the size of the points.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BubbleMapbox
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                sizes: seq<int>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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

            let mapboxStyle =
                defaultArg MapboxStyle StyleParam.MapboxStyle.OpenStreetMap

            let mapbox =
                Mapbox.init (Style = mapboxStyle)

            TraceMapbox.initScatterMapbox (
                TraceMapboxStyle.ScatterMapbox(
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
                    ?Below = Below
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (Layout.init () |> Layout.setMapbox (StyleParam.SubPlotId.Mapbox 1, mapbox))

        /// <summary>
        /// Creates a BubbleMapbox chart, where data is visualized on a geographic map as points using mapbox, additionally using the point size as a third dimension.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="lonlatsizes">Sets the (longitude,latitude) coordinates (in degrees East, degrees North) together with the point size.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BubbleMapbox
            (
                lonlatsizes: seq<#IConvertible * #IConvertible * int>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let longitudes, latitudes, sizes =
                Seq.unzip3 lonlatsizes

            Chart.BubbleMapbox(
                longitudes,
                latitudes,
                sizes,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
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
                ?Below = Below,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member ChoroplethMapbox
            (
                locations: seq<string>,
                z: seq<#IConvertible>,
                geoJson: obj,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let mapboxStyle =
                defaultArg MapboxStyle StyleParam.MapboxStyle.OpenStreetMap

            let mapbox =
                Mapbox.init (Style = mapboxStyle)

            TraceMapbox.initChoroplethMapbox (
                TraceMapboxStyle.ChoroplethMapbox(
                    Locations = locations,
                    Z = z,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    GeoJson = geoJson,
                    ?FeatureIdKey = FeatureIdKey,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Below = Below
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (Layout.init () |> Layout.setMapbox (StyleParam.SubPlotId.Mapbox 1, mapbox))

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
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
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
        [<Extension>]
        static member DensityMapbox
            (
                longitudes: seq<#IConvertible>,
                latitudes: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Radius: int,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let mapboxStyle =
                defaultArg MapboxStyle StyleParam.MapboxStyle.OpenStreetMap

            let mapbox =
                Mapbox.init (Style = mapboxStyle)

            TraceMapbox.initDensityMapbox (
                TraceMapboxStyle.DensityMapbox(
                    Lon = longitudes,
                    Lat = latitudes,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Z = Z,
                    ?Radius = Radius,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Below = Below

                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (Layout.init () |> Layout.setMapbox (StyleParam.SubPlotId.Mapbox 1, mapbox))

        /// <summary>
        /// Creates a DensityMapbox Chart that draws a bivariate kernel density estimation with a Gaussian kernel from `lon` and `lat` coordinates and optional `z` values using a colorscale.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees East, degrees North).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
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
        [<Extension>]
        static member DensityMapbox
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?MapboxStyle: StyleParam.MapboxStyle,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Radius: int,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Below: string,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let longitudes, latitudes = Seq.unzip lonlat

            Chart.DensityMapbox(
                longitudes,
                latitudes,
                ?Name = Name,
                ?MapboxStyle = MapboxStyle,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Z = Z,
                ?Radius = Radius,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?Below = Below,
                ?UseDefaults = UseDefaults
            )
