namespace FSharp.Plotly

/// Module containing plotly axis 
module Axis =

    /// LinearAxis type inherits from dynamic object
    type LinearAxis () =
        inherit DynamicObj ()

        /// Init LinearAxis type
        static member init (applyStyle:LinearAxis->LinearAxis) =
            LinearAxis() |> applyStyle

        // Applies the styles to LinearAxis()
        static member LinearAxis
            (
                ?AxisType, 
                ?Title,            
                ?Titlefont:Font,                             
                ?Autorange,        
                ?Rangemode,        
                ?Range,            
                ?Fixedrange,       
                ?Tickmode,         
                ?nTicks,           
                ?Tick0,            
                ?dTick,            
                ?Tickvals,         
                ?Ticktext,         
                ?Ticks,            
                ?Mirror,           
                ?Ticklen,          
                ?Tickwidth,        
                ?Tickcolor,        
                ?Showticklabels,   
                ?Tickfont:Font,         
                ?Tickangle,        
                ?Tickprefix,       
                ?Showtickprefix,   
                ?Ticksuffix,       
                ?Showticksuffix,   
                ?Showexponent,     
                ?Exponentformat,   
                ?Tickformat,       
                ?Hoverformat,      
                ?Showline,         
                ?Linecolor,        
                ?Linewidth,        
                ?Showgrid,         
                ?Gridcolor,        
                ?Gridwidth,        
                ?Zeroline,         
                ?Zerolinecolor,    
                ?Zerolinewidth,    
                ?Anchor,           
                ?Side,             
                ?Overlaying,       
                ?Domain,           
                ?Position,         
                ?IsSubplotObj,    
                ?Tickvalssrc,      
                ?Ticktextsrc,      
                ?Showspikes,       
                ?Spikesides,       
                ?Spikethickness,   
                ?Spikecolor,       
                ?Showbackground,   
                ?Backgroundcolor,  
                ?Showaxeslabels       
            ) =
                (fun (axis:LinearAxis) -> 
                    AxisType        |> DynObj.setValueOptBy axis "type" StyleParam.AxisType.convert
                    Title           |> DynObj.setValueOpt   axis "title"                 
                    
                    Autorange       |> DynObj.setValueOptBy axis "autorange" StyleParam.AutoRange.convert
                    Rangemode       |> DynObj.setValueOptBy axis "rangemode" StyleParam.RangeMode.convert
                    Range           |> DynObj.setValueOptBy axis "range"     StyleParam.RangeValues.convert       
                    Fixedrange      |> DynObj.setValueOpt   axis "fixedrange"      
                    Tickmode        |> DynObj.setValueOptBy axis "tickmode"  StyleParam.TickMode.convert
                    nTicks          |> DynObj.setValueOpt   axis "nticks"          
                    Tick0           |> DynObj.setValueOpt   axis "tick0"           
                    dTick           |> DynObj.setValueOpt   axis "dtick"           
                    Tickvals        |> DynObj.setValueOpt   axis "tickvals"        
                    Ticktext        |> DynObj.setValueOpt   axis "ticktext"        
                    Ticks           |> DynObj.setValueOptBy axis "ticks"     StyleParam.TickOptions.convert
                    Mirror          |> DynObj.setValueOptBy axis "mirror"    StyleParam.Mirror.convert
                    Ticklen         |> DynObj.setValueOpt   axis "ticklen"         
                    Tickwidth       |> DynObj.setValueOpt   axis "tickwidth"       
                    Tickcolor       |> DynObj.setValueOpt   axis "tickcolor"       
                    Showticklabels  |> DynObj.setValueOpt   axis "showticklabels"             

                    Tickangle       |> DynObj.setValueOpt   axis "tickangle"       
                    Tickprefix      |> DynObj.setValueOpt   axis "tickprefix"      
                    Showtickprefix  |> DynObj.setValueOptBy axis "showtickprefix" StyleParam.ShowTickOption.convert
                    Ticksuffix      |> DynObj.setValueOpt   axis "ticksuffix"   
                    Showticksuffix  |> DynObj.setValueOptBy axis "showticksuffix" StyleParam.ShowTickOption.convert
                    Showexponent    |> DynObj.setValueOptBy axis "showexponent" StyleParam.ShowExponent.convert
                    Exponentformat  |> DynObj.setValueOptBy axis "exponentformat" StyleParam.ExponentFormat.convert  
                    Tickformat      |> DynObj.setValueOpt   axis "tickformat"      
                    Hoverformat     |> DynObj.setValueOpt   axis "hoverformat"     
                    Showline        |> DynObj.setValueOpt   axis "showline"        
                    Linecolor       |> DynObj.setValueOpt   axis "linecolor"       
                    Linewidth       |> DynObj.setValueOpt   axis "linewidth"       
                    Showgrid        |> DynObj.setValueOpt   axis "showgrid"        
                    Gridcolor       |> DynObj.setValueOpt   axis "gridcolor"       
                    Gridwidth       |> DynObj.setValueOpt   axis "gridwidth"       
                    Zeroline        |> DynObj.setValueOpt   axis "zeroline"        
                    Zerolinecolor   |> DynObj.setValueOpt   axis "zerolinecolor"   
                    Zerolinewidth   |> DynObj.setValueOpt   axis "zerolinewidth"   
                    Anchor          |> DynObj.setValueOpt   axis "anchor"          
                    Side            |> DynObj.setValueOptBy axis "side"     StyleParam.Side.convert
                    Overlaying      |> DynObj.setValueOpt   axis "overlaying"      
                    Domain          |> DynObj.setValueOptBy axis "domain"   StyleParam.RangeValues.convert               
                    Position        |> DynObj.setValueOpt   axis "position"        
                    IsSubplotObj    |> DynObj.setValueOpt   axis "_isSubplotObj"    
                    Tickvalssrc     |> DynObj.setValueOpt   axis "tickvalssrc"     
                    Ticktextsrc     |> DynObj.setValueOpt   axis "ticktextsrc"     
                    Showspikes      |> DynObj.setValueOpt   axis "showspikes"      
                    Spikesides      |> DynObj.setValueOpt   axis "spikesides"      
                    Spikethickness  |> DynObj.setValueOpt   axis "spikethickness"  
                    Spikecolor      |> DynObj.setValueOpt   axis "spikecolor"      
                    Showbackground  |> DynObj.setValueOpt   axis "showbackground"  
                    Backgroundcolor |> DynObj.setValueOpt   axis "backgroundcolor" 
                    Showaxeslabels  |> DynObj.setValueOpt   axis "showaxeslabels"     

                    //Update
                    Titlefont       |> DynObj.setValueOpt   axis "titlefont" 
                    Tickfont        |> DynObj.setValueOpt   axis "tickfont"

                    axis
                )


    /// Radialaxis type inherits from dynamic object
    type RadialAxis () =
        inherit DynamicObj ()

        /// Init Radialaxis type
        static member init (applyStyle:RadialAxis->RadialAxis) =
            RadialAxis() |> applyStyle

    /// Angularaxis type inherits from dynamic object
    type AngularAxis () =
        inherit DynamicObj ()

        /// Init Angularaxis type
        static member init (applyStyle:AngularAxis->AngularAxis) =
            AngularAxis() |> applyStyle



