namespace FSharp.Plotly

open System

/// Marker type inherits from dynamic object
type Marker () =
    inherit DynamicObj ()

    /// Initialized Marker object
    static member init
        (   
            ?Size           ,
            ?Color          ,
            ?Symbol         ,
            ?Opacity        ,
            ?MultiSizes     ,
            ?Line           ,
            ?Colorbar       ,
            ?Colorscale     ,
            ?Colors         ,
                            
            ?Maxdisplayed   ,
            ?Sizeref        ,
            ?Sizemin        ,
            ?Sizemode       ,
            ?Cauto          ,
            ?Cmax           ,
            ?Cmin           ,
            ?Autocolorscale ,
            ?Reversescale   ,
            ?Showscale      ,
                            
            ?Symbolsrc      ,
            ?Opacitysrc     ,
            ?Sizesrc        ,
            ?Colorsrc       ,
            ?Cutliercolor   ,
            ?Colorssrc      

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
                                        
                ?Maxdisplayed  = Maxdisplayed   ,
                ?Sizeref       = Sizeref        ,
                ?Sizemin       = Sizemin        ,
                ?Sizemode      = Sizemode       ,
                ?Cauto         = Cauto          ,
                ?Cmax          = Cmax           ,
                ?Cmin          = Cmin           ,
                ?Autocolorscale= Autocolorscale ,
                ?Reversescale  = Reversescale   ,
                ?Showscale     = Showscale      ,
                                           
                ?Symbolsrc     = Symbolsrc      ,
                ?Opacitysrc    = Opacitysrc     ,
                ?Sizesrc       = Sizesrc        ,
                ?Colorsrc      = Colorsrc       ,
                ?Cutliercolor  = Cutliercolor   ,
                ?Colorssrc     = Colorssrc      
            )

    // Applies the styles to Marker()
    static member style
        (   
            ?Size:int,
            ?Color,
            ?Symbol:StyleParam.Symbol,
            ?Opacity:float,
            ?MultiSizes:seq<#IConvertible>,
            ?Line : Line,
            ?Colorbar       ,
            ?Colorscale : StyleParam.Colorscale,
            ?Colors         ,
                            
            ?Maxdisplayed   ,
            ?Sizeref        ,
            ?Sizemin        ,
            ?Sizemode       ,
            ?Cauto          ,
            ?Cmax           ,
            ?Cmin           ,
            ?Autocolorscale ,
            ?Reversescale   ,
            ?Showscale      ,
                            
            ?Symbolsrc      ,
            ?Opacitysrc     ,
            ?Sizesrc        ,
            ?Colorsrc       ,
            ?Cutliercolor   ,
            ?Colorssrc      

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
                                                    
                Symbolsrc      |> DynObj.setValueOpt marker "symbolsrc"      
                Opacitysrc     |> DynObj.setValueOpt marker "opacitysrc"     
                Sizesrc        |> DynObj.setValueOpt marker "sizesrc"        
                Colorsrc       |> DynObj.setValueOpt marker "colorsrc"       
                Cutliercolor   |> DynObj.setValueOpt marker "outliercolor"            
                Colorssrc      |> DynObj.setValueOpt marker "colorssrc"      

                marker
            )



