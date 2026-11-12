module Plotly.NET.Verso.BrowserTests.RenderingTests

open System.Threading.Tasks
open Expecto
open Giraffe.ViewEngine
open Plotly.NET
open Plotly.NET.Verso
open BrowserHarness

let private assetUrl = $"https://assets.example.invalid/plotly-{Globals.PLOTLYJS_VERSION}.min.js?fixture=verso"

let private lineChart () =
    Chart.Line(x = [ 1; 2; 3 ], y = [ 4; 6; 5 ], UseDefaults = false)

let private reference mode chart =
    chart |> GenericChart.setDisplayOptions(DisplayOptions.init(PlotlyJSReference = mode))

let private online () = lineChart () |> reference (CDN assetUrl)

let private render session cell chart = insert session cell (Formatters.toVersoHTML chart)

let private browserTest name body = testCaseAsync name (run name servePlotly false body)

let private noNetworkTest name body = testCaseAsync name (run name rejectNetwork false body)

let private delayedTest name body =
    testCaseAsync name (async {
        let gate = DelayedScript()
        return! run name (fun request index -> gate.Route(request, index)) false (body gate)
    })

let private graphId (session: Session) cellId =
    session.Page.EvaluateFunctionAsync<string>(
        "id => document.getElementById(id).querySelector('.plotly-net-verso').id",
        [| box cellId |]
    )

let private assertRequests (session: Session) expected =
    Expect.sequenceEqual (session.Requests.ToArray()) expected "Only the specified locally fulfilled Plotly requests are permitted."

