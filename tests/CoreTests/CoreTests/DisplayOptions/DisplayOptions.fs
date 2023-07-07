module Tests.DisplayOptions

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine

open TestUtils.Objects

let headTags = 
    [
        script [_src "lol.meme"] []
    ]

let description = 
    [   
        h1 [] [str "Yes"]
    ]

let plotlyRef = NoReference

let displayOpts =
    DisplayOptions.init(
        AdditionalHeadTags = [
            script [_src "lol.meme"] []
        ],
        Description = [
            h1 [] [str "Yes"]
        ],
        PlotlyJSReference = NoReference
    )

let combined = 
    DisplayOptions.combine 
        (DisplayOptions.init(
            AdditionalHeadTags = [script [_src "1"] []],
            Description = [h1 [] [str "1"]],
            PlotlyJSReference = NoReference
        )) 
        (DisplayOptions.init(
            AdditionalHeadTags = [script [_src "2"] []],
            Description = [h1 [] [str "2"]],
            PlotlyJSReference = Full
        ))

let expectedCombined = 
    DisplayOptions.init(
        AdditionalHeadTags = [script [_src "1"] []; script [_src "2"] []],
        Description = [h1 [] [str "1"]; h1 [] [str "2"]],
        PlotlyJSReference = Full
    )

[<Tests>]
let ``DisplayOptions API tests`` =
    testList "DisplayOptions.DisplayOptions API" [
        testCase "AdditionalHeadTags tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetAdditionalHeadTags) (Some headTags) "DisplayOptions.tryGetAdditionalHeadTags did not return the correct result")
        testCase "Description tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetDescription) (Some description) "DisplayOptions.tryGetDescription did not return the correct result")
        testCase "PlotlyJSReference tryGet" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.tryGetPlotlyReference) (Some plotlyRef) "DisplayOptions.tryGetPlotlyReference did not return the correct result")

        testCase "AdditionalHeadTags getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getAdditionalHeadTags) headTags "DisplayOptions.getAdditionalHeadTags did not return the correct result")
        testCase "Description getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getDescription) description "DisplayOptions.getDescription did not return the correct result")
        testCase "PlotlyJSReference getter" (fun _ -> Expect.equal (displayOpts |> DisplayOptions.getPlotlyReference) plotlyRef "DisplayOptions.getPlotlyReference did not return the correct result")

        testCase "AdditionalHeadTags setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setAdditionalHeadTags headTags |> DisplayOptions.getAdditionalHeadTags)
                headTags
                "DisplayOptions.setAdditionalHeadTags did not set the correct result"
            )
        testCase "Description setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setDescription description |> DisplayOptions.getDescription)
                description
                "DisplayOptions.setDescription did not set the correct result"
            )
        testCase "PlotlyJSReference setter" (fun _ -> 
            Expect.equal 
                (DisplayOptions.init() |> DisplayOptions.setPlotlyReference plotlyRef |> DisplayOptions.getPlotlyReference)
                plotlyRef
                "DisplayOptions.setPlotlyReference did set return the correct result"
            )

        testCase "AdditionalHeadTags combine" (fun _ -> 
            Expect.sequenceEqual 
                (combined |> DisplayOptions.getAdditionalHeadTags)
                (expectedCombined |> DisplayOptions.getAdditionalHeadTags)
                "DisplayOptions.combine did not return the correct object"
        )         
        testCase "Description combine" (fun _ -> 
            Expect.sequenceEqual 
                (combined |> DisplayOptions.getDescription)
                (expectedCombined |> DisplayOptions.getDescription)
                "DisplayOptions.combine did not return the correct object"
        )         
        testCase "PlotlyJSReference combine" (fun _ -> 
            Expect.equal 
                (combined |> DisplayOptions.getPlotlyReference)
                Full
                "DisplayOptions.combine did not return the correct object"
        ) 
    ]