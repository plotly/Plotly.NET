module TestUtils

open System.Reflection
open System.IO
open Expecto
open Plotly.NET
open DynamicObj
open Newtonsoft.Json

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

