namespace Plotly.NET
open System.Runtime.InteropServices

open DynamicObj

type Title() =
    inherit DynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?Text       : string,
            [<Optional;DefaultParameterValue(null)>] ?Font       : Font,
            [<Optional;DefaultParameterValue(null)>] ?Standoff   : int,
            [<Optional;DefaultParameterValue(null)>] ?Side       : StyleParam.Side
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
            [<Optional;DefaultParameterValue(null)>] ?Text       : string,
            [<Optional;DefaultParameterValue(null)>] ?Font       : Font,
            [<Optional;DefaultParameterValue(null)>] ?Standoff   : int,
            [<Optional;DefaultParameterValue(null)>] ?Side       : StyleParam.Side
        ) =
            (fun (title:Title) -> 

                Text    |> DynObj.setValueOpt title "text"
                Font    |> DynObj.setValueOpt title "font"
                Standoff|> DynObj.setValueOpt title "standoff"
                Side    |> DynObj.setValueOpt title "side"

                title
            )
