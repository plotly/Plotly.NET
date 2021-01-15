#r "paket:
nuget BlackFox.Fake.BuildTask
nuget Fake.Core.Target
nuget Fake.Core.Process
nuget Fake.Core.ReleaseNotes
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.DotNet.MSBuild
nuget Fake.DotNet.AssemblyInfoFile
nuget Fake.DotNet.Paket
nuget Fake.DotNet.FSFormatting
nuget Fake.DotNet.Fsi
nuget Fake.DotNet.NuGet
nuget Fake.Api.Github
nuget Fake.DotNet.Testing.Expecto //"

#if !FAKE
#load "./.fake/build.fsx/intellisense.fsx"
#r "netstandard" // Temp fix for https://github.com/dotnet/fsharp/issues/5216
#endif

open BlackFox.Fake
open System.IO
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators

let runDotNet cmd workingDir =
    let result =
        DotNet.exec (DotNet.Options.withWorkingDirectory workingDir) cmd ""
    if result.ExitCode <> 0 then failwithf "'dotnet %s' failed in %s" cmd workingDir

let project = "Plotly.NET"

let testProject = "tests/Plotly.NET.Tests/Plotly.NET.Tests.fsproj"

let summary = "A F# interactive charting library using plotly.js"

let solutionFile  = "Plotly.NET.sln"

let configuration = "Release"

// Git configuration (used for publishing documentation in gh-pages branch)
// The profile where the project is posted
let gitOwner = "plotly"
let gitHome = sprintf "%s/%s" "https://github.com" gitOwner

let gitName = "Plotly.NET"

let website = "/Plotly.NET"

let pkgDir = "pkg"

let release = ReleaseNotes.load "RELEASE_NOTES.md"

let stableVersion   = SemVer.parse release.NugetVersion

[<AutoOpen>]
module MessagePrompts =

    let prompt (msg:string) =
        System.Console.Write(msg)
        System.Console.ReadLine().Trim()
        |> function | "" -> None | s -> Some s
        |> Option.map (fun s -> s.Replace ("\"","\\\""))

    let rec promptYesNo msg =
        match prompt (sprintf "%s [Yn]: " msg) with
        | Some "Y" | Some "y" -> true
        | Some "N" | Some "n" -> false
        | _ -> System.Console.WriteLine("Sorry, invalid answer"); promptYesNo msg

    let releaseMsg = """This will stage all uncommitted changes, push them to the origin and bump the release version to the latest number in the RELEASE_NOTES.md file. 
        Do you want to continue?"""

    let releaseDocsMsg = """This will push the docs to gh-pages. Remember building the docs prior to this. Do you want to continue?"""

let clean = BuildTask.create "Clean" [] {
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "pkg"
    ++ "bin"
    |> Shell.cleanDirs 
}

let cleanDocs = BuildTask.create "CleanDocs" [] {
    !! "output"
    |> Shell.cleanDirs 
}

let build = BuildTask.create "Build" [clean] {
    solutionFile
    |> DotNet.build id
}

let copyBinaries = BuildTask.create "CopyBinaries" [clean; build] {
    let targets = 
        !! "src/**/*.??proj"
        -- "src/**/*.shproj"
        |>  Seq.map (fun f -> ((Path.getDirectory f) </> "bin" </> configuration, "bin" </> (Path.GetFileNameWithoutExtension f)))
    for i in targets do printfn "%A" i
    targets
    |>  Seq.iter (fun (fromDir, toDir) -> Shell.copyDir toDir fromDir (fun _ -> true))
}

let pack = BuildTask.create "Pack" [clean; build] {
    if promptYesNo (sprintf "creating stable package with version %i.%i.%i OK?" stableVersion.Major stableVersion.Minor stableVersion.Patch ) then
        !! "src/**/*.*proj"
        |> Seq.iter (Fake.DotNet.DotNet.pack (fun p ->
            let msBuildParams =
                {p.MSBuildParams with 
                    Properties = ([
                        "Version",(sprintf "%i.%i.%i" stableVersion.Major stableVersion.Minor stableVersion.Patch )
                    ] @ p.MSBuildParams.Properties)
                }
            {
                p with 
                    MSBuildParams = msBuildParams
                    OutputPath = Some pkgDir
            }
        ))
    else failwith "aborted"
}

let packPrerelease = BuildTask.create "PackPrerelease" [clean; build] {
    !! "src/**/*.*proj"
    |> Seq.iter (Fake.DotNet.DotNet.pack (fun p ->
        printfn "Please enter pre-release package suffix"
        let suffix = System.Console.ReadLine()
        let prereleaseTag = (sprintf "%s-%s" release.NugetVersion suffix)
        if promptYesNo (sprintf "package tag will be %s OK?" prereleaseTag )
            then 
                let msBuildParams =
                    {p.MSBuildParams with 
                        Properties = ([
                            "Version", prereleaseTag
                        ] @ p.MSBuildParams.Properties)
                    }
                {
                    p with 
                        VersionSuffix = Some suffix
                        OutputPath = Some pkgDir
                        MSBuildParams = msBuildParams
                }
            else
                failwith "aborted"
    ))
}

// --------------------------------------------------------------------------------------
// Generate the documentation

let docs = BuildTask.create "BuildDocs" [cleanDocs; build; copyBinaries] {
    runDotNet "fsdocs build --eval --property Configuration=Release" "./"
}

let watchDocs = BuildTask.create "WatchDocs" [cleanDocs; build; copyBinaries] {
   runDotNet "fsdocs watch --eval --property Configuration=Release" "./"
}

let runTests = BuildTask.create "RunTests" [clean; build; copyBinaries] {
    let standardParams = Fake.DotNet.MSBuild.CliArguments.Create ()
    Fake.DotNet.DotNet.test(fun testParams ->
        {
            testParams with
                Logger = Some "console;verbosity=detailed"
        }
    ) testProject
}

// let runTestsWithCodeCov = BuildTask.create "RunTestsWithCodeCov" [clean; build; copyBinaries] {
//     let standardParams = Fake.DotNet.MSBuild.CliArguments.Create ()
//     Fake.DotNet.DotNet.test(fun testParams ->
//         {
//             testParams with
//                 MSBuildParams = {
//                     standardParams with
//                         Properties = [
//                             "AltCover","true"
//                             "AltCoverCobertura","../../codeCov.xml"
//                             "AltCoverForce","true"
//                         ]
//                 };
//                 Logger = Some "console;verbosity=detailed"
//         }
//     ) testProject
//}

let _all = BuildTask.createEmpty "All" [clean; cleanDocs; build; copyBinaries; runTests (*runTestsWithCodeCov*); pack; docs]

BuildTask.runOrDefault copyBinaries