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

    let genTests chart name parts =
        parts
        |> List.mapi (fun i part ->
            testCase $"{name} #{i}: '{part}'" ( fun () ->
                part
                |> chartGeneratedContains chart
            );
        )

module LayoutObjects =
    
    let createJsonFieldTest fieldName expected (object:#ImmutableDynamicObj) =
        testCase fieldName ( fun () -> 
            Expect.stringContains 
                ((object :> ImmutableDynamicObj) |> JsonConvert.SerializeObject) 
                ($"\"{fieldName}\":{expected}") 
                ($"Field `{fieldName}` not set correctly in serialized dynamic object.")
        )