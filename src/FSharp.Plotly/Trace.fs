namespace FSharp.Plotly

open System

/// Trace type inherits from dynamic object
type Trace (traceTypeName) =
    inherit DynamicObj ()
    //interface ITrace with
        // Implictit ITrace
    member val ``type`` = traceTypeName with get,set



[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Trace = 

    /// Init trace for scatter plot
    let initScatter (applyStyle:Trace->Trace) = 
        Trace("scatter") |> applyStyle

    /// Init trace for bar chart
    let initBar (applyStyle:Trace->Trace) = 
        Trace("bar") |> applyStyle

    /// Init trace for box plot
    let initBoxPlot (applyStyle:Trace->Trace) = 
        Trace("box") |> applyStyle

    /// Init trace for pie chart
    let initPie (applyStyle:Trace->Trace) = 
        Trace("pie") |> applyStyle

    /// Init trace for Heatmap
    let initHeatmap (applyStyle:Trace->Trace) = 
        Trace("heatmap") |> applyStyle

    /// Init trace for Contour
    let initContour (applyStyle:Trace->Trace) = 
        Trace("contour") |> applyStyle

    /// Init trace for 2d-histogram
    let initHistogram2d (applyStyle:Trace->Trace) = 
        Trace("histogram2d") |> applyStyle

    /// Functions provide the styling of the Chart objects
    type TraceStyle() =
        
        /// Applies the TraceInfo styles to TraceObjects
        static member TraceInfo
            (    
                ?Name: string,
                ?Visible: StyleParam.Visible,
                ?Showlegend: bool,
                ?Legendgroup:string,
                ?Opacity: float,
                ?Uid: string,
                ?Hoverinfo: string
                //?Stream: Stream

            ) =
                (fun (trace:('T :> Trace)) ->  
                    Name        |> DynObj.setValueOpt trace "name"
                    Visible     |> DynObj.setValueOptBy trace "name" StyleParam.Visible.toString
                    Showlegend  |> DynObj.setValueOpt trace "showlegendName"
                    Legendgroup |> DynObj.setValueOpt trace "legendgroup"  
                    Opacity     |> DynObj.setValueOpt trace "opacity"
                    Uid         |> DynObj.setValueOpt trace "uid"
                    Hoverinfo   |> DynObj.setValueOpt trace "hoverinfo"
                    // Update
                    //Stream: Stream                    
                    
                    // out ->
                    trace
                ) 


        // Applies the styles of TextLabel to TraceObjects
        static member TextLabel
            (    
                ?Text   : seq<#IConvertible>,
                ?Textposition: StyleParam.TextPosition,
                ?Textfont: Font,
                ?Textsrc : string,
                ?Textpositionsrc : string

            ) =
                (fun (trace:('T :> Trace)) ->
                    Text            |> DynObj.setValueOpt trace "text"
                    Textposition    |> DynObj.setValueOptBy trace "textposition" StyleParam.TextPosition.toString                  
                    Textsrc         |> DynObj.setValueOpt trace "textsrc"
                    Textpositionsrc |> DynObj.setValueOpt trace "textpositionsrc"
                    Textfont        |> DynObj.setValueOpt trace "textfont"
                    
                    // out ->
                    trace
                )  


        // Sets Line() to TraceObjects
        static member SetLine
            (
                line:Line
            ) =  
                (fun (trace:('T :> Trace)) ->

                    trace.SetValue("line", line)
                    trace
                )


        // Applies the styles to Line()
        static member Line
            (
                ?Width,
                ?Color,
                ?Shape:StyleParam.Shape,
                ?Dash,
                ?Smoothing,
                ?Colorscale : StyleParam.Colorscale
            ) =
                (fun (trace:('T :> Trace)) ->
                    let line =
                        match (trace.TryGetValue "line") with
                        | Some line -> line :?> Line
                        | None -> Line.init (id)
                        |> Line.style(?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?Colorscale=Colorscale)
                    
                    trace.SetValue("line", line)
                    trace
                )    


        // Sets Marker() to TraceObjects
        static member SetMarker
            (
                marker:Marker
            ) =  
                (fun (trace:('T :> Trace)) ->

                    trace.SetValue("marker", marker)
                    trace
                )


        // Applies the styles to Marker()
        static member Marker
            (   
                ?Size:int,
                ?Color,
                ?Symbol:StyleParam.Symbol,
                ?Opacity:float,
                ?MultiSizes:seq<#IConvertible>,
                ?Line : Line,
                ?Colorbar       ,
                ?Colorscale : StyleParam.Colorscale,
                ?Colors         ,
                            
                ?Maxdisplayed   ,
                ?Sizeref        ,
                ?Sizemin        ,
                ?Sizemode       ,
                ?Cauto          ,
                ?Cmax           ,
                ?Cmin           ,
                ?Autocolorscale : bool,
                ?Reversescale   : bool,
                ?Showscale      : bool,
                            
                ?Symbolsrc      ,
                ?Opacitysrc     ,
                ?Sizesrc        ,
                ?Colorsrc       ,
                ?Cutliercolor   ,
                ?Colorssrc      

            ) =
                (fun (trace:('T :> Trace)) ->
                    let marker =
                        match (trace.TryGetValue "marker") with
                        | Some m -> m :?> Marker
                        | None -> Marker ()
                    
                        |> Marker.style(?Size=Size,?Color=Color,?Symbol=Symbol,
                            ?Opacity=Opacity,?MultiSizes=MultiSizes,?Line=Line,
                            ?Colorbar=Colorbar,?Colorscale=Colorscale,?Colors=Colors,
                            ?Maxdisplayed=Maxdisplayed,?Sizeref=Sizeref,?Sizemin=Sizemin,
                            ?Sizemode=Sizemode,?Cauto=Cauto,?Cmax=Cmax,?Cmin=Cmin,
                            ?Autocolorscale=Autocolorscale,?Reversescale=Reversescale,?Showscale=Showscale,
                            ?Symbolsrc=Symbolsrc,?Opacitysrc=Opacitysrc,?Sizesrc=Sizesrc,
                            ?Colorsrc=Colorsrc,?Cutliercolor=Cutliercolor,?Colorssrc=Colorssrc
                            )

                    trace.SetValue("marker", marker)
                    trace                   

                )

        // Sets X-Error() to TraceObjects
        static member SetErrorX
            (
                error:Error
            ) =  
                (fun (trace:('T :> Trace)) ->

                    trace.SetValue("error_x", error)
                    trace
                )

        // Sets Y-Error() to TraceObjects
        static member SetErrorY
            (
                error:Error
            ) =  
                (fun (trace:('T :> Trace)) ->

                    trace.SetValue("error_y", error)
                    trace
                )

        // Sets Z-Error() to TraceObjects
        static member SetErrorZ
            (
                error:Error
            ) =  
               (fun (trace:('T :> Trace)) ->

                    trace.SetValue("error_z", error)
                    trace
                )


// #################################
// # Charts 


        // Applies the styles of scatter plot to TraceObjects 
        static member Scatter
            (   
                ?X      : seq<#IConvertible>,
                ?Y      : seq<#IConvertible>,
                ?Mode: StyleParam.Mode,         
                ?Fill: StyleParam.Fill,
                ?Fillcolor: string,                        
                ?Connectgaps: bool, 
                ?R: _, 
                ?T: _,
                ?Error_y: Error,
                ?Error_x: Error
            ) =
                (fun (trace:('T :> Trace)) ->
                    //scatter.set_type plotType                     
                    X            |> DynObj.setValueOpt trace "x"
                    Y            |> DynObj.setValueOpt trace "y"
                    Mode         |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.toString
                    Connectgaps  |> DynObj.setValueOpt trace "connectgaps"
                    Fill         |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.toString
                    Fillcolor    |> DynObj.setValueOpt trace "fillcolor"                    
                    R            |> DynObj.setValueOpt trace "r"
                    T            |> DynObj.setValueOpt trace "t"
                    // Update
                    Error_x      |> DynObj.setValueOpt trace "error_x"
                    Error_y      |> DynObj.setValueOpt trace "error_y"
                        
                    // out ->
                    trace
                ) 


        // Applies the styles of bar plot to TraceObjects 
        static member Bar
            (   
                ?X      : seq<#IConvertible>,
                ?Y      : seq<#IConvertible>,                                 
                ?Marker : Marker,            
                ?R: _, ?T: _,
                ?Error_y: Error,
                ?Error_x: Error,
                // 
                ?Orientation
            ) =
                (fun (bar:('T :> Trace)) ->    
                    X            |> DynObj.setValueOpt bar "x"
                    Y            |> DynObj.setValueOpt bar "y"    
                    R            |> DynObj.setValueOpt bar "r"
                    T            |> DynObj.setValueOpt bar "t"
                    Orientation  |> DynObj.setValueOptBy bar "orientation" StyleParam.Orientation.convert
                        
                    // Update                
                    Marker       |> DynObj.setValueOpt bar "marker"                
                    Error_x      |> DynObj.setValueOpt bar "error_x"
                    Error_y      |> DynObj.setValueOpt bar "error_y"
                        
                    // out ->
                    bar

               ) 

        // Applies the styles of pie plot to TraceObjects 
        static member Pie
            (                
                ?Values,
                ?Labels,
                ?Label0,
                ?dLabel,   
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


        // Applies the styles of box plot plot to TraceObjects 
        static member BoxPlot
            (            
                ?Y,           
                ?X,           
                ?X0,          
                ?Y0,          
                ?Whiskerwidth,
                ?Boxpoints,   
                ?Boxmean,     
                ?Jitter,      
                ?Pointpos,    
                ?Orientation, 
                ?Fillcolor,   
                ?xAxis,       
                ?yAxis,       
                ?Ysrc,        
                ?Xsrc        

            ) =
                (fun (boxPlot:('T :> Trace)) ->

                    Y            |> DynObj.setValueOpt boxPlot "y"           
                    X            |> DynObj.setValueOpt boxPlot "x"           
                    X0           |> DynObj.setValueOpt boxPlot "x0"          
                    Y0           |> DynObj.setValueOpt boxPlot "y0"          
                    Whiskerwidth |> DynObj.setValueOpt boxPlot "whiskerwidth"
                    Boxpoints    |> DynObj.setValueOptBy boxPlot "boxpoints"  StyleParam.Boxpoints.convert  
                    Boxmean      |> DynObj.setValueOptBy boxPlot "boxmean"    StyleParam.BoxMean.convert    
                    Jitter       |> DynObj.setValueOpt boxPlot "jitter"      
                    Pointpos     |> DynObj.setValueOpt boxPlot "pointpos"    
                    Orientation  |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
                    Fillcolor    |> DynObj.setValueOpt boxPlot "fillcolor"   
                    xAxis        |> DynObj.setValueOpt boxPlot "xaxis"       
                    yAxis        |> DynObj.setValueOpt boxPlot "yaxis"       
                    Ysrc         |> DynObj.setValueOpt boxPlot "ysrc"        
                    Xsrc         |> DynObj.setValueOpt boxPlot "xsrc"        
                    
                    // out ->
                    boxPlot
                ) 




        // Applies the styles of heatmap to TraceObjects 
        static member Heatmap
            (                
                ?Z : seq<#seq<#IConvertible>>,
                ?X : seq<#IConvertible>,
                ?Y : seq<#IConvertible>,            
                ?X0             ,
                ?dX             ,
                ?Y0             ,
                ?dY             ,
                ?xType          ,
                ?yType          ,
                ?xAxis          ,
                ?yAxis          ,
                ?Zsrc           ,
                ?Xsrc           ,
                ?Ysrc           ,

                ?Xgap           ,         
                ?Ygap           ,
                ?Transpose      ,
                ?zAuto          ,
                ?zMin           ,
                ?zMax           ,
                ?Colorscale     ,
                ?Autocolorscale ,
                ?Reversescale   ,
                ?Showscale      ,
                ?zSmooth        ,
                ?Colorbar
            ) =
                (fun (heatmap:('T :> Trace)) -> 
                
                    Z              |> DynObj.setValueOpt heatmap "z"         
                    X              |> DynObj.setValueOpt heatmap "x"               
                    Y              |> DynObj.setValueOpt heatmap "y"
                    X0             |> DynObj.setValueOpt heatmap "x0"             
                    dX             |> DynObj.setValueOpt heatmap "dx"             
                    Y0             |> DynObj.setValueOpt heatmap "y0"            
                    dY             |> DynObj.setValueOpt heatmap "dy"            
                    xType          |> DynObj.setValueOpt heatmap "xtype"         
                    yType          |> DynObj.setValueOpt heatmap "ytype"                          
                    xAxis          |> DynObj.setValueOpt heatmap "xaxis"         
                    yAxis          |> DynObj.setValueOpt heatmap "yaxis"         
                    Zsrc           |> DynObj.setValueOpt heatmap "zsrc"       
                    Xsrc           |> DynObj.setValueOpt heatmap "xsrc"       
                    Ysrc           |> DynObj.setValueOpt heatmap "ysrc"  

                    Xgap           |> DynObj.setValueOpt heatmap "xgap"       
                    Ygap           |> DynObj.setValueOpt heatmap "ygap"  
                    Transpose      |> DynObj.setValueOpt heatmap "transpose" 
                    zAuto          |> DynObj.setValueOpt heatmap "zauto"     
                    zMin           |> DynObj.setValueOpt heatmap "zmin"      
                    zMax           |> DynObj.setValueOpt heatmap "zmax"      
                    Colorscale     |> DynObj.setValueOptBy heatmap "colorscale" StyleParam.Colorscale.convert 
                    Autocolorscale |> DynObj.setValueOpt heatmap "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt heatmap "reversescale"  
                    Showscale      |> DynObj.setValueOpt heatmap "showscale"     
                    zSmooth        |> DynObj.setValueOptBy heatmap "zsmooth" StyleParam.SmoothAlg.convert   
                    Colorbar       |> DynObj.setValueOpt heatmap "colorbar"    

                    // out ->
                    heatmap 
                ) 

        static member Contour
            (                
                ?Z : seq<#seq<#IConvertible>>,
                ?X : seq<#IConvertible>,
                ?Y : seq<#IConvertible>,            
                ?X0             ,
                ?dX             ,
                ?Y0             ,
                ?dY             ,
                ?xType          ,
                ?yType          ,
                ?xAxis          ,
                ?yAxis          ,
                ?Zsrc           ,
                ?Xsrc           ,
                ?Ysrc           ,

                ?Xgap           ,         
                ?Ygap           ,
                ?Transpose      ,
                ?zAuto          ,
                ?zMin           ,
                ?zMax           ,
                ?Colorscale     ,
                ?Autocolorscale ,
                ?Reversescale   ,
                ?Showscale      ,
                ?zSmooth        ,
                ?Colorbar
            ) =
                (fun (contour:('T :> Trace)) -> 
                
                    Z              |> DynObj.setValueOpt contour "z"         
                    X              |> DynObj.setValueOpt contour "x"               
                    Y              |> DynObj.setValueOpt contour "y"
                    X0             |> DynObj.setValueOpt contour "x0"             
                    dX             |> DynObj.setValueOpt contour "dx"             
                    Y0             |> DynObj.setValueOpt contour "y0"            
                    dY             |> DynObj.setValueOpt contour "dy"            
                    xType          |> DynObj.setValueOpt contour "xtype"         
                    yType          |> DynObj.setValueOpt contour "ytype"                          
                    xAxis          |> DynObj.setValueOpt contour "xaxis"         
                    yAxis          |> DynObj.setValueOpt contour "yaxis"         
                    Zsrc           |> DynObj.setValueOpt contour "zsrc"       
                    Xsrc           |> DynObj.setValueOpt contour "xsrc"       
                    Ysrc           |> DynObj.setValueOpt contour "ysrc"  

                    Xgap           |> DynObj.setValueOpt contour   "xgap"       
                    Ygap           |> DynObj.setValueOpt contour   "ygap"  
                    Transpose      |> DynObj.setValueOpt contour   "transpose" 
                    zAuto          |> DynObj.setValueOpt contour   "zauto"     
                    zMin           |> DynObj.setValueOpt contour   "zmin"      
                    zMax           |> DynObj.setValueOpt contour   "zmax"      
                    Colorscale     |> DynObj.setValueOptBy contour "colorscale" StyleParam.Colorscale.convert 
                    Autocolorscale |> DynObj.setValueOpt contour   "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt contour   "reversescale"  
                    Showscale      |> DynObj.setValueOpt contour   "showscale"     
                    zSmooth        |> DynObj.setValueOptBy contour "zsmooth" StyleParam.SmoothAlg.convert   
                    Colorbar       |> DynObj.setValueOpt contour   "colorbar"    

                    // out ->
                    contour 
                )


        // Applies the styles of histogram to TraceObjects



//    let mutable _connectgaps: bool option = None
//    let mutable _histfunc: _ option = None
//    let mutable _histnorm: _ option = None
//    let mutable _autobinx: bool option = None
//    let mutable _nbinsx: int option = None
//    let mutable _xbins: Xbins option = None
//    let mutable _autobiny: bool option = None
//    let mutable _nbinsy: int option = None
//    let mutable _ybins: Ybins option = None

        static member Histogram2d
            (            
                ?Z : seq<#seq<#IConvertible>>,
                ?X : seq<#IConvertible>,
                ?Y : seq<#IConvertible>,            
                ?X0             ,
                ?dX             ,
                ?Y0             ,
                ?dY             ,
                ?xType          ,
                ?yType          ,
                ?xAxis          ,
                ?yAxis          ,
                ?Zsrc           ,
                ?Xsrc           ,
                ?Ysrc           ,

                ?Marker : Marker, 
                ?Orientation    , 

                ?Xgap           ,         
                ?Ygap           ,
                ?Transpose      ,
                ?zAuto          ,
                ?zMin           ,
                ?zMax           ,
                ?Colorscale     ,
                ?Autocolorscale ,
                ?Reversescale   ,
                ?Showscale      ,
                ?zSmooth        ,
                ?Colorbar      

            ) =
                (fun (histogram2d:('T :> Trace)) ->

                    Z              |> DynObj.setValueOpt histogram2d "z"         
                    X              |> DynObj.setValueOpt histogram2d "x"               
                    Y              |> DynObj.setValueOpt histogram2d "y"
                    X0             |> DynObj.setValueOpt histogram2d "x0"             
                    dX             |> DynObj.setValueOpt histogram2d "dx"             
                    Y0             |> DynObj.setValueOpt histogram2d "y0"            
                    dY             |> DynObj.setValueOpt histogram2d "dy"            
                    xType          |> DynObj.setValueOpt histogram2d "xtype"         
                    yType          |> DynObj.setValueOpt histogram2d "ytype"                          
                    xAxis          |> DynObj.setValueOpt histogram2d "xaxis"         
                    yAxis          |> DynObj.setValueOpt histogram2d "yaxis"         
                    Zsrc           |> DynObj.setValueOpt histogram2d "zsrc"       
                    Xsrc           |> DynObj.setValueOpt histogram2d "xsrc"       
                    Ysrc           |> DynObj.setValueOpt histogram2d "ysrc"  

                    Orientation  |> DynObj.setValueOptBy histogram2d "orientation" StyleParam.Orientation.convert

                    Xgap           |> DynObj.setValueOpt histogram2d   "xgap"       
                    Ygap           |> DynObj.setValueOpt histogram2d   "ygap"  
                    Transpose      |> DynObj.setValueOpt histogram2d   "transpose" 
                    zAuto          |> DynObj.setValueOpt histogram2d   "zauto"     
                    zMin           |> DynObj.setValueOpt histogram2d   "zmin"      
                    zMax           |> DynObj.setValueOpt histogram2d   "zmax"      
                    Colorscale     |> DynObj.setValueOptBy histogram2d "colorscale" StyleParam.Colorscale.convert 
                    Autocolorscale |> DynObj.setValueOpt histogram2d   "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt histogram2d   "reversescale"  
                    Showscale      |> DynObj.setValueOpt histogram2d   "showscale"     
                    zSmooth        |> DynObj.setValueOptBy histogram2d "zsmooth" StyleParam.SmoothAlg.convert   
                    Colorbar       |> DynObj.setValueOpt histogram2d   "colorbar"    

                    // Update                
                    Marker       |> DynObj.setValueOpt histogram2d "marker"  
                    
                    // out ->
                    histogram2d
                ) 

