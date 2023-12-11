module BasicTasks

open BlackFox.Fake
open Fake.IO
open Fake.DotNet
open Fake.IO.Globbing.Operators

open ProjectInfo

/// Buildtask for setting a prerelease tag (also sets the mutable isPrerelease to true, and the PackagePrereleaseTag of all project infos accordingly.)
let setPrereleaseTag =
    BuildTask.create "SetPrereleaseTag" [] {
        printfn "Please enter pre-release package suffix"
        let suffix = System.Console.ReadLine()
        prereleaseSuffix <- suffix
        isPrerelease <- true
        projects
        |> List.iter (fun p ->
            p.PackagePrereleaseTag <- (sprintf "%s-%s" p.PackageVersionTag suffix)
        )
        // 
        prereleaseTag <- (sprintf "%s-%s" CoreProject.PackageVersionTag suffix)
    }

/// cleans the bin, obj/obj dir of all projects and test projects, as well as the pkg dir.
let clean =
    BuildTask.create "Clean" [] {
        !! "src/**/bin" ++ "src/**/obj" ++ "tests/**/bin" ++ "tests/**/obj" ++ "pkg" |> Shell.cleanDirs
    }

/// builds the solution file (dotnet build solution.sln)
let buildSolution =
    BuildTask.create "BuildSolution" [ clean ] { 
        solutionFile 
        |> DotNet.build (fun p ->
            let msBuildParams =
                {p.MSBuildParams with 
                    Properties = ([
                        "warnon", "3390"
                    ])
                    DisableInternalBinLog = true
                }
            {
                p with 
                    MSBuildParams = msBuildParams
                    
            }
            |> DotNet.Options.withCustomParams (Some "-tl")
        )
    }

/// builds the individual project files (dotnet build project.*proj)
///
/// The following MSBuild params are set for each project accordingly to the respective ProjectInfo:
///
/// - AssemblyVersion
///
/// - AssemblyInformationalVersion
let build = BuildTask.create "Build" [clean] {
    projects
    |> List.iter (fun pInfo ->
        let proj = pInfo.ProjFile
        proj
        |> DotNet.build (fun p ->
            let msBuildParams =
                {p.MSBuildParams with 
                    Properties = ([
                        "AssemblyVersion", pInfo.AssemblyVersion
                        "InformationalVersion", pInfo.AssemblyInformationalVersion
                        "warnon", "3390"
                    ])
                    DisableInternalBinLog = true
                }
            {
                p with 
                    MSBuildParams = msBuildParams
            }
            |> DotNet.Options.withCustomParams (Some "--no-dependencies -tl")
        )
    )
}