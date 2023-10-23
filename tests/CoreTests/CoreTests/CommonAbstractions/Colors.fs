module Tests.CommonAbstractions.Colors

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Newtonsoft.Json

let testARGB = ARGB.fromRGB 255 255 255

let testKeywordARGB = ARGB.fromKeyword ColorKeyword.Cyan

[<Tests>]
let ``ARGB tests`` =
    testList "CommonAbstractions.ARGB tests" [
        testCase "WebHex" (fun () -> Expect.equal (testARGB |> ARGB.toWebHex) "#FFFFFF" "ARGB not correctly converted to web hex")
        testCase "HexBase" (fun () -> Expect.equal (testARGB |> ARGB.toHex true) "0xFFFFFF" "ARGB not correctly converted to hex")
        testCase "Keyword" (fun () -> Expect.equal (testKeywordARGB |> ARGB.toWebHex) "#00FFFF" "ARGB from keyword not correctly converted to hex")
    ]

[<Tests>]
let ``Colors tests`` =
    testList "CommonAbstractions.Color JSON tests" [
        testCase "fromString" (fun () ->
            let testColor = Color.fromString "red" |> JsonConvert.SerializeObject
            Expect.equal testColor "\"red\"" "Color.fromString not correctly serialized"
        )        
        testCase "fromARGB" (fun () ->
            let testColor = Color.fromARGB 255 255 255 255 |> JsonConvert.SerializeObject
            Expect.equal testColor "\"rgba(255, 255, 255, 1.0)\"" "Color.fromARGB not correctly serialized"
        )                
        testCase "fromRGB" (fun () ->
            let testColor = Color.fromRGB 255 255 255 |> JsonConvert.SerializeObject
            Expect.equal testColor "\"rgba(255, 255, 255, 1.0)\"" "Color.fromRGB not correctly serialized"
        )        
        testCase "fromHex" (fun () ->
            let testColor = Color.fromHex "#FFFFFF" |> JsonConvert.SerializeObject
            Expect.equal testColor "\"rgba(255, 255, 255, 1.0)\"" "Color.fromHex not correctly serialized"
        )        
        testCase "fromKeyword" (fun () ->
            let testColor = Color.fromKeyword ColorKeyword.Cyan |> JsonConvert.SerializeObject
            Expect.equal testColor "\"rgba(0, 255, 255, 1.0)\"" "Color.fromKeyword not correctly serialized"
        )        
        testCase "fromColors" (fun () ->
            let testColor = 
                Color.fromColors [
                    Color.fromString "red"
                    Color.fromARGB 255 255 255 255
                    Color.fromHex "#FFFFFF"
                    Color.fromKeyword ColorKeyword.Cyan
                ] 
                |> JsonConvert.SerializeObject
            Expect.equal testColor """["red","rgba(255, 255, 255, 1.0)","rgba(255, 255, 255, 1.0)","rgba(0, 255, 255, 1.0)"]""" "Color.fromColors not correctly serialized"
        )        
        testCase "fromColorScaleValues" (fun () ->
            let testColor = 
                Color.fromColorScaleValues [
                    1;2;3;4;5;6
                ] 
                |> JsonConvert.SerializeObject
            Expect.equal testColor """[1,2,3,4,5,6]""" "Color.fromColorScaleValues not correctly serialized"
        )
    ]
    