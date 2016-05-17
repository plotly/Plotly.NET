namespace FSharp.Plotly


module Geo =
    
    open StyleGramar
    open ChartArea
 
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
        let mutable _lonaxis: Axis option = None
        let mutable _lataxis: Axis option = None
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



