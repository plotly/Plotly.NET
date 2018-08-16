// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r "paket: groupref FakeBuild //"
open Fake.IO

#load "./.fake/build.fsx/intellisense.fsx"

open System.IO
open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.DotNet.Testing
open Fake.Tools
open Fake.Api

// --------------------------------------------------------------------------------------
// START TODO: Provide project-specific details below
// --------------------------------------------------------------------------------------

// Information about the project are used
//  - for version and project name in generated AssemblyInfo file
//  - by the generated NuGet package
//  - to run tests and to publish documentation on GitHub gh-pages
//  - for documentation, you also need to edit info in "docsrc/tools/generate.fsx"

// The name of the project
// (used by attributes in AssemblyInfo, name of a NuGet package and directory in 'src')
let project = "FSharp.Plotly"

// Short summary of the project
// (used as description in AssemblyInfo and as a short summary for NuGet package)
let summary = "A F# interactive charting library using plotly.js"

// Longer description of the project
// (used as a description for NuGet package; line breaks are automatically cleaned up)
let description = "A F# interactive charting library using plotly.js"

// List of author names (for NuGet package)
let author = "Timo Mühlhaus"

// Tags for your project (for NuGet package)
let tags = "visualization charting plotly F#"

// File system information
let solutionFile  = "FSharp.Plotly.sln"

// Default target configuration
let configuration = "Release"

// Pattern specifying assemblies to be tested using Expecto
let testAssemblies = "tests/**/bin" </> configuration </> "**" </> "*Tests.exe"

// Git configuration (used for publishing documentation in gh-pages branch)
// The profile where the project is posted
let gitOwner = "muehlhaus"
let gitHome = sprintf "%s/%s" "https://github.com" gitOwner

// The name of the project on GitHub
let gitName = "FSharp.Plotly"

// The url for the raw files hosted
let gitRaw = Environment.environVarOrDefault "gitRaw" "https://raw.githubusercontent.com/Timo Mühlhaus"

let website = "/FSharp.Plotly"

// --------------------------------------------------------------------------------------
// END TODO: The rest of the file includes standard build steps
// --------------------------------------------------------------------------------------

// Read additional information from the release notes document
let release = ReleaseNotes.load "RELEASE_NOTES.md"

// Helper active pattern for project types
let (|Fsproj|Csproj|Vbproj|Shproj|) (projFileName:string) =
    match projFileName with
    | f when f.EndsWith("fsproj") -> Fsproj
    | f when f.EndsWith("csproj") -> Csproj
    | f when f.EndsWith("vbproj") -> Vbproj
    | f when f.EndsWith("shproj") -> Shproj
    | _                           -> failwith (sprintf "Project file %s not supported. Unknown project type." projFileName)

// Generate assembly info files with the right version & up-to-date information
Target.create "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ AssemblyInfo.Title (projectName)
          AssemblyInfo.Product project
          AssemblyInfo.Description summary
          AssemblyInfo.Version release.AssemblyVersion
          AssemblyInfo.FileVersion release.AssemblyVersion
          AssemblyInfo.Configuration configuration ]

    let getProjectDetails projectPath =
        let projectName = Path.GetFileNameWithoutExtension(projectPath)
        ( projectPath,
          projectName,
          Path.GetDirectoryName(projectPath),
          (getAssemblyInfoAttributes projectName)
        )

    !! "src/**/*.??proj"
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, _, folderName, attributes) ->
        match projFileName with
        | Fsproj -> AssemblyInfoFile.createFSharp (folderName </> "AssemblyInfo.fs") attributes
        | Csproj -> AssemblyInfoFile.createCSharp ((folderName </> "Properties") </> "AssemblyInfo.cs") attributes
        | Vbproj -> AssemblyInfoFile.createVisualBasic ((folderName </> "My Project") </> "AssemblyInfo.vb") attributes
        | Shproj -> ()
        )
)

// Copies binaries from default VS location to expected bin folder
// But keeps a subdirectory structure for each project in the
// src folder to support multiple project outputs
Target.create "CopyBinaries" (fun _ ->
    !! "src/**/*.??proj"
    -- "src/**/*.shproj"
    |>  Seq.map (fun f -> ((Path.getDirectory f) </> "bin" </> configuration, "bin" </> (Path.GetFileNameWithoutExtension f)))
    |>  Seq.iter (fun (fromDir, toDir) -> Shell.copyDir toDir fromDir (fun _ -> true))
)

// --------------------------------------------------------------------------------------
// Clean build results

let buildConfiguration = DotNet.Custom <| Environment.environVarOrDefault "configuration" configuration

Target.create "Clean" (fun _ ->
    Shell.cleanDirs ["bin"; "temp"]
)

Target.create "CleanDocs" (fun _ ->
    Shell.cleanDirs ["docs"]
)

// --------------------------------------------------------------------------------------
// Build library & test project

Target.create "Restore" (fun _ ->
    solutionFile
    |> DotNet.restore id
)

