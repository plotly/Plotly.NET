module CoreTests.UpstreamFeatures.PlotlyJS_2_28

open Expecto

open TestUtils.HtmlCodegen
open PlotlyJS_2_28_TestCharts

module ``Encoded typed arrays`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays" [
                testCase "x is serialized as an encoded object" (fun () ->
                    """"x":{"bdata":"AAAAAAAA8D8AAAAAAAAAQA==","dtype":"f8"}"""
                    |> chartGeneratedContains ``Encoded typed arrays``.``Scatter x/y encoded``
                )
                testCase "y is serialized as an encoded object" (fun () ->
                    """"y":{"bdata":"AAAAAAAACEAAAAAAAAAQQA==","dtype":"f8"}"""
                    |> chartGeneratedContains ``Encoded typed arrays``.``Scatter x/y encoded``
                )
                testCase "scatter additional data-array fields are serialized as encoded objects" (fun () ->
                    [
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays``.``Scatter fully encoded with error bars``)
                )
                testCase "encoded error_x array is serialized under error_x.array" (fun () ->
                    """"error_x":{"type":"data","array":{"bdata":"""
                    |> chartGeneratedContains ``Encoded typed arrays``.``Scatter fully encoded with error bars``
                )
                testCase "encoded error_y array and arrayminus are serialized under error_y" (fun () ->
                    [
                        "\"error_y\":{\"type\":\"data\",\"array\":{\"bdata\":"
                        "\"arrayminus\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays``.``Scatter fully encoded with error bars``)
                )
            ]
        ]
