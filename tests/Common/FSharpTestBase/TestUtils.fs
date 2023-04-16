module TestUtils

open System.Reflection
open System.IO
open Expecto
open Plotly.NET
open DynamicObj
open Newtonsoft.Json

module DataGeneration =
    
    //---------------------- Generate linearly spaced vector ----------------------
    let linspace (min,max,n) = 
        if n <= 2 then failwithf "n needs to be larger then 2"
        let bw = float (max - min) / (float n - 1.)
        Array.init n (fun i -> min + (bw * float i))

    //-------------------- Generate linearly spaced mesh grid ---------------------
    let mgrid (min,max,n) = 

        let data = linspace(min,max,n)

        let z = [|for i in 1 .. n do [|for i in 1 .. n do yield data|]|]
        let x = [|for i in 1 .. n do [|for j in 1 .. n do yield [|for k in 1 .. n do yield data.[i-1]|]|]|]
        let y = [|for i in 1 .. n do [|for j in 1 .. n do yield [|for k in 1 .. n do yield data.[j-1]|]|]|]

        x,y,z

    let normal (rnd:System.Random) mu tau =
        let mutable v1 = 2.0 * rnd.NextDouble() - 1.0
        let mutable v2 = 2.0 * rnd.NextDouble() - 1.0
        let mutable r = v1 * v1 + v2 * v2
        while (r >= 1.0 || r = 0.0) do
            v1 <- 2.0 * rnd.NextDouble() - 1.0
            v2 <- 2.0 * rnd.NextDouble() - 1.0
            r <- v1 * v1 + v2 * v2
        let fac = sqrt(-2.0*(log r)/r)
        (tau * v1 * fac + mu)

module HtmlCodegen =

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

    let substringIsInChart chart htmlizer substring =
        chart
        |> htmlizer
        |> Expect.stringContains
        |> (fun expecting -> expecting substring $"Should've contained {substring}")


    let substringListIsInChart chart htmlizer substringList =
        for substring in substringList do
            substringIsInChart chart htmlizer substring


    let chartGeneratedContains chart substring =
        substringIsInChart chart GenericChart.toChartHTML substring
        substringIsInChart chart GenericChart.toEmbeddedHTML substring


    let chartGeneratedContainsList chart substringList =
        for substring in substringList do
            chartGeneratedContains chart substring

    let emptyLayout chart =
        "var layout = {};" |> chartGeneratedContains chart

module Objects =

    let jsonFieldIsSetWith fieldName expected (object:#DynamicObj) =
        Expect.equal
            ((object :> DynamicObj)?($"{fieldName}") |> JsonConvert.SerializeObject) 
            expected
            ($"Field `{fieldName}` not set correctly in serialized dynamic object.")

