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

open BasicTasks

//workaround for tasks created with functions not being runnable.

//let _ = TestTasks.buildTestsAll |> ignore
//let _ = TestTasks.buildTestsCore |> ignore
//let _ = TestTasks.buildTestsNetFX |> ignore
//let _ = TestTasks.buildTestsExtensionsLibs |> ignore

//let _ = TestTasks.runTestsAll |> ignore
//let _ = TestTasks.runTestsCore |> ignore
//let _ = TestTasks.runTestsNetFX |> ignore
//let _ = TestTasks.runTestsCoreWithNetFX |> ignore
//let _ = TestTasks.runTestsExtensionLibs |> ignore


let sourceFiles =
    !! "src/Plotly.NET/**/*.fs"
    ++ "src/Plotly.NET.ImageExport/**/*.fs"
    ++ "src/Plotly.NET.Interactive/**/*.fs"
    ++ "build/*.fs"
    -- "**/obj/**/*.*"
    -- "**/bin/**/*.*"

/// Full release of nuget package, git tag, and documentation for the stable version.
let _release =
    BuildTask.createEmpty
        "Release"
        [
            clean
            build
            runTestsAll
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
            runTestsAll
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
            runTestsAll
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
            runTestsAll
            packPrerelease
            createPrereleaseTag
            publishNugetPrerelease
        ]

[<EntryPoint>]
let main args = runOrDefault build args
