module TestUtils

open Expecto
open DynamicObj
open Newtonsoft.Json
open Plotly.NET.GenericChart

module HtmlCodegen =

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

module LayoutObjects =
    
    let createJsonFieldTest fieldName expected (object:#DynamicObj) =
        testCase fieldName ( fun () -> 
            Expect.stringContains 
                ((object :> DynamicObj) |> JsonConvert.SerializeObject) 
                ($"\"{fieldName}\":{expected}") 
                ($"Field `{fieldName}` not set correctly in serialized dynamic object.")
        )