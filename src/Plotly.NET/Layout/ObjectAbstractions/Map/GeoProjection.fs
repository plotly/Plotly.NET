namespace Plotly.NET.LayoutObjects

open Plotly.NET
OHNONONO
open System
open System.Runtime.InteropServices

/// <summary>Determines Map rotation in GeoProjections</summary>
type GeoProjectionRotation () = 
    inherit ImmutableDynamicObj ()

    /// <summary>Initialize a GeoProjectionRotation object that determines Map rotation in GeoProjections</summary>
    /// <param name="Longitude">Rotates the map along parallels (in degrees East). Defaults to the center of the `lonaxis.range` values.</param>
    /// <param name="Latitude">Rotates the map along meridians (in degrees North).</param>
    /// <param name="Roll">Roll the map (in degrees) For example, a roll of "180" makes the map appear upside down.</param>
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?Longitude  :float,
            [<Optional;DefaultParameterValue(null)>] ?Latitude   :float,
            [<Optional;DefaultParameterValue(null)>] ?Roll       :int

        ) =
            GeoProjectionRotation()
            |> GeoProjectionRotation.style
                (
                    ?Longitude  = Longitude,
                    ?Latitude   = Latitude ,
                    ?Roll       = Roll     
                )

    /// <summary>Create a function that applies the given style parameters to a GeoProjectionRotation object</summary>
    /// <param name="Longitude">Rotates the map along parallels (in degrees East). Defaults to the center of the `lonaxis.range` values.</param>
    /// <param name="Latitude">Rotates the map along meridians (in degrees North).</param>
    /// <param name="Roll">Roll the map (in degrees) For example, a roll of "180" makes the map appear upside down.</param>
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?Longitude  :float,
            [<Optional;DefaultParameterValue(null)>] ?Latitude   :float,
            [<Optional;DefaultParameterValue(null)>] ?Roll       :int
        ) =
            (fun (rotation:GeoProjectionRotation) -> 

                rotation
                ++? ("lon", Longitude )
                ++? ("lat", Latitude  )
                ++? ("roll", Roll      )
            ) 

/// <summary>Determines the map projection in geo traces.</summary>
type GeoProjection() = 
    inherit ImmutableDynamicObj ()

    /// <summary>Initialize a GeoProjection object that determines the map projection in geo traces.</summary>
    /// <param name="projectionType">Sets the type of projection</param>
    /// <param name="Rotation">Sets the rotation applied to the map</param>
    /// <param name="Parallels">For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.</param>
    /// <param name="Scale">Zooms in or out on the map view. A scale of "1" corresponds to the largest zoom level that fits the map's lon and lat ranges.</param>
    static member init
        (   
            projectionType  : StyleParam.GeoProjectionType  ,
            [<Optional;DefaultParameterValue(null)>] ?Rotation       : GeoProjectionRotation         ,
            [<Optional;DefaultParameterValue(null)>] ?Parallels      : (float*float)                 ,
            [<Optional;DefaultParameterValue(null)>] ?Scale          : float

        ) =
            GeoProjection()
            |> GeoProjection.style
                (
                    projectionType  = projectionType,
                    ?Rotation       = Rotation      ,
                    ?Parallels      = Parallels     ,
                    ?Scale          = Scale        
                )

    /// <summary>Create a function that applies the given style parameters to a GeoProjection object.</summary>
    /// <param name="projectionType">Sets the type of projection</param>
    /// <param name="Rotation">Sets the rotation applied to the map</param>
    /// <param name="Parallels">For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.</param>
    /// <param name="Scale">Zooms in or out on the map view. A scale of "1" corresponds to the largest zoom level that fits the map's lon and lat ranges.</param>
    static member style
        (   
            projectionType  : StyleParam.GeoProjectionType  ,
            [<Optional;DefaultParameterValue(null)>] ?Rotation       : GeoProjectionRotation         ,
            [<Optional;DefaultParameterValue(null)>] ?Parallels      : (float*float)                 ,
            [<Optional;DefaultParameterValue(null)>] ?Scale          : float
        ) =
            (fun (projection:GeoProjection) -> 

                projection
                
                ++ ("type", projectionType |> StyleParam.GeoProjectionType.convert )


                ++? ("parallels", Parallels       |> Option.map (fun (a,b) -> sprintf "[%f,%f]" a b) )

                ++? ("rotation", Rotation        )
                ++? ("scale", Scale           )
            ) 