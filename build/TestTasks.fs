module TestTasks

open BlackFox.Fake
open Fake.DotNet
open Fake.Core

open ProjectInfo
open BasicTasks

let createTestBuildTask (name: string) (deps: BuildTask.TaskInfo list) (projects: ProjectInfo list) =
    BuildTask.create name deps {
        projects
        |> List.iter (fun pInfo ->
            let proj = pInfo.ProjFile
            proj
            |> DotNet.build (fun p ->
                {
                    p with
                        MSBuildParams = { p.MSBuildParams with DisableInternalBinLog = true}
                }
                |> DotNet.Options.withCustomParams (Some "--no-dependencies -tl")
            )
        )
    }

let buildTestsAll = createTestBuildTask "BuildTestsAll" [clean; build] (testBaseProjects @ testProjectsCore @ testProjectsExtensionsLibs)

let buildTestsCore = createTestBuildTask "BuildTestsCore" [clean; build] (testBaseProjects @ testProjectsCore)

let buildTestsExtensionsLibs = createTestBuildTask "BuildTestsExtensionsLibs" [clean; build] (testBaseProjects @ testProjectsExtensionsLibs)


let createRunTestTask (name: string) (deps: BuildTask.TaskInfo list) (projects: ProjectInfo list) =
    BuildTask.create name deps {
        projects
        |> Seq.iter (fun testProjectInfo ->
            Fake.DotNet.DotNet.test
                (fun testParams ->
                    { testParams with
                        Logger = Some "console;verbosity=detailed"
                        Configuration = DotNet.BuildConfiguration.fromString configuration
                        NoBuild = true
                        MSBuildParams = { testParams.MSBuildParams with DisableInternalBinLog = true }
                    }
                    |> DotNet.Options.withCustomParams (Some "-tl")
                )
                testProjectInfo.ProjFile
        )
    }

let createRunTestFastTask (name: string) (projects: ProjectInfo list) =
    BuildTask.create name [] {
        Trace.trace $"Running {name} without Clean, while letting dotnet test handle restore and incremental builds."

        projects
        |> Seq.iter (fun testProjectInfo ->
            Fake.DotNet.DotNet.test
                (fun testParams ->
                    { testParams with
                        Logger = Some "console;verbosity=detailed"
                        Configuration = DotNet.BuildConfiguration.fromString configuration
                        MSBuildParams = { testParams.MSBuildParams with DisableInternalBinLog = true }
                    }
                    |> DotNet.Options.withCustomParams (Some "-tl")
                )
                testProjectInfo.ProjFile
        )
    }

let createRunSingleTestProjectFastTask (project: ProjectInfo) =
    createRunTestFastTask $"Run{project.Name}Fast" [ project ]

/// runs the all test projects via `dotnet test`
let runTestsAll = createRunTestTask "RunTestsAll" [ clean; build; buildTestsAll ] (testProjectsCore @ testProjectsExtensionsLibs)

/// runs the core test projects via `dotnet test`
let runTestsCore = createRunTestTask "RunTestsCore" [ clean; build; buildTestsCore; buildTestsCore] testProjectsCore

/// runs the extension lib test projects via `dotnet test`
let runTestsExtensionLibs = createRunTestTask "RunTestsExtensionLibs" [ clean; build; buildTestsExtensionsLibs] testProjectsExtensionsLibs

/// runs all test projects via incremental `dotnet test`, without cleaning first.
let runTestsAllFast = createRunTestFastTask "RunTestsAllFast" (testProjectsCore @ testProjectsExtensionsLibs)

/// runs core test projects via incremental `dotnet test`, without cleaning first.
let runTestsCoreFast = createRunTestFastTask "RunTestsCoreFast" testProjectsCore

/// runs extension lib test projects via incremental `dotnet test`, without cleaning first.
let runTestsExtensionLibsFast = createRunTestFastTask "RunTestsExtensionLibsFast" testProjectsExtensionsLibs

/// runs the ImageExportTests project via incremental `dotnet test`, without cleaning first.
let runImageExportTestsFast = createRunSingleTestProjectFastTask ImageExportTestProject

/// runs the CSharpTests project via incremental `dotnet test`, without cleaning first.
let runCSharpTestsFast = createRunSingleTestProjectFastTask CSharpTestProject
