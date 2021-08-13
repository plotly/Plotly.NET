namespace Plotly.NET

open DynamicObj

type Title() =
    inherit DynamicObj ()

    static member init
        (    
            ?Text       :  string,
            ?Font       :  Font,
            ?Standoff   : int
        ) =    
            Title()
            |> Title.style
                (
                    ?Text       = Text,
                    ?Font       = Font,
                    ?Standoff   = Standoff
                )

    static member style
        (    
            ?Text       :  string,
            ?Font       :  Font,
            ?Standoff   : int
        ) =
            (fun (title:Title) -> 

                Text    |> DynObj.setValueOpt title "text"
                Font    |> DynObj.setValueOpt title "font"
                Standoff|> DynObj.setValueOpt title "standoff"

                title
            )