Target.create "Build" (fun _ ->
    (*solutionFile
    |> DotNet.build (fun p ->
        { p with
            Configuration = buildConfiguration })*)
    let setParams (defaults:MSBuildParams) =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Build"]
            Properties =
                [
                    "Optimize", "True"
                    "DebugSymbols", "True"
                    "Configuration", configuration
                ]
         }
    MSBuild.build setParams solutionFile
    Shell.copyFile
        (__SOURCE_DIRECTORY__ + @"\src\FSharp.Plotly\bin\" + configuration + @"\netstandard2.0\Newtonsoft.Json.dll")
        (__SOURCE_DIRECTORY__+ @"\packages\Newtonsoft.Json\lib\netstandard2.0\Newtonsoft.Json.dll")
)

// --------------------------------------------------------------------------------------
// Run the unit tests using test runner

Target.create "RunTests" (fun _ ->
    let assemblies = !! testAssemblies

    let setParams f =
        match Environment.isWindows with
        | true ->
            fun p ->
                { p with
                    FileName = f}
        | false ->
            fun p ->
                { p with
                    FileName = "mono"
                    Arguments = f }
    assemblies
    |> Seq.map (fun f ->
        Process.execSimple (setParams f) System.TimeSpan.MaxValue
    )
    |>Seq.reduce (+)
    |> (fun i -> if i > 0 then failwith "")
)

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target.create "NuGet" (fun _ ->
    Paket.pack(fun p ->
        { p with
            OutputPath = "bin"
            Version = release.NugetVersion
            ReleaseNotes = String.toLines release.Notes})
)

Target.create "PublishNuget" (fun _ ->
    Paket.push(fun p ->
        { p with
            PublishUrl = "https://www.nuget.org"
            WorkingDir = "bin" })
)


// --------------------------------------------------------------------------------------
// Generate the documentation

// Paths with template/source/output locations
let bin        = __SOURCE_DIRECTORY__ @@ "bin"
let content    = __SOURCE_DIRECTORY__ @@ "docsrc/content"
let output     = __SOURCE_DIRECTORY__ @@ "docs"
let files      = __SOURCE_DIRECTORY__ @@ "docsrc/files"
let templates  = __SOURCE_DIRECTORY__ @@ "docsrc/tools/templates"
let formatting = __SOURCE_DIRECTORY__ @@ "packages/formatting/FSharp.Formatting"
let docTemplate = "docpage.cshtml"

let github_release_user = Environment.environVarOrDefault "github_release_user" gitOwner
let githubLink = sprintf "https://github.com/%s/%s" github_release_user gitName

// Specify more information about your project
let info =
  [ "project-name", "FSharp.Plotly"
    "project-author", "Timo Mühlhaus"
    "project-summary", "A F# interactive charting library using plotly.js"
    "project-github", githubLink
    "project-nuget", "http://nuget.org/packages/FSharp.Plotly" ]

let root = website

let referenceBinaries = []

let layoutRootsAll = new System.Collections.Generic.Dictionary<string, string list>()
layoutRootsAll.Add("en",[   templates;
                            formatting @@ "templates"
                            formatting @@ "templates/reference" ])

Target.create "ReferenceDocs" (fun _ ->
    Directory.ensure (output @@ "reference")

    let binaries () =
        let manuallyAdded =
            referenceBinaries
            |> List.map (fun b -> bin @@ b)

        let conventionBased =
            DirectoryInfo.getSubDirectories <| DirectoryInfo bin
            |> Array.collect (fun d ->
                let name, dInfo =
                    let net45Bin =
                        DirectoryInfo.getSubDirectories d |> Array.filter(fun x -> x.FullName.ToLower().Contains("net45"))
                    let net47Bin =
                        DirectoryInfo.getSubDirectories d |> Array.filter(fun x -> x.FullName.ToLower().Contains("net47"))
                    if net45Bin.Length > 0 then
                        d.Name, net45Bin.[0]
                    else
                        d.Name, net47Bin.[0]

                dInfo.GetFiles()
                |> Array.filter (fun x ->
                    x.Name.ToLower() = (sprintf "%s.dll" name).ToLower())
                |> Array.map (fun x -> x.FullName)
                )
            |> List.ofArray

        conventionBased @ manuallyAdded

    binaries()
    |> FSFormatting.createDocsForDlls (fun args ->
        { args with
            OutputDirectory = output @@ "reference"
            LayoutRoots =  layoutRootsAll.["en"]
            ProjectParameters =  ("root", root)::info
            SourceRepository = githubLink @@ "tree/master" }
           )
)

let copyFiles () =
    Shell.copyRecursive files output true
    |> Trace.logItems "Copying file: "
    Directory.ensure (output @@ "content")
    Shell.copyRecursive (formatting @@ "styles") (output @@ "content") true
    |> Trace.logItems "Copying styles and scripts: "

Target.create "Docs" (fun _ ->
    File.delete "docsrc/content/release-notes.md"
    Shell.copyFile "docsrc/content/" "RELEASE_NOTES.md"
    Shell.rename "docsrc/content/release-notes.md" "docsrc/content/RELEASE_NOTES.md"

    File.delete "docsrc/content/license.md"
    Shell.copyFile "docsrc/content/" "LICENSE.txt"
    Shell.rename "docsrc/content/license.md" "docsrc/content/LICENSE.txt"


    DirectoryInfo.getSubDirectories (DirectoryInfo.ofPath templates)
    |> Seq.iter (fun d ->
                    let name = d.Name
                    if name.Length = 2 || name.Length = 3 then
                        layoutRootsAll.Add(
                                name, [templates @@ name
                                       formatting @@ "templates"
                                       formatting @@ "templates/reference" ]))
    copyFiles ()

    for dir in  [ content; ] do
        let langSpecificPath(lang, path:string) =
            path.Split([|'/'; '\\'|], System.StringSplitOptions.RemoveEmptyEntries)
            |> Array.exists(fun i -> i = lang)
        let layoutRoots =
            let key = layoutRootsAll.Keys |> Seq.tryFind (fun i -> langSpecificPath(i, dir))
            match key with
            | Some lang -> layoutRootsAll.[lang]
            | None -> layoutRootsAll.["en"] // "en" is the default language

        FSFormatting.createDocs (fun args ->
            { args with
                Source = content
                OutputDirectory = output
                LayoutRoots = layoutRoots
                ProjectParameters  = ("root", root)::info
                Template = docTemplate } )
)

// --------------------------------------------------------------------------------------
// Release Scripts

//#load "paket-files/fsharp/FAKE/modules/Octokit/Octokit.fsx"
//open Octokit

Target.create "Release" (fun _ ->
    // not fully converted from  FAKE 4

    //let user =
    //    match getBuildParam "github-user" with
    //    | s when not (String.isNullOrWhiteSpace s) -> s
    //    | _ -> getUserInput "Username: "
    //let pw =
    //    match getBuildParam "github-pw" with
    //    | s when not (String.isNullOrWhiteSpace s) -> s
    //    | _ -> getUserPassword "Password: "
    //let remote =
    //    Git.CommandHelper.getGitResult "" "remote -v"
    //    |> Seq.filter (fun (s: string) -> s.EndsWith("(push)"))
    //    |> Seq.tryFind (fun (s: string) -> s.Contains(gitOwner + "/" + gitName))
    //    |> function None -> gitHome + "/" + gitName | Some (s: string) -> s.Split().[0]

    //Git.Staging.stageAll ""
    //Git.Commit.exec "" (sprintf "Bump version to %s" release.NugetVersion)
    //Git.Branches.pushBranch "" remote (Git.Information.getBranchName "")

    //Git.Branches.tag "" release.NugetVersion
    //Git.Branches.pushTag "" remote release.NugetVersion

    //// release on github
    //GitHub.createClient user pw
    //|> createDraft gitOwner gitName release.NugetVersion (release.SemVer.PreRelease <> None) release.Notes
    //// TODO: |> uploadFile "PATH_TO_FILE"
    //|> releaseDraft
    //|> Async.RunSynchronously

    // using simplified FAKE 5 release for now

    Git.Staging.stageAll ""
    Git.Commit.exec "" (sprintf "Bump version to %s" release.NugetVersion)
    Git.Branches.push ""

    Git.Branches.tag "" release.NugetVersion
    Git.Branches.pushTag "" "origin" release.NugetVersion
)

Target.create "BuildPackage" ignore
Target.create "GenerateDocs" ignore

Target.create "GitReleaseNuget" (fun _ ->
    let tempNugetDir = "temp/nuget"
    Shell.cleanDir tempNugetDir |> ignore
    Git.Repository.cloneSingleBranch "" (gitHome + "/" + gitName + ".git") "nuget" tempNugetDir
    let files = Directory.EnumerateFiles bin 
    Shell.copy tempNugetDir files
    Git.Staging.stageAll tempNugetDir
    Git.Commit.exec tempNugetDir (sprintf "Update git nuget packages for version %s" release.NugetVersion)
    Git.Branches.push tempNugetDir
)

// --------------------------------------------------------------------------------------
// Run all targets by default. Invoke 'build <Target>' to override

Target.create "All" ignore

"Clean"
  ==> "AssemblyInfo"
  ==> "Restore"
  ==> "Build"
  ==> "CopyBinaries"
  ==> "RunTests"
//   ==> "GenerateDocs"
  ==> "NuGet"
  ==> "All"

"RunTests" ?=> "CleanDocs"

"CleanDocs"
  ==>"Docs"
//   ==> "ReferenceDocs"
//   ==> "GenerateDocs"

"Clean"
  ==> "Release"

"BuildPackage"
  ==> "PublishNuget"
  ==> "Release"


"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "CopyBinaries"
  ==> "RunTests"
  ==> "NuGet"
  ==> "GitReleaseNuget"

Target.runOrDefault "All"
