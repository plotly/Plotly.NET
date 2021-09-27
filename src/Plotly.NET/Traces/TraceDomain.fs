namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceDomain(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "pie" applying the given trace styling function
    static member initPie (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("pie") |> applyStyle

    ///initializes a trace of type "funnelarea" applying the given trace styling function
    static member initFunnelArea (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("funnelarea") |> applyStyle

    ///initializes a trace of type "sunburst" applying the given trace styling function
    static member initSunburst (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("sunburst") |> applyStyle

    ///initializes a trace of type "treemap" applying the given trace styling function
    static member initTreemap (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("treemap") |> applyStyle

    ///initializes a trace of type "parcoords" applying the given trace styling function
    static member initParallelCoord (applyStyle: TraceDomain -> TraceDomain)= 
        TraceDomain("parcoords") |> applyStyle

    ///initializes a trace of type "parcats" applying the given trace styling function
    static member initParallelCategories (applyStyle: TraceDomain -> TraceDomain) =
        TraceDomain("parcats") |> applyStyle

    ///initializes a trace of type "sankey" applying the given trace styling function
    static member initSankey (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("sankey") |> applyStyle

    ///initializes a trace of type "Table" applying the given trace styling function
    static member initTable (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("table") |> applyStyle

    ///initializes a trace of type "indicator" applying the given trace styling function
    static member initIndicator (applyStyle: TraceDomain -> TraceDomain) = 
        TraceDomain("indicator") |> applyStyle

type TraceDomainStyle() =
    
    static member SetDomain
        (
            [<Optional;DefaultParameterValue(null)>] ?Domain:Domain
        ) =  
            (fun (trace:TraceDomain) ->

                Domain |> DynObj.setValueOpt trace "domain"

                trace
            )

    // Applies the styles of pie plot to TraceObjects 
    static member Pie
        (                
            [<Optional;DefaultParameterValue(null)>] ?Name                  : string,
            [<Optional;DefaultParameterValue(null)>] ?Title                 : Title,
            [<Optional;DefaultParameterValue(null)>] ?Visible               : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend            : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup           : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle      : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity               : float,
            [<Optional;DefaultParameterValue(null)>] ?Ids                   : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Values                : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Labels                : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?DLabel                : #IConvertible,   
            [<Optional;DefaultParameterValue(null)>] ?Label0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Pull                  : float,
            [<Optional;DefaultParameterValue(null)>] ?Text                  : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition          : StyleParam.TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextTemplate          : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverText             : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo             : string,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Meta                  : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?CustomData            : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Domain                : Domain,
            [<Optional;DefaultParameterValue(null)>] ?AutoMargin            : bool,
            [<Optional;DefaultParameterValue(null)>] ?Marker                : Marker,
            [<Optional;DefaultParameterValue(null)>] ?TextFont              : Font,
            [<Optional;DefaultParameterValue(null)>] ?TextInfo              : StyleParam.TextInfo,
            [<Optional;DefaultParameterValue(null)>] ?Direction             : StyleParam.Direction,
            [<Optional;DefaultParameterValue(null)>] ?Hole                  : float,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel            : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?InsideTextFont        : Font,
            [<Optional;DefaultParameterValue(null)>] ?InsideTextOrientation : StyleParam.InsideTextOrientation,
            [<Optional;DefaultParameterValue(null)>] ?OutsideTextFont       : Font,
            [<Optional;DefaultParameterValue(null)>] ?Rotation              : float,
            [<Optional;DefaultParameterValue(null)>] ?ScaleGroup            : string,
            [<Optional;DefaultParameterValue(null)>] ?Sort                  : bool,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision            : string
        ) =
            (fun (pie:('T :> Trace)) ->

                Name                  |> DynObj.setValueOpt pie "name"
                Title                 |> DynObj.setValueOpt pie "title"
                Visible               |> DynObj.setValueOptBy pie "visible" StyleParam.Visible.convert
                ShowLegend            |> DynObj.setValueOpt pie "showlegend"
                LegendGroup           |> DynObj.setValueOpt pie "legendgroup"
                LegendGroupTitle      |> DynObj.setValueOpt pie "legendgrouptitle"
                Opacity               |> DynObj.setValueOpt pie "opacity"
                Ids                   |> DynObj.setValueOpt pie "ids"
                Values                |> DynObj.setValueOpt pie "values"
                Labels                |> DynObj.setValueOpt pie "labels"
                DLabel                |> DynObj.setValueOpt pie "dlabel"
                Label0                |> DynObj.setValueOpt pie "label0"
                Pull                  |> DynObj.setValueOpt pie "pull"
                Text                  |> DynObj.setValueOpt pie "text"
                TextPosition          |> DynObj.setValueOptBy pie "textposition" StyleParam.TextPosition.convert
                TextTemplate          |> DynObj.setValueOpt pie "texttemplate"
                HoverText             |> DynObj.setValueOpt pie "hovertext"
                HoverInfo             |> DynObj.setValueOpt pie "hoverinfo"
                HoverTemplate         |> DynObj.setValueOpt pie "hovertemplate"
                Meta                  |> DynObj.setValueOpt pie "meta"
                CustomData            |> DynObj.setValueOpt pie "customdata"
                Domain                |> DynObj.setValueOpt pie "domain"
                AutoMargin            |> DynObj.setValueOpt pie "automargin"
                Marker                |> DynObj.setValueOpt pie "marker"
                TextFont              |> DynObj.setValueOpt pie "textfont"
                TextInfo              |> DynObj.setValueOptBy pie "textinfo" StyleParam.TextInfo.convert
                Direction             |> DynObj.setValueOptBy pie "direction" StyleParam.Direction.convert
                Hole                  |> DynObj.setValueOpt pie "hole"
                HoverLabel            |> DynObj.setValueOpt pie "hoverlabel"
                InsideTextFont        |> DynObj.setValueOpt pie "insidetextfont"
                InsideTextOrientation |> DynObj.setValueOptBy pie "insidetextorientation" StyleParam.InsideTextOrientation.convert
                OutsideTextFont       |> DynObj.setValueOpt pie "outsidetextfont"
                Rotation              |> DynObj.setValueOpt pie "rotation"
                ScaleGroup            |> DynObj.setValueOpt pie "scalegroup"
                Sort                  |> DynObj.setValueOpt pie "sort"
                UIRevision            |> DynObj.setValueOpt pie "uirevision"

                pie
            ) 

            
    static member FunnelArea
        (
            [<Optional;DefaultParameterValue(null)>] ?Values        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?dLabel        : float,
            [<Optional;DefaultParameterValue(null)>] ?Label0        : float,
            [<Optional;DefaultParameterValue(null)>] ?Aspectratio   : float,
            [<Optional;DefaultParameterValue(null)>] ?Baseratio     : float,
            [<Optional;DefaultParameterValue(null)>] ?Insidetextfont: Font,
            [<Optional;DefaultParameterValue(null)>] ?Scalegroup    : string
        ) = 
            (fun (trace:('T :> Trace)) -> 
        
                Values         |> DynObj.setValueOpt   trace "values"
                Labels         |> DynObj.setValueOpt   trace "labels"
                dLabel         |> DynObj.setValueOpt   trace "dlabel"
                Label0         |> DynObj.setValueOpt   trace "label0"
                Aspectratio    |> DynObj.setValueOpt   trace "aspectratio"
                Baseratio      |> DynObj.setValueOpt   trace "baseratio"
                Insidetextfont |> DynObj.setValueOpt   trace "insidetextfont"
                Scalegroup     |> DynObj.setValueOpt   trace "scalegroup"

                trace

            )
            
    /// Applies the styles of sundburst plot to TraceObjects 
    ///
    /// Parameters:
    ///
    /// labels: Sets the labels of each of the sectors.
    ///
    /// parents: Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.
    ///
    /// Ids: Assigns id labels to each datum. These ids for object constancy of data points during animation.
    ///
    /// Values: Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.
    ///
    /// Text: Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
    ///
    /// Branchvalues: Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.
    ///
    /// Level: Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.
    ///
    /// Maxdepth: Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.
    static member Sunburst
        (
            labels          : seq<#IConvertible>,
            parents         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Ids            : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?Values         : seq<float>,
            [<Optional;DefaultParameterValue(null)>] ?Text           : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?Branchvalues   : StyleParam.BranchValues,
            [<Optional;DefaultParameterValue(null)>] ?Level          ,
            [<Optional;DefaultParameterValue(null)>] ?Maxdepth       : int
        ) =
            (fun (trace:('T :> Trace)) -> 
                labels       |> DynObj.setValue trace       "labels"
                parents       |> DynObj.setValue trace      "parents"
                Ids           |> DynObj.setValueOpt trace   "ids"
                Values        |> DynObj.setValueOpt trace   "values"
                Text          |> DynObj.setValueOpt trace   "text"
                Branchvalues  |> DynObj.setValueOptBy trace "branchvalues" StyleParam.BranchValues.convert
                Level         |> DynObj.setValueOpt trace   "level"
                Maxdepth      |> DynObj.setValueOpt trace   "maxdepth"
                trace
            )

    /// Applies the styles of treemap plot to TraceObjects 
    ///
    /// Parameters:
    ///
    /// labels      : Sets the labels of each of the sectors.
    ///
    /// parents     : Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.
    ///
    /// Ids         : Assigns id labels to each datum. These ids for object constancy of data points during animation.
    ///
    /// Values      : Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.
    ///
    /// Text        : Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
    ///
    /// Branchvalues: Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.
    ///
    /// Tiling      : Sets Tiling algorithm options
    ///
    /// PathBar     : Sets the Pathbar used to navigate zooming
    ///
    /// Level       : Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.
    ///
    /// Maxdepth    : Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.
    static member Treemap
        (
            labels          : seq<#IConvertible>,
            parents         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Ids            : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?Values         : seq<float>,
            [<Optional;DefaultParameterValue(null)>] ?Text           : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?Branchvalues   : StyleParam.BranchValues,
            [<Optional;DefaultParameterValue(null)>] ?Tiling         : TreemapTiling,
            [<Optional;DefaultParameterValue(null)>] ?PathBar        : Pathbar,
            [<Optional;DefaultParameterValue(null)>] ?Level          ,
            [<Optional;DefaultParameterValue(null)>] ?Maxdepth       : int
        ) =
            (fun (trace:('T :> Trace)) -> 
                labels          |> DynObj.setValue trace      "labels"
                parents         |> DynObj.setValue trace      "parents"
                Ids             |> DynObj.setValueOpt trace   "ids"
                Values          |> DynObj.setValueOpt trace   "values"
                Text            |> DynObj.setValueOpt trace   "text"
                Branchvalues    |> DynObj.setValueOptBy trace "branchvalues" StyleParam.BranchValues.convert
                Tiling          |> DynObj.setValueOpt trace   "tiling"
                PathBar         |> DynObj.setValueOpt trace   "pathbar"
                Level           |> DynObj.setValueOpt trace   "level"
                Maxdepth        |> DynObj.setValueOpt trace   "maxdepth"
                trace
            )

            

    // Applies the styles of parallel coordinates plot to TraceObjects 
    static member ParallelCoord
        (                
            [<Optional;DefaultParameterValue(null)>] ?Dimensions : seq<Dimensions>,
            [<Optional;DefaultParameterValue(null)>] ?Line               ,
            [<Optional;DefaultParameterValue(null)>] ?Domain             ,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont          ,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont   :   Font,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont  :   Font        
        ) =
            (fun (parcoords:('T :> Trace)) -> 
                
                Dimensions         |> DynObj.setValueOpt parcoords "dimensions"         
                Line               |> DynObj.setValueOpt parcoords "line"                     
                Domain             |> DynObj.setValueOpt parcoords "domain"     
                Labelfont          |> DynObj.setValueOpt parcoords "labelfont"               
                Tickfont           |> DynObj.setValueOpt parcoords "tickfont"                
                Rangefont          |> DynObj.setValueOpt parcoords "rangefont"              
                    
                // out ->
                parcoords 
            ) 
    
    static member ParallelCategories
        (                
            [<Optional;DefaultParameterValue(null)>] ?Dimensions : seq<Dimensions>,
            [<Optional;DefaultParameterValue(null)>] ?Line               ,
            [<Optional;DefaultParameterValue(null)>] ?Domain             ,
            [<Optional;DefaultParameterValue(null)>] ?Color : Color,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont          ,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont   :   Font,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont  :   Font        
        ) =
            (fun (parcats:('T :> Trace)) -> 
        
                Dimensions         |> DynObj.setValueOpt parcats "dimensions"         
                Line               |> DynObj.setValueOpt parcats "line"                     
                Domain             |> DynObj.setValueOpt parcats "domain"     
                Color              |> DynObj.setValueOpt parcats "color"     
                Labelfont          |> DynObj.setValueOpt parcats "labelfont"               
                Tickfont           |> DynObj.setValueOpt parcats "tickfont"                
                Rangefont          |> DynObj.setValueOpt parcats "rangefont"              
            
                // out ->
                parcats 
            ) 

    // Applies the styles of table plot to TraceObjects 
    static member Table
        (   
            header       : TableHeader  ,
            cells        : TableCells   ,
            [<Optional;DefaultParameterValue(null)>] ?ColumnWidth : seq<int>,
            [<Optional;DefaultParameterValue(null)>] ?ColumnOrder : seq<int>         
        ) =
            (fun (trace:('T :> Trace)) ->                  
                header      |> DynObj.setValue    trace "header"
                cells       |> DynObj.setValue    trace "cells"
                ColumnWidth |> DynObj.setValueOpt trace "columnwidth"
                ColumnOrder |> DynObj.setValueOpt trace "columnorder"
                // out ->
                trace
            ) 

    static member Indicator
        (
            [<Optional;DefaultParameterValue(null)>] ?Name              : string,
            [<Optional;DefaultParameterValue(null)>] ?Title             : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible           : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank        : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup       : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle  : Title,
            [<Optional;DefaultParameterValue(null)>] ?Mode              : StyleParam.IndicatorMode,
            [<Optional;DefaultParameterValue(null)>] ?Ids               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Value             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Meta              : string,
            [<Optional;DefaultParameterValue(null)>] ?CustomData        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Domain            : Domain,
            [<Optional;DefaultParameterValue(null)>] ?Align             : StyleParam.IndicatorAlignment,
            [<Optional;DefaultParameterValue(null)>] ?Delta             : IndicatorDelta,
            [<Optional;DefaultParameterValue(null)>] ?Number            : IndicatorNumber,
            [<Optional;DefaultParameterValue(null)>] ?Gauge             : IndicatorGauge,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision        : string
        ) =
            fun (trace: #Trace) ->                  
                
                Name              |> DynObj.setValueOpt trace "name"
                Title             |> DynObj.setValueOpt trace "title" 
                Visible           |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
                ShowLegend        |> DynObj.setValueOpt trace "showlegend"
                LegendRank        |> DynObj.setValueOpt trace "legendrank"
                LegendGroup       |> DynObj.setValueOpt trace "legendgroup"
                LegendGroupTitle  |> DynObj.setValueOpt trace "legendgrouptitle"
                Mode              |> DynObj.setValueOptBy trace "mode" StyleParam.IndicatorMode.convert
                Ids               |> DynObj.setValueOpt trace "ids"
                Value             |> DynObj.setValueOpt trace "value"
                Meta              |> DynObj.setValueOpt trace "meta"
                CustomData        |> DynObj.setValueOpt trace "customdata"
                Domain            |> DynObj.setValueOpt trace "domain"
                Align             |> DynObj.setValueOptBy trace "align" StyleParam.IndicatorAlignment.convert
                Delta             |> DynObj.setValueOpt trace "delta"
                Number            |> DynObj.setValueOpt trace "number"
                Gauge             |> DynObj.setValueOpt trace "gauge"
                UIRevision        |> DynObj.setValueOpt trace "uirevision"

                trace
