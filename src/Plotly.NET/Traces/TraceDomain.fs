namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System

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
    
    // Applies the styles of pie plot to TraceObjects 
    static member Pie
        (                
            ?Values: seq<#IConvertible>,
            ?Labels: seq<#IConvertible>,
            ?Label0: #IConvertible,
            ?dLabel: #IConvertible,   
            ?Scalegroup,
            ?Textinfo,
            //?Textfont: FontOptions,                    
            ?Insidetextfont: Font,
            ?Outsidetextfont: Font,
            ?Domain, // TODO
            ?Hole: float,
            ?Sort: bool,
            ?Direction, // TODO
            ?Rotation: float,
            ?Pull: float,
            ?Labelssrc: string,
            ?Valuessrc: string,
            ?Pullsrc

        ) =
            (fun (pie:('T :> Trace)) ->

                Values          |> DynObj.setValueOpt pie "values"
                Labels          |> DynObj.setValueOpt pie "labels"
                Label0          |> DynObj.setValueOpt pie "label0"
                dLabel          |> DynObj.setValueOpt pie "dlabel" //-- temporarily
                Scalegroup      |> DynObj.setValueOpt pie "scalegroup"
                Textinfo        |> DynObj.setValueOpt pie "textinfo"      
                                    
                Domain          |> DynObj.setValueOpt pie "domain"         
                Hole            |> DynObj.setValueOpt pie "hole"           
                Sort            |> DynObj.setValueOpt pie "sort"          
                Direction       |> DynObj.setValueOpt pie "direction"      
                Rotation        |> DynObj.setValueOpt pie "rotation"       
                Pull            |> DynObj.setValueOpt pie "pull"           
                Labelssrc       |> DynObj.setValueOpt pie "labelssrc"      
                Valuessrc       |> DynObj.setValueOpt pie "valuessrc"      
                Pullsrc         |> DynObj.setValueOpt pie "pullsrc"        
                    
                // Update
                //Marker          |> Option.iter (updatePropertyValueAndIgnore pie <@ pie.marker          @>)
                //Textfont        |> Option.iter (updatePropertyValueAndIgnore pie <@ pie.textfont        @>)
                Insidetextfont  |> DynObj.setValueOpt pie "insidetextfont"
                Outsidetextfont |> DynObj.setValueOpt pie "outsidetextfont"
                        
                // out ->
                pie
            ) 

            
    static member FunnelArea
        (
            ?Values        : seq<#IConvertible>,
            ?Labels        : seq<#IConvertible>,
            ?dLabel        : float,
            ?Label0        : float,
            ?Aspectratio   : float,
            ?Baseratio     : float,
            ?Insidetextfont: Font,
            ?Scalegroup    : string
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
            ?Ids            : seq<string>,
            ?Values         : seq<float>,
            ?Text           : seq<string>,
            ?Branchvalues   : StyleParam.BranchValues,
            ?Level          ,
            ?Maxdepth       : int
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
            ?Ids            : seq<string>,
            ?Values         : seq<float>,
            ?Text           : seq<string>,
            ?Branchvalues   : StyleParam.BranchValues,
            ?Tiling         : TreemapTiling,
            ?PathBar        : Pathbar,
            ?Level          ,
            ?Maxdepth       : int
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
            ?Dimensions : seq<Dimensions>,
            ?Line               ,
            ?Domain             ,
            ?Labelfont          ,
            ?Tickfont   :   Font,
            ?Rangefont  :   Font        
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
            ?Dimensions : seq<Dimensions>,
            ?Line               ,
            ?Domain             ,
            ?Color      : seq<#IConvertible>,
            ?Labelfont          ,
            ?Tickfont   :   Font,
            ?Rangefont  :   Font        
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
            ?ColumnWidth : seq<int>,
            ?ColumnOrder : seq<int>         
        ) =
            (fun (trace:('T :> Trace)) ->                  
                header      |> DynObj.setValue    trace "header"
                cells       |> DynObj.setValue    trace "cells"
                ColumnWidth |> DynObj.setValueOpt trace "columnwidth"
                ColumnOrder |> DynObj.setValueOpt trace "columnorder"
                // out ->
                trace
            ) 

