module TestTasks

open BlackFox.Fake
open Fake.DotNet

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

let buildTestsAll = createTestBuildTask "BuildTestsAll" [clean; build] (testBaseProjects @ testProjectsCore @ testProjectsExtensionsLibs @ testProjectsNetFX)

let buildTestsAllNoNetFX = createTestBuildTask "BuildTestsAllNoNetFX" [clean; build] (testBaseProjects @ testProjectsCore @ testProjectsExtensionsLibs)
   
let buildTestsCore = createTestBuildTask "BuildTestsCore" [clean; build] (testBaseProjects @ testProjectsCore)

let buildTestsNetFX = createTestBuildTask "BuildTestsNetFX" [clean; build] (testBaseProjects @ testProjectsNetFX)

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

/// runs the all test projects via `dotnet test`
let runTestsAll = createRunTestTask "RunTestsAll" [ clean; build; buildTestsAll ] (testProjectsCore @ testProjectsExtensionsLibs @ testProjectsNetFX)

/// runs the all test projects except those targeting netfx via `dotnet test`
let runTestsAllNoNetFX = createRunTestTask "RunTestsAllNoNetFX" [ clean; build; buildTestsAllNoNetFX ] (testProjectsCore @ testProjectsExtensionsLibs)

/// runs the core test projects via `dotnet test`
let runTestsCore = createRunTestTask "RunTestsCore" [ clean; build; buildTestsCore; buildTestsCore] testProjectsCore 

/// runs the core netfx test projects via `dotnet test`
let runTestsNetFX = createRunTestTask "RunTestsNetFX" [ clean; build; buildTestsNetFX;] testProjectsNetFX

/// runs the core and core netfx test projects via `dotnet test`
let runTestsCoreWithNetFX = createRunTestTask "RunTestsCoreWithNetFX" [ clean; build; buildTestsCore; buildTestsNetFX;] (testProjectsCore @ testProjectsNetFX)

/// runs the extension lib test projects via `dotnet test`
let runTestsExtensionLibs = createRunTestTask "RunTestsExtensionLibs" [ clean; build; buildTestsExtensionsLibs] testProjectsExtensionsLibs