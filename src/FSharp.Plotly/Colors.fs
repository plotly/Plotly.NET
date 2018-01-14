namespace FSharp.Plotly
//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
/// Represents an ARGB (alpha, red, green, blue) color
module Colors =   

    module internal Hex =
    
        open System

        [<CompiledName("ToHexDigit")>]
        let toHexDigit n =
            if n < 10 then char (n + 0x30) else char (n + 0x37)
    
        [<CompiledName("FromHexDigit")>]
        let fromHexDigit c =
            if c >= '0' && c <= '9' then int c - int '0'
            elif c >= 'A' && c <= 'F' then (int c - int 'A') + 10
            elif c >= 'a' && c <= 'f' then (int c - int 'a') + 10
            else raise <| new ArgumentException()
        
    //    [<CompiledName("Encode")>]
    //    let encode (buf:byte array) (prefix:bool) =
    //        let hex = Array.zeroCreate (buf.Length * 2)
    //        let mutable n = 0
    //        for i = 0 to buf.Length - 1 do
    //            hex.[n] <- toHexDigit ((int buf.[i] &&& 0xF0) >>> 4)
    //            n <- n + 1
    //            hex.[n] <- toHexDigit (int buf.[i] &&& 0xF)
    //            n <- n + 1
    //        if prefix then String.Concat("0x", new String(hex)) 
    //        else new String(hex)
        [<CompiledName("Encode")>]
        let encode (prefix:string) (color:byte array)  =
            let hex = Array.zeroCreate (color.Length * 2)
            let mutable n = 0
            for i = 0 to color.Length - 1 do
                hex.[n] <- toHexDigit ((int color.[i] &&& 0xF0) >>> 4)
                n <- n + 1
                hex.[n] <- toHexDigit (int color.[i] &&& 0xF)
                n <- n + 1
            String.Concat(prefix, new String(hex))
        
                    
        [<CompiledName("Decode")>]
        let decode (s:string) =
            match s with
            | null -> nullArg "s"
            | _ when s.Length = 0 -> Array.empty
            | _ ->
                let mutable len = s.Length
                let mutable i = 0
                if len >= 2 && s.[0] = '0' && (s.[1] = 'x' || s.[1] = 'X') then do
                    len <- len - 2
                    i <- i + 2
                if len % 2 <> 0 then invalidArg "s" "Invalid hex format"
                else
                    let buf = Array.zeroCreate (len / 2)
                    let mutable n = 0
                    while i < s.Length do
                        buf.[n] <- byte (((fromHexDigit s.[i]) <<< 4) ||| (fromHexDigit s.[i + 1]))
                        i <- i + 2
                        n <- n + 1
                    buf

    
    /// Color component ARGB
    type ColorComponent =
        | A of byte
        | R of byte
        | G of byte
        | B of byte 
    
    let getValueFromCC cc =
        match cc with
        | A v -> v
        | R v -> v
        | G v -> v
        | B v -> v

    /// Color structure
    type Color = {
        /// The alpha component value of this Color structure.
        A : byte
        /// The red component value of this Color structure.
        R : byte
        /// The green component value of this Color structure.
        G : byte
        /// The blue component value of this Color structure.
        B : byte
        }
            
    
    let maxRGB c =
        let r,g,b = R c.R,G c.G,B c.B
        max r g |> max b

    let minRGB c =
        let r,g,b = R c.R,G c.G,B c.B
        min r g |> min b
        


    /// Creates a Color structure from the four ARGB component (alpha, red, green, and blue) values.
    let fromArgb a r g b =
        let f v =
            if v < 0 || v > 255 then 
                failwithf "Value for component needs to be between 0 and 255."
            else
                byte v
        {A= f a; R = f r; G = f g; B = f b}

    /// Creates a Color structure from the specified color values (red, green, and blue).
    /// The alpha value is implicitly 255 (fully opaque). 
    let fromRgb r g b =
        fromArgb 255 r g b

//    /// Gets the hue-saturation-brightness (HSB) brightness value for this Color structure.
//    let getBrightness = ()

    /// Gets the hue-saturation-brightness (HSB) hue value, in degrees, for this Color structure.
    let getHue c =
        let min = minRGB c |> getValueFromCC
        match maxRGB c with
        | R r -> float (c.G - c.B) / float (r - min)
        | G g -> 2.0 + float (c.B - c. R) / float (g - min)
        | B b -> 4.0 + float (c.R - c.G) / float (b - min)
        | _   -> failwithf "" // can't be


    /// Gets the hue-saturation-brightness (HSB) saturation value for this Color structure.
    let getSaturation col =
        let minimum = minRGB col
        let maximum = maxRGB col
        float (getValueFromCC minimum + getValueFromCC maximum) / 2.
        |> round
           
    /// Gets the 32-bit ARGB value of this Color structure.
    let toArgb c =
        (int c.A, int c.R, int c.G, int c.B)
    
    /// Gets the hex representataion (FFFFFF) of a color (with valid prefix "0xFFFFFF")
    let toHex prefix (c:Color) =
        let prefix' = if prefix then "0x" else ""
        Hex.encode prefix' [|c.R;c.G;c.B|]

    /// Gets color from hex representataion (FFFFFF) or (0xFFFFFF)
    let fromHex (s:string) =
        match (Hex.decode s) with
        | [|r;g;b|]  -> fromRgb (int r) (int g) (int b)
        | _          -> failwithf "Invalid hex color format"

    /// Gets the web color representataion (#FFFFFF)
    let toWebColor c =        
        Hex.encode "#" [|c.R;c.G;c.B|]                

    /// Gets color from web color (#FFFFFF)
    let fromWebColor (s:string) =
        let s' = s.TrimStart([|'#'|])
        match (Hex.decode s') with
        | [|r;g;b|]  -> fromRgb (int r) (int g) (int b)
        | _          -> failwithf "Invalid hex color format"


    /// Converts this Color structure to a human-readable string.
    let toString c =
        let a,r,g,b = toArgb c
        sprintf "{Alpha: %i Red: %i Green: %i Blue: %i}" a r g b


    // http://graphicdesign.stackexchange.com/questions/3682/where-can-i-find-a-large-palette-set-of-contrasting-colors-for-coloring-many-d
    module Table =    

        let black       = fromRgb   0   0   0                
        let blackLite   = fromRgb  89  89  89 // 35% lighter
        let white       = fromRgb 255 255 255

        /// Color palette from Microsoft office 2016
        module Office = 
        
            // blue
            let blue        = fromRgb  65 113 156        
            let lightBlue   = fromRgb 189 215 238
            let darkBlue    = fromRgb  68 114 196
                        
            // red           
            let red         = fromRgb 241  90  96  
            let lightRed    = fromRgb 252 212 214

            // orange           
            let orange      = fromRgb 237 125  49
            let lightOrange = fromRgb 248 203 173
                                                                  
            // yellow        
            let yellow      = fromRgb 255 217 102
            let lightYellow = fromRgb 255 230 153
            let darkYellow  = fromRgb 255 192   0
                         
            // green         
            let green       = fromRgb 122 195 106
            let lightGreen  = fromRgb 197 224 180
            let darkGreen   = fromRgb 112 173  71

            // grey         
            let grey        = fromRgb 165 165 165
            let lightGrey   = fromRgb 217 217 217

        // From publication: Escaping RGBland: Selecting Colors for Statistical Graphics
        // http://epub.wu.ac.at/1692/1/document.pdf
        module StatisticalGraphics24 =
            let a = 1
        // 
        //{2,63,165},{125,135,185},{190,193,212},{214,188,192},{187,119,132},{142,6,59},{74,111,227},{133,149,225},{181,187,227},{230,175,185},{224,123,145},{211,63,106},{17,198,56},{141,213,147},{198,222,199},{234,211,198},{240,185,141},{239,151,8},{15,207,192},{156,222,214},{213,234,231},{243,225,235},{246,196,225},{247,156,212}




//
//BrightPastel: 418CF0,FCB441,DF3A02,056492,BFBFBF,1A3B69,FFE382,129CDD,CA6B4B,005CDB,F3D288,506381,F1B9A8,E0830A,7893BE
//Berry: 8A2BE2,BA55D3,4169E1,C71585,0000FF,8019E0,DA70D6,7B68EE,C000C0,0000CD,800080
//Bright: 008000,0000FF,800080,800080,FF00FF,008080,FFFF00,808080,00FFFF,000080,800000,FF3939,7F7F00,C0C0C0,FF6347,FFE4B5
//BrightPastel: 418CF0,FCB441,DF3A02,056492,BFBFBF,1A3B69,FFE382,129CDD,CA6B4B,005CDB,F3D288,506381,F1B9A8,E0830A,7893BE
//Chocolate: A0522D,D2691E,8B0000,CD853F,A52A2A,F4A460,8B4513,C04000,B22222,B65C3A
//EarthTones: 33023,B8860B,C04000,6B8E23,CD853F,C0C000,228B22,D2691E,808000,20B2AA,F4A460,00C000,8FBC8B,B22222,843A05,C00000
//Excel: 9999FF,993366,FFFFCC,CCFFFF,660066,FF8080,0063CB,CCCCFF,000080,FF00FF,FFFF00,00FFFF,800080,800000,007F7F,0000FF
//Fire: FFD700,FF0000,FF1493,DC143C,FF8C00,FF00FF,FFFF00,FF4500,C71585,DDE221
//GrayScale: C8C8C8,BDBDBD,B2B2B2,A7A7A7,9C9C9C,919191,868686,7A7A7A,707070,656565,565656,4F4F4F,424242,393939,2E2E2E,232323
//Light: E6E6FA,FFF0F5,FFDAB9,,FFFACD,,FFE4E1,F0FFF0,F0F8FF,F5F5F5,FAEBD7,E0FFFF
//Pastel: 87CEEB,32CD32,BA55D3,F08080,4682B4,9ACD32,40E0D0,FF69B4,F0E68C,D2B48C,8FBC8B,6495ED,DDA0DD,5F9EA0,FFDAB9,FFA07A
//SeaGreen: 2E8B57,66CDAA,4682B4,008B8B,5F9EA0,38B16E,48D1CC,B0C4DE,8FBC8B,87CEEB
//SemiTransparent: FF6969,69FF69,6969FF,FFFF5D,69FFFF,FF69FF,CDB075,FFAFAF,AFFFAF,AFAFFF,FFFFAF,AFFFFF,FFAFFF,E4D5B5,A4B086,819EC1

