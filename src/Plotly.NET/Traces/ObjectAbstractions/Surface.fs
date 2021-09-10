namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Surface () =
    inherit ImmutableDynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Count: int,
            [<Optional;DefaultParameterValue(null)>] ?Fill: float,
            [<Optional;DefaultParameterValue(null)>] ?Pattern: StyleParam.SurfacePattern,
            [<Optional;DefaultParameterValue(null)>] ?Show: bool
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
            [<Optional;DefaultParameterValue(null)>] ?Count: int,
            [<Optional;DefaultParameterValue(null)>] ?Fill: float,
            [<Optional;DefaultParameterValue(null)>] ?Pattern: StyleParam.SurfacePattern,
            [<Optional;DefaultParameterValue(null)>] ?Show: bool
        ) =

            fun (surface: Surface) ->
                
                Count       |> DynObj.setValueOpt surface "count"
                Fill        |> DynObj.setValueOpt surface "fill"
                Pattern     |> DynObj.setValueOptBy surface "pattern" StyleParam.SurfacePattern.convert
                Show        |> DynObj.setValueOpt surface "show"

                surface