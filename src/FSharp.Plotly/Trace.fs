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
                ?ColorScale:StyleParam.ColorScale
            ) =
                (fun (trace:('T :> Trace)) ->
                    let line =
                        match (trace.TryGetValue "line") with
                        | Some line -> line :?> Line
                        | None -> Line.init (id)
                        |> Line.LineStyle.Apply(?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?ColorScale=ColorScale)
                    
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
                ?Colorscale     ,
                ?Colors         ,
                            
                ?Maxdisplayed   ,
                ?Sizeref        ,
                ?Sizemin        ,
                ?Sizemode       ,
                ?Cauto          ,
                ?Cmax           ,
                ?Cmin           ,
                ?Autocolorscale ,
                ?Reversescale   ,
                ?Showscale      ,
                            
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
                    
                        |> Marker.MarkerStyle.Apply(?Size=Size,?Color=Color,?Symbol=Symbol,
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


        // Applies the styles to Bar()
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

        // Applies the styles to Pie()
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


        // Applies the styles to |> DynObj.setValueOpt pie "
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







