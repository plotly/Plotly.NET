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
            ]
        ]
