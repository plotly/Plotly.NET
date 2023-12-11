module PackageTasks

open ProjectInfo

open MessagePrompts
open BasicTasks
open TestTasks

open BlackFox.Fake
open Fake.Core
open Fake.DotNet
open Fake.IO.Globbing.Operators

let pack = BuildTask.create "Pack" [ clean; build; runTestsAll ] {
    projects
    |> List.iter (fun pInfo ->
        if promptYesNo $"creating stable package for {pInfo.Name}{System.Environment.NewLine}\tpackage version: {pInfo.PackageVersionTag}{System.Environment.NewLine}\tassembly version: {pInfo.AssemblyVersion}{System.Environment.NewLine}\tassembly informational version: {pInfo.AssemblyInformationalVersion}{System.Environment.NewLine} OK?" then
            pInfo.ProjFile
            |> Fake.DotNet.DotNet.pack (fun p ->
                let msBuildParams =
                    match pInfo.ReleaseNotes with
                    | Some r ->
                        { p.MSBuildParams with
                            Properties =
                                ([
                                    "Version",pInfo.PackageVersionTag
                                    "AssemblyVersion", pInfo.AssemblyVersion
                                    "AssemblyInformationalVersion", pInfo.AssemblyVersion
                                    "PackageReleaseNotes",  (r.Notes |> String.concat "\r\n")
                                    "TargetsForTfmSpecificContentInPackage", "" //https://github.com/dotnet/fsharp/issues/12320
                                    ]
                                    @ p.MSBuildParams.Properties)
                            DisableInternalBinLog = true
                        }
                    | _ ->
                        { p.MSBuildParams with
                            Properties =
                                ([
                                    "Version",pInfo.PackageVersionTag
                                    "AssemblyVersion", pInfo.AssemblyVersion
                                    "AssemblyInformationalVersion", pInfo.AssemblyVersion
                                    "TargetsForTfmSpecificContentInPackage", "" //https://github.com/dotnet/fsharp/issues/12320
                                    ]
                                    @ p.MSBuildParams.Properties)
                            DisableInternalBinLog = true
                        }
                        

                { p with
                    MSBuildParams = msBuildParams
                    OutputPath = Some pkgDir
                    NoBuild = true
                }
                |> DotNet.Options.withCustomParams (Some "--no-dependencies -tl")
            )
        else
            failwith "aborted"
        )
    }

let packPrerelease =
    BuildTask.create
        "PackPrerelease"
        [
            clean
            build
            runTestsAll
        ] {
        projects
        |> List.iter (fun pInfo ->
            printfn $"Please enter pre-release package suffix for {pInfo.Name}"
            let prereleaseSuffix = System.Console.ReadLine()
            pInfo.PackagePrereleaseTag <- sprintf "%s-%s" pInfo.PackageVersionTag prereleaseSuffix
            if promptYesNo $"creating prerelease package for {pInfo.Name}{System.Environment.NewLine}\tpackage version: {pInfo.PackagePrereleaseTag}{System.Environment.NewLine}\tassembly version: {pInfo.AssemblyVersion}{System.Environment.NewLine}\tassembly informational version: {pInfo.AssemblyInformationalVersion}{System.Environment.NewLine} OK?" then
                pInfo.ProjFile
                |> Fake.DotNet.DotNet.pack (fun p ->
                    let msBuildParams =
                        match pInfo.ReleaseNotes with
                        | Some r ->
                            { p.MSBuildParams with
                                Properties =
                                    ([
                                        "Version",pInfo.PackagePrereleaseTag
                                        "AssemblyVersion", pInfo.AssemblyVersion
                                        "InformationalVersion", pInfo.AssemblyInformationalVersion
                                        "PackageReleaseNotes",  (r.Notes |> String.concat "\r\n")
                                        "TargetsForTfmSpecificContentInPackage", "" //https://github.com/dotnet/fsharp/issues/12320
                                        ])
                                DisableInternalBinLog = true
                            }
                        | _ -> 
                            { p.MSBuildParams with
                                Properties =
                                    ([
                                        "Version",pInfo.PackagePrereleaseTag
                                        "AssemblyVersion", pInfo.AssemblyVersion
                                        "InformationalVersion", pInfo.AssemblyInformationalVersion
                                        "TargetsForTfmSpecificContentInPackage", "" //https://github.com/dotnet/fsharp/issues/12320
                                        ])
                                DisableInternalBinLog = true
                            }

                    { p with
                        VersionSuffix = Some prereleaseSuffix
                        OutputPath = Some pkgDir
                        MSBuildParams = msBuildParams
                        NoBuild = true
                    }
                    |> DotNet.Options.withCustomParams (Some "--no-dependencies  -tl")
                )
            else
                failwith "aborted"
        )
    }
