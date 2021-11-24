namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceTernary(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scatterternary" applying the given trace styling function
    static member initScatterTernary(applyStyle: TraceTernary -> TraceTernary) =
        TraceTernary("scatterternary") |> applyStyle

type TraceTernaryStyle() =

    static member SetTernary([<Optional; DefaultParameterValue(null)>] ?TernaryId: StyleParam.SubPlotId) =
        (fun (trace: TraceTernary) ->

            TernaryId |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.toString

            trace)

    static member ScatterTernary
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
            [<Optional; DefaultParameterValue(null)>] ?A: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?B: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?C: seq<#IConvertible>,
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
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Fill: StyleParam.Fill,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOn: StyleParam.HoverOn,
            [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Mode |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
            Ids |> DynObj.setValueOpt trace "ids"
            A |> DynObj.setValueOpt trace "a"
            B |> DynObj.setValueOpt trace "b"
            C |> DynObj.setValueOpt trace "c"
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
            ClipOnAxis |> DynObj.setValueOpt trace "cliponaxis"
            ConnectGaps |> DynObj.setValueOpt trace "connectgaps"
            Fill |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
            FillColor |> DynObj.setValueOpt trace "fillcolor"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            HoverOn |> DynObj.setValueOptBy trace "hoveron" StyleParam.HoverOn.convert
            Sum |> DynObj.setValueOpt trace "sum"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace
