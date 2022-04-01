module PackageTasks

open ProjectInfo

open MessagePrompts
open BasicTasks
open TestTasks

open BlackFox.Fake
open Fake.Core
open Fake.IO.Globbing.Operators

let pack = BuildTask.create "Pack" [clean; build; runTests] {
    if promptYesNo (sprintf "creating stable package with version %s OK?" stableVersionTag ) 
        then
            !! "src/**/*.*proj"
            -- "src/bin/*"
            |> Seq.iter (Fake.DotNet.DotNet.pack (fun p ->
                let msBuildParams =
                    {p.MSBuildParams with 
                        Properties = ([
                            "Version",stableVersionTag
                            "PackageReleaseNotes",  (release.Notes |> String.concat "\r\n")
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

let packPrerelease = BuildTask.create "PackPrerelease" [setPrereleaseTag; clean; build; runTests] {
    if promptYesNo (sprintf "package tag will be %s OK?" prereleaseTag )
        then 
            !! "src/**/*.*proj"
            -- "src/bin/*"
            |> Seq.iter (Fake.DotNet.DotNet.pack (fun p ->
                        let msBuildParams =
                            {p.MSBuildParams with 
                                Properties = ([
                                    "Version", prereleaseTag
                                    "PackageReleaseNotes",  (release.Notes |> String.toLines )
                                ] @ p.MSBuildParams.Properties)
                            }
                        {
                            p with 
                                VersionSuffix = Some prereleaseSuffix
                                OutputPath = Some pkgDir
                                MSBuildParams = msBuildParams
                        }
            ))
    else
        failwith "aborted"
}