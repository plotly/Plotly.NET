namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System

/// An object to set the Lighting of a 3D Scene
type Lighting() =
    inherit DynamicObj ()

    /// <summary>
    /// Initialize a Lighting object
    /// </summary>
    /// <param name="Ambient">Ambient light increases overall color visibility but can wash out the image.</param>
    /// <param name="Diffuse">Represents the extent that incident rays are reflected in a range of angles.</param>
    /// <param name="FaceNormalEpsilon">Epsilon for face normals calculation avoids math issues arising from degenerate geometry.</param>
    /// <param name="Fresnel">Represents the reflectance as a dependency of the viewing angle; e.g. paper is reflective when viewing it from the edge of the paper (almost 90 degrees), causing shine.</param>
    /// <param name="Roughness">Alters specular reflection; the rougher the surface, the wider and less contrasty the shine.</param>
    /// <param name="Specular">Represents the level that incident rays are reflected in a single direction, causing shine.</param>
    /// <param name="VertexNormalEpsilon">Epsilon for vertex normals calculation avoids math issues arising from degenerate geometry.</param>
    static member init
        (
            ?Ambient            : float,
            ?Diffuse            : float,
            ?FaceNormalEpsilon  : float,
            ?Fresnel            : float,
            ?Roughness          : float,
            ?Specular           : float,
            ?VertexNormalEpsilon: float
        ) =
            Lighting()
            |> Lighting.style
                (
                    ?Ambient            = Ambient            ,
                    ?Diffuse            = Diffuse            ,
                    ?FaceNormalEpsilon  = FaceNormalEpsilon  ,
                    ?Fresnel            = Fresnel            ,
                    ?Roughness          = Roughness          ,
                    ?Specular           = Specular           ,
                    ?VertexNormalEpsilon= VertexNormalEpsilon
                )

    /// <summary>
    /// Creates a function that applies the given style parameters to a Lighting object
    /// </summary>
    /// <param name="Ambient">Ambient light increases overall color visibility but can wash out the image.</param>
    /// <param name="Diffuse">Represents the extent that incident rays are reflected in a range of angles.</param>
    /// <param name="FaceNormalEpsilon">Epsilon for face normals calculation avoids math issues arising from degenerate geometry.</param>
    /// <param name="Fresnel">Represents the reflectance as a dependency of the viewing angle; e.g. paper is reflective when viewing it from the edge of the paper (almost 90 degrees), causing shine.</param>
    /// <param name="Roughness">Alters specular reflection; the rougher the surface, the wider and less contrasty the shine.</param>
    /// <param name="Specular">Represents the level that incident rays are reflected in a single direction, causing shine.</param>
    /// <param name="VertexNormalEpsilon">Epsilon for vertex normals calculation avoids math issues arising from degenerate geometry.</param>
    static member style 
        (
            ?Ambient            : float,
            ?Diffuse            : float,
            ?FaceNormalEpsilon  : float,
            ?Fresnel            : float,
            ?Roughness          : float,
            ?Specular           : float,
            ?VertexNormalEpsilon : float
        ) =
            fun (l:Lighting) ->

                Ambient             |> DynObj.setValueOpt l "ambient"
                Diffuse             |> DynObj.setValueOpt l "diffuse"
                FaceNormalEpsilon   |> DynObj.setValueOpt l "facenormalepsilon"
                Fresnel             |> DynObj.setValueOpt l "fresnel"
                Roughness           |> DynObj.setValueOpt l "roughness"
                Specular            |> DynObj.setValueOpt l "specular"
                VertexNormalEpsilon |> DynObj.setValueOpt l "vertexnormalepsilon"

                l

type LightPosition() =
    inherit DynamicObj ()

    /// <summary>
    /// Initialize a LightPosition object
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    static member init   
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =
            LightPosition()
            |> LightPosition.style
                (
                    ?X= X,
                    ?Y= Y,
                    ?Z= Z
                )

    /// <summary>
    /// Creates a function that applies the given style parameters to a LightPosition object
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    static member style
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =
            fun (lp: LightPosition) ->
                
                X |> DynObj.setValueOpt lp "x"
                Y |> DynObj.setValueOpt lp "y"
                Z |> DynObj.setValueOpt lp "z"

                lp