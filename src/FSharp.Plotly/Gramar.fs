namespace FSharp.Plotly

module Gramar =


















    type Heatmap() =
        inherit Trace()

        let mutable _type: string option = Some "heatmap"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _z: _ option = None
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _text: _ option = None
        let mutable _transpose: bool option = None
        let mutable _xtype: _ option = None
        let mutable _ytype: _ option = None
        let mutable _zauto: bool option = None
        let mutable _zmin: float option = None
        let mutable _zmax: float option = None
        let mutable _colorscale: _ option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _zsmooth: _ option = None
        let mutable _connectgaps: bool option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _zsrc: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None

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

    type Histogram() =
        inherit Trace()

        let mutable _type: string option = Some "histogram"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _text: string option = None
        let mutable _orientation: _ option = None
        let mutable _marker: Marker option = None
        let mutable _r: _ option = None
        let mutable _t: _ option = None
        let mutable _z: _ option = None
        let mutable _histfunc: _ option = None
        let mutable _histnorm: _ option = None
        let mutable _autobinx: bool option = None
        let mutable _nbinsx: int option = None
        let mutable _xbins: Xbins option = None
        let mutable _autobiny: bool option = None
        let mutable _nbinsy: int option = None
        let mutable _ybins: Ybins option = None
        let mutable _error_y: Error_y option = None
        let mutable _error_x: Error_x option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None
        let mutable _rsrc: string option = None
        let mutable _tsrc: string option = None
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

        /// Sets the sample data to be binned on the x axis.
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

        /// Sets the sample data to be binned on the y axis.
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

        /// Sets the aggregation data.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        /// Specifies the binning function used for this histogram trace. If *count*, the histogram values are computed by counting the number of values lying inside each bin. If *sum*, *avg*, *min*, *max*, the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.
        member __.histfunc
            with get () = Option.get _histfunc
            and set value = _histfunc <- Some value

        /// Specifies the type of normalization used for this histogram trace. If **, the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If *percent*, the span of each bar corresponds to the percentage of occurrences with respect to the total number of sample points (here, the sum of all bin area equals 100%). If *density*, the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin area equals the total number of sample points). If *probability density*, the span of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin area equals 1).
        member __.histnorm
            with get () = Option.get _histnorm
            and set value = _histnorm <- Some value

        /// Determines whether or not the x axis bin attributes are picked by an algorithm.
        member __.autobinx
            with get () = Option.get _autobinx
            and set value = _autobinx <- Some value

        /// Sets the number of x axis bins.
        member __.nbinsx
            with get () = Option.get _nbinsx
            and set value = _nbinsx <- Some value

        member __.xbins
            with get () = Option.get _xbins
            and set value = _xbins <- Some value

        /// Determines whether or not the y axis bin attributes are picked by an algorithm.
        member __.autobiny
            with get () = Option.get _autobiny
            and set value = _autobiny <- Some value

        /// Sets the number of y axis bins.
        member __.nbinsy
            with get () = Option.get _nbinsy
            and set value = _nbinsy <- Some value

        member __.ybins
            with get () = Option.get _ybins
            and set value = _ybins <- Some value

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

        /// Sets the source reference on plot.ly for  z .
        member __.zsrc
            with get () = Option.get _zsrc
            and set value = _zsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
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
        member __.ShouldSerializez() = not _z.IsNone
        member __.ShouldSerializehistfunc() = not _histfunc.IsNone
        member __.ShouldSerializehistnorm() = not _histnorm.IsNone
        member __.ShouldSerializeautobinx() = not _autobinx.IsNone
        member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
        member __.ShouldSerializexbins() = not _xbins.IsNone
        member __.ShouldSerializeautobiny() = not _autobiny.IsNone
        member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
        member __.ShouldSerializeybins() = not _ybins.IsNone
        member __.ShouldSerializeerror_y() = not _error_y.IsNone
        member __.ShouldSerializeerror_x() = not _error_x.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
        member __.ShouldSerializersrc() = not _rsrc.IsNone
        member __.ShouldSerializetsrc() = not _tsrc.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone



    type Histogram2d() =
        inherit Trace()

        let mutable _type: string option = Some "histogram2d"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _z: _ option = None
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _text: _ option = None
        let mutable _transpose: bool option = None
        let mutable _xtype: _ option = None
        let mutable _ytype: _ option = None
        let mutable _zauto: bool option = None
        let mutable _zmin: float option = None
        let mutable _zmax: float option = None
        let mutable _colorscale: _ option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _zsmooth: _ option = None
        let mutable _connectgaps: bool option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _marker: Marker option = None
        let mutable _orientation: _ option = None
        let mutable _histfunc: _ option = None
        let mutable _histnorm: _ option = None
        let mutable _autobinx: bool option = None
        let mutable _nbinsx: int option = None
        let mutable _xbins: Xbins option = None
        let mutable _autobiny: bool option = None
        let mutable _nbinsy: int option = None
        let mutable _ybins: Ybins option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _zsrc: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None

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

        /// Sets the aggregation data.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        /// Sets the sample data to be binned on the x axis.
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

        /// Sets the sample data to be binned on the y axis.
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

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// Sets the orientation of the bars. With *v* (*h*), the value of the each bar spans along the vertical (horizontal).
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        /// Specifies the binning function used for this histogram trace. If *count*, the histogram values are computed by counting the number of values lying inside each bin. If *sum*, *avg*, *min*, *max*, the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.
        member __.histfunc
            with get () = Option.get _histfunc
            and set value = _histfunc <- Some value

        /// Specifies the type of normalization used for this histogram trace. If **, the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If *percent*, the span of each bar corresponds to the percentage of occurrences with respect to the total number of sample points (here, the sum of all bin area equals 100%). If *density*, the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin area equals the total number of sample points). If *probability density*, the span of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin area equals 1).
        member __.histnorm
            with get () = Option.get _histnorm
            and set value = _histnorm <- Some value

        /// Determines whether or not the x axis bin attributes are picked by an algorithm.
        member __.autobinx
            with get () = Option.get _autobinx
            and set value = _autobinx <- Some value

        /// Sets the number of x axis bins.
        member __.nbinsx
            with get () = Option.get _nbinsx
            and set value = _nbinsx <- Some value

        member __.xbins
            with get () = Option.get _xbins
            and set value = _xbins <- Some value

        /// Determines whether or not the y axis bin attributes are picked by an algorithm.
        member __.autobiny
            with get () = Option.get _autobiny
            and set value = _autobiny <- Some value

        /// Sets the number of y axis bins.
        member __.nbinsy
            with get () = Option.get _nbinsy
            and set value = _nbinsy <- Some value

        member __.ybins
            with get () = Option.get _ybins
            and set value = _ybins <- Some value

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
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializehistfunc() = not _histfunc.IsNone
        member __.ShouldSerializehistnorm() = not _histnorm.IsNone
        member __.ShouldSerializeautobinx() = not _autobinx.IsNone
        member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
        member __.ShouldSerializexbins() = not _xbins.IsNone
        member __.ShouldSerializeautobiny() = not _autobiny.IsNone
        member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
        member __.ShouldSerializeybins() = not _ybins.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone

    type Pie() =
        inherit Trace()

        let mutable _type: string option = Some "pie"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _labels: _ option = None
        let mutable _label0: float option = None
        let mutable _dlabel: float option = None
        let mutable _values: _ option = None
        let mutable _marker: Marker option = None
        let mutable _text: _ option = None
        let mutable _scalegroup: string option = None
        let mutable _textinfo: string option = None
        let mutable _textposition: _ option = None
        let mutable _textfont: Textfont option = None
        let mutable _insidetextfont: Insidetextfont option = None
        let mutable _outsidetextfont: Outsidetextfont option = None
        let mutable _domain: Domain option = None
        let mutable _hole: float option = None
        let mutable _sort: bool option = None
        let mutable _direction: _ option = None
        let mutable _rotation: float option = None
        let mutable _pull: float option = None
        let mutable _labelssrc: string option = None
        let mutable _valuessrc: string option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None
        let mutable _pullsrc: string option = None

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
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
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



    type Contour() =
        inherit Trace()

        let mutable _type: string option = Some "contour"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _z: _ option = None
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _text: _ option = None
        let mutable _transpose: bool option = None
        let mutable _xtype: _ option = None
        let mutable _ytype: _ option = None
        let mutable _zauto: bool option = None
        let mutable _zmin: float option = None
        let mutable _zmax: float option = None
        let mutable _colorscale: _ option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _zsmooth: _ option = None
        let mutable _connectgaps: bool option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _autocontour: bool option = None
        let mutable _ncontours: int option = None
        let mutable _contours: Contours option = None
        let mutable _line: Line option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _zsrc: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None
        let mutable _show: bool option = None
        let mutable _color: string option = None
        let mutable _width: float option = None
        //let mutable _role: string option = Some "object"

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

        /// Determines whether of not the contour level attributes at picked by an algorithm. If *true*, the number of contour levels can be set in `ncontours`. If *false*, set the contour level attributes in `contours`.
        member __.autocontour
            with get () = Option.get _autocontour
            and set value = _autocontour <- Some value

        /// Sets the number of contour levels.
        member __.ncontours
            with get () = Option.get _ncontours
            and set value = _ncontours <- Some value

        member __.contours
            with get () = Option.get _contours
            and set value = _contours <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

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

        member __.show
            with get () = Option.get _show
            and set value = _show <- Some value

        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

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
        member __.ShouldSerializeautocontour() = not _autocontour.IsNone
        member __.ShouldSerializencontours() = not _ncontours.IsNone
        member __.ShouldSerializecontours() = not _contours.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
        member __.ShouldSerializeshow() = not _show.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone



    type Histogram2dcontour() =
        inherit Trace()

        let mutable _type: string option = Some "histogram2dcontour"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _z: _ option = None
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _text: _ option = None
        let mutable _transpose: bool option = None
        let mutable _xtype: _ option = None
        let mutable _ytype: _ option = None
        let mutable _zauto: bool option = None
        let mutable _zmin: float option = None
        let mutable _zmax: float option = None
        let mutable _colorscale: _ option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _zsmooth: _ option = None
        let mutable _connectgaps: bool option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _marker: Marker option = None
        let mutable _orientation: _ option = None
        let mutable _histfunc: _ option = None
        let mutable _histnorm: _ option = None
        let mutable _autobinx: bool option = None
        let mutable _nbinsx: int option = None
        let mutable _xbins: Xbins option = None
        let mutable _autobiny: bool option = None
        let mutable _nbinsy: int option = None
        let mutable _ybins: Ybins option = None
        let mutable _autocontour: bool option = None
        let mutable _ncontours: int option = None
        let mutable _contours: Contours option = None
        let mutable _line: Line option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _zsrc: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None

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

        /// Sets the aggregation data.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        /// Sets the sample data to be binned on the x axis.
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

        /// Sets the sample data to be binned on the y axis.
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

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// Sets the orientation of the bars. With *v* (*h*), the value of the each bar spans along the vertical (horizontal).
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        /// Specifies the binning function used for this histogram trace. If *count*, the histogram values are computed by counting the number of values lying inside each bin. If *sum*, *avg*, *min*, *max*, the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.
        member __.histfunc
            with get () = Option.get _histfunc
            and set value = _histfunc <- Some value

        /// Specifies the type of normalization used for this histogram trace. If **, the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If *percent*, the span of each bar corresponds to the percentage of occurrences with respect to the total number of sample points (here, the sum of all bin area equals 100%). If *density*, the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin area equals the total number of sample points). If *probability density*, the span of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin area equals 1).
        member __.histnorm
            with get () = Option.get _histnorm
            and set value = _histnorm <- Some value

        /// Determines whether or not the x axis bin attributes are picked by an algorithm.
        member __.autobinx
            with get () = Option.get _autobinx
            and set value = _autobinx <- Some value

        /// Sets the number of x axis bins.
        member __.nbinsx
            with get () = Option.get _nbinsx
            and set value = _nbinsx <- Some value

        member __.xbins
            with get () = Option.get _xbins
            and set value = _xbins <- Some value

        /// Determines whether or not the y axis bin attributes are picked by an algorithm.
        member __.autobiny
            with get () = Option.get _autobiny
            and set value = _autobiny <- Some value

        /// Sets the number of y axis bins.
        member __.nbinsy
            with get () = Option.get _nbinsy
            and set value = _nbinsy <- Some value

        member __.ybins
            with get () = Option.get _ybins
            and set value = _ybins <- Some value

        /// Determines whether of not the contour level attributes at picked by an algorithm. If *true*, the number of contour levels can be set in `ncontours`. If *false*, set the contour level attributes in `contours`.
        member __.autocontour
            with get () = Option.get _autocontour
            and set value = _autocontour <- Some value

        /// Sets the number of contour levels.
        member __.ncontours
            with get () = Option.get _ncontours
            and set value = _ncontours <- Some value

        member __.contours
            with get () = Option.get _contours
            and set value = _contours <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

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
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializehistfunc() = not _histfunc.IsNone
        member __.ShouldSerializehistnorm() = not _histnorm.IsNone
        member __.ShouldSerializeautobinx() = not _autobinx.IsNone
        member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
        member __.ShouldSerializexbins() = not _xbins.IsNone
        member __.ShouldSerializeautobiny() = not _autobiny.IsNone
        member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
        member __.ShouldSerializeybins() = not _ybins.IsNone
        member __.ShouldSerializeautocontour() = not _autocontour.IsNone
        member __.ShouldSerializencontours() = not _ncontours.IsNone
        member __.ShouldSerializecontours() = not _contours.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone

    type Scatter3d() =
        inherit Trace()

        let mutable _type: string option = Some "scatter3d"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _x: _ option = None
        let mutable _y: _ option = None
        let mutable _z: _ option = None
        let mutable _text: _ option = None
        let mutable _mode: string option = None
        let mutable _surfaceaxis: _ option = None
        let mutable _surfacecolor: string option = None
        let mutable _projection: Projection option = None
        let mutable _line: Line option = None
        let mutable _marker: Marker option = None
        let mutable _textposition: _ option = None
        let mutable _textfont: Textfont option = None
        let mutable _error_x: Error_x option = None
        let mutable _error_y: Error_y option = None
        let mutable _error_z: Error_z option = None
        let mutable _scene: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _zsrc: string option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None

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
    //    member __.ShouldSerializename() = not _name.IsNone
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



    type Surface() =
        inherit Trace()

        let mutable _type: string option = Some "surface"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _z: _ option = None
        let mutable _x: _ option = None
        let mutable _y: _ option = None
        let mutable _text: _ option = None
        let mutable _zauto: bool option = None
        let mutable _zmin: float option = None
        let mutable _zmax: float option = None
        let mutable _colorscale: _ option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _contours: Contours option = None
        let mutable _hidesurface: bool option = None
        let mutable _lighting: Lighting option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _scene: string option = None
        let mutable _zsrc: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None

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

        /// Determines whether or not a colorbar is displayed for this trace.
        member __.showscale
            with get () = Option.get _showscale
            and set value = _showscale <- Some value

        member __.contours
            with get () = Option.get _contours
            and set value = _contours <- Some value

        member __.hidesurface
            with get () = Option.get _hidesurface
            and set value = _hidesurface <- Some value

        member __.lighting
            with get () = Option.get _lighting
            and set value = _lighting <- Some value

        member __.colorbar
            with get () = Option.get _colorbar
            and set value = _colorbar <- Some value

        /// Sets a reference between this trace's 3D coordinate system and a 3D scene. If *scene* (the default value), the (x,y,z) coordinates refer to `layout.scene`. If *scene2*, the (x,y,z) coordinates refer to `layout.scene2`, and so on.
        member __.scene
            with get () = Option.get _scene
            and set value = _scene <- Some value

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
        member __.ShouldSerializecontours() = not _contours.IsNone
        member __.ShouldSerializehidesurface() = not _hidesurface.IsNone
        member __.ShouldSerializelighting() = not _lighting.IsNone
        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
        member __.ShouldSerializescene() = not _scene.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone





    type Mesh3d() =
        inherit Trace()

        let mutable _type: string option = Some "mesh3d"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _x: _ option = None
        let mutable _y: _ option = None
        let mutable _z: _ option = None
        let mutable _i: _ option = None
        let mutable _j: _ option = None
        let mutable _k: _ option = None
        let mutable _delaunayaxis: _ option = None
        let mutable _alphahull: float option = None
        let mutable _intensity: _ option = None
        let mutable _color: string option = None
        let mutable _vertexcolor: _ option = None
        let mutable _facecolor: _ option = None
        let mutable _flatshading: bool option = None
        let mutable _contour: Contour option = None
        let mutable _colorscale: _ option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _lighting: Lighting option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _scene: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _zsrc: string option = None
        let mutable _isrc: string option = None
        let mutable _jsrc: string option = None
        let mutable _ksrc: string option = None
        let mutable _intensitysrc: string option = None
        let mutable _vertexcolorsrc: string option = None
        let mutable _facecolorsrc: string option = None

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

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        member __.i
            with get () = Option.get _i
            and set value = _i <- Some value

        member __.j
            with get () = Option.get _j
            and set value = _j <- Some value

        member __.k
            with get () = Option.get _k
            and set value = _k <- Some value

        member __.delaunayaxis
            with get () = Option.get _delaunayaxis
            and set value = _delaunayaxis <- Some value

        member __.alphahull
            with get () = Option.get _alphahull
            and set value = _alphahull <- Some value

        member __.intensity
            with get () = Option.get _intensity
            and set value = _intensity <- Some value

        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        member __.vertexcolor
            with get () = Option.get _vertexcolor
            and set value = _vertexcolor <- Some value

        member __.facecolor
            with get () = Option.get _facecolor
            and set value = _facecolor <- Some value

        member __.flatshading
            with get () = Option.get _flatshading
            and set value = _flatshading <- Some value

        member __.contour
            with get () = Option.get _contour
            and set value = _contour <- Some value

        /// Sets the colorscale.
        member __.colorscale
            with get () = Option.get _colorscale
            and set value = _colorscale <- Some value

        /// Reverses the colorscale.
        member __.reversescale
            with get () = Option.get _reversescale
            and set value = _reversescale <- Some value

        /// Determines whether or not a colorbar is displayed for this trace.
        member __.showscale
            with get () = Option.get _showscale
            and set value = _showscale <- Some value

        member __.lighting
            with get () = Option.get _lighting
            and set value = _lighting <- Some value

        member __.colorbar
            with get () = Option.get _colorbar
            and set value = _colorbar <- Some value

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

        /// Sets the source reference on plot.ly for  i .
        member __.isrc
            with get () = Option.get _isrc
            and set value = _isrc <- Some value

        /// Sets the source reference on plot.ly for  j .
        member __.jsrc
            with get () = Option.get _jsrc
            and set value = _jsrc <- Some value

        /// Sets the source reference on plot.ly for  k .
        member __.ksrc
            with get () = Option.get _ksrc
            and set value = _ksrc <- Some value

        /// Sets the source reference on plot.ly for  intensity .
        member __.intensitysrc
            with get () = Option.get _intensitysrc
            and set value = _intensitysrc <- Some value

        /// Sets the source reference on plot.ly for  vertexcolor .
        member __.vertexcolorsrc
            with get () = Option.get _vertexcolorsrc
            and set value = _vertexcolorsrc <- Some value

        /// Sets the source reference on plot.ly for  facecolor .
        member __.facecolorsrc
            with get () = Option.get _facecolorsrc
            and set value = _facecolorsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        member __.ShouldSerializei() = not _i.IsNone
        member __.ShouldSerializej() = not _j.IsNone
        member __.ShouldSerializek() = not _k.IsNone
        member __.ShouldSerializedelaunayaxis() = not _delaunayaxis.IsNone
        member __.ShouldSerializealphahull() = not _alphahull.IsNone
        member __.ShouldSerializeintensity() = not _intensity.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializevertexcolor() = not _vertexcolor.IsNone
        member __.ShouldSerializefacecolor() = not _facecolor.IsNone
        member __.ShouldSerializeflatshading() = not _flatshading.IsNone
        member __.ShouldSerializecontour() = not _contour.IsNone
        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
        member __.ShouldSerializereversescale() = not _reversescale.IsNone
        member __.ShouldSerializeshowscale() = not _showscale.IsNone
        member __.ShouldSerializelighting() = not _lighting.IsNone
        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
        member __.ShouldSerializescene() = not _scene.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializeisrc() = not _isrc.IsNone
        member __.ShouldSerializejsrc() = not _jsrc.IsNone
        member __.ShouldSerializeksrc() = not _ksrc.IsNone
        member __.ShouldSerializeintensitysrc() = not _intensitysrc.IsNone
        member __.ShouldSerializevertexcolorsrc() = not _vertexcolorsrc.IsNone
        member __.ShouldSerializefacecolorsrc() = not _facecolorsrc.IsNone

    type Scattergeo() =
        inherit Trace()

        let mutable _type: string option = Some "scattergeo"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _lon: _ option = None
        let mutable _lat: _ option = None
        let mutable _locations: _ option = None
        let mutable _locationmode: _ option = None
        let mutable _mode: string option = None
        let mutable _text: string option = None
        let mutable _line: Line option = None
        let mutable _marker: Marker option = None
        let mutable _textfont: Textfont option = None
        let mutable _textposition: _ option = None
        let mutable _geo: string option = None
        let mutable _lonsrc: string option = None
        let mutable _latsrc: string option = None
        let mutable _locationssrc: string option = None
        let mutable _textsrc: string option = None
        let mutable _textpositionsrc: string option = None

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

        /// Sets the longitude coordinates (in degrees East).
        member __.lon
            with get () = Option.get _lon
            and set value = _lon <- Some value

        /// Sets the latitude coordinates (in degrees North).
        member __.lat
            with get () = Option.get _lat
            and set value = _lat <- Some value

        /// Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.
        member __.locations
            with get () = Option.get _locations
            and set value = _locations <- Some value

        /// Determines the set of locations used to match entries in `locations` to regions on the map.
        member __.locationmode
            with get () = Option.get _locationmode
            and set value = _locationmode <- Some value

        /// Determines the drawing mode for this scatter trace. If the provided `mode` includes *text* then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points, then the default is *lines+markers*. Otherwise, *lines*.
        member __.mode
            with get () = Option.get _mode
            and set value = _mode <- Some value

        /// Sets text elements associated with each (lon,lat) pair. or item in `locations`. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) or `locations` coordinates.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        member __.textfont
            with get () = Option.get _textfont
            and set value = _textfont <- Some value

        /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
        member __.textposition
            with get () = Option.get _textposition
            and set value = _textposition <- Some value

        /// Sets a reference between this trace's geospatial coordinates and a geographic map. If *geo* (the default value), the geospatial coordinates refer to `layout.geo`. If *geo2*, the geospatial coordinates refer to `layout.geo2`, and so on.
        member __.geo
            with get () = Option.get _geo
            and set value = _geo <- Some value

        /// Sets the source reference on plot.ly for  lon .
        member __.lonsrc
            with get () = Option.get _lonsrc
            and set value = _lonsrc <- Some value

        /// Sets the source reference on plot.ly for  lat .
        member __.latsrc
            with get () = Option.get _latsrc
            and set value = _latsrc <- Some value

        /// Sets the source reference on plot.ly for  locations .
        member __.locationssrc
            with get () = Option.get _locationssrc
            and set value = _locationssrc <- Some value

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
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializelon() = not _lon.IsNone
        member __.ShouldSerializelat() = not _lat.IsNone
        member __.ShouldSerializelocations() = not _locations.IsNone
        member __.ShouldSerializelocationmode() = not _locationmode.IsNone
        member __.ShouldSerializemode() = not _mode.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializetextfont() = not _textfont.IsNone
        member __.ShouldSerializetextposition() = not _textposition.IsNone
        member __.ShouldSerializegeo() = not _geo.IsNone
        member __.ShouldSerializelonsrc() = not _lonsrc.IsNone
        member __.ShouldSerializelatsrc() = not _latsrc.IsNone
        member __.ShouldSerializelocationssrc() = not _locationssrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone
        member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone

    type Choropleth() =
        inherit Trace()

        let mutable _type: string option = Some "choropleth"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _locations: _ option = None
        let mutable _locationmode: _ option = None
        let mutable _z: _ option = None
        let mutable _text: _ option = None
        let mutable _marker: Marker option = None
        let mutable _zauto: bool option = None
        let mutable _zmin: float option = None
        let mutable _zmax: float option = None
        let mutable _colorscale: _ option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _colorbar: Colorbar option = None
        let mutable _geo: string option = None
        let mutable _locationssrc: string option = None
        let mutable _zsrc: string option = None
        let mutable _textsrc: string option = None

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

        /// Sets the coordinates via location IDs or names. See `locationmode` for more info.
        member __.locations
            with get () = Option.get _locations
            and set value = _locations <- Some value

        /// Determines the set of locations used to match entries in `locations` to regions on the map.
        member __.locationmode
            with get () = Option.get _locationmode
            and set value = _locationmode <- Some value

        /// Sets the color values.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        /// Sets the text elements associated with each location.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

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

        member __.colorbar
            with get () = Option.get _colorbar
            and set value = _colorbar <- Some value

        /// Sets a reference between this trace's geospatial coordinates and a geographic map. If *geo* (the default value), the geospatial coordinates refer to `layout.geo`. If *geo2*, the geospatial coordinates refer to `layout.geo2`, and so on.
        member __.geo
            with get () = Option.get _geo
            and set value = _geo <- Some value

        /// Sets the source reference on plot.ly for  locations .
        member __.locationssrc
            with get () = Option.get _locationssrc
            and set value = _locationssrc <- Some value

        /// Sets the source reference on plot.ly for  z .
        member __.zsrc
            with get () = Option.get _zsrc
            and set value = _zsrc <- Some value

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
        member __.ShouldSerializelocations() = not _locations.IsNone
        member __.ShouldSerializelocationmode() = not _locationmode.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializezauto() = not _zauto.IsNone
        member __.ShouldSerializezmin() = not _zmin.IsNone
        member __.ShouldSerializezmax() = not _zmax.IsNone
        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
        member __.ShouldSerializereversescale() = not _reversescale.IsNone
        member __.ShouldSerializeshowscale() = not _showscale.IsNone
        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
        member __.ShouldSerializegeo() = not _geo.IsNone
        member __.ShouldSerializelocationssrc() = not _locationssrc.IsNone
        member __.ShouldSerializezsrc() = not _zsrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone

    type Scattergl() =
        inherit Trace()

        let mutable _type: string option = Some "scattergl"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _x: _ option = None
        let mutable _x0: _ option = None
        let mutable _dx: float option = None
        let mutable _y: _ option = None
        let mutable _y0: _ option = None
        let mutable _dy: float option = None
        let mutable _text: string option = None
        let mutable _mode: string option = None
        let mutable _line: Line option = None
        let mutable _marker: Marker option = None
        let mutable _fill: _ option = None
        let mutable _fillcolor: string option = None
        let mutable _error_x: Error_x option = None
        let mutable _error_y: Error_y option = None
        let mutable _xaxis: string option = None
        let mutable _yaxis: string option = None
        let mutable _xsrc: string option = None
        let mutable _ysrc: string option = None
        let mutable _textsrc: string option = None

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

        /// Sets text elements associated with each (x,y) pair to appear on hover. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        /// Determines the drawing mode for this scatter trace.
        member __.mode
            with get () = Option.get _mode
            and set value = _mode <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// Sets the area to fill with a solid color. Use with `fillcolor`.
        member __.fill
            with get () = Option.get _fill
            and set value = _fill <- Some value

        /// Sets the fill color.
        member __.fillcolor
            with get () = Option.get _fillcolor
            and set value = _fillcolor <- Some value

        member __.error_x
            with get () = Option.get _error_x
            and set value = _error_x <- Some value

        member __.error_y
            with get () = Option.get _error_y
            and set value = _error_y <- Some value

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

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializex0() = not _x0.IsNone
        member __.ShouldSerializedx() = not _dx.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializey0() = not _y0.IsNone
        member __.ShouldSerializedy() = not _dy.IsNone
        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializemode() = not _mode.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializefill() = not _fill.IsNone
        member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
        member __.ShouldSerializeerror_x() = not _error_x.IsNone
        member __.ShouldSerializeerror_y() = not _error_y.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializexsrc() = not _xsrc.IsNone
        member __.ShouldSerializeysrc() = not _ysrc.IsNone
        member __.ShouldSerializetextsrc() = not _textsrc.IsNone

    type Area() =
        inherit Trace()

        let mutable _type: string option = Some "area"
        let mutable _visible: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _legendgroup: string option = None
        let mutable _opacity: float option = None
    //    let mutable _name: string option = None
        let mutable _uid: string option = None
        let mutable _hoverinfo: string option = None
        let mutable _stream: Stream option = None
        let mutable _r: _ option = None
        let mutable _t: _ option = None
        let mutable _marker: Marker option = None
        let mutable _rsrc: string option = None
        let mutable _tsrc: string option = None

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

        /// For polar chart only.Sets the radial coordinates.
        member __.r
            with get () = Option.get _r
            and set value = _r <- Some value

        /// For polar chart only.Sets the angular coordinates.
        member __.t
            with get () = Option.get _t
            and set value = _t <- Some value

        member __.marker
            with get () = Option.get _marker
            and set value = _marker <- Some value

        /// Sets the source reference on plot.ly for  r .
        member __.rsrc
            with get () = Option.get _rsrc
            and set value = _rsrc <- Some value

        /// Sets the source reference on plot.ly for  t .
        member __.tsrc
            with get () = Option.get _tsrc
            and set value = _tsrc <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
    //    member __.ShouldSerializename() = not _name.IsNone
        member __.ShouldSerializeuid() = not _uid.IsNone
        member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
        member __.ShouldSerializestream() = not _stream.IsNone
        member __.ShouldSerializer() = not _r.IsNone
        member __.ShouldSerializet() = not _t.IsNone
        member __.ShouldSerializemarker() = not _marker.IsNone
        member __.ShouldSerializersrc() = not _rsrc.IsNone
        member __.ShouldSerializetsrc() = not _tsrc.IsNone












    type Up() =

        let mutable _x: float option = None
        let mutable _y: float option = None
        let mutable _z: float option = None
        //let mutable _description: string option = Some "Sets the (x,y,z) components of the 'up' camera vector. This vector determines the up direction of this scene with respect to the page. The default is *{x: 0, y: 0, z: 1}* which means that the z axis points up."
        //let mutable _role: string option = Some "object"

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

    //    member __.description
    //        with get () = Option.get _description
    //        and set value = _description <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        //member __.ShouldSerializedescription() = not _description.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Center() =

        let mutable _x: float option = None
        let mutable _y: float option = None
        let mutable _z: float option = None
        //let mutable _description: string option = Some "Sets the (x,y,z) components of the 'center' camera vector This vector determines the translation (x,y,z) space about the center of this scene. By default, there is no such translation."
        //let mutable _role: string option = Some "object"

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

    //    member __.description
    //        with get () = Option.get _description
    //        and set value = _description <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        //member __.ShouldSerializedescription() = not _description.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Eye() =

        let mutable _x: float option = None
        let mutable _y: float option = None
        let mutable _z: float option = None
        //let mutable _description: string option = Some "Sets the (x,y,z) components of the 'eye' camera vector. This vector determines the view point about the origin of this scene."
        //let mutable _role: string option = Some "object"

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

    //    member __.description
    //        with get () = Option.get _description
    //        and set value = _description <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        //member __.ShouldSerializedescription() = not _description.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Aspectratio() =

        let mutable _x: float option = None
        let mutable _y: float option = None
        let mutable _z: float option = None
        //let mutable _description: string option = Some "Sets this scene's axis aspectratio."
        //let mutable _role: string option = Some "object"

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

    //    member __.description
    //        with get () = Option.get _description
    //        and set value = _description <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        //member __.ShouldSerializedescription() = not _description.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Camera() =

        let mutable _up: Up option = None
        let mutable _center: Center option = None
        let mutable _eye: Eye option = None
        //let mutable _role: string option = Some "object"

        member __.up
            with get () = Option.get _up
            and set value = _up <- Some value

        member __.center
            with get () = Option.get _center
            and set value = _center <- Some value

        member __.eye
            with get () = Option.get _eye
            and set value = _eye <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializeup() = not _up.IsNone
        member __.ShouldSerializecenter() = not _center.IsNone
        member __.ShouldSerializeeye() = not _eye.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Zaxis() =

        let mutable _showspikes: bool option = None
        let mutable _spikesides: bool option = None
        let mutable _spikethickness: float option = None
        let mutable _spikecolor: string option = None
        let mutable _showbackground: bool option = None
        let mutable _backgroundcolor: string option = None
        let mutable _showaxeslabels: bool option = None
        let mutable _title: string option = None
        let mutable _titlefont: Font option = None
        let mutable _type: _ option = None
        let mutable _autorange: _ option = None
        let mutable _rangemode: _ option = None
        let mutable _range: _ option = None
        let mutable _fixedrange: bool option = None
        let mutable _tickmode: _ option = None
        let mutable _nticks: int option = None
        let mutable _tick0: float option = None
        let mutable _dtick: _ option = None
        let mutable _tickvals: _ option = None
        let mutable _ticktext: _ option = None
        let mutable _ticks: _ option = None
        let mutable _mirror: _ option = None
        let mutable _ticklen: float option = None
        let mutable _tickwidth: float option = None
        let mutable _tickcolor: string option = None
        let mutable _showticklabels: bool option = None
        let mutable _tickfont: Font option = None
        let mutable _tickangle: float option = None
        let mutable _tickprefix: string option = None
        let mutable _showtickprefix: _ option = None
        let mutable _ticksuffix: string option = None
        let mutable _showticksuffix: _ option = None
        let mutable _showexponent: _ option = None
        let mutable _exponentformat: _ option = None
        let mutable _tickformat: string option = None
        let mutable _hoverformat: string option = None
        let mutable _showline: bool option = None
        let mutable _linecolor: string option = None
        let mutable _linewidth: float option = None
        let mutable _showgrid: bool option = None
        let mutable _gridcolor: string option = None
        let mutable _gridwidth: float option = None
        let mutable _zeroline: bool option = None
        let mutable _zerolinecolor: string option = None
        let mutable _zerolinewidth: float option = None
        //let mutable _role: string option = Some "object"
        let mutable _tickvalssrc: string option = None
        let mutable _ticktextsrc: string option = None

        /// Sets whether or not spikes starting from data points to this axis' wall are shown on hover.
        member __.showspikes
            with get () = Option.get _showspikes
            and set value = _showspikes <- Some value

        /// Sets whether or not spikes extending from the projection data points to this axis' wall boundaries are shown on hover.
        member __.spikesides
            with get () = Option.get _spikesides
            and set value = _spikesides <- Some value

        /// Sets the thickness (in px) of the spikes.
        member __.spikethickness
            with get () = Option.get _spikethickness
            and set value = _spikethickness <- Some value

        /// Sets the color of the spikes.
        member __.spikecolor
            with get () = Option.get _spikecolor
            and set value = _spikecolor <- Some value

        /// Sets whether or not this axis' wall has a background color.
        member __.showbackground
            with get () = Option.get _showbackground
            and set value = _showbackground <- Some value

        /// Sets the background color of this axis' wall.
        member __.backgroundcolor
            with get () = Option.get _backgroundcolor
            and set value = _backgroundcolor <- Some value

        /// Sets whether or not this axis is labeled
        member __.showaxeslabels
            with get () = Option.get _showaxeslabels
            and set value = _showaxeslabels <- Some value

        /// Sets the title of this axis.
        member __.title
            with get () = Option.get _title
            and set value = _title <- Some value

        member __.titlefont
            with get () = Option.get _titlefont
            and set value = _titlefont <- Some value

        /// Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.
        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        /// Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to *false*.
        member __.autorange
            with get () = Option.get _autorange
            and set value = _autorange <- Some value

        /// If *normal*, the range is computed in relation to the extrema of the input data. If *tozero*`, the range extends to 0, regardless of the input data If *nonnegative*, the range is non-negative, regardless of the input data.
        member __.rangemode
            with get () = Option.get _rangemode
            and set value = _rangemode <- Some value

        /// Sets the range of this axis. If the axis `type` is *log*, then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is *date*, then you must convert the date to unix time in milliseconds (the number of milliseconds since January 1st, 1970). For example, to set the date range from January 1st 1970 to November 4th, 2013, set the range from 0 to 1380844800000.0
        member __.range
            with get () = Option.get _range
            and set value = _range <- Some value

        /// Determines whether or not this axis is zoom-able. If true, then zoom is disabled.
        member __.fixedrange
            with get () = Option.get _fixedrange
            and set value = _fixedrange <- Some value

        /// Sets the tick mode for this axis. If *auto*, the number of ticks is set via `nticks`. If *linear*, the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` (*linear* is the default value if `tick0` and `dtick` are provided). If *array*, the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. (*array* is the default value if `tickvals` is provided).
        member __.tickmode
            with get () = Option.get _tickmode
            and set value = _tickmode <- Some value

        /// Sets the number of ticks. Has an effect only if `tickmode` is set to *auto*.
        member __.nticks
            with get () = Option.get _nticks
            and set value = _nticks <- Some value

        /// Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is *log*, then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2). If the axis `type` is *date*, then you must convert the date to unix time in milliseconds (the number of milliseconds since January 1st, 1970). For example, to set the starting tick to November 4th, 2013, set the range to 1380844800000.0.
        member __.tick0
            with get () = Option.get _tick0
            and set value = _tick0 <- Some value

        /// Sets the step in-between ticks on this axis Use with `tick0`. If the axis `type` is *log*, then ticks are set every 10^(n*dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. If the axis `type` is *date*, then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0.
        member __.dtick
            with get () = Option.get _dtick
            and set value = _dtick <- Some value

        /// Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to *array*. Used with `ticktext`.
        member __.tickvals
            with get () = Option.get _tickvals
            and set value = _tickvals <- Some value

        /// Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to *array*. Used with `ticktext`.
        member __.ticktext
            with get () = Option.get _ticktext
            and set value = _ticktext <- Some value

        /// Determines whether ticks are drawn or not. If **, this axis' ticks are not drawn. If *outside* (*inside*), this axis' are drawn outside (inside) the axis lines.
        member __.ticks
            with get () = Option.get _ticks
            and set value = _ticks <- Some value

        /// Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If *true*, the axis lines are mirrored. If *ticks*, the axis lines and ticks are mirrored. If *false*, mirroring is disable. If *all*, axis lines are mirrored on all shared-axes subplots. If *allticks*, axis lines and ticks are mirrored on all shared-axes subplots.
        member __.mirror
            with get () = Option.get _mirror
            and set value = _mirror <- Some value

        /// Sets the tick length (in px).
        member __.ticklen
            with get () = Option.get _ticklen
            and set value = _ticklen <- Some value

        /// Sets the tick width (in px).
        member __.tickwidth
            with get () = Option.get _tickwidth
            and set value = _tickwidth <- Some value

        /// Sets the tick color.
        member __.tickcolor
            with get () = Option.get _tickcolor
            and set value = _tickcolor <- Some value

        /// Determines whether or not the tick labels are drawn.
        member __.showticklabels
            with get () = Option.get _showticklabels
            and set value = _showticklabels <- Some value

        member __.tickfont
            with get () = Option.get _tickfont
            and set value = _tickfont <- Some value

        /// Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.
        member __.tickangle
            with get () = Option.get _tickangle
            and set value = _tickangle <- Some value

        /// Sets a tick label prefix.
        member __.tickprefix
            with get () = Option.get _tickprefix
            and set value = _tickprefix <- Some value

        /// If *all*, all tick labels are displayed with a prefix. If *first*, only the first tick is displayed with a prefix. If *last*, only the last tick is displayed with a suffix. If *none*, tick prefixes are hidden.
        member __.showtickprefix
            with get () = Option.get _showtickprefix
            and set value = _showtickprefix <- Some value

        /// Sets a tick label suffix.
        member __.ticksuffix
            with get () = Option.get _ticksuffix
            and set value = _ticksuffix <- Some value

        /// Same as `showtickprefix` but for tick suffixes.
        member __.showticksuffix
            with get () = Option.get _showticksuffix
            and set value = _showticksuffix <- Some value

        /// If *all*, all exponents are shown besides their significands. If *first*, only the exponent of the first tick is shown. If *last*, only the exponent of the last tick is shown. If *none*, no exponents appear.
        member __.showexponent
            with get () = Option.get _showexponent
            and set value = _showexponent <- Some value

        /// Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If *none*, it appears as 1,000,000,000. If *e*, 1e+9. If *E*, 1E+9. If *power*, 1x10^9 (with 9 in a super script). If *SI*, 1G. If *B*, 1B.
        member __.exponentformat
            with get () = Option.get _exponentformat
            and set value = _exponentformat <- Some value

        /// Sets the tick label formatting rule using the python/d3 number formatting language. See https://github.com/mbostock/d3/wiki/Formatting#numbers or https://docs.python.org/release/3.1.3/library/string.html#formatspec for more info.
        member __.tickformat
            with get () = Option.get _tickformat
            and set value = _tickformat <- Some value

        /// Sets the hover text formatting rule for data values on this axis, using the python/d3 number formatting language. See https://github.com/mbostock/d3/wiki/Formatting#numbers or https://docs.python.org/release/3.1.3/library/string.html#formatspec for more info.
        member __.hoverformat
            with get () = Option.get _hoverformat
            and set value = _hoverformat <- Some value

        /// Determines whether or not a line bounding this axis is drawn.
        member __.showline
            with get () = Option.get _showline
            and set value = _showline <- Some value

        /// Sets the axis line color.
        member __.linecolor
            with get () = Option.get _linecolor
            and set value = _linecolor <- Some value

        /// Sets the width (in px) of the axis line.
        member __.linewidth
            with get () = Option.get _linewidth
            and set value = _linewidth <- Some value

        /// Determines whether or not grid lines are drawn. If *true*, the grid lines are drawn at every tick mark.
        member __.showgrid
            with get () = Option.get _showgrid
            and set value = _showgrid <- Some value

        /// Sets the color of the grid lines.
        member __.gridcolor
            with get () = Option.get _gridcolor
            and set value = _gridcolor <- Some value

        /// Sets the width (in px) of the grid lines.
        member __.gridwidth
            with get () = Option.get _gridwidth
            and set value = _gridwidth <- Some value

        /// Determines whether or not a line is drawn at along the 0 value of this axis. If *true*, the zero line is drawn on top of the grid lines.
        member __.zeroline
            with get () = Option.get _zeroline
            and set value = _zeroline <- Some value

        /// Sets the line color of the zero line.
        member __.zerolinecolor
            with get () = Option.get _zerolinecolor
            and set value = _zerolinecolor <- Some value

        /// Sets the width (in px) of the zero line.
        member __.zerolinewidth
            with get () = Option.get _zerolinewidth
            and set value = _zerolinewidth <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        /// Sets the source reference on plot.ly for  tickvals .
        member __.tickvalssrc
            with get () = Option.get _tickvalssrc
            and set value = _tickvalssrc <- Some value

        /// Sets the source reference on plot.ly for  ticktext .
        member __.ticktextsrc
            with get () = Option.get _ticktextsrc
            and set value = _ticktextsrc <- Some value

        member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
        member __.ShouldSerializespikesides() = not _spikesides.IsNone
        member __.ShouldSerializespikethickness() = not _spikethickness.IsNone
        member __.ShouldSerializespikecolor() = not _spikecolor.IsNone
        member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
        member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
        member __.ShouldSerializeshowaxeslabels() = not _showaxeslabels.IsNone
        member __.ShouldSerializetitle() = not _title.IsNone
        member __.ShouldSerializetitlefont() = not _titlefont.IsNone
        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializeautorange() = not _autorange.IsNone
        member __.ShouldSerializerangemode() = not _rangemode.IsNone
        member __.ShouldSerializerange() = not _range.IsNone
        member __.ShouldSerializefixedrange() = not _fixedrange.IsNone
        member __.ShouldSerializetickmode() = not _tickmode.IsNone
        member __.ShouldSerializenticks() = not _nticks.IsNone
        member __.ShouldSerializetick0() = not _tick0.IsNone
        member __.ShouldSerializedtick() = not _dtick.IsNone
        member __.ShouldSerializetickvals() = not _tickvals.IsNone
        member __.ShouldSerializeticktext() = not _ticktext.IsNone
        member __.ShouldSerializeticks() = not _ticks.IsNone
        member __.ShouldSerializemirror() = not _mirror.IsNone
        member __.ShouldSerializeticklen() = not _ticklen.IsNone
        member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
        member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
        member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
        member __.ShouldSerializetickfont() = not _tickfont.IsNone
        member __.ShouldSerializetickangle() = not _tickangle.IsNone
        member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
        member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
        member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
        member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
        member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
        member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
        member __.ShouldSerializetickformat() = not _tickformat.IsNone
        member __.ShouldSerializehoverformat() = not _hoverformat.IsNone
        member __.ShouldSerializeshowline() = not _showline.IsNone
        member __.ShouldSerializelinecolor() = not _linecolor.IsNone
        member __.ShouldSerializelinewidth() = not _linewidth.IsNone
        member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
        member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
        member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
        member __.ShouldSerializezeroline() = not _zeroline.IsNone
        member __.ShouldSerializezerolinecolor() = not _zerolinecolor.IsNone
        member __.ShouldSerializezerolinewidth() = not _zerolinewidth.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializetickvalssrc() = not _tickvalssrc.IsNone
        member __.ShouldSerializeticktextsrc() = not _ticktextsrc.IsNone

    type Scene() =

        let mutable _bgcolor: string option = None
        let mutable _camera: Camera option = None
        let mutable _domain: Domain option = None
        let mutable _aspectmode: _ option = None
        let mutable _aspectratio: Aspectratio option = None
        let mutable _xaxis: Xaxis option = None
        let mutable _yaxis: Yaxis option = None
        let mutable _zaxis: Zaxis option = None
        let mutable __isSubplotObj: bool option = Some true
        //let mutable _role: string option = Some "object"

        member __.bgcolor
            with get () = Option.get _bgcolor
            and set value = _bgcolor <- Some value

        member __.camera
            with get () = Option.get _camera
            and set value = _camera <- Some value

        member __.domain
            with get () = Option.get _domain
            and set value = _domain <- Some value

        /// If *cube*, this scene's axes are drawn as a cube, regardless of the axes' ranges. If *data*, this scene's axes are drawn in proportion with the axes' ranges. If *manual*, this scene's axes are drawn in proportion with the input of *aspectratio* (the default behavior if *aspectratio* is provided). If *auto*, this scene's axes are drawn using the results of *data* except when one axis is more than four times the size of the two others, where in that case the results of *cube* are used.
        member __.aspectmode
            with get () = Option.get _aspectmode
            and set value = _aspectmode <- Some value

        member __.aspectratio
            with get () = Option.get _aspectratio
            and set value = _aspectratio <- Some value

        member __.xaxis
            with get () = Option.get _xaxis
            and set value = _xaxis <- Some value

        member __.yaxis
            with get () = Option.get _yaxis
            and set value = _yaxis <- Some value

        member __.zaxis
            with get () = Option.get _zaxis
            and set value = _zaxis <- Some value

        member __._isSubplotObj
            with get () = Option.get __isSubplotObj
            and set value = __isSubplotObj <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
        member __.ShouldSerializecamera() = not _camera.IsNone
        member __.ShouldSerializedomain() = not _domain.IsNone
        member __.ShouldSerializeaspectmode() = not _aspectmode.IsNone
        member __.ShouldSerializeaspectratio() = not _aspectratio.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializezaxis() = not _zaxis.IsNone
        member __.ShouldSerialize_isSubplotObj() = not __isSubplotObj.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

 
  