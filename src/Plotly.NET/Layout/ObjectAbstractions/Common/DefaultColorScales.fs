namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

type DefaultColorScales() =
    inherit DynamicObj ()

    static member init
        (    
            ?Diverging      : StyleParam.Colorscale,
            ?Sequential     : StyleParam.Colorscale,
            ?SequentialMinus: StyleParam.Colorscale
        ) =    
            DefaultColorScales()
            |> DefaultColorScales.style
                (
                    ?Diverging      = Diverging      ,
                    ?Sequential     = Sequential     ,
                    ?SequentialMinus= SequentialMinus
                )

    static member style
        (    
            ?Diverging      : StyleParam.Colorscale,
            ?Sequential     : StyleParam.Colorscale,
            ?SequentialMinus: StyleParam.Colorscale
        ) =
            (fun (defaultColorScales:DefaultColorScales) -> 
               
                Diverging       |> DynObj.setValueOptBy defaultColorScales "diverging" StyleParam.Colorscale.convert
                Sequential      |> DynObj.setValueOptBy defaultColorScales "sequential" StyleParam.Colorscale.convert
                SequentialMinus |> DynObj.setValueOptBy defaultColorScales "sequentialminus" StyleParam.Colorscale.convert

                defaultColorScales
            )