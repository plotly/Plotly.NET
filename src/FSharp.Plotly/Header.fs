namespace FSharp.Plotly

open System

/// Header type inherits from dynamic object
type Header () =
    inherit DynamicObj ()

    /// Initialized Header object
    static member init
        (   
            Values , 
            ?Align ,
            ?Height,
            ?Fill  ,
            ?Font  ,
            ?Line

        ) =
        Header() 
        |> Header.style
            (
                Values  = Values,
                ?Align  = Align ,
                ?Height = Height,
                ?Fill   = Fill  ,
                ?Font   = Font  ,
                ?Line   = Line

            )

    /// Applies the styles to Header()
    static member style
        (   
            Values : seq<#seq<#IConvertible>>       , 
            ?Align : seq<StyleParam.HorizontalAlign>,
            ?Height                                 ,
            ?Fill                                   ,
            ?Font  : Font                           ,
            ?Line  : Line 

        ) =
            (fun (header: Header) -> 

                Values |> DynObj.setValue      header "values" 
                Align  |> DynObj.setValueOptBy header "align" (Seq.map StyleParam.HorizontalAlign.convert)
                Height |> DynObj.setValueOpt   header "height"
                Fill   |> DynObj.setValueOpt   header "fill" 
                Line   |> DynObj.setValueOpt   header "line"    
                Font   |> DynObj.setValueOpt   header "font"
                header
            )