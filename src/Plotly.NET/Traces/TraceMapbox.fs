namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices


//Figures can include two different types of map subplots: geo subplots for outline maps and mapbox subplots for tile maps.
///The following trace types support attributes named geo or mapbox, whose values must refer to corresponding objects in the layout
///i.e. geo="geo2" etc. Note that attributes such as layout.geo2 and layout.mapbox etc do not have to be explicitly defined, in which
///case default values will be inferred. Multiple traces of a compatible type can be placed on the same subplot.
///
/// The following trace types are compatible with geo subplots via the geo attribute:
///
/// - scattergeo, which can be used to draw individual markers, line and curves and filled areas on outline maps
///
/// - choropleth: colored polygons on outline maps
///
/// The following trace types are compatible with mapbox subplots via the mapbox attribute:
///
/// - scattermapbox, which can be used to draw individual markers, lines and curves and filled areas on tile maps
///
/// - choroplethmapbox: colored polygons on tile maps
///
/// - densitymapbox: density heatmaps on tile maps

type TraceMapbox(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scattermapbox" applying the given trace styling function
    static member initScatterMapbox(applyStyle: TraceMapbox -> TraceMapbox) =
        TraceMapbox("scattermapbox") |> applyStyle

    ///initializes a trace of type "choroplethmapbox" applying the given trace styling function
    static member initChoroplethMapbox(applyStyle: TraceMapbox -> TraceMapbox) =
        TraceMapbox("choroplethmapbox") |> applyStyle

    ///initializes a trace of type "densitymapbox" applying the given trace styling function
    static member initDensityMapbox(applyStyle: TraceMapbox -> TraceMapbox) =
        TraceMapbox("densitymapbox") |> applyStyle

type TraceMapboxStyle() =

    static member SetMapbox([<Optional; DefaultParameterValue(null)>] ?MapboxId: StyleParam.SubPlotId) =
        (fun (trace: TraceMapbox) ->

            MapboxId |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.toString

            trace)

    static member ScatterMapbox
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.Mode,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Lat: #IConvertible seq,
            [<Optional; DefaultParameterValue(null)>] ?Lon: #IConvertible seq,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?SubPlot: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: Selection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: Selection,
            [<Optional; DefaultParameterValue(null)>] ?Below: string,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Fill: StyleParam.Fill,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Mode |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
            Ids |> DynObj.setValueOpt trace "ids"
            Lat |> DynObj.setValueOpt trace "lat"
            Lon |> DynObj.setValueOpt trace "lon"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            SubPlot |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            Line |> DynObj.setValueOpt trace "line"
            TextFont |> DynObj.setValueOpt trace "textfont"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            Below |> DynObj.setValueOpt trace "below"
            ConnectGaps |> DynObj.setValueOpt trace "connectgaps"
            Fill |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
            FillColor |> DynObj.setValueOpt trace "fillcolor"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    static member ChoroplethMapbox
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
            [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
            [<Optional; DefaultParameterValue(null)>] ?Locations: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?SubPlot: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?Zmin: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmid: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmax: float,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: Selection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: Selection,
            [<Optional; DefaultParameterValue(null)>] ?Below: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Ids |> DynObj.setValueOpt trace "ids"
            Z |> DynObj.setValueOpt trace "z"
            GeoJson |> DynObj.setValueOpt trace "geojson"
            FeatureIdKey |> DynObj.setValueOpt trace "featureidkey"
            Locations |> DynObj.setValueOpt trace "locations"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            SubPlot |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.convert
            ColorAxis |> DynObj.setValueOptBy trace "coloraxis" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            ColorBar |> DynObj.setValueOpt trace "colorbar"
            AutoColorScale |> DynObj.setValueOpt trace "autocolorscale"
            ColorScale |> DynObj.setValueOptBy trace "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt trace "showscale"
            ReverseScale |> DynObj.setValueOpt trace "reversescale"
            ZAuto |> DynObj.setValueOpt trace "zauto"
            Zmin |> DynObj.setValueOpt trace "zmin"
            Zmid |> DynObj.setValueOpt trace "zmid"
            Zmax |> DynObj.setValueOpt trace "zmax"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            Below |> DynObj.setValueOpt trace "below"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            UIRevision |> DynObj.setValueOpt trace "uirevision"


            trace)

    static member DensityMapbox
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Radius: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Lat: #IConvertible seq,
            [<Optional; DefaultParameterValue(null)>] ?Lon: #IConvertible seq,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?SubPlot: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?Zmin: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmid: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmax: float,
            [<Optional; DefaultParameterValue(null)>] ?Below: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Z |> DynObj.setValueOpt trace "z"
            Radius |> DynObj.setValueOpt trace "radius"
            Lat |> DynObj.setValueOpt trace "lat"
            Lon |> DynObj.setValueOpt trace "lon"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            SubPlot |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.convert
            ColorAxis |> DynObj.setValueOptBy trace "coloraxis" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            ColorBar |> DynObj.setValueOpt trace "colorbar"
            AutoColorScale |> DynObj.setValueOpt trace "autocolorscale"
            ColorScale |> DynObj.setValueOptBy trace "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt trace "showscale"
            ReverseScale |> DynObj.setValueOpt trace "reversescale"
            ZAuto |> DynObj.setValueOpt trace "zauto"
            Zmin |> DynObj.setValueOpt trace "zmin"
            Zmid |> DynObj.setValueOpt trace "zmid"
            Zmax |> DynObj.setValueOpt trace "zmax"
            Below |> DynObj.setValueOpt trace "below"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            UIRevision |> DynObj.setValueOpt trace "uirevision"


            trace)
