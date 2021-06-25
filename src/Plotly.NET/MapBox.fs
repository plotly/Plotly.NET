namespace Plotly.NET

/// <summary>Determines the style of the map shown in mapbox traces</summary>
type Mapbox() = 

    inherit DynamicObj ()

    /// <summary>Initialize a Mapbox object that determines the style of the map shown in geo mapbox</summary>

    static member init
        (   
            ?Domain: Domain,
            ?AccessToken: string,
            ?Style: StyleParam.MapboxStyle,
            ?Center: (float*float),
            ?Zoom: float,
            ?Bearing: float,
            ?Pitch: float,
            ?Layers: seq<MapboxLayer>
        ) =
            Mapbox()
            |> Mapbox.style
                (
                    ?Domain     = Domain,
                    ?AccessToken= AccessToken,
                    ?Style      = Style,
                    ?Center     = Center,
                    ?Zoom       = Zoom,
                    ?Bearing    = Bearing,
                    ?Pitch      = Pitch,
                    ?Layers     = Layers
                )

    /// <summary>Create a function that applies the given style parameters to a Mapbox object.</summary>

    static member style
        (   
            ?Domain: Domain,
            ?AccessToken: string,
            ?Style: StyleParam.MapboxStyle,
            ?Center: (float*float),
            ?Zoom: float,
            ?Bearing: float,
            ?Pitch: float,
            ?Layers: seq<MapboxLayer>

        ) =
            (fun (mapBox:Mapbox) -> 
                
                Domain          |> DynObj.setValueOpt   mapBox "domain"
                AccessToken     |> DynObj.setValueOpt   mapBox "accesstoken"
                Style           |> DynObj.setValueOptBy mapBox "style" StyleParam.MapboxStyle.convert

                Center         
                |> Option.map (fun (lon,lat) -> 
                    let t = DynamicObj()
                    t?lon <- lon
                    t?lat <- lat
                    t
                )
                |> DynObj.setValueOpt mapBox "center"

                Zoom            |> DynObj.setValueOpt   mapBox "zoom"
                Bearing         |> DynObj.setValueOpt   mapBox "bearing"
                Pitch           |> DynObj.setValueOpt   mapBox "pitch"
                Layers          |> DynObj.setValueOpt   mapBox "layers"

                mapBox
            ) 