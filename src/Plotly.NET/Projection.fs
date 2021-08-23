namespace Plotly.NET

open DynamicObj
open System


type ProjectionDimension () =
    inherit DynamicObj () 

    static member init 
        (
            ?Opacity    : float,
            ?Scale      : float,
            ?Show       : bool
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
            ?Opacity    : float,
            ?Scale      : float,
            ?Show       : bool
        ) =

            fun (projectionDimension: ProjectionDimension) ->
                
                Opacity |> DynObj.setValueOpt projectionDimension "opacity"
                Scale   |> DynObj.setValueOpt projectionDimension "scale"
                Show    |> DynObj.setValueOpt projectionDimension "show"

                projectionDimension

type Projection () =
    inherit DynamicObj () 

    static member init 
        (
            ?X: ProjectionDimension,
            ?Y: ProjectionDimension,
            ?Z: ProjectionDimension
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
            ?X: ProjectionDimension,
            ?Y: ProjectionDimension,
            ?Z: ProjectionDimension
        ) =

            fun (projection: Projection) ->
                
                X   |> DynObj.setValueOpt projection "x"
                Y   |> DynObj.setValueOpt projection "y"
                Z   |> DynObj.setValueOpt projection "z"

                projection