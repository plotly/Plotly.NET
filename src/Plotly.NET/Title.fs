namespace Plotly.NET

type Title() =
    inherit DynamicObj ()

    static member init
        (    
            ?Text:  string,
            ?Font:  Font
        ) =    
            Title()
            |> Title.style
                (
                    ?Text   = Text,
                    ?Font   = Font
                )

    static member style
        (    
            ?Text:  string,
            ?Font:  Font
        ) =
            (fun (title:Title) -> 

                Text    |> DynObj.setValueOpt title "text"
                Font    |> DynObj.setValueOpt title "font"

                title
            )
