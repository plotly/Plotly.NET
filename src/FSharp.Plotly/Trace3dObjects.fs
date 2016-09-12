namespace FSharp.Plotly


[<AutoOpen>]
module Trace3dObjects =
    
    type ITrace3d = //interface end    
        inherit ITrace 
//            abstract ``type``            : string with get, set
//            abstract ShouldSerializetype : unit -> bool


    type Scatter3d() =

        // ITrace3d interface
        let mutable _type: string option = Some "scatter3d"
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
        let mutable _y: _ option = None
        let mutable _z: _ option = None
        let mutable _mode: string option = None
        let mutable _surfaceaxis: _ option = None
        let mutable _surfacecolor: string option = None
        let mutable _projection: Projection option = None
        let mutable _error_x: Error option = None
        let mutable _error_y: Error option = None
        let mutable _error_z: Error option = None
        let mutable _scene: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _zsrc: string option = None


        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

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

        /// Sets the trace name. The trace name appear as the legend item and on hover.
        member __.name
            with get () = Option.get _name
            and set value = _name <- Some value

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

        /// Sets the x coordinates.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets the y coordinates.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Sets the z coordinates.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        /// Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        /// Determines the drawing mode for this scatter trace. If the provided `mode` includes *text* then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points, then the default is *lines+markers*. Otherwise, *lines*.
        member __.mode
            with get () = Option.get _mode
            and set value = _mode <- Some value

        /// If *-1*, the scatter points are not fill with a surface If *0*, *1*, *2*, the scatter points are filled with a Delaunay surface about the x, y, z respectively.
        member __.surfaceaxis
            with get () = Option.get _surfaceaxis
            and set value = _surfaceaxis <- Some value

        /// Sets the surface fill color.
        member __.surfacecolor
            with get () = Option.get _surfacecolor
            and set value = _surfacecolor <- Some value

        member __.projection
            with get () = Option.get _projection
            and set value = _projection <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
        member __.textposition
            with get () = Option.get _textposition
            and set value = _textposition <- Some value

        member __.textfont
            with get () = Option.get _textfont
            and set value = _textfont <- Some value

        member __.error_x
            with get () = Option.get _error_x
            and set value = _error_x <- Some value

        member __.error_y
            with get () = Option.get _error_y
            and set value = _error_y <- Some value

        member __.error_z
            with get () = Option.get _error_z
            and set value = _error_z <- Some value

        /// Sets a reference between this trace's 3D coordinate system and a 3D scene. If *scene* (the default value), the (x,y,z) coordinates refer to `layout.scene`. If *scene2*, the (x,y,z) coordinates refer to `layout.scene2`, and so on.
        member __.scene
            with get () = Option.get _scene
            and set value = _scene <- Some value

        /// Sets the source reference on plot.ly for  x .
        member __.xsrc
            with get () = Option.get _xsrc
            and set value = _xsrc <- Some value

        /// Sets the source reference on plot.ly for  y .
        member __.ysrc
            with get () = Option.get _ysrc
            and set value = _ysrc <- Some value

        /// Sets the source reference on plot.ly for  z .
        member __.zsrc
            with get () = Option.get _zsrc
            and set value = _zsrc <- Some value

        /// Sets the source reference on plot.ly for  text .
        member __.textsrc
            with get () = Option.get _textsrc
            and set value = _textsrc <- Some value

        /// Sets the source reference on plot.ly for  textposition .
        member __.textpositionsrc
            with get () = Option.get _textpositionsrc
            and set value = _textpositionsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializemode() = not _mode.IsNone
        member __.ShouldSerializesurfaceaxis() = not _surfaceaxis.IsNone
        member __.ShouldSerializesurfacecolor() = not _surfacecolor.IsNone
        member __.ShouldSerializeprojection() = not _projection.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializetextposition() = not _textposition.IsNone
        member __.ShouldSerializetextfont() = not _textfont.IsNone
        member __.ShouldSerializeerror_x() = not _error_x.IsNone
        member __.ShouldSerializeerror_y() = not _error_y.IsNone
        member __.ShouldSerializeerror_z() = not _error_z.IsNone
        member __.ShouldSerializescene() = not _scene.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
        member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone

        interface ITrace3d with 
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



    type Surface() =

        // ITrace3d interface
        let mutable _type: string option = Some "surface"
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
        // IMapZ interface
        let mutable _z              : _ option = None
        let mutable _x              : _ option = None
        let mutable _y              : _ option = None
        let mutable _x0             : _ option = None
        let mutable _dx             : float option = None        
        let mutable _y0             : _ option = None
        let mutable _dy             : float option = None
        let mutable _xtype          : _ option = None
        let mutable _ytype          : _ option = None
        let mutable _xaxis          : string option = None
        let mutable _yaxis          : string option = None
        let mutable _zsrc           : string option = None
        let mutable _xsrc           : string option = None
        let mutable _ysrc           : string option = None

//        // Maybe IScene
//        let mutable _contours: Contours option = None
//        let mutable _hidesurface: bool option = None
//        let mutable _lighting: Lighting option = None        
//        let mutable _scene: string option = None



        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

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

        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        /// Sets the trace name. The trace name appear as the legend item and on hover.
    //    member __.name
    //        with get () = Option.get _name
    //        and set value = _name <- Some value

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

        /// Sets the z coordinates.
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

        /// Sets the text elements associated with each z value.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

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

        member __.colorbar
            with get () = Option.get _colorbar
            and set value = _colorbar <- Some value

        /// Determines whether or not a colorbar is displayed for this trace.
        member __.showscale
            with get () = Option.get _showscale
            and set value = _showscale <- Some value

//        member __.contours
//            with get () = Option.get _contours
//            and set value = _contours <- Some value
//
//        member __.hidesurface
//            with get () = Option.get _hidesurface
//            and set value = _hidesurface <- Some value
//
//        member __.lighting
//            with get () = Option.get _lighting
//            and set value = _lighting <- Some value
//
//        /// Sets a reference between this trace's 3D coordinate system and a 3D scene. If *scene* (the default value), the (x,y,z) coordinates refer to `layout.scene`. If *scene2*, the (x,y,z) coordinates refer to `layout.scene2`, and so on.
//        member __.scene
//            with get () = Option.get _scene
//            and set value = _scene <- Some value

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

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializezauto() = not _zauto.IsNone
        member __.ShouldSerializezmin() = not _zmin.IsNone
        member __.ShouldSerializezmax() = not _zmax.IsNone
        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
        member __.ShouldSerializereversescale() = not _reversescale.IsNone
        member __.ShouldSerializeshowscale() = not _showscale.IsNone
        member __.ShouldSerializecolorbar() = not _colorbar.IsNone        
//        member __.ShouldSerializecontours() = not _contours.IsNone
//        member __.ShouldSerializehidesurface() = not _hidesurface.IsNone
//        member __.ShouldSerializelighting() = not _lighting.IsNone
//        member __.ShouldSerializescene() = not _scene.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone


        interface ITrace3d with 
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
        
        interface IMapZ with 
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

            /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
            member __.y0
                with get () = Option.get _y0
                and set value = _y0 <- Some value

            /// Sets the y coordinate step. See `y0` for more info.
            member __.dy
                with get () = Option.get _dy
                and set value = _dy <- Some value

            /// If *array*, the heatmap's x coordinates are given by *x* (the default behavior when `x` is provided). If *scaled*, the heatmap's x coordinates are given by *x0* and *dx* (the default behavior when `x` is not provided).
            member __.xtype
                with get () = Option.get _xtype
                and set value = _xtype <- Some value

            /// If *array*, the heatmap's y coordinates are given by *y* (the default behavior when `y` is provided) If *scaled*, the heatmap's y coordinates are given by *y0* and *dy* (the default behavior when `y` is not provided)
            member __.ytype
                with get () = Option.get _ytype
                and set value = _ytype <- Some value

            /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
            member __.xaxis
                with get () = Option.get _xaxis
                and set value = _xaxis <- Some value

            /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
            member __.yaxis
                with get () = Option.get _yaxis
                and set value = _yaxis <- Some value                

            /// Sets the y coordinates.
            member __.y
                with get () = Option.get _y
                and set value = _y <- Some value
 
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
            member __.ShouldSerializex0() = not _x0.IsNone
            member __.ShouldSerializedx() = not _dx.IsNone    
            member __.ShouldSerializey0() = not _y0.IsNone
            member __.ShouldSerializedy() = not _dy.IsNone
            member __.ShouldSerializextype() = not _xtype.IsNone
            member __.ShouldSerializeytype() = not _ytype.IsNone
            member __.ShouldSerializexaxis() = not _xaxis.IsNone 
            member __.ShouldSerializeyaxis() = not _yaxis.IsNone
            member __.ShouldSerializezsrc() = not _zsrc.IsNone
            member __.ShouldSerializexsrc() = not _xsrc.IsNone
            member __.ShouldSerializeysrc() = not _ysrc.IsNone  
                       
        interface IColormap with 

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











// https://plot.ly/javascript/reference/#mesh3d-colorscale



//type Mesh3d() =
//    //inherit Trace()
//
//    let mutable _type: string option = Some "mesh3d"
//    let mutable _visible: _ option = None
//    let mutable _showlegend: bool option = None
//    let mutable _legendgroup: string option = None
//    let mutable _opacity: float option = None
////    let mutable _name: string option = None
//    let mutable _uid: string option = None
//    let mutable _hoverinfo: string option = None
//    let mutable _stream: Stream option = None
//    let mutable _x: _ option = None
//    let mutable _y: _ option = None
//    let mutable _z: _ option = None
//    let mutable _i: _ option = None
//    let mutable _j: _ option = None
//    let mutable _k: _ option = None
//    let mutable _delaunayaxis: _ option = None
//    let mutable _alphahull: float option = None
//    let mutable _intensity: _ option = None
//    let mutable _color: string option = None
//    let mutable _vertexcolor: _ option = None
//    let mutable _facecolor: _ option = None
//    let mutable _flatshading: bool option = None
//    let mutable _contour: Contour option = None
//    let mutable _colorscale: _ option = None
//    let mutable _reversescale: bool option = None
//    let mutable _showscale: bool option = None
//    let mutable _lighting: Lighting option = None
//    let mutable _colorbar: Colorbar option = None
//    let mutable _scene: string option = None
//    let mutable _xsrc: string option = None
//    let mutable _ysrc: string option = None
//    let mutable _zsrc: string option = None
//    let mutable _isrc: string option = None
//    let mutable _jsrc: string option = None
//    let mutable _ksrc: string option = None
//    let mutable _intensitysrc: string option = None
//    let mutable _vertexcolorsrc: string option = None
//    let mutable _facecolorsrc: string option = None
//
//    member __.``type``
//        with get () = Option.get _type
//        and set value = _type <- Some value
//
//    /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
//    member __.visible
//        with get () = Option.get _visible
//        and set value = _visible <- Some value
//
//    /// Determines whether or not an item corresponding to this trace is shown in the legend.
//    member __.showlegend
//        with get () = Option.get _showlegend
//        and set value = _showlegend <- Some value
//
//    /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
//    member __.legendgroup
//        with get () = Option.get _legendgroup
//        and set value = _legendgroup <- Some value
//
//    member __.opacity
//        with get () = Option.get _opacity
//        and set value = _opacity <- Some value
//
//    /// Sets the trace name. The trace name appear as the legend item and on hover.
////    member __.name
////        with get () = Option.get _name
////        and set value = _name <- Some value
//
//    member __.uid
//        with get () = Option.get _uid
//        and set value = _uid <- Some value
//
//    /// Determines which trace information appear on hover.
//    member __.hoverinfo
//        with get () = Option.get _hoverinfo
//        and set value = _hoverinfo <- Some value
//
//    member __.stream
//        with get () = Option.get _stream
//        and set value = _stream <- Some value
//
//    member __.x
//        with get () = Option.get _x
//        and set value = _x <- Some value
//
//    member __.y
//        with get () = Option.get _y
//        and set value = _y <- Some value
//
//    member __.z
//        with get () = Option.get _z
//        and set value = _z <- Some value
//
//    member __.i
//        with get () = Option.get _i
//        and set value = _i <- Some value
//
//    member __.j
//        with get () = Option.get _j
//        and set value = _j <- Some value
//
//    member __.k
//        with get () = Option.get _k
//        and set value = _k <- Some value
//
//    member __.delaunayaxis
//        with get () = Option.get _delaunayaxis
//        and set value = _delaunayaxis <- Some value
//
//    member __.alphahull
//        with get () = Option.get _alphahull
//        and set value = _alphahull <- Some value
//
//    member __.intensity
//        with get () = Option.get _intensity
//        and set value = _intensity <- Some value
//
//    member __.color
//        with get () = Option.get _color
//        and set value = _color <- Some value
//
//    member __.vertexcolor
//        with get () = Option.get _vertexcolor
//        and set value = _vertexcolor <- Some value
//
//    member __.facecolor
//        with get () = Option.get _facecolor
//        and set value = _facecolor <- Some value
//
//    member __.flatshading
//        with get () = Option.get _flatshading
//        and set value = _flatshading <- Some value
//
//    member __.contour
//        with get () = Option.get _contour
//        and set value = _contour <- Some value
//
//    /// Sets the colorscale.
//    member __.colorscale
//        with get () = Option.get _colorscale
//        and set value = _colorscale <- Some value
//
//    /// Reverses the colorscale.
//    member __.reversescale
//        with get () = Option.get _reversescale
//        and set value = _reversescale <- Some value
//
//    /// Determines whether or not a colorbar is displayed for this trace.
//    member __.showscale
//        with get () = Option.get _showscale
//        and set value = _showscale <- Some value
//
//    member __.lighting
//        with get () = Option.get _lighting
//        and set value = _lighting <- Some value
//
//    member __.colorbar
//        with get () = Option.get _colorbar
//        and set value = _colorbar <- Some value
//
//    /// Sets a reference between this trace's 3D coordinate system and a 3D scene. If *scene* (the default value), the (x,y,z) coordinates refer to `layout.scene`. If *scene2*, the (x,y,z) coordinates refer to `layout.scene2`, and so on.
//    member __.scene
//        with get () = Option.get _scene
//        and set value = _scene <- Some value
//
//    /// Sets the source reference on plot.ly for  x .
//    member __.xsrc
//        with get () = Option.get _xsrc
//        and set value = _xsrc <- Some value
//
//    /// Sets the source reference on plot.ly for  y .
//    member __.ysrc
//        with get () = Option.get _ysrc
//        and set value = _ysrc <- Some value
//
//    /// Sets the source reference on plot.ly for  z .
//    member __.zsrc
//        with get () = Option.get _zsrc
//        and set value = _zsrc <- Some value
//
//    /// Sets the source reference on plot.ly for  i .
//    member __.isrc
//        with get () = Option.get _isrc
//        and set value = _isrc <- Some value
//
//    /// Sets the source reference on plot.ly for  j .
//    member __.jsrc
//        with get () = Option.get _jsrc
//        and set value = _jsrc <- Some value
//
//    /// Sets the source reference on plot.ly for  k .
//    member __.ksrc
//        with get () = Option.get _ksrc
//        and set value = _ksrc <- Some value
//
//    /// Sets the source reference on plot.ly for  intensity .
//    member __.intensitysrc
//        with get () = Option.get _intensitysrc
//        and set value = _intensitysrc <- Some value
//
//    /// Sets the source reference on plot.ly for  vertexcolor .
//    member __.vertexcolorsrc
//        with get () = Option.get _vertexcolorsrc
//        and set value = _vertexcolorsrc <- Some value
//
//    /// Sets the source reference on plot.ly for  facecolor .
//    member __.facecolorsrc
//        with get () = Option.get _facecolorsrc
//        and set value = _facecolorsrc <- Some value
//
//    member __.ShouldSerializetype() = not _type.IsNone
//    member __.ShouldSerializevisible() = not _visible.IsNone
//    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
//    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
//    member __.ShouldSerializeopacity() = not _opacity.IsNone
////    member __.ShouldSerializename() = not _name.IsNone
//    member __.ShouldSerializeuid() = not _uid.IsNone
//    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
//    member __.ShouldSerializestream() = not _stream.IsNone
//    member __.ShouldSerializex() = not _x.IsNone
//    member __.ShouldSerializey() = not _y.IsNone
//    member __.ShouldSerializez() = not _z.IsNone
//    member __.ShouldSerializei() = not _i.IsNone
//    member __.ShouldSerializej() = not _j.IsNone
//    member __.ShouldSerializek() = not _k.IsNone
//    member __.ShouldSerializedelaunayaxis() = not _delaunayaxis.IsNone
//    member __.ShouldSerializealphahull() = not _alphahull.IsNone
//    member __.ShouldSerializeintensity() = not _intensity.IsNone
//    member __.ShouldSerializecolor() = not _color.IsNone
//    member __.ShouldSerializevertexcolor() = not _vertexcolor.IsNone
//    member __.ShouldSerializefacecolor() = not _facecolor.IsNone
//    member __.ShouldSerializeflatshading() = not _flatshading.IsNone
//    member __.ShouldSerializecontour() = not _contour.IsNone
//    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
//    member __.ShouldSerializereversescale() = not _reversescale.IsNone
//    member __.ShouldSerializeshowscale() = not _showscale.IsNone
//    member __.ShouldSerializelighting() = not _lighting.IsNone
//    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
//    member __.ShouldSerializescene() = not _scene.IsNone
//    member __.ShouldSerializexsrc() = not _xsrc.IsNone
//    member __.ShouldSerializeysrc() = not _ysrc.IsNone
//    member __.ShouldSerializezsrc() = not _zsrc.IsNone
//    member __.ShouldSerializeisrc() = not _isrc.IsNone
//    member __.ShouldSerializejsrc() = not _jsrc.IsNone
//    member __.ShouldSerializeksrc() = not _ksrc.IsNone
//    member __.ShouldSerializeintensitysrc() = not _intensitysrc.IsNone
//    member __.ShouldSerializevertexcolorsrc() = not _vertexcolorsrc.IsNone
//    member __.ShouldSerializefacecolorsrc() = not _facecolorsrc.IsNone
