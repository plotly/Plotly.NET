namespace Plotly.NET

///https://www.w3.org/TR/2011/REC-SVG11-20110816/types.html#ColorKeywords
///
///W3C Recognized color keyword names
type ColorKeyword =
    | AliceBlue               
    | AntiqueWhite            
    | Aqua                    
    | Aquamarine              
    | Azure                   
    | Beige                   
    | Bisque                  
    | Black                   
    | BlanchedAlmond          
    | Blue                    
    | Blueviolet              
    | Brown                   
    | BurlyWood               
    | CadetBlue               
    | Chartreuse              
    | Chocolate               
    | Coral                   
    | CornflowerBlue          
    | CornSilk                
    | Crimson                 
    | Cyan                    
    | DarkBlue                
    | DarkCyan                
    | DarkGoldenRod           
    | DarkGray                
    | DarkGreen               
    | DarkGrey                
    | DarkKhaki               
    | DarkMagenta             
    | Darkolivegreen          
    | DarkOrange              
    | DarkOrchid              
    | DarkRed                 
    | DarkSalmon              
    | DarkSeaGreen            
    | DarkSlateBlue           
    | DarkSlateGray           
    | DarkSlateGrey           
    | DarkTurquoise           
    | DarkViolet              
    | DeepPink                
    | DeepSkyBlue             
    | DimGray                 
    | DimGrey                 
    | DodgerBlue              
    | FireBrick               
    | FloralWhite             
    | ForestGreen             
    | Fuchsia                 
    | Gainsboro               
    | GhostWhite              
    | Gold                    
    | GoldenRod               
    | Gray                    
    | Grey                    
    | Green                   
    | GreenYellow             
    | Honeydew                
    | Hotpink                 
    | IndianRed               
    | Indigo                  
    | Ivory                   
    | Khaki                   
    | Lavender                
    | LavenderBlush           
    | LawnGreen               
    | LemonChiffon            
    | LightBlue               
    | LightCoral              
    | LightCyan               
    | LightGoldenRodYellow    
    | LightGray               
    | LightGreen              
    | LightGrey               
    | LightPink               
    | LightAalmon             
    | LightAeaGreen           
    | LightAkyBlue            
    | LightAlateGray          
    | LightslateGrey          
    | LightSteelBlue          
    | LightYellow             
    | Lime                    
    | Limegreen               
    | Linen                   
    | Magenta                 
    | Maroon                  
    | MediumAquamarine        
    | MediumBlue              
    | MediumOrchid            
    | MediumPurple            
    | MediumSeaGreen          
    | MediumSlateBlue         
    | MediumSpringGreen       
    | MediumTurquoise         
    | MediumVioletRed         
    | MidnightBlue            
    | MintCream               
    | MistyRose               
    | Moccasin                
    | NavajoWhite             
    | Navy                    
    | OldLace                 
    | Olive                   
    | OliveDrab               
    | Orange                  
    | OrangeRed               
    | Orchid                  
    | PaleGoldenRod           
    | PaleGreen               
    | PaleTurquoise           
    | PaleVioletRed           
    | PapayaWhip              
    | PeachPuff               
    | Peru                    
    | Pink                    
    | Plum                    
    | PowderBlue              
    | Purple                  
    | Red                     
    | RosyBrown               
    | RoyalBlue               
    | SaddleBrown             
    | Salmon                  
    | SandyBrown              
    | SeaGreen                
    | SeaShell                
    | Sienna                  
    | Silver                  
    | Skyblue                 
    | SlateBlue               
    | SlateGray               
    | SlateGrey               
    | Snow                    
    | SpringGreen             
    | SteelBlue               
    | Tan                     
    | Teal                    
    | Thistle                 
    | Tomato                  
    | Turquoise               
    | Violet                  
    | Wheat                   
    | White                   
    | WhiteSmoke              
    | Yellow                  
    | YellowGreen             
    
    static member internal ofRGB (r:int) (g:int) (b:int) = 
        match (r,g,b) with
        | (240, 248, 255)   -> AliceBlue               
        | (250, 235, 215)   -> AntiqueWhite            
        | (127, 255, 212)   -> Aquamarine              
        | (240, 255, 255)   -> Azure                   
        | (245, 245, 220)   -> Beige                   
        | (255, 228, 196)   -> Bisque                  
        | ( 0, 0, 0)        -> Black                   
        | (255, 235, 205)   -> BlanchedAlmond          
        | ( 0, 0, 255)      -> Blue                    
        | (138, 43, 226)    -> Blueviolet              
        | (165, 42, 42)     -> Brown                   
        | (222, 184, 135)   -> BurlyWood               
        | ( 95, 158, 160)   -> CadetBlue               
        | (127, 255, 0)     -> Chartreuse              
        | (210, 105, 30)    -> Chocolate               
        | (255, 127, 80)    -> Coral                   
        | (100, 149, 237)   -> CornflowerBlue          
        | (255, 248, 220)   -> CornSilk                
        | (220, 20, 60)     -> Crimson                 
        | ( 0, 255, 255)    -> Cyan                    
        | ( 0, 0, 139)      -> DarkBlue                
        | ( 0, 139, 139)    -> DarkCyan                
        | (184, 134, 11)    -> DarkGoldenRod           
        | ( 0, 100, 0)      -> DarkGreen               
        | (169, 169, 169)   -> DarkGray                
        | (189, 183, 107)   -> DarkKhaki               
        | (139, 0, 139)     -> DarkMagenta             
        | ( 85, 107, 47)    -> Darkolivegreen          
        | (255, 140, 0)     -> DarkOrange              
        | (153, 50, 204)    -> DarkOrchid              
        | (139, 0, 0)       -> DarkRed                 
        | (233, 150, 122)   -> DarkSalmon              
        | (143, 188, 143)   -> DarkSeaGreen            
        | ( 72, 61, 139)    -> DarkSlateBlue           
        | ( 47, 79, 79)     -> DarkSlateGray           
        | ( 0, 206, 209)    -> DarkTurquoise           
        | (148, 0, 211)     -> DarkViolet              
        | (255, 20, 147)    -> DeepPink                
        | ( 0, 191, 255)    -> DeepSkyBlue             
        | (105, 105, 105)   -> DimGray                 
        | ( 30, 144, 255)   -> DodgerBlue              
        | (178, 34, 34)     -> FireBrick               
        | (255, 250, 240)   -> FloralWhite             
        | ( 34, 139, 34)    -> ForestGreen             
        | (220, 220, 220)   -> Gainsboro               
        | (248, 248, 255)   -> GhostWhite              
        | (255, 215, 0)     -> Gold                    
        | (218, 165, 32)    -> GoldenRod               
        | (128, 128, 128)   -> Gray                    
        | ( 0, 128, 0)      -> Green                   
        | (173, 255, 47)    -> GreenYellow             
        | (240, 255, 240)   -> Honeydew                
        | (255, 105, 180)   -> Hotpink                 
        | (205, 92, 92)     -> IndianRed               
        | ( 75, 0, 130)     -> Indigo                  
        | (255, 255, 240)   -> Ivory                   
        | (240, 230, 140)   -> Khaki                   
        | (230, 230, 250)   -> Lavender                
        | (255, 240, 245)   -> LavenderBlush           
        | (124, 252, 0)     -> LawnGreen               
        | (255, 250, 205)   -> LemonChiffon            
        | (173, 216, 230)   -> LightBlue               
        | (240, 128, 128)   -> LightCoral              
        | (224, 255, 255)   -> LightCyan               
        | (250, 250, 210)   -> LightGoldenRodYellow    
        | (211, 211, 211)   -> LightGray               
        | (144, 238, 144)   -> LightGreen              
        | (255, 182, 193)   -> LightPink               
        | (255, 160, 122)   -> LightAalmon             
        | ( 32, 178, 170)   -> LightAeaGreen           
        | (135, 206, 250)   -> LightAkyBlue            
        | (119, 136, 153)   -> LightAlateGray          
        | (176, 196, 222)   -> LightSteelBlue          
        | (255, 255, 224)   -> LightYellow             
        | ( 0, 255, 0)      -> Lime                    
        | ( 50, 205, 50)    -> Limegreen               
        | (250, 240, 230)   -> Linen                   
        | (255, 0, 255)     -> Magenta                 
        | (128, 0, 0)       -> Maroon                  
        | (102, 205, 170)   -> MediumAquamarine        
        | ( 0, 0, 205)      -> MediumBlue              
        | (186, 85, 211)    -> MediumOrchid            
        | (147, 112, 219)   -> MediumPurple            
        | ( 60, 179, 113)   -> MediumSeaGreen          
        | (123, 104, 238)   -> MediumSlateBlue         
        | ( 0, 250, 154)    -> MediumSpringGreen       
        | ( 72, 209, 204)   -> MediumTurquoise         
        | (199, 21, 133)    -> MediumVioletRed         
        | ( 25, 25, 112)    -> MidnightBlue            
        | (245, 255, 250)   -> MintCream               
        | (255, 228, 225)   -> MistyRose               
        | (255, 228, 181)   -> Moccasin                
        | (255, 222, 173)   -> NavajoWhite             
        | ( 0, 0, 128)      -> Navy                    
        | (253, 245, 230)   -> OldLace                 
        | (128, 128, 0)     -> Olive                   
        | (107, 142, 35)    -> OliveDrab               
        | (255, 165, 0)     -> Orange                  
        | (255, 69, 0)      -> OrangeRed               
        | (218, 112, 214)   -> Orchid                  
        | (238, 232, 170)   -> PaleGoldenRod           
        | (152, 251, 152)   -> PaleGreen               
        | (175, 238, 238)   -> PaleTurquoise           
        | (219, 112, 147)   -> PaleVioletRed           
        | (255, 239, 213)   -> PapayaWhip              
        | (255, 218, 185)   -> PeachPuff               
        | (205, 133, 63)    -> Peru                    
        | (255, 192, 203)   -> Pink                    
        | (221, 160, 221)   -> Plum                    
        | (176, 224, 230)   -> PowderBlue              
        | (128, 0, 128)     -> Purple                  
        | (255, 0, 0)       -> Red                     
        | (188, 143, 143)   -> RosyBrown               
        | ( 65, 105, 225)   -> RoyalBlue               
        | (139, 69, 19)     -> SaddleBrown             
        | (250, 128, 114)   -> Salmon                  
        | (244, 164, 96)    -> SandyBrown              
        | ( 46, 139, 87)    -> SeaGreen                
        | (255, 245, 238)   -> SeaShell                
        | (160, 82, 45)     -> Sienna                  
        | (192, 192, 192)   -> Silver                  
        | (135, 206, 235)   -> Skyblue                 
        | (106, 90, 205)    -> SlateBlue               
        | (112, 128, 144)   -> SlateGray               
        | (255, 250, 250)   -> Snow                    
        | ( 0, 255, 127)    -> SpringGreen             
        | ( 70, 130, 180)   -> SteelBlue               
        | (210, 180, 140)   -> Tan                     
        | ( 0, 128, 128)    -> Teal                    
        | (216, 191, 216)   -> Thistle                 
        | (255, 99, 71)     -> Tomato                  
        | ( 64, 224, 208)   -> Turquoise               
        | (238, 130, 238)   -> Violet                  
        | (245, 222, 179)   -> Wheat                   
        | (255, 255, 255)   -> White                   
        | (245, 245, 245)   -> WhiteSmoke              
        | (255, 255, 0)     -> Yellow                  
        | (154, 205, 50)    -> YellowGreen             
        | _ -> failwith "input color has no standard color keyword"

    static member toRGB = function
        | AliceBlue               -> (240, 248, 255)
        | AntiqueWhite            -> (250, 235, 215)
        | Aqua                    -> ( 0, 255, 255)
        | Aquamarine              -> (127, 255, 212)
        | Azure                   -> (240, 255, 255)
        | Beige                   -> (245, 245, 220)
        | Bisque                  -> (255, 228, 196)
        | Black                   -> ( 0, 0, 0)
        | BlanchedAlmond          -> (255, 235, 205)
        | Blue                    -> ( 0, 0, 255)
        | Blueviolet              -> (138, 43, 226)
        | Brown                   -> (165, 42, 42)
        | BurlyWood               -> (222, 184, 135)
        | CadetBlue               -> ( 95, 158, 160)
        | Chartreuse              -> (127, 255, 0)
        | Chocolate               -> (210, 105, 30)
        | Coral                   -> (255, 127, 80)
        | CornflowerBlue          -> (100, 149, 237)
        | CornSilk                -> (255, 248, 220)
        | Crimson                 -> (220, 20, 60)
        | Cyan                    -> ( 0, 255, 255)
        | DarkBlue                -> ( 0, 0, 139)
        | DarkCyan                -> ( 0, 139, 139)
        | DarkGoldenRod           -> (184, 134, 11)
        | DarkGray                -> (169, 169, 169)
        | DarkGreen               -> ( 0, 100, 0)
        | DarkGrey                -> (169, 169, 169)
        | DarkKhaki               -> (189, 183, 107)
        | DarkMagenta             -> (139, 0, 139)
        | Darkolivegreen          -> ( 85, 107, 47)
        | DarkOrange              -> (255, 140, 0)
        | DarkOrchid              -> (153, 50, 204)
        | DarkRed                 -> (139, 0, 0)
        | DarkSalmon              -> (233, 150, 122)
        | DarkSeaGreen            -> (143, 188, 143)
        | DarkSlateBlue           -> ( 72, 61, 139)
        | DarkSlateGray           -> ( 47, 79, 79)
        | DarkSlateGrey           -> ( 47, 79, 79)
        | DarkTurquoise           -> ( 0, 206, 209)
        | DarkViolet              -> (148, 0, 211)
        | DeepPink                -> (255, 20, 147)
        | DeepSkyBlue             -> ( 0, 191, 255)
        | DimGray                 -> (105, 105, 105)
        | DimGrey                 -> (105, 105, 105)
        | DodgerBlue              -> ( 30, 144, 255)
        | FireBrick               -> (178, 34, 34)
        | FloralWhite             -> (255, 250, 240)
        | ForestGreen             -> ( 34, 139, 34)
        | Fuchsia                 -> (255, 0, 255)
        | Gainsboro               -> (220, 220, 220)
        | GhostWhite              -> (248, 248, 255)
        | Gold                    -> (255, 215, 0)
        | GoldenRod               -> (218, 165, 32)
        | Gray                    -> (128, 128, 128)
        | Grey                    -> (128, 128, 128)
        | Green                   -> ( 0, 128, 0)
        | GreenYellow             -> (173, 255, 47)
        | Honeydew                -> (240, 255, 240)
        | Hotpink                 -> (255, 105, 180)
        | IndianRed               -> (205, 92, 92)
        | Indigo                  -> ( 75, 0, 130)
        | Ivory                   -> (255, 255, 240)
        | Khaki                   -> (240, 230, 140)
        | Lavender                -> (230, 230, 250)
        | LavenderBlush           -> (255, 240, 245)
        | LawnGreen               -> (124, 252, 0)
        | LemonChiffon            -> (255, 250, 205)
        | LightBlue               -> (173, 216, 230)
        | LightCoral              -> (240, 128, 128)
        | LightCyan               -> (224, 255, 255)
        | LightGoldenRodYellow    -> (250, 250, 210)
        | LightGray               -> (211, 211, 211)
        | LightGreen              -> (144, 238, 144)
        | LightGrey               -> (211, 211, 211)
        | LightPink               -> (255, 182, 193)
        | LightAalmon             -> (255, 160, 122)
        | LightAeaGreen           -> ( 32, 178, 170)
        | LightAkyBlue            -> (135, 206, 250)
        | LightAlateGray          -> (119, 136, 153)
        | LightslateGrey          -> (119, 136, 153)
        | LightSteelBlue          -> (176, 196, 222)
        | LightYellow             -> (255, 255, 224)
        | Lime                    -> ( 0, 255, 0)
        | Limegreen               -> ( 50, 205, 50)
        | Linen                   -> (250, 240, 230)
        | Magenta                 -> (255, 0, 255)
        | Maroon                  -> (128, 0, 0)
        | MediumAquamarine        -> (102, 205, 170)
        | MediumBlue              -> ( 0, 0, 205)
        | MediumOrchid            -> (186, 85, 211)
        | MediumPurple            -> (147, 112, 219)
        | MediumSeaGreen          -> ( 60, 179, 113)
        | MediumSlateBlue         -> (123, 104, 238)
        | MediumSpringGreen       -> ( 0, 250, 154)
        | MediumTurquoise         -> ( 72, 209, 204)
        | MediumVioletRed         -> (199, 21, 133)
        | MidnightBlue            -> ( 25, 25, 112)
        | MintCream               -> (245, 255, 250)
        | MistyRose               -> (255, 228, 225)
        | Moccasin                -> (255, 228, 181)
        | NavajoWhite             -> (255, 222, 173)
        | Navy                    -> ( 0, 0, 128)
        | OldLace                 -> (253, 245, 230)
        | Olive                   -> (128, 128, 0)
        | OliveDrab               -> (107, 142, 35)
        | Orange                  -> (255, 165, 0)
        | OrangeRed               -> (255, 69, 0)
        | Orchid                  -> (218, 112, 214)
        | PaleGoldenRod           -> (238, 232, 170)
        | PaleGreen               -> (152, 251, 152)
        | PaleTurquoise           -> (175, 238, 238)
        | PaleVioletRed           -> (219, 112, 147)
        | PapayaWhip              -> (255, 239, 213)
        | PeachPuff               -> (255, 218, 185)
        | Peru                    -> (205, 133, 63)
        | Pink                    -> (255, 192, 203)
        | Plum                    -> (221, 160, 221)
        | PowderBlue              -> (176, 224, 230)
        | Purple                  -> (128, 0, 128)
        | Red                     -> (255, 0, 0)
        | RosyBrown               -> (188, 143, 143)
        | RoyalBlue               -> ( 65, 105, 225)
        | SaddleBrown             -> (139, 69, 19)
        | Salmon                  -> (250, 128, 114)
        | SandyBrown              -> (244, 164, 96)
        | SeaGreen                -> ( 46, 139, 87)
        | SeaShell                -> (255, 245, 238)
        | Sienna                  -> (160, 82, 45)
        | Silver                  -> (192, 192, 192)
        | Skyblue                 -> (135, 206, 235)
        | SlateBlue               -> (106, 90, 205)
        | SlateGray               -> (112, 128, 144)
        | SlateGrey               -> (112, 128, 144)
        | Snow                    -> (255, 250, 250)
        | SpringGreen             -> ( 0, 255, 127)
        | SteelBlue               -> ( 70, 130, 180)
        | Tan                     -> (210, 180, 140)
        | Teal                    -> ( 0, 128, 128)
        | Thistle                 -> (216, 191, 216)
        | Tomato                  -> (255, 99, 71)
        | Turquoise               -> ( 64, 224, 208)
        | Violet                  -> (238, 130, 238)
        | Wheat                   -> (245, 222, 179)
        | White                   -> (255, 255, 255)
        | WhiteSmoke              -> (245, 245, 245)
        | Yellow                  -> (255, 255, 0)
        | YellowGreen             -> (154, 205, 50)

    static member ofKeyWord = function
        | "aliceblue"               -> AliceBlue               
        | "antiquewhite"            -> AntiqueWhite            
        | "aqua"                    -> Aqua                    
        | "aquamarine"              -> Aquamarine              
        | "azure"                   -> Azure                   
        | "beige"                   -> Beige                   
        | "bisque"                  -> Bisque                  
        | "black"                   -> Black                   
        | "blanchedalmond"          -> BlanchedAlmond          
        | "blue"                    -> Blue                    
        | "blueviolet"              -> Blueviolet              
        | "brown"                   -> Brown                   
        | "burlywood"               -> BurlyWood               
        | "cadetblue"               -> CadetBlue               
        | "chartreuse"              -> Chartreuse              
        | "chocolate"               -> Chocolate               
        | "coral"                   -> Coral                   
        | "cornflowerblue"          -> CornflowerBlue          
        | "cornsilk"                -> CornSilk                
        | "crimson"                 -> Crimson                 
        | "cyan"                    -> Cyan                    
        | "darkblue"                -> DarkBlue                
        | "darkcyan"                -> DarkCyan                
        | "darkgoldenrod"           -> DarkGoldenRod           
        | "darkgray"                -> DarkGray                
        | "darkgreen"               -> DarkGreen               
        | "darkgrey"                -> DarkGrey                
        | "darkkhaki"               -> DarkKhaki               
        | "darkmagenta"             -> DarkMagenta             
        | "darkolivegreen"          -> Darkolivegreen          
        | "darkorange"              -> DarkOrange              
        | "darkorchid"              -> DarkOrchid              
        | "darkred"                 -> DarkRed                 
        | "darksalmon"              -> DarkSalmon              
        | "darkseagreen"            -> DarkSeaGreen            
        | "darkslateblue"           -> DarkSlateBlue           
        | "darkslategray"          ->  DarkSlateGray           
        | "darkslategrey"           -> DarkSlateGrey           
        | "darkturquoise"           -> DarkTurquoise           
        | "darkviolet"              -> DarkViolet              
        | "deeppink"                -> DeepPink                
        | "deepskyblue"             -> DeepSkyBlue             
        | "dimgray"                 -> DimGray                 
        | "dimgrey"                 -> DimGrey                 
        | "dodgerblue"              -> DodgerBlue              
        | "firebrick"               -> FireBrick               
        | "floralwhite"             -> FloralWhite             
        | "forestgreen"             -> ForestGreen             
        | "fuchsia"                 -> Fuchsia                 
        | "gainsboro"               -> Gainsboro               
        | "ghostwhite"              -> GhostWhite              
        | "gold"                    -> Gold                    
        | "goldenrod"               -> GoldenRod               
        | "gray"                    -> Gray                    
        | "grey"                    -> Grey                    
        | "green"                   -> Green                   
        | "greenyellow"             -> GreenYellow             
        | "honeydew"                -> Honeydew                
        | "hotpink"                 -> Hotpink                 
        | "indianred"               -> IndianRed               
        | "indigo"                  -> Indigo                  
        | "ivory"                   -> Ivory                   
        | "khaki"                   -> Khaki                   
        | "lavender"                -> Lavender                
        | "lavenderblush"           -> LavenderBlush           
        | "lawngreen"               -> LawnGreen               
        | "lemonchiffon"            -> LemonChiffon            
        | "lightblue"               -> LightBlue               
        | "lightcoral"              -> LightCoral              
        | "lightcyan"               -> LightCyan               
        | "lightgoldenrodyellow"    -> LightGoldenRodYellow    
        | "lightgray"               -> LightGray               
        | "lightgreen"              -> LightGreen              
        | "lightgrey"               -> LightGrey               
        | "lightpink"               -> LightPink               
        | "lightsalmon"             -> LightAalmon             
        | "lightseagreen"           -> LightAeaGreen           
        | "lightskyblue"            -> LightAkyBlue            
        | "lightslategray"          -> LightAlateGray          
        | "lightslategrey"          -> LightslateGrey          
        | "lightsteelblue"          -> LightSteelBlue          
        | "lightyellow"             -> LightYellow             
        | "lime"                    -> Lime                    
        | "limegreen"               -> Limegreen               
        | "linen"                   -> Linen                   
        | "magenta"                 -> Magenta                 
        | "maroon"                  -> Maroon                  
        | "mediumaquamarine"        -> MediumAquamarine        
        | "mediumblue"              -> MediumBlue              
        | "mediumorchid"            -> MediumOrchid            
        | "mediumpurple"            -> MediumPurple            
        | "mediumseagreen"          -> MediumSeaGreen          
        | "mediumslateblue"         -> MediumSlateBlue         
        | "mediumspringgreen"       -> MediumSpringGreen       
        | "mediumturquoise"         -> MediumTurquoise         
        | "mediumvioletred"         -> MediumVioletRed         
        | "midnightblue"            -> MidnightBlue            
        | "mintcream"               -> MintCream               
        | "mistyrose"               -> MistyRose               
        | "moccasin"                -> Moccasin                
        | "navajowhite"             -> NavajoWhite             
        | "navy"                    -> Navy                    
        | "oldlace"                 -> OldLace                 
        | "olive"                   -> Olive                   
        | "olivedrab"               -> OliveDrab               
        | "orange"                  -> Orange                  
        | "orangered"               -> OrangeRed               
        | "orchid"                  -> Orchid                  
        | "palegoldenrod"           -> PaleGoldenRod           
        | "palegreen"               -> PaleGreen               
        | "paleturquoise"           -> PaleTurquoise           
        | "palevioletred"           -> PaleVioletRed           
        | "papayawhip"              -> PapayaWhip              
        | "peachpuff"               -> PeachPuff               
        | "peru"                    -> Peru                    
        | "pink"                    -> Pink                    
        | "plum"                    -> Plum                    
        | "powderblue"              -> PowderBlue              
        | "purple"                  -> Purple                  
        | "red"                     -> Red                     
        | "rosybrown"               -> RosyBrown               
        | "royalblue"               -> RoyalBlue               
        | "saddlebrown"             -> SaddleBrown             
        | "salmon"                  -> Salmon                  
        | "sandybrown"              -> SandyBrown              
        | "seagreen"                -> SeaGreen                
        | "seashell"                -> SeaShell                
        | "sienna"                  -> Sienna                  
        | "silver"                  -> Silver                  
        | "skyblue"                 -> Skyblue                 
        | "slateblue"               -> SlateBlue               
        | "slategray"               -> SlateGray               
        | "slategrey"               -> SlateGrey               
        | "snow"                    -> Snow                    
        | "springgreen"             -> SpringGreen             
        | "steelblue"               -> SteelBlue               
        | "tan"                     -> Tan                     
        | "teal"                    -> Teal                    
        | "thistle"                 -> Thistle                 
        | "tomato"                  -> Tomato                  
        | "turquoise"               -> Turquoise               
        | "violet"                  -> Violet                  
        | "wheat"                   -> Wheat                   
        | "white"                   -> White                   
        | "whitesmoke"              -> WhiteSmoke              
        | "yellow"                  -> Yellow                  
        | "yellowgreen"             -> YellowGreen             
        | _                         -> failwith "not a valid color keyword"

