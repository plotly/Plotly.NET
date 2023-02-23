namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary>Clustering options for points on mapbox traces</summary>
type MapboxCluster() =

    inherit DynamicObj()

    /// <summary>
    /// Returns a new MapboxCluster object with the given styles
    /// </summary>
    /// <param name="Color">Sets the color for each cluster step.</param>
    /// <param name="Enabled">Determines whether clustering is enabled or disabled.</param>
    /// <param name="MaxZoom">Sets the maximum zoom level. At zoom levels equal to or greater than this, points will never be clustered.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="Size">Sets the size for each cluster step.</param>
    /// <param name="MultiSize">Sets the size for each cluster step.</param>
    /// <param name="Step">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    /// <param name="MultiStep">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Enabled: bool,
            [<Optional; DefaultParameterValue(null)>] ?MaxZoom: float,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Size: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiSize: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Step: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiStep: seq<int>
        ) =
        MapboxCluster()
        |> MapboxCluster.style (
            ?Color = Color,
            ?Enabled = Enabled,
            ?MaxZoom = MaxZoom,
            ?Opacity = Opacity,
            ?Size = Size,
            ?MultiSize = MultiSize,
            ?Step = Step,
            ?MultiStep = MultiStep
        )

    /// <summary>
    /// Returns a function that applies the given styles to a MapboxCluster object.
    /// </summary>
    /// <param name="Color">Sets the color for each cluster step.</param>
    /// <param name="Enabled">Determines whether clustering is enabled or disabled.</param>
    /// <param name="MaxZoom">Sets the maximum zoom level. At zoom levels equal to or greater than this, points will never be clustered.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="Size">Sets the size for each cluster step.</param>
    /// <param name="MultiSize">Sets the size for each cluster step.</param>
    /// <param name="Step">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    /// <param name="MultiStep">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Enabled: bool,
            [<Optional; DefaultParameterValue(null)>] ?MaxZoom: float,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Size: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiSize: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Step: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiStep: seq<int>

        ) =
        (fun (mapboxCluster: MapboxCluster) ->

            Color |> DynObj.setValueOpt mapboxCluster "color"
            Enabled |> DynObj.setValueOpt mapboxCluster "enabled"
            MaxZoom |> DynObj.setValueOpt mapboxCluster "maxzoom"
            Opacity |> DynObj.setValueOpt mapboxCluster "opacity"
            (Size, MultiSize) |> DynObj.setSingleOrMultiOpt mapboxCluster "size"
            (Step, MultiStep) |> DynObj.setSingleOrMultiOpt mapboxCluster "step"

            mapboxCluster)
