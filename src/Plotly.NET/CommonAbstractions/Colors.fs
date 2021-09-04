namespace Plotly.NET
//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
open Newtonsoft.Json

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
        else raise <| ArgumentException()
    

    [<CompiledName("Encode")>]
    let encode (prefix:string) (color:byte array)  =
        let hex = Array.zeroCreate (color.Length * 2)
        let mutable n = 0
        for i = 0 to color.Length - 1 do
            hex.[n] <- toHexDigit ((int color.[i] &&& 0xF0) >>> 4)
            n <- n + 1
            hex.[n] <- toHexDigit (int color.[i] &&& 0xF)
            n <- n + 1
        String.Concat(prefix, String(hex))
    
                
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



/// Represents an ARGB (alpha, red, green, blue) color
[<JsonConverter(typeof<ARGBConverter>)>]
type ARGB = { 
    /// The alpha component value of this Color structure.
    A : byte
    /// The red component value of this Color structure.
    R : byte
    /// The green component value of this Color structure.
    G : byte
    /// The blue component value of this Color structure.
    B : byte       
    } with

    /// Creates a Argb Color from the four ARGB component (alpha, red, green, and blue) values.
    static member create a r g b =
        let fi v =
            if v < 0 || v > 255 then 
                failwithf "Value for component needs to be between 0 and 255."
            else
                byte v
        {A= fi a; R = fi r; G = fi g; B = fi b}

    /// Creates a Argb color from the specified color values (red, green, and blue).
    /// The alpha value is implicitly 255 (fully opaque). 
    static member fromRGB r g b =
        ARGB.create 255 r g b
               
    /// Gets the hex representataion (FFFFFF) of a color (with valid prefix "0xFFFFFF")
    static member toHex prefix (c:ARGB) =
        let prefix' = if prefix then "0x" else ""
        Hex.encode prefix' [|c.R;c.G;c.B|]

    /// Gets color from hex representataion (FFFFFF) or (0xFFFFFF)
    static member fromHex (s:string) =
        match (Hex.decode s) with
        | [|r;g;b|]  -> ARGB.fromRGB (int r) (int g) (int b)
        | _          -> failwithf "Invalid hex color format"

    /// Gets the web color representataion (#FFFFFF)
    static member toWebHex c =        
        Hex.encode "#" [|c.R;c.G;c.B|]                

    /// Gets color from web color (#FFFFFF)
    static member fromWebHex (s:string) =
        let s' = s.TrimStart([|'#'|])
        match (Hex.decode s') with
        | [|r;g;b|]  -> ARGB.fromRGB (int r) (int g) (int b)
        | _          -> failwithf "Invalid hex color format"

    /// Converts this Color structure to a human-readable string.
    static member toString c =        
        let a,r,g,b = (int c.A, int c.R, int c.G, int c.B)
        sprintf "{Alpha: %i Red: %i Green: %i Blue: %i}" a r g b

    static member fromKeyword (c:ColorKeyword) =
        c
        |> ColorKeyword.toRGB
        |> fun (r,g,b) -> ARGB.fromRGB r g b

and ARGBConverter() =
    inherit JsonConverter()

    override _.CanConvert(objectType) =       
        objectType = typeof<ARGB>      

    override _.ReadJson(reader, t, existingValue, serializer) =  
        raise (System.NotImplementedException())
        //unbox reader.Value

    override _.WriteJson(writer, value, serializer) =       
        let argb = value :?> ARGB
        //writer.WriteValue(sprintf "rgba(%i, %i, %i, %0.1f)" argb.R argb.G argb.B argb.A )
        writer.WriteValue(sprintf "rgba(%i, %i, %i, %0.1f)" argb.R argb.G argb.B (float argb.A / 255.))

/// Plotly color can be a single color, a sequence of colors, or a sequence of numeric values referencing the color of the colorscale obj
[<JsonConverter(typeof<ColorConverter>)>]
type Color private(obj:obj) =

    /// Creates a Color from the four ARGB component (alpha, red, green, and blue) values.
    static member fromARGB a r g b =
        ARGB.create a r g b
        |> unbox
        |> Color

    /// Creates a Color from the specified color values (red, green, and blue).
    /// The alpha value is implicitly 1. (fully opaque). 
    static member fromRGB r g b =
        Color.fromARGB 255 r g b

    /// Color from web color (#FFFFFF) or hex representataion (FFFFFF) / (0xFFFFFF)
    static member fromHex (s:string) =
        let s' = s.TrimStart('#')
        match (Hex.decode s') with
        | [|r;g;b|]  -> Color.fromRGB (int r) (int g) (int b)
        | _          -> failwithf "Invalid hex color format"

    /// Color 
    static member fromColors (c:seq<Color>) =
        let tmp =
            c |> Seq.map (fun v -> v.Value)
        Color (unbox tmp)

    /// Color from a raw string input, no check for correctness performed
    static member fromString (c:string) =
        Color (unbox c)

    /// Values are interpreted relative to color scale
    static member fromColorScaleValues (c:seq<System.IConvertible>) =
        Color (unbox c)

    /// Color from a standard web color keyword, e.g. White -> "white" (see //https://www.w3.org/TR/2011/REC-SVG11-20110816/types.html#ColorKeywords)
    static member fromKeyword (c: ColorKeyword) =
        Color (unbox (ARGB.fromKeyword c))

    override this.Equals(other) =
        match other with
        | :? Color as otherColor -> this.Value = otherColor.Value
        | _  -> false

    override this.GetHashCode() = this.Value.GetHashCode()

    /// extractor
    member this.Value = obj

and ColorConverter() =
    inherit JsonConverter()

    override _.CanConvert(objectType) =       
        objectType = typeof<Color>      

    override _.ReadJson(reader, t, existingValue, serializer) =  
        raise (System.NotImplementedException())
           
    override _.WriteJson(writer, value, serializer) =       
        let c  = value :?> Color
        let jc = JsonConvert.SerializeObject(c.Value)
        writer.WriteRawValue(jc)


// http://graphicdesign.stackexchange.com/questions/3682/where-can-i-find-a-large-palette-set-of-contrasting-colors-for-coloring-many-d
module Color = 
    module Table =    

        let black       = Color.fromRGB   0   0   0                
        let blackLite   = Color.fromRGB  89  89  89 // 35% lighter
        let white       = Color.fromRGB 255 255 255

        /// Color palette from Microsoft office 2016
        module Office = 
    
            // blue
            let blue        = Color.fromRGB  65 113 156        
            let lightBlue   = Color.fromRGB 189 215 238
            let darkBlue    = Color.fromRGB  68 114 196
                    
            // red           
            let red         = Color.fromRGB 241  90  96  
            let lightRed    = Color.fromRGB 252 212 214

            // orange           
            let orange      = Color.fromRGB 237 125  49
            let lightOrange = Color.fromRGB 248 203 173
                                                              
            // yellow        
            let yellow      = Color.fromRGB 255 217 102
            let lightYellow = Color.fromRGB 255 230 153
            let darkYellow  = Color.fromRGB 255 192   0
                     
            // green         
            let green       = Color.fromRGB 122 195 106
            let lightGreen  = Color.fromRGB 197 224 180
            let darkGreen   = Color.fromRGB 112 173  71

            // grey         
            let grey        = Color.fromRGB 165 165 165
            let lightGrey   = Color.fromRGB 217 217 217

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

