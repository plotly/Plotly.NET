namespace Plotly.NET

open DynamicObj

type Title() =
    inherit DynamicObj ()

    static member init
        (    
            ?Text       : string,
            ?Font       : Font,
            ?Standoff   : int,
            ?Side       : StyleParam.Side
        ) =    
            Title()
            |> Title.style
                (
                    ?Text       = Text,
                    ?Font       = Font,
                    ?Standoff   = Standoff,
                    ?Side       = Side
                )

    static member style
        (    
            ?Text       : string,
            ?Font       : Font,
            ?Standoff   : int,
            ?Side       : StyleParam.Side
        ) =
            (fun (title:Title) -> 

                Text    |> DynObj.setValueOpt title "text"
                Font    |> DynObj.setValueOpt title "font"
                Standoff|> DynObj.setValueOpt title "standoff"
                Side    |> DynObj.setValueOpt title "side"

                title
            )
