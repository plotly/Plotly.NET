[<AutoOpen>]
module XPlot.Plotly.Graph

type Insidetextfont() =

    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    //let mutable _description: string option = Some "Sets the font used for `textinfo` lying inside the pie."
    //let mutable _role: string option = Some "object"

    /// HTML font family - the typeface that will be applied by the web browser. The web browser will only be able to apply a font if it is available on the system which it operates. Provide multiple font families, separated by commas, to indicate the preference in which to apply fonts if they aren't available on the system. The plotly service (at https://plot.ly or on-premise) generates images on a server, where only a select number of fonts are installed and supported. These include *Arial*, *Balto*, *Courier New*, *Droid Sans*,, *Droid Serif*, *Droid Sans Mono*, *Gravitas One*, *Old Standard TT*, *Open Sans*, *Overpass*, *PT Sans Narrow*, *Raleway*, *Times New Roman*.
    member __.family
        with get () = Option.get _family
        and set value = _family <- Some value

    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

////    member __.description
////        with get () = Option.get _description
////        and set value = _description <- Some value
//
////    member __.role
////        with get () = Option.get _role
////        and set value = _role <- Some value

    member __.ShouldSerializefamily() = not _family.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    //member __.ShouldSerializedescription() = not _description.IsNone
    //member __.ShouldSerializerole() = not _role.IsNone

type Outsidetextfont() =

    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    //let mutable _description: string option = Some "Sets the font used for `textinfo` lying outside the pie."
    //let mutable _role: string option = Some "object"

    /// HTML font family - the typeface that will be applied by the web browser. The web browser will only be able to apply a font if it is available on the system which it operates. Provide multiple font families, separated by commas, to indicate the preference in which to apply fonts if they aren't available on the system. The plotly service (at https://plot.ly or on-premise) generates images on a server, where only a select number of fonts are installed and supported. These include *Arial*, *Balto*, *Courier New*, *Droid Sans*,, *Droid Serif*, *Droid Sans Mono*, *Gravitas One*, *Old Standard TT*, *Open Sans*, *Overpass*, *PT Sans Narrow*, *Raleway*, *Times New Roman*.
    member __.family
        with get () = Option.get _family
        and set value = _family <- Some value

    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

////    member __.description
////        with get () = Option.get _description
////        and set value = _description <- Some value
//
////    member __.role
////        with get () = Option.get _role
////        and set value = _role <- Some value

    member __.ShouldSerializefamily() = not _family.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    //member __.ShouldSerializedescription() = not _description.IsNone
    //member __.ShouldSerializerole() = not _role.IsNone

type Titlefont() =

    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    //let mutable _description: string option = Some "Sets this color bar's title font."
    //let mutable _role: string option = Some "object"

    /// HTML font family - the typeface that will be applied by the web browser. The web browser will only be able to apply a font if it is available on the system which it operates. Provide multiple font families, separated by commas, to indicate the preference in which to apply fonts if they aren't available on the system. The plotly service (at https://plot.ly or on-premise) generates images on a server, where only a select number of fonts are installed and supported. These include *Arial*, *Balto*, *Courier New*, *Droid Sans*,, *Droid Serif*, *Droid Sans Mono*, *Gravitas One*, *Old Standard TT*, *Open Sans*, *Overpass*, *PT Sans Narrow*, *Raleway*, *Times New Roman*.
    member __.family
        with get () = Option.get _family
        and set value = _family <- Some value

    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

//    member __.description
//        with get () = Option.get _description
//        and set value = _description <- Some value

//    member __.role
////        with get () = Option.get _role
//        and set value = _role <- Some value


    member __.ShouldSerializefamily() = not _family.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    //member __.ShouldSerializedescription() = not _description.IsNone
    //member __.ShouldSerializerole() = not _role.IsNone

type Tickfont() =

    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    //let mutable _description: string option = Some "Sets the tick font."
    //let mutable _role: string option = Some "object"

    /// HTML font family - the typeface that will be applied by the web browser. The web browser will only be able to apply a font if it is available on the system which it operates. Provide multiple font families, separated by commas, to indicate the preference in which to apply fonts if they aren't available on the system. The plotly service (at https://plot.ly or on-premise) generates images on a server, where only a select number of fonts are installed and supported. These include *Arial*, *Balto*, *Courier New*, *Droid Sans*,, *Droid Serif*, *Droid Sans Mono*, *Gravitas One*, *Old Standard TT*, *Open Sans*, *Overpass*, *PT Sans Narrow*, *Raleway*, *Times New Roman*.
    member __.family
        with get () = Option.get _family
        and set value = _family <- Some value

    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

//    member __.description
//        with get () = Option.get _description
//        and set value = _description <- Some value

//    member __.role
//        with get () = Option.get _role
//        and set value = _role <- Some value

    member __.ShouldSerializefamily() = not _family.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    //member __.ShouldSerializedescription() = not _description.IsNone
    //member __.ShouldSerializerole() = not _role.IsNone






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


type Items() =

    let mutable _annotation: Annotation option = None
    let mutable _shape: Shape option = None

    member __.annotation
        with get () = Option.get _annotation
        and set value = _annotation <- Some value

    member __.shape
        with get () = Option.get _shape
        and set value = _shape <- Some value

    member __.ShouldSerializeannotation() = not _annotation.IsNone
    member __.ShouldSerializeshape() = not _shape.IsNone

type Annotations() =

    let mutable _items: Items option = None
    //let mutable _role: string option = Some "object"

    member __.items
        with get () = Option.get _items
        and set value = _items <- Some value

//    member __.role
//        with get () = Option.get _role
//        and set value = _role <- Some value

    member __.ShouldSerializeitems() = not _items.IsNone
    //member __.ShouldSerializerole() = not _role.IsNone


type Shapes() =

    let mutable _items: Items option = None
    //let mutable _role: string option = Some "object"

    member __.items
        with get () = Option.get _items
        and set value = _items <- Some value

//    member __.role
//        with get () = Option.get _role
//        and set value = _role <- Some value

    member __.ShouldSerializeitems() = not _items.IsNone
    //member __.ShouldSerializerole() = not _role.IsNone
e