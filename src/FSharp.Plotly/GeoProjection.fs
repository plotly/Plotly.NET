namespace FSharp.Plotly

/// Determines Map rotation in GeoProjections
///
/// Parameters  :
///
/// Longitude   : Rotates the map along parallels (in degrees East). Defaults to the center of the `lonaxis.range` values.
///
/// Latitude    : Rotates the map along meridians (in degrees North).
/// 
/// Roll        : Roll the map (in degrees) For example, a roll of "180" makes the map appear upside down.

type GeoProjectionRotation () = 
    inherit DynamicObj ()

    static member init
        (   
            ?Longitude  :float,
            ?Latitude   :float,
            ?Roll       :int

        ) =
            GeoProjectionRotation()
            |> GeoProjectionRotation.style
                (
                    ?Longitude  = Longitude,
                    ?Latitude   = Latitude ,
                    ?Roll       = Roll     
                )

    static member style
        (   
            ?Longitude  :float,
            ?Latitude   :float,
            ?Roll       :int
        ) =
            (fun (rotation:GeoProjectionRotation) -> 
                Longitude |> DynObj.setValueOpt rotation "lon"
                Latitude  |> DynObj.setValueOpt rotation "lat"
                Roll      |> DynObj.setValueOpt rotation "roll"

                rotation
            ) 

/// Determines the map projection in geo traces.
/// 
/// Parameters      :
///
/// projectionType  : Sets the type of projection
///
/// Rotation       : Sets the rotation applied to the map
///
/// Parallels      : For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.
///
/// Scale          : Zooms in or out on the map view. A scale of "1" corresponds to the largest zoom level that fits the map's lon and lat ranges.
type GeoProjection() = 
    inherit DynamicObj ()

    static member init
        (   
            projectionType  : StyleParam.GeoProjectionType  ,
            ?Rotation       : GeoProjectionRotation         ,
            ?Parallels      : (float*float)                 ,
            ?Scale          : float

        ) =
            GeoProjection()
            |> GeoProjection.style
                (
                    projectionType  = projectionType,
                    ?Rotation       = Rotation      ,
                    ?Parallels      = Parallels     ,
                    ?Scale          = Scale        
                )

    static member style
        (   
            projectionType  : StyleParam.GeoProjectionType  ,
            ?Rotation       : GeoProjectionRotation         ,
            ?Parallels      : (float*float)                 ,
            ?Scale          : float
        ) =
            (fun (projection:GeoProjection) -> 
                
                projectionType  
                |> StyleParam.GeoProjectionType.convert 
                |> DynObj.setValue projection "type"

                Parallels       
                |> Option.map (fun (a,b) -> sprintf "[%f,%f]" a b) 
                |> DynObj.setValueOpt projection "parallels"

                Rotation        |> DynObj.setValueOpt   projection "rotation"
                Scale           |> DynObj.setValueOpt   projection "scale"

                projection
            ) 