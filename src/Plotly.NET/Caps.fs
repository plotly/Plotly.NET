namespace Plotly.NET

open DynamicObj
open System

type CapFill () =
    inherit DynamicObj () 

    static member init 
        (
            ?Fill: float,
            ?Show: bool
        ) =
            CapFill()
            |> CapFill.style
                (
                    ?Fill = Fill,
                    ?Show = Show
                )

    static member style
        (
            ?Fill: float,
            ?Show: bool
        ) =

            fun (capFill: CapFill) ->
                
                Fill |> DynObj.setValueOpt capFill "fill"
                Show |> DynObj.setValueOpt capFill "show"


type Caps() =
    inherit DynamicObj ()

    static member init
        (
            ?X: CapFill,
            ?Y: CapFill,
            ?Z: CapFill
        ) =

            Caps()
            |> Caps.style
                (
                    ?X  = X,
                    ?Y  = Y,
                    ?Z  = Z
                )
            
    static member style 
        (
            ?X: CapFill,
            ?Y: CapFill,
            ?Z: CapFill
        ) =
            fun (caps: Caps) ->

                X   |> DynObj.setValueOpt caps "x"
                Y   |> DynObj.setValueOpt caps "y"
                Z   |> DynObj.setValueOpt caps "z"

                caps