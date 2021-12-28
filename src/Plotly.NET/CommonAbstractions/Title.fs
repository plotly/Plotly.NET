﻿namespace Plotly.NET

open System.Runtime.InteropServices

open DynamicObj
open DynamicObj.Operators

type Title() =
    inherit ImmutableDynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Standoff: int,
            [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.Side,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float
        ) =
        Title() |> Title.style (?Text = Text, ?Font = Font, ?Standoff = Standoff, ?Side = Side, ?X = X, ?Y = Y)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Standoff: int,
            [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.Side,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float
        ) =
        (fun (title: Title) ->

            title

            ++? ("text", Text )
            ++? ("font", Font )
            ++? ("standoff", Standoff )
            ++? ("side", Side )
            ++? ("x", X )
            ++? ("y", Y ))
