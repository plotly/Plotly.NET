namespace FSharp.Plotly

module Text =
    
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