namespace Plotly.NET


/// Bin type inherits from dynamic object
type Bins () =
    inherit DynamicObj ()

    // Init Bins()
    static member init
        (
            ?StartBins: float,
            ?EndBins: float,
            ?Size: float
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
            ?StartBins: float,
            ?EndBins: float,
            ?Size: float
        ) =
            
            (fun (bins:Bins) -> 
                StartBins |> DynObj.setValueOpt bins "start"
                EndBins   |> DynObj.setValueOpt bins "end"
                Size      |> DynObj.setValueOpt bins "size"
           
                bins
            )


