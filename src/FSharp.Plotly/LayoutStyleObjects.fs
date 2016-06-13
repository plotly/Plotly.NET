namespace FSharp.Plotly

[<AutoOpen>]
module LayoutStyleObjects =

//    type Font() =
//
//        let mutable _family: string option = None
//        let mutable _size: float option = None
//        let mutable _color: string option = None
//        //let mutable _description: string option = Some "Sets the global font. Note that fonts used in traces and other layout components inherit from the global font."
//        //let mutable _role: string option = Some "object"
//
//        /// HTML font family - the typeface that will be applied by the web browser. The web browser will only be able to apply a font if it is available on the system which it operates. Provide multiple font families, separated by commas, to indicate the preference in which to apply fonts if they aren't available on the system. The plotly service (at https://plot.ly or on-premise) generates images on a server, where only a select number of fonts are installed and supported. These include *Arial*, *Balto*, *Courier New*, *Droid Sans*,, *Droid Serif*, *Droid Sans Mono*, *Gravitas One*, *Old Standard TT*, *Open Sans*, *Overpass*, *PT Sans Narrow*, *Raleway*, *Times New Roman*.
//        member __.family
//            with get () = Option.get _family
//            and set value = _family <- Some value
//
//        member __.size
//            with get () = Option.get _size
//            and set value = _size <- Some value
//
//        member __.color
//            with get () = Option.get _color
//            and set value = _color <- Some value
//
//    ////    member __.description
//    ////        with get () = Option.get _description
//    ////        and set value = _description <- Some value
//    //
//    ////    member __.role
//    ////        with get () = Option.get _role
//    ////        and set value = _role <- Some value
//
//
//        member __.ShouldSerializefamily() = not _family.IsNone
//        member __.ShouldSerializesize() = not _size.IsNone
//        member __.ShouldSerializecolor() = not _color.IsNone
//        //member __.ShouldSerializedescription() = not _description.IsNone
//        //member __.ShouldSerializerole() = not _role.IsNone

    type Font() =

        let mutable _family: string option = None
        let mutable _size: float option = None
        let mutable _color: string option = None
        //let mutable _description: string option = Some "Sets the text font."
        //let mutable _role: string option = Some "object"
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

    //    member __.description
    //        with get () = Option.get _description
    //        and set value = _description <- Some value

    //    member __.role
    //        with get () = Option.get _role
    //        and set value = _role <- Some value

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
        //member __.ShouldSerializedescription() = not _description.IsNone
        //member __.ShouldSerializerole() = not _role.IsNone
        member __.ShouldSerializefamilysrc() = not _familysrc.IsNone
        member __.ShouldSerializesizesrc() = not _sizesrc.IsNone
        member __.ShouldSerializecolorsrc() = not _colorsrc.IsNone

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

