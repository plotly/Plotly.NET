namespace Plotly.NET.LayoutObjects

open DynamicObj

/// Margin 
type Margin() = 
    inherit DynamicObj ()

    /// Init Margin type
    static member init
        (
            ?Left   ,
            ?Right  ,
            ?Top    ,
            ?Bottom ,
            ?Pad    ,
            ?Autoexpand
        ) =
            Margin()
            |> Margin.style
                (
                    ?Left       = Left       ,
                    ?Right      = Right      ,
                    ?Top        = Top        ,
                    ?Bottom     = Bottom     ,
                    ?Pad        = Pad        ,
                    ?Autoexpand = Autoexpand                
                )


    // Applies the styles to Margin()
    static member style
        (
            ?Left   ,
            ?Right  ,
            ?Top    ,
            ?Bottom ,
            ?Pad    ,
            ?Autoexpand
        ) =
            (fun (margin:Margin) -> 
                Left   |> DynObj.setValueOpt margin "l"
                Right  |> DynObj.setValueOpt margin "r"
                Top    |> DynObj.setValueOpt margin "t"
                Bottom |> DynObj.setValueOpt margin "b"

                Pad        |> DynObj.setValueOpt margin "pad"
                Autoexpand |> DynObj.setValueOpt margin "autoexpand"

                margin
                )