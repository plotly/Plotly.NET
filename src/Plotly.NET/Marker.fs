namespace Plotly.NET

open DynamicObj
open System

/// Marker type inherits from dynamic object
type Marker () =
    inherit DynamicObj ()

    /// Initialized Marker object
    static member init
        (   
            ?Size: int,
            ?Opacity: float,
            ?Color: string,
            ?Symbol: StyleParam.Symbol,
            ?MultiSizes: seq<#IConvertible>,
            ?Line: Line,
            ?Colorbar: Colorbar,
            ?Colorscale : StyleParam.Colorscale,
            ?Colors: seq<string>,
            ?OutlierColor:string,
                            
            ?Maxdisplayed: int,
            ?Sizeref: float,
            ?Sizemin: float,
            ?Sizemode: StyleParam.SizeMode,
            ?Cauto: bool,
            ?Cmax: float,
            ?Cmin: float,
            ?Cmid: float,
            ?Autocolorscale: bool,
            ?Reversescale: bool,
            ?Showscale: bool

        ) =
        Marker () 
        |> Marker.style
            (
                ?Size          = Size           ,
                ?Color         = Color          ,
                ?Symbol        = Symbol         ,
                ?Opacity       = Opacity        ,
                ?MultiSizes    = MultiSizes     ,
                ?Line          = Line           ,
                ?Colorbar      = Colorbar       ,
                ?Colorscale    = Colorscale     ,
                ?Colors        = Colors         ,
                ?OutlierColor  = OutlierColor   ,
                                        
                ?Maxdisplayed  = Maxdisplayed   ,
                ?Sizeref       = Sizeref        ,
                ?Sizemin       = Sizemin        ,
                ?Sizemode      = Sizemode       ,
                ?Cauto         = Cauto          ,
                ?Cmax          = Cmax           ,
                ?Cmin          = Cmin           ,
                ?Autocolorscale= Autocolorscale ,
                ?Reversescale  = Reversescale   ,
                ?Showscale     = Showscale      

            )

    // Applies the styles to Marker()
    static member style
        (   
            ?Size: int,
            ?Opacity: float,
            ?Color: string,
            ?Symbol: StyleParam.Symbol,
            ?MultiSizes: seq<#IConvertible>,
            ?Line: Line,
            ?Colorbar: Colorbar,
            ?Colorscale : StyleParam.Colorscale,
            ?Colors: seq<string>,
            ?OutlierColor:string,
                            
            ?Maxdisplayed: int,
            ?Sizeref: float,
            ?Sizemin: float,
            ?Sizemode: StyleParam.SizeMode,
            ?Cauto: bool,
            ?Cmax: float,
            ?Cmin: float,
            ?Cmid: float,
            ?Autocolorscale: bool,
            ?Reversescale: bool,
            ?Showscale: bool
        ) =
            (fun (marker: Marker) -> 
                Size           |> DynObj.setValueOpt marker "size" 
                Color          |> DynObj.setValueOpt marker "color"
                Symbol         |> DynObj.setValueOpt marker "symbol"
                Opacity        |> DynObj.setValueOpt marker "opacity"
                MultiSizes     |> DynObj.setValueOpt marker "size"
                Line           |> DynObj.setValueOpt marker "line"        
                Colorbar       |> DynObj.setValueOpt marker "colorbar"       
                Colorscale     |> DynObj.setValueOptBy marker "colorscale" StyleParam.Colorscale.convert
                Colors         |> DynObj.setValueOpt marker "colors"     
                OutlierColor   |> DynObj.setValueOpt marker "outliercolor"     
                                                
                Maxdisplayed   |> DynObj.setValueOpt marker "maxdisplayed"   
                Sizeref        |> DynObj.setValueOpt marker "sizeref"        
                Sizemin        |> DynObj.setValueOpt marker "sizemin"        
                Sizemode       |> DynObj.setValueOpt marker "sizemode"            
                Cauto          |> DynObj.setValueOpt marker "cauto"          
                Cmax           |> DynObj.setValueOpt marker "cmax"           
                Cmin           |> DynObj.setValueOpt marker "cmin"           
                Autocolorscale |> DynObj.setValueOpt marker "autocolorscale" 
                Reversescale   |> DynObj.setValueOpt marker "reversescale"   
                Showscale      |> DynObj.setValueOpt marker "showscale"      

                marker
            )



