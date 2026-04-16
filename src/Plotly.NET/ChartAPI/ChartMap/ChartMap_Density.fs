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
module ChartMap_Density =

    [<Extension>]
    type Chart =
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
                ?Name: string,
                ?MapboxStyle: StyleParam.MapboxStyle,
                ?ShowLegend: bool,
                ?FeatureIdKey: string,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Below: string,
                ?UseDefaults: bool
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
        /// Creates a choropleth map using mapbox from encoded color values.
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
        /// <param name="zEncoded">The color values for each location as an encoded typed array.</param>
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
                zEncoded: EncodedTypedArray,
                geoJson: obj,
                ?Name: string,
                ?MapboxStyle: StyleParam.MapboxStyle,
                ?ShowLegend: bool,
                ?FeatureIdKey: string,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Below: string,
                ?UseDefaults: bool
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
                    ZEncoded = zEncoded,
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
                ?Name: string,
                ?MapboxStyle: StyleParam.MapboxStyle,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Z: seq<#IConvertible>,
                ?Radius: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Below: string,
                ?UseDefaults: bool
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
                ?Name: string,
                ?MapboxStyle: StyleParam.MapboxStyle,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Z: seq<#IConvertible>,
                ?Radius: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Below: string,
                ?UseDefaults: bool
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

        /// <summary>
        /// Creates a DensityMapbox Chart from encoded longitude and latitude coordinates and optional encoded weights.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudesEncoded">Sets the longitude coordinates (in degrees East) as an encoded typed array.</param>
        /// <param name="latitudesEncoded">Sets the latitude coordinates (in degrees North) as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opacity of the trace</param>
        /// <param name="zEncoded">Sets the points' weight as an encoded typed array. For example, a value of 10 would be equivalent to having 10 points of weight 1 in the same spot.</param>
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
                longitudesEncoded: EncodedTypedArray,
                latitudesEncoded: EncodedTypedArray,
                ?Name: string,
                ?MapboxStyle: StyleParam.MapboxStyle,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?zEncoded: EncodedTypedArray,
                ?Radius: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Below: string,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let mapboxStyle =
                defaultArg MapboxStyle StyleParam.MapboxStyle.OpenStreetMap

            let mapbox =
                Mapbox.init (Style = mapboxStyle)

            TraceMapbox.initDensityMapbox (
                TraceMapboxStyle.DensityMapbox(
                    LonEncoded = longitudesEncoded,
                    LatEncoded = latitudesEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?ZEncoded = zEncoded,
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
