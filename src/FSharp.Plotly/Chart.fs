namespace FSharp.Plotly

open System
open System.IO

 
open StyleGramar
open ChartArea

open GenericChart
    

type private Helpers() = 
        
    // Applies the styles to GenericTrace()
    static member ApplyTraceStyles
        (plotType: string, ?showlegend: bool, ?legendgroup:string,
            ?opacity: float, ?name: string, ?uid: string,
            ?hoverinfo: string, ?stream: Stream, 
            ?x: seq<#IConvertible>, ?y: seq<#IConvertible>, ?text: seq<#IConvertible> ,
            ?mode: StyleOption.Mode, ?line: Line, ?connectgaps: bool,
            ?fill: StyleOption.Fill,
            ?fillcolor: string,
            ?marker: Marker,
            ?textposition: _,
            ?textfont: Font,
            ?r: _,
            ?t: _,
            ?error_y: Error,
            ?error_x: Error,
            ?orientation : StyleOption.Orientation
        ) =
            (fun (trace:Trace) -> 
                    trace.set_type plotType 
                    showlegend   |> Option.iter trace.set_showlegend
                    legendgroup  |> Option.iter trace.set_legendgroup
                    opacity      |> Option.iter trace.set_opacity
                    name         |> Option.iter trace.set_name
                    uid          |> Option.iter trace.set_uid
                    hoverinfo    |> Option.iter trace.set_hoverinfo
                    stream       |> Option.iter trace.set_stream
                    x            |> Option.iter trace.set_x
                    y            |> Option.iter trace.set_y
                    text         |> Option.iter trace.set_text
                    textposition |> Option.iter trace.set_textposition
                    textfont     |> Option.iter trace.set_textfont

                    mode         |> Option.iter (StyleOption.Mode.toString >> trace.set_mode)
                    line         |> Option.iter trace.set_line
                    connectgaps  |> Option.iter trace.set_connectgaps
                    fill         |> Option.iter (StyleOption.Fill.toString >> trace.set_fill)
                    fillcolor    |> Option.iter trace.set_fillcolor
                    marker       |> Option.iter trace.set_marker
                        
                    r            |> Option.iter trace.set_r
                    t            |> Option.iter trace.set_t
                    error_y      |> Option.iter trace.set_error_y
                    error_x      |> Option.iter trace.set_error_x
                        
                    orientation  |> Option.iter (StyleOption.Orientation.convert >> trace.set_orientation)

                    trace
            )


    // Applies the styles to BoxPlot()
    static member ApplyBoxPlotStyles
        (?whiskerwidth,?boxpoints:StyleOption.Boxpoints,?boxmean:StyleOption.BoxMean,?jitter,?pointpos
        ) =
            (fun (trace:Trace) ->   
            whiskerwidth |> Option.iter trace.set_whiskerwidth
            boxpoints    |> Option.iter (StyleOption.Boxpoints.convert >> trace.set_boxpoints)
            boxmean      |> Option.iter (StyleOption.BoxMean.convert >> trace.set_boxmean)
            jitter       |> Option.iter trace.set_jitter
            pointpos     |> Option.iter trace.set_pointpos 

            trace
            )

    // Applies the styles to HeatMap() 
    static member ApplyHeatMapStyles
        (z:seq<#seq<#IConvertible>>, ?x:seq<#IConvertible>,?y:seq<#IConvertible>, 
         ?colorScale:StyleOption.ColorScale,?showscale,?zsmooth,?colorbar
        ) =
            (fun (trace:Trace) -> 
            trace.set_z z     
            x          |> Option.iter trace.set_x                        
            y          |> Option.iter trace.set_y            
            colorScale |> Option.iter (StyleOption.ColorScale.convert >> trace.set_colorscale)
            showscale  |> Option.iter trace.set_showscale
            zsmooth    |> Option.iter trace.set_zsmooth
            colorbar   |> Option.iter trace.set_colorbar

            trace
            )


    // Applies the styles to Line()
    static member ApplyLineStyles
        (?width,?color,?shape,?dash,?smoothing,?colorScale:StyleOption.ColorScale
        ) =
            (fun (line:('T :> Line)) -> 
            color      |> Option.iter line.set_color
            width      |> Option.iter line.set_width
            shape      |> Option.iter line.set_shape
            smoothing  |> Option.iter line.set_smoothing
            dash       |> Option.iter line.set_dash
            colorScale |> Option.iter (StyleOption.ColorScale.convert >> line.set_colorscale)
            line
            )

    // Applies the styles to Marker()
    static member ApplyMarkerStyles
        (?size:int,?color,?symbol:StyleOption.Symbol,?opacity:float
        ) =
            (fun (marker:('T :> Marker)) -> 
            size    |> Option.iter marker.set_size 
            color   |> Option.iter marker.set_color
            symbol  |> Option.iter marker.set_symbol
            opacity |> Option.iter marker.set_opacity
            marker
            )

    // Applies the styles to Axis()
    //TODO
    static member ApplyAxisStyles
        (?size,?color,?family:StyleOption.FontFamily
        ) =
            (fun (font:('T :> Font)) -> 
            size   |> Option.iter font.set_size
            color  |> Option.iter font.set_color
            family |> Option.iter (StyleOption.FontFamily.toString >> font.set_family)

            font
            )

    // Applies the styles to Error()
    static member ApplyErrorStyles
        (errorType,?symmetric,?array,
            ?arrayminus,?value,?valueminus,
            ?traceref,?tracerefminus,?copy_ystyle,
            ?copy_zstyle,?color,?thickness,
            ?width,?arraysrc,?arrayminussrc
        ) =
            (fun (error:Error) -> 
            error.set_type errorType
            symmetric |> Option.iter error.set_symmetric
            array |> Option.iter error.set_array
            arrayminus |> Option.iter error.set_arrayminus
            value |> Option.iter error.set_value
            valueminus |> Option.iter error.set_valueminus
            traceref |> Option.iter error.set_traceref
            tracerefminus |> Option.iter error.set_tracerefminus
            copy_ystyle |> Option.iter error.set_copy_ystyle
            copy_zstyle |> Option.iter error.set_copy_zstyle
            color |> Option.iter error.set_color
            thickness |> Option.iter error.set_thickness
            width |> Option.iter error.set_width
            arraysrc |> Option.iter error.set_arraysrc
            arrayminussrc |> Option.iter error.set_arrayminussrc
            )

    // Applies the styles to Layout()
    static member ApplyLayoutStyles
        (?font,?title,?titlefont,
            ?autosize,?width,?height,
            ?margin,?paper_bgcolor,?plot_bgcolor,
            ?separators,?hidesources,?smith,
            ?showlegend,?dragmode,?hovermode,
            ?xaxis,?xaxis1,?xaxis2,
            ?yaxis,?yaxis2,?scene,
            ?geo,?legend,?annotations,
            ?shapes,?radialaxis,?angularaxis,
            ?direction,?orientation,?barmode,
            ?bargap
        ) =
            (fun (layout:('T :> Layout)) -> 
            font |> Option.iter layout.set_font
            title |> Option.iter layout.set_title
            titlefont |> Option.iter layout.set_titlefont
            autosize |> Option.iter layout.set_autosize
            width |> Option.iter layout.set_width
            height |> Option.iter layout.set_height
            margin |> Option.iter layout.set_margin
            paper_bgcolor |> Option.iter layout.set_paper_bgcolor
            plot_bgcolor |> Option.iter layout.set_plot_bgcolor
            separators |> Option.iter layout.set_separators
            hidesources |> Option.iter layout.set_hidesources
            smith |> Option.iter layout.set_smith
            showlegend |> Option.iter layout.set_showlegend
            dragmode |> Option.iter layout.set_dragmode
            hovermode |> Option.iter layout.set_hovermode
            xaxis |> Option.iter layout.set_xaxis
            xaxis1 |> Option.iter layout.set_xaxis1
            xaxis2 |> Option.iter layout.set_xaxis2
            yaxis |> Option.iter layout.set_yaxis
            yaxis2 |> Option.iter layout.set_yaxis2
            //scene |> Option.iter layout.set_scene
            geo |> Option.iter layout.set_geo
            legend |> Option.iter layout.set_legend
            annotations |> Option.iter layout.set_annotations
            shapes |> Option.iter layout.set_shapes
            radialaxis |> Option.iter layout.set_radialaxis
            angularaxis |> Option.iter layout.set_angularaxis
            direction |> Option.iter layout.set_direction
            orientation |> Option.iter layout.set_orientation
            barmode |> Option.iter layout.set_barmode
            bargap |> Option.iter layout.set_bargap

            layout
            )











//    type key = IConvertible
//    type value = IConvertible

 
            



/// Provides a set of static methods for creating charts.
type Chart =

    static member Scatter(x, y, mode, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode, ?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)


    static member Point(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=StyleOption.Markers, ?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)

    static member Line(x, y,?Name,?ShowMarkers,?Showlegend,?Color,?Opacity,?Labels) =             
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode', ?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)

    static member Range(x, y, upper, lower, ?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels) =             
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
            
        let tLine = Line(width = 0)
        let tmark = Marker(color = if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")
            

        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode', ?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?text=Labels)
        let lower = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = lower, mode=StyleOption.Lines,line=tLine,
                showlegend=false,?fillcolor=RangeColor,marker=tmark)
        let upper = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = upper, mode=StyleOption.Lines,fill=StyleOption.ToNext_y,line=tLine,
                showlegend=false,?fillcolor=RangeColor,marker=tmark)
        GenericChart.MultiChart ([lower;upper;trace],None)

    static member Area(x, y, ?Name,?ShowMarkers,?Showlegend,?Color,?Opacity,?Labels) = 
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, fill=StyleOption.ToZero_y, mode=mode', ?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)

    static member Bar(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)

    static member StackedBar(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        let layout = Layout (barmode = "stack")
        GenericChart.Chart (trace,Some layout)

    static member Column(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels,orientation = StyleOption.Orientation.Horizontal)
        GenericChart.Chart (trace,None)

    static member StackedColumn(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels,orientation = StyleOption.Orientation.Horizontal)
        let layout = Layout (barmode = "stack")
        GenericChart.Chart (trace,Some layout)

    static member BoxPlot(?x,?y,?Name,?Showlegend, ?Color,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("box", ?x=x, ?y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity)
            |> Helpers.ApplyBoxPlotStyles(?whiskerwidth=Whiskerwidth,?boxpoints=Boxpoints,
                                            ?boxmean=Boxmean,?jitter=Jitter,?pointpos=Pointpos)
        GenericChart.Chart (trace,None)


    static member HeatMap(data,?Rownames, ?Colnames, ?Name,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("heatmap",?name=Name)                
            |> Helpers.ApplyHeatMapStyles(data, ?x=Colnames, ?y=Rownames,
                                            ?colorScale=Colorscale,?showscale=Showscale,?zsmooth=zSmooth,?colorbar=Colorbar)
        GenericChart.Chart (trace,None)




//         static member Point3D(x, y, z, ?Name,?ShowMarkers,?Showlegend,?Color,?Opacity,?Labels) = 
//            let trace = 
//                GenericTrace()
//                |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode="markers", ?name=Name,
//                    ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
//            GenericChart.Chart (trace,None)       
        
        
    static member Combine(gCharts:seq<GenericChart>) =
        GenericChart.combine gCharts
 
 
  
    
//pie  
///

                        
