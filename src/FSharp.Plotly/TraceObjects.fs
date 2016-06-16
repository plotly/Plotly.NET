namespace FSharp.Plotly

[<AutoOpen>]
module TraceObjects =

    type ITrace = //interface end    
        abstract ``type``            : string with get, set
        abstract ShouldSerializetype : unit -> bool

    type ITraceInfo =
        abstract name        : string with get, set
        abstract visible     : obj with get, set
        abstract showlegend  : bool with get, set
        abstract legendgroup : string with get, set
        abstract opacity     : float with get, set
        abstract uid         : string with get, set
        abstract hoverinfo   : string with get, set
        abstract stream      : Stream with get, set

        abstract ShouldSerializename        : unit -> bool
        abstract ShouldSerializevisible     : unit -> bool
        abstract ShouldSerializeshowlegend  : unit -> bool
        abstract ShouldSerializelegendgroup : unit -> bool
        abstract ShouldSerializeopacity     : unit -> bool
        abstract ShouldSerializeuid         : unit -> bool
        abstract ShouldSerializehoverinfo   : unit -> bool
        abstract ShouldSerializestream      : unit -> bool


    type ITextLabel =
        /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
        abstract text : obj with get, set
        /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
        abstract textposition : obj with get, set
        abstract textfont : Font with get, set
        /// Sets the source reference on plot.ly for  text .
        abstract textsrc : string with get, set 
        /// Sets the source reference on plot.ly for  textposition .
        abstract textpositionsrc : string with get, set

        abstract ShouldSerializetext            : unit -> bool
        abstract ShouldSerializetextposition    : unit -> bool
        abstract ShouldSerializetextfont        : unit -> bool
        abstract ShouldSerializetextsrc         : unit -> bool
        abstract ShouldSerializetextpositionsrc : unit -> bool


    type ILine =
        abstract line                : Line with get, set
        abstract ShouldSerializeline : unit -> bool

    type IMarker =
        abstract marker            : Marker  with get, set
        abstract ShouldSerializemarker : unit -> bool



    type IColormap =
        abstract z              : seq<seq<System.IConvertible>> with get, set
        abstract x              : seq<System.IConvertible> with get, set
        abstract y              : seq<System.IConvertible> with get, set
        abstract transpose      : bool with get, set
        abstract zauto          : bool with get, set
        abstract zmin           : float with get, set
        abstract zmax           : float with get, set
        abstract colorscale     : obj with get, set
        abstract autocolorscale : bool with get, set
        abstract reversescale   : bool with get, set
        abstract showscale      : bool with get, set
        abstract zsmooth        : obj with get, set
        abstract colorbar       : Colorbar with get, set
        abstract zsrc           : string with get, set
        abstract xsrc           : string with get, set
        abstract ysrc           : string with get, set

        abstract ShouldSerializez             : unit -> bool
        abstract ShouldSerializex              : unit -> bool
        abstract ShouldSerializey              : unit -> bool
        abstract ShouldSerializetranspose      : unit -> bool
        abstract ShouldSerializezauto          : unit -> bool
        abstract ShouldSerializezmin           : unit -> bool
        abstract ShouldSerializezmax           : unit -> bool
        abstract ShouldSerializecolorscale     : unit -> bool
        abstract ShouldSerializeautocolorscale : unit -> bool
        abstract ShouldSerializereversescale   : unit -> bool
        abstract ShouldSerializeshowscale      : unit -> bool
        abstract ShouldSerializezsmooth        : unit -> bool
        abstract ShouldSerializecolorbar       : unit -> bool
        abstract ShouldSerializezsrc           : unit -> bool
        abstract ShouldSerializexsrc           : unit -> bool
        abstract ShouldSerializeysrc           : unit -> bool



    type Scatter() =

        // ITrace interface
        let mutable _type: string option = Some "scatter"
        // ITraceInfo interface
        let mutable _name: string option = None
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        // ITextLabel interface
        let mutable _text: _ option = None
        let mutable _textposition: _ option = None
        let mutable _textfont: Font option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None
        // ILine interface
        let mutable _line: Line option = None
        // IMarker interface
        let mutable _marker: Marker option = None

        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        
        let mutable _mode: string option = None
        
        let mutable _connectgaps: bool option = None
        let mutable _fill: _ option = None
        let mutable _fillcolor: string option = None
        
        let mutable _r: _ option = None
        let mutable _t: _ option = None
        let mutable _error_y: Error_y option = None
        let mutable _error_x: Error_x option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _rsrc: string option = None
        let mutable _tsrc: string option = None

//        member __.line
//            with get () = Option.get _line
//            and set value = _line <- Some value
//        
//        member __.ShouldSerializeline() = not _line.IsNone
        
        /// Sets the x coordinates.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
        member __.x0
            with get () = Option.get _x0
            and set value = _x0 <- Some value

        /// Sets the x coordinate step. See `x0` for more info.
        member __.dx
            with get () = Option.get _dx
            and set value = _dx <- Some value

        /// Sets the y coordinates.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
        member __.y0
            with get () = Option.get _y0
            and set value = _y0 <- Some value

        /// Sets the y coordinate step. See `y0` for more info.
        member __.dy
            with get () = Option.get _dy
            and set value = _dy <- Some value

        /// Determines the drawing mode for this scatter trace. If the provided `mode` includes *text* then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points, then the default is *lines+markers*. Otherwise, *lines*.
        member __.mode
            with get () = Option.get _mode
            and set value = _mode <- Some value

        /// Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.
        member __.connectgaps
            with get () = Option.get _connectgaps
            and set value = _connectgaps <- Some value

        /// Sets the area to fill with a solid color. Use with `fillcolor`.
        member __.fill
            with get () = Option.get _fill
            and set value = _fill <- Some value

        /// Sets the fill color.
        member __.fillcolor
            with get () = Option.get _fillcolor
            and set value = _fillcolor <- Some value

        /// For polar chart only.Sets the radial coordinates.
        member __.r
            with get () = Option.get _r
            and set value = _r <- Some value

        /// For polar chart only.Sets the angular coordinates.
        member __.t
            with get () = Option.get _t
            and set value = _t <- Some value

        member __.error_y
            with get () = Option.get _error_y
            and set value = _error_y <- Some value

        member __.error_x
            with get () = Option.get _error_x
            and set value = _error_x <- Some value

        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
        member __.xaxis
            with get () = Option.get _xaxis
            and set value = _xaxis <- Some value

        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
        member __.yaxis
            with get () = Option.get _yaxis
            and set value = _yaxis <- Some value

        /// Sets the source reference on plot.ly for  x .
        member __.xsrc
            with get () = Option.get _xsrc
            and set value = _xsrc <- Some value

        /// Sets the source reference on plot.ly for  y .
        member __.ysrc
            with get () = Option.get _ysrc
            and set value = _ysrc <- Some value


        /// Sets the source reference on plot.ly for  r .
        member __.rsrc
            with get () = Option.get _rsrc
            and set value = _rsrc <- Some value

        /// Sets the source reference on plot.ly for  t .
        member __.tsrc
            with get () = Option.get _tsrc
            and set value = _tsrc <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializex0() = not _x0.IsNone
        member __.ShouldSerializedx() = not _dx.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializey0() = not _y0.IsNone
        member __.ShouldSerializedy() = not _dy.IsNone
        member __.ShouldSerializemode() = not _mode.IsNone        
        member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
        member __.ShouldSerializefill() = not _fill.IsNone
        member __.ShouldSerializefillcolor() = not _fillcolor.IsNone        
        member __.ShouldSerializer() = not _r.IsNone
        member __.ShouldSerializet() = not _t.IsNone
        member __.ShouldSerializeerror_y() = not _error_y.IsNone
        member __.ShouldSerializeerror_x() = not _error_x.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializersrc() = not _rsrc.IsNone
        member __.ShouldSerializetsrc() = not _tsrc.IsNone

        // Implictit ITrace
        member __.``type`` = (__ :> ITrace).``type``
        member __.ShouldSerializetype() = (__ :> ITrace).ShouldSerializetype()
        
        // Implictit ITraceInfo
        member __.name = (__ :> ITraceInfo).name
        
        
        //member __.ShouldSerializetype() = (__ :> ITraceInfo).ShouldSerializetype()

        interface ITrace with 
            member __.``type``
                with get () = Option.get _type
                and set value = _type <- Some value

            member __.ShouldSerializetype() = not _type.IsNone

        interface ITraceInfo with
            /// Sets the trace name. The trace name appear as the legend item and on hover.
            member __.name
                with get () = Option.get _name
                and set value = _name <- Some value
            /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
            member __.visible
                with get () = Option.get _visible
                and set value = _visible <- Some value

            /// Determines whether or not an item corresponding to this trace is shown in the legend.
            member __.showlegend
                with get () = Option.get _showlegend
                and set value = _showlegend <- Some value

            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
            member __.legendgroup
                with get () = Option.get _legendgroup
                and set value = _legendgroup <- Some value

            /// Sets the opacity of the trace.
            member __.opacity
                with get () = Option.get _opacity
                and set value = _opacity <- Some value

            member __.uid
                with get () = Option.get _uid
                and set value = _uid <- Some value

            /// Determines which trace information appear on hover.
            member __.hoverinfo
                with get () = Option.get _hoverinfo
                and set value = _hoverinfo <- Some value

            member __.stream
                with get () = Option.get _stream
                and set value = _stream <- Some value

            member __.ShouldSerializename() = not _name.IsNone
            member __.ShouldSerializevisible() = not _visible.IsNone
            member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
            member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
            member __.ShouldSerializeopacity() = not _opacity.IsNone
            member __.ShouldSerializeuid() = not _uid.IsNone
            member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
            member __.ShouldSerializestream() = not _stream.IsNone

        interface ITextLabel with 
            
            /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
            member __.text
                with get () = Option.get _text
                and set value = _text <- Some value

            /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
            member __.textposition
                with get () = Option.get _textposition
                and set value = _textposition <- Some value

            member __.textfont
                with get () = Option.get _textfont
                and set value = _textfont <- Some value

            /// Sets the source reference on plot.ly for  text .
            member __.textsrc
                with get () = Option.get _textsrc
                and set value = _textsrc <- Some value

            /// Sets the source reference on plot.ly for  textposition .
            member __.textpositionsrc
                with get () = Option.get _textpositionsrc
                and set value = _textpositionsrc <- Some value
        
            member __.ShouldSerializetext() = not _text.IsNone
            member __.ShouldSerializetextposition() = not _textposition.IsNone
            member __.ShouldSerializetextfont() = not _textfont.IsNone
            member __.ShouldSerializetextsrc() = not _textsrc.IsNone
            member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
       
        interface ILine with 
            member __.line
                with get () = Option.get _line
                and set value = _line <- Some value

            member __.ShouldSerializeline() = not _line.IsNone

        interface IMarker with 
            member __.marker
                with get () = Option.get _marker
                and set value = _marker <- Some value

            member __.ShouldSerializemarker() = not _marker.IsNone


    type Bar() =

        // ITrace interface
        let mutable _type: string option = Some "bar"
        // ITraceInfo interface
        let mutable _name: string option = None
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        // ITextLabel interface
        let mutable _text: _ option = None
        let mutable _textposition: _ option = None
        let mutable _textfont: Font option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None
        // IMarker interface
        let mutable _marker: Marker option = None
        
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _orientation: _ option = None

        let mutable _r: _ option = None
        let mutable _t: _ option = None
        let mutable _error_y: Error_y option = None
        let mutable _error_x: Error_x option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _rsrc: string option = None
        let mutable _tsrc: string option = None

        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

