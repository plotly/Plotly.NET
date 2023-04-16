module TestUtils

open System.Reflection
open System.IO

let getLogoPNG() =
    let assembly = Assembly.GetExecutingAssembly()
    use str = assembly.GetManifestResourceStream($"FSharpTestBase.logo.png")
    use r = new BinaryReader(str)
    r.ReadBytes(int(str.Length))
    |> System.Convert.ToBase64String

let getFullPlotlyJS() =
    let assembly = Assembly.GetExecutingAssembly()
    use str = assembly.GetManifestResourceStream($"FSharpTestBase.plotly-{Globals.PLOTLYJS_VERSION}.min.js")
    use r = new StreamReader(str)
    r.ReadToEnd()
