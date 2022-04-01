open BlackFox.Fake
open System.IO
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Tools

open Helpers
open BasicTasks
open TestTasks
open PackageTasks
open DocumentationTasks
open ReleaseTasks

initializeContext ()

open FSharp.Compiler.Diagnostics
open BasicTasks

let verifyDocs =
    BuildTask.create "VerifyDocs" [ clean; build ] {
        let targets =
            !! "docs/**.fsx" |> Seq.map (fun f -> f.ToString())

        let checker =
            FSharp.Compiler.CodeAnalysis.FSharpChecker.Create()

        let ignoredDiagnostics = Set.ofList [ 1182 ] // unused variable

        targets
        |> Seq.map (fun target ->
            checker.Compile(
                [|
                    "fsc.exe"
                    "-o"
                    @"aaaaaaaaaaa.exe"
                    "-a"
                    target
                |]
            )
            |> Async.RunSynchronously
            |> fst
            |> Seq.where (fun diag ->
                match diag.Severity with
                | FSharpDiagnosticSeverity.Error
                | FSharpDiagnosticSeverity.Warning -> true
                | _ -> false))
        |> Seq.collect id
        |> Seq.where (fun c -> not (ignoredDiagnostics.Contains c.ErrorNumber))
        |> Seq.sortBy (fun diag ->
            (match diag.Severity with
             | FSharpDiagnosticSeverity.Error -> 0
             | _ -> 1),
            diag.FileName.[..6 (* to only count the numeric part *) ])
        |> Seq.map (fun diag ->
            (match diag.Severity with
             | FSharpDiagnosticSeverity.Error -> "--- Error: "
             | _ -> "--- Warning: ")
            + diag.ToString())
        |> String.concat "\n"
        |> (fun errorText ->
            match errorText with
            | "" -> ()
            | text -> raise (System.Exception $"Errors:\n{text}"))
    }

let sourceFiles =
    !! "src/Plotly.NET/**/*.fs"
    ++ "src/Plotly.NET.ImageExport/**/*.fs"
    ++ "src/Plotly.NET.Interactive/**/*.fs"
    ++ "build/*.fs"
    -- "**/obj/**/*.*"
    -- "**/bin/**/*.*"

let checkFormat =
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
            sourceFiles |> Seq.map (sprintf "\"%s\"") |> String.concat " " |> DotNet.exec id "fantomas"

        if not result.OK then
            printfn "Errors while formatting all files: %A" result.Messages
    }


/// Full release of nuget package, git tag, and documentation for the stable version.
let _release =
    BuildTask.createEmpty
        "Release"
        [
            clean
            build
            runTests
            pack
            buildDocs
            createTag
            publishNuget
            releaseDocs
        ]

/// Full release of nuget package, git tag, and documentation for the prerelease version.
let _preRelease =
    BuildTask.createEmpty
        "PreRelease"
        [
            setPrereleaseTag
            clean
            build
            runTests
            packPrerelease
            buildDocsPrerelease
            createPrereleaseTag
            publishNugetPrerelease
            prereleaseDocs
        ]

/// Full release of nuget package for the prerelease version.
let _releaseNoDocs =
    BuildTask.createEmpty
        "ReleaseNoDocs"
        [
            clean
            build
            runTests
            pack
            createTag
            publishNuget
        ]

/// Full release of nuget package for the prerelease version.
let _preReleaseNoDocs =
    BuildTask.createEmpty
        "PreReleaseNoDocs"
        [
            setPrereleaseTag
            clean
            build
            runTests
            packPrerelease
            createPrereleaseTag
            publishNugetPrerelease
        ]

[<EntryPoint>]
let main args = runOrDefault build args