//        /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
//        member __.visible
//            with get () = Option.get _visible
//            and set value = _visible <- Some value
//
//        /// Determines whether or not an item corresponding to this trace is shown in the legend.
//        member __.showlegend
//            with get () = Option.get _showlegend
//            and set value = _showlegend <- Some value
//
//        /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
//        member __.legendgroup
//            with get () = Option.get _legendgroup
//            and set value = _legendgroup <- Some value
//
//        /// Sets the opacity of the trace.
//        member __.opacity
//            with get () = Option.get _opacity
//            and set value = _opacity <- Some value
//
//    //    /// Sets the trace name. The trace name appear as the legend item and on hover.
//    ////    member __.name
//    ////        with get () = Option.get _name
//    ////        and set value = _name <- Some value
//
//        member __.uid
//            with get () = Option.get _uid
//            and set value = _uid <- Some value
//
//        /// Determines which trace information appear on hover.
//        member __.hoverinfo
//            with get () = Option.get _hoverinfo
//            and set value = _hoverinfo <- Some value
//
//        member __.stream
//            with get () = Option.get _stream
//            and set value = _stream <- Some value

        /// Sets the x coordinates.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
        member __.x0
            with get () = Option.get _x0
            and set value = _x0 <- Some value

        /// Sets the x coordinate step. See `x0` for more info.
        member __.dx
            with get () = Option.get _dx
            and set value = _dx <- Some value

        /// Sets the y coordinates.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
        member __.y0
            with get () = Option.get _y0
            and set value = _y0 <- Some value

        /// Sets the y coordinate step. See `y0` for more info.
        member __.dy
            with get () = Option.get _dy
            and set value = _dy <- Some value

        /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        /// Sets the orientation of the bars. With *v* (*h*), the value of the each bar spans along the vertical (horizontal).
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// For polar chart only.Sets the radial coordinates.
        member __.r
            with get () = Option.get _r
            and set value = _r <- Some value

        /// For polar chart only.Sets the angular coordinates.
        member __.t
            with get () = Option.get _t
            and set value = _t <- Some value

        member __.error_y
            with get () = Option.get _error_y
            and set value = _error_y <- Some value

        member __.error_x
            with get () = Option.get _error_x
            and set value = _error_x <- Some value

        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
        member __.xaxis
            with get () = Option.get _xaxis
            and set value = _xaxis <- Some value

        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
        member __.yaxis
            with get () = Option.get _yaxis
            and set value = _yaxis <- Some value

        /// Sets the source reference on plot.ly for  x .
        member __.xsrc
            with get () = Option.get _xsrc
            and set value = _xsrc <- Some value

        /// Sets the source reference on plot.ly for  y .
        member __.ysrc
            with get () = Option.get _ysrc
            and set value = _ysrc <- Some value

        /// Sets the source reference on plot.ly for  text .
        member __.textsrc
            with get () = Option.get _textsrc
            and set value = _textsrc <- Some value

        /// Sets the source reference on plot.ly for  r .
        member __.rsrc
            with get () = Option.get _rsrc
            and set value = _rsrc <- Some value

        /// Sets the source reference on plot.ly for  t .
        member __.tsrc
            with get () = Option.get _tsrc
            and set value = _tsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
//        member __.ShouldSerializevisible() = not _visible.IsNone
//        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
//        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
//        member __.ShouldSerializeopacity() = not _opacity.IsNone
//    //    member __.ShouldSerializename() = not _name.IsNone
//        member __.ShouldSerializeuid() = not _uid.IsNone
//        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
//        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializex0() = not _x0.IsNone
        member __.ShouldSerializedx() = not _dx.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializey0() = not _y0.IsNone
        member __.ShouldSerializedy() = not _dy.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializer() = not _r.IsNone
        member __.ShouldSerializet() = not _t.IsNone
        member __.ShouldSerializeerror_y() = not _error_y.IsNone
        member __.ShouldSerializeerror_x() = not _error_x.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
        member __.ShouldSerializersrc() = not _rsrc.IsNone
        member __.ShouldSerializetsrc() = not _tsrc.IsNone
        
        
        interface ITrace with 
            member __.``type``
                with get () = Option.get _type
                and set value = _type <- Some value

            member __.ShouldSerializetype() = not _type.IsNone

        interface ITraceInfo with
            /// Sets the trace name. The trace name appear as the legend item and on hover.
            member __.name
                with get () = Option.get _name
                and set value = _name <- Some value
            /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
            member __.visible
                with get () = Option.get _visible
                and set value = _visible <- Some value

            /// Determines whether or not an item corresponding to this trace is shown in the legend.
            member __.showlegend
                with get () = Option.get _showlegend
                and set value = _showlegend <- Some value

            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
            member __.legendgroup
                with get () = Option.get _legendgroup
                and set value = _legendgroup <- Some value

            /// Sets the opacity of the trace.
            member __.opacity
                with get () = Option.get _opacity
                and set value = _opacity <- Some value

            member __.uid
                with get () = Option.get _uid
                and set value = _uid <- Some value

            /// Determines which trace information appear on hover.
            member __.hoverinfo
                with get () = Option.get _hoverinfo
                and set value = _hoverinfo <- Some value

            member __.stream
                with get () = Option.get _stream
                and set value = _stream <- Some value

            member __.ShouldSerializename() = not _name.IsNone
            member __.ShouldSerializevisible() = not _visible.IsNone
            member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
            member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
            member __.ShouldSerializeopacity() = not _opacity.IsNone
            member __.ShouldSerializeuid() = not _uid.IsNone
            member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
            member __.ShouldSerializestream() = not _stream.IsNone

        interface ITextLabel with 
            
            /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
            member __.text
                with get () = Option.get _text
                and set value = _text <- Some value

            /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
            member __.textposition
                with get () = Option.get _textposition
                and set value = _textposition <- Some value

            member __.textfont
                with get () = Option.get _textfont
                and set value = _textfont <- Some value

            /// Sets the source reference on plot.ly for  text .
            member __.textsrc
                with get () = Option.get _textsrc
                and set value = _textsrc <- Some value

            /// Sets the source reference on plot.ly for  textposition .
            member __.textpositionsrc
                with get () = Option.get _textpositionsrc
                and set value = _textpositionsrc <- Some value
        
            member __.ShouldSerializetext() = not _text.IsNone
            member __.ShouldSerializetextposition() = not _textposition.IsNone
            member __.ShouldSerializetextfont() = not _textfont.IsNone
            member __.ShouldSerializetextsrc() = not _textsrc.IsNone
            member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
       
        interface IMarker with 
            member __.marker
                with get () = Option.get _marker
                and set value = _marker <- Some value

            member __.ShouldSerializemarker() = not _marker.IsNone


    type Pie() =

        // ITrace interface
        let mutable _type: string option = Some "pie"
        // ITraceInfo interface
        let mutable _name: string option = None
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        // ITextLabel interface
        let mutable _text: _ option = None
        let mutable _textposition: _ option = None
        let mutable _textfont: Font option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None
        // IMarker interface        
        let mutable _marker: Marker option = None

        let mutable _textinfo: string option = None
        let mutable _labels: _ option = None
        let mutable _label0: float option = None
        let mutable _dlabel: float option = None
        let mutable _values: _ option = None
        let mutable _scalegroup: string option = None
        let mutable _insidetextfont: Font option = None
        let mutable _outsidetextfont: Font option = None
        let mutable _domain: _ option = None
        let mutable _hole: float option = None
        let mutable _sort: bool option = None
        let mutable _direction: _ option = None
        let mutable _rotation: float option = None
        let mutable _pull: float option = None
        let mutable _labelssrc: string option = None
        let mutable _valuessrc: string option = None
        let mutable _pullsrc: string option = None

        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        /// Sets the sector labels.
        member __.labels
            with get () = Option.get _labels
            and set value = _labels <- Some value

        /// Alternate to `labels`. Builds a numeric set of labels. Use with `dlabel` where `label0` is the starting label and `dlabel` the step.
        member __.label0
            with get () = Option.get _label0
            and set value = _label0 <- Some value

        /// Sets the label step. See `label0` for more info.
        member __.dlabel
            with get () = Option.get _dlabel
            and set value = _dlabel <- Some value

        /// Sets the values of the sectors of this pie chart.
        member __.values
            with get () = Option.get _values
            and set value = _values <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// Sets text elements associated with each sector.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        /// If there are multiple pies that should be sized according to their totals, link them by providing a non-empty group id here shared by every trace in the same group.
        member __.scalegroup
            with get () = Option.get _scalegroup
            and set value = _scalegroup <- Some value

        /// Determines which trace information appear on the graph.
        member __.textinfo
            with get () = Option.get _textinfo
            and set value = _textinfo <- Some value

        /// Specifies the location of the `textinfo`.
        member __.textposition
            with get () = Option.get _textposition
            and set value = _textposition <- Some value

        member __.textfont
            with get () = Option.get _textfont
            and set value = _textfont <- Some value

        member __.insidetextfont
            with get () = Option.get _insidetextfont
            and set value = _insidetextfont <- Some value

        member __.outsidetextfont
            with get () = Option.get _outsidetextfont
            and set value = _outsidetextfont <- Some value

        member __.domain
            with get () = Option.get _domain
            and set value = _domain <- Some value

        /// Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.
        member __.hole
            with get () = Option.get _hole
            and set value = _hole <- Some value

        /// Determines whether or not the sectors of reordered from largest to smallest.
        member __.sort
            with get () = Option.get _sort
            and set value = _sort <- Some value

        /// Specifies the direction at which succeeding sectors follow one another.
        member __.direction
            with get () = Option.get _direction
            and set value = _direction <- Some value

        /// Instead of the first slice starting at 12 o'clock, rotate to some other angle.
        member __.rotation
            with get () = Option.get _rotation
            and set value = _rotation <- Some value

        /// Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.
        member __.pull
            with get () = Option.get _pull
            and set value = _pull <- Some value

        /// Sets the source reference on plot.ly for  labels .
        member __.labelssrc
            with get () = Option.get _labelssrc
            and set value = _labelssrc <- Some value

        /// Sets the source reference on plot.ly for  values .
        member __.valuessrc
            with get () = Option.get _valuessrc
            and set value = _valuessrc <- Some value

        /// Sets the source reference on plot.ly for  text .
        member __.textsrc
            with get () = Option.get _textsrc
            and set value = _textsrc <- Some value

        /// Sets the source reference on plot.ly for  textposition .
        member __.textpositionsrc
            with get () = Option.get _textpositionsrc
            and set value = _textpositionsrc <- Some value

        /// Sets the source reference on plot.ly for  pull .
        member __.pullsrc
            with get () = Option.get _pullsrc
            and set value = _pullsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializelabels() = not _labels.IsNone
        member __.ShouldSerializelabel0() = not _label0.IsNone
        member __.ShouldSerializedlabel() = not _dlabel.IsNone
        member __.ShouldSerializevalues() = not _values.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializescalegroup() = not _scalegroup.IsNone
        member __.ShouldSerializetextinfo() = not _textinfo.IsNone
        member __.ShouldSerializetextposition() = not _textposition.IsNone
        member __.ShouldSerializetextfont() = not _textfont.IsNone
        member __.ShouldSerializeinsidetextfont() = not _insidetextfont.IsNone
        member __.ShouldSerializeoutsidetextfont() = not _outsidetextfont.IsNone
        member __.ShouldSerializedomain() = not _domain.IsNone
        member __.ShouldSerializehole() = not _hole.IsNone
        member __.ShouldSerializesort() = not _sort.IsNone
        member __.ShouldSerializedirection() = not _direction.IsNone
        member __.ShouldSerializerotation() = not _rotation.IsNone
        member __.ShouldSerializepull() = not _pull.IsNone
        member __.ShouldSerializelabelssrc() = not _labelssrc.IsNone
        member __.ShouldSerializevaluessrc() = not _valuessrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
        member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
        member __.ShouldSerializepullsrc() = not _pullsrc.IsNone

        interface ITrace with 
            member __.``type``
                with get () = Option.get _type
                and set value = _type <- Some value

            member __.ShouldSerializetype() = not _type.IsNone

        interface ITraceInfo with
            /// Sets the trace name. The trace name appear as the legend item and on hover.
            member __.name
                with get () = Option.get _name
                and set value = _name <- Some value
            /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
            member __.visible
                with get () = Option.get _visible
                and set value = _visible <- Some value

            /// Determines whether or not an item corresponding to this trace is shown in the legend.
            member __.showlegend
                with get () = Option.get _showlegend
                and set value = _showlegend <- Some value

            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
            member __.legendgroup
                with get () = Option.get _legendgroup
                and set value = _legendgroup <- Some value

            /// Sets the opacity of the trace.
            member __.opacity
                with get () = Option.get _opacity
                and set value = _opacity <- Some value

            member __.uid
                with get () = Option.get _uid
                and set value = _uid <- Some value

            /// Determines which trace information appear on hover.
            member __.hoverinfo
                with get () = Option.get _hoverinfo
                and set value = _hoverinfo <- Some value

            member __.stream
                with get () = Option.get _stream
                and set value = _stream <- Some value

            member __.ShouldSerializename() = not _name.IsNone
            member __.ShouldSerializevisible() = not _visible.IsNone
            member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
            member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
            member __.ShouldSerializeopacity() = not _opacity.IsNone
            member __.ShouldSerializeuid() = not _uid.IsNone
            member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
            member __.ShouldSerializestream() = not _stream.IsNone

        interface ITextLabel with 
            
            /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
            member __.text
                with get () = Option.get _text
                and set value = _text <- Some value

            /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
            member __.textposition
                with get () = Option.get _textposition
                and set value = _textposition <- Some value

            member __.textfont
                with get () = Option.get _textfont
                and set value = _textfont <- Some value

            /// Sets the source reference on plot.ly for  text .
            member __.textsrc
                with get () = Option.get _textsrc
                and set value = _textsrc <- Some value

            /// Sets the source reference on plot.ly for  textposition .
            member __.textpositionsrc
                with get () = Option.get _textpositionsrc
                and set value = _textpositionsrc <- Some value
        
            member __.ShouldSerializetext() = not _text.IsNone
            member __.ShouldSerializetextposition() = not _textposition.IsNone
            member __.ShouldSerializetextfont() = not _textfont.IsNone
            member __.ShouldSerializetextsrc() = not _textsrc.IsNone
            member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
       
        interface IMarker with 
            member __.marker
                with get () = Option.get _marker
                and set value = _marker <- Some value

            member __.ShouldSerializemarker() = not _marker.IsNone



    type Box() =

        // ITrace interface
        let mutable _type: string option = Some "box"
        // ITraceInfo interface
        let mutable _name: string option = None
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        // ILine interface
        let mutable _line: Line option = None
        // IMarker interface
        let mutable _marker: Marker option = None

        let mutable _y            : _ option = None
        let mutable _x            : _ option = None
        let mutable _x0           : _ option = None
        let mutable _y0           : _ option = None
        let mutable _whiskerwidth : float option = None
        let mutable _boxpoints    : _ option = None
        let mutable _boxmean      : _ option = None
        let mutable _jitter       : float option = None
        let mutable _pointpos     : float option = None
        let mutable _orientation  : _ option = None
        let mutable _fillcolor    : string option = None
        let mutable _xaxis        : string option = None
        let mutable _yaxis        : string option = None
        let mutable _ysrc         : string option = None
        let mutable _xsrc         : string option = None

        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        /// Sets the y sample data or coordinates. See overview for more info.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Sets the x sample data or coordinates. See overview for more info.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets the x coordinate of the box. See overview for more info.
        member __.x0
            with get () = Option.get _x0
            and set value = _x0 <- Some value

        /// Sets the y coordinate of the box. See overview for more info.
        member __.y0
            with get () = Option.get _y0
            and set value = _y0 <- Some value

        /// Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).
        member __.whiskerwidth
            with get () = Option.get _whiskerwidth
            and set value = _whiskerwidth <- Some value

        /// If *outliers*, only the sample points lying outside the whiskers are shown If *suspectedoutliers*, the outlier points are shown and points either less than 4*Q1-3*Q3 or greater than 4*Q3-3*Q1 are highlighted (see `outliercolor`) If *all*, all sample points are shown If *false*, only the box(es) are shown with no sample points
        member __.boxpoints
            with get () = Option.get _boxpoints
            and set value = _boxpoints <- Some value

        /// If *true*, the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If *sd* the standard deviation is also drawn.
        member __.boxmean
            with get () = Option.get _boxmean
            and set value = _boxmean <- Some value

        /// Sets the amount of jitter in the sample points drawn. If *0*, the sample points align along the distribution axis. If *1*, the sample points are drawn in a random jitter of width equal to the width of the box(es).
        member __.jitter
            with get () = Option.get _jitter
            and set value = _jitter <- Some value

        /// Sets the position of the sample points in relation to the box(es). If *0*, the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes
        member __.pointpos
            with get () = Option.get _pointpos
            and set value = _pointpos <- Some value

        /// Sets the orientation of the box(es). If *v* (*h*), the distribution is visualized along the vertical (horizontal).
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

        /// Sets the fill color.
        member __.fillcolor
            with get () = Option.get _fillcolor
            and set value = _fillcolor <- Some value

        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
        member __.xaxis
            with get () = Option.get _xaxis
            and set value = _xaxis <- Some value

        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
        member __.yaxis
            with get () = Option.get _yaxis
            and set value = _yaxis <- Some value

        /// Sets the source reference on plot.ly for  y .
        member __.ysrc
            with get () = Option.get _ysrc
            and set value = _ysrc <- Some value

        /// Sets the source reference on plot.ly for  x .
        member __.xsrc
            with get () = Option.get _xsrc
            and set value = _xsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializex0() = not _x0.IsNone
        member __.ShouldSerializey0() = not _y0.IsNone
        member __.ShouldSerializewhiskerwidth() = not _whiskerwidth.IsNone
        member __.ShouldSerializeboxpoints() = not _boxpoints.IsNone
        member __.ShouldSerializeboxmean() = not _boxmean.IsNone
        member __.ShouldSerializejitter() = not _jitter.IsNone
        member __.ShouldSerializepointpos() = not _pointpos.IsNone
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone


        interface ITrace with 
            member __.``type``
                with get () = Option.get _type
                and set value = _type <- Some value

            member __.ShouldSerializetype() = not _type.IsNone

        interface ITraceInfo with
            /// Sets the trace name. The trace name appear as the legend item and on hover.
            member __.name
                with get () = Option.get _name
                and set value = _name <- Some value
            /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
            member __.visible
                with get () = Option.get _visible
                and set value = _visible <- Some value

            /// Determines whether or not an item corresponding to this trace is shown in the legend.
            member __.showlegend
                with get () = Option.get _showlegend
                and set value = _showlegend <- Some value

            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
            member __.legendgroup
                with get () = Option.get _legendgroup
                and set value = _legendgroup <- Some value

            /// Sets the opacity of the trace.
            member __.opacity
                with get () = Option.get _opacity
                and set value = _opacity <- Some value

            member __.uid
                with get () = Option.get _uid
                and set value = _uid <- Some value

            /// Determines which trace information appear on hover.
            member __.hoverinfo
                with get () = Option.get _hoverinfo
                and set value = _hoverinfo <- Some value

            member __.stream
                with get () = Option.get _stream
                and set value = _stream <- Some value

            member __.ShouldSerializename() = not _name.IsNone
            member __.ShouldSerializevisible() = not _visible.IsNone
            member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
            member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
            member __.ShouldSerializeopacity() = not _opacity.IsNone
            member __.ShouldSerializeuid() = not _uid.IsNone
            member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
            member __.ShouldSerializestream() = not _stream.IsNone
       
        interface ILine with 
            member __.line
                with get () = Option.get _line
                and set value = _line <- Some value

            member __.ShouldSerializeline() = not _line.IsNone

        interface IMarker with 
            member __.marker
                with get () = Option.get _marker
                and set value = _marker <- Some value

            member __.ShouldSerializemarker() = not _marker.IsNone




    type Colormap() =
        // ITrace interface
        let mutable _type: string option = Some "Heatmap"
        // ITraceInfo interface
        let mutable _name: string option = None
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        // ITextLabel interface
        let mutable _text: _ option = None
        let mutable _textposition: _ option = None
        let mutable _textfont: Font option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None
        // IColormap interface      
        let mutable _z              : seq<#seq<#System.IConvertible>> option = None
        let mutable _x              : seq<#System.IConvertible> option = None
        let mutable _y              : seq<#System.IConvertible> option = None
        let mutable _transpose      : bool option = None
        let mutable _zauto          : bool option = None
        let mutable _zmin           : float option = None
        let mutable _zmax           : float option = None
        let mutable _colorscale     : _ option = None
        let mutable _autocolorscale : bool option = None
        let mutable _reversescale   : bool option = None
        let mutable _showscale      : bool option = None
        let mutable _zsmooth        : _ option = None
        let mutable _colorbar       : Colorbar option = None
        let mutable _zsrc           : string option = None
        let mutable _xsrc           : string option = None
        let mutable _ysrc           : string option = None


        let mutable _connectgaps    : bool option = None

        let mutable _x0             : _ option = None
        let mutable _dx             : float option = None        
        let mutable _y0             : _ option = None
        let mutable _dy             : float option = None
        let mutable _xtype          : _ option = None
        let mutable _ytype          : _ option = None
        let mutable _xaxis          : string option = None
        let mutable _yaxis          : string option = None

        /// Sets the z data.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        /// Sets the x coordinates.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
        member __.x0
            with get () = Option.get _x0
            and set value = _x0 <- Some value

        /// Sets the x coordinate step. See `x0` for more info.
        member __.dx
            with get () = Option.get _dx
            and set value = _dx <- Some value

        /// Sets the y coordinates.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
        member __.y0
            with get () = Option.get _y0
            and set value = _y0 <- Some value

        /// Sets the y coordinate step. See `y0` for more info.
        member __.dy
            with get () = Option.get _dy
            and set value = _dy <- Some value

        /// Sets the text elements associated with each z value.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        /// Transposes the z data.
        member __.transpose
            with get () = Option.get _transpose
            and set value = _transpose <- Some value

        /// If *array*, the heatmap's x coordinates are given by *x* (the default behavior when `x` is provided). If *scaled*, the heatmap's x coordinates are given by *x0* and *dx* (the default behavior when `x` is not provided).
        member __.xtype
            with get () = Option.get _xtype
            and set value = _xtype <- Some value

        /// If *array*, the heatmap's y coordinates are given by *y* (the default behavior when `y` is provided) If *scaled*, the heatmap's y coordinates are given by *y0* and *dy* (the default behavior when `y` is not provided)
        member __.ytype
            with get () = Option.get _ytype
            and set value = _ytype <- Some value

        /// Determines the whether or not the color domain is computed with respect to the input data.
        member __.zauto
            with get () = Option.get _zauto
            and set value = _zauto <- Some value

        /// Sets the lower bound of color domain.
        member __.zmin
            with get () = Option.get _zmin
            and set value = _zmin <- Some value

        /// Sets the upper bound of color domain.
        member __.zmax
            with get () = Option.get _zmax
            and set value = _zmax <- Some value

        /// Sets the colorscale.
        member __.colorscale
            with get () = Option.get _colorscale
            and set value = _colorscale <- Some value

        /// Determines whether or not the colorscale is picked using the sign of the input z values.
        member __.autocolorscale
            with get () = Option.get _autocolorscale
            and set value = _autocolorscale <- Some value

        /// Reverses the colorscale.
        member __.reversescale
            with get () = Option.get _reversescale
            and set value = _reversescale <- Some value

        /// Determines whether or not a colorbar is displayed for this trace.
        member __.showscale
            with get () = Option.get _showscale
            and set value = _showscale <- Some value

        /// Picks a smoothing algorithm use to smooth `z` data.
        member __.zsmooth
            with get () = Option.get _zsmooth
            and set value = _zsmooth <- Some value

        /// Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in.
        member __.connectgaps
            with get () = Option.get _connectgaps
            and set value = _connectgaps <- Some value

        member __.colorbar
            with get () = Option.get _colorbar
            and set value = _colorbar <- Some value

        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
        member __.xaxis
            with get () = Option.get _xaxis
            and set value = _xaxis <- Some value

        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
        member __.yaxis
            with get () = Option.get _yaxis
            and set value = _yaxis <- Some value

        /// Sets the source reference on plot.ly for  z .
        member __.zsrc
            with get () = Option.get _zsrc
            and set value = _zsrc <- Some value

        /// Sets the source reference on plot.ly for  x .
        member __.xsrc
            with get () = Option.get _xsrc
            and set value = _xsrc <- Some value

        /// Sets the source reference on plot.ly for  y .
        member __.ysrc
            with get () = Option.get _ysrc
            and set value = _ysrc <- Some value

        /// Sets the source reference on plot.ly for  text .
        member __.textsrc
            with get () = Option.get _textsrc
            and set value = _textsrc <- Some value
        
        member __.ShouldSerializez() = not _z.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializex0() = not _x0.IsNone
        member __.ShouldSerializedx() = not _dx.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializey0() = not _y0.IsNone
        member __.ShouldSerializedy() = not _dy.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializetranspose() = not _transpose.IsNone
        member __.ShouldSerializextype() = not _xtype.IsNone
        member __.ShouldSerializeytype() = not _ytype.IsNone
        member __.ShouldSerializezauto() = not _zauto.IsNone
        member __.ShouldSerializezmin() = not _zmin.IsNone
        member __.ShouldSerializezmax() = not _zmax.IsNone
        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
        member __.ShouldSerializereversescale() = not _reversescale.IsNone
        member __.ShouldSerializeshowscale() = not _showscale.IsNone
        member __.ShouldSerializezsmooth() = not _zsmooth.IsNone
        member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone


        interface ITrace with 
            member __.``type``
                with get () = Option.get _type
                and set value = _type <- Some value

            member __.ShouldSerializetype() = not _type.IsNone

        interface ITraceInfo with
            /// Sets the trace name. The trace name appear as the legend item and on hover.
            member __.name
                with get () = Option.get _name
                and set value = _name <- Some value
            /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
            member __.visible
                with get () = Option.get _visible
                and set value = _visible <- Some value

            /// Determines whether or not an item corresponding to this trace is shown in the legend.
            member __.showlegend
                with get () = Option.get _showlegend
                and set value = _showlegend <- Some value

            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
            member __.legendgroup
                with get () = Option.get _legendgroup
                and set value = _legendgroup <- Some value

            /// Sets the opacity of the trace.
            member __.opacity
                with get () = Option.get _opacity
                and set value = _opacity <- Some value

            member __.uid
                with get () = Option.get _uid
                and set value = _uid <- Some value

            /// Determines which trace information appear on hover.
            member __.hoverinfo
                with get () = Option.get _hoverinfo
                and set value = _hoverinfo <- Some value

            member __.stream
                with get () = Option.get _stream
                and set value = _stream <- Some value

            member __.ShouldSerializename() = not _name.IsNone
            member __.ShouldSerializevisible() = not _visible.IsNone
            member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
            member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
            member __.ShouldSerializeopacity() = not _opacity.IsNone
            member __.ShouldSerializeuid() = not _uid.IsNone
            member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
            member __.ShouldSerializestream() = not _stream.IsNone

        interface ITextLabel with 
            
            /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
            member __.text
                with get () = Option.get _text
                and set value = _text <- Some value

            /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
            member __.textposition
                with get () = Option.get _textposition
                and set value = _textposition <- Some value

            member __.textfont
                with get () = Option.get _textfont
                and set value = _textfont <- Some value

            /// Sets the source reference on plot.ly for  text .
            member __.textsrc
                with get () = Option.get _textsrc
                and set value = _textsrc <- Some value

            /// Sets the source reference on plot.ly for  textposition .
            member __.textpositionsrc
                with get () = Option.get _textpositionsrc
                and set value = _textpositionsrc <- Some value
        
            member __.ShouldSerializetext() = not _text.IsNone
            member __.ShouldSerializetextposition() = not _textposition.IsNone
            member __.ShouldSerializetextfont() = not _textfont.IsNone
            member __.ShouldSerializetextsrc() = not _textsrc.IsNone
            member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
       
        interface IColormap with 
            /// Sets the z data.
            member __.z
                with get () = Option.get _z
                and set value = _z <- Some value

            /// Sets the x coordinates.
            member __.x
                with get () = Option.get _x
                and set value = _x <- Some value

            /// Sets the y coordinates.
            member __.y
                with get () = Option.get _y
                and set value = _y <- Some value

            /// Transposes the z data.
            member __.transpose
                with get () = Option.get _transpose
                and set value = _transpose <- Some value

            /// Determines the whether or not the color domain is computed with respect to the input data.
            member __.zauto
                with get () = Option.get _zauto
                and set value = _zauto <- Some value

            /// Sets the lower bound of color domain.
            member __.zmin
                with get () = Option.get _zmin
                and set value = _zmin <- Some value

            /// Sets the upper bound of color domain.
            member __.zmax
                with get () = Option.get _zmax
                and set value = _zmax <- Some value

            /// Sets the colorscale.
            member __.colorscale
                with get () = Option.get _colorscale
                and set value = _colorscale <- Some value

            /// Determines whether or not the colorscale is picked using the sign of the input z values.
            member __.autocolorscale
                with get () = Option.get _autocolorscale
                and set value = _autocolorscale <- Some value

            /// Reverses the colorscale.
            member __.reversescale
                with get () = Option.get _reversescale
                and set value = _reversescale <- Some value

            /// Determines whether or not a colorbar is displayed for this trace.
            member __.showscale
                with get () = Option.get _showscale
                and set value = _showscale <- Some value

            /// Picks a smoothing algorithm use to smooth `z` data.
            member __.zsmooth
                with get () = Option.get _zsmooth
                and set value = _zsmooth <- Some value

            member __.colorbar
                with get () = Option.get _colorbar
                and set value = _colorbar <- Some value

            /// Sets the source reference on plot.ly for  z .
            member __.zsrc
                with get () = Option.get _zsrc
                and set value = _zsrc <- Some value

            /// Sets the source reference on plot.ly for  x .
            member __.xsrc
                with get () = Option.get _xsrc
                and set value = _xsrc <- Some value

            /// Sets the source reference on plot.ly for  y .
            member __.ysrc
                with get () = Option.get _ysrc
                and set value = _ysrc <- Some value


            member __.ShouldSerializez() = not _z.IsNone
            member __.ShouldSerializex() = not _x.IsNone
            member __.ShouldSerializey() = not _y.IsNone
            member __.ShouldSerializetranspose() = not _transpose.IsNone
            member __.ShouldSerializezauto() = not _zauto.IsNone
            member __.ShouldSerializezmin() = not _zmin.IsNone
            member __.ShouldSerializezmax() = not _zmax.IsNone
            member __.ShouldSerializecolorscale() = not _colorscale.IsNone
            member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
            member __.ShouldSerializereversescale() = not _reversescale.IsNone
            member __.ShouldSerializeshowscale() = not _showscale.IsNone
            member __.ShouldSerializezsmooth() = not _zsmooth.IsNone
            member __.ShouldSerializecolorbar() = not _colorbar.IsNone
            member __.ShouldSerializezsrc() = not _zsrc.IsNone
            member __.ShouldSerializexsrc() = not _xsrc.IsNone
            member __.ShouldSerializeysrc() = not _ysrc.IsNone



    type Heatmap() =
        inherit Colormap()
        
        let mutable _type           : string option = Some "heatmap"

        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        member __.ShouldSerializetype() = not _type.IsNone

    type Contour() =
        inherit Colormap()
        
        let mutable _type           : string option = Some "contour"

        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        member __.ShouldSerializetype() = not _type.IsNone


//    type FrequencyDiagram() =
//        //inherit Trace()
//
//        let mutable _name: string option = None
//        let mutable _visible: _ option = None
//        let mutable _showlegend: bool option = None
//        let mutable _legendgroup: string option = None
//        let mutable _opacity: float option = None
//        let mutable _uid: string option = None
//        let mutable _hoverinfo: string option = None
//        let mutable _stream: Stream option = None
//       
//        let mutable _x           : _ option = None
//        let mutable _x0          : _ option = None
//        let mutable _dx          : float option = None
//        let mutable _y           : _ option = None
//        let mutable _y0          : _ option = None
//        let mutable _dy          : float option = None
//        let mutable _text        : string option = None
//        let mutable _orientation : _ option = None
//        let mutable _marker      : Marker option = None 
//        let mutable _z           : _ option = None
//        let mutable _histfunc    : _ option = None
//        let mutable _histnorm    : _ option = None
//        let mutable _autobinx    : bool option = None
//        let mutable _nbinsx      : int option = None
//        let mutable _xbins       : Xbins option = None
//        let mutable _autobiny    : bool option = None
//        let mutable _nbinsy      : int option = None
//        let mutable _ybins       : Ybins option = None
//        let mutable _error_y     : Error_y option = None // Not in histo2d and contour Error
//        let mutable _error_x     : Error_x option = None // Error
//        let mutable _xaxis       : string option = None
//        let mutable _yaxis       : string option = None
//        let mutable _xsrc        : string option = None
//        let mutable _ysrc        : string option = None
//        let mutable _textsrc     : string option = None
//        let mutable _zsrc        : string option = None
//
//        /// Sets the sample data to be binned on the x axis.
//        member __.x
//            with get () = Option.get _x
//            and set value = _x <- Some value
//
//        /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
//        member __.x0
//            with get () = Option.get _x0
//            and set value = _x0 <- Some value
//
//        /// Sets the x coordinate step. See `x0` for more info.
//        member __.dx
//            with get () = Option.get _dx
//            and set value = _dx <- Some value
//
//        /// Sets the sample data to be binned on the y axis.
//        member __.y
//            with get () = Option.get _y
//            and set value = _y <- Some value
//
//        /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
//        member __.y0
//            with get () = Option.get _y0
//            and set value = _y0 <- Some value
//
//        /// Sets the y coordinate step. See `y0` for more info.
//        member __.dy
//            with get () = Option.get _dy
//            and set value = _dy <- Some value
//
//        /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
//        member __.text
//            with get () = Option.get _text
//            and set value = _text <- Some value
//
//        /// Sets the orientation of the bars. With *v* (*h*), the value of the each bar spans along the vertical (horizontal).
//        member __.orientation
//            with get () = Option.get _orientation
//            and set value = _orientation <- Some value
//
//        member __.marker
//            with get () = Option.get _marker
//            and set value = _marker <- Some value
//
//        /// Sets the aggregation data.
//        member __.z
//            with get () = Option.get _z
//            and set value = _z <- Some value
//
//        /// Specifies the binning function used for this histogram trace. If *count*, the histogram values are computed by counting the number of values lying inside each bin. If *sum*, *avg*, *min*, *max*, the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.
//        member __.histfunc
//            with get () = Option.get _histfunc
//            and set value = _histfunc <- Some value
//
//        /// Specifies the type of normalization used for this histogram trace. If **, the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If *percent*, the span of each bar corresponds to the percentage of occurrences with respect to the total number of sample points (here, the sum of all bin area equals 100%). If *density*, the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin area equals the total number of sample points). If *probability density*, the span of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin area equals 1).
//        member __.histnorm
//            with get () = Option.get _histnorm
//            and set value = _histnorm <- Some value
//
//        /// Determines whether or not the x axis bin attributes are picked by an algorithm.
//        member __.autobinx
//            with get () = Option.get _autobinx
//            and set value = _autobinx <- Some value
//
//        /// Sets the number of x axis bins.
//        member __.nbinsx
//            with get () = Option.get _nbinsx
//            and set value = _nbinsx <- Some value
//
//        member __.xbins
//            with get () = Option.get _xbins
//            and set value = _xbins <- Some value
//
//        /// Determines whether or not the y axis bin attributes are picked by an algorithm.
//        member __.autobiny
//            with get () = Option.get _autobiny
//            and set value = _autobiny <- Some value
//
//        /// Sets the number of y axis bins.
//        member __.nbinsy
//            with get () = Option.get _nbinsy
//            and set value = _nbinsy <- Some value
//
//        member __.ybins
//            with get () = Option.get _ybins
//            and set value = _ybins <- Some value
//
//        member __.error_y
//            with get () = Option.get _error_y
//            and set value = _error_y <- Some value
//
//        member __.error_x
//            with get () = Option.get _error_x
//            and set value = _error_x <- Some value
//
//        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
//        member __.xaxis
//            with get () = Option.get _xaxis
//            and set value = _xaxis <- Some value
//
//        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
//        member __.yaxis
//            with get () = Option.get _yaxis
//            and set value = _yaxis <- Some value
//
//        /// Sets the source reference on plot.ly for  x .
//        member __.xsrc
//            with get () = Option.get _xsrc
//            and set value = _xsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  y .
//        member __.ysrc
//            with get () = Option.get _ysrc
//            and set value = _ysrc <- Some value
//
//        /// Sets the source reference on plot.ly for  text .
//        member __.textsrc
//            with get () = Option.get _textsrc
//            and set value = _textsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  z .
//        member __.zsrc
//            with get () = Option.get _zsrc
//            and set value = _zsrc <- Some value
//
//        member __.ShouldSerializex() = not _x.IsNone
//        member __.ShouldSerializex0() = not _x0.IsNone
//        member __.ShouldSerializedx() = not _dx.IsNone
//        member __.ShouldSerializey() = not _y.IsNone
//        member __.ShouldSerializey0() = not _y0.IsNone
//        member __.ShouldSerializedy() = not _dy.IsNone
//        member __.ShouldSerializetext() = not _text.IsNone
//        member __.ShouldSerializeorientation() = not _orientation.IsNone
//        member __.ShouldSerializemarker() = not _marker.IsNone
//        member __.ShouldSerializez() = not _z.IsNone
//        member __.ShouldSerializehistfunc() = not _histfunc.IsNone
//        member __.ShouldSerializehistnorm() = not _histnorm.IsNone
//        member __.ShouldSerializeautobinx() = not _autobinx.IsNone
//        member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
//        member __.ShouldSerializexbins() = not _xbins.IsNone
//        member __.ShouldSerializeautobiny() = not _autobiny.IsNone
//        member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
//        member __.ShouldSerializeybins() = not _ybins.IsNone
//        member __.ShouldSerializeerror_y() = not _error_y.IsNone
//        member __.ShouldSerializeerror_x() = not _error_x.IsNone
//        member __.ShouldSerializexaxis() = not _xaxis.IsNone
//        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
//        member __.ShouldSerializexsrc() = not _xsrc.IsNone
//        member __.ShouldSerializeysrc() = not _ysrc.IsNone
//        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
//        member __.ShouldSerializezsrc() = not _zsrc.IsNone
//
//        interface ITrace with
//            /// Sets the trace name. The trace name appear as the legend item and on hover.
//            member __.name
//                with get () = Option.get _name
//                and set value = _name <- Some value
//            /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
//            member __.visible
//                with get () = Option.get _visible
//                and set value = _visible <- Some value
//
//            /// Determines whether or not an item corresponding to this trace is shown in the legend.
//            member __.showlegend
//                with get () = Option.get _showlegend
//                and set value = _showlegend <- Some value
//
//            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
//            member __.legendgroup
//                with get () = Option.get _legendgroup
//                and set value = _legendgroup <- Some value
//
//            /// Sets the opacity of the trace.
//            member __.opacity
//                with get () = Option.get _opacity
//                and set value = _opacity <- Some value
//
//            member __.uid
//                with get () = Option.get _uid
//                and set value = _uid <- Some value
//
//            /// Determines which trace information appear on hover.
//            member __.hoverinfo
//                with get () = Option.get _hoverinfo
//                and set value = _hoverinfo <- Some value
//
//            member __.stream
//                with get () = Option.get _stream
//                and set value = _stream <- Some value
//
//            member __.ShouldSerializename() = not _name.IsNone
//            member __.ShouldSerializevisible() = not _visible.IsNone
//            member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
//            member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
//            member __.ShouldSerializeopacity() = not _opacity.IsNone
//            member __.ShouldSerializeuid() = not _uid.IsNone
//            member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
//            member __.ShouldSerializestream() = not _stream.IsNone
//
//
//    type Histogram() =
//        inherit FrequencyDiagram()
//        
//        let mutable _type           : string option = Some "histogram"
//
//        member __.``type``
//            with get () = Option.get _type
//            and set value = _type <- Some value
//
//        member __.ShouldSerializetype() = not _type.IsNone


//    type Histogram2d() =
//        inherit Trace()
//
//        let mutable _type: string option = Some "histogram2d"
//        let mutable _z: _ option = None
//        let mutable _x: _ option = None
//        let mutable _x0: _ option = None
//        let mutable _dx: float option = None
//        let mutable _y: _ option = None
//        let mutable _y0: _ option = None
//        let mutable _dy: float option = None
//        let mutable _text: _ option = None
//        let mutable _transpose: bool option = None
//        let mutable _xtype: _ option = None
//        let mutable _ytype: _ option = None
//        let mutable _zauto: bool option = None
//        let mutable _zmin: float option = None
//        let mutable _zmax: float option = None
//        let mutable _colorscale: _ option = None
//        let mutable _autocolorscale: bool option = None
//        let mutable _reversescale: bool option = None
//        let mutable _showscale: bool option = None
//        let mutable _zsmooth: _ option = None
//        let mutable _connectgaps: bool option = None
//        let mutable _colorbar: Colorbar option = None
//        let mutable _marker: Marker option = None
//        let mutable _orientation: _ option = None
//        let mutable _histfunc: _ option = None
//        let mutable _histnorm: _ option = None
//        let mutable _autobinx: bool option = None
//        let mutable _nbinsx: int option = None
//        let mutable _xbins: Xbins option = None
//        let mutable _autobiny: bool option = None
//        let mutable _nbinsy: int option = None
//        let mutable _ybins: Ybins option = None
//        let mutable _xaxis: string option = None
//        let mutable _yaxis: string option = None
//        let mutable _zsrc: string option = None
//        let mutable _xsrc: string option = None
//        let mutable _ysrc: string option = None
//        let mutable _textsrc: string option = None
//
//        member __.``type``
//            with get () = Option.get _type
//            and set value = _type <- Some value
//
//        /// Sets the aggregation data.
//        member __.z
//            with get () = Option.get _z
//            and set value = _z <- Some value
//
//        /// Sets the sample data to be binned on the x axis.
//        member __.x
//            with get () = Option.get _x
//            and set value = _x <- Some value
//
//        /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
//        member __.x0
//            with get () = Option.get _x0
//            and set value = _x0 <- Some value
//
//        /// Sets the x coordinate step. See `x0` for more info.
//        member __.dx
//            with get () = Option.get _dx
//            and set value = _dx <- Some value
//
//        /// Sets the sample data to be binned on the y axis.
//        member __.y
//            with get () = Option.get _y
//            and set value = _y <- Some value
//
//        /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
//        member __.y0
//            with get () = Option.get _y0
//            and set value = _y0 <- Some value
//
//        /// Sets the y coordinate step. See `y0` for more info.
//        member __.dy
//            with get () = Option.get _dy
//            and set value = _dy <- Some value
//
//        /// Sets the text elements associated with each z value.
//        member __.text
//            with get () = Option.get _text
//            and set value = _text <- Some value
//
//        /// Transposes the z data.
//        member __.transpose
//            with get () = Option.get _transpose
//            and set value = _transpose <- Some value
//
//        /// If *array*, the heatmap's x coordinates are given by *x* (the default behavior when `x` is provided). If *scaled*, the heatmap's x coordinates are given by *x0* and *dx* (the default behavior when `x` is not provided).
//        member __.xtype
//            with get () = Option.get _xtype
//            and set value = _xtype <- Some value
//
//        /// If *array*, the heatmap's y coordinates are given by *y* (the default behavior when `y` is provided) If *scaled*, the heatmap's y coordinates are given by *y0* and *dy* (the default behavior when `y` is not provided)
//        member __.ytype
//            with get () = Option.get _ytype
//            and set value = _ytype <- Some value
//
//        /// Determines the whether or not the color domain is computed with respect to the input data.
//        member __.zauto
//            with get () = Option.get _zauto
//            and set value = _zauto <- Some value
//
//        /// Sets the lower bound of color domain.
//        member __.zmin
//            with get () = Option.get _zmin
//            and set value = _zmin <- Some value
//
//        /// Sets the upper bound of color domain.
//        member __.zmax
//            with get () = Option.get _zmax
//            and set value = _zmax <- Some value
//
//        /// Sets the colorscale.
//        member __.colorscale
//            with get () = Option.get _colorscale
//            and set value = _colorscale <- Some value
//
//        /// Determines whether or not the colorscale is picked using the sign of the input z values.
//        member __.autocolorscale
//            with get () = Option.get _autocolorscale
//            and set value = _autocolorscale <- Some value
//
//        /// Reverses the colorscale.
//        member __.reversescale
//            with get () = Option.get _reversescale
//            and set value = _reversescale <- Some value
//
//        /// Determines whether or not a colorbar is displayed for this trace.
//        member __.showscale
//            with get () = Option.get _showscale
//            and set value = _showscale <- Some value
//
//        /// Picks a smoothing algorithm use to smooth `z` data.
//        member __.zsmooth
//            with get () = Option.get _zsmooth
//            and set value = _zsmooth <- Some value
//
//        /// Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in.
//        member __.connectgaps
//            with get () = Option.get _connectgaps
//            and set value = _connectgaps <- Some value
//
//        member __.colorbar
//            with get () = Option.get _colorbar
//            and set value = _colorbar <- Some value
//
//        member __.marker
//            with get () = Option.get _marker
//            and set value = _marker <- Some value
//
//        /// Sets the orientation of the bars. With *v* (*h*), the value of the each bar spans along the vertical (horizontal).
//        member __.orientation
//            with get () = Option.get _orientation
//            and set value = _orientation <- Some value
//
//        /// Specifies the binning function used for this histogram trace. If *count*, the histogram values are computed by counting the number of values lying inside each bin. If *sum*, *avg*, *min*, *max*, the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.
//        member __.histfunc
//            with get () = Option.get _histfunc
//            and set value = _histfunc <- Some value
//
//        /// Specifies the type of normalization used for this histogram trace. If **, the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If *percent*, the span of each bar corresponds to the percentage of occurrences with respect to the total number of sample points (here, the sum of all bin area equals 100%). If *density*, the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin area equals the total number of sample points). If *probability density*, the span of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin area equals 1).
//        member __.histnorm
//            with get () = Option.get _histnorm
//            and set value = _histnorm <- Some value
//
//        /// Determines whether or not the x axis bin attributes are picked by an algorithm.
//        member __.autobinx
//            with get () = Option.get _autobinx
//            and set value = _autobinx <- Some value
//
//        /// Sets the number of x axis bins.
//        member __.nbinsx
//            with get () = Option.get _nbinsx
//            and set value = _nbinsx <- Some value
//
//        member __.xbins
//            with get () = Option.get _xbins
//            and set value = _xbins <- Some value
//
//        /// Determines whether or not the y axis bin attributes are picked by an algorithm.
//        member __.autobiny
//            with get () = Option.get _autobiny
//            and set value = _autobiny <- Some value
//
//        /// Sets the number of y axis bins.
//        member __.nbinsy
//            with get () = Option.get _nbinsy
//            and set value = _nbinsy <- Some value
//
//        member __.ybins
//            with get () = Option.get _ybins
//            and set value = _ybins <- Some value
//
//        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
//        member __.xaxis
//            with get () = Option.get _xaxis
//            and set value = _xaxis <- Some value
//
//        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
//        member __.yaxis
//            with get () = Option.get _yaxis
//            and set value = _yaxis <- Some value
//
//        /// Sets the source reference on plot.ly for  z .
//        member __.zsrc
//            with get () = Option.get _zsrc
//            and set value = _zsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  x .
//        member __.xsrc
//            with get () = Option.get _xsrc
//            and set value = _xsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  y .
//        member __.ysrc
//            with get () = Option.get _ysrc
//            and set value = _ysrc <- Some value
//
//        /// Sets the source reference on plot.ly for  text .
//        member __.textsrc
//            with get () = Option.get _textsrc
//            and set value = _textsrc <- Some value
//
//        member __.ShouldSerializetype() = not _type.IsNone
//        member __.ShouldSerializez() = not _z.IsNone
//        member __.ShouldSerializex() = not _x.IsNone
//        member __.ShouldSerializex0() = not _x0.IsNone
//        member __.ShouldSerializedx() = not _dx.IsNone
//        member __.ShouldSerializey() = not _y.IsNone
//        member __.ShouldSerializey0() = not _y0.IsNone
//        member __.ShouldSerializedy() = not _dy.IsNone
//        member __.ShouldSerializetext() = not _text.IsNone
//        member __.ShouldSerializetranspose() = not _transpose.IsNone
//        member __.ShouldSerializextype() = not _xtype.IsNone
//        member __.ShouldSerializeytype() = not _ytype.IsNone
//        member __.ShouldSerializezauto() = not _zauto.IsNone
//        member __.ShouldSerializezmin() = not _zmin.IsNone
//        member __.ShouldSerializezmax() = not _zmax.IsNone
//        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
//        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
//        member __.ShouldSerializereversescale() = not _reversescale.IsNone
//        member __.ShouldSerializeshowscale() = not _showscale.IsNone
//        member __.ShouldSerializezsmooth() = not _zsmooth.IsNone
//        member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
//        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
//        member __.ShouldSerializemarker() = not _marker.IsNone
//        member __.ShouldSerializeorientation() = not _orientation.IsNone
//        member __.ShouldSerializehistfunc() = not _histfunc.IsNone
//        member __.ShouldSerializehistnorm() = not _histnorm.IsNone
//        member __.ShouldSerializeautobinx() = not _autobinx.IsNone
//        member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
//        member __.ShouldSerializexbins() = not _xbins.IsNone
//        member __.ShouldSerializeautobiny() = not _autobiny.IsNone
//        member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
//        member __.ShouldSerializeybins() = not _ybins.IsNone
//        member __.ShouldSerializexaxis() = not _xaxis.IsNone
//        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
//        member __.ShouldSerializezsrc() = not _zsrc.IsNone
//        member __.ShouldSerializexsrc() = not _xsrc.IsNone
//        member __.ShouldSerializeysrc() = not _ysrc.IsNone
//        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
//
//    type Histogram2dcontour() =
//        inherit Trace()
//
//        let mutable _type: string option = Some "histogram2dcontour"
//        let mutable _z: _ option = None
//        let mutable _x: _ option = None
//        let mutable _x0: _ option = None
//        let mutable _dx: float option = None
//        let mutable _y: _ option = None
//        let mutable _y0: _ option = None
//        let mutable _dy: float option = None
//        let mutable _text: _ option = None
//        let mutable _transpose: bool option = None
//        let mutable _xtype: _ option = None
//        let mutable _ytype: _ option = None
//        let mutable _zauto: bool option = None
//        let mutable _zmin: float option = None
//        let mutable _zmax: float option = None
//        let mutable _colorscale: _ option = None
//        let mutable _autocolorscale: bool option = None
//        let mutable _reversescale: bool option = None
//        let mutable _showscale: bool option = None
//        let mutable _zsmooth: _ option = None
//        let mutable _connectgaps: bool option = None
//        let mutable _colorbar: Colorbar option = None
//        let mutable _marker: Marker option = None
//        let mutable _orientation: _ option = None
//        let mutable _histfunc: _ option = None
//        let mutable _histnorm: _ option = None
//        let mutable _autobinx: bool option = None
//        let mutable _nbinsx: int option = None
//        let mutable _xbins: Xbins option = None
//        let mutable _autobiny: bool option = None
//        let mutable _nbinsy: int option = None
//        let mutable _ybins: Ybins option = None
//        let mutable _autocontour: bool option = None
//        let mutable _ncontours: int option = None
//        let mutable _contours: Contours option = None
//        let mutable _line: Line option = None
//        let mutable _xaxis: string option = None
//        let mutable _yaxis: string option = None
//        let mutable _zsrc: string option = None
//        let mutable _xsrc: string option = None
//        let mutable _ysrc: string option = None
//        let mutable _textsrc: string option = None
//
//        member __.``type``
//            with get () = Option.get _type
//            and set value = _type <- Some value
//
//        /// Sets the aggregation data.
//        member __.z
//            with get () = Option.get _z
//            and set value = _z <- Some value
//
//        /// Sets the sample data to be binned on the x axis.
//        member __.x
//            with get () = Option.get _x
//            and set value = _x <- Some value
//
//        /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
//        member __.x0
//            with get () = Option.get _x0
//            and set value = _x0 <- Some value
//
//        /// Sets the x coordinate step. See `x0` for more info.
//        member __.dx
//            with get () = Option.get _dx
//            and set value = _dx <- Some value
//
//        /// Sets the sample data to be binned on the y axis.
//        member __.y
//            with get () = Option.get _y
//            and set value = _y <- Some value
//
//        /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
//        member __.y0
//            with get () = Option.get _y0
//            and set value = _y0 <- Some value
//
//        /// Sets the y coordinate step. See `y0` for more info.
//        member __.dy
//            with get () = Option.get _dy
//            and set value = _dy <- Some value
//
//        /// Sets the text elements associated with each z value.
//        member __.text
//            with get () = Option.get _text
//            and set value = _text <- Some value
//
//        /// Transposes the z data.
//        member __.transpose
//            with get () = Option.get _transpose
//            and set value = _transpose <- Some value
//
//        /// If *array*, the heatmap's x coordinates are given by *x* (the default behavior when `x` is provided). If *scaled*, the heatmap's x coordinates are given by *x0* and *dx* (the default behavior when `x` is not provided).
//        member __.xtype
//            with get () = Option.get _xtype
//            and set value = _xtype <- Some value
//
//        /// If *array*, the heatmap's y coordinates are given by *y* (the default behavior when `y` is provided) If *scaled*, the heatmap's y coordinates are given by *y0* and *dy* (the default behavior when `y` is not provided)
//        member __.ytype
//            with get () = Option.get _ytype
//            and set value = _ytype <- Some value
//
//        /// Determines the whether or not the color domain is computed with respect to the input data.
//        member __.zauto
//            with get () = Option.get _zauto
//            and set value = _zauto <- Some value
//
//        /// Sets the lower bound of color domain.
//        member __.zmin
//            with get () = Option.get _zmin
//            and set value = _zmin <- Some value
//
//        /// Sets the upper bound of color domain.
//        member __.zmax
//            with get () = Option.get _zmax
//            and set value = _zmax <- Some value
//
//        /// Sets the colorscale.
//        member __.colorscale
//            with get () = Option.get _colorscale
//            and set value = _colorscale <- Some value
//
//        /// Determines whether or not the colorscale is picked using the sign of the input z values.
//        member __.autocolorscale
//            with get () = Option.get _autocolorscale
//            and set value = _autocolorscale <- Some value
//
//        /// Reverses the colorscale.
//        member __.reversescale
//            with get () = Option.get _reversescale
//            and set value = _reversescale <- Some value
//
//        /// Determines whether or not a colorbar is displayed for this trace.
//        member __.showscale
//            with get () = Option.get _showscale
//            and set value = _showscale <- Some value
//
//        /// Picks a smoothing algorithm use to smooth `z` data.
//        member __.zsmooth
//            with get () = Option.get _zsmooth
//            and set value = _zsmooth <- Some value
//
//        /// Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in.
//        member __.connectgaps
//            with get () = Option.get _connectgaps
//            and set value = _connectgaps <- Some value
//
//        member __.colorbar
//            with get () = Option.get _colorbar
//            and set value = _colorbar <- Some value
//
//        member __.marker
//            with get () = Option.get _marker
//            and set value = _marker <- Some value
//
//        /// Sets the orientation of the bars. With *v* (*h*), the value of the each bar spans along the vertical (horizontal).
//        member __.orientation
//            with get () = Option.get _orientation
//            and set value = _orientation <- Some value
//
//        /// Specifies the binning function used for this histogram trace. If *count*, the histogram values are computed by counting the number of values lying inside each bin. If *sum*, *avg*, *min*, *max*, the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.
//        member __.histfunc
//            with get () = Option.get _histfunc
//            and set value = _histfunc <- Some value
//
//        /// Specifies the type of normalization used for this histogram trace. If **, the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If *percent*, the span of each bar corresponds to the percentage of occurrences with respect to the total number of sample points (here, the sum of all bin area equals 100%). If *density*, the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin area equals the total number of sample points). If *probability density*, the span of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin area equals 1).
//        member __.histnorm
//            with get () = Option.get _histnorm
//            and set value = _histnorm <- Some value
//
//        /// Determines whether or not the x axis bin attributes are picked by an algorithm.
//        member __.autobinx
//            with get () = Option.get _autobinx
//            and set value = _autobinx <- Some value
//
//        /// Sets the number of x axis bins.
//        member __.nbinsx
//            with get () = Option.get _nbinsx
//            and set value = _nbinsx <- Some value
//
//        member __.xbins
//            with get () = Option.get _xbins
//            and set value = _xbins <- Some value
//
//        /// Determines whether or not the y axis bin attributes are picked by an algorithm.
//        member __.autobiny
//            with get () = Option.get _autobiny
//            and set value = _autobiny <- Some value
//
//        /// Sets the number of y axis bins.
//        member __.nbinsy
//            with get () = Option.get _nbinsy
//            and set value = _nbinsy <- Some value
//
//        member __.ybins
//            with get () = Option.get _ybins
//            and set value = _ybins <- Some value
//
//        /// Determines whether of not the contour level attributes at picked by an algorithm. If *true*, the number of contour levels can be set in `ncontours`. If *false*, set the contour level attributes in `contours`.
//        member __.autocontour
//            with get () = Option.get _autocontour
//            and set value = _autocontour <- Some value
//
//        /// Sets the number of contour levels.
//        member __.ncontours
//            with get () = Option.get _ncontours
//            and set value = _ncontours <- Some value
//
//        member __.contours
//            with get () = Option.get _contours
//            and set value = _contours <- Some value
//
//        member __.line
//            with get () = Option.get _line
//            and set value = _line <- Some value
//
//        /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
//        member __.xaxis
//            with get () = Option.get _xaxis
//            and set value = _xaxis <- Some value
//
//        /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
//        member __.yaxis
//            with get () = Option.get _yaxis
//            and set value = _yaxis <- Some value
//
//        /// Sets the source reference on plot.ly for  z .
//        member __.zsrc
//            with get () = Option.get _zsrc
//            and set value = _zsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  x .
//        member __.xsrc
//            with get () = Option.get _xsrc
//            and set value = _xsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  y .
//        member __.ysrc
//            with get () = Option.get _ysrc
//            and set value = _ysrc <- Some value
//
//        /// Sets the source reference on plot.ly for  text .
//        member __.textsrc
//            with get () = Option.get _textsrc
//            and set value = _textsrc <- Some value
//
//        member __.ShouldSerializetype() = not _type.IsNone
//        member __.ShouldSerializez() = not _z.IsNone
//        member __.ShouldSerializex() = not _x.IsNone
//        member __.ShouldSerializex0() = not _x0.IsNone
//        member __.ShouldSerializedx() = not _dx.IsNone
//        member __.ShouldSerializey() = not _y.IsNone
//        member __.ShouldSerializey0() = not _y0.IsNone
//        member __.ShouldSerializedy() = not _dy.IsNone
//        member __.ShouldSerializetext() = not _text.IsNone
//        member __.ShouldSerializetranspose() = not _transpose.IsNone
//        member __.ShouldSerializextype() = not _xtype.IsNone
//        member __.ShouldSerializeytype() = not _ytype.IsNone
//        member __.ShouldSerializezauto() = not _zauto.IsNone
//        member __.ShouldSerializezmin() = not _zmin.IsNone
//        member __.ShouldSerializezmax() = not _zmax.IsNone
//        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
//        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
//        member __.ShouldSerializereversescale() = not _reversescale.IsNone
//        member __.ShouldSerializeshowscale() = not _showscale.IsNone
//        member __.ShouldSerializezsmooth() = not _zsmooth.IsNone
//        member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
//        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
//        member __.ShouldSerializemarker() = not _marker.IsNone
//        member __.ShouldSerializeorientation() = not _orientation.IsNone
//        member __.ShouldSerializehistfunc() = not _histfunc.IsNone
//        member __.ShouldSerializehistnorm() = not _histnorm.IsNone
//        member __.ShouldSerializeautobinx() = not _autobinx.IsNone
//        member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
//        member __.ShouldSerializexbins() = not _xbins.IsNone
//        member __.ShouldSerializeautobiny() = not _autobiny.IsNone
//        member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
//        member __.ShouldSerializeybins() = not _ybins.IsNone
//        member __.ShouldSerializeautocontour() = not _autocontour.IsNone
//        member __.ShouldSerializencontours() = not _ncontours.IsNone
//        member __.ShouldSerializecontours() = not _contours.IsNone
//        member __.ShouldSerializeline() = not _line.IsNone
//        member __.ShouldSerializexaxis() = not _xaxis.IsNone
//        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
//        member __.ShouldSerializezsrc() = not _zsrc.IsNone
//        member __.ShouldSerializexsrc() = not _xsrc.IsNone
//        member __.ShouldSerializeysrc() = not _ysrc.IsNone
//        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
//
//    type Area() =
//        inherit Trace()
//
//        let mutable _type: string option = Some "area"
//        let mutable _r: _ option = None
//        let mutable _t: _ option = None
//        let mutable _marker: Marker option = None
//        let mutable _rsrc: string option = None
//        let mutable _tsrc: string option = None
//
//        member __.``type``
//            with get () = Option.get _type
//            and set value = _type <- Some value
//
//        /// For polar chart only.Sets the radial coordinates.
//        member __.r
//            with get () = Option.get _r
//            and set value = _r <- Some value
//
//        /// For polar chart only.Sets the angular coordinates.
//        member __.t
//            with get () = Option.get _t
//            and set value = _t <- Some value
//
//        member __.marker
//            with get () = Option.get _marker
//            and set value = _marker <- Some value
//
//        /// Sets the source reference on plot.ly for  r .
//        member __.rsrc
//            with get () = Option.get _rsrc
//            and set value = _rsrc <- Some value
//
//        /// Sets the source reference on plot.ly for  t .
//        member __.tsrc
//            with get () = Option.get _tsrc
//            and set value = _tsrc <- Some value
//
//        member __.ShouldSerializetype() = not _type.IsNone
//        member __.ShouldSerializer() = not _r.IsNone
//        member __.ShouldSerializet() = not _t.IsNone
//        member __.ShouldSerializemarker() = not _marker.IsNone
//        member __.ShouldSerializersrc() = not _rsrc.IsNone
//        member __.ShouldSerializetsrc() = not _tsrc.IsNone
//