[<Tests>]
let rendering =
    testSequencedGroup "VersoBrowser" (
        testList "Verso browser rendering" [
            delayedTest "CDN waits for a delayed script before drawing" (fun gate session -> task {
                do! render session "first" (online ())
                do! gate.Started
                let! waiting = session.Page.EvaluateExpressionAsync<bool>("document.querySelector('.plotly-net-verso').dataset.plotlyState === 'loading' && typeof window.Plotly === 'undefined'")
                Expect.isTrue waiting "The cell must wait for the external asset instead of calling an absent Plotly."
                do! assertCallCount session 0
                gate.Release()
                do! assertRendered session "first"
                do! assertCallCount session 1
                let! version = session.Page.EvaluateExpressionAsync<string>("window.Plotly.version")
                Expect.equal version Globals.PLOTLYJS_VERSION "The test must execute the bundle shipped by this core assembly."
                assertRequests session [ assetUrl ]
            })

            delayedTest "Concurrent cells share one load and retain distinct charts" (fun gate session -> task {
                do! render session "first" (online ())
                do! gate.Started
                let second = Chart.Point(x = [ 8; 9 ], y = [ 10; 11 ], UseDefaults = false) |> reference (CDN assetUrl)
                do! render session "second" second
                do! assertCallCount session 0
                gate.Release()
                do! assertRendered session "first"
                do! assertRendered session "second"
                let! firstId = graphId session "first"
                let! secondId = graphId session "second"
                Expect.notEqual firstId secondId "Independent cells must have distinct chart IDs."
                let! dataPreserved = session.Page.EvaluateExpressionAsync<bool>("document.querySelector('#first .js-plotly-plot').data[0].x.join(',') === '1,2,3' && document.querySelector('#second .js-plotly-plot').data[0].y.join(',') === '10,11'")
                Expect.isTrue dataPreserved "Concurrent output must not overwrite another chart's data."
                do! assertCallCount session 2
                assertRequests session [ assetUrl ]
            })

            browserTest "Cached loading and rerunning a cell draw exactly once per output" (fun session -> task {
                do! render session "first" (online ())
                do! assertRendered session "first"
                let! previousId = graphId session "first"
                do! render session "second" (online ())
                do! assertRendered session "second"
                do! render session "first" (online ())
                do! assertRendered session "first"
                let! nextId = graphId session "first"
                Expect.notEqual previousId nextId "A rerun should use a fresh output identity."
                do! session.Page.EvaluateFunctionAsync("() => { for (const script of document.querySelectorAll('script[src]')) script.dispatchEvent(new Event('load')); }")
                do! session.Page.EvaluateFunctionAsync("() => new Promise(resolve => requestAnimationFrame(() => requestAnimationFrame(resolve)))")
                do! assertCallCount session 3
                let! graphCount = session.Page.EvaluateExpressionAsync<int>("document.querySelectorAll('.js-plotly-plot').length")
                Expect.equal graphCount 2 "A rerun must replace the old graph rather than append a duplicate."
                assertRequests session [ assetUrl ]
            })

            delayedTest "Removing a waiting cell does not render into detached output" (fun gate session -> task {
                do! render session "removed" (online ())
                do! gate.Started
                let! removedId = graphId session "removed"
                do! render session "remaining" (online ())
                do! session.Page.EvaluateFunctionAsync("() => document.getElementById('removed').remove()")
                gate.Release()
                do! assertRendered session "remaining"
                do! assertCallCount session 1
                let! ignored = session.Page.EvaluateFunctionAsync<bool>("id => !document.getElementById(id) && !window.__plotlyCalls.includes(id)", [| box removedId |])
                Expect.isTrue ignored "Resolving a pending load must not resurrect or render a removed chart."
                assertRequests session [ assetUrl ]
            })

            testCaseAsync "A failed CDN load is visible and a later output retries" (
                run "A failed CDN load is visible and a later output retries"
                    (fun request index -> if index = 1 then respondWithFailure request else respondWithPlotly request)
                    true
                    (fun session -> task {
                        do! render session "failed" (online ())
                        let! message = assertError session "failed"
                        Expect.isTrue (message.Contains("Plotly") || message.Contains("plotly")) "Loading failures should identify the missing renderer."
                        do! assertCallCount session 0
                        do! render session "retry" (online ())
                        do! assertRendered session "retry"
                        do! assertCallCount session 1
                        assertRequests session [ assetUrl; assetUrl ]
                    })
            )

            testCaseAsync "A script without Plotly reports initialization failure and permits retry" (
                run "A script without Plotly reports initialization failure and permits retry"
                    (fun request index -> if index = 1 then respondWithoutPlotly request else respondWithPlotly request)
                    false
                    (fun session -> task {
                        do! render session "wrong-script" (online ())
                        let! message = assertError session "wrong-script"
                        Expect.stringContains message "Plotly" "A successful HTTP response alone must not be considered a loaded renderer."
                        do! assertCallCount session 0
                        do! render session "correct-script" (online ())
                        do! assertRendered session "correct-script"
                        do! assertCallCount session 1
                        assertRequests session [ assetUrl; assetUrl ]
                    })
            )

            noNetworkTest "Full reference renders with every network request blocked" (fun session -> task {
                do! render session "offline" (lineChart () |> reference Full)
                do! assertRendered session "offline"
                do! assertCallCount session 1
                assertRequests session []
            })

            noNetworkTest "The complete offline document survives notebook-style insertion" (fun session -> task {
                do! insert session "offline-document" (Formatters.toVersoHTMLOffline (online ()))
                do! assertRendered session "offline-document"
                do! assertCallCount session 1
                assertRequests session []
            })

            noNetworkTest "NoReference reuses a preloaded Plotly without downloading" (fun session -> task {
                do! session.Page.EvaluateExpressionAsync(plotlySource.Value)
                do! render session "preloaded" (lineChart () |> reference NoReference)
                do! assertRendered session "preloaded"
                do! assertCallCount session 1
                assertRequests session []
            })

            delayedTest "NoReference can join an existing pending adapter load" (fun gate session -> task {
                do! render session "loader" (online ())
                do! gate.Started
                do! render session "consumer" (lineChart () |> reference NoReference)
                do! assertCallCount session 0
                gate.Release()
                do! assertRendered session "loader"
                do! assertRendered session "consumer"
                do! assertCallCount session 2
                assertRequests session [ assetUrl ]
            })

            noNetworkTest "NoReference without a loaded renderer reports an actionable error" (fun session -> task {
                do! render session "missing" (lineChart () |> reference NoReference)
                let! message = assertError session "missing"
                Expect.isTrue (message.Contains("CDN") || message.Contains("Full")) "The error should explain how to provide Plotly."
                do! assertCallCount session 0
                assertRequests session []
            })

            noNetworkTest "Require reports migration guidance without loading RequireJS" (fun session -> task {
                do! render session "require" (lineChart () |> reference (Require "https://assets.example.invalid/plotly"))
                let! message = assertError session "require"
                Expect.stringContains message "CDN" "Require users should be directed to the supported CDN mode."
                Expect.stringContains message "Full" "Require users should be directed to the supported offline mode."
                do! assertCallCount session 0
                assertRequests session []
            })

            browserTest "An absent reference uses the originating runtime CDN" (fun session -> task {
                let chart = lineChart () |> GenericChart.setDisplayOptions(DisplayOptions.init())
                do! render session "default" chart
                do! assertRendered session "default"
                assertRequests session [ $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min.js" ]
            })

            browserTest "Rendering preserves data layout configuration descriptions and head tags" (fun session -> task {
                let chart =
                    lineChart ()
                    |> Chart.withTitle "A chart with explicit options"
                    |> Chart.withSize(Width = 480, Height = 320)
                    |> Chart.withConfig(Config.init(Responsive = false, DisplayModeBar = false))
                    |> GenericChart.setDisplayOptions(
                        DisplayOptions.init(
                            PlotlyJSReference = CDN assetUrl,
                            AdditionalHeadTags = [ script [] [ rawText "window.__additionalHeadTagRan = true;" ] ],
                            ChartDescription = [ p [ _class "chart-description" ] [ str "A retained chart description" ] ]
                        )
                    )
                do! render session "configured" chart
                do! assertRendered session "configured"
                let! retained = session.Page.EvaluateExpressionAsync<bool>("""(() => {
                    const graph = document.querySelector('#configured .js-plotly-plot');
                    return graph.data[0].x.join(',') === '1,2,3' && graph.data[0].y.join(',') === '4,6,5' &&
                        graph.layout.title.text === 'A chart with explicit options' &&
                        graph._fullLayout.width === 480 && graph._fullLayout.height === 320 &&
                        graph._context.responsive === false && graph._context.displayModeBar === false &&
                        document.querySelector('#configured .chart-description').textContent === 'A retained chart description' &&
                        window.__additionalHeadTagRan === true;
                })()""")
                Expect.isTrue retained "The adapter must preserve the chart's input options and additional content."
                do! assertCallCount session 1
                assertRequests session [ assetUrl ]
            })

            browserTest "A combined chart renders every trace" (fun session -> task {
                let chart =
                    Chart.combine [ lineChart (); Chart.Point(x = [ 2; 4 ], y = [ 1; 3 ], UseDefaults = false) ]
                    |> reference (CDN assetUrl)
                do! render session "combined" chart
                do! assertRendered session "combined"
                let! traces = session.Page.EvaluateExpressionAsync<int>("document.querySelector('#combined .js-plotly-plot').calcdata.length")
                Expect.equal traces 2 "A MultiChart must retain all traces when formatted."
                do! assertCallCount session 1
                assertRequests session [ assetUrl ]
            })

            noNetworkTest "Render rejections become visible output errors" (fun session -> task {
                do! session.Page.EvaluateFunctionAsync("() => { window.Plotly = { newPlot() { return Promise.reject(new Error('Deliberate render failure')); } }; }")
                do! render session "render-failure" (lineChart () |> reference NoReference)
                let! message = assertError session "render-failure"
                Expect.stringContains message "Deliberate render failure" "The output should preserve the useful renderer failure."
                do! assertCallCount session 1
                assertRequests session []
            })

            noNetworkTest "Synchronous render exceptions become visible output errors" (fun session -> task {
                do! session.Page.EvaluateFunctionAsync("() => { window.Plotly = { newPlot() { throw new Error('Deliberate synchronous failure'); } }; }")
                do! render session "render-throw" (lineChart () |> reference NoReference)
                let! message = assertError session "render-throw"
                Expect.stringContains message "Deliberate synchronous failure" "Synchronous failures must not escape the output's error handler."
                do! assertCallCount session 1
                assertRequests session []
            })
        ]
    )
