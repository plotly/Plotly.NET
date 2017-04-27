namespace FSharp.Plotly


/// Error type inherits from dynamic object
type Error () =
    inherit DynamicObj ()

//    /// Init Error type
//    static member init (applyStyle:Error->Error) = 
//        Error() |> applyStyle
    
    /// Init Error type
    static member init
        (   
            ?Symmetric,
            ?Array,
            ?Arrayminus,
            ?Value,
            ?Valueminus,
            ?Traceref,
            ?Tracerefminus,
            ?Copy_ystyle,
            ?Copy_zstyle,
            ?Color,
            ?Thickness,
            ?Width,
            ?Arraysrc,
            ?Arrayminussrc
        ) =
            Error() 
            |> Error.style
                (   
                   ?Symmetric     =  Symmetric     ,
                   ?Array         =  Array         ,
                   ?Arrayminus    =  Arrayminus    ,
                   ?Value         =  Value         ,
                   ?Valueminus    =  Valueminus    ,
                   ?Traceref      =  Traceref      ,
                   ?Tracerefminus =  Tracerefminus ,
                   ?Copy_ystyle   =  Copy_ystyle   ,
                   ?Copy_zstyle   =  Copy_zstyle   ,
                   ?Color         =  Color         ,
                   ?Thickness     =  Thickness     ,
                   ?Width         =  Width         ,
                   ?Arraysrc      =  Arraysrc      ,
                   ?Arrayminussrc = Arrayminussrc
                )

    // Applies the styles to Error()
    static member style
        (   
            ?Symmetric,
            ?Array,
            ?Arrayminus,
            ?Value,
            ?Valueminus,
            ?Traceref,
            ?Tracerefminus,
            ?Copy_ystyle,
            ?Copy_zstyle,
            ?Color,
            ?Thickness,
            ?Width,
            ?Arraysrc,
            ?Arrayminussrc
        ) =
            (fun (error:Error) -> 
                Symmetric     |> DynObj.setValueOpt error "symmetric"
                Array         |> DynObj.setValueOpt error "array"
                Arrayminus    |> DynObj.setValueOpt error "arrayminus"
                Value         |> DynObj.setValueOpt error "value"
                Valueminus    |> DynObj.setValueOpt error "valueminus"
                Traceref      |> DynObj.setValueOpt error "traceref"
                Tracerefminus |> DynObj.setValueOpt error "tracerefminus"
                Copy_ystyle   |> DynObj.setValueOpt error "copy_ystyle"
                Copy_zstyle   |> DynObj.setValueOpt error "copy_zstyle"
                Color         |> DynObj.setValueOpt error "color"
                Thickness     |> DynObj.setValueOpt error "thickness"
                Width         |> DynObj.setValueOpt error "width"
                Arraysrc      |> DynObj.setValueOpt error "arraysrc"
                Arrayminussrc |> DynObj.setValueOpt error "arrayminussrc"

                // out ->
                error
            )
    
 
            