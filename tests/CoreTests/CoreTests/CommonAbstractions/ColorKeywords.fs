module Tests.CommonAbstractions.ColorKeywords

open Expecto
open Microsoft.FSharp.Reflection
open Newtonsoft.Json
open Plotly.NET

// RGB expectations come from the W3C SVG color keyword table:
// https://www.w3.org/TR/2011/REC-SVG11-20110816/types.html#ColorKeywords
let private correctedKeywords =
    [
        ColorKeyword.DarkOliveGreen, "darkolivegreen", (85, 107, 47), "\"rgba(85, 107, 47, 1.0)\""
        ColorKeyword.HoneyDew, "honeydew", (240, 255, 240), "\"rgba(240, 255, 240, 1.0)\""
        ColorKeyword.HotPink, "hotpink", (255, 105, 180), "\"rgba(255, 105, 180, 1.0)\""
        ColorKeyword.LightSalmon, "lightsalmon", (255, 160, 122), "\"rgba(255, 160, 122, 1.0)\""
        ColorKeyword.LightSeaGreen, "lightseagreen", (32, 178, 170), "\"rgba(32, 178, 170, 1.0)\""
        ColorKeyword.LightSkyBlue, "lightskyblue", (135, 206, 250), "\"rgba(135, 206, 250, 1.0)\""
        ColorKeyword.LightSlateGray, "lightslategray", (119, 136, 153), "\"rgba(119, 136, 153, 1.0)\""
        ColorKeyword.LightSlateGrey, "lightslategrey", (119, 136, 153), "\"rgba(119, 136, 153, 1.0)\""
        ColorKeyword.SkyBlue, "skyblue", (135, 206, 235), "\"rgba(135, 206, 235, 1.0)\""
    ]

[<Tests>]
let ``Color keyword corrections`` =
    testList "CommonAbstractions.ColorKeyword" [
        for keyword, css, (r, g, b), expectedJson in correctedKeywords do
            testCase $"{keyword} parsing and color conversions" (fun () ->
                Expect.equal (ColorKeyword.ofKeyWord css) keyword "CSS keyword should parse to the corrected case"
                Expect.equal (ColorKeyword.toRGB keyword) (r, g, b) "Keyword should map to its standard RGB value"

                let canonical =
                    if keyword = ColorKeyword.LightSlateGrey then ColorKeyword.LightSlateGray else keyword

                Expect.equal (ColorKeyword.ofRGB r g b) canonical "RGB lookup should return the canonical corrected case"
                Expect.equal
                    (ARGB.fromKeyword keyword)
                    { A = 255uy; R = byte r; G = byte g; B = byte b }
                    "ARGB conversion should preserve the keyword color"
                Expect.equal
                    (Color.fromKeyword keyword |> JsonConvert.SerializeObject)
                    expectedJson
                    "Color JSON should contain the standard RGBA value"
            )

        testCase "All current keywords round-trip through CSS names and RGB" (fun () ->
            for case in FSharpType.GetUnionCases typeof<ColorKeyword> do
                let keyword = FSharpValue.MakeUnion(case, [||]) :?> ColorKeyword
                let r, g, b = ColorKeyword.toRGB keyword
                Expect.equal
                    (ColorKeyword.ofKeyWord (case.Name.ToLowerInvariant()))
                    keyword
                    $"{case.Name} should parse from its CSS spelling"
                Expect.equal
                    (ColorKeyword.ofRGB r g b |> ColorKeyword.toRGB)
                    (r, g, b)
                    $"{case.Name} should round-trip through RGB, including synonymous names"
        )
    ]
