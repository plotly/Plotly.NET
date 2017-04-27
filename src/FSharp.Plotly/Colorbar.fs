namespace FSharp.Plotly

open System

/// Colorbar type inherits from dynamic object
type Colorbar () =
    inherit DynamicObj ()
       
    /// Initialized Colorbar object
    //[<CompiledName("init")>]
    static member init
        (   
            ?Thicknessmode,  
            ?Thickness,      
            ?Lenmode,        
            ?Len,            
            ?X,              
            ?Xanchor,
            ?Xpad,           
            ?Y,              
            ?Yanchor,        
            ?Ypad,           
            ?Outlinecolor,   
            ?Outlinewidth,   
            ?Bordercolor,    
            ?Borderwidth,    
            ?Bgcolor,        
            ?Tickmode,       
            ?nTicks,         
            ?Tick0,          
            ?dTick,          
            ?Tickvals,       
            ?Ticktext,       
            ?Ticks,          
            ?Ticklen,        
            ?Tickwidth,      
            ?Tickcolor,      
            ?Showticklabels, 
            ?Tickfont,       
            ?Tickangle,      
            ?Tickformat,     
            ?Tickprefix,     
            ?Showtickprefix, 
            ?Ticksuffix,     
            ?Showticksuffix, 
            ?Exponentformat, 
            ?Showexponent,   
            ?Title,          
            ?Titlefont,      
            ?Titleside,      
            ?Tickvalssrc,
            ?Ticktextsrc    

        ) = 
            Colorbar()
            |> Colorbar.style
                (   
                    ?Thicknessmode  = Thicknessmode ,  
                    ?Thickness      = Thickness     ,      
                    ?Lenmode        = Lenmode       ,        
                    ?Len            = Len           ,            
                    ?X              = X             ,              
                    ?Xanchor        = Xanchor       ,
                    ?Xpad           = Xpad          ,           
                    ?Y              = Y             ,              
                    ?Yanchor        = Yanchor       ,        
                    ?Ypad           = Ypad          ,           
                    ?Outlinecolor   = Outlinecolor  ,   
                    ?Outlinewidth   = Outlinewidth  ,   
                    ?Bordercolor    = Bordercolor   ,    
                    ?Borderwidth    = Borderwidth   ,    
                    ?Bgcolor        = Bgcolor       ,        
                    ?Tickmode       = Tickmode      ,       
                    ?nTicks         = nTicks        ,         
                    ?Tick0          = Tick0         ,          
                    ?dTick          = dTick         ,          
                    ?Tickvals       = Tickvals      ,       
                    ?Ticktext       = Ticktext      ,       
                    ?Ticks          = Ticks         ,          
                    ?Ticklen        = Ticklen       ,        
                    ?Tickwidth      = Tickwidth     ,      
                    ?Tickcolor      = Tickcolor     ,      
                    ?Showticklabels = Showticklabels, 
                    ?Tickfont       = Tickfont      ,       
                    ?Tickangle      = Tickangle     ,      
                    ?Tickformat     = Tickformat    ,     
                    ?Tickprefix     = Tickprefix    ,     
                    ?Showtickprefix = Showtickprefix, 
                    ?Ticksuffix     = Ticksuffix    ,     
                    ?Showticksuffix = Showticksuffix, 
                    ?Exponentformat = Exponentformat, 
                    ?Showexponent   = Showexponent  ,   
                    ?Title          = Title         ,          
                    ?Titlefont      = Titlefont     ,      
                    ?Titleside      = Titleside     ,      
                    ?Tickvalssrc    = Tickvalssrc   ,
                    ?Ticktextsrc    = Ticktextsrc    

                )


    /// Applies the styles to Lighting()
    //[<CompiledName("style")>]
    static member style
        (   
            ?Thicknessmode,  
            ?Thickness,      
            ?Lenmode,        
            ?Len,            
            ?X,              
            ?Xanchor,
            ?Xpad,           
            ?Y,              
            ?Yanchor,        
            ?Ypad,           
            ?Outlinecolor,   
            ?Outlinewidth,   
            ?Bordercolor,    
            ?Borderwidth,    
            ?Bgcolor,        
            ?Tickmode,       
            ?nTicks,         
            ?Tick0,          
            ?dTick,          
            ?Tickvals,       
            ?Ticktext,       
            ?Ticks,          
            ?Ticklen,        
            ?Tickwidth,      
            ?Tickcolor,      
            ?Showticklabels, 
            ?Tickfont,       
            ?Tickangle,      
            ?Tickformat,     
            ?Tickprefix,     
            ?Showtickprefix, 
            ?Ticksuffix,     
            ?Showticksuffix, 
            ?Exponentformat, 
            ?Showexponent,   
            ?Title,          
            ?Titlefont,      
            ?Titleside,      
            ?Tickvalssrc,
            ?Ticktextsrc    

        ) =
                
            (fun (colorbar:Colorbar) ->            
                Thicknessmode  |> DynObj.setValueOpt colorbar "thicknessmode" 
                Thickness      |> DynObj.setValueOpt colorbar "thickness"      
                Lenmode        |> DynObj.setValueOpt colorbar "lenmode"        
                Len            |> DynObj.setValueOpt colorbar "len"            
                X              |> DynObj.setValueOpt colorbar "x"              
                Xanchor        |> DynObj.setValueOpt colorbar "xanchor"        
                Xpad           |> DynObj.setValueOpt colorbar "xpad"           
                Y              |> DynObj.setValueOpt colorbar "y"              
                Yanchor        |> DynObj.setValueOpt colorbar "yanchor"        
                Ypad           |> DynObj.setValueOpt colorbar "ypad"           
                Outlinecolor   |> DynObj.setValueOpt colorbar "outlinecolor"   
                Outlinewidth   |> DynObj.setValueOpt colorbar "outlinewidth"   
                Bordercolor    |> DynObj.setValueOpt colorbar "bordercolor"    
                Borderwidth    |> DynObj.setValueOpt colorbar "borderwidth"    
                Bgcolor        |> DynObj.setValueOpt colorbar "bgcolor"        
                Tickmode       |> DynObj.setValueOpt colorbar "tickmode"       
                nTicks         |> DynObj.setValueOpt colorbar "nticks"         
                Tick0          |> DynObj.setValueOpt colorbar "tick0"          
                dTick          |> DynObj.setValueOpt colorbar "dtick"          
                Tickvals       |> DynObj.setValueOpt colorbar "tickvals"       
                Ticktext       |> DynObj.setValueOpt colorbar "ticktext"       
                Ticks          |> DynObj.setValueOpt colorbar "ticks"          
                Ticklen        |> DynObj.setValueOpt colorbar "ticklen"        
                Tickwidth      |> DynObj.setValueOpt colorbar "tickwidth"      
                Tickcolor      |> DynObj.setValueOpt colorbar "tickcolor"      
                Showticklabels |> DynObj.setValueOpt colorbar "showticklabels" 
                Tickfont       |> DynObj.setValueOpt colorbar "tickfont"       
                Tickangle      |> DynObj.setValueOpt colorbar "tickangle"      
                Tickformat     |> DynObj.setValueOpt colorbar "tickformat"     
                Tickprefix     |> DynObj.setValueOpt colorbar "tickprefix"     
                Showtickprefix |> DynObj.setValueOpt colorbar "showtickprefix" 
                Ticksuffix     |> DynObj.setValueOpt colorbar "ticksuffix"     
                Showticksuffix |> DynObj.setValueOpt colorbar "showticksuffix" 
                Exponentformat |> DynObj.setValueOpt colorbar "exponentformat" 
                Showexponent   |> DynObj.setValueOpt colorbar "showexponent"   
                Title          |> DynObj.setValueOpt colorbar "title"          
                Titlefont      |> DynObj.setValueOpt colorbar "titlefont"      
                Titleside      |> DynObj.setValueOpt colorbar "titleside"      
                Tickvalssrc    |> DynObj.setValueOpt colorbar "tickvalssrc"    
                Ticktextsrc    |> DynObj.setValueOpt colorbar "ticktextsrc"         

                colorbar
            )


//[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
//module Colorbar = 
//
//    let initColorbar (applyStyle:Colorbar->Colorbar) = 
//        Colorbar() |> applyStyle
//
//
//    /// Functions provide the styling of the Colorbar object
//    type ColorbarStyle() =


