module FormattingTasks

open MessagePrompts
open ProjectInfo
open BasicTasks

open BlackFox.Fake
open Fake.Core
open Fake.DotNet
open Fake.Api
open Fake.Tools
open Fake.IO
open Fake.IO.Globbing.Operators

// files that will be formatted by fantomas
let sourceFiles =
    !! "src/Plotly.NET/**/*.fs"
    ++ "src/Plotly.NET.ImageExport/**/*.fs"
    ++ "src/Plotly.NET.Interactive/**/*.fs"
    -- "**/obj/**/*.*"
    -- "**/bin/**/*.*"

let ccheckFormat =
    BuildTask.create "CheckFormat" [] {
        let result =
            sourceFiles
            |> Seq.map (sprintf "\"%s\"")
            |> String.concat " "
            |> sprintf "%s --check"
            |> DotNet.exec id "fantomas"
    
        if result.ExitCode = 0 then
            Trace.log "No files need formatting"
        elif result.ExitCode = 99 then
            failwith "Some files need formatting, check output for more info"
        else
            Trace.logf "Errors while formatting: %A" result.Errors
         }

let format =
    BuildTask.create "Format" [] {
        let result =
            sourceFiles
            |> Seq.map (sprintf "\"%s\"")
            |> String.concat " "
            |> DotNet.exec id "fantomas"
    
        if not result.OK then
            printfn "Errors while formatting all files: %A" result.Messages
            }