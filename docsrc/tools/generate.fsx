// --------------------------------------------------------------------------------------
// Builds the documentation from `.fsx` and `.md` files in the 'docs/content' directory
// (the generated documentation is stored in the 'docs/output' directory)
// --------------------------------------------------------------------------------------

// Web site location for the generated documentation
let website = "https://fslab.org/XPlot"

// Specify more information about your project
let info =
  [ "project-name", "XPlot"
    "project-author", "Taha Hachana; Tomas Petricek"
    "project-summary", "Data visualization library for F#"
    "project-github", "https://github.com/fslaborg/XPlot"
    "project-nuget", "http://www.nuget.org/packages?q=XPlot" ]

// --------------------------------------------------------------------------------------
// For typical project, no changes are needed below
// --------------------------------------------------------------------------------------

#load "formatters.fsx"
#load "../../.fake/build.fsx/intellisense.fsx"
#if !FAKE
let execContext = Fake.Core.Context.FakeExecutionContext.Create false "generate.fsx" []
Fake.Core.Context.setExecutionContext (Fake.Core.Context.RuntimeContext.Fake execContext)
#endif
open Fake.Core
open System.IO
open Fake.IO.FileSystemOperators
open Fake.IO
open FSharp.Formatting.Razor


// Binaries for which to generate XML documentation
let referenceBinaries = 
  [ 
    __SOURCE_DIRECTORY__ + "/../../bin/XPlot.D3/netstandard2.0/XPlot.D3.dll"
    __SOURCE_DIRECTORY__ + "/../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
    __SOURCE_DIRECTORY__ + "/../../bin/XPlot.GoogleCharts.Deedle/netstandard2.0/XPlot.GoogleCharts.Deedle.dll"
    __SOURCE_DIRECTORY__ + "/../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
  ]

// When called from 'build.fsx', use the public project URL as <root>
// otherwise, use the current 'output' directory.
#if RELEASE
let root = website
#else
let root = "file://" + (__SOURCE_DIRECTORY__ @@ "../output")
#endif

// Paths with template/source/output locations
let bin        = __SOURCE_DIRECTORY__ @@ "../../bin"
let content    = __SOURCE_DIRECTORY__ @@ "../content"
let output     = __SOURCE_DIRECTORY__ @@ "../../docs/output"
let files      = __SOURCE_DIRECTORY__ @@ "../files"
let templates  = __SOURCE_DIRECTORY__ @@ "templates"
let formatting = __SOURCE_DIRECTORY__ @@ "../../packages/formatting/FSharp.Formatting/"
let docTemplate = formatting @@ "templates/docpage.cshtml"

// Where to look for *.csproj templates (in this order)
let layoutRoots =
  [ templates; formatting @@ "templates";
    formatting @@ "templates/reference" ]

// Copy static files and CSS + JS from F# Formatting
let copyFiles () =
  Shell.copyRecursive files output true |> Trace.logItems "Copying file: "
  Directory.ensure (output @@ "content")
  Shell.copyRecursive (formatting @@ "styles") (output @@ "content") true 
    |> Trace.logItems "Copying styles and scripts: "

// Build API reference from XML comments
let buildReference () =
  Shell.cleanDir (output @@ "reference")
  RazorMetadataFormat.Generate
    ( referenceBinaries, output @@ "reference", layoutRoots,
      parameters = ("root", root)::info,
      sourceRepo = "https://github.com/fslaborg/XPlot/tree/master/",
      sourceFolder = __SOURCE_DIRECTORY__.Substring(0, __SOURCE_DIRECTORY__.Length - @"\docsrc\tools".Length))

// Build documentation from `fsx` and `md` files in `docs/content`
let buildDocumentation () =
  Shell.copyFile content (__SOURCE_DIRECTORY__ @@ "../../RELEASE_NOTES.md")
  let fsiEvaluator = Formatters.createFsiEvaluator root output "#.####"
  let subdirs = Directory.EnumerateDirectories(content, "*", SearchOption.AllDirectories)
  for dir in Seq.append [content] subdirs do
    let sub = if dir.Length > content.Length then dir.Substring(content.Length + 1) else "."
    RazorLiterate.ProcessDirectory
      ( dir, docTemplate, output @@ sub, replacements = ("root", root)::info,
        layoutRoots = layoutRoots, fsiEvaluator = fsiEvaluator, generateAnchors = true)

// Generate
copyFiles()
buildDocumentation()
buildReference()