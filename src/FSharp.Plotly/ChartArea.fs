namespace FSharp.Plotly


module ChartArea =
    
    open StyleGramar

    type Axis() =

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
        let mutable _anchor: _ option = None
        let mutable _side: _ option = None
        let mutable _overlaying: _ option = None
        let mutable _domain: _ option = None
        let mutable _position: float option = None
        let mutable __isSubplotObj: bool option = Some true
        //let mutable _role: string option = Some "object"
        let mutable _tickvalssrc: string option = None
        let mutable _ticktextsrc: string option = None
        let mutable _showspikes: bool option = None
        let mutable _spikesides: bool option = None
        let mutable _spikethickness: float option = None
        let mutable _spikecolor: string option = None
        let mutable _showbackground: bool option = None
        let mutable _backgroundcolor: string option = None
        let mutable _showaxeslabels: bool option = None

        //Radialaxis and Angularaxis Extension
        let mutable _orientation: float option = None
        let mutable _tickorientation: _ option = None
        let mutable _endpadding: float option = None
        


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

        /// If set to an opposite-letter axis id (e.g. `xaxis2`, `yaxis`), this axis is bound to the corresponding opposite-letter axis. If set to *free*, this axis' position is determined by `position`.
        member __.anchor
            with get () = Option.get _anchor
            and set value = _anchor <- Some value

        /// Determines whether a x (y) axis is positioned at the *bottom* (*left*) or *top* (*right*) of the plotting area.
        member __.side
            with get () = Option.get _side
            and set value = _side <- Some value

        /// If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis. If *false*, this axis does not overlay any same-letter axes.
        member __.overlaying
            with get () = Option.get _overlaying
            and set value = _overlaying <- Some value

        /// Sets the domain of this axis (in plot fraction).
        member __.domain
            with get () = Option.get _domain
            and set value = _domain <- Some value

        /// Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to *free*.
        member __.position
            with get () = Option.get _position
            and set value = _position <- Some value

        member __._isSubplotObj
            with get () = Option.get __isSubplotObj
            and set value = __isSubplotObj <- Some value

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

        
        //---> Radialaxis and Angularaxis Extension
        
        /// Sets the orientation (an angle with respect to the origin) of the radial axis.
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        /// Sets the orientation (from the paper perspective) of the radial axis tick labels.
        member __.tickorientation
            with get () = Option.get _tickorientation
            and set value = _tickorientation <- Some value

        member __.endpadding
            with get () = Option.get _endpadding
            and set value = _endpadding <- Some value


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
        member __.ShouldSerializeanchor() = not _anchor.IsNone
        member __.ShouldSerializeside() = not _side.IsNone
        member __.ShouldSerializeoverlaying() = not _overlaying.IsNone
        member __.ShouldSerializedomain() = not _domain.IsNone
        member __.ShouldSerializeposition() = not _position.IsNone
        member __.ShouldSerialize_isSubplotObj() = not __isSubplotObj.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializetickvalssrc() = not _tickvalssrc.IsNone
        member __.ShouldSerializeticktextsrc() = not _ticktextsrc.IsNone
        member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
        member __.ShouldSerializespikesides() = not _spikesides.IsNone
        member __.ShouldSerializespikethickness() = not _spikethickness.IsNone
        member __.ShouldSerializespikecolor() = not _spikecolor.IsNone
        member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
        member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
        member __.ShouldSerializeshowaxeslabels() = not _showaxeslabels.IsNone
        
        //Radialaxis and Angularaxis Extension
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializetickorientation() = not _tickorientation.IsNone
        member __.ShouldSerializeendpadding() = not _endpadding.IsNone

    type Xaxis() = inherit Axis()
    type Yaxis() = inherit Axis()


    type Error() =

        let mutable _visible: bool option = None
        let mutable _type: _ option = None
        let mutable _symmetric: bool option = None
        let mutable _array: _ option = None
        let mutable _arrayminus: _ option = None
        let mutable _value: float option = None
        let mutable _valueminus: float option = None
        let mutable _traceref: int option = None
        let mutable _tracerefminus: int option = None
        let mutable _copy_ystyle: bool option = None
        let mutable _copy_zstyle: bool option = None
        let mutable _color: string option = None
        let mutable _thickness: float option = None
        let mutable _width: float option = None
        //let mutable _role: string option = Some "object"
        let mutable _arraysrc: string option = None
        let mutable _arrayminussrc: string option = None

        /// Determines whether or not this set of error bars is visible.
        member __.visible
            with get () = Option.get _visible
            and set value = _visible <- Some value

        /// Determines the rule used to generate the error bars. If *constant`, the bar lengths are of a constant value. Set this constant in `value`. If *percent*, the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If *sqrt*, the bar lengths correspond to the sqaure of the underlying data. If *array*, the bar lengths are set with data set `array`.
        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        /// Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.
        member __.symmetric
            with get () = Option.get _symmetric
            and set value = _symmetric <- Some value

        /// Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.
        member __.array
            with get () = Option.get _array
            and set value = _array <- Some value

        /// Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.
        member __.arrayminus
            with get () = Option.get _arrayminus
            and set value = _arrayminus <- Some value

        /// Sets the value of either the percentage (if `type` is set to *percent*) or the constant (if `type` is set to *constant*) corresponding to the lengths of the error bars.
        member __.value
            with get () = Option.get _value
            and set value = _value <- Some value

        /// Sets the value of either the percentage (if `type` is set to *percent*) or the constant (if `type` is set to *constant*) corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars
        member __.valueminus
            with get () = Option.get _valueminus
            and set value = _valueminus <- Some value

        member __.traceref
            with get () = Option.get _traceref
            and set value = _traceref <- Some value

        member __.tracerefminus
            with get () = Option.get _tracerefminus
            and set value = _tracerefminus <- Some value

        member __.copy_ystyle
            with get () = Option.get _copy_ystyle
            and set value = _copy_ystyle <- Some value

        member __.copy_zstyle
            with get () = Option.get _copy_zstyle
            and set value = _copy_zstyle <- Some value

        /// Sets the stoke color of the error bars.
        member __.color
            with get () = Option.get _color
            and set value = _color <- Some value

        /// Sets the thickness (in px) of the error bars.
        member __.thickness
            with get () = Option.get _thickness
            and set value = _thickness <- Some value

        /// Sets the width (in px) of the cross-bar at both ends of the error bars.
        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        /// Sets the source reference on plot.ly for  array .
        member __.arraysrc
            with get () = Option.get _arraysrc
            and set value = _arraysrc <- Some value

        /// Sets the source reference on plot.ly for  arrayminus .
        member __.arrayminussrc
            with get () = Option.get _arrayminussrc
            and set value = _arrayminussrc <- Some value

        member __.ShouldSerializevisible() = not _visible.IsNone
        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializesymmetric() = not _symmetric.IsNone
        member __.ShouldSerializearray() = not _array.IsNone
        member __.ShouldSerializearrayminus() = not _arrayminus.IsNone
        member __.ShouldSerializevalue() = not _value.IsNone
        member __.ShouldSerializevalueminus() = not _valueminus.IsNone
        member __.ShouldSerializetraceref() = not _traceref.IsNone
        member __.ShouldSerializetracerefminus() = not _tracerefminus.IsNone
        member __.ShouldSerializecopy_ystyle() = not _copy_ystyle.IsNone
        member __.ShouldSerializecopy_zstyle() = not _copy_zstyle.IsNone
        member __.ShouldSerializecolor() = not _color.IsNone
        member __.ShouldSerializethickness() = not _thickness.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializearraysrc() = not _arraysrc.IsNone
        member __.ShouldSerializearrayminussrc() = not _arrayminussrc.IsNone


    type Error_x() = inherit Error()
    type Error_y() = inherit Error()
    type Error_z() = inherit Error()


    type Legend() =

        let mutable _bgcolor: string option = None
        let mutable _bordercolor: string option = None
        let mutable _borderwidth: float option = None
        let mutable _font: Font option = None
        let mutable _traceorder: string option = None
        let mutable _tracegroupgap: float option = None
        let mutable _x: float option = None
        let mutable _xanchor: _ option = None
        let mutable _y: float option = None
        let mutable _yanchor: _ option = None
        //let mutable _role: string option = Some "object"

        /// Sets the legend background color.
        member __.bgcolor
            with get () = Option.get _bgcolor
            and set value = _bgcolor <- Some value

        /// Sets the color of the border enclosing the legend.
        member __.bordercolor
            with get () = Option.get _bordercolor
            and set value = _bordercolor <- Some value

        /// Sets the width (in px) of the border enclosing the legend.
        member __.borderwidth
            with get () = Option.get _borderwidth
            and set value = _borderwidth <- Some value

        member __.font
            with get () = Option.get _font
            and set value = _font <- Some value

        /// Determines the order at which the legend items are displayed. If *normal*, the items are displayed top-to-bottom in the same order as the input data. If *reversed*, the items are displayed in the opposite order as *normal*. If *grouped*, the items are displayed in groups (when a trace `legendgroup` is provided). if *grouped+reversed*, the items are displayed in the opposite order as *grouped*.
        member __.traceorder
            with get () = Option.get _traceorder
            and set value = _traceorder <- Some value

        /// Sets the amount of vertical space (in px) between legend groups.
        member __.tracegroupgap
            with get () = Option.get _tracegroupgap
            and set value = _tracegroupgap <- Some value

        /// Sets the x position (in normalized coordinates) of the legend.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets the legend's horizontal position anchor. This anchor binds the `x` position to the *left*, *center* or *right* of the legend.
        member __.xanchor
            with get () = Option.get _xanchor
            and set value = _xanchor <- Some value

        /// Sets the y position (in normalized coordinates) of the legend.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Sets the legend's vertical position anchor This anchor binds the `y` position to the *top*, *middle* or *bottom* of the legend.
        member __.yanchor
            with get () = Option.get _yanchor
            and set value = _yanchor <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
        member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
        member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
        member __.ShouldSerializefont() = not _font.IsNone
        member __.ShouldSerializetraceorder() = not _traceorder.IsNone
        member __.ShouldSerializetracegroupgap() = not _tracegroupgap.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializexanchor() = not _xanchor.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializeyanchor() = not _yanchor.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Annotation() =

        let mutable _text: string option = None
        let mutable _textangle: float option = None
        let mutable _font: Font option = None
        let mutable _opacity: float option = None
        let mutable _align: _ option = None
        let mutable _bgcolor: string option = None
        let mutable _bordercolor: string option = None
        let mutable _borderpad: float option = None
        let mutable _borderwidth: float option = None
        let mutable _showarrow: bool option = None
        let mutable _arrowcolor: string option = None
        let mutable _arrowhead: int option = None
        let mutable _arrowsize: float option = None
        let mutable _arrowwidth: float option = None
        let mutable _ax: float option = None
        let mutable _ay: float option = None
        let mutable _xref: _ option = None
        let mutable _x: _ option = None
        let mutable _xanchor: _ option = None
        let mutable _yref: _ option = None
        let mutable _y: _ option = None
        let mutable _yanchor: _ option = None
        //let mutable _role: string option = Some "object"

        /// Sets the text associated with this annotation. Plotly uses a subset of HTML tags to do things like newline (<br>), bold (<b></b>), italics (<i></i>), hyperlinks (<a href='...'></a>). Tags <em>, <sup>, <sub> <span> are also supported.
        member __.text
            with get () = Option.get _text
            and set value = _text <- Some value

        /// Sets the angle at which the `text` is drawn with respect to the horizontal.
        member __.textangle
            with get () = Option.get _textangle
            and set value = _textangle <- Some value

        member __.font
            with get () = Option.get _font
            and set value = _font <- Some value

        /// Sets the opacity of the annotation (text + arrow).
        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        /// Sets the vertical alignment of the `text` with respect to the set `x` and `y` position. Has only an effect if `text` spans more two or more lines (i.e. `text` contains one or more <br> HTML tags).
        member __.align
            with get () = Option.get _align
            and set value = _align <- Some value

        /// Sets the background color of the annotation.
        member __.bgcolor
            with get () = Option.get _bgcolor
            and set value = _bgcolor <- Some value

        /// Sets the color of the border enclosing the annotation `text`.
        member __.bordercolor
            with get () = Option.get _bordercolor
            and set value = _bordercolor <- Some value

        /// Sets the padding (in px) between the `text` and the enclosing border.
        member __.borderpad
            with get () = Option.get _borderpad
            and set value = _borderpad <- Some value

        /// Sets the width (in px) of the border enclosing the annotation `text`.
        member __.borderwidth
            with get () = Option.get _borderwidth
            and set value = _borderwidth <- Some value

        /// Determines whether or not the annotation is drawn with an arrow. If *true*, `text` is placed near the arrow's tail. If *false*, `text` lines up with the `x` and `y` provided.
        member __.showarrow
            with get () = Option.get _showarrow
            and set value = _showarrow <- Some value

        /// Sets the color of the annotation arrow.
        member __.arrowcolor
            with get () = Option.get _arrowcolor
            and set value = _arrowcolor <- Some value

        /// Sets the annotation arrow head style.
        member __.arrowhead
            with get () = Option.get _arrowhead
            and set value = _arrowhead <- Some value

        /// Sets the size (in px) of annotation arrow head.
        member __.arrowsize
            with get () = Option.get _arrowsize
            and set value = _arrowsize <- Some value

        /// Sets the width (in px) of annotation arrow.
        member __.arrowwidth
            with get () = Option.get _arrowwidth
            and set value = _arrowwidth <- Some value

        /// Sets the x component of the arrow tail about the arrow head. A positive (negative) component corresponds to an arrow pointing from right to left (left to right)
        member __.ax
            with get () = Option.get _ax
            and set value = _ax <- Some value

        /// Sets the y component of the arrow tail about the arrow head. A positive (negative) component corresponds to an arrow pointing from bottom to top (top to bottom)
        member __.ay
            with get () = Option.get _ay
            and set value = _ay <- Some value

        /// Sets the annotation's x coordinate axis. If set to an x axis id (e.g. *x* or *x2*), the `x` position refers to an x coordinate If set to *paper*, the `x` position refers to the distance from the left side of the plotting area in normalized coordinates where 0 (1) corresponds to the left (right) side.
        member __.xref
            with get () = Option.get _xref
            and set value = _xref <- Some value

        /// Sets the annotation's x position. Note that dates and categories are converted to numbers.
        member __.x
            with get () = Option.get _x
            and set value = _x <- Some value

        /// Sets the annotation's horizontal position anchor This anchor binds the `x` position to the *left*, *center* or *right* of the annotation. For example, if `x` is set to 1, `xref` to *paper* and `xanchor` to *right* then the right-most portion of the annotation lines up with the right-most edge of the plotting area. If *auto*, the anchor is equivalent to *center* for data-referenced annotations whereas for paper-referenced, the anchor picked corresponds to the closest side.
        member __.xanchor
            with get () = Option.get _xanchor
            and set value = _xanchor <- Some value

        /// Sets the annotation's y coordinate axis. If set to an y axis id (e.g. *y* or *y2*), the `y` position refers to an y coordinate If set to *paper*, the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where 0 (1) corresponds to the bottom (top).
        member __.yref
            with get () = Option.get _yref
            and set value = _yref <- Some value

        /// Sets the annotation's y position. Note that dates and categories are converted to numbers.
        member __.y
            with get () = Option.get _y
            and set value = _y <- Some value

        /// Sets the annotation's vertical position anchor This anchor binds the `y` position to the *top*, *middle* or *bottom* of the annotation. For example, if `y` is set to 1, `yref` to *paper* and `yanchor` to *top* then the top-most portion of the annotation lines up with the top-most edge of the plotting area. If *auto*, the anchor is equivalent to *middle* for data-referenced annotations whereas for paper-referenced, the anchor picked corresponds to the closest side.
        member __.yanchor
            with get () = Option.get _yanchor
            and set value = _yanchor <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializetext() = not _text.IsNone
        member __.ShouldSerializetextangle() = not _textangle.IsNone
        member __.ShouldSerializefont() = not _font.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializealign() = not _align.IsNone
        member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
        member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
        member __.ShouldSerializeborderpad() = not _borderpad.IsNone
        member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
        member __.ShouldSerializeshowarrow() = not _showarrow.IsNone
        member __.ShouldSerializearrowcolor() = not _arrowcolor.IsNone
        member __.ShouldSerializearrowhead() = not _arrowhead.IsNone
        member __.ShouldSerializearrowsize() = not _arrowsize.IsNone
        member __.ShouldSerializearrowwidth() = not _arrowwidth.IsNone
        member __.ShouldSerializeax() = not _ax.IsNone
        member __.ShouldSerializeay() = not _ay.IsNone
        member __.ShouldSerializexref() = not _xref.IsNone
        member __.ShouldSerializex() = not _x.IsNone
        member __.ShouldSerializexanchor() = not _xanchor.IsNone
        member __.ShouldSerializeyref() = not _yref.IsNone
        member __.ShouldSerializey() = not _y.IsNone
        member __.ShouldSerializeyanchor() = not _yanchor.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone


