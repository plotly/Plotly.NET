namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
OHNONONO
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

                surface
                
                ++? ("count", Count       )
                ++? ("fill", Fill        )
                ++?? ("pattern", Pattern     , StyleParam.SurfacePattern.convert)
                ++? ("show", Show        )