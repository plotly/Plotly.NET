namespace FSharp.Plotly


/// Bin type inherits from dynamic object
type Bins () =
    inherit DynamicObj ()

    // Init Bins()
    static member init
        (
            ?StartBins ,
            ?EndBins   ,
            ?Size
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
            ?StartBins:float,
            ?EndBins  :float,
            ?Size
        ) =
            
            (fun (bins:('T :> Bins)) -> 
                StartBins |> DynObj.setValueOpt bins "start"
                EndBins   |> DynObj.setValueOpt bins "end"
                Size      |> DynObj.setValueOpt bins "size"
           
                bins
            )


