namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxBounds() =

    inherit DynamicObj()

    /// <summary>
    /// Returns a new MapboxBounds object with the given styles
    /// </summary>
    /// <param name="East">Sets the maximum longitude of the map (in degrees East) if `west`, `south` and `north` are declared.</param>
    /// <param name="North">Sets the maximum latitude of the map (in degrees North) if `east`, `west` and `south` are declared.</param>
    /// <param name="South">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    /// <param name="West">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?East: float,
            [<Optional; DefaultParameterValue(null)>] ?North: float,
            [<Optional; DefaultParameterValue(null)>] ?South: float,
            [<Optional; DefaultParameterValue(null)>] ?West: float
        ) =
        MapboxBounds() |> MapboxBounds.style (?East = East, ?North = North, ?South = South, ?West = West)

    /// <summary>
    /// Returns a function that applies the given styles to a MapoxBounds object.
    /// </summary>
    /// <param name="East">Sets the maximum longitude of the map (in degrees East) if `west`, `south` and `north` are declared.</param>
    /// <param name="North">Sets the maximum latitude of the map (in degrees North) if `east`, `west` and `south` are declared.</param>
    /// <param name="South">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    /// <param name="West">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?East: float,
            [<Optional; DefaultParameterValue(null)>] ?North: float,
            [<Optional; DefaultParameterValue(null)>] ?South: float,
            [<Optional; DefaultParameterValue(null)>] ?West: float
        ) =
        (fun (mapboxBounds: MapboxBounds) ->

            East |> DynObj.setValueOpt mapboxBounds "east"
            North |> DynObj.setValueOpt mapboxBounds "north"
            South |> DynObj.setValueOpt mapboxBounds "south"
            West |> DynObj.setValueOpt mapboxBounds "west"

            mapboxBounds)
