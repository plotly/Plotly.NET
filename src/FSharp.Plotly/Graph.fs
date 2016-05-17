[<AutoOpen>]
module XPlot.Plotly.Graph

type Trace() =

    let mutable _name: string option = None

    /// Sets the trace name. The trace name appear as the legend item and on hover.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    member __.ShouldSerializename() = not _name.IsNone

type Font() =

    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    //let mutable _description: string option = Some "Sets the global font. Note that fonts used in traces and other layout components inherit from the global font."
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



type Error_z() =

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

////    member __.role
////        with get () = Option.get _role
////        and set value = _role <- Some value
//
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

type Error_y() =

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

////    member __.role
////        with get () = Option.get _role
////        and set value = _role <- Some value

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

type Error_x() =

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

type Textfont() =

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

type Scatter() =
    inherit Trace()

    let mutable _type: string option = Some "scatter"
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
    let mutable _text: _ option = None
    let mutable _mode: string option = None
    let mutable _line: Line option = None
    let mutable _connectgaps: bool option = None
    let mutable _fill: _ option = None
    let mutable _fillcolor: string option = None
    let mutable _marker: Marker option = None
    let mutable _textposition: _ option = None
    let mutable _textfont: Textfont option = None
    let mutable _r: _ option = None
    let mutable _t: _ option = None
    let mutable _error_y: Error_y option = None
    let mutable _error_x: Error_x option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _textsrc: string option = None
    let mutable _textpositionsrc: string option = None
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

//    /// Sets the trace name. The trace name appear as the legend item and on hover.
////    member __.name
////        with get () = Option.get _name
////        and set value = _name <- Some value

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

    /// Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Determines the drawing mode for this scatter trace. If the provided `mode` includes *text* then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points, then the default is *lines+markers*. Otherwise, *lines*.
    member __.mode
        with get () = Option.get _mode
        and set value = _mode <- Some value

    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

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

    /// Sets the source reference on plot.ly for  textposition .
    member __.textpositionsrc
        with get () = Option.get _textpositionsrc
        and set value = _textpositionsrc <- Some value

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
////    member __.ShouldSerializename() = not _name.IsNone
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
    member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
    member __.ShouldSerializefill() = not _fill.IsNone
    member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializetextposition() = not _textposition.IsNone
    member __.ShouldSerializetextfont() = not _textfont.IsNone
    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
    member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
    member __.ShouldSerializersrc() = not _rsrc.IsNone
    member __.ShouldSerializetsrc() = not _tsrc.IsNone















type Bar() =
    inherit Trace()

    let mutable _type: string option = Some "bar"
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
    let mutable _text: _ option = None
    let mutable _orientation: _ option = None
    let mutable _marker: Marker option = None
    let mutable _r: _ option = None
    let mutable _t: _ option = None
    let mutable _error_y: Error_y option = None
    let mutable _error_x: Error_x option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _textsrc: string option = None
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

//    /// Sets the trace name. The trace name appear as the legend item and on hover.
////    member __.name
////        with get () = Option.get _name
////        and set value = _name <- Some value

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
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
    member __.ShouldSerializersrc() = not _rsrc.IsNone
    member __.ShouldSerializetsrc() = not _tsrc.IsNone

type Box() =
    inherit Trace()

    let mutable _type: string option = Some "box"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
//    let mutable _name: string option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _y: _ option = None
    let mutable _x: _ option = None
    let mutable _x0: _ option = None
    let mutable _y0: _ option = None
    let mutable _whiskerwidth: float option = None
    let mutable _boxpoints: _ option = None
    let mutable _boxmean: _ option = None
    let mutable _jitter: float option = None
    let mutable _pointpos: float option = None
    let mutable _orientation: _ option = None
    let mutable _marker: Marker option = None
    let mutable _line: Line option = None
    let mutable _fillcolor: string option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _ysrc: string option = None
    let mutable _xsrc: string option = None

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
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
//    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
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

type Xaxis() =

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

type Yaxis() =

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