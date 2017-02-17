namespace FSharp.Plotly

/// Module containing plotly Bins 
module Bins =

    /// Bin type inherits from dynamic object
    type Bins () =
        inherit DynamicObj ()

    type BinsStyle = 

        // Applies the styles to Bins()
        static member BinsStyle
            (
                ?StartBins:float,
                ?EndBins:float,
                ?Size
            ) =
            
                (fun (bins:('T :> Bins)) -> 
                    StartBins |> DynObj.setValueOpt bins "start"
                    EndBins   |> DynObj.setValueOpt bins "end"
                    Size      |> DynObj.setValueOpt bins "size"
           
                    bins
                )