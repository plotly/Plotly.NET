namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// An object to set the Lighting of a 3D Scene
type StreamTubeStarts() =
    inherit DynamicObj()

    /// <summary>
    /// Initializes a TubeStarts object
    /// </summary>
    /// <param name="X">Sets the x components of the starting position of the streamtubes</param>
    /// <param name="Y">Sets the y components of the starting position of the streamtubes</param>
    /// <param name="Z">Sets the z components of the starting position of the streamtubes</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>
        ) =

        StreamTubeStarts() |> StreamTubeStarts.style (?X = X, ?Y = Y, ?Z = Z)

    /// <summary>
    /// Creates a function that applies the given style parameters to a TubeStarts object
    /// </summary>
    /// <param name="X">Sets the x components of the starting position of the streamtubes</param>
    /// <param name="Y">Sets the y components of the starting position of the streamtubes</param>
    /// <param name="Z">Sets the z components of the starting position of the streamtubes</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>
        ) =
        fun (streamTubeStarts: StreamTubeStarts) ->

            X |> DynObj.setOptionalProperty streamTubeStarts "x"
            Y |> DynObj.setOptionalProperty streamTubeStarts "y"
            Z |> DynObj.setOptionalProperty streamTubeStarts "z"

            streamTubeStarts
