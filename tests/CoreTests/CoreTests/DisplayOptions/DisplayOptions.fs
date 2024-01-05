module Tests.DisplayOptions

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine

open TestUtils.Objects

let documentTitle = "testtitle"

let documentDescription = "testdesc"

let documentCharset = "UTF-8"

let documentFavicon = 
    (link [
        _id "favicon"
        _rel "shortcut icon"
        _type "image/png"
        _href "testfavicon"
    ])

let additionalHeadTags = 
    [
        script [_src "lol.meme"] []
    ]

let chartDescription = 
    [   
        h1 [] [str "Yes"]
    ]

let plotlyRef = NoReference

let displayOpts =
    DisplayOptions.init(
        DocumentTitle = "testtitle",
        DocumentDescription = "testdesc",
        DocumentCharset = "UTF-8",
        DocumentFavicon = (link [
            _id "favicon"
            _rel "shortcut icon"
            _type "image/png"
            _href "testfavicon"
        ]),
        AdditionalHeadTags = [
            script [_src "lol.meme"] []
        ],
        ChartDescription = [
            h1 [] [str "Yes"]
        ],
        PlotlyJSReference = NoReference
    )

let combined = 
    DisplayOptions.combine 
        (DisplayOptions.init(
            DocumentTitle = "1",
            DocumentDescription = "1",
            DocumentCharset = "1",
            DocumentFavicon = (link [
                _id "1"
                _rel "1"
                _type "1"
                _href "1"
            ]),
            AdditionalHeadTags = [script [_src "1"] []],
            ChartDescription = [h1 [] [str "1"]],
            PlotlyJSReference = NoReference
        )) 
        (DisplayOptions.init(
            DocumentTitle = "2",
            DocumentDescription = "2",
            DocumentCharset = "2",
            DocumentFavicon = (link [
                _id "2"
                _rel "2"
                _type "2"
                _href "2"
            ]),
            AdditionalHeadTags = [script [_src "2"] []],
            ChartDescription = [h1 [] [str "2"]],
            PlotlyJSReference = Full
        ))

let expectedCombined = 
    DisplayOptions.init(
        DocumentTitle = "2",
        DocumentDescription = "2",
        DocumentCharset = "2",
        DocumentFavicon = (link [
            _id "2"
            _rel "2"
            _type "2"
            _href "2"
        ]),
        AdditionalHeadTags = [script [_src "1"] []; script [_src "2"] []],
        ChartDescription = [h1 [] [str "1"]; h1 [] [str "2"]],
        PlotlyJSReference = Full
    )

[<Tests>]
let ``DisplayOptions API tests`` =
    testList "DisplayOptions.DisplayOptions API" [
        testCase "DocumentTitle tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetDocumentTitle) (Some documentTitle) "DisplayOptions.tryGetDocumentTitle did not return the correct result")
        testCase "DocumentDescription tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetDocumentDescription) (Some documentDescription) "DisplayOptions.tryGetDocumentDescription did not return the correct result")
        testCase "DocumentCharset tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetDocumentCharset) (Some documentCharset) "DisplayOptions.tryGetDocumentCharset did not return the correct result")
        testCase "DocumentFavicon tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetDocumentFavicon) (Some documentFavicon) "DisplayOptions.tryGetDocumentFavicon did not return the correct result")
        testCase "AdditionalHeadTags tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetAdditionalHeadTags) (Some additionalHeadTags) "DisplayOptions.tryGetAdditionalHeadTags did not return the correct result")
        testCase "ChartDescription tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetChartDescription) (Some chartDescription) "DisplayOptions.tryGetDescription did not return the correct result")
        testCase "PlotlyJSReference tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetPlotlyReference) (Some plotlyRef) "DisplayOptions.tryGetPlotlyReference did not return the correct result")

        testCase "DocumentTitle getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getDocumentTitle) documentTitle "DisplayOptions.getDocumentTitle did not return the correct result")
        testCase "DocumentDescription getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getDocumentDescription) documentDescription "DisplayOptions.getDocumentDescription did not return the correct result")
        testCase "DocumentCharset getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getDocumentCharset) documentCharset "DisplayOptions.getDocumentCharset did not return the correct result")
        testCase "DocumentFavicon getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getDocumentFavicon) documentFavicon "DisplayOptions.getDocumentFavicon did not return the correct result")
        testCase "AdditionalHeadTags getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getAdditionalHeadTags) additionalHeadTags "DisplayOptions.getAdditionalHeadTags did not return the correct result")
        testCase "ChartDescription getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getChartDescription) chartDescription "DisplayOptions.getDescription did not return the correct result")
        testCase "PlotlyJSReference getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getPlotlyReference) plotlyRef "DisplayOptions.getPlotlyReference did not return the correct result")

        testCase "DocumentTitle setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setDocumentTitle documentTitle |> DisplayOptions.getDocumentTitle)
                documentTitle
                "DisplayOptions.setDocumentTitle did not set the correct result"
            )
        testCase "DocumentDescription setter" (fun _ ->
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setDocumentDescription documentDescription |> DisplayOptions.getDocumentDescription)
                documentDescription
                "DisplayOptions.setDocumentDescription did not set the correct result"
            )
        testCase "DocumentCharset setter" (fun _ ->
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setDocumentCharset documentCharset |> DisplayOptions.getDocumentCharset)
                documentCharset
                "DisplayOptions.setDocumentCharset did not set the correct result"
            )
        testCase "DocumentFavicon setter" (fun _ ->
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setDocumentFavicon documentFavicon |> DisplayOptions.getDocumentFavicon)
                documentFavicon
                "DisplayOptions.setDocumentFavicon did not set the correct result"
            )
        testCase "AdditionalHeadTags setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setAdditionalHeadTags additionalHeadTags |> DisplayOptions.getAdditionalHeadTags)
                additionalHeadTags
                "DisplayOptions.setAdditionalHeadTags did not set the correct result"
            )
        testCase "ChartDescription setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setChartDescription chartDescription |> DisplayOptions.getChartDescription)
                chartDescription
                "DisplayOptions.setDescription did not set the correct result"
            )
        testCase "PlotlyJSReference setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setPlotlyReference plotlyRef |> DisplayOptions.getPlotlyReference)
                plotlyRef
                "DisplayOptions.setPlotlyReference did set return the correct result"
            )

        testCase "DocumentTitle combine" (fun _ ->
            Expect.equal 
                (combined |> DisplayOptions.getDocumentTitle)
                (expectedCombined |> DisplayOptions.getDocumentTitle)
                "DisplayOptions.combine did not return the correct object"
            )
        testCase "DocumentDescription combine" (fun _ ->
            Expect.equal 
                (combined |> DisplayOptions.getDocumentDescription)
                (expectedCombined |> DisplayOptions.getDocumentDescription)
                "DisplayOptions.combine did not return the correct object"
            )
        testCase "DocumentCharset combine" (fun _ ->
            Expect.equal 
                (combined |> DisplayOptions.getDocumentCharset)
                (expectedCombined |> DisplayOptions.getDocumentCharset)
                "DisplayOptions.combine did not return the correct object"
            )
        testCase "DocumentFavicon combine" (fun _ ->
            Expect.equal 
                (combined |> DisplayOptions.getDocumentFavicon)
                (expectedCombined |> DisplayOptions.getDocumentFavicon)
                "DisplayOptions.combine did not return the correct object"
            )
        testCase "AdditionalHeadTags combine" (fun _ -> 
            Expect.sequenceEqual 
                (combined |> DisplayOptions.getAdditionalHeadTags)
                (expectedCombined |> DisplayOptions.getAdditionalHeadTags)
                "DisplayOptions.combine did not return the correct object"
        )         
        testCase "ChartDescription combine" (fun _ -> 
            Expect.sequenceEqual 
                (combined |> DisplayOptions.getChartDescription)
                (expectedCombined |> DisplayOptions.getChartDescription)
                "DisplayOptions.combine did not return the correct object"
        )         
        testCase "PlotlyJSReference combine" (fun _ -> 
            Expect.equal 
                (combined |> DisplayOptions.getPlotlyReference)
                Full
                "DisplayOptions.combine did not return the correct object"
        ) 
    ]