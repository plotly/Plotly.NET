module ProjectInfo

open Fake.Core

let project = "Plotly.NET"

let testProjects = 
    [
        "tests/Plotly.NET.Tests/Plotly.NET.Tests.fsproj"
        "tests/Plotly.NET.ImageExport.Tests/Plotly.NET.ImageExport.Tests.fsproj"
        "tests/Plotly.NET.Tests.CSharp/Plotly.NET.Tests.CSharp.csproj"
    ]

let solutionFile  = $"{project}.sln"

let configuration = "Release"

let gitOwner = "plotly"

let gitHome = $"https://github.com/{gitOwner}"

let projectRepo = $"https://github.com/{gitOwner}/{project}"

let pkgDir = "pkg"

let release = ReleaseNotes.load "RELEASE_NOTES.md"

let stableVersion = SemVer.parse release.NugetVersion

let stableVersionTag = (sprintf "%i.%i.%i" stableVersion.Major stableVersion.Minor stableVersion.Patch )

let mutable prereleaseSuffix = ""

let mutable prereleaseTag = ""

let mutable isPrerelease = false