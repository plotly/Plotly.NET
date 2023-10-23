module CoreTests.UpstreamFeatures.PlotlyJS_2_20

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open PlotlyJS_2_20_TestCharts

module TitleAutoMargin = 

    [<Tests>]
    let ``Title AutoMargin chart HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_20" [
            testList "TitleAutoMargin" [
                testCase "Title AutoMargin data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains TitleAutoMargin.``Title with AutoMargin``
                )
                testCase "Title AutoMargin layout" ( fun () ->
                    """var layout = {"title":{"text":"Lorem ipsum dolor sit amet, <br>consetetur sadipscing elitr, sed diam nonumy eirmod <br>tempor invidunt ut labore et dolore magna aliquyam erat, <br>sed diam voluptua. At vero eos et accusam et justo <br>duo dolores et ea rebum. Stet clita kasd gubergren,<br>no sea takimata sanctus est Lorem ipsum dolor sit amet. <br>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, <br>sed diam nonumy eirmod tempor invidunt ut labore et <br>dolore magna aliquyam erat, sed diam voluptua. <br>At vero eos et accusam et justo duo dolores et ea rebum. <br>Stet clita kasd gubergren, no sea takimata sanctus est <br>Lorem ipsum dolor sit amet.","automargin":true}};"""
                    |> chartGeneratedContains TitleAutoMargin.``Title with AutoMargin``
                )
            ]
        ]