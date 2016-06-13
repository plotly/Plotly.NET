namespace FSharp.Plotly

[<AutoOpen>]
module AxisObjects = 

    type LinearAxis() = 

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

    type Xaxis() =
        inherit LinearAxis()

    type Yaxis() =
        inherit LinearAxis()

    type Zaxis() =
        inherit LinearAxis()

    type Radialaxis() =

        let mutable _range: _ option = None
        let mutable _domain: _ option = None
        let mutable _orientation: float option = None
        let mutable _showline: bool option = None
        let mutable _showticklabels: bool option = None
        let mutable _tickorientation: _ option = None
        let mutable _ticklen: float option = None
        let mutable _tickcolor: string option = None
        let mutable _ticksuffix: string option = None
        let mutable _endpadding: float option = None
        let mutable _visible: bool option = None
        //let mutable _role: string option = Some "object"

        /// Defines the start and end point of this radial axis.
        member __.range
            with get () = Option.get _range
            and set value = _range <- Some value

        /// Polar chart subplots are not supported yet. This key has currently no effect.
        member __.domain
            with get () = Option.get _domain
            and set value = _domain <- Some value

        /// Sets the orientation (an angle with respect to the origin) of the radial axis.
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        /// Determines whether or not the line bounding this radial axis will be shown on the figure.
        member __.showline
            with get () = Option.get _showline
            and set value = _showline <- Some value

        /// Determines whether or not the radial axis ticks will feature tick labels.
        member __.showticklabels
            with get () = Option.get _showticklabels
            and set value = _showticklabels <- Some value

        /// Sets the orientation (from the paper perspective) of the radial axis tick labels.
        member __.tickorientation
            with get () = Option.get _tickorientation
            and set value = _tickorientation <- Some value

        /// Sets the length of the tick lines on this radial axis.
        member __.ticklen
            with get () = Option.get _ticklen
            and set value = _ticklen <- Some value

        /// Sets the color of the tick lines on this radial axis.
        member __.tickcolor
            with get () = Option.get _tickcolor
            and set value = _tickcolor <- Some value

        /// Sets the length of the tick lines on this radial axis.
        member __.ticksuffix
            with get () = Option.get _ticksuffix
            and set value = _ticksuffix <- Some value

        member __.endpadding
            with get () = Option.get _endpadding
            and set value = _endpadding <- Some value

        /// Determines whether or not this axis will be visible.
        member __.visible
            with get () = Option.get _visible
            and set value = _visible <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializerange() = not _range.IsNone
        member __.ShouldSerializedomain() = not _domain.IsNone
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializeshowline() = not _showline.IsNone
        member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
        member __.ShouldSerializetickorientation() = not _tickorientation.IsNone
        member __.ShouldSerializeticklen() = not _ticklen.IsNone
        member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
        member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
        member __.ShouldSerializeendpadding() = not _endpadding.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Angularaxis() =

        let mutable _range: _ option = None
        let mutable _domain: _ option = None
        let mutable _showline: bool option = None
        let mutable _showticklabels: bool option = None
        let mutable _tickorientation: _ option = None
        let mutable _ticklen: float option = None
        let mutable _tickcolor: string option = None
        let mutable _ticksuffix: string option = None
        let mutable _endpadding: float option = None
        let mutable _visible: bool option = None
        //let mutable _role: string option = Some "object"

        /// Defines the start and end point of this angular axis.
        member __.range
            with get () = Option.get _range
            and set value = _range <- Some value

        /// Polar chart subplots are not supported yet. This key has currently no effect.
        member __.domain
            with get () = Option.get _domain
            and set value = _domain <- Some value

        /// Determines whether or not the line bounding this angular axis will be shown on the figure.
        member __.showline
            with get () = Option.get _showline
            and set value = _showline <- Some value

        /// Determines whether or not the angular axis ticks will feature tick labels.
        member __.showticklabels
            with get () = Option.get _showticklabels
            and set value = _showticklabels <- Some value

        /// Sets the orientation (from the paper perspective) of the angular axis tick labels.
        member __.tickorientation
            with get () = Option.get _tickorientation
            and set value = _tickorientation <- Some value

        /// Sets the length of the tick lines on this angular axis.
        member __.ticklen
            with get () = Option.get _ticklen
            and set value = _ticklen <- Some value

        /// Sets the color of the tick lines on this angular axis.
        member __.tickcolor
            with get () = Option.get _tickcolor
            and set value = _tickcolor <- Some value

        /// Sets the length of the tick lines on this angular axis.
        member __.ticksuffix
            with get () = Option.get _ticksuffix
            and set value = _ticksuffix <- Some value

        member __.endpadding
            with get () = Option.get _endpadding
            and set value = _endpadding <- Some value

        /// Determines whether or not this axis will be visible.
        member __.visible
            with get () = Option.get _visible
            and set value = _visible <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializerange() = not _range.IsNone
        member __.ShouldSerializedomain() = not _domain.IsNone
        member __.ShouldSerializeshowline() = not _showline.IsNone
        member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
        member __.ShouldSerializetickorientation() = not _tickorientation.IsNone
        member __.ShouldSerializeticklen() = not _ticklen.IsNone
        member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
        member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
        member __.ShouldSerializeendpadding() = not _endpadding.IsNone
        member __.ShouldSerializevisible() = not _visible.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

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

    type Lonaxis() =

        let mutable _range: _ option = None
        let mutable _showgrid: bool option = None
        let mutable _tick0: float option = None
        let mutable _dtick: float option = None
        let mutable _gridcolor: string option = None
        let mutable _gridwidth: float option = None
        //let mutable _role: string option = Some "object"

        /// Sets the range of this axis (in degrees).
        member __.range
            with get () = Option.get _range
            and set value = _range <- Some value

        /// Sets whether or not graticule are shown on the map.
        member __.showgrid
            with get () = Option.get _showgrid
            and set value = _showgrid <- Some value

        /// Sets the graticule's starting tick longitude/latitude.
        member __.tick0
            with get () = Option.get _tick0
            and set value = _tick0 <- Some value

        /// Sets the graticule's longitude/latitude tick step.
        member __.dtick
            with get () = Option.get _dtick
            and set value = _dtick <- Some value

        /// Sets the graticule's stroke color.
        member __.gridcolor
            with get () = Option.get _gridcolor
            and set value = _gridcolor <- Some value

        /// Sets the graticule's stroke width (in px).
        member __.gridwidth
            with get () = Option.get _gridwidth
            and set value = _gridwidth <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializerange() = not _range.IsNone
        member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
        member __.ShouldSerializetick0() = not _tick0.IsNone
        member __.ShouldSerializedtick() = not _dtick.IsNone
        member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
        member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Lataxis() =

        let mutable _range: _ option = None
        let mutable _showgrid: bool option = None
        let mutable _tick0: float option = None
        let mutable _dtick: float option = None
        let mutable _gridcolor: string option = None
        let mutable _gridwidth: float option = None
        //let mutable _role: string option = Some "object"

        /// Sets the range of this axis (in degrees).
        member __.range
            with get () = Option.get _range
            and set value = _range <- Some value

        /// Sets whether or not graticule are shown on the map.
        member __.showgrid
            with get () = Option.get _showgrid
            and set value = _showgrid <- Some value

        /// Sets the graticule's starting tick longitude/latitude.
        member __.tick0
            with get () = Option.get _tick0
            and set value = _tick0 <- Some value

        /// Sets the graticule's longitude/latitude tick step.
        member __.dtick
            with get () = Option.get _dtick
            and set value = _dtick <- Some value

        /// Sets the graticule's stroke color.
        member __.gridcolor
            with get () = Option.get _gridcolor
            and set value = _gridcolor <- Some value

        /// Sets the graticule's stroke width (in px).
        member __.gridwidth
            with get () = Option.get _gridwidth
            and set value = _gridwidth <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializerange() = not _range.IsNone
        member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
        member __.ShouldSerializetick0() = not _tick0.IsNone
        member __.ShouldSerializedtick() = not _dtick.IsNone
        member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
        member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone


    type Geo() =

        let mutable _domain: Domain option = None
        let mutable _resolution: _ option = None
        let mutable _scope: _ option = None
        let mutable _projection: Projection option = None
        let mutable _showcoastlines: bool option = None
        let mutable _coastlinecolor: string option = None
        let mutable _coastlinewidth: float option = None
        let mutable _showland: bool option = None
        let mutable _landcolor: string option = None
        let mutable _showocean: bool option = None
        let mutable _oceancolor: string option = None
        let mutable _showlakes: bool option = None
        let mutable _lakecolor: string option = None
        let mutable _showrivers: bool option = None
        let mutable _rivercolor: string option = None
        let mutable _riverwidth: float option = None
        let mutable _showcountries: bool option = None
        let mutable _countrycolor: string option = None
        let mutable _countrywidth: float option = None
        let mutable _showsubunits: bool option = None
        let mutable _subunitcolor: string option = None
        let mutable _subunitwidth: float option = None
        let mutable _showframe: bool option = None
        let mutable _framecolor: string option = None
        let mutable _framewidth: float option = None
        let mutable _bgcolor: string option = None
        let mutable _lonaxis: Lonaxis option = None
        let mutable _lataxis: Lataxis option = None
        let mutable __isSubplotObj: bool option = Some true
        //let mutable _role: string option = Some "object"

        member __.domain
            with get () = Option.get _domain
            and set value = _domain <- Some value

        /// Sets the resolution of the base layers. The values have units of km/mm e.g. 110 corresponds to a scale ratio of 1:110,000,000.
        member __.resolution
            with get () = Option.get _resolution
            and set value = _resolution <- Some value

        /// Set the scope of the map.
        member __.scope
            with get () = Option.get _scope
            and set value = _scope <- Some value

        member __.projection
            with get () = Option.get _projection
            and set value = _projection <- Some value

        /// Sets whether or not the coastlines are drawn.
        member __.showcoastlines
            with get () = Option.get _showcoastlines
            and set value = _showcoastlines <- Some value

        /// Sets the coastline color.
        member __.coastlinecolor
            with get () = Option.get _coastlinecolor
            and set value = _coastlinecolor <- Some value

        /// Sets the coastline stroke width (in px).
        member __.coastlinewidth
            with get () = Option.get _coastlinewidth
            and set value = _coastlinewidth <- Some value

        /// Sets whether or not land masses are filled in color.
        member __.showland
            with get () = Option.get _showland
            and set value = _showland <- Some value

        /// Sets the land mass color.
        member __.landcolor
            with get () = Option.get _landcolor
            and set value = _landcolor <- Some value

        /// Sets whether or not oceans are filled in color.
        member __.showocean
            with get () = Option.get _showocean
            and set value = _showocean <- Some value

        /// Sets the ocean color
        member __.oceancolor
            with get () = Option.get _oceancolor
            and set value = _oceancolor <- Some value

        /// Sets whether or not lakes are drawn.
        member __.showlakes
            with get () = Option.get _showlakes
            and set value = _showlakes <- Some value

        /// Sets the color of the lakes.
        member __.lakecolor
            with get () = Option.get _lakecolor
            and set value = _lakecolor <- Some value

        /// Sets whether or not rivers are drawn.
        member __.showrivers
            with get () = Option.get _showrivers
            and set value = _showrivers <- Some value

        /// Sets color of the rivers.
        member __.rivercolor
            with get () = Option.get _rivercolor
            and set value = _rivercolor <- Some value

        /// Sets the stroke width (in px) of the rivers.
        member __.riverwidth
            with get () = Option.get _riverwidth
            and set value = _riverwidth <- Some value

        /// Sets whether or not country boundaries are drawn.
        member __.showcountries
            with get () = Option.get _showcountries
            and set value = _showcountries <- Some value

        /// Sets line color of the country boundaries.
        member __.countrycolor
            with get () = Option.get _countrycolor
            and set value = _countrycolor <- Some value

        /// Sets line width (in px) of the country boundaries.
        member __.countrywidth
            with get () = Option.get _countrywidth
            and set value = _countrywidth <- Some value

        /// Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.
        member __.showsubunits
            with get () = Option.get _showsubunits
            and set value = _showsubunits <- Some value

        /// Sets the color of the subunits boundaries.
        member __.subunitcolor
            with get () = Option.get _subunitcolor
            and set value = _subunitcolor <- Some value

        /// Sets the stroke width (in px) of the subunits boundaries.
        member __.subunitwidth
            with get () = Option.get _subunitwidth
            and set value = _subunitwidth <- Some value

        /// Sets whether or not a frame is drawn around the map.
        member __.showframe
            with get () = Option.get _showframe
            and set value = _showframe <- Some value

        /// Sets the color the frame.
        member __.framecolor
            with get () = Option.get _framecolor
            and set value = _framecolor <- Some value

        /// Sets the stroke width (in px) of the frame.
        member __.framewidth
            with get () = Option.get _framewidth
            and set value = _framewidth <- Some value

        /// Set the background color of the map
        member __.bgcolor
            with get () = Option.get _bgcolor
            and set value = _bgcolor <- Some value

        member __.lonaxis
            with get () = Option.get _lonaxis
            and set value = _lonaxis <- Some value

        member __.lataxis
            with get () = Option.get _lataxis
            and set value = _lataxis <- Some value

        member __._isSubplotObj
            with get () = Option.get __isSubplotObj
            and set value = __isSubplotObj <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializedomain() = not _domain.IsNone
        member __.ShouldSerializeresolution() = not _resolution.IsNone
        member __.ShouldSerializescope() = not _scope.IsNone
        member __.ShouldSerializeprojection() = not _projection.IsNone
        member __.ShouldSerializeshowcoastlines() = not _showcoastlines.IsNone
        member __.ShouldSerializecoastlinecolor() = not _coastlinecolor.IsNone
        member __.ShouldSerializecoastlinewidth() = not _coastlinewidth.IsNone
        member __.ShouldSerializeshowland() = not _showland.IsNone
        member __.ShouldSerializelandcolor() = not _landcolor.IsNone
        member __.ShouldSerializeshowocean() = not _showocean.IsNone
        member __.ShouldSerializeoceancolor() = not _oceancolor.IsNone
        member __.ShouldSerializeshowlakes() = not _showlakes.IsNone
        member __.ShouldSerializelakecolor() = not _lakecolor.IsNone
        member __.ShouldSerializeshowrivers() = not _showrivers.IsNone
        member __.ShouldSerializerivercolor() = not _rivercolor.IsNone
        member __.ShouldSerializeriverwidth() = not _riverwidth.IsNone
        member __.ShouldSerializeshowcountries() = not _showcountries.IsNone
        member __.ShouldSerializecountrycolor() = not _countrycolor.IsNone
        member __.ShouldSerializecountrywidth() = not _countrywidth.IsNone
        member __.ShouldSerializeshowsubunits() = not _showsubunits.IsNone
        member __.ShouldSerializesubunitcolor() = not _subunitcolor.IsNone
        member __.ShouldSerializesubunitwidth() = not _subunitwidth.IsNone
        member __.ShouldSerializeshowframe() = not _showframe.IsNone
        member __.ShouldSerializeframecolor() = not _framecolor.IsNone
        member __.ShouldSerializeframewidth() = not _framewidth.IsNone
        member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
        member __.ShouldSerializelonaxis() = not _lonaxis.IsNone
        member __.ShouldSerializelataxis() = not _lataxis.IsNone
        member __.ShouldSerialize_isSubplotObj() = not __isSubplotObj.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone

    type Shape() =

        let mutable _type: _ option = None
        let mutable _xref: _ option = None
        let mutable _x0: _ option = None
        let mutable _x1: _ option = None
        let mutable _yref: _ option = None
        let mutable _y0: _ option = None
        let mutable _y1: _ option = None
        let mutable _path: string option = None
        let mutable _opacity: float option = None
        let mutable _line: Line option = None
        let mutable _fillcolor: string option = None
        //let mutable _role: string option = Some "object"

        /// Specifies the shape type to be drawn. If *line*, a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If *circle*, a circle is drawn from ((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If *rect*, a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`) If *path*, draw a custom SVG path using `path`.
        member __.``type``
            with get () = Option.get _type
            and set value = _type <- Some value

        /// Sets the shape's x coordinate axis. If set to an x axis id (e.g. *x* or *x2*), the `x` position refers to an x coordinate If set to *paper*, the `x` position refers to the distance from the left side of the plotting area in normalized coordinates where *0* (*1*) corresponds to the left (right) side.
        member __.xref
            with get () = Option.get _xref
            and set value = _xref <- Some value

        /// Sets the shape's starting x position. See `type` for more info.
        member __.x0
            with get () = Option.get _x0
            and set value = _x0 <- Some value

        /// Sets the shape's end x position. See `type` for more info.
        member __.x1
            with get () = Option.get _x1
            and set value = _x1 <- Some value

        /// Sets the annotation's y coordinate axis. If set to an y axis id (e.g. *y* or *y2*), the `y` position refers to an y coordinate If set to *paper*, the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where *0* (*1*) corresponds to the bottom (top).
        member __.yref
            with get () = Option.get _yref
            and set value = _yref <- Some value

        /// Sets the shape's starting y position. See `type` for more info.
        member __.y0
            with get () = Option.get _y0
            and set value = _y0 <- Some value

        /// Sets the shape's end y position. See `type` for more info.
        member __.y1
            with get () = Option.get _y1
            and set value = _y1 <- Some value

        /// For `type` *path* - a valid SVG path but with the pixel values replaced by data values. There are a few restrictions / quirks only absolute instructions, not relative. So the allowed segments are: M, L, H, V, Q, C, T, S, and Z arcs (A) are not allowed because radius rx and ry are relative. In the future we could consider supporting relative commands, but we would have to decide on how to handle date and log axes. Note that even as is, Q and C Bezier paths that are smooth on linear axes may not be smooth on log, and vice versa. no chained "polybezier" commands - specify the segment type for each one. On category axes, values are numbers scaled to the serial numbers of categories because using the categories themselves there would be no way to describe fractional positions On data axes: because space and T are both normal components of path strings, we can't use either to separate date from time parts. Therefore we'll use underscore for this purpose: 2015-02-21_13:45:56.789
        member __.path
            with get () = Option.get _path
            and set value = _path <- Some value

        /// Sets the opacity of the shape.
        member __.opacity
            with get () = Option.get _opacity
            and set value = _opacity <- Some value

        member __.line
            with get () = Option.get _line
            and set value = _line <- Some value

        /// Sets the color filling the shape's interior.
        member __.fillcolor
            with get () = Option.get _fillcolor
            and set value = _fillcolor <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

        member __.ShouldSerializetype() = not _type.IsNone
        member __.ShouldSerializexref() = not _xref.IsNone
        member __.ShouldSerializex0() = not _x0.IsNone
        member __.ShouldSerializex1() = not _x1.IsNone
        member __.ShouldSerializeyref() = not _yref.IsNone
        member __.ShouldSerializey0() = not _y0.IsNone
        member __.ShouldSerializey1() = not _y1.IsNone
        member __.ShouldSerializepath() = not _path.IsNone
        member __.ShouldSerializeopacity() = not _opacity.IsNone
        member __.ShouldSerializeline() = not _line.IsNone
        member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone