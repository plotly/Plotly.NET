namespace Plotly.NET

open System
/// Module containing plotly axis 
module Axis =

    /// LinearAxis type inherits from dynamic object
    type LinearAxis () =
        inherit DynamicObj ()

        /// Init LinearAxis type
        static member init
            (
                ?AxisType: StyleParam.AxisType, 
                ?Title: string,            
                ?Titlefont: Font,                             
                ?Autorange: StyleParam.AutoRange,        
                ?Rangemode: StyleParam.RangeMode,        
                ?Range: StyleParam.Range,            
                ?RangeSlider: RangeSlider,
                ?Fixedrange:bool,       
                ?Tickmode: StyleParam.TickMode,         
                ?nTicks: int,           
                ?Tick0: IConvertible,            
                ?dTick: IConvertible,            
                ?Tickvals: seq<#IConvertible>,         
                ?Ticktext: seq<#IConvertible>,         
                ?Ticks: StyleParam.TickOptions,            
                ?Mirror: StyleParam.Mirror,           
                ?Ticklen: float,
                ?Tickwidth: float,        
                ?Tickcolor: string,        
                ?Showticklabels: bool,   
                ?Tickfont: Font,         
                ?Tickangle: int,        
                ?Tickprefix: string,       
                ?Showtickprefix: StyleParam.ShowTickOption,   
                ?Ticksuffix: string,       
                ?Showticksuffix: StyleParam.ShowTickOption,   
                ?Showexponent: StyleParam.ShowExponent,     
                ?Exponentformat: StyleParam.ExponentFormat,   
                ?Tickformat: string,       
                ?Hoverformat: string,      
                ?Showline: bool,         
                ?Linecolor: string,        
                ?Linewidth: float,        
                ?Showgrid: bool,         
                ?Gridcolor: string,        
                ?Gridwidth: float,        
                ?Zeroline : bool,         
                ?Zerolinecolor: string,    
                ?Zerolinewidth: float,    
                ?Anchor: StyleParam.AxisAnchorId,           
                ?Side: StyleParam.Side,             
                ?Overlaying: StyleParam.AxisAnchorId,      
                ?Domain: StyleParam.Range,           
                ?Position: float,         
                ?IsSubplotObj: bool,
                ?Showspikes: bool,       
                ?Spikethickness: float,   
                ?Spikecolor: string,       
                ?Showbackground: bool,   
                ?Backgroundcolor: string,  
                ?Showaxeslabels: bool,
                ?Visible: bool
            ) =
                LinearAxis() 
                |> LinearAxis.style
                    (
                        ?AxisType        = AxisType       ,
                        ?Title           = Title          ,
                        ?Titlefont       = Titlefont      ,
                        ?Autorange       = Autorange      ,
                        ?Rangemode       = Rangemode      ,
                        ?Range           = Range          ,
                        ?RangeSlider     = RangeSlider    ,
                        ?Fixedrange      = Fixedrange     ,
                        ?Tickmode        = Tickmode       ,
                        ?nTicks          = nTicks         ,
                        ?Tick0           = Tick0          ,
                        ?dTick           = dTick          ,
                        ?Tickvals        = Tickvals       ,
                        ?Ticktext        = Ticktext       ,
                        ?Ticks           = Ticks          ,
                        ?Mirror          = Mirror         ,
                        ?Ticklen         = Ticklen        ,
                        ?Tickwidth       = Tickwidth      ,
                        ?Tickcolor       = Tickcolor      ,
                        ?Showticklabels  = Showticklabels ,
                        ?Tickfont        = Tickfont       ,
                        ?Tickangle       = Tickangle      ,
                        ?Tickprefix      = Tickprefix     ,
                        ?Showtickprefix  = Showtickprefix ,
                        ?Ticksuffix      = Ticksuffix     ,
                        ?Showticksuffix  = Showticksuffix ,
                        ?Showexponent    = Showexponent   ,
                        ?Exponentformat  = Exponentformat ,
                        ?Tickformat      = Tickformat     ,
                        ?Hoverformat     = Hoverformat    ,
                        ?Showline        = Showline       ,
                        ?Linecolor       = Linecolor      ,
                        ?Linewidth       = Linewidth      ,
                        ?Showgrid        = Showgrid       ,
                        ?Gridcolor       = Gridcolor      ,
                        ?Gridwidth       = Gridwidth      ,
                        ?Zeroline        = Zeroline       ,
                        ?Zerolinecolor   = Zerolinecolor  ,
                        ?Zerolinewidth   = Zerolinewidth  ,
                        ?Anchor          = Anchor         ,
                        ?Side            = Side           ,
                        ?Overlaying      = Overlaying     ,
                        ?Domain          = Domain         ,
                        ?Position        = Position       ,
                        ?IsSubplotObj    = IsSubplotObj   ,
                        ?Showspikes      = Showspikes     ,
                        ?Spikethickness  = Spikethickness ,
                        ?Spikecolor      = Spikecolor     ,
                        ?Showbackground  = Showbackground ,
                        ?Backgroundcolor = Backgroundcolor,
                        ?Showaxeslabels  = Showaxeslabels,
                        ?Visible = Visible
                    )

        // Applies the styles to LinearAxis()
        static member style
            (
                ?AxisType: StyleParam.AxisType, 
                ?Title: string,            
                ?Titlefont: Font,                             
                ?Autorange: StyleParam.AutoRange,        
                ?Rangemode: StyleParam.RangeMode,        
                ?Range: StyleParam.Range,            
                ?RangeSlider: RangeSlider,
                ?Fixedrange:bool,       
                ?Tickmode: StyleParam.TickMode,         
                ?nTicks: int,           
                ?Tick0: IConvertible,            
                ?dTick: IConvertible,            
                ?Tickvals: seq<#IConvertible>,         
                ?Ticktext: seq<#IConvertible>,         
                ?Ticks: StyleParam.TickOptions,            
                ?Mirror: StyleParam.Mirror,           
                ?Ticklen: float,
                ?Tickwidth: float,        
                ?Tickcolor: string,        
                ?Showticklabels: bool,   
                ?Tickfont: Font,         
                ?Tickangle: int,        
                ?Tickprefix: string,       
                ?Showtickprefix: StyleParam.ShowTickOption,   
                ?Ticksuffix: string,       
                ?Showticksuffix: StyleParam.ShowTickOption,   
                ?Showexponent: StyleParam.ShowExponent,     
                ?Exponentformat: StyleParam.ExponentFormat,   
                ?Tickformat: string,       
                ?Hoverformat: string,      
                ?Showline: bool,         
                ?Linecolor: string,        
                ?Linewidth: float,        
                ?Showgrid: bool,         
                ?Gridcolor: string,        
                ?Gridwidth: float,        
                ?Zeroline : bool,         
                ?Zerolinecolor: string,    
                ?Zerolinewidth: float,    
                ?Anchor: StyleParam.AxisAnchorId,           
                ?Side: StyleParam.Side,             
                ?Overlaying: StyleParam.AxisAnchorId,      
                ?Domain: StyleParam.Range,           
                ?Position: float,         
                ?IsSubplotObj: bool,
                ?Showspikes: bool,       
                ?Spikethickness: float,   
                ?Spikecolor: string,       
                ?Showbackground: bool,   
                ?Backgroundcolor: string,  
                ?Showaxeslabels: bool,
                ?Visible: bool
            ) =
                (fun (axis:LinearAxis) -> 
                    AxisType        |> DynObj.setValueOptBy axis "type" StyleParam.AxisType.convert
                    Title           |> DynObj.setValueOpt   axis "title"                 
                    
                    Autorange       |> DynObj.setValueOptBy axis "autorange" StyleParam.AutoRange.convert
                    Rangemode       |> DynObj.setValueOptBy axis "rangemode" StyleParam.RangeMode.convert
                    Range           |> DynObj.setValueOptBy axis "range"     StyleParam.Range.convert       
                    RangeSlider     |> DynObj.setValueOpt   axis "rangeslider"
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
                    Anchor          |> DynObj.setValueOptBy axis "anchor"     StyleParam.AxisAnchorId.convert
                    Side            |> DynObj.setValueOptBy axis "side"     StyleParam.Side.convert
                    Overlaying      |> DynObj.setValueOptBy axis "overlaying" StyleParam.AxisAnchorId.convert      
                    Domain          |> DynObj.setValueOptBy axis "domain"   StyleParam.Range.convert               
                    Position        |> DynObj.setValueOpt   axis "position"        
                    IsSubplotObj    |> DynObj.setValueOpt   axis "_isSubplotObj"    
                    Showspikes      |> DynObj.setValueOpt   axis "showspikes"      
                    Spikethickness  |> DynObj.setValueOpt   axis "spikethickness"  
                    Spikecolor      |> DynObj.setValueOpt   axis "spikecolor"      
                    Showbackground  |> DynObj.setValueOpt   axis "showbackground"  
                    Backgroundcolor |> DynObj.setValueOpt   axis "backgroundcolor" 
                    Showaxeslabels  |> DynObj.setValueOpt   axis "showaxeslabels"     
                    Visible         |> DynObj.setValueOpt   axis "visible"     
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



