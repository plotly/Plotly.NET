namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type ProjectionDimension () =
    inherit DynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Opacity    : float,
            [<Optional;DefaultParameterValue(null)>] ?Scale      : float,
            [<Optional;DefaultParameterValue(null)>] ?Show       : bool
        ) =
            ProjectionDimension()
            |> ProjectionDimension.style
                (
                    ?Opacity    = Opacity,
                    ?Scale      = Scale  ,
                    ?Show       = Show   
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Opacity    : float,
            [<Optional;DefaultParameterValue(null)>] ?Scale      : float,
            [<Optional;DefaultParameterValue(null)>] ?Show       : bool
        ) =

            fun (projectionDimension: ProjectionDimension) ->
                
                ++? ("opacity", Opacity )
                ++? ("scale", Scale   )
                ++? ("show", Show    )

                projectionDimension

type Projection () =
    inherit DynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?X: ProjectionDimension,
            [<Optional;DefaultParameterValue(null)>] ?Y: ProjectionDimension,
            [<Optional;DefaultParameterValue(null)>] ?Z: ProjectionDimension
        ) =
            Projection()
            |> Projection.style
                (
                    ?X = X,
                    ?Y = Y,
                    ?Z = Z
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?X: ProjectionDimension,
            [<Optional;DefaultParameterValue(null)>] ?Y: ProjectionDimension,
            [<Optional;DefaultParameterValue(null)>] ?Z: ProjectionDimension
        ) =

            fun (projection: Projection) ->
                
                ++? ("x", X   )
                ++? ("y", Y   )
                ++? ("z", Z   )

                projection