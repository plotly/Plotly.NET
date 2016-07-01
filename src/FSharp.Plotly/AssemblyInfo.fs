namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Plotly")>]
[<assembly: AssemblyProductAttribute("FSharp.Plotly")>]
[<assembly: AssemblyDescriptionAttribute("A F# interactive charting library using plotly.js")>]
[<assembly: AssemblyVersionAttribute("0.6.1")>]
[<assembly: AssemblyFileVersionAttribute("0.6.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.6.1"
    let [<Literal>] InformationalVersion = "0.6.1"
