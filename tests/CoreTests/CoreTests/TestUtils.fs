module TestUtils

open Expecto
open DynamicObj
open Newtonsoft.Json
open Plotly.NET.GenericChart
open System.Reflection
open System.IO

module HtmlCodegen =

    let getFullPlotlyJS() =
        let assembly = Assembly.GetExecutingAssembly()
        use str = assembly.GetManifestResourceStream($"CoreTests.plotly-{Globals.PLOTLYJS_VERSION}.min.js")
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
        substringIsInChart chart toChartHTML substring
        substringIsInChart chart toEmbeddedHTML substring


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
