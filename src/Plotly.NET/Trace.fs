namespace Plotly.NET

open System

/// Trace type inherits from dynamic object
type Trace (traceTypeName) =
    inherit DynamicObj ()
    //interface ITrace with
        // Implictit ITrace
    member val ``type`` = traceTypeName with get,set



[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Trace = 
    

    //Trace Types

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //Simple

    ///initializes a trace of type "scatter" applying the givin trace styling function
    let initScatter (applyStyle:Trace->Trace) = 
        Trace("scatter") |> applyStyle

    ///initializes a trace of type "scattergl" applying the givin trace styling function
    let initScatterGL (applyStyle:Trace->Trace) = 
        Trace("scattergl") |> applyStyle

    ///initializes a trace of type "bar" applying the givin trace styling function
    let initBar (applyStyle:Trace->Trace) = 
        Trace("bar") |> applyStyle

    ///initializes a trace of type "pie" applying the givin trace styling function
    let initPie (applyStyle:Trace->Trace) = 
        Trace("pie") |> applyStyle

    ///initializes a trace of type "heatmap" applying the givin trace styling function
    let initHeatmap (applyStyle:Trace->Trace) = 
        Trace("heatmap") |> applyStyle

    ///initializes a trace of type "image" applying the givin trace styling function
    let initImage (applyStyle:Trace->Trace) = 
         Trace("image") |> applyStyle

    ///initializes a trace of type "contour" applying the givin trace styling function
    let initContour (applyStyle:Trace->Trace) = 
        Trace("contour") |> applyStyle

    ///initializes a trace of type "Table" applying the givin trace styling function
    /// Init trace for table
    let initTable (applyStyle:Trace->Trace) = 
        Trace("table") |> applyStyle

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //Distributions

    ///initializes a trace of type "box" applying the givin trace styling function
    let initBoxPlot (applyStyle:Trace->Trace) = 
        Trace("box") |> applyStyle

    ///initializes a trace of type "violin" applying the givin trace styling function
    let initViolin (applyStyle:Trace->Trace) = 
        Trace("violin") |> applyStyle

    ///initializes a trace of type "histogram" applying the givin trace styling function
    let initHistogram (applyStyle:Trace->Trace) = 
        Trace("histogram") |> applyStyle

    ///initializes a trace of type "histogram2d" applying the givin trace styling function
    let initHistogram2d (applyStyle:Trace->Trace) = 
        Trace("histogram2d") |> applyStyle

    ///initializes a trace of type "histogram2dcontour" applying the givin trace styling function
    let initHistogram2dContour (applyStyle:Trace->Trace) = 
        Trace("histogram2dcontour") |> applyStyle

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //Finance

    ///initializes a trace of type "ohlc" applying the givin trace styling function
    let initOHLC (applyStyle:Trace->Trace) = 
        Trace("ohlc") |> applyStyle

    ///initializes a trace of type "candlestick" applying the givin trace styling function
    let initCandlestick (applyStyle:Trace->Trace) = 
        Trace("candlestick") |> applyStyle

    ///initializes a trace of type "waterfall" applying the givin trace styling function
    let initWaterfall (applyStyle:Trace->Trace) = 
        Trace("waterfall") |> applyStyle

    ///initializes a trace of type "funnel" applying the givin trace styling function
    let initFunnel (applyStyle:Trace->Trace) = 
        Trace("funnel") |> applyStyle

    ///initializes a trace of type "funnelarea" applying the givin trace styling function
    let initFunnelArea (applyStyle:Trace->Trace) = 
        Trace("funnelarea") |> applyStyle

    ///initializes a trace of type "indicator" applying the givin trace styling function
    let initIndicator (applyStyle:Trace->Trace) = 
        Trace("indicator") |> applyStyle

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //Maps

    ///initializes a trace of type "scattergeo" applying the givin trace styling function
    let initScatterGeo (applyStyle:Trace->Trace) = 
        Trace("scattergeo") |> applyStyle

    ///initializes a trace of type "choropleth" applying the givin trace styling function
    let initChoroplethMap (applyStyle:Trace->Trace) = 
        Trace("choropleth") |> applyStyle

    ///initializes a trace of type "scattermapbox" applying the givin trace styling function
    let initScatterMapbox (applyStyle:Trace->Trace) = 
        Trace("scattermapbox") |> applyStyle

    ///initializes a trace of type "choroplethmapbox" applying the givin trace styling function
    let initChoroplethMapbox (applyStyle:Trace->Trace) = 
        Trace("choroplethmapbox") |> applyStyle

    ///initializes a trace of type "densitymapbox" applying the givin trace styling function
    let initDensityMapbox (applyStyle:Trace->Trace) = 
        Trace("densitymapbox") |> applyStyle

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //Specialized
    ///initializes a trace of type "scatterpolar" applying the givin trace styling function
    let initScatterPolar (applyStyle:Trace->Trace) = 
        Trace("scatterpolar") |> applyStyle

    ///initializes a trace of type "scatterpolargl" applying the givin trace styling function
    let initScatterPolarGL (applyStyle:Trace->Trace) = 
        Trace("scatterpolargl") |> applyStyle

    ///initializes a trace of type "barpolar" applying the givin trace styling function
    let initBarPolar (applyStyle:Trace->Trace) = 
        Trace("barpolar") |> applyStyle

    ///initializes a trace of type "scatterternary" applying the givin trace styling function
    let initScatterTernary (applyStyle:Trace->Trace) = 
        Trace("scatterternary") |> applyStyle

    ///initializes a trace of type "sunburst" applying the givin trace styling function
    let initSunburst (applyStyle:Trace->Trace) = 
        Trace("sunburst") |> applyStyle

    ///initializes a trace of type "treemap" applying the givin trace styling function
    let initTreemap (applyStyle:Trace->Trace) = 
        Trace("treemap") |> applyStyle

    ///initializes a trace of type "sankey" applying the givin trace styling function
    let initSankey (applyStyle:Trace->Trace) = 
        Trace("sankey") |> applyStyle

    ///initializes a trace of type "SPLOM" applying the givin trace styling function
    let initSplom (applyStyle:Trace->Trace) = 
        Trace("splom") |> applyStyle

    ///initializes a trace of type "parcoords" applying the givin trace styling function
    let initParallelCoord (applyStyle:Trace->Trace) = 
        Trace("parcoords") |> applyStyle

    ///initializes a trace of type "parcats" applying the givin trace styling function
    let initParallelCategories (applyStyle: Trace -> Trace) =
        Trace("parcats") |> applyStyle

    ///initializes a trace of type "carpet" applying the givin trace styling function
    let initCarpet (applyStyle:Trace->Trace) = 
        Trace("carpet") |> applyStyle

    ///initializes a trace of type "scattercarpet" applying the givin trace styling function
    let initScatterCarpet (applyStyle:Trace->Trace) = 
        Trace("scattercarpet") |> applyStyle

    ///initializes a trace of type "contourcarpet" applying the givin trace styling function
    let initContourCarpet (applyStyle:Trace->Trace) = 
        Trace("contourcarpet") |> applyStyle



    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //Custom

    /// Init trace for wind rose chart 
    let initWindRose (applyStyle:Trace->Trace) = 
        Trace("area") |> applyStyle

    //-------------------------------------------------------------------------------------------------------------------------------------------------
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
                    Visible     |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.toString
                    Showlegend  |> DynObj.setValueOpt trace "showlegend"
                    Legendgroup |> DynObj.setValueOpt trace "legendgroup"  
                    Opacity     |> DynObj.setValueOpt trace "opacity"
                    Uid         |> DynObj.setValueOpt trace "uid"
                    Hoverinfo   |> DynObj.setValueOpt trace "hoverinfo"
                    // Update
                    //Stream: Stream                    
                    
                    // out ->
                    trace
                ) 

        // Sets Axis anchor id to TraceObjects
        static member SetAxisAnchor
            (
                ?X:StyleParam.AxisAnchorId,
                ?Y:StyleParam.AxisAnchorId,
                ?Z:StyleParam.AxisAnchorId
            ) =  
                (fun (trace:('T :> Trace)) ->

                    X     |> DynObj.setValueOptBy trace "xaxis" StyleParam.AxisAnchorId.toString
                    Y     |> DynObj.setValueOptBy trace "yaxis" StyleParam.AxisAnchorId.toString
                    Z     |> DynObj.setValueOptBy trace "zaxis" StyleParam.AxisAnchorId.toString
                    
                    trace
                )

        // Sets selection of data points
        static member SetSelection
            (
                ?Selectedpoints,
                ?Selected,
                ?UnSelected
            ) =  
                (fun (trace:('T :> Trace)) ->

                    Selectedpoints |> DynObj.setValueOpt trace "Selectedpoints"
                    Selected       |> DynObj.setValueOpt trace "Selected"
                    UnSelected     |> DynObj.setValueOpt trace "UnSelected"
            
                    trace
                )


        // Applies the styles of TextLabel to TraceObjects
        static member TextLabel
            (    
                ?Text   : seq<string>,
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
                ?Color: string,
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

        // Sets Stackgroup() to TraceObjects
        static member SetStackGroup
            (
                stackgroup: string
            ) =  
               (fun (trace:('T :> Trace)) ->

                    trace.SetValue("stackgroup", stackgroup)
                    trace
                )

        //#############################################################################################################################################
        //# Chart trace style abstractions
        //#############################################################################################################################################
        
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        //Simple

        /// Applies the styles of scatter plot to TraceObjects 
        ///
        /// Parameters:
        ///
        /// X           : Sets the x coordinates of the plotted data.
        ///
        /// Y           : Sets the y coordinates of the plotted data.
        ///
        /// Mode        : Determines the drawing mode for this scatter trace.
        ///
        /// Fill        : Sets the area to fill with a solid color
        ///
        /// Fillcolor   :
        ///
        /// Connectgaps : Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.
        ///
        /// StackGroup  : Set several scatter traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order
        ///
        /// Orientation : Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.
        ///
        /// GroupNorm   : Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used
        ///
        /// R           : [Legacy] used for polar charts. Will be removed when adding the new polar charts.
        ///
        /// T           : [Legacy] used for polar charts. Will be removed when adding the new polar charts.
        ///
        /// Error_y     : Sets vertical error bars for this this scatter trace.
        ///
        /// Error_x     : Sets horizontal error bars for this this scatter trace.
        static member Scatter
            (   
                ?X          : seq<#IConvertible>,
                ?Y          : seq<#IConvertible>,
                ?Mode       : StyleParam.Mode,         
                ?Fill       : StyleParam.Fill,
                ?Fillcolor  : string,                        
                ?Connectgaps: bool, 
                ?StackGroup : string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm  : StyleParam.GroupNorm, 
                ?R          : seq<#IConvertible>,
                ?T          : seq<#IConvertible>,
                ?Error_y    : Error,
                ?Error_x    : Error
            ) =
                (fun (trace:('T :> Trace)) ->    
                
                    X           |> DynObj.setValueOpt   trace "x"
                    Y           |> DynObj.setValueOpt   trace "y"
                    Mode        |> DynObj.setValueOptBy trace "mode"        StyleParam.Mode.toString
                    Connectgaps |> DynObj.setValueOpt   trace "connectgaps"
                    StackGroup  |> DynObj.setValueOpt   trace "stackgroup"
                    Orientation |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
                    GroupNorm   |> DynObj.setValueOptBy trace "groupnorm"   StyleParam.GroupNorm.convert
                    Fill        |> DynObj.setValueOptBy trace "fill"        StyleParam.Fill.toString
                    Fillcolor   |> DynObj.setValueOpt   trace "fillcolor"                    
                    R           |> DynObj.setValueOpt   trace "r"
                    T           |> DynObj.setValueOpt   trace "t"
                    Error_x     |> DynObj.setValueOpt   trace "error_x"
                    Error_y     |> DynObj.setValueOpt   trace "error_y"

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
                ?Marker:Marker,
                ?Line:Line,
                ?Alignmentgroup,
                ?Offsetgroup,
                ?Notched:bool,
                ?NotchWidth:float,
                ?QuartileMethod:StyleParam.QuartileMethod,
                ?xAxis,       
                ?yAxis,       
                ?Ysrc,        
                ?Xsrc        

            ) =
                (fun (boxPlot:('T :> Trace)) ->

                    Y              |> DynObj.setValueOpt boxPlot "y"           
                    X              |> DynObj.setValueOpt boxPlot "x"           
                    X0             |> DynObj.setValueOpt boxPlot "x0"          
                    Y0             |> DynObj.setValueOpt boxPlot "y0"          
                    Whiskerwidth   |> DynObj.setValueOpt boxPlot "whiskerwidth"
                    Boxpoints      |> DynObj.setValueOptBy boxPlot "boxpoints"  StyleParam.Boxpoints.convert  
                    Boxmean        |> DynObj.setValueOptBy boxPlot "boxmean"    StyleParam.BoxMean.convert    
                    Jitter         |> DynObj.setValueOpt boxPlot "jitter"      
                    Pointpos       |> DynObj.setValueOpt boxPlot "pointpos"    
                    Orientation    |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
                    Fillcolor      |> DynObj.setValueOpt boxPlot "fillcolor"   
                    Marker         |> DynObj.setValueOpt boxPlot "marker"   
                    Line           |> DynObj.setValueOpt boxPlot "line"   
                    Alignmentgroup   |> DynObj.setValueOpt boxPlot "alignmentgroup"   
                    Offsetgroup      |> DynObj.setValueOpt boxPlot "offsetgroup"                     
                    Notched        |> DynObj.setValueOpt boxPlot "notched"   
                    NotchWidth     |> DynObj.setValueOpt boxPlot "notchwidth"   
                    QuartileMethod |> DynObj.setValueOptBy boxPlot "quartilemethod" StyleParam.QuartileMethod.convert

                    xAxis          |> DynObj.setValueOpt boxPlot "xaxis"       
                    yAxis          |> DynObj.setValueOpt boxPlot "yaxis"       
                    Ysrc           |> DynObj.setValueOpt boxPlot "ysrc"        
                    Xsrc           |> DynObj.setValueOpt boxPlot "xsrc"        
                    
                    // out ->
                    boxPlot
                ) 


        // Applies the styles of violin plot plot to TraceObjects 
        static member Violin
            (            
                ?Y,           
                ?X,           
                ?X0,          
                ?Y0,          
                
                ?Width,
                ?Marker:Marker,
                ?Line:Line,
                ?Alignmentgroup,
                ?Offsetgroup,

                ?Box:Box,
                ?Bandwidth,
                ?Meanline:Meanline,
                ?Scalegroup,
                ?Scalemode,
                ?Side,
                ?Span,
                ?SpanMode,
                ?Uirevision,


                ?Points,     
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

                    Y                |> DynObj.setValueOpt boxPlot "y"           
                    X                |> DynObj.setValueOpt boxPlot "x"           
                    X0               |> DynObj.setValueOpt boxPlot "x0"          
                    Y0               |> DynObj.setValueOpt boxPlot "y0"          
                    Points           |> DynObj.setValueOptBy boxPlot "points"  StyleParam.Jitterpoints.convert      
                    Jitter           |> DynObj.setValueOpt boxPlot "jitter"      
                    Pointpos         |> DynObj.setValueOpt boxPlot "pointpos"    
                    Orientation      |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
                    Fillcolor        |> DynObj.setValueOpt boxPlot "fillcolor"   
                                     
                    Width            |> DynObj.setValueOpt boxPlot "width"  
                    Marker           |> DynObj.setValueOpt boxPlot "marker"   
                    Line             |> DynObj.setValueOpt boxPlot "line" 
                    Alignmentgroup   |> DynObj.setValueOpt boxPlot "alignmentgroup"   
                    Offsetgroup      |> DynObj.setValueOpt boxPlot "offsetgroup"  
                                    
                    Box              |> DynObj.setValueOpt boxPlot "box"  
                    Bandwidth        |> DynObj.setValueOpt boxPlot "bandwidth"  
                    Meanline         |> DynObj.setValueOpt boxPlot "meanline"  
                    Scalegroup       |> DynObj.setValueOpt boxPlot "scalegroup"  
                    Scalemode        |> DynObj.setValueOpt boxPlot "scalemode"  
                    Side             |> DynObj.setValueOpt boxPlot "side"  
                    Span             |> DynObj.setValueOpt boxPlot "span"  
                    SpanMode         |> DynObj.setValueOpt boxPlot "spanmode"  
                    Uirevision       |> DynObj.setValueOpt boxPlot "uirevision"  

                    
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


        static member Histogram
            (            
                ?X : seq<#IConvertible>       ,
                ?Y : seq<#IConvertible>       ,            
                ?Text : seq<string>           ,   
                ?xAxis                        ,
                ?yAxis                        ,
                ?Xsrc                         ,
                ?Ysrc                         ,
                ?Orientation                  , 
                ?HistFunc                     ,
                ?HistNorm                     ,
                ?Cumulative : Cumulative      ,
                
                                              
                ?Autobinx    : bool           ,
                ?nBinsx      : int            ,
                ?xBins       : Bins           ,
                ?Autobiny    : bool           ,
                ?nBinsy      : int            ,
                ?yBins       : Bins           ,
                ?Marker      : Marker         ,

                ?xError       : Error         ,
                ?yError       : Error



            ) =
                (fun (histogram:('T :> Trace)) ->
        
                    X              |> DynObj.setValueOpt histogram "x"               
                    Y              |> DynObj.setValueOpt histogram "y"                          
                    Text           |> DynObj.setValueOpt histogram "text"
                    xAxis          |> DynObj.setValueOpt histogram "xaxis"         
                    yAxis          |> DynObj.setValueOpt histogram "yaxis"                
                    Xsrc           |> DynObj.setValueOpt histogram "xsrc"       
                    Ysrc           |> DynObj.setValueOpt histogram "ysrc"  

                    Orientation    |> DynObj.setValueOptBy histogram "orientation" StyleParam.Orientation.convert
                    HistFunc       |> DynObj.setValueOptBy histogram "histfunc"    StyleParam.HistFunc.convert
                    HistNorm       |> DynObj.setValueOptBy histogram "histnorm"    StyleParam.HistNorm.convert
                    Cumulative     |> DynObj.setValueOpt histogram "cumulative"

                    Autobinx       |> DynObj.setValueOpt histogram "autobinx"
                    nBinsx         |> DynObj.setValueOpt histogram "nbinsx"
                    xBins          |> DynObj.setValueOpt histogram "xbins"
                    Autobiny       |> DynObj.setValueOpt histogram "autobiny"
                    nBinsy         |> DynObj.setValueOpt histogram "nbinsy"
                    yBins          |> DynObj.setValueOpt histogram "ybins"

                    // Update                
                    Marker         |> DynObj.setValueOpt histogram "marker"
                    xError         |> DynObj.setValueOpt histogram "error_x"
                    yError         |> DynObj.setValueOpt histogram "error_y"
                    
                    // out ->
                    histogram
                ) 


        static member Histogram2d
            (            
                ?X : seq<#IConvertible>       ,
                ?Y : seq<#IConvertible>       ,            
                ?Z : seq<#seq<#IConvertible>> ,                
                ?X0                           ,
                ?dX                           ,
                ?Y0                           ,
                ?dY                           ,
                ?xType                        ,
                ?yType                        ,
                ?xAxis                        ,
                ?yAxis                        ,
                ?Zsrc                         ,
                ?Xsrc                         ,
                ?Ysrc                         ,
                                              
                ?Marker      : Marker         , 
                ?Orientation                  , 
                //?Connectgaps : bool           ,
                ?HistFunc                     ,
                ?HistNorm                     ,
                ?Autobinx    : bool           ,
                ?nBinsx      : int            ,
                ?xBins       : Bins           ,
                ?Autobiny    : bool           ,
                ?nBinsy      : int            ,
                ?yBins       : Bins           ,

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

                    Orientation    |> DynObj.setValueOptBy histogram2d "orientation" StyleParam.Orientation.convert
                    //Connectgaps    |> DynObj.setValueOptBy histogram2d "connectgaps" StyleParam.Orientation.convert
                    HistFunc       |> DynObj.setValueOptBy histogram2d "histfunc   " StyleParam.HistFunc.convert
                    HistNorm       |> DynObj.setValueOptBy histogram2d "histnorm   " StyleParam.HistNorm.convert
                    Autobinx       |> DynObj.setValueOpt histogram2d "autobinx"
                    nBinsx         |> DynObj.setValueOpt histogram2d "nbinsx"
                    xBins          |> DynObj.setValueOpt histogram2d "xbins"
                    Autobiny       |> DynObj.setValueOpt histogram2d "autobiny"
                    nBinsy         |> DynObj.setValueOpt histogram2d "nbinsy"
                    yBins          |> DynObj.setValueOpt histogram2d "ybins"
                    
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


        static member Histogram2dContour
            (            
                ?X : seq<#IConvertible>       ,
                ?Y : seq<#IConvertible>       ,            
                ?Z : seq<#seq<#IConvertible>> ,                
                ?X0                           ,
                ?dX                           ,
                ?Y0                           ,
                ?dY                           ,
                ?xType                        ,
                ?yType                        ,
                ?xAxis                        ,
                ?yAxis                        ,
                ?Zsrc                         ,
                ?Xsrc                         ,
                ?Ysrc                         ,
                                              
                ?Marker      : Marker         , 
                ?Orientation                  , 
                //?Connectgaps : bool           ,
                ?HistFunc                     ,
                ?HistNorm                     ,
                ?Autobinx    : bool           ,
                ?nBinsx      : int            ,
                ?xBins       : Bins           ,
                ?Autobiny    : bool           ,
                ?nBinsy      : int            ,
                ?yBins       : Bins           ,

                ?nContours   : int            ,
                ?Contours    : Contour        ,
                ?Line        : Line           ,


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
                (fun (histogram2dContour:('T :> Trace)) ->

                    Z              |> DynObj.setValueOpt histogram2dContour "z"         
                    X              |> DynObj.setValueOpt histogram2dContour "x"               
                    Y              |> DynObj.setValueOpt histogram2dContour "y"
                    X0             |> DynObj.setValueOpt histogram2dContour "x0"             
                    dX             |> DynObj.setValueOpt histogram2dContour "dx"             
                    Y0             |> DynObj.setValueOpt histogram2dContour "y0"            
                    dY             |> DynObj.setValueOpt histogram2dContour "dy"            
                    xType          |> DynObj.setValueOpt histogram2dContour "xtype"         
                    yType          |> DynObj.setValueOpt histogram2dContour "ytype"                          
                    xAxis          |> DynObj.setValueOpt histogram2dContour "xaxis"         
                    yAxis          |> DynObj.setValueOpt histogram2dContour "yaxis"         
                    Zsrc           |> DynObj.setValueOpt histogram2dContour "zsrc"       
                    Xsrc           |> DynObj.setValueOpt histogram2dContour "xsrc"       
                    Ysrc           |> DynObj.setValueOpt histogram2dContour "ysrc"  

                    Orientation    |> DynObj.setValueOptBy histogram2dContour "orientation" StyleParam.Orientation.convert
                    //Connectgaps    |> DynObj.setValueOptBy histogram2dContour< "connectgaps" StyleParam.Orientation.convert
                    HistFunc       |> DynObj.setValueOptBy histogram2dContour "histfunc   " StyleParam.HistFunc.convert
                    HistNorm       |> DynObj.setValueOptBy histogram2dContour "histnorm   " StyleParam.HistNorm.convert
                    Autobinx       |> DynObj.setValueOpt histogram2dContour "autobinx"
                    nBinsx         |> DynObj.setValueOpt histogram2dContour "nbinsx"
                    xBins          |> DynObj.setValueOpt histogram2dContour "xbins"
                    Autobiny       |> DynObj.setValueOpt histogram2dContour "autobiny"
                    nBinsy         |> DynObj.setValueOpt histogram2dContour "nbinsy"
                    yBins          |> DynObj.setValueOpt histogram2dContour "ybins"

                    nContours      |> DynObj.setValueOpt histogram2dContour   "ncontours"       
                    Contours       |> DynObj.setValueOpt histogram2dContour   "contours"  
                    Line           |> DynObj.setValueOpt histogram2dContour   "line"                     
                    Xgap           |> DynObj.setValueOpt histogram2dContour   "xgap"       
                    Ygap           |> DynObj.setValueOpt histogram2dContour   "ygap"  
                    Transpose      |> DynObj.setValueOpt histogram2dContour   "transpose" 
                    zAuto          |> DynObj.setValueOpt histogram2dContour   "zauto"     
                    zMin           |> DynObj.setValueOpt histogram2dContour   "zmin"      
                    zMax           |> DynObj.setValueOpt histogram2dContour   "zmax"      
                    Colorscale     |> DynObj.setValueOptBy histogram2dContour "colorscale" StyleParam.Colorscale.convert 
                    Autocolorscale |> DynObj.setValueOpt histogram2dContour   "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt histogram2dContour   "reversescale"  
                    Showscale      |> DynObj.setValueOpt histogram2dContour   "showscale"     
                    zSmooth        |> DynObj.setValueOptBy histogram2dContour "zsmooth" StyleParam.SmoothAlg.convert   
                    Colorbar       |> DynObj.setValueOpt histogram2dContour   "colorbar"    

                    // Update                
                    Marker       |> DynObj.setValueOpt histogram2dContour "marker"  
                    
                    // out ->
                    histogram2dContour
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
                ?Labelfont          ,
                ?Tickfont   :   Font,
                ?Rangefont  :   Font        
            ) =
                (fun (parcats:('T :> Trace)) -> 
        
                    Dimensions         |> DynObj.setValueOpt parcats "dimensions"         
                    Line               |> DynObj.setValueOpt parcats "line"                     
                    Domain             |> DynObj.setValueOpt parcats "domain"     
                    Labelfont          |> DynObj.setValueOpt parcats "labelfont"               
                    Tickfont           |> DynObj.setValueOpt parcats "tickfont"                
                    Rangefont          |> DynObj.setValueOpt parcats "rangefont"              
            
                    // out ->
                    parcats 
                ) 

        // Applies the styles of choropleth map plot to TraceObjects 
        static member ChoroplethMap
            (                
                ?Locations      : seq<string>,
                ?Z              : seq<#IConvertible>,
                ?Text           : seq<#IConvertible>,
                ?Locationmode                   ,
                ?Autocolorscale : bool,
                ?Colorscale,
                ?Colorbar,
                ?Marker         : Marker,
                ?Zmin,
                ?Zmax
     

            ) =
                (fun (choropleth:('T :> Trace)) -> 
                
                    Locations          |> DynObj.setValueOpt   choropleth "locations"         
                    Z                  |> DynObj.setValueOpt   choropleth "z"                     
                    Text               |> DynObj.setValueOpt   choropleth "text"     
                    Locationmode       |> DynObj.setValueOptBy choropleth "locationmode" StyleParam.LocationFormat.convert            
                    Autocolorscale     |> DynObj.setValueOpt   choropleth "autocolorscale"    
                    
                    Colorscale         |> DynObj.setValueOptBy choropleth "colorscale" StyleParam.Colorscale.convert
                    Colorbar           |> DynObj.setValueOpt   choropleth "colorbar"
                    Marker             |> DynObj.setValueOpt   choropleth "marker"  
                    Zmin               |> DynObj.setValueOpt   choropleth "zmin"
                    Zmax               |> DynObj.setValueOpt   choropleth "zmax"  
                    
                    // out ->
                    choropleth 
                ) 


        // Applies the styles of Splom plot to TraceObjects 
        static member Splom
            (   
                ?Dimensions : seq<Dimensions>
            ) =
                (fun (trace:('T :> Trace)) ->
                    Dimensions   |> DynObj.setValueOpt trace "dimensions"
                        
                    // out ->
                    trace
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


        /// Applies the styles of ohlc plot to TraceObjects 
        ///
        /// ``open``    : Sets the open values.
        ///
        /// high        : Sets the high values.
        ///
        /// low         : Sets the low values.
        ///
        /// close       : Sets the close values.
        ///
        /// x           : Sets the x coordinates. If absent, linear coordinate will be generated.
        ///
        /// ?Increasing : Sets the Line style of the Increasing part of the chart
        ///
        /// ?Decreasing : Sets the Line style of the Decreasing part of the chart
        ///
        /// ?Line       : Sets the Line style of both the Decreasing and Increasing part of the chart
        ///
        /// ?Tickwidth  : Sets the width of the open/close tick marks relative to the "x" minimal interval.
        ///
        /// ?XCalendar  : Sets the calendar system to use with `x` date data.
        static member OHLC
            (
                ``open``        : #IConvertible seq,
                high            : #IConvertible seq,
                low             : #IConvertible seq,
                close           : #IConvertible seq,
                x               : #IConvertible seq,
                ?Increasing     : Line,
                ?Decreasing     : Line,
                ?Line           : Line,
                ?Tickwidth      : float,
                ?XCalendar      : StyleParam.Calendar
            ) =
                (fun (trace:('T :> Trace)) ->
                    DynObj.setValue     trace "open"        ``open``
                    DynObj.setValue     trace "high"        high
                    DynObj.setValue     trace "low"         low
                    DynObj.setValue     trace "close"       close
                    DynObj.setValue     trace "x"           x
                    DynObj.setValue     trace "xaxis"       "x"
                    DynObj.setValue     trace "yaxis"       "y"
                    DynObj.setValueOpt  trace "increasing"  Increasing
                    DynObj.setValueOpt  trace "decreasing"  Decreasing
                    DynObj.setValueOpt  trace "tickwidth"   Tickwidth
                    DynObj.setValueOpt  trace "line"        Line
                    DynObj.setValueOpt  trace "xcalendar"   XCalendar
                    
                    trace
                )


        /// Applies the styles of candlestick plot to TraceObjects 
        ///
        /// ``open``        : Sets the open values.
        ///
        /// high            : Sets the high values.
        ///
        /// low             : Sets the low values.
        ///
        /// close           : Sets the close values.
        ///
        /// x               : Sets the x coordinates. If absent, linear coordinate will be generated.
        ///
        /// ?Increasing     : Sets the Line style of the Increasing part of the chart
        ///
        /// ?Decreasing     : Sets the Line style of the Decreasing part of the chart
        ///
        /// ?Line           : Sets the Line style of both the Decreasing and Increasing part of the chart
        ///
        /// ?WhiskerWidth   : Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).
        ///
        /// ?XCalendar      : Sets the calendar system to use with `x` date data.
        static member Candlestick
            (
                ``open``        : #IConvertible seq,
                high            : #IConvertible seq,
                low             : #IConvertible seq,
                close           : #IConvertible seq,
                x               : #IConvertible seq,
                ?Increasing     : Line,
                ?Decreasing     : Line,
                ?WhiskerWidth   : float,
                ?Line           : Line,
                ?XCalendar      : StyleParam.Calendar
            ) =
                (fun (trace:('T :> Trace)) ->
                    DynObj.setValue     trace "open"        ``open``
                    DynObj.setValue     trace "high"        high
                    DynObj.setValue     trace "low"         low
                    DynObj.setValue     trace "close"       close
                    DynObj.setValue     trace "x"           x
                    DynObj.setValue     trace "xaxis"       "x"
                    DynObj.setValue     trace "yaxis"       "y"
                    DynObj.setValueOpt  trace "increasing"  Increasing
                    DynObj.setValueOpt  trace "decreasing"  Decreasing
                    DynObj.setValueOpt  trace "whiskerwidth"WhiskerWidth
                    DynObj.setValueOpt  trace "line"        Line
                    DynObj.setValueOpt  trace "xcalendar"   XCalendar

                    trace
                )
        
        /// Applies the styles of candlestick plot to TraceObjects 
        ///
        /// Parameters:
        ///
        /// x               : Sets the x coordinates.
        ///
        /// y               : Sets the y coordinates.
        ///
        /// Base            : Sets where the bar base is drawn (in position axis units).
        ///
        /// Width           : Sets the bar width (in position axis units).
        ///
        /// Measure         : An array containing types of values. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.
        ///
        /// Orientation     : Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).
        ///
        /// Connector       : Sets the styling of the connector lines
        ///
        /// AlignmentGroup  : Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.
        ///
        /// OffsetGroup     : Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.
        ///
        /// Offset          : Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.
        static member Waterfall 
            (
                x               : #IConvertible seq,
                y               : #IConvertible seq,
                ?Base           : IConvertible,
                ?Width          : float,
                ?Measure        : StyleParam.WaterfallMeasure seq,
                ?Orientation    : StyleParam.Orientation,
                ?Connector      : WaterfallConnector,
                ?AlignmentGroup : string,
                ?OffsetGroup    : string,
                ?Offset             

            ) =
                (fun (trace:('T :> Trace)) ->
                    
                    x               |> DynObj.setValue      trace "x"
                    y               |> DynObj.setValue      trace "y"
                    Base            |> DynObj.setValueOpt   trace "base"
                    Width           |> DynObj.setValueOpt   trace "width"
                    Measure         |> DynObj.setValueOptBy trace "measure" (Seq.map StyleParam.WaterfallMeasure.convert)
                    Orientation     |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
                    AlignmentGroup  |> DynObj.setValueOpt   trace "alignmentgroup"
                    Connector       |> DynObj.setValueOpt   trace "connector"
                    OffsetGroup     |> DynObj.setValueOpt   trace "offsetgroup"
                    Offset          |> DynObj.setValueOpt   trace "offset"
                    
                    trace
                )

        static member ScatterGeo 
            (
                mode       : StyleParam.Mode,
                ?Longitudes : #IConvertible seq,
                ?Latitudes  : #IConvertible seq,
                ?Locations  : seq<string>,
                ?GeoJson    ,
                ?Connectgaps : bool,
                ?Fill        : StyleParam.Fill,
                ?Fillcolor   
            ) =
                (fun (trace:('T :> Trace)) -> 
                
                    mode        |> StyleParam.Mode.convert |> DynObj.setValue trace "mode"
                    Longitudes  |> DynObj.setValueOpt   trace "lon"
                    Latitudes   |> DynObj.setValueOpt   trace "lat"
                    Locations   |> DynObj.setValueOpt   trace "locations"
                    GeoJson     |> DynObj.setValueOpt   trace "geojson"
                    Connectgaps |> DynObj.setValueOpt   trace "connectgaps"
                    Fill        |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
                    Fillcolor   |> DynObj.setValueOpt   trace "fillcolor"

                    trace

                )