module Tests.ImageExport

open Expecto
open Plotly.NET
// open Plotly.NET.ImageExport

open System.IO

let testBase64JPG   = File.ReadAllText (__SOURCE_DIRECTORY__ + "/data/testBase64JPG.txt")
let testBase64PNG   = File.ReadAllText (__SOURCE_DIRECTORY__ + "/data/testBase64PNG.txt")

let testChart = Chart.Point([1.,1.])

//[<Tests>]
//let jpgTests =
//    testList "ImageExport_JPG" [
//        testCase "Chart.toBase64JPGString should create valid base64 JPG string" ( fun () ->
//            Expect.equal
//                (testChart |> Chart.toBase64JPGString())
//                testBase64JPG
//                "Nope"
//        )        
//    ]

//[<Tests>]
//let pngTests =
//    testList "ImageExport_PNG" [
//        testCase "Chart.toBase64PNGString should create valid base64 PNG string" ( fun () ->
//            Expect.equal
//                (testChart |> Chart.toBase64PNGString())
//                testBase64PNG
//                "Nope"
//        )        
//    ]