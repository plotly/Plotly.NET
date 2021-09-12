namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// Bin type inherits from dynamic object
type Bins () =
    inherit ImmutableDynamicObj ()

    // Init Bins()
    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?StartBins: float,
            [<Optional;DefaultParameterValue(null)>] ?EndBins: float,
            [<Optional;DefaultParameterValue(null)>] ?Size: float
        ) =
            Bins () 
            |> Bins.style
                (
                    ?StartBins = StartBins,
                    ?EndBins   = EndBins  ,
                    ?Size      = Size           
                )


    // Applies the styles to Bins()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?StartBins: float,
            [<Optional;DefaultParameterValue(null)>] ?EndBins: float,
            [<Optional;DefaultParameterValue(null)>] ?Size: float
        ) =
            
            (fun (bins:Bins) -> 
           
                bins
                ++? ("start", StartBins)
                ++? ("end", EndBins)
                ++? ("size", Size)
            )


