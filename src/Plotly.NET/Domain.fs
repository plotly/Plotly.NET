namespace Plotly.NET

open System


/// Dimensions type inherits from dynamic object
type Domain () =
    inherit DynamicObj ()

    /// Initialized Dimensions object
    static member init
        (
            ?X      : StyleParam.Range,
            ?Y      : StyleParam.Range,
            ?Row    : int,
            ?Column : int
        ) =
            Domain () 
            |> Domain.style
                (
                    ?X      = X,   
                    ?Y      = Y,   
                    ?Row    = Row,
                    ?Column = Column
                )


    // Applies the styles to Dimensions()
    static member style
        (
            ?X      : StyleParam.Range,
            ?Y      : StyleParam.Range,
            ?Row    : int,
            ?Column : int
        ) =
            (fun (dom:Domain) -> 
                X       |> DynObj.setValueOptBy dom "x" StyleParam.Range.convert
                Y       |> DynObj.setValueOptBy dom "y" StyleParam.Range.convert                
                Row     |> DynObj.setValueOpt   dom "row"                 
                Column  |> DynObj.setValueOpt   dom "column"
               
                // out -> 
                dom
            )