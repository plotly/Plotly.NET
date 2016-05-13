namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Plotly")>]
[<assembly: AssemblyProductAttribute("FSharp.Plotly")>]
[<assembly: AssemblyDescriptionAttribute("A F# interactive charting library using plotly.js")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
    let [<Literal>] InformationalVersion = "1.0"
