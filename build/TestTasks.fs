module TestTasks

open BlackFox.Fake
open Fake.DotNet

open ProjectInfo
open BasicTasks

let buildTests = BuildTask.create "BuildTests" [clean; build] {
    testProjects
    |> List.iter (fun pInfo ->
        let proj = pInfo.ProjFile
        proj
        |> DotNet.build (fun p ->
            p
            |> DotNet.Options.withCustomParams (Some "--no-dependencies")
        )
    )
}

/// runs the individual test projects via `dotnet test`
let runTests =
    BuildTask.create "RunTests" [ clean; build; buildTests ] {
        testProjects
        |> Seq.iter (fun testProjectInfo ->
            Fake.DotNet.DotNet.test
                (fun testParams ->
                    { testParams with
                        Logger = Some "console;verbosity=detailed"
                        Configuration = DotNet.BuildConfiguration.fromString configuration
                        NoBuild = true
                    })
                testProjectInfo.ProjFile)
    }

// to do: use this once we have actual tests
let runTestsWithCodeCov =
    BuildTask.create "RunTestsWithCodeCov" [ clean; build ] {
        let standardParams =
            Fake.DotNet.MSBuild.CliArguments.Create()

        testProjects
        |> Seq.iter (fun testProjectInfo ->
            Fake.DotNet.DotNet.test
                (fun testParams ->
                    { testParams with
                        MSBuildParams =
                            { standardParams with
                                Properties =
                                    [
                                        "AltCover", "true"
                                        "AltCoverCobertura", "../../codeCov.xml"
                                        "AltCoverForce", "true"
                                    ]
                            }
                        Logger = Some "console;verbosity=detailed"
                    })
                testProjectInfo.ProjFile)
    }
