namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

type TraceTernary(traceTypeName) =

    inherit Trace (traceTypeName)
    new() = TraceTernary(null)

    ///initializes a trace of type "scatterternary" applying the given trace styling function
    static member initScatterTernary (applyStyle:TraceTernary -> TraceTernary) = 
        TraceTernary("scatterternary") |> applyStyle

type TraceTernaryStyle() =

    static member SetTernary
        (
            [<Optional;DefaultParameterValue(null)>] ?TernaryId:StyleParam.SubPlotId
        ) =  
            (fun (trace:TraceTernary) ->

                trace

                ++?? ("subplot", TernaryId , StyleParam.SubPlotId.toString)
            )

    static member ScatterTernary
        (
            [<Optional;DefaultParameterValue(null)>] ?Name              : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible           : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank        : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup       : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle  : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
            [<Optional;DefaultParameterValue(null)>] ?Mode              : StyleParam.Mode,
            [<Optional;DefaultParameterValue(null)>] ?Ids               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?A                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?B                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?C                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Text              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextTemplate      : string,
            [<Optional;DefaultParameterValue(null)>] ?HoverText         : string,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo         : StyleParam.HoverInfo,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate     : string,
            [<Optional;DefaultParameterValue(null)>] ?Meta              : string,
            [<Optional;DefaultParameterValue(null)>] ?CustomData        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?SubPlot           : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
            [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
            [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
            [<Optional;DefaultParameterValue(null)>] ?SelectedPoints    : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Selected          : Selection,
            [<Optional;DefaultParameterValue(null)>] ?Unselected        : Selection,
            [<Optional;DefaultParameterValue(null)>] ?ClipOnAxis        : bool,
            [<Optional;DefaultParameterValue(null)>] ?ConnectGaps       : bool,
            [<Optional;DefaultParameterValue(null)>] ?Fill              : StyleParam.Fill,
            [<Optional;DefaultParameterValue(null)>] ?FillColor         : Color,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel        : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?HoverOn           : StyleParam.HoverOn,
            [<Optional;DefaultParameterValue(null)>] ?Sum               : #IConvertible

        ) =
            fun (trace: TraceTernary) ->

                trace
                
                ++? ("name", Name              )
                ++?? ("visible", Visible           , StyleParam.Visible.convert)
                ++? ("showlegend", ShowLegend        )
                ++? ("legendrank", LegendRank        )
                ++? ("legendgroup", LegendGroup       )
                ++? ("legendgrouptitle", LegendGroupTitle  )
                ++? ("opacity", Opacity           )
                ++?? ("mode", Mode              , StyleParam.Mode.convert)
                ++? ("ids", Ids               )
                ++? ("a", A                 )
                ++? ("b", B                 )
                ++? ("c", C                 )
                ++? ("text", Text              )
                ++?? ("textposition", TextPosition      , StyleParam.TextPosition.convert)
                ++? ("texttemplate", TextTemplate      )
                ++? ("hovertext", HoverText         )
                ++?? ("hoverinfo", HoverInfo         , StyleParam.HoverInfo.convert)
                ++? ("hovertemplate", HoverTemplate     )
                ++? ("meta", Meta              )
                ++? ("customdata", CustomData        )
                ++?? ("subplot", SubPlot           , StyleParam.SubPlotId.convert)
                ++? ("marker", Marker            )
                ++? ("line", Line              )
                ++? ("textfont", TextFont          )
                ++? ("selectedpoints", SelectedPoints    )
                ++? ("selected", Selected          )
                ++? ("unselected", Unselected        )
                ++? ("cliponaxis", ClipOnAxis        )
                ++? ("connectgaps", ConnectGaps       )
                ++?? ("fill", Fill              , StyleParam.Fill.convert)
                ++? ("fillcolor", FillColor         )
                ++? ("hoverlabel", HoverLabel        )
                ++?? ("hoveron", HoverOn           , StyleParam.HoverOn.convert)
                ++? ("sum", Sum               )