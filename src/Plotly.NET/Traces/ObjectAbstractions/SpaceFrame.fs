namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System

type Spaceframe () =
    inherit DynamicObj () 

    static member init 
        (
            ?Fill: float,
            ?Show: bool
        ) =
            Spaceframe()
            |> Spaceframe.style
                (
                    ?Fill       = Fill,
                    ?Show       = Show
                )

    static member style
        (
            ?Fill: float,
            ?Show: bool
        ) =

            fun (spaceframe: Spaceframe) ->
                
                Fill        |> DynObj.setValueOpt spaceframe "fill"
                Show        |> DynObj.setValueOpt spaceframe "show"

                spaceframe