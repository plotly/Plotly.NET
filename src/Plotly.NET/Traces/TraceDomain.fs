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
                trace
                ++? ("domain", Domain)

                trace
            )

    // Applies the styles of pie plot to TraceObjects 
    static member Pie
        (                
            [<Optional;DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Label0: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?dLabel: #IConvertible,   
            [<Optional;DefaultParameterValue(null)>] ?Scalegroup,
            [<Optional;DefaultParameterValue(null)>] ?Textinfo,
            [<Optional;DefaultParameterValue(null)>] ?Insidetextfont: Font,
            [<Optional;DefaultParameterValue(null)>] ?Outsidetextfont: Font,
            [<Optional;DefaultParameterValue(null)>] ?Domain, // TODO
            [<Optional;DefaultParameterValue(null)>] ?Hole: float,
            [<Optional;DefaultParameterValue(null)>] ?Sort: bool,
            [<Optional;DefaultParameterValue(null)>] ?Direction, // TODO
            [<Optional;DefaultParameterValue(null)>] ?Rotation: float,
            [<Optional;DefaultParameterValue(null)>] ?Pull: float,
            [<Optional;DefaultParameterValue(null)>] ?Labelssrc: string,
            [<Optional;DefaultParameterValue(null)>] ?Valuessrc: string,
            [<Optional;DefaultParameterValue(null)>] ?Pullsrc

        ) =
            (fun (pie:('T :> Trace)) ->

                ++? ("values", Values)
                ++? ("labels", Labels)
                Label0          |> DynObj.setValueOpt pie "label0"
                ++? ("dlabel", dLabel) //-- temporarily
                ++? ("scalegroup", Scalegroup)
                ++? ("textinfo", Textinfo)      
                                    
                ++? ("domain", Domain)         
                ++? ("hole", Hole)           
                ++? ("sort", Sort)          
                ++? ("direction", Direction)      
                ++? ("rotation", Rotation)       
                ++? ("pull", Pull)           
                ++? ("labelssrc", Labelssrc)      
                ++? ("valuessrc", Valuessrc)      
                ++? ("pullsrc", Pullsrc)        
                    
                // Update
                //Marker          |> Option.iter (updatePropertyValueAndIgnore pie <@ pie.marker          @>)
                //Textfont        |> Option.iter (updatePropertyValueAndIgnore pie <@ pie.textfont        @>)
                ++? ("insidetextfont", Insidetextfont)
                ++? ("outsidetextfont", Outsidetextfont)
                        
                // out ->
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
        
                ++? ("values", Values)
                ++? ("labels", Labels)
                ++? ("dlabel", dLabel)
                Label0         |> DynObj.setValueOpt   trace "label0"
                ++? ("aspectratio", Aspectratio)
                ++? ("baseratio", Baseratio)
                ++? ("insidetextfont", Insidetextfont)
                ++? ("scalegroup", Scalegroup)

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
                labels       |> ++ ("labels", parents       |> DynObj.setValue trace      "parents")
                ++? ("ids", Ids)
                ++? ("values", Values)
                ++? ("text", Text)
                ++?? ("branchvalues", Branchvalues, StyleParam.BranchValues.convert)
                ++? ("level", Level)
                ++? ("maxdepth", Maxdepth)
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
                labels          |> ++ ("labels", parents         |> DynObj.setValue trace      "parents")
                ++? ("ids", Ids)
                ++? ("values", Values)
                ++? ("text", Text)
                ++?? ("branchvalues", Branchvalues, StyleParam.BranchValues.convert)
                ++? ("tiling", Tiling)
                ++? ("pathbar", PathBar)
                ++? ("level", Level)
                ++? ("maxdepth", Maxdepth)
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
                
                ++? ("dimensions", Dimensions)         
                ++? ("line", Line)                     
                ++? ("domain", Domain)     
                ++? ("labelfont", Labelfont)               
                ++? ("tickfont", Tickfont)                
                ++? ("rangefont", Rangefont)              
                    
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
        
                ++? ("dimensions", Dimensions)         
                ++? ("line", Line)                     
                ++? ("domain", Domain)     
                ++? ("color", Color)     
                ++? ("labelfont", Labelfont)               
                ++? ("tickfont", Tickfont)                
                ++? ("rangefont", Rangefont)              
            
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
                header      |> ++ ("header", cells       |> DynObj.setValue    trace "cells")
                ++? ("columnwidth", ColumnWidth)
                ++? ("columnorder", ColumnOrder)
                // out ->
                trace
            ) 

