namespace FSharp.Plotly


module Shapes =
    
    open StyleGramar
    open ChartArea


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





