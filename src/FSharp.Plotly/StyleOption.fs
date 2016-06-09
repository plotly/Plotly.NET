namespace FSharp.Plotly

// https://plot.ly/javascript/reference/

module StyleOption =

//Symbol
//enumerated: 
//  "0" | "circle" | "100" | "circle-open" | "200" | "circle-dot" | "300" | "circle-open-dot" 
//| "1" | "square" | "101" | "square-open" | "201" | "square-dot" | "301" | "square-open-dot" 
//| "2" | "diamond" | "102" | "diamond-open" | "202" | "diamond-dot" | "302" | "diamond-open-dot" 
//| "3" | "cross" | "103" | "cross-open" | "203" | "cross-dot" | "303" | "cross-open-dot" 
//| "4" | "x" | "104" | "x-open" | "204" | "x-dot" | "304" | "x-open-dot" 
//| "5" | "triangle-up" | "105" | "triangle-up-open" | "205" | "triangle-up-dot" | "305" | "triangle-up-open-dot" 
//| "6" | "triangle-down" | "106" | "triangle-down-open" | "206" | "triangle-down-dot" | "306" | "triangle-down-open-dot" 
//| "7" | "triangle-left" | "107" | "triangle-left-open" | "207" | "triangle-left-dot" | "307" | "triangle-left-open-dot" 
//| "8" | "triangle-right" | "108" | "triangle-right-open" | "208" | "triangle-right-dot" | "308" | "triangle-right-open-dot" 
//| "9" | "triangle-ne" | "109" | "triangle-ne-open" | "209" | "triangle-ne-dot" | "309" | "triangle-ne-open-dot" 
//| "10" | "triangle-se" | "110" | "triangle-se-open" | "210" | "triangle-se-dot" | "310" | "triangle-se-open-dot" 
//| "11" | "triangle-sw" | "111" | "triangle-sw-open" | "211" | "triangle-sw-dot" | "311" | "triangle-sw-open-dot" 
//| "12" | "triangle-nw" | "112" | "triangle-nw-open" | "212" | "triangle-nw-dot" | "312" | "triangle-nw-open-dot" 
//| "13" | "pentagon" | "113" | "pentagon-open" | "213" | "pentagon-dot" | "313" | "pentagon-open-dot" 
//| "14" | "hexagon" | "114" | "hexagon-open" | "214" | "hexagon-dot" | "314" | "hexagon-open-dot" 
//| "15" | "hexagon2" | "115" | "hexagon2-open" | "215" | "hexagon2-dot" | "315" | "hexagon2-open-dot" 
//| "16" | "octagon" | "116" | "octagon-open" | "216" | "octagon-dot" | "316" | "octagon-open-dot" 
//| "17" | "star" | "117" | "star-open" | "217" | "star-dot" | "317" | "star-open-dot"
//| "18" | "hexagram" | "118" | "hexagram-open" | "218" | "hexagram-dot" | "318" | "hexagram-open-dot" 
//| "19" | "star-triangle-up" | "119" | "star-triangle-up-open" | "219" | "star-triangle-up-dot" | "319" | "star-triangle-up-open-dot" 
//| "20" | "star-triangle-down" | "120" | "star-triangle-down-open" | "220" | "star-triangle-down-dot" | "320" | "star-triangle-down-open-dot" 
//| "21" | "star-square" | "121" | "star-square-open" | "221" | "star-square-dot" | "321" | "star-square-open-dot" 
//| "22" | "star-diamond" | "122" | "star-diamond-open" | "222" | "star-diamond-dot" | "322" | "star-diamond-open-dot" 
//| "23" | "diamond-tall" | "123" | "diamond-tall-open" | "223" | "diamond-tall-dot" | "323" | "diamond-tall-open-dot" 
//| "24" | "diamond-wide" | "124" | "diamond-wide-open" | "224" | "diamond-wide-dot" | "324" | "diamond-wide-open-dot" 
//| "25" | "hourglass" | "125" | "hourglass-open" 
//| "26" | "bowtie" | "126" | "bowtie-open" 
//| "27" | "circle-cross" | "127" | "circle-cross-open" 
//| "28" | "circle-x" | "128" | "circle-x-open" 
//| "29" | "square-cross" | "129" | "square-cross-open" 
//| "30" | "square-x" | "130" | "square-x-open" 
//| "31" | "diamond-cross" | "131" | "diamond-cross-open" 
//| "32" | "diamond-x" | "132" | "diamond-x-open" 
//| "33" | "cross-thin" | "133" | "cross-thin-open" 
//| "34" | "x-thin" | "134" | "x-thin-open" 
//| "35" | "asterisk" | "135" | "asterisk-open" 
//| "36" | "hash" | "136" | "hash-open" | "236" | "hash-dot" | "336" | "hash-open-dot" 
//| "37" | "y-up" | "137" | "y-up-open" | "38" | "y-down" | "138" | "y-down-open" | "39" | "y-left" | "139" | "y-left-open" | "40" | "y-right" | "140" | "y-right-open" | "41" | "line-ew" | "141" | "line-ew-open" | "42" | "line-ns" | "142" | "line-ns-open" | "43" | "line-ne" | "143" | "line-ne-open" | "44" | "line-nw" | "144" | "line-nw-open"

    type Symbol =
        | Circle = 0
        | Square = 1

    /// Dash: Sets the drawing style of the lines segments in this trace.
    /// Sets the style of the lines. Set to a dash string type or a dash length in px.
    type DrawingStyle = 
        | Solid 
        | Dash   
        | Dot 
        | DashDot
        | User of int
        static member toString = function
            | Solid   -> "solid"             
            | Dash    -> "dash"            
            | Dot     -> "dot"    
            | DashDot -> "dashdot"       
            | User px -> px.ToString()
           

        static member convert = DrawingStyle.toString >> box


    // | "lines", "markers", "text" joined with a "+" OR "none".
    type Mode = 
        | None 
        | Lines   | Lines_Markers | Lines_Text | Lines_Markers_Text
        | Markers | Markers_Text
        | Text
        static member toString = function
            | None               -> "None"             
            | Lines              -> "lines"            
            | Lines_Markers      -> "lines+markers"    
            | Lines_Text         -> "lines+text"       
            | Lines_Markers_Text -> "lines+markers+text"
            | Markers            -> "markers"          
            | Markers_Text       -> "markers+text"
            | Text               -> "text"             

        static member convert = Mode.toString >> box

    /// Sets the positions of the `text` elements with respects to the (x,y) coordinates. (default: MiddleCenter)
    type TextPosition =
        | TopLeft | TopCenter | TopRight | MiddleLeft | MiddleCenter | MiddleRight | BottomLeft | BottomCenter | BottomRight 
        static member toString = function
            | TopLeft      -> "top left" 
            | TopCenter    -> "top center"
            | TopRight     -> "top right"
            | MiddleLeft   -> "middle left"
            | MiddleCenter -> "middle center"
            | MiddleRight  -> "middle right"
            | BottomLeft   -> "bottom left"
            | BottomCenter -> "bottom center"
            | BottomRight  -> "bottom right"        

        static member convert = TextPosition.toString >> box



    /// Names of installed font families
    type FontFamily =
        | Arial | Balto | Courier_New | Droid_Sans | Droid_Serif | Droid_Sans_Mono | Gravitas_One | Old_Standard_TT | Open_Sans | Overpass | PT_Sans_Narrow | Raleway | Times_New_Roman
        
        static member toString = function
            | Arial           -> "Arial"
            | Balto           -> "Balto"
            | Courier_New     -> "Courier New"
            | Droid_Sans      -> "Droid Sans"     
            | Droid_Serif     -> "Droid Serif"    
            | Droid_Sans_Mono -> "Droid Sans Mono"
            | Gravitas_One    -> "Gravitas One"   
            | Old_Standard_TT -> "Old Standard TT"
            | Open_Sans       -> "Open Sans"      
            | Overpass        -> "Overpass"       
            | PT_Sans_Narrow  -> "PT Sans Narrow" 
            | Raleway         -> "Raleway"        
            | Times_New_Roman -> "Times New Roman"

        static member convert = FontFamily.toString >> box

    /// Determines the line shape. With "spline" the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.
    type Shape =
        | Linear | Spline | Hv | Vh | Hvh | Vhv
        
        static member toString = function
            | Linear -> "linear"
            | Spline -> "spline"
            | Hv     -> "hv"
            | Vh     -> "vh"
            | Hvh    -> "hvh"
            | Vhv    -> "vhv"
        
        static member convert  = Shape.toString >> box
    
    /// Sets the area to fill with a solid color. (default: "none" )
    type Fill =
        | None | ToZero_y | ToZero_x | ToNext_y | ToNext_x | ToSelf | ToNext
        
        static member toString = function
            | None      -> "none"
            | ToZero_y  -> "tozeroy"
            | ToZero_x  -> "tozerox"
            | ToNext_y  -> "tonexty"
            | ToNext_x  -> "tonextx"
            | ToSelf    -> "toself"
            | ToNext    -> "tonext"
        
        static member convert = Fill.toString >> box


    type Boxpoints =
        | Outliers
        | All
        | Suspectedoutliers
        | False    

        static member convert = function
            | Outliers          -> box "outliers"
            | All               -> box "all"
            | Suspectedoutliers -> box "suspectedoutliers"
            | False             -> box false


    type BoxMean =
        | True
        | False
        | SD 
             
        static member convert = function
            | True  -> box true
            | False -> box false
            | SD    -> box "SD"

    type Orientation =
        | Horizontal
        | Vertival

        static member convert = function
            | Horizontal -> box "h"
            | Vertival   -> box "v"

    /// The colorscale must be a collection containing a mapping of a normalized value (between 0.0 and 1.0) to it's color. At minimum, a mapping for the lowest (0.0) and highest (1.0) values are required. 
    type ColorScale =
        | Custom of seq<float*string> 
        | RdBu | Earth | Blackbody | YIOrRd | YIGnBu | Bluered
        | Portland | Electric | Jet | Hot | Greys | Greens | Picnic 
        
        static member convert = function
            | Custom (cScale) -> cScale
                                 |> Seq.map (fun (v,color) -> [|box v;box color|])
                                 |> Array.ofSeq |> box
            | RdBu            -> box "RdBu"     
            | Earth           -> box "Earth"    
            | Blackbody       -> box "Blackbody"
            | YIOrRd          -> box "YIOrRd"   
            | YIGnBu          -> box "YIGnBu"   
            | Bluered         -> box "Bluered"  
            | Portland        -> box "Portland"
            | Electric        -> box "Electric" 
            | Jet             -> box "Jet"      
            | Hot             -> box "Hot"      
            | Greys           -> box "Greys"    
            | Greens          -> box "Greens"   
            | Picnic          -> box "Picnic"   
                           
    
    /// If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.
    type ShowTickOption =
        | All | First | Last | None
        
        static member toString = function
            | All   -> "all"
            | First -> "first"
            | Last  -> "last"
            | None  -> "none"
            
        
        static member convert = ShowTickOption.toString >> box


    /// If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.
    type ShowExponent =
        | All | First | Last | None
        
        static member toString = function
            | All   -> "all"
            | First -> "first"
            | Last  -> "last"
            | None  -> "none"
            
        
        static member convert = ShowExponent.toString >> box

    /// Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. 
    /// If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.
    type ExponentFormat =
        | B | SI | Power | Ecapital | E | None
        
        static member toString = function
            | B        -> "B"
            | SI       -> "SI"
            | Power    -> "power"
            | Ecapital -> "E"
            | E        -> "e"
            | None     -> "none"
            
        
        static member convert = ExponentFormat.toString >> box

    type Side =
        | Top | Bottom | Left | Right 
        
        static member toString = function
            | Top    -> "top"
            | Bottom -> "bottom"
            | Left   -> "left"
            | Right  -> "right"            
       
        static member convert = Side.toString >> box

    /// Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If "true", the axis lines are mirrored. 
    /// If "ticks", the axis lines and ticks are mirrored. If "false", mirroring is disable. If "all", axis lines are mirrored on all shared-axes subplots. If "allticks", axis lines and ticks are mirrored on all shared-axes subplots.
    type Mirror =
        | True | Ticks | False | All | AllTicks 
        
        static member toString = function
            | True     -> "true"
            | Ticks    -> "ticks"
            | False    -> "false"
            | All      -> "all"
            | AllTicks -> "allticks"

        static member convert = Mirror.toString >> box

    /// Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".
    type AutoRange =
        | True | False | Reversed
        
        static member toString = function
            | True     -> "true"            
            | False    -> "false"            
            | Reversed -> "reversed"

        static member convert = AutoRange.toString >> box

    /// Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). 
    /// If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).
    type TickMode =
        | Auto | Linear | Array
        
        static member toString = function
            | Auto   -> "auto"            
            | Linear -> "linear"            
            | Array  -> "array"

        static member convert = TickMode.toString >> box

    /// Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.
    type TickOptions =
        | Outside | Inside | Empty
        
        static member toString = function
            | Outside   -> "outside"            
            | Inside    -> "inside"            
            | Empty    -> ""

        static member convert = TickOptions.toString >> box

    /// If "normal", the range is computed in relation to the extrema of the input data. If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data.
    type RangeMode =
        | Normal | ToZero | NonNegative
        
        static member toString = function
            | Normal      -> "normal"            
            | ToZero      -> "tozero"            
            | NonNegative -> "nonnegative"

        static member convert = RangeMode.toString >> box


    /// Sets the axis type. By default (Auto), plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.
    type AxisType =
        | Auto | Linear | Log | Date | Category
        
        static member toString = function
            | Auto     -> "-"            
            | Linear   -> "linear"            
            | Log      -> "log"
            | Date     -> "date"
            | Category -> "category"

        static member convert = AxisType.toString >> box
  

    /// Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. 
    /// If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`.
    type CategoryOrder =
        | Trace | Ascending | Descending | Array
        
        static member toString = function
            | Trace      -> "trace"            
            | Ascending      -> "category ascending"            
            | Descending -> "category descending"
            | Array -> "array"

        static member convert = CategoryOrder.toString >> box

    /// Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
    type Visible =
        | True | False | LegendOnly
        
        static member toString = function
            | True       -> "true"            
            | False      -> "false"            
            | LegendOnly -> "legendonly"

        static member convert = Visible.toString >> box

    /// Determines which trace information appear on the graph and  on hove (HoverInfo)
    //Any combination of "label", "text", "value", "percent" joined with a "+" OR "none". 
    //examples: "label", "text", "label+text", "label+text+value", "none"
    type TextInfo =
        | All | None | Label | Text | Value | Percent
        
        static member toString = function
            | All     -> "all"
            | None    -> "none"
            | Label   -> "label"                        
            | Text    -> "text"                          
            | Value   -> "value"            
            | Percent -> "percent"

        static member convert = TextInfo.toString >> box

        static member toConcatString (o:seq<TextInfo>) =
            o |> Seq.map TextInfo.toString |> String.concat "+"

    /// Specifies the location of the `textinfo`.
    type TextInfoPosition =
        | Auto | Inside | Outside | None
        
        static member toString = function
            | Auto    -> "auto"
            | Inside  -> "inside"
            | Outside -> "outside"            
            | None    -> "none"            


        static member convert = TextInfoPosition.toString >> box

    /// Specifies the direction at which succeeding sectors follow one another.
    type Direction =
        | Clockwise | CounterClockwise 
        
        static member toString = function
            | Clockwise        -> "clockwise"
            | CounterClockwise -> "counterclockwise"

        static member convert = Direction.toString >> box


    /// Sets the type of normalization for this histogram trace. By default ('histnorm' set to '') the height of each bar 
    /// displays the frequency of occurrence, i.e., the number of times this value was found in the corresponding bin.
    /// If set to 'percent', the height of each bar displays the percentage of total occurrences found within the corresponding bin. 
    /// If set to 'probability', the height of each bar displays the probability that an event will fall into the corresponding bin. 
    /// If set to 'density', the height of each bar is equal to the number of occurrences in a bin divided by the size of the bin 
    /// interval such that summing the area of all bins will yield the total number of occurrences. If set to 'probability density', 
    /// the height of each bar is equal to the number of probability that an event will fall into the corresponding bin divided by 
    /// the size of the bin interval such that summing the area of all bins will yield 1.
    type HistNorm =
        | Percent | Probability | Density | ProbabilityDensity 
        
        static member toString = function
            | Percent            -> "percent"
            | Probability        -> "probability"
            | Density            -> "density"
            | ProbabilityDensity -> "probability density"

        static member convert = HistNorm.toString >> box


    /// Sets the binning function used for this histogram trace. The default value is 'count' where the histogram values are computed 
    /// by counting the number of values lying inside each bin. With 'histfunc' set to 'sum', 'avg', 'min' or 'max', the histogram values 
    /// are computed using the sum, the average, the minimum or the 'maximum' of the values lying inside each bin respectively.
    type HistFunc =
        | Count | Sum | Avg | Min | Max 
        
        static member toString = function
            | Count -> "count"
            | Sum   -> "sum"
            | Avg   -> "avg"
            | Min   -> "min"
            | Max   -> "max"

        static member convert = HistNorm.toString >> box


    /// Choose between algorithms ('best' or 'fast') to smooth data linked to 'z'. The default value is false corresponding to no smoothing.
    type SmoothAlg =
        | False | Best | Fast
        
        static member convert = function
            | False -> box false
            | Best  -> box "best"
            | Fast  -> box "fast"
                    


