module Tests.ImageExport

open System.Runtime.InteropServices
open Expecto
open Plotly.NET
open Plotly.NET.ImageExport

open System
open System.IO

let readTestFilePlatformSpecific filePostfix =
    if RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
        let content = File.ReadAllText (__SOURCE_DIRECTORY__ + $"/data/linux{filePostfix}")
        content.Substring(0, content.Length - 1) // Because on Linux you're expected to newline terminate the file
    else if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
        File.ReadAllText (__SOURCE_DIRECTORY__ + $"/data/win{filePostfix}")
    else
        raise (Exception "Running tests on the current OS is not supported :(")

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
                let testBase64JPG = readTestFilePlatformSpecific "TestBase64JPG.txt"
                
                let! actual = (Chart.Point([1.,1.]) |> Chart.toBase64JPGStringAsync() |> Async.AwaitTask)

                return 
                    Expect.equal
                        actual
                        testBase64JPG
                        "Invalid base64 string for Chart.toBase64JPGStringAsync"
            }
            ptestAsync "Chart.toBase64PNGStringAsync" {
                let testBase64PNG = readTestFilePlatformSpecific "TestBase64PNG.txt"
                
                let! actual = (Chart.Point([1.,1.]) |> Chart.toBase64PNGStringAsync() |> Async.AwaitTask)

                return 
                    Expect.equal
                        actual
                        testBase64PNG
                        "Invalid base64 string for Chart.toBase64PNGStringAsync"
            }
            testCase "Chart.toBase64JPGString terminates" <| fun () ->
                let actual = Chart.Point([1.,1.]) |> Chart.toBase64JPGString()
                Expect.isTrue (actual.Length > 100) ""
            testCase "Chart.toBase64PNGString terminates" <| fun () ->
                let actual = Chart.Point([1.,1.]) |> Chart.toBase64PNGString()
                Expect.isTrue (actual.Length > 100) ""
            testCase "Chart.toSVGString terminates" <| fun () ->
                let actual = Chart.Point([1.,1.]) |> Chart.toSVGString()
                Expect.isTrue (actual.Length > 100) ""
        ]
    )
