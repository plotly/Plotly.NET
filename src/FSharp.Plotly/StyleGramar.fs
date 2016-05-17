namespace FSharp.Plotly

module StyleGramar =
        
    type Font() =

        let mutable _family: string option = None
        let mutable _size: float option = None
        let mutable _color: string option = None        
        let mutable _familysrc: string option = None
        let mutable _sizesrc: string option = None
        let mutable _colorsrc: string option = None

        member __.family
            with get () = Option.get _family
            and set value = _family <- Some value

        member __.size
            with get () = Option.get _size
            and set value = _size <- Some value

        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        /// Sets the source reference on plot.ly for  family .
        member __.familysrc
            with get () = Option.get _familysrc
            and set value = _familysrc <- Some value

        /// Sets the source reference on plot.ly for  size .
        member __.sizesrc
            with get () = Option.get _sizesrc
            and set value = _sizesrc <- Some value

        /// Sets the source reference on plot.ly for  color .
        member __.colorsrc
            with get () = Option.get _colorsrc
            and set value = _colorsrc <- Some value


        member __.ShouldSerializefamily() = not _family.IsNone
        member __.ShouldSerializesize() = not _size.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializefamilysrc() = not _familysrc.IsNone
        member __.ShouldSerializesizesrc() = not _sizesrc.IsNone
        member __.ShouldSerializecolorsrc() = not _colorsrc.IsNone


    type Margin() =

        let mutable _l: float option = None
        let mutable _r: float option = None
        let mutable _t: float option = None
        let mutable _b: float option = None
        let mutable _pad: float option = None
        let mutable _autoexpand: bool option = None
        //let mutable _role: string option = Some "object"

        /// Sets the left margin (in px).
        member __.l
            with get () = Option.get _l
            and set value = _l <- Some value

        /// Sets the right margin (in px).
        member __.r
            with get () = Option.get _r
            and set value = _r <- Some value

        /// Sets the top margin (in px).
        member __.t
            with get () = Option.get _t
            and set value = _t <- Some value

        /// Sets the bottom margin (in px).
        member __.b
            with get () = Option.get _b
            and set value = _b <- Some value

        /// Sets the amount of padding (in px) between the plotting area and the axis lines
        member __.pad
            with get () = Option.get _pad
            and set value = _pad <- Some value

        member __.autoexpand
            with get () = Option.get _autoexpand
            and set value = _autoexpand <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializel() = not _l.IsNone
        member __.ShouldSerializer() = not _r.IsNone
        member __.ShouldSerializet() = not _t.IsNone
        member __.ShouldSerializeb() = not _b.IsNone
        member __.ShouldSerializepad() = not _pad.IsNone
        member __.ShouldSerializeautoexpand() = not _autoexpand.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone



    type Colorbar() =

        let mutable _thicknessmode: _ option = None
        let mutable _thickness: float option = None
        let mutable _lenmode: _ option = None
        let mutable _len: float option = None
        let mutable _x: float option = None
        let mutable _xanchor: _ option = None
        let mutable _xpad: float option = None
        let mutable _y: float option = None
        let mutable _yanchor: _ option = None
        let mutable _ypad: float option = None
        let mutable _outlinecolor: string option = None
        let mutable _outlinewidth: float option = None
        let mutable _bordercolor: string option = None
        let mutable _borderwidth: float option = None
        let mutable _bgcolor: string option = None
        let mutable _tickmode: _ option = None
        let mutable _nticks: int option = None
        let mutable _tick0: float option = None
        let mutable _dtick: _ option = None
        let mutable _tickvals: _ option = None
        let mutable _ticktext: _ option = None
        let mutable _ticks: _ option = None
        let mutable _ticklen: float option = None
        let mutable _tickwidth: float option = None
        let mutable _tickcolor: string option = None
        let mutable _showticklabels: bool option = None
        let mutable _tickfont: Font option = None
        let mutable _tickangle: float option = None
        let mutable _tickformat: string option = None
        let mutable _tickprefix: string option = None
        let mutable _showtickprefix: _ option = None
        let mutable _ticksuffix: string option = None
        let mutable _showticksuffix: _ option = None
        let mutable _exponentformat: _ option = None
        let mutable _showexponent: _ option = None
        let mutable _title: string option = None
        let mutable _titlefont: Font option = None
        let mutable _titleside: _ option = None
        //let mutable _role: string option = Some "object"
        let mutable _tickvalssrc: string option = None
        let mutable _ticktextsrc: string option = None

        /// Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot *fraction* or in *pixels*. Use `thickness` to set the value.
        member __.thicknessmode
            with get () = Option.get _thicknessmode
            and set value = _thicknessmode <- Some value

        /// Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.
        member __.thickness
            with get () = Option.get _thickness
            and set value = _thickness <- Some value

        /// Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot *fraction* or in *pixels. Use `len` to set the value.
        member __.lenmode
            with get () = Option.get _lenmode
            and set value = _lenmode <- Some value

        /// Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.
        member __.len
            with get () = Option.get _len
            and set value = _len <- Some value

        /// Sets the x position of the color bar (in plot fraction).
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the *left*, *center* or *right* of the color bar.
        member __.xanchor
            with get () = Option.get _xanchor
            and set value = _xanchor <- Some value

        /// Sets the amount of padding (in px) along the x direction.
        member __.xpad
            with get () = Option.get _xpad
            and set value = _xpad <- Some value

        /// Sets the y position of the color bar (in plot fraction).
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Sets this color bar's vertical position anchor This anchor binds the `y` position to the *top*, *middle* or *bottom* of the color bar.
        member __.yanchor
            with get () = Option.get _yanchor
            and set value = _yanchor <- Some value

        /// Sets the amount of padding (in px) along the y direction.
        member __.ypad
            with get () = Option.get _ypad
            and set value = _ypad <- Some value

        /// Sets the axis line color.
        member __.outlinecolor
            with get () = Option.get _outlinecolor
            and set value = _outlinecolor <- Some value

        /// Sets the width (in px) of the axis line.
        member __.outlinewidth
            with get () = Option.get _outlinewidth
            and set value = _outlinewidth <- Some value

        /// Sets the axis line color.
        member __.bordercolor
            with get () = Option.get _bordercolor
            and set value = _bordercolor <- Some value

        /// Sets the width (in px) or the border enclosing this color bar.
        member __.borderwidth
            with get () = Option.get _borderwidth
            and set value = _borderwidth <- Some value

        /// Sets the color of padded area.
        member __.bgcolor
            with get () = Option.get _bgcolor
            and set value = _bgcolor <- Some value

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

        /// Sets the tick label formatting rule using the python/d3 number formatting language. See https://github.com/mbostock/d3/wiki/Formatting#numbers or https://docs.python.org/release/3.1.3/library/string.html#formatspec for more info.
        member __.tickformat
            with get () = Option.get _tickformat
            and set value = _tickformat <- Some value

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

        /// Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If *none*, it appears as 1,000,000,000. If *e*, 1e+9. If *E*, 1E+9. If *power*, 1x10^9 (with 9 in a super script). If *SI*, 1G. If *B*, 1B.
        member __.exponentformat
            with get () = Option.get _exponentformat
            and set value = _exponentformat <- Some value

        /// If *all*, all exponents are shown besides their significands. If *first*, only the exponent of the first tick is shown. If *last*, only the exponent of the last tick is shown. If *none*, no exponents appear.
        member __.showexponent
            with get () = Option.get _showexponent
            and set value = _showexponent <- Some value

        /// Sets the title of the color bar.
        member __.title
            with get () = Option.get _title
            and set value = _title <- Some value

        member __.titlefont
            with get () = Option.get _titlefont
            and set value = _titlefont <- Some value

        /// Determines the location of the colorbar title with respect to the color bar.
        member __.titleside
            with get () = Option.get _titleside
            and set value = _titleside <- Some value

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

        member __.ShouldSerializethicknessmode() = not _thicknessmode.IsNone
        member __.ShouldSerializethickness() = not _thickness.IsNone
        member __.ShouldSerializelenmode() = not _lenmode.IsNone
        member __.ShouldSerializelen() = not _len.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializexanchor() = not _xanchor.IsNone
        member __.ShouldSerializexpad() = not _xpad.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializeyanchor() = not _yanchor.IsNone
        member __.ShouldSerializeypad() = not _ypad.IsNone
        member __.ShouldSerializeoutlinecolor() = not _outlinecolor.IsNone
        member __.ShouldSerializeoutlinewidth() = not _outlinewidth.IsNone
        member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
        member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
        member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
        member __.ShouldSerializetickmode() = not _tickmode.IsNone
        member __.ShouldSerializenticks() = not _nticks.IsNone
        member __.ShouldSerializetick0() = not _tick0.IsNone
        member __.ShouldSerializedtick() = not _dtick.IsNone
        member __.ShouldSerializetickvals() = not _tickvals.IsNone
        member __.ShouldSerializeticktext() = not _ticktext.IsNone
        member __.ShouldSerializeticks() = not _ticks.IsNone
        member __.ShouldSerializeticklen() = not _ticklen.IsNone
        member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
        member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
        member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
        member __.ShouldSerializetickfont() = not _tickfont.IsNone
        member __.ShouldSerializetickangle() = not _tickangle.IsNone
        member __.ShouldSerializetickformat() = not _tickformat.IsNone
        member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
        member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
        member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
        member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
        member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
        member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
        member __.ShouldSerializetitle() = not _title.IsNone
        member __.ShouldSerializetitlefont() = not _titlefont.IsNone
        member __.ShouldSerializetitleside() = not _titleside.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializetickvalssrc() = not _tickvalssrc.IsNone
        member __.ShouldSerializeticktextsrc() = not _ticktextsrc.IsNone






    type Line() =

        let mutable _color: _ option = None
        let mutable _width: _ option = None
        let mutable _shape: _ option = None
        let mutable _smoothing: float option = None
        let mutable _dash: string option = None
        //let mutable _role: string option = Some "object"
        let mutable _colorscale: _ option = None
        let mutable _cauto: bool option = None
        let mutable _cmax: float option = None
        let mutable _cmin: float option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _colorsrc: string option = None
        let mutable _widthsrc: string option = None
        let mutable _outliercolor: string option = None
        let mutable _outlierwidth: float option = None

        /// Sets the line color.
        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        /// Sets the line width (in px).
        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

        /// Determines the line shape. With *spline* the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.
        member __.shape
            with get () = Option.get _shape
            and set value = _shape <- Some value

        /// Has only an effect if `shape` is set to *spline* Sets the amount of smoothing. *0* corresponds to no smoothing (equivalent to a *linear* shape).
        member __.smoothing
            with get () = Option.get _smoothing
            and set value = _smoothing <- Some value

        /// Sets the style of the lines. Set to a dash string type or a dash length in px.
        member __.dash
            with get () = Option.get _dash
            and set value = _dash <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value


        /// Has only an effect if `marker.line.color` is set to a numerical array. Sets the colorscale.
        member __.colorscale
            with get () = Option.get _colorscale
            and set value = _colorscale <- Some value

        /// Has only an effect if `marker.line.color` is set to a numerical array. Determines the whether or not the color domain is computed with respect to the input data.
        member __.cauto
            with get () = Option.get _cauto
            and set value = _cauto <- Some value

        /// Has only an effect if `marker.line.color` is set to a numerical array. Sets the upper bound of the color domain.
        member __.cmax
            with get () = Option.get _cmax
            and set value = _cmax <- Some value

        /// Has only an effect if `marker.line.color` is set to a numerical array. Sets the lower bound of the color domain.
        member __.cmin
            with get () = Option.get _cmin
            and set value = _cmin <- Some value

        /// Has only an effect if `marker.line.color` is set to a numerical array. Determines whether or not the colorscale is picked using the sign of values inside `marker.line.color`.
        member __.autocolorscale
            with get () = Option.get _autocolorscale
            and set value = _autocolorscale <- Some value

        /// Has only an effect if `marker.line.color` is set to a numerical array. Reverses the colorscale.
        member __.reversescale
            with get () = Option.get _reversescale
            and set value = _reversescale <- Some value

        /// Sets the source reference on plot.ly for  color .
        member __.colorsrc
            with get () = Option.get _colorsrc
            and set value = _colorsrc <- Some value

        /// Sets the source reference on plot.ly for  width .
        member __.widthsrc
            with get () = Option.get _widthsrc
            and set value = _widthsrc <- Some value

        /// Sets the border line color of the outlier sample points. Defaults to marker.color
        member __.outliercolor
            with get () = Option.get _outliercolor
            and set value = _outliercolor <- Some value

        /// Sets the border line width (in px) of the outlier sample points.
        member __.outlierwidth
            with get () = Option.get _outlierwidth
            and set value = _outlierwidth <- Some value






        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        member __.ShouldSerializeshape() = not _shape.IsNone
        member __.ShouldSerializesmoothing() = not _smoothing.IsNone
        member __.ShouldSerializedash() = not _dash.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
        member __.ShouldSerializecauto() = not _cauto.IsNone
        member __.ShouldSerializecmax() = not _cmax.IsNone
        member __.ShouldSerializecmin() = not _cmin.IsNone
        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
        member __.ShouldSerializereversescale() = not _reversescale.IsNone
        member __.ShouldSerializecolorsrc() = not _colorsrc.IsNone
        member __.ShouldSerializewidthsrc() = not _widthsrc.IsNone
        member __.ShouldSerializeoutliercolor() = not _outliercolor.IsNone
        member __.ShouldSerializeoutlierwidth() = not _outlierwidth.IsNone

    type Marker() =

        let mutable _symbol: _ option = None
        let mutable _opacity: _ option = None
        let mutable _size: _ option = None
        let mutable _color: _ option = None
        let mutable _maxdisplayed: float option = None
        let mutable _sizeref: float option = None
        let mutable _sizemin: float option = None
        let mutable _sizemode: _ option = None
        let mutable _colorscale: _ option = None
        let mutable _cauto: bool option = None
        let mutable _cmax: float option = None
        let mutable _cmin: float option = None
        let mutable _autocolorscale: bool option = None
        let mutable _reversescale: bool option = None
        let mutable _showscale: bool option = None
        let mutable _line: Line option = None
        let mutable _colorbar: Colorbar option = None
        //let mutable _role: string option = Some "object"
        let mutable _symbolsrc: string option = None
        let mutable _opacitysrc: string option = None
        let mutable _sizesrc: string option = None
        let mutable _colorsrc: string option = None
        let mutable _outliercolor: string option = None
        let mutable _colors: _ option = None
        let mutable _colorssrc: string option = None

        /// Sets the marker symbol type. Adding 100 is equivalent to appending *-open* to a symbol name. Adding 200 is equivalent to appending *-dot* to a symbol name. Adding 300 is equivalent to appending *-open-dot* or *dot-open* to a symbol name.
        member __.symbol
            with get () = Option.get _symbol
            and set value = _symbol <- Some value

        /// Sets the marker opacity.
        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        /// Sets the marker size (in px).
        member __.size
            with get () = Option.get _size
            and set value = _size <- Some value

        /// Sets the marker color.
        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        /// Sets a maximum number of points to be drawn on the graph. *0* corresponds to no limit.
        member __.maxdisplayed
            with get () = Option.get _maxdisplayed
            and set value = _maxdisplayed <- Some value

        /// Has only an effect if `marker.size` is set to a numerical array. Sets the scale factor used to determine the rendered size of marker points. Use with `sizemin` and `sizemode`.
        member __.sizeref
            with get () = Option.get _sizeref
            and set value = _sizeref <- Some value

        /// Has only an effect if `marker.size` is set to a numerical array. Sets the minimum size (in px) of the rendered marker points.
        member __.sizemin
            with get () = Option.get _sizemin
            and set value = _sizemin <- Some value

        /// Has only an effect if `marker.size` is set to a numerical array. Sets the rule for which the data in `size` is converted to pixels.
        member __.sizemode
            with get () = Option.get _sizemode
            and set value = _sizemode <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Sets the colorscale.
        member __.colorscale
            with get () = Option.get _colorscale
            and set value = _colorscale <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Determines the whether or not the color domain is computed automatically.
        member __.cauto
            with get () = Option.get _cauto
            and set value = _cauto <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Sets the upper bound of the color domain.
        member __.cmax
            with get () = Option.get _cmax
            and set value = _cmax <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Sets the lower bound of the color domain.
        member __.cmin
            with get () = Option.get _cmin
            and set value = _cmin <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Determines whether or not the colorscale is picked using values inside `marker.color`.
        member __.autocolorscale
            with get () = Option.get _autocolorscale
            and set value = _autocolorscale <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Reverses the colorscale.
        member __.reversescale
            with get () = Option.get _reversescale
            and set value = _reversescale <- Some value

        /// Has only an effect if `marker.color` is set to a numerical array. Determines whether or not a colorbar is displayed.
        member __.showscale
            with get () = Option.get _showscale
            and set value = _showscale <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

        member __.colorbar
            with get () = Option.get _colorbar
            and set value = _colorbar <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        /// Sets the source reference on plot.ly for  symbol .
        member __.symbolsrc
            with get () = Option.get _symbolsrc
            and set value = _symbolsrc <- Some value

        /// Sets the source reference on plot.ly for  opacity .
        member __.opacitysrc
            with get () = Option.get _opacitysrc
            and set value = _opacitysrc <- Some value

        /// Sets the source reference on plot.ly for  size .
        member __.sizesrc
            with get () = Option.get _sizesrc
            and set value = _sizesrc <- Some value

        /// Sets the source reference on plot.ly for  color .
        member __.colorsrc
            with get () = Option.get _colorsrc
            and set value = _colorsrc <- Some value

        /// Sets the color of the outlier sample points.
        member __.outliercolor
            with get () = Option.get _outliercolor
            and set value = _outliercolor <- Some value

        /// Sets the color of each sector of this pie chart. If not specified, the default trace color set is used to pick the sector colors.
        member __.colors
            with get () = Option.get _colors
            and set value = _colors <- Some value

        /// Sets the source reference on plot.ly for  colors .
        member __.colorssrc
            with get () = Option.get _colorssrc
            and set value = _colorssrc <- Some value


        member __.ShouldSerializesymbol() = not _symbol.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializesize() = not _size.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializemaxdisplayed() = not _maxdisplayed.IsNone
        member __.ShouldSerializesizeref() = not _sizeref.IsNone
        member __.ShouldSerializesizemin() = not _sizemin.IsNone
        member __.ShouldSerializesizemode() = not _sizemode.IsNone
        member __.ShouldSerializecolorscale() = not _colorscale.IsNone
        member __.ShouldSerializecauto() = not _cauto.IsNone
        member __.ShouldSerializecmax() = not _cmax.IsNone
        member __.ShouldSerializecmin() = not _cmin.IsNone
        member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
        member __.ShouldSerializereversescale() = not _reversescale.IsNone
        member __.ShouldSerializeshowscale() = not _showscale.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializecolorbar() = not _colorbar.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializesymbolsrc() = not _symbolsrc.IsNone
        member __.ShouldSerializeopacitysrc() = not _opacitysrc.IsNone
        member __.ShouldSerializesizesrc() = not _sizesrc.IsNone
        member __.ShouldSerializecolorsrc() = not _colorsrc.IsNone
        member __.ShouldSerializeoutliercolor() = not _outliercolor.IsNone
        member __.ShouldSerializecolors() = not _colors.IsNone
        member __.ShouldSerializecolorssrc() = not _colorssrc.IsNone

    type Stream() =

        let mutable _token: string option = None
        let mutable _maxpoints: float option = None
        //let mutable _role: string option = Some "object"

        /// The stream id number links a data trace on a plot with a stream. See https://plot.ly/settings for more details.
        member __.token
            with get () = Option.get _token
            and set value = _token <- Some value

        /// Sets the maximum number of points to keep on the plots from an incoming stream. If `maxpoints` is set to *50*, only the newest 50 points will be displayed on the plot.
        member __.maxpoints
            with get () = Option.get _maxpoints
            and set value = _maxpoints <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializetoken() = not _token.IsNone
        member __.ShouldSerializemaxpoints() = not _maxpoints.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone



    type Lighting() =

        let mutable _ambient: float option = None
        let mutable _diffuse: float option = None
        let mutable _specular: float option = None
        let mutable _roughness: float option = None
        let mutable _fresnel: float option = None
        //let mutable _role: string option = Some "object"

        member __.ambient
            with get () = Option.get _ambient
            and set value = _ambient <- Some value

        member __.diffuse
            with get () = Option.get _diffuse
            and set value = _diffuse <- Some value

        member __.specular
            with get () = Option.get _specular
            and set value = _specular <- Some value

        member __.roughness
            with get () = Option.get _roughness
            and set value = _roughness <- Some value

        member __.fresnel
            with get () = Option.get _fresnel
            and set value = _fresnel <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.ShouldSerializeambient() = not _ambient.IsNone
        member __.ShouldSerializediffuse() = not _diffuse.IsNone
        member __.ShouldSerializespecular() = not _specular.IsNone
        member __.ShouldSerializeroughness() = not _roughness.IsNone
        member __.ShouldSerializefresnel() = not _fresnel.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Rotation() =

        let mutable _lon: float option = None
        let mutable _lat: float option = None
        let mutable _roll: float option = None
        //let mutable _role: string option = Some "object"

        /// Rotates the map along parallels (in degrees East).
        member __.lon
            with get () = Option.get _lon
            and set value = _lon <- Some value

        /// Rotates the map along meridians (in degrees North).
        member __.lat
            with get () = Option.get _lat
            and set value = _lat <- Some value

        /// Roll the map (in degrees) For example, a roll of *180* makes the map appear upside down.
        member __.roll
            with get () = Option.get _roll
            and set value = _roll <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.ShouldSerializelon() = not _lon.IsNone
        member __.ShouldSerializelat() = not _lat.IsNone
        member __.ShouldSerializeroll() = not _roll.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone






    type Project() =

        let mutable _x: bool option = None
        let mutable _y: bool option = None
        let mutable _z: bool option = None
        //let mutable _role: string option = Some "object"

        /// Sets whether or not the dynamic contours are projected along the x axis.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets whether or not the dynamic contours are projected along the y axis.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Sets whether or not the dynamic contours are projected along the z axis.
        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type X() =

        let mutable _show: bool option = None
        let mutable _opacity: float option = None
        let mutable _scale: float option = None
        //let mutable _role: string option = Some "object"
        let mutable _project: Project option = None
        let mutable _color: string option = None
        let mutable _usecolormap: bool option = None
        let mutable _width: float option = None
        let mutable _highlight: bool option = None
        let mutable _highlightColor: string option = None
        let mutable _highlightWidth: float option = None

        /// Sets whether or not projections are shown along the x axis.
        member __.show
            with get () = Option.get _show
            and set value = _show <- Some value

        /// Sets the projection color.
        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        /// Sets the scale factor determining the size of the projection marker points.
        member __.scale
            with get () = Option.get _scale
            and set value = _scale <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.project
            with get () = Option.get _project
            and set value = _project <- Some value

        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        member __.usecolormap
            with get () = Option.get _usecolormap
            and set value = _usecolormap <- Some value

        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

        member __.highlight
            with get () = Option.get _highlight
            and set value = _highlight <- Some value

        member __.highlightColor
            with get () = Option.get _highlightColor
            and set value = _highlightColor <- Some value

        member __.highlightWidth
            with get () = Option.get _highlightWidth
            and set value = _highlightWidth <- Some value

        member __.ShouldSerializeshow() = not _show.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializescale() = not _scale.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializeproject() = not _project.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializeusecolormap() = not _usecolormap.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        member __.ShouldSerializehighlight() = not _highlight.IsNone
        member __.ShouldSerializehighlightColor() = not _highlightColor.IsNone
        member __.ShouldSerializehighlightWidth() = not _highlightWidth.IsNone

    type Y() =

        let mutable _show: bool option = None
        let mutable _opacity: float option = None
        let mutable _scale: float option = None
        //let mutable _role: string option = Some "object"
        let mutable _project: Project option = None
        let mutable _color: string option = None
        let mutable _usecolormap: bool option = None
        let mutable _width: float option = None
        let mutable _highlight: bool option = None
        let mutable _highlightColor: string option = None
        let mutable _highlightWidth: float option = None

        /// Sets whether or not projections are shown along the y axis.
        member __.show
            with get () = Option.get _show
            and set value = _show <- Some value

        /// Sets the projection color.
        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        /// Sets the scale factor determining the size of the projection marker points.
        member __.scale
            with get () = Option.get _scale
            and set value = _scale <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.project
            with get () = Option.get _project
            and set value = _project <- Some value

        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        member __.usecolormap
            with get () = Option.get _usecolormap
            and set value = _usecolormap <- Some value

        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

        member __.highlight
            with get () = Option.get _highlight
            and set value = _highlight <- Some value

        member __.highlightColor
            with get () = Option.get _highlightColor
            and set value = _highlightColor <- Some value

        member __.highlightWidth
            with get () = Option.get _highlightWidth
            and set value = _highlightWidth <- Some value

        member __.ShouldSerializeshow() = not _show.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializescale() = not _scale.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializeproject() = not _project.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializeusecolormap() = not _usecolormap.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        member __.ShouldSerializehighlight() = not _highlight.IsNone
        member __.ShouldSerializehighlightColor() = not _highlightColor.IsNone
        member __.ShouldSerializehighlightWidth() = not _highlightWidth.IsNone

    type Z() =

        let mutable _show: bool option = None
        let mutable _opacity: float option = None
        let mutable _scale: float option = None
        //let mutable _role: string option = Some "object"
        let mutable _project: Project option = None
        let mutable _color: string option = None
        let mutable _usecolormap: bool option = None
        let mutable _width: float option = None
        let mutable _highlight: bool option = None
        let mutable _highlightColor: string option = None
        let mutable _highlightWidth: float option = None

        /// Sets whether or not projections are shown along the z axis.
        member __.show
            with get () = Option.get _show
            and set value = _show <- Some value

        /// Sets the projection color.
        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        /// Sets the scale factor determining the size of the projection marker points.
        member __.scale
            with get () = Option.get _scale
            and set value = _scale <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.project
            with get () = Option.get _project
            and set value = _project <- Some value

        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        member __.usecolormap
            with get () = Option.get _usecolormap
            and set value = _usecolormap <- Some value

        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

        member __.highlight
            with get () = Option.get _highlight
            and set value = _highlight <- Some value

        member __.highlightColor
            with get () = Option.get _highlightColor
            and set value = _highlightColor <- Some value

        member __.highlightWidth
            with get () = Option.get _highlightWidth
            and set value = _highlightWidth <- Some value

        member __.ShouldSerializeshow() = not _show.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializescale() = not _scale.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializeproject() = not _project.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializeusecolormap() = not _usecolormap.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        member __.ShouldSerializehighlight() = not _highlight.IsNone
        member __.ShouldSerializehighlightColor() = not _highlightColor.IsNone
        member __.ShouldSerializehighlightWidth() = not _highlightWidth.IsNone

    type Projection() =

        let mutable _x: X option = None
        let mutable _y: Y option = None
        let mutable _z: Z option = None
        //let mutable _role: string option = Some "object"
        let mutable _type: _ option = None
        let mutable _rotation: Rotation option = None
        let mutable _parallels: _ option = None
        let mutable _scale: float option = None

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        /// Sets the projection type.
        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        member __.rotation
            with get () = Option.get _rotation
            and set value = _rotation <- Some value

        /// For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.
        member __.parallels
            with get () = Option.get _parallels
            and set value = _parallels <- Some value

        /// Zooms in or out on the map view.
        member __.scale
            with get () = Option.get _scale
            and set value = _scale <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializerotation() = not _rotation.IsNone
        member __.ShouldSerializeparallels() = not _parallels.IsNone
        member __.ShouldSerializescale() = not _scale.IsNone




    type Contours() =

        let mutable _start: float option = None
        let mutable _end: float option = None
        let mutable _size: float option = None
        let mutable _coloring: _ option = None
        let mutable _showlines: bool option = None
        //let mutable _role: string option = Some "object"
        let mutable _x: X option = None
        let mutable _y: Y option = None
        let mutable _z: Z option = None

        /// Sets the starting contour level value.
        member __.start
            with get () = Option.get _start
            and set value = _start <- Some value

        /// Sets the end contour level value.
        member __.``end``
            with get () = Option.get _end
            and set value = _end <- Some value

        /// Sets the step between each contour level.
        member __.size
            with get () = Option.get _size
            and set value = _size <- Some value

        /// Determines the coloring method showing the contour values. If *fill*, coloring is done evenly between each contour level If *heatmap*, a heatmap gradient is coloring is applied between each contour level. If *lines*, coloring is done on the contour lines. If *none*, no coloring is applied on this trace.
        member __.coloring
            with get () = Option.get _coloring
            and set value = _coloring <- Some value

        /// Determines whether or not the contour lines are drawn. Has only an effect if `contours.coloring` is set to *fill*.
        member __.showlines
            with get () = Option.get _showlines
            and set value = _showlines <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        member __.z
            with get () = Option.get _z
            and set value = _z <- Some value

        member __.ShouldSerializestart() = not _start.IsNone
        member __.ShouldSerializeend() = not _end.IsNone
        member __.ShouldSerializesize() = not _size.IsNone
        member __.ShouldSerializecoloring() = not _coloring.IsNone
        member __.ShouldSerializeshowlines() = not _showlines.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializez() = not _z.IsNone



    type Domain() =

        let mutable _x: _ option = None
        let mutable _y: _ option = None
        //let mutable _role: string option = Some "object"

        /// Sets the horizontal domain of this pie trace (in plot fraction).
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets the vertical domain of this pie trace (in plot fraction).
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Xbins() =

        let mutable _start: float option = None
        let mutable _end: float option = None
        let mutable _size: _ option = None
        //let mutable _role: string option = Some "object"

        /// Sets the starting value for the x axis bins.
        member __.start
            with get () = Option.get _start
            and set value = _start <- Some value

        /// Sets the end value for the x axis bins.
        member __.``end``
            with get () = Option.get _end
            and set value = _end <- Some value

        /// Sets the step in-between value each x axis bin.
        member __.size
            with get () = Option.get _size
            and set value = _size <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.ShouldSerializestart() = not _start.IsNone
        member __.ShouldSerializeend() = not _end.IsNone
        member __.ShouldSerializesize() = not _size.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Ybins() =

        let mutable _start: float option = None
        let mutable _end: float option = None
        let mutable _size: _ option = None
        //let mutable _role: string option = Some "object"

        /// Sets the starting value for the y axis bins.
        member __.start
            with get () = Option.get _start
            and set value = _start <- Some value

        /// Sets the end value for the y axis bins.
        member __.``end``
            with get () = Option.get _end
            and set value = _end <- Some value

        /// Sets the step in-between value each y axis bin.
        member __.size
            with get () = Option.get _size
            and set value = _size <- Some value

    ////    member __.role
    ////        with get () = Option.get _role
    ////        and set value = _role <- Some value

        member __.ShouldSerializestart() = not _start.IsNone
        member __.ShouldSerializeend() = not _end.IsNone
        member __.ShouldSerializesize() = not _size.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone



 
