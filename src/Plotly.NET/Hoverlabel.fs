namespace Plotly.NET

open System


/// Hoverlabel type inherits from dynamic object
type Hoverlabel () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?BgColor: string,
            ?BorderColor: string,
            ?Font: Font,
            ?Align: StyleParam.Align,
            ?Namelength: int
        ) =
            Hoverlabel () 
            |> Hoverlabel.style
                (
                    ?BgColor     = BgColor,
                    ?BorderColor = BorderColor,
                    ?Font        = Font,
                    ?Align       = Align,
                    ?Namelength  = Namelength
                )


    // Applies the styles to Line()
    static member style
        (
            ?BgColor: string,
            ?BorderColor: string,
            ?Font: Font,
            ?Align: StyleParam.Align,
            ?Namelength: int
        ) =
            (fun (label:Hoverlabel) -> 
                BgColor       |> DynObj.setValueOpt   label "bgcolor"
                BorderColor   |> DynObj.setValueOpt   label "bordercolor"
                Font          |> DynObj.setValueOpt   label "font" 
                Align         |> DynObj.setValueOptBy label "align" StyleParam.Align.convert
                Namelength    |> DynObj.setValueOpt   label "namelength" 
                    
                // out -> 
                label
            )



               