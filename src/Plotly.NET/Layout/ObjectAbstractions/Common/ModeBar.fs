namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

type ModeBar() =
    inherit DynamicObj ()

    static member init
        (    
            ?ActiveColor    : string,
            ?Add            : seq<string>,
            ?BGColor        : string,
            ?Color          : string,
            ?Orientation    : StyleParam.Orientation,
            ?Remove         : string,
            ?UIRevision     : string
        ) =    
            ModeBar()
            |> ModeBar.style
                (
                    ?ActiveColor    = ActiveColor ,
                    ?Add            = Add         ,
                    ?BGColor        = BGColor     ,
                    ?Color          = Color       ,
                    ?Orientation    = Orientation ,
                    ?Remove         = Remove      ,
                    ?UIRevision     = UIRevision  
                )

    static member style
        (    
           ?ActiveColor    : string,
           ?Add            : seq<string>,
           ?BGColor        : string,
           ?Color          : string,
           ?Orientation    : StyleParam.Orientation,
           ?Remove         : string,
           ?UIRevision     : string
        ) =
            (fun (modeBar:ModeBar) -> 
               
                ActiveColor |> DynObj.setValueOpt modeBar "activecolor"
                Add         |> DynObj.setValueOpt modeBar "add"
                BGColor     |> DynObj.setValueOpt modeBar "bgcolor"
                Color       |> DynObj.setValueOpt modeBar "color"
                Orientation |> DynObj.setValueOptBy modeBar "orientation" StyleParam.Orientation.convert
                Remove      |> DynObj.setValueOpt modeBar "remove"
                UIRevision  |> DynObj.setValueOpt modeBar "uirevision "

                modeBar
            )