namespace Plotly.NET

open DynamicObj
open System

/// An object to set the Lighting of a 3D Scene
type StreamTubeStarts() =
    inherit DynamicObj ()

    /// <summary>
    /// Initializes a TubeStarts object
    /// </summary>
    /// <param name="X">Sets the x components of the starting position of the streamtubes</param>
    /// <param name="Y">Sets the y components of the starting position of the streamtubes</param>
    /// <param name="Z">Sets the z components of the starting position of the streamtubes</param>
    static member init
        (
            ?X: seq<#IConvertible>,
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>
        ) =

            StreamTubeStarts()
            |> StreamTubeStarts.style
                (
                    ?X  = X,
                    ?Y  = Y,
                    ?Z  = Z
                )
            
    /// <summary>
    /// Creates a function that applies the given style parameters to a TubeStarts object
    /// </summary>
    /// <param name="X">Sets the x components of the starting position of the streamtubes</param>
    /// <param name="Y">Sets the y components of the starting position of the streamtubes</param>
    /// <param name="Z">Sets the z components of the starting position of the streamtubes</param>
    static member style 
        (
            ?X: seq<#IConvertible>,
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>
        ) =
            fun (streamTubeStarts: StreamTubeStarts) ->

                X   |> DynObj.setValueOpt streamTubeStarts "x"
                Y   |> DynObj.setValueOpt streamTubeStarts "y"
                Z   |> DynObj.setValueOpt streamTubeStarts "z"

                streamTubeStarts