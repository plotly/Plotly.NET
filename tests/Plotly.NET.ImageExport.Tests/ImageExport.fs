module Tests.ImageExport

open Expecto
open Plotly.NET
open Plotly.NET.ImageExport

open System
open System.IO

let testBase64JPG   = File.ReadAllText (__SOURCE_DIRECTORY__ + "/data/testBase64JPG.txt")

let testBase64PNG   = 
    File.ReadAllBytes(__SOURCE_DIRECTORY__ + "/data/testPNG.png")
    |> Convert.ToBase64String

[<Tests>]
let ``Image export tests`` =
    // this has to run in sequence as the first call will establish chromium dependencies.
    // assigning exact equality on the produced images seems hard to do. 
    // the jpeg test for example works on windows, but produces a very slightly different base64 string on ubuntu.
    // This is very frustrating stuff.
    testSequencedGroup "ImageExport_Sequenced" (
        // skipping this for now, cannot make it work atm (pTestAsync -> testAsync for running it)
        testList "base64 strings" [
            ptestAsync "Chart.toBase64JPGStringAsync" {
                let! actual = (Chart.Point([1.,1.]) |> Chart.toBase64JPGStringAsync())

                return 
                    Expect.stringContains
                        actual
                        testBase64JPG
                        "Invalid base64 string for Chart.toBase64JPGStringAsync"
            }
            ptestAsync "Chart.toBase64PNGStringAsync" {
                let! actual = (Chart.Point([1.,1.]) |> Chart.toBase64PNGStringAsync())

                return 
                    Expect.stringContains
                        actual
                        testBase64JPG
                        "Invalid base64 string for Chart.toBase64PNGStringAsync"
            }
        ]
    )
