namespace FSharp.Plotly

open System
open System.IO

 
open StyleGramar
open ChartArea

open GenericChart

   

type private Helpers() = 
        
    // Applies the styles to GenericTrace()
    static member ApplyTraceStyles
        (   plotType: string, 
            // data
            ?x      : seq<#IConvertible>,
            ?y      : seq<#IConvertible>,
            ?z,
            ?values : seq<#IConvertible>,            
            ?labels : seq<#IConvertible>,
            ?text   : seq<#IConvertible>,
            ?textposition: StyleOption.TextPosition,
            ?textfont: Font,
            ?textinfo:StyleOption.TextInfo,
            //?textinfo:StyleOption.TextInfoPosition,

            ?name: string,
            ?visible: StyleOption.Visible,
            ?showlegend: bool,
            ?legendgroup:string,
            ?hoverinfo: string,
            
            ?mode: StyleOption.Mode, 
            ?line: Line,                         
            ?marker: Marker,
            
            ?fill: StyleOption.Fill,
            ?fillcolor: string,
            ?opacity: float,            
            ?colorScale: StyleOption.ColorScale,
            ?showscale,
            ?zsmooth, 
            ?colorbar : Colorbar,

            ?uid: string, ?stream: Stream, ?connectgaps: bool, ?r: _, ?t: _,
            ?error_y: Error,
            ?error_x: Error,
            ?orientation : StyleOption.Orientation,            
            // Boxplot
            ?whiskerwidth,?boxpoints:StyleOption.Boxpoints,?boxmean:StyleOption.BoxMean,?jitter,?pointpos,
            //
            ?hole
        ) =
            (fun (trace:Trace) -> 
                    trace.set_type plotType 
                    visible      |> Option.iter trace.set_visible
                    showlegend   |> Option.iter trace.set_showlegend
                    legendgroup  |> Option.iter trace.set_legendgroup
                    opacity      |> Option.iter trace.set_opacity
                    name         |> Option.iter trace.set_name
                    uid          |> Option.iter trace.set_uid
                    hoverinfo    |> Option.iter trace.set_hoverinfo
                    stream       |> Option.iter trace.set_stream
                    x            |> Option.iter trace.set_x
                    y            |> Option.iter trace.set_y
                    z            |> Option.iter trace.set_z
                    values       |> Option.iter trace.set_values
                    labels       |> Option.iter trace.set_labels


                    text         |> Option.iter trace.set_text
                    textposition |> Option.iter (StyleOption.TextPosition.toString >> trace.set_textposition)
                    textfont     |> Option.iter trace.set_textfont

                    mode         |> Option.iter (StyleOption.Mode.toString >> trace.set_mode)
                    line         |> Option.iter trace.set_line
                    connectgaps  |> Option.iter trace.set_connectgaps
                    fill         |> Option.iter (StyleOption.Fill.toString >> trace.set_fill)
                    fillcolor    |> Option.iter trace.set_fillcolor
                    colorScale   |> Option.iter (StyleOption.ColorScale.convert >> trace.set_colorscale)                    
                    showscale  |> Option.iter trace.set_showscale
                    zsmooth    |> Option.iter trace.set_zsmooth
                    colorbar   |> Option.iter trace.set_colorbar

                    marker       |> Option.iter trace.set_marker
                        
                    r            |> Option.iter trace.set_r
                    t            |> Option.iter trace.set_t
                    error_y      |> Option.iter trace.set_error_y
                    error_x      |> Option.iter trace.set_error_x
                        
                    orientation  |> Option.iter (StyleOption.Orientation.convert >> trace.set_orientation)
                    // Boxplot
                    whiskerwidth |> Option.iter trace.set_whiskerwidth
                    boxpoints    |> Option.iter (StyleOption.Boxpoints.convert >> trace.set_boxpoints)
                    boxmean      |> Option.iter (StyleOption.BoxMean.convert >> trace.set_boxmean)
                    jitter       |> Option.iter trace.set_jitter
                    pointpos     |> Option.iter trace.set_pointpos 
                    // Pie
                    hole         |> Option.iter trace.set_hole
                    
                    trace
            )


    // Applies the styles to Line()
    static member ApplyLineStyles
        (?width,?color,?shape:StyleOption.Shape,?dash,?smoothing,?colorScale:StyleOption.ColorScale
        ) =
            (fun (line:('T :> Line)) -> 
            color      |> Option.iter line.set_color
            width      |> Option.iter line.set_width
            shape      |> Option.iter (StyleOption.Shape.convert >> line.set_shape)
            smoothing  |> Option.iter line.set_smoothing
            dash       |> Option.iter (StyleOption.DrawingStyle.toString >> line.set_dash)
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
            symmetric     |> Option.iter error.set_symmetric
            array         |> Option.iter error.set_array
            arrayminus    |> Option.iter error.set_arrayminus
            value         |> Option.iter error.set_value
            valueminus    |> Option.iter error.set_valueminus
            traceref      |> Option.iter error.set_traceref
            tracerefminus |> Option.iter error.set_tracerefminus
            copy_ystyle   |> Option.iter error.set_copy_ystyle
            copy_zstyle   |> Option.iter error.set_copy_zstyle
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

    // Applies the styles to Margin()
    static member ApplyMarginStyles
        (?left,?right,?top,?bottom,
            ?pad,?autoexpand
        ) =
            (fun (margin:('T :> Margin)) -> 
            left   |> Option.iter margin.set_l
            right  |> Option.iter margin.set_r
            top    |> Option.iter margin.set_t
            bottom |> Option.iter margin.set_b

            pad        |> Option.iter margin.set_pad
            autoexpand |> Option.iter margin.set_autoexpand

            margin
            )

    // Applies the styles to Axis()
    // TODO
    static member ApplyAxisStyles
        (?axisType, 
         ?title,            
         ?titlefont,                             
         ?autorange,        
         ?rangemode,        
         ?range,            
         ?fixedrange,       
         ?tickmode,         
         ?nticks,           
         ?tick0,            
         ?dtick,            
         ?tickvals,         
         ?ticktext,         
         ?ticks,            
         ?mirror,           
         ?ticklen,          
         ?tickwidth,        
         ?tickcolor,        
         ?showticklabels,   
         ?tickfont,         
         ?tickangle,        
         ?tickprefix,       
         ?showtickprefix,   
         ?ticksuffix,       
         ?showticksuffix,   
         ?showexponent,     
         ?exponentformat,   
         ?tickformat,       
         ?hoverformat,      
         ?showline,         
         ?linecolor,        
         ?linewidth,        
         ?showgrid,         
         ?gridcolor,        
         ?gridwidth,        
         ?zeroline,         
         ?zerolinecolor,    
         ?zerolinewidth,    
         ?anchor,           
         ?side,             
         ?overlaying,       
         ?domain,           
         ?position,         
         ?isSubplotObj,    
         ?tickvalssrc,      
         ?ticktextsrc,      
         ?showspikes,       
         ?spikesides,       
         ?spikethickness,   
         ?spikecolor,       
         ?showbackground,   
         ?backgroundcolor,  
         ?showaxeslabels,   
         ?orientation,     
         ?tickorientation, 
         ?endpadding      
        ) =
            (fun (axis:('T :> Axis)) -> 
            axisType        |> Option.iter (StyleOption.AxisType.convert >> axis.set_type)
            title           |> Option.iter axis.set_title           
            titlefont       |> Option.iter axis.set_titlefont       
            autorange       |> Option.iter (StyleOption.AutoRange.convert >> axis.set_autorange)
            rangemode       |> Option.iter (StyleOption.RangeMode.convert >> axis.set_rangemode)
            range           |> Option.iter axis.set_range           
            fixedrange      |> Option.iter axis.set_fixedrange      
            tickmode        |> Option.iter (StyleOption.TickMode.convert >>  axis.set_tickmode)
            nticks          |> Option.iter axis.set_nticks          
            tick0           |> Option.iter axis.set_tick0           
            dtick           |> Option.iter axis.set_dtick           
            tickvals        |> Option.iter axis.set_tickvals        
            ticktext        |> Option.iter axis.set_ticktext        
            ticks           |> Option.iter (StyleOption.TickOptions.convert >> axis.set_ticks)
            mirror          |> Option.iter (StyleOption.Mirror.convert >> axis.set_mirror)
            ticklen         |> Option.iter axis.set_ticklen         
            tickwidth       |> Option.iter axis.set_tickwidth       
            tickcolor       |> Option.iter axis.set_tickcolor       
            showticklabels  |> Option.iter axis.set_showticklabels  
            tickfont        |> Option.iter axis.set_tickfont        
            tickangle       |> Option.iter axis.set_tickangle       
            tickprefix      |> Option.iter axis.set_tickprefix      
            showtickprefix  |> Option.iter (StyleOption.ShowTickOption.convert >> axis.set_showtickprefix)
            ticksuffix      |> Option.iter axis.set_ticksuffix    
            showticksuffix  |> Option.iter (StyleOption.ShowTickOption.convert >> axis.set_showticksuffix)
            showexponent    |> Option.iter (StyleOption.ShowExponent.convert >> axis.set_showexponent)
            exponentformat  |> Option.iter axis.set_exponentformat  
            tickformat      |> Option.iter axis.set_tickformat      
            hoverformat     |> Option.iter axis.set_hoverformat     
            showline        |> Option.iter axis.set_showline        
            linecolor       |> Option.iter axis.set_linecolor       
            linewidth       |> Option.iter axis.set_linewidth       
            showgrid        |> Option.iter axis.set_showgrid        
            gridcolor       |> Option.iter axis.set_gridcolor       
            gridwidth       |> Option.iter axis.set_gridwidth       
            zeroline        |> Option.iter axis.set_zeroline        
            zerolinecolor   |> Option.iter axis.set_zerolinecolor   
            zerolinewidth   |> Option.iter axis.set_zerolinewidth   
            anchor          |> Option.iter axis.set_anchor          
            side            |> Option.iter (StyleOption.Side.convert >> axis.set_side)
            overlaying      |> Option.iter axis.set_overlaying      
            domain          |> Option.iter axis.set_domain          
            position        |> Option.iter axis.set_position        
            isSubplotObj    |> Option.iter axis.set__isSubplotObj    
            tickvalssrc     |> Option.iter axis.set_tickvalssrc     
            ticktextsrc     |> Option.iter axis.set_ticktextsrc     
            showspikes      |> Option.iter axis.set_showspikes      
            spikesides      |> Option.iter axis.set_spikesides      
            spikethickness  |> Option.iter axis.set_spikethickness  
            spikecolor      |> Option.iter axis.set_spikecolor      
            showbackground  |> Option.iter axis.set_showbackground  
            backgroundcolor |> Option.iter axis.set_backgroundcolor 
            showaxeslabels  |> Option.iter axis.set_showaxeslabels  
            orientation     |> Option.iter axis.set_orientation     
            tickorientation |> Option.iter axis.set_tickorientation 
            endpadding      |> Option.iter axis.set_endpadding      

            // Categoricalorder

            axis
            )


    static member ApplyColorbarStyles
        (   ?thicknessmode,  
            ?thickness,      
            ?lenmode,        
            ?len,            
            ?x,              
            ?xanchor,
            ?xpad,           
            ?y,              
            ?yanchor,        
            ?ypad,           
            ?outlinecolor,   
            ?outlinewidth,   
            ?bordercolor,    
            ?borderwidth,    
            ?bgcolor,        
            ?tickmode,       
            ?nticks,         
            ?tick0,          
            ?dtick,          
            ?tickvals,       
            ?ticktext,       
            ?ticks,          
            ?ticklen,        
            ?tickwidth,      
            ?tickcolor,      
            ?showticklabels, 
            ?tickfont,       
            ?tickangle,      
            ?tickformat,     
            ?tickprefix,     
            ?showtickprefix, 
            ?ticksuffix,     
            ?showticksuffix, 
            ?exponentformat, 
            ?showexponent,   
            ?title,          
            ?titlefont,      
            ?titleside,      
            ?tickvalssrc,
            ?ticktextsrc    

        ) =
            (fun (colorbar:('T :> Colorbar)) ->            
            thicknessmode  |> Option.iter colorbar.set_thicknessmode  
            thickness      |> Option.iter colorbar.set_thickness      
            lenmode        |> Option.iter colorbar.set_lenmode        
            len            |> Option.iter colorbar.set_len            
            x              |> Option.iter colorbar.set_x              
            xanchor        |> Option.iter colorbar.set_xanchor        
            xpad           |> Option.iter colorbar.set_xpad           
            y              |> Option.iter colorbar.set_y              
            yanchor        |> Option.iter colorbar.set_yanchor        
            ypad           |> Option.iter colorbar.set_ypad           
            outlinecolor   |> Option.iter colorbar.set_outlinecolor   
            outlinewidth   |> Option.iter colorbar.set_outlinewidth   
            bordercolor    |> Option.iter colorbar.set_bordercolor    
            borderwidth    |> Option.iter colorbar.set_borderwidth    
            bgcolor        |> Option.iter colorbar.set_bgcolor        
            tickmode       |> Option.iter colorbar.set_tickmode       
            nticks         |> Option.iter colorbar.set_nticks         
            tick0          |> Option.iter colorbar.set_tick0          
            dtick          |> Option.iter colorbar.set_dtick          
            tickvals       |> Option.iter colorbar.set_tickvals       
            ticktext       |> Option.iter colorbar.set_ticktext       
            ticks          |> Option.iter colorbar.set_ticks          
            ticklen        |> Option.iter colorbar.set_ticklen        
            tickwidth      |> Option.iter colorbar.set_tickwidth      
            tickcolor      |> Option.iter colorbar.set_tickcolor      
            showticklabels |> Option.iter colorbar.set_showticklabels 
            tickfont       |> Option.iter colorbar.set_tickfont       
            tickangle      |> Option.iter colorbar.set_tickangle      
            tickformat     |> Option.iter colorbar.set_tickformat     
            tickprefix     |> Option.iter colorbar.set_tickprefix     
            showtickprefix |> Option.iter colorbar.set_showtickprefix 
            ticksuffix     |> Option.iter colorbar.set_ticksuffix     
            showticksuffix |> Option.iter colorbar.set_showticksuffix 
            exponentformat |> Option.iter colorbar.set_exponentformat 
            showexponent   |> Option.iter colorbar.set_showexponent   
            title          |> Option.iter colorbar.set_title          
            titlefont      |> Option.iter colorbar.set_titlefont      
            titleside      |> Option.iter colorbar.set_titleside      
            tickvalssrc    |> Option.iter colorbar.set_tickvalssrc    
            ticktextsrc    |> Option.iter colorbar.set_ticktextsrc         

            colorbar
            )




