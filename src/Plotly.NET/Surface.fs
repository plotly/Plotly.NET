namespace Plotly.NET

open DynamicObj
open System

type Surface () =
    inherit DynamicObj () 

    static member init 
        (
            ?Count: int,
            ?Fill: float,
            ?Pattern: StyleParam.SurfacePattern,
            ?Show: bool
        ) =
            Surface()
            |> Surface.style
                (
                    ?Count      = Count,
                    ?Fill       = Fill,
                    ?Pattern    = Pattern,
                    ?Show       = Show
                )

    static member style
        (
            ?Count: int,
            ?Fill: float,
            ?Pattern: StyleParam.SurfacePattern,
            ?Show: bool
        ) =

            fun (surface: Surface) ->
                
                Count       |> DynObj.setValueOpt surface "count"
                Fill        |> DynObj.setValueOpt surface "fill"
                Pattern     |> DynObj.setValueOptBy surface "pattern" StyleParam.SurfacePattern.convert
                Show        |> DynObj.setValueOpt surface "show"

                surface