namespace Plotly.NET

open DynamicObj
open System.Runtime.InteropServices

type Padding() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Padding object with the given styling. Set the padding of the component along each side
    /// </summary>
    /// <param name="B">The amount of padding (in px) along the bottom of the component</param>
    /// <param name="L">The amount of padding (in px) on the left side of the component</param>
    /// <param name="R">The amount of padding (in px) on the right side of the component</param>
    /// <param name="T">The amount of padding (in px) along the top of the component</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?B: int,
            [<Optional; DefaultParameterValue(null)>] ?L: int,
            [<Optional; DefaultParameterValue(null)>] ?R: int,
            [<Optional; DefaultParameterValue(null)>] ?T: int
        ) =
        Padding() |> Padding.style (?B = B, ?L = L, ?R = R, ?T = T)

    /// <summary>
    /// Returns a function that applies the given styles to a Padding object. Set the padding of the component along each side
    /// </summary>
    /// <param name="B">The amount of padding (in px) along the bottom of the component</param>
    /// <param name="L">The amount of padding (in px) on the left side of the component</param>
    /// <param name="R">The amount of padding (in px) on the right side of the component</param>
    /// <param name="T">The amount of padding (in px) along the top of the component</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?B: int,
            [<Optional; DefaultParameterValue(null)>] ?L: int,
            [<Optional; DefaultParameterValue(null)>] ?R: int,
            [<Optional; DefaultParameterValue(null)>] ?T: int
        ) =
        (fun (padding: Padding) ->
            B |> DynObj.setValueOpt padding "b"
            L |> DynObj.setValueOpt padding "l"
            R |> DynObj.setValueOpt padding "r"
            T |> DynObj.setValueOpt padding "t"
            padding)
