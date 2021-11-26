namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceDomain(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "pie" applying the given trace styling function
    static member initPie(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("pie") |> applyStyle

    ///initializes a trace of type "funnelarea" applying the given trace styling function
    static member initFunnelArea(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("funnelarea") |> applyStyle

    ///initializes a trace of type "sunburst" applying the given trace styling function
    static member initSunburst(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("sunburst") |> applyStyle

    ///initializes a trace of type "treemap" applying the given trace styling function
    static member initTreemap(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("treemap") |> applyStyle

    ///initializes a trace of type "parcoords" applying the given trace styling function
    static member initParallelCoord(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("parcoords") |> applyStyle

    ///initializes a trace of type "parcats" applying the given trace styling function
    static member initParallelCategories(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("parcats") |> applyStyle

    ///initializes a trace of type "sankey" applying the given trace styling function
    static member initSankey(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("sankey") |> applyStyle

    ///initializes a trace of type "Table" applying the given trace styling function
    static member initTable(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("table") |> applyStyle

    ///initializes a trace of type "indicator" applying the given trace styling function
    static member initIndicator(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("indicator") |> applyStyle

    ///initializes a trace of type "icicle" applying the given trace styling function
    static member initIcicle(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("icicle") |> applyStyle

type TraceDomainStyle() =

    static member SetDomain([<Optional; DefaultParameterValue(null)>] ?Domain: Domain) =
        (fun (trace: TraceDomain) ->

            Domain |> DynObj.setValueOpt trace "domain"

            trace)

    // Applies the styles of pie plot to TraceObjects
    static member Pie
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?DLabel: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Label0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Pull: float,
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
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?AutoMargin: bool,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.Direction,
            [<Optional; DefaultParameterValue(null)>] ?Hole: float,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextOrientation: StyleParam.InsideTextOrientation,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Rotation: float,
            [<Optional; DefaultParameterValue(null)>] ?ScaleGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Title |> DynObj.setValueOpt trace "title"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Values |> DynObj.setValueOpt trace "values"
            Labels |> DynObj.setValueOpt trace "labels"
            DLabel |> DynObj.setValueOpt trace "dlabel"
            Label0 |> DynObj.setValueOpt trace "label0"
            Pull |> DynObj.setValueOpt trace "pull"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            AutoMargin |> DynObj.setValueOpt trace "automargin"
            Marker |> DynObj.setValueOpt trace "marker"
            TextFont |> DynObj.setValueOpt trace "textfont"
            TextInfo |> DynObj.setValueOptBy trace "textinfo" StyleParam.TextInfo.convert
            Direction |> DynObj.setValueOptBy trace "direction" StyleParam.Direction.convert
            Hole |> DynObj.setValueOpt trace "hole"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            InsideTextFont |> DynObj.setValueOpt trace "insidetextfont"

            InsideTextOrientation
            |> DynObj.setValueOptBy trace "insidetextorientation" StyleParam.InsideTextOrientation.convert

            OutsideTextFont |> DynObj.setValueOpt trace "outsidetextfont"
            Rotation |> DynObj.setValueOpt trace "rotation"
            ScaleGroup |> DynObj.setValueOpt trace "scalegroup"
            Sort |> DynObj.setValueOpt trace "sort"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    /// Applies the styles of funnelarea plot to TraceObjects
    static member FunnelArea
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?DLabel: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Label0: #IConvertible,
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
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?AspectRatio: float,
            [<Optional; DefaultParameterValue(null)>] ?BaseRatio: float,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?ScaleGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Title |> DynObj.setValueOpt trace "title"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Values |> DynObj.setValueOpt trace "values"
            Labels |> DynObj.setValueOpt trace "labels"
            DLabel |> DynObj.setValueOpt trace "dlabel"
            Label0 |> DynObj.setValueOpt trace "label0"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Marker |> DynObj.setValueOpt trace "marker"
            TextFont |> DynObj.setValueOpt trace "textfont"
            TextInfo |> DynObj.setValueOptBy trace "textinfo" StyleParam.TextInfo.convert
            AspectRatio |> DynObj.setValueOpt trace "aspectratio"
            BaseRatio |> DynObj.setValueOpt trace "baseratio"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            InsideTextFont |> DynObj.setValueOpt trace "insidetextfont"
            ScaleGroup |> DynObj.setValueOpt trace "scalegroup"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    /// Applies the styles of sunburst plot to TraceObjects
    static member Sunburst
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Parents: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?BranchValues: StyleParam.BranchValues,
            [<Optional; DefaultParameterValue(null)>] ?Count: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextOrientation: StyleParam.InsideTextOrientation,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Root: SunburstRoot,
            [<Optional; DefaultParameterValue(null)>] ?Leaf: SunburstLeaf,
            [<Optional; DefaultParameterValue(null)>] ?Level: string,
            [<Optional; DefaultParameterValue(null)>] ?MaxDepth: int,
            [<Optional; DefaultParameterValue(null)>] ?Rotation: int,
            [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Title |> DynObj.setValueOpt trace "title"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Parents |> DynObj.setValueOpt trace "parents"
            Values |> DynObj.setValueOpt trace "values"
            Labels |> DynObj.setValueOpt trace "labels"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Marker |> DynObj.setValueOpt trace "marker"
            TextFont |> DynObj.setValueOpt trace "textfont"
            TextInfo |> DynObj.setValueOptBy trace "textinfo" StyleParam.TextInfo.convert
            BranchValues |> DynObj.setValueOptBy trace "branchvalues" StyleParam.BranchValues.convert
            Count |> DynObj.setValueOpt trace "count"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            InsideTextFont |> DynObj.setValueOpt trace "insidetextfont"

            InsideTextOrientation
            |> DynObj.setValueOptBy trace "insidetextorientation" StyleParam.InsideTextOrientation.convert

            OutsideTextFont |> DynObj.setValueOpt trace "outsidetextfont"
            Root |> DynObj.setValueOpt trace "root"
            Leaf |> DynObj.setValueOpt trace "leaf"
            Level |> DynObj.setValueOpt trace "level"
            MaxDepth |> DynObj.setValueOpt trace "maxdepth"
            Rotation |> DynObj.setValueOpt trace "rotation"
            Sort |> DynObj.setValueOpt trace "sort"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    /// Applies the styles of treemap plot to TraceObjects
    static member Treemap
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Parents: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
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
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?BranchValues: StyleParam.BranchValues,
            [<Optional; DefaultParameterValue(null)>] ?Count: string,
            [<Optional; DefaultParameterValue(null)>] ?Tiling: TreemapTiling,
            [<Optional; DefaultParameterValue(null)>] ?PathBar: Pathbar,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Root: TreemapRoot,
            [<Optional; DefaultParameterValue(null)>] ?Level: string,
            [<Optional; DefaultParameterValue(null)>] ?MaxDepth: int,
            [<Optional; DefaultParameterValue(null)>] ?Rotation: int,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Title |> DynObj.setValueOpt trace "title"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Parents |> DynObj.setValueOpt trace "parents"
            Values |> DynObj.setValueOpt trace "values"
            Labels |> DynObj.setValueOpt trace "labels"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Marker |> DynObj.setValueOpt trace "marker"
            TextFont |> DynObj.setValueOpt trace "textfont"
            TextInfo |> DynObj.setValueOptBy trace "textinfo" StyleParam.TextInfo.convert
            BranchValues |> DynObj.setValueOptBy trace "branchvalues" StyleParam.BranchValues.convert
            Count |> DynObj.setValueOpt trace "count"
            Tiling |> DynObj.setValueOpt trace "tiling"
            PathBar |> DynObj.setValueOpt trace "pathbar"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            InsideTextFont |> DynObj.setValueOpt trace "insidetextfont"
            OutsideTextFont |> DynObj.setValueOpt trace "outsidetextfont"
            Root |> DynObj.setValueOpt trace "root"
            Level |> DynObj.setValueOpt trace "level"
            MaxDepth |> DynObj.setValueOpt trace "maxdepth"
            Rotation |> DynObj.setValueOpt trace "rotation"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    // Applies the styles of parallel coordinates plot to TraceObjects
    static member ParallelCoord
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Dimensions: seq<Dimension>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?LabelAngle: int,
            [<Optional; DefaultParameterValue(null)>] ?LabelFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?LabelSide: StyleParam.Side,
            [<Optional; DefaultParameterValue(null)>] ?RangeFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TickFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Ids |> DynObj.setValueOpt trace "ids"
            Dimensions |> DynObj.setValueOpt trace "dimensions"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Line |> DynObj.setValueOpt trace "line"
            LabelAngle |> DynObj.setValueOpt trace "labelangle"
            LabelFont |> DynObj.setValueOpt trace "labelfont"
            LabelSide |> DynObj.setValueOpt trace "labelside"
            RangeFont |> DynObj.setValueOpt trace "rangefont"
            TickFont |> DynObj.setValueOpt trace "tickfont "
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    static member ParallelCategories
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Counts: int,
            [<Optional; DefaultParameterValue(null)>] ?Dimensions: seq<Dimension>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Arrangement: StyleParam.CategoryArrangement,
            [<Optional; DefaultParameterValue(null)>] ?BundleColors: bool,
            [<Optional; DefaultParameterValue(null)>] ?SortPaths: StyleParam.SortAlgorithm,
            [<Optional; DefaultParameterValue(null)>] ?Hoveron: StyleParam.HoverOn,
            [<Optional; DefaultParameterValue(null)>] ?LabelFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TickFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Counts |> DynObj.setValueOpt trace "counts"
            Dimensions |> DynObj.setValueOpt trace "dimensions"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            Domain |> DynObj.setValueOpt trace "domain"
            Line |> DynObj.setValueOpt trace "line"
            Arrangement |> DynObj.setValueOptBy trace "arrangement" StyleParam.CategoryArrangement.convert
            BundleColors |> DynObj.setValueOpt trace "bundlecolors"
            SortPaths |> DynObj.setValueOptBy trace "sortpaths" StyleParam.SortAlgorithm.convert
            Hoveron |> DynObj.setValueOptBy trace "hoveron" StyleParam.HoverOn.convert
            LabelFont |> DynObj.setValueOpt trace "labelfont"
            TickFont |> DynObj.setValueOpt trace "tickfont "
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    static member Sankey
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?Node: SankeyNodes,
            [<Optional; DefaultParameterValue(null)>] ?Link: SankeyLinks,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Arrangement: StyleParam.CategoryArrangement,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?ValueFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?ValueSuffix: string,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Ids |> DynObj.setValueOpt trace "ids"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Orientation |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
            Node |> DynObj.setValueOpt trace "node"
            Link |> DynObj.setValueOpt trace "link"
            TextFont |> DynObj.setValueOpt trace "textfont"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Arrangement |> DynObj.setValueOptBy trace "arrangement" StyleParam.CategoryArrangement.convert
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            ValueFormat |> DynObj.setValueOpt trace "valueformat"
            ValueSuffix |> DynObj.setValueOpt trace "valuesuffix"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    // Applies the styles of table plot to TraceObjects
    static member Table
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?ColumnOrder: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?ColumnWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiColumnWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Cells: TableCells,
            [<Optional; DefaultParameterValue(null)>] ?Header: TableHeader,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Ids |> DynObj.setValueOpt trace "ids"
            ColumnOrder |> DynObj.setValueOpt trace "columnorder"
            (ColumnWidth, MultiColumnWidth) |> DynObj.setSingleOrMultiOpt trace "columnwidth"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Cells |> DynObj.setValueOpt trace "cells"
            Header |> DynObj.setValueOpt trace "header"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    static member Indicator
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Title: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.IndicatorMode,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Value: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.IndicatorAlignment,
            [<Optional; DefaultParameterValue(null)>] ?Delta: IndicatorDelta,
            [<Optional; DefaultParameterValue(null)>] ?Number: IndicatorNumber,
            [<Optional; DefaultParameterValue(null)>] ?Gauge: IndicatorGauge,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Title |> DynObj.setValueOpt trace "title"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Mode |> DynObj.setValueOptBy trace "mode" StyleParam.IndicatorMode.convert
            Ids |> DynObj.setValueOpt trace "ids"
            Value |> DynObj.setValueOpt trace "value"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Align |> DynObj.setValueOptBy trace "align" StyleParam.IndicatorAlignment.convert
            Delta |> DynObj.setValueOpt trace "delta"
            Number |> DynObj.setValueOpt trace "number"
            Gauge |> DynObj.setValueOpt trace "gauge"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace

    static member Icicle
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Title: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Parents: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
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
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?BranchValues: StyleParam.BranchValues,
            [<Optional; DefaultParameterValue(null)>] ?Count: StyleParam.IcicleCount,
            [<Optional; DefaultParameterValue(null)>] ?Tiling: IcicleTiling,
            [<Optional; DefaultParameterValue(null)>] ?PathBar: Pathbar,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Root: IcicleRoot,
            [<Optional; DefaultParameterValue(null)>] ?Leaf: IcicleLeaf,
            [<Optional; DefaultParameterValue(null)>] ?Level: string,
            [<Optional; DefaultParameterValue(null)>] ?MaxDepth: int,
            [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Title |> DynObj.setValueOpt trace "title"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Parents |> DynObj.setValueOpt trace "parents"
            Values |> DynObj.setValueOpt trace "values"
            Labels |> DynObj.setValueOpt trace "labels"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Domain |> DynObj.setValueOpt trace "domain"
            Marker |> DynObj.setValueOpt trace "marker"
            TextFont |> DynObj.setValueOpt trace "textfont"
            TextInfo |> DynObj.setValueOptBy trace "textinfo" StyleParam.TextInfo.convert
            BranchValues |> DynObj.setValueOptBy trace "branchvalues" StyleParam.BranchValues.convert
            Count |> DynObj.setValueOptBy trace "count" StyleParam.IcicleCount.convert
            Tiling |> DynObj.setValueOpt trace "tiling"
            PathBar |> DynObj.setValueOpt trace "pathbar"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            InsideTextFont |> DynObj.setValueOpt trace "insidetextfont"
            OutsideTextFont |> DynObj.setValueOpt trace "outsidetextfont"
            Root |> DynObj.setValueOpt trace "root"
            Leaf |> DynObj.setValueOpt trace "leaf"
            Level |> DynObj.setValueOpt trace "level"
            MaxDepth |> DynObj.setValueOpt trace "maxdepth"
            Sort |> DynObj.setValueOpt trace "sort"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace
