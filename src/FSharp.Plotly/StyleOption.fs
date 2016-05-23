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

        static member convert = box Mode.toString

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

        static member convert o = box (TextPosition.toString o)



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

        static member convert = box FontFamily.toString

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
        
        static member convert o = box (Shape.toString o)
    
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
        
        static member convert o = box (Fill.toString o)


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
                           



