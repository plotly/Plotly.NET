namespace FSharp.Plotly


[<AutoOpen>]
module Layout =

    type Layout() =

        let mutable _font: Font option = None
        let mutable _title: string option = None
        let mutable _titlefont: Font option = None
        let mutable _autosize: _ option = None
        let mutable _width: float option = None
        let mutable _height: float option = None
        let mutable _margin: Margin option = None
        let mutable _paper_bgcolor: string option = None
        let mutable _plot_bgcolor: string option = None
        let mutable _separators: string option = None
        let mutable _hidesources: bool option = None
        let mutable _smith: _ option = None
        let mutable _showlegend: bool option = None
        let mutable _dragmode: _ option = None
        let mutable _hovermode: _ option = None
        let mutable _xaxis: Xaxis option = None
        let mutable _xaxis1: Xaxis option = None
        let mutable _xaxis2: Xaxis option = None
        let mutable _yaxis: Yaxis option = None
        let mutable _yaxis2: Yaxis option = None
        let mutable _scene: Scene option = None
        let mutable _geo: Geo option = None
        let mutable _legend: Legend option = None
        let mutable _annotations: seq<Annotation> option = None
        let mutable _shapes: seq<Shape> option = None
        let mutable _radialaxis: Radialaxis option = None
        let mutable _angularaxis: Angularaxis option = None
        let mutable _direction: _ option = None
        let mutable _orientation: float option = None
        let mutable _barmode: string option = None
        let mutable _bargap: float option = None

        member __.font
            with get () = Option.get _font
            and set value = _font <- Some value

        /// Sets the plot's title.
        member __.title
            with get () = Option.get _title
            and set value = _title <- Some value

        member __.titlefont
            with get () = Option.get _titlefont
            and set value = _titlefont <- Some value

        /// Determines whether or not the dimensions of the figure are computed as a function of the display size.
        member __.autosize
            with get () = Option.get _autosize
            and set value = _autosize <- Some value

        /// Sets the plot's width (in px).
        member __.width
            with get () = Option.get _width
            and set value = _width <- Some value

        /// Sets the plot's height (in px).
        member __.height
            with get () = Option.get _height
            and set value = _height <- Some value

        member __.margin
            with get () = Option.get _margin
            and set value = _margin <- Some value

        /// Sets the color of paper where the graph is drawn.
        member __.paper_bgcolor
            with get () = Option.get _paper_bgcolor
            and set value = _paper_bgcolor <- Some value

        /// Sets the color of plotting area in-between x and y axes.
        member __.plot_bgcolor
            with get () = Option.get _plot_bgcolor
            and set value = _plot_bgcolor <- Some value

        /// Sets the decimal and thousand separators. For example, *. * puts a '.' before decimals and a space between thousands.
        member __.separators
            with get () = Option.get _separators
            and set value = _separators <- Some value

        /// Determines whether or not a text link citing the data source is placed at the bottom-right cored of the figure. Has only an effect only on graphs that have been generated via forked graphs from the plotly service (at https://plot.ly or on-premise).
        member __.hidesources
            with get () = Option.get _hidesources
            and set value = _hidesources <- Some value

        member __.smith
            with get () = Option.get _smith
            and set value = _smith <- Some value

        /// Determines whether or not a legend is drawn.
        member __.showlegend
            with get () = Option.get _showlegend
            and set value = _showlegend <- Some value

        /// Determines the mode of drag interactions.
        member __.dragmode
            with get () = Option.get _dragmode
            and set value = _dragmode <- Some value

        /// Determines the mode of hover interactions.
        member __.hovermode
            with get () = Option.get _hovermode
            and set value = _hovermode <- Some value

        member __.xaxis
            with get () = Option.get _xaxis
            and set value = _xaxis <- Some value

        member __.xaxis1
            with get () = Option.get _xaxis1
            and set value = _xaxis1 <- Some value

        member __.xaxis2
            with get () = Option.get _xaxis2
            and set value = _xaxis2 <- Some value

        member __.yaxis
            with get () = Option.get _yaxis
            and set value = _yaxis <- Some value

        member __.yaxis2
            with get () = Option.get _yaxis2
            and set value = _yaxis <- Some value

        member __.scene
            with get () = Option.get _scene
            and set value = _scene <- Some value

        member __.geo
            with get () = Option.get _geo
            and set value = _geo <- Some value

        member __.legend
            with get () = Option.get _legend
            and set value = _legend <- Some value

        member __.annotations
            with get () = Option.get _annotations
            and set value = _annotations <- Some value

        member __.shapes
            with get () = Option.get _shapes
            and set value = _shapes <- Some value

        member __.radialaxis
            with get () = Option.get _radialaxis
            and set value = _radialaxis <- Some value

        member __.angularaxis
            with get () = Option.get _angularaxis
            and set value = _angularaxis <- Some value

        /// For polar plots only. Sets the direction corresponding to positive angles.
        member __.direction
            with get () = Option.get _direction
            and set value = _direction <- Some value

        /// For polar plots only. Rotates the entire polar by the given angle.
        member __.orientation
            with get () = Option.get _orientation
            and set value = _orientation <- Some value

        member __.barmode
            with get () = Option.get _barmode
            and set value = _barmode <- Some value

        member __.bargap
            with get () = Option.get _bargap
            and set value = _bargap <- Some value

        member __.ShouldSerializefont() = not _font.IsNone
        member __.ShouldSerializetitle() = not _title.IsNone
        member __.ShouldSerializetitlefont() = not _titlefont.IsNone
        member __.ShouldSerializeautosize() = not _autosize.IsNone
        member __.ShouldSerializewidth() = not _width.IsNone
        member __.ShouldSerializeheight() = not _height.IsNone
        member __.ShouldSerializemargin() = not _margin.IsNone
        member __.ShouldSerializepaper_bgcolor() = not _paper_bgcolor.IsNone
        member __.ShouldSerializeplot_bgcolor() = not _plot_bgcolor.IsNone
        member __.ShouldSerializeseparators() = not _separators.IsNone
        member __.ShouldSerializehidesources() = not _hidesources.IsNone
        member __.ShouldSerializesmith() = not _smith.IsNone
        member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
        member __.ShouldSerializedragmode() = not _dragmode.IsNone
        member __.ShouldSerializehovermode() = not _hovermode.IsNone
        member __.ShouldSerializexaxis() = not _xaxis.IsNone
        member __.ShouldSerializexaxis1() = not _xaxis1.IsNone
        member __.ShouldSerializexaxis2() = not _xaxis2.IsNone

        member __.ShouldSerializeyaxis() = not _yaxis.IsNone
        member __.ShouldSerializeyaxis2() = not _yaxis2.IsNone
        member __.ShouldSerializescene() = not _scene.IsNone
        member __.ShouldSerializegeo() = not _geo.IsNone
        member __.ShouldSerializelegend() = not _legend.IsNone
        member __.ShouldSerializeannotations() = not _annotations.IsNone
        member __.ShouldSerializeshapes() = not _shapes.IsNone
        member __.ShouldSerializeradialaxis() = not _radialaxis.IsNone
        member __.ShouldSerializeangularaxis() = not _angularaxis.IsNone
        member __.ShouldSerializedirection() = not _direction.IsNone
        member __.ShouldSerializeorientation() = not _orientation.IsNone
        member __.ShouldSerializebarmode() = not _barmode.IsNone
        member __.ShouldSerializebargap() = not _bargap.IsNone