namespace Plotly.NET

open Giraffe.ViewEngine
open System

type HTML() =

    static member CreateChartScript
        (
            data: string,
            layout: string,
            config: string,
            plotlyReference: PlotlyJSReference,
            guid: string
        ) =
        match plotlyReference with
        | Require r ->
            script
                [ _type "text/javascript" ]
                [
                    rawText (
                        Globals.REQUIREJS_SCRIPT_TEMPLATE
                            .Replace("[REQUIRE_SRC]", r)
                            .Replace("[SCRIPTID]", guid.Replace("-", ""))
                            .Replace("[ID]", guid)
                            .Replace("[DATA]", data)
                            .Replace("[LAYOUT]", layout)
                            .Replace("[CONFIG]", config)
                    )
                ]
        | _ ->
            script
                [ _type "text/javascript" ]
                [
                    rawText (
                        Globals.SCRIPT_TEMPLATE
                            .Replace("[SCRIPTID]", guid.Replace("-", ""))
                            .Replace("[ID]", guid)
                            .Replace("[DATA]", data)
                            .Replace("[LAYOUT]", layout)
                            .Replace("[CONFIG]", config)
                    )
                ]


    static member Doc(chart, plotlyReference: PlotlyJSReference, ?AdditionalHeadTags, ?Description) =
        let additionalHeadTags =
            defaultArg AdditionalHeadTags []

        let description = defaultArg Description []

        let plotlyScriptRef =
            match plotlyReference with
            | CDN cdn -> script [ _src cdn; _charset "utf-8"] []
            | Full ->
                script
                    [ _type "text/javascript"; _charset "utf-8"]
                    [
                        rawText (InternalUtils.getFullPlotlyJS ())
                    ]
            | NoReference
            | Require _ -> rawText ""

        html
            []
            [
                head
                    []
                    [
                        plotlyScriptRef
                        yield! additionalHeadTags
                    ]
                body [] [ yield! chart; yield! description ]
            ]

    static member CreateChartHTML(data: string, layout: string, config: string, plotlyReference: PlotlyJSReference) =
        let guid = Guid.NewGuid().ToString()

        let chartScript =
            HTML.CreateChartScript(
                data = data,
                layout = layout,
                config = config,
                plotlyReference = plotlyReference,
                guid = guid
            )

        [
            div
                [ _id guid ]
                [
                    comment "Plotly chart will be drawn inside this DIV"
                ]
            chartScript
        ]