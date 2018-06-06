namespace FSharp.Plotly


// https://plot.ly/javascript/reference/
// https://plot.ly/javascript-graphing-library/reference/

module StyleParam =
    open System.Text.RegularExpressions

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

    /// Functions to manipulate StyleParam Mode
    module ModeUtils=
        
        /// Takes the current mode and adds the Text flag
        let showText isShow (cmode:Mode) =
            if isShow then 
                match cmode with
                | None          -> Mode.Text
                | Lines         -> Mode.Lines_Text
                | Lines_Markers -> Mode.Lines_Markers_Text
                | Markers       -> Mode.Markers_Text
                | _             -> cmode
            else
                cmode
        /// Takes the current mode and adds the Markers flag
        let showMarker isShow (cmode:Mode) =
            if isShow then 
                match cmode with
                | None          -> Mode.Markers
                | Lines         -> Mode.Lines_Markers
                | Lines_Text    -> Mode.Lines_Markers_Text            
                | Text          -> Mode.Markers_Text
                | _             -> cmode
            else
                cmode
                        
        /// Takes the current mode and adds the Lines flag
        let showLines isShow (cmode:Mode) =
            if isShow then 
                match cmode with
                | None          -> Mode.Lines
                | Markers       -> Mode.Lines_Markers
                | Markers_Text  -> Mode.Lines_Markers_Text
                | Text          -> Mode.Lines_Text
                | _             -> cmode
            else
                cmode


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


    type Jitterpoints = Boxpoints



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
        | Vertical

        static member convert = function
            | Horizontal -> box "h"
            | Vertical   -> box "v"

    /// The colorscale must be a collection containing a mapping of a normalized value (between 0.0 and 1.0) to it's color. At minimum, a mapping for the lowest (0.0) and highest (1.0) values are required. 
    type Colorscale =
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

    /// Only applies if cumulative is enabled. If "increasing" (default) we sum all prior bins, so the result increases from left to right.
    /// If "decreasing" we sum later bins so the result decreases from left to right.  default: "increasing"
    type CumulativeDirection =
        | Increasing | Decreasing 
        
        static member toString = function
            | Increasing  -> "increasing"
            | Decreasing  -> "decreasing"

        static member convert = CumulativeDirection.toString >> box

    /// Only applies if cumulative is enabled. Sets whether the current bin is included, excluded, or has half of its value included in 
    /// the current cumulative value. "include" is the default for compatibility with various other tools, however it introduces
    /// a half-bin bias to the results. "exclude" makes the opposite half-bin bias, and "half" removes it.
    type Currentbin =
        | Include | Exclude | Half 
        
        static member toString = function
            | Include -> "Include"
            | Exclude -> "Exclude"
            | Half    -> "Half"

        static member convert = Currentbin.toString >> box


    /// Sets the type of normalization for this histogram trace. By default ('histnorm' set to '') the height of each bar 
    /// displays the frequency of occurrence, i.e., the number of times this value was found in the corresponding bin.
    /// If set to 'percent', the height of each bar displays the percentage of total occurrences found within the corresponding bin. 
    /// If set to 'probability', the height of each bar displays the probability that an event will fall into the corresponding bin. 
    /// If set to 'density', the height of each bar is equal to the number of occurrences in a bin divided by the size of the bin 
    /// interval such that summing the area of all bins will yield the total number of occurrences. If set to 'probability density', 
    /// the height of each bar is equal to the number of probability that an event will fall into the corresponding bin divided by 
    /// the size of the bin interval such that summing the area of all bins will yield 1.
    /// default: None  
    type HistNorm =
        | None | Percent | Probability | Density | ProbabilityDensity 
        
        static member toString = function
            | None               -> ""
            | Percent            -> "percent"
            | Probability        -> "probability"
            | Density            -> "density"
            | ProbabilityDensity -> "probability density"

        static member convert = HistNorm.toString >> box


    /// Sets the binning function used for this histogram trace. The default value is 'count' where the histogram values are computed 
    /// by counting the number of values lying inside each bin. With 'histfunc' set to 'sum', 'avg', 'min' or 'max', the histogram values 
    /// are computed using the sum, the average, the minimum or the 'maximum' of the values lying inside each bin respectively.
    /// default: Count    
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
                    

    /// Sets this figure's behavior when a user hovers over it. When set to 'x', all data sharing the same 'x' coordinate will be shown on screen
    /// with corresponding trace labels. When set to 'y' all data sharing the same 'y' coordinates will be shown on the screen with corresponding
    /// trace labels. When set to 'closest', information about the data point closest to where the viewer is hovering will appear.
    type Hovermode =
        | Closest | X | Y 
        
        static member toString = function
            | Closest -> "closest"
            | X       -> "x"
            | Y       -> "y"


        static member convert = Hovermode.toString >> box



    /// Sets this figure's behavior when a user preforms a mouse 'drag' in the plot area. When set to 'zoom', a portion of the plot will be highlighted,
    /// when the viewer exits the drag, this highlighted section will be zoomed in on. When set to 'pan', data in the plot will move along with the viewers
    /// dragging motions. A user can always depress the 'shift' key to access the whatever functionality has not been set as the default. In 3D plots, the 
    /// default drag mode is 'rotate' which rotates the scene.
    type Dragmode =
        | Zoom | Pan | Rotate 
        
        static member toString = function
            | Zoom   -> "zoom"
            | Pan    -> "pan"
            | Rotate -> "rotate"


        static member convert = Dragmode.toString >> box


    /// For bar and histogram plots only. This sets how multiple bar objects are plotted together. In other words, this defines how bars at the same location
    /// appear on the plot. If set to 'stack' the bars are stacked on top of one another. If set to 'group', the bars are plotted next to one another, centered 
    /// around the shared location. If set to 'overlay', the bars are simply plotted over one another, you may need to set the opacity to see this.
    type Barmode =
        | Stack | Group | Overlay 
        
        static member toString = function
            | Stack   -> "stack"
            | Group   -> "group"
            | Overlay -> "overlay"


        static member convert = Barmode.toString >> box

    /// Defines a Range between min and max value 
    type Range =
        | MinMax of float * float
        | Values of array<float>
        
        static member convert = function
            | MinMax (min,max)   -> box [|min;max|]
            | Values  arr   -> box arr
 
 


    /// Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from ((`x0`+`x1`)/2, (`y0`+`y1`)/2))
    /// with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)
    /// If "path", draw a custom SVG path using `path`.          
    type ShapeType =
        | Circle | Rectangle | SvgPath | Line 
        
        static member toString = function
            | Circle    -> "circle"
            | Rectangle -> "rect"
            | SvgPath   -> "path"
            | Line      -> "line"


        static member convert = ShapeType.toString >> box


    /// Specifies whether shapes are drawn below or above traces. Default is Above
    type Layer =
        | Below | Above
        
        static member toString = function
            | Below   -> "below"
            | Above   -> "above"

        static member convert = Layer.toString >> box


    /// Sets the Delaunay axis, which is the axis that is perpendicular to the surface of the Delaunay triangulation.
    /// It has an effect if `i`, `j`, `k` are not provided and `alphahull` is set to indicate Delaunay triangulation. 
    /// Default is "z"
    type Delaunayaxis = 
        | X | Y | Z
        
        static member toString = function
            | X   -> "x"
            | Y   -> "y"
            | Z   -> "z"

        static member convert = Delaunayaxis.toString >> box


    /// Sets the calendar system to use with `x y z` date data. Default: "gregorian"
    type Calendar = 
        | Gregorian | Chinese | Coptic | Discworld | Ethiopian | Hebrew | Islamic | Julian    
        | Mayan | Nanakshahi | Nepali | Persian | Jalali | Taiwan | Thai | Ummalqura 
        
        static member toString = function
            | Gregorian  -> "gregorian" 
            | Chinese    -> "chinese" 
            | Coptic     -> "coptic" 
            | Discworld  -> "discworld" 
            | Ethiopian  -> "ethiopian" 
            | Hebrew     -> "hebrew" 
            | Islamic    -> "islamic" 
            | Julian     -> "julian" 
            | Mayan      -> "mayan" 
            | Nanakshahi -> "nanakshahi"
            | Nepali     -> "nepali" 
            | Persian    -> "persian" 
            | Jalali     -> "jalali" 
            | Taiwan     -> "taiwan" 
            | Thai       -> "thai" 
            | Ummalqura  -> "ummalqura"

        static member convert = Delaunayaxis.toString >> box

    /// 
    type AxisAnchorId = 
        | X of int 
        | Y of int 
        | Z of int
        | Free
        
        static member toString = function
            | X id  -> if id < 2 then "x" else sprintf "x%i" id
            | Y id  -> if id < 2 then "y" else sprintf "y%i" id
            | Z id  -> if id < 2 then "z" else sprintf "z%i" id
            | Free -> "free"

        static member convert = AxisAnchorId.toString >> box 

        //static member parse (str:string) =
        //    if str.Length > 0 then
        //        let no =  
        //            let sub = str.Substring(1,str.Length-1) 
        //            if sub.Length < 1 then 1 else sub |> int
        //        match str.ToUpper().Chars(0) with
        //        | 'X' -> AxisAnchorId.X no
        //        | 'Y' -> AxisAnchorId.Y no
        //        | 'Z' -> AxisAnchorId.Z no
        //        | _   -> failwithf "AxisAnchorId string must be in the form of x1|y1|z1..."
        //    else
        //        failwithf "AxisAnchorId string must not be empty."


        //static member toPropertyName = function
        //    | X id  -> if id < 2 then "xaxis" else sprintf "xaxis%i" id
        //    | Y id  -> if id < 2 then "yaxis" else sprintf "yaxis%i" id
        //    | Z id  -> if id < 2 then "zaxis" else sprintf "zaxis%i" id
        //    | Free -> failwithf "Axis property must not be 'free'."


    type AxisId = 
        | X of int 
        | Y of int 
        | Z of int
        
        static member toString = function
            | X id  -> if id < 2 then "xaxis" else sprintf "xaxis%i" id
            | Y id  -> if id < 2 then "yaxis" else sprintf "yaxis%i" id
            | Z id  -> if id < 2 then "zaxis" else sprintf "zaxis%i" id
        
        static member convert = AxisId.toString >> box 

    /// Determines the set of locations used to match entries in `locations` to regions on the map. Default: ISO-3
    type LocationFormat = 
        | CountryNames 
        | ISO_3
        | USA_states
        
        static member toString = function
            | CountryNames  -> "country names"
            | ISO_3         -> "ISO-3" 
            | USA_states    -> "USA-states"
        
        static member convert = LocationFormat.toString >> box 

// hoverinfo (flaglist string) 
//Any combination of "x", "y", "z", "text", "name" joined with a "+" OR "all" or "none" or "skip". 
//examples: "x", "y", "x+y", "x+y+z", "all" 
//default: "all" 
//Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.


    type ImageFormat =
        | SVG  | PNG | JPEG
        static member toString = function
            | SVG  -> "svg"             
            | PNG  -> "png"            
            | JPEG -> "jpeg"    

        static member convert = ImageFormat.toString >> box