namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// The ColorBar object to be used with ColorAxes.
type ColorBar () =
    inherit ImmutableDynamicObj ()
       
    /// <summary>
    /// Initializes a ColorBar object.
    /// </summary>
    /// <param name="BGColor">Sets the color of padded area.</param>
    /// <param name="BorderColor">Sets the axis line color.</param>
    /// <param name="BorderWidth">Sets the width (in px) or the border enclosing this color bar.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="Len">Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.</param>
    /// <param name="LenMode">Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot "fraction" or in "pixels. Use `len` to set the value.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `tickformat` is "SI" or "B".</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="OutlineColor">Sets the axis line color.</param>
    /// <param name="OutlineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="Thickness">Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.</param>
    /// <param name="ThicknessMode">Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot "fraction" or in "pixels". Use `thickness` to set the value.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&gt;f&lt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the color bar's tick label font</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". In other cases the default is "hide past div".</param>
    /// <param name="TickLabelPosition">Determines where tick labels are drawn.</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to "array". Used with `tickvals`.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="Title">Sets the ColorBar title.</param>
    /// <param name="X">Sets the x position of the color bar (in plot fraction).</param>
    /// <param name="XAnchor">Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the color bar.</param>
    /// <param name="XPad">Sets the amount of padding (in px) along the x direction.</param>
    /// <param name="Y">Sets the y position of the color bar (in plot fraction).</param>
    /// <param name="YAnchor">Sets this color bar's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the color bar.</param>
    /// <param name="YPad">Sets the amount of padding (in px) along the y direction.</param>
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?BGColor            : Color,        
            [<Optional;DefaultParameterValue(null)>] ?BorderColor        : Color,    
            [<Optional;DefaultParameterValue(null)>] ?BorderWidth        : float,    
            [<Optional;DefaultParameterValue(null)>] ?DTick              : IConvertible,          
            [<Optional;DefaultParameterValue(null)>] ?ExponentFormat     : StyleParam.ExponentFormat, 
            [<Optional;DefaultParameterValue(null)>] ?Len                : float,            
            [<Optional;DefaultParameterValue(null)>] ?LenMode            : StyleParam.UnitMode,        
            [<Optional;DefaultParameterValue(null)>] ?MinExponent        : float,
            [<Optional;DefaultParameterValue(null)>] ?NTicks             : int,         
            [<Optional;DefaultParameterValue(null)>] ?OutlineColor       : Color,   
            [<Optional;DefaultParameterValue(null)>] ?OutlineWidth       : float,   
            [<Optional;DefaultParameterValue(null)>] ?SeparateThousands  : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowExponent       : StyleParam.ShowExponent,   
            [<Optional;DefaultParameterValue(null)>] ?ShowTickLabels     : bool, 
            [<Optional;DefaultParameterValue(null)>] ?ShowTickPrefix     : StyleParam.ShowTickOption, 
            [<Optional;DefaultParameterValue(null)>] ?ShowTickSuffix     : StyleParam.ShowTickOption,
            [<Optional;DefaultParameterValue(null)>] ?Thickness          : float,      
            [<Optional;DefaultParameterValue(null)>] ?ThicknessMode      : StyleParam.UnitMode,  
            [<Optional;DefaultParameterValue(null)>] ?Tick0              : IConvertible,          
            [<Optional;DefaultParameterValue(null)>] ?TickAngle          : int,      
            [<Optional;DefaultParameterValue(null)>] ?TickColor          : Color,      
            [<Optional;DefaultParameterValue(null)>] ?TickFont           : Font,       
            [<Optional;DefaultParameterValue(null)>] ?TickFormat         : string,     
            [<Optional;DefaultParameterValue(null)>] ?TickFormatStops    : seq<TickFormatStop>,
            [<Optional;DefaultParameterValue(null)>] ?TickLabelOverflow  : StyleParam.TickLabelOverflow,
            [<Optional;DefaultParameterValue(null)>] ?TickLabelPosition  : StyleParam.TickLabelPosition,
            [<Optional;DefaultParameterValue(null)>] ?TickLen            : float,        
            [<Optional;DefaultParameterValue(null)>] ?TickMode           : StyleParam.TickMode,       
            [<Optional;DefaultParameterValue(null)>] ?TickPrefix         : string,     
            [<Optional;DefaultParameterValue(null)>] ?Ticks              : StyleParam.TickOptions,          
            [<Optional;DefaultParameterValue(null)>] ?TickSuffix         : string,     
            [<Optional;DefaultParameterValue(null)>] ?TickText           : seq<#IConvertible>,       
            [<Optional;DefaultParameterValue(null)>] ?TickVals           : seq<#IConvertible>,       
            [<Optional;DefaultParameterValue(null)>] ?TickWidth          : float,      
            [<Optional;DefaultParameterValue(null)>] ?Title              : Title,          
            [<Optional;DefaultParameterValue(null)>] ?X                  : float,              
            [<Optional;DefaultParameterValue(null)>] ?XAnchor            : StyleParam.HorizontalAlign,
            [<Optional;DefaultParameterValue(null)>] ?XPad               : float,           
            [<Optional;DefaultParameterValue(null)>] ?Y                  : float,              
            [<Optional;DefaultParameterValue(null)>] ?YAnchor            : StyleParam.VerticalAlign,        
            [<Optional;DefaultParameterValue(null)>] ?YPad               : float           

        ) = 
            ColorBar()
            |> ColorBar.style
                (   
                    ?BGColor            = BGColor            ,
                    ?BorderColor        = BorderColor        ,
                    ?BorderWidth        = BorderWidth        ,
                    ?DTick              = DTick              ,
                    ?ExponentFormat     = ExponentFormat     ,
                    ?Len                = Len                ,
                    ?LenMode            = LenMode            ,
                    ?MinExponent        = MinExponent        ,
                    ?NTicks             = NTicks             ,
                    ?OutlineColor       = OutlineColor       ,
                    ?OutlineWidth       = OutlineWidth       ,
                    ?SeparateThousands  = SeparateThousands  ,
                    ?ShowExponent       = ShowExponent       ,
                    ?ShowTickLabels     = ShowTickLabels     ,
                    ?ShowTickPrefix     = ShowTickPrefix     ,
                    ?ShowTickSuffix     = ShowTickSuffix     ,
                    ?Thickness          = Thickness          ,
                    ?ThicknessMode      = ThicknessMode      ,
                    ?Tick0              = Tick0              ,
                    ?TickAngle          = TickAngle          ,
                    ?TickColor          = TickColor          ,
                    ?TickFont           = TickFont           ,
                    ?TickFormat         = TickFormat         ,
                    ?TickFormatStops    = TickFormatStops    ,
                    ?TickLabelOverflow  = TickLabelOverflow  ,
                    ?TickLabelPosition  = TickLabelPosition  ,
                    ?TickLen            = TickLen            ,
                    ?TickMode           = TickMode           ,
                    ?TickPrefix         = TickPrefix         ,
                    ?Ticks              = Ticks              ,
                    ?TickSuffix         = TickSuffix         ,
                    ?TickText           = TickText           ,
                    ?TickVals           = TickVals           ,
                    ?TickWidth          = TickWidth          ,
                    ?Title              = Title              ,
                    ?X                  = X                  ,
                    ?XAnchor            = XAnchor            ,
                    ?XPad               = XPad               ,
                    ?Y                  = Y                  ,
                    ?YAnchor            = YAnchor            ,
                    ?YPad               = YPad               
                )


    /// <summary>
    /// Create a function that applies the given style parameters to a ColorBar object
    /// </summary>
    /// <param name="BGColor">Sets the color of padded area.</param>
    /// <param name="BorderColor">Sets the axis line color.</param>
    /// <param name="BorderWidth">Sets the width (in px) or the border enclosing this color bar.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="Len">Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.</param>
    /// <param name="LenMode">Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot "fraction" or in "pixels. Use `len` to set the value.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `tickformat` is "SI" or "B".</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="OutlineColor">Sets the axis line color.</param>
    /// <param name="OutlineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="Thickness">Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.</param>
    /// <param name="ThicknessMode">Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot "fraction" or in "pixels". Use `thickness` to set the value.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&gt;f&lt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the color bar's tick label font</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". In other cases the default is "hide past div".</param>
    /// <param name="TickLabelPosition">Determines where tick labels are drawn.</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to "array". Used with `tickvals`.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="Title">Sets the ColorBar title.</param>
    /// <param name="X">Sets the x position of the color bar (in plot fraction).</param>
    /// <param name="XAnchor">Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the color bar.</param>
    /// <param name="XPad">Sets the amount of padding (in px) along the x direction.</param>
    /// <param name="Y">Sets the y position of the color bar (in plot fraction).</param>
    /// <param name="YAnchor">Sets this color bar's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the color bar.</param>
    /// <param name="YPad">Sets the amount of padding (in px) along the y direction.</param>
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?BGColor            : Color,        
            [<Optional;DefaultParameterValue(null)>] ?BorderColor        : Color,    
            [<Optional;DefaultParameterValue(null)>] ?BorderWidth        : float,    
            [<Optional;DefaultParameterValue(null)>] ?DTick              : IConvertible,          
            [<Optional;DefaultParameterValue(null)>] ?ExponentFormat     : StyleParam.ExponentFormat, 
            [<Optional;DefaultParameterValue(null)>] ?Len                : float,            
            [<Optional;DefaultParameterValue(null)>] ?LenMode            : StyleParam.UnitMode,        
            [<Optional;DefaultParameterValue(null)>] ?MinExponent        : float,
            [<Optional;DefaultParameterValue(null)>] ?NTicks             : int,         
            [<Optional;DefaultParameterValue(null)>] ?OutlineColor       : Color,   
            [<Optional;DefaultParameterValue(null)>] ?OutlineWidth       : float,   
            [<Optional;DefaultParameterValue(null)>] ?SeparateThousands  : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowExponent       : StyleParam.ShowExponent,   
            [<Optional;DefaultParameterValue(null)>] ?ShowTickLabels     : bool, 
            [<Optional;DefaultParameterValue(null)>] ?ShowTickPrefix     : StyleParam.ShowTickOption, 
            [<Optional;DefaultParameterValue(null)>] ?ShowTickSuffix     : StyleParam.ShowTickOption,
            [<Optional;DefaultParameterValue(null)>] ?Thickness          : float,      
            [<Optional;DefaultParameterValue(null)>] ?ThicknessMode      : StyleParam.UnitMode,  
            [<Optional;DefaultParameterValue(null)>] ?Tick0              : IConvertible,          
            [<Optional;DefaultParameterValue(null)>] ?TickAngle          : int,      
            [<Optional;DefaultParameterValue(null)>] ?TickColor          : Color,      
            [<Optional;DefaultParameterValue(null)>] ?TickFont           : Font,       
            [<Optional;DefaultParameterValue(null)>] ?TickFormat         : string,     
            [<Optional;DefaultParameterValue(null)>] ?TickFormatStops    : seq<TickFormatStop>,
            [<Optional;DefaultParameterValue(null)>] ?TickLabelOverflow  : StyleParam.TickLabelOverflow,
            [<Optional;DefaultParameterValue(null)>] ?TickLabelPosition  : StyleParam.TickLabelPosition,
            [<Optional;DefaultParameterValue(null)>] ?TickLen            : float,        
            [<Optional;DefaultParameterValue(null)>] ?TickMode           : StyleParam.TickMode,       
            [<Optional;DefaultParameterValue(null)>] ?TickPrefix         : string,     
            [<Optional;DefaultParameterValue(null)>] ?Ticks              : StyleParam.TickOptions,          
            [<Optional;DefaultParameterValue(null)>] ?TickSuffix         : string,     
            [<Optional;DefaultParameterValue(null)>] ?TickText           : seq<#IConvertible>,       
            [<Optional;DefaultParameterValue(null)>] ?TickVals           : seq<#IConvertible>,       
            [<Optional;DefaultParameterValue(null)>] ?TickWidth          : float,      
            [<Optional;DefaultParameterValue(null)>] ?Title              : Title,          
            [<Optional;DefaultParameterValue(null)>] ?X                  : float,              
            [<Optional;DefaultParameterValue(null)>] ?XAnchor            : StyleParam.HorizontalAlign,
            [<Optional;DefaultParameterValue(null)>] ?XPad               : float,           
            [<Optional;DefaultParameterValue(null)>] ?Y                  : float,              
            [<Optional;DefaultParameterValue(null)>] ?YAnchor            : StyleParam.VerticalAlign,        
            [<Optional;DefaultParameterValue(null)>] ?YPad               : float           

        ) =
                
            (fun (colorBar:ColorBar) ->            

                colorBar

                ++? ("bgcolor", BGColor)
                ++? ("bordercolor", BorderColor)
                ++? ("borderwidth", BorderWidth)
                ++? ("dtick", DTick)
                ++? ("exponentformat", ExponentFormat)
                ++? ("len", Len)
                ++? ("lenmode", LenMode)
                ++? ("min3xponent", MinExponent)
                ++? ("nticks", NTicks)
                ++? ("outlinecolor", OutlineColor)
                ++? ("outlinewidth", OutlineWidth)
                ++? ("separatethousands", SeparateThousands)
                ++? ("showexponent", ShowExponent)
                ++? ("showticklabels", ShowTickLabels)
                ++? ("showtickprefix", ShowTickPrefix)
                ++? ("showticksuffix", ShowTickSuffix)
                ++? ("thickness", Thickness)
                ++? ("thicknessmode", ThicknessMode)
                ++? ("tick0", Tick0)
                ++? ("tickangle", TickAngle)
                ++? ("tickcolor", TickColor)
                ++? ("tickfont", TickFont)
                ++? ("tickformat", TickFormat)
                ++? ("tickformatstops", TickFormatStops)
                ++? ("ticklabeloverflow", TickLabelOverflow)
                ++? ("ticklabelposition", TickLabelPosition)
                ++? ("ticklen", TickLen)
                ++? ("tickmode", TickMode)
                ++? ("tickprefix", TickPrefix)
                ++? ("ticks", Ticks)
                ++? ("ticksuffix", TickSuffix)
                ++? ("ticktext", TickText)
                ++? ("tickvals", TickVals)
                ++? ("tickwidth", TickWidth)
                ++? ("title", Title)
                ++? ("x", X)
                ++? ("xanchor", XAnchor)
                ++? ("xpad", XPad)
                ++? ("y", Y)
                ++? ("yanchor", YAnchor)
                ++? ("ypad", YPad)
            )
