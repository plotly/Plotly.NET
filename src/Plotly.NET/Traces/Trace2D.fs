namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System

/// The most commonly-used kind of subplot is a two-dimensional Cartesian subplot. Traces compatible with these subplots 
/// support xaxis and yaxis attributes whose values must refer to corresponding objects in the layout portion of the figure. 
/// For example, if xaxis="x", and yaxis="y" (which is the default) then this trace is drawn on the subplot at the intersection 
/// of the axes configured under layout.xaxis and layout.yaxis, but if xaxis="x2" and yaxis="y3" then the trace is drawn at the 
/// intersection of the axes configured under layout.xaxis2 and layout.yaxis3. Note that attributes such as layout.xaxis and 
/// layout.xaxis2 etc do not have to be explicitly defined, in which case default values will be inferred. Multiple traces of 
/// different types can be drawn on the same subplot.
///
/// X- and Y-axes support the type attribute, which enables them to represent continuous values (type="linear", type="log"), 
/// temporal values (type="date") or categorical values (type="category", type="multicategory). Axes can also be overlaid on 
/// top of one another to create dual-axis or multiple-axis charts. 2-d cartesian subplots lend themselves very well to creating 
/// "small multiples" figures, also known as facet or trellis plots.
///
/// The following trace types are compatible with 2d-cartesian subplots via the xaxis and yaxis attributes:
///
/// - scatter-like trace types: scatter and scattergl can be used to draw scatter plots, line plots and curves, time-series plots, 
/// bubble charts, dot plots and filled areas and also support error bars
///
/// - bar, funnel, waterfall: bar-like trace types which can also be used to draw timelines and Gantt charts
///
/// - histogram: an aggregating bar-like trace type
///
/// - box and violin: 1-dimensional distribution-like trace types
///
/// - histogram2d and histogram2dcontour: 2-dimensional distribution-like density trace types
///
/// - image, heatmap and contour: matrix trace types
///
/// - ohlc and candlestick: stock-like trace types
///
/// - splom: multi-dimensional scatter plots which implicitly refer to many 2-d cartesian subplots at once.


type Trace2D(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scatter" applying the given trace styling function
    static member initScatter (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("scatter") |> applyStyle

    ///initializes a trace of type "scattergl" applying the given trace styling function
    static member initScatterGL (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("scattergl") |> applyStyle

    ///initializes a trace of type "bar" applying the given trace styling function
    static member initBar (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("bar") |> applyStyle

    ///initializes a trace of type "funnel" applying the given trace styling function
    static member initFunnel (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("funnel") |> applyStyle

    ///initializes a trace of type "waterfall" applying the given trace styling function
    static member initWaterfall (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("waterfall") |> applyStyle
         
    ///initializes a trace of type "histogram" applying the given trace styling function
    static member initHistogram (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("histogram") |> applyStyle

    ///initializes a trace of type "box" applying the given trace styling function
    static member initBoxPlot (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("box") |> applyStyle

    ///initializes a trace of type "violin" applying the given trace styling function
    static member initViolin (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("violin") |> applyStyle

    ///initializes a trace of type "histogram2d" applying the given trace styling function
    static member initHistogram2d (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("histogram2d") |> applyStyle

    ///initializes a trace of type "histogram2dcontour" applying the given trace styling function
    static member initHistogram2dContour (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("histogram2dcontour") |> applyStyle

    ///initializes a trace of type "image" applying the given trace styling function
    static member initImage (applyStyle: Trace2D -> Trace2D) = 
         Trace2D("image") |> applyStyle
    
    ///initializes a trace of type "heatmap" applying the given trace styling function
    static member initHeatmap (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("heatmap") |> applyStyle

    ///initializes a trace of type "heatmapgl" applying the given trace styling function
    static member initHeatmapGL (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("heatmapgl") |> applyStyle

    ///initializes a trace of type "contour" applying the given trace styling function
    static member initContour (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("contour") |> applyStyle

    ///initializes a trace of type "ohlc" applying the given trace styling function
    static member initOHLC (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("ohlc") |> applyStyle

    ///initializes a trace of type "candlestick" applying the given trace styling function
    static member initCandlestick (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("candlestick") |> applyStyle

    ///initializes a trace of type "SPLOM" applying the given trace styling function
    static member initSplom (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("splom") |> applyStyle


type Trace2DStyle() =
    
    /// <summary>Create a function that applies the styles of a scatter plot to a Trace object</summary>
    /// <param name="X">Sets the x coordinates of the plotted data.</param>
    /// <param name="Y">Sets the y coordinates of the plotted data.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace.</param>
    /// <param name="Fill">Sets the area to fill with a solid color</param>
    /// <param name="Fillcolor">Sets the color applied to the fill area</param>
    /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="StackGroup">Set several scatter traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
    /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
    /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
    /// <param name="Error_y">Sets vertical error bars for this this scatter trace.</param>
    /// <param name="Error_x">Sets horizontal error bars for this this scatter trace.</param>
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
                Error_x     |> DynObj.setValueOpt   trace "error_x"
                Error_y     |> DynObj.setValueOpt   trace "error_y"

                trace
            ) 

    /// <summary>Create a function that applies the styles of a bar plot to a Trace object</summary>
    /// <param name="X">Sets the x coordinates of the plotted data.</param>
    /// <param name="Y">Sets the y coordinates of the plotted data.</param>
    /// <param name="Marker">Sets Marker</param>
    /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
    /// <param name="R">[Legacy] used for polar charts. Will be removed when adding the new polar charts.</param>
    /// <param name="T">[Legacy] used for polar charts. Will be removed when adding the new polar charts.</param>
    /// <param name="Error_y">Sets vertical error bars for this this scatter trace.</param>
    /// <param name="Error_x">Sets horizontal error bars for this this scatter trace.</param>
    static member Bar
        (   
            ?X      : seq<#IConvertible>,
            ?Y      : seq<#IConvertible>,                                 
            ?Marker : Marker,            
            ?R      : seq<#IConvertible>,
            ?T      : seq<#IConvertible>,
            ?Error_y: Error,
            ?Error_x: Error, 
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
    
    static member Funnel
        (
            x               : seq<#IConvertible>,
            y               : seq<#IConvertible>,
            ?x0,
            ?dX             : float,
            ?y0,
            ?dY             : float,
            ?Width          : float,
            ?Offset         : float,
            ?Orientation    : StyleParam.Orientation,
            ?Alignmentgroup : string,
            ?Offsetgroup    : string,
            ?Cliponaxis     : bool,
            ?Connector      : FunnelConnector,
            ?Insidetextfont : Font,
            ?Outsidetextfont: Font
        ) = 
            (fun (trace:('T :> Trace)) -> 
                
                x               |> DynObj.setValue      trace "x"
                y               |> DynObj.setValue      trace "y"
                x0              |> DynObj.setValueOpt   trace "x0"
                dX              |> DynObj.setValueOpt   trace "dx"
                y0              |> DynObj.setValueOpt   trace "y0"
                dY              |> DynObj.setValueOpt   trace "dy"
                Width           |> DynObj.setValueOpt   trace "width"
                Offset          |> DynObj.setValueOpt   trace "offset"
                Orientation     |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
                Alignmentgroup  |> DynObj.setValueOpt   trace "alignmentgroup"
                Offsetgroup     |> DynObj.setValueOpt   trace "offsetgroup"
                Cliponaxis      |> DynObj.setValueOpt   trace "cliponaxis"
                Connector       |> DynObj.setValueOpt   trace "connector"
                Insidetextfont  |> DynObj.setValueOpt   trace "insidetextfont"
                Outsidetextfont |> DynObj.setValueOpt   trace "outsidetextfont"

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
            ?Base           : #IConvertible,
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

                Y               |> DynObj.setValueOpt boxPlot "y"           
                X               |> DynObj.setValueOpt boxPlot "x"           
                X0              |> DynObj.setValueOpt boxPlot "x0"          
                Y0              |> DynObj.setValueOpt boxPlot "y0"          
                Whiskerwidth    |> DynObj.setValueOpt boxPlot "whiskerwidth"
                Boxpoints       |> DynObj.setValueOptBy boxPlot "boxpoints"  StyleParam.Boxpoints.convert  
                Boxmean         |> DynObj.setValueOptBy boxPlot "boxmean"    StyleParam.BoxMean.convert    
                Jitter          |> DynObj.setValueOpt boxPlot "jitter"      
                Pointpos        |> DynObj.setValueOpt boxPlot "pointpos"    
                Orientation     |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
                Fillcolor       |> DynObj.setValueOpt boxPlot "fillcolor"   
                Marker          |> DynObj.setValueOpt boxPlot "marker"   
                Line            |> DynObj.setValueOpt boxPlot "line"   
                Alignmentgroup  |> DynObj.setValueOpt boxPlot "alignmentgroup"   
                Offsetgroup     |> DynObj.setValueOpt boxPlot "offsetgroup"                     
                Notched         |> DynObj.setValueOpt boxPlot "notched"   
                NotchWidth      |> DynObj.setValueOpt boxPlot "notchwidth"   
                QuartileMethod  |> DynObj.setValueOptBy boxPlot "quartilemethod" StyleParam.QuartileMethod.convert

                xAxis           |> DynObj.setValueOpt boxPlot "xaxis"       
                yAxis           |> DynObj.setValueOpt boxPlot "yaxis"       
                Ysrc            |> DynObj.setValueOpt boxPlot "ysrc"        
                Xsrc            |> DynObj.setValueOpt boxPlot "xsrc"        
                    
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
            ?ColorBar      

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
                ColorBar       |> DynObj.setValueOpt histogram2d   "colorbar"    

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
            ?ColorBar      

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
                ColorBar       |> DynObj.setValueOpt histogram2dContour   "colorbar"    

                // Update                
                Marker       |> DynObj.setValueOpt histogram2dContour "marker"  
                    
                // out ->
                histogram2dContour
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
            ?ColorBar
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
                ColorBar       |> DynObj.setValueOpt heatmap "colorbar"    

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
            ?ColorBar
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
                ColorBar       |> DynObj.setValueOpt contour   "colorbar"    

                // out ->
                contour 
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