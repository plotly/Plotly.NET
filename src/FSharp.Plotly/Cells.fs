namespace FSharp.Plotly

open System


/// Cells type inherits from dynamic object
type Cells () =
    inherit DynamicObj ()

    /// Initialized Cells object
    static member init
        (   
            Values , 
            ?Align ,
            ?Height,
            ?Fill  ,
            ?Font  ,
            ?Line   

        ) =
        Cells() 
        |> Cells.style
            (
                Values  = Values,
                ?Align  = Align ,
                ?Height = Height,
                ?Fill   = Fill  ,
                ?Font   = Font  ,
                ?Line   = Line

            )

    //Applies the styles to Cells()
    static member style
        (   
            Values : seq<#seq<#IConvertible>>       , 
            ?Align : seq<StyleParam.HorizontalAlign>,
            ?Height                                 ,
            ?Fill                                   , 
            ?Font  : Font                           ,
            ?Line  : Line 

        ) =
           (fun (cells: Cells) -> 

                Values |> DynObj.setValue      cells "values" 
                Align  |> DynObj.setValueOptBy cells "align" (Seq.map StyleParam.HorizontalAlign.convert)
                Height |> DynObj.setValueOpt   cells "height"
                Fill   |> DynObj.setValueOpt   cells "fill"
                Line   |> DynObj.setValueOpt   cells "line"     
                Font   |> DynObj.setValueOpt   cells "font"  
                cells
            )
