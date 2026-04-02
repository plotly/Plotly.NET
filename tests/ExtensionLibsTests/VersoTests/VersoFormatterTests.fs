module Tests.VersoFormatterTests

open Expecto
open Plotly.NET
open Plotly.NET.Verso
open Verso.Abstractions
open Verso.Testing
open Verso.Testing.Stubs

open TestUtils.HtmlCodegen

let formatter = GenericChartFormatter() :> IDataFormatter
let context = StubFormatterContext()

let sampleChart =
    Chart.Line(x = [1; 2; 3], y = [4; 6; 5], UseDefaults = false)
    |> Chart.withDisplayOptions (
        DisplayOptions.init (
            PlotlyJSReference = Require $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"
        )
    )

let sampleChartOffline =
    Chart.Line(x = [1; 2; 3], y = [4; 6; 5], UseDefaults = false)
    |> Chart.withDisplayOptions (
        DisplayOptions.init (
            PlotlyJSReference = Full
        )
    )

[<Tests>]
let ``GenericChartFormatter tests`` =
    testList "Verso.GenericChartFormatter" [

        testCase "SupportedTypes contains GenericChart" (fun () ->
            Expect.contains
                formatter.SupportedTypes
                (typeof<GenericChart>)
                "SupportedTypes should contain GenericChart"
        )

        testCase "CanFormat returns true for GenericChart" (fun () ->
            let chart = Chart.Point(x = [1; 2], y = [3; 4], UseDefaults = false)
            Expect.isTrue
                (formatter.CanFormat(chart, context))
                "CanFormat should return true for a GenericChart value"
        )

        testCase "CanFormat returns false for non-GenericChart" (fun () ->
            Expect.isFalse
                (formatter.CanFormat("not a chart", context))
                "CanFormat should return false for a string value"
        )

        testCase "CanFormat returns false for null" (fun () ->
            Expect.isFalse
                (formatter.CanFormat(null, context))
                "CanFormat should return false for null"
        )

        testCase "Priority is 100" (fun () ->
            Expect.equal
                formatter.Priority
                100
                "Priority should be 100"
        )

        testAsync "FormatAsync returns text/html CellOutput" {
            let! output = formatter.FormatAsync(sampleChart, context) |> Async.AwaitTask
            Expect.equal
                output.MimeType
                "text/html"
                "MimeType should be text/html"
        }

        testAsync "FormatAsync output contains chart div" {
            let! output = formatter.FormatAsync(sampleChart, context) |> Async.AwaitTask
            Expect.stringContains
                output.Content
                "Plotly chart will be drawn inside this DIV"
                "HTML should contain chart div placeholder"
        }

        testAsync "FormatAsync output is not an error" {
            let! output = formatter.FormatAsync(sampleChart, context) |> Async.AwaitTask
            Expect.isFalse
                output.IsError
                "Output should not be an error"
        }
    ]

[<Tests>]
let ``toVersoHTML tests`` =
    testList "Verso.Formatters.toVersoHTML" [

        testCase "require: Expecting cloudflare link" (fun () ->
            """https://cdnjs.cloudflare.com/ajax/libs/require.js"""
            |> chartGeneratedContains sampleChart
        )

        testCase "require: Expecting require config" (fun () ->
            sprintf """var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-%s.min'}}) || require;""" Globals.PLOTLYJS_VERSION
            |> chartGeneratedContains sampleChart
        )

        testCase "Contains chart data script" (fun () ->
            "Plotly.newPlot"
            |> chartGeneratedContains sampleChart
        )
    ]

[<Tests>]
let ``toVersoHTMLOffline tests`` =
    testList "Verso.Formatters.toVersoHTMLOffline" [

        testCase "Contains inline plotly.js source" (fun () ->
            "Plotly.newPlot"
            |> substringIsInChart sampleChartOffline GenericChart.toEmbeddedHTML
        )

        testCase "Contains full HTML document structure" (fun () ->
            ["<html>"; "</html>"; "<head>"; "</head>"; "<body>"; "</body>"]
            |> substringListIsInChart sampleChartOffline GenericChart.toEmbeddedHTML
        )

        testCase "Contains full plotly.js source" (fun () ->
            getFullPlotlyJS()
            |> substringIsInChart sampleChartOffline GenericChart.toEmbeddedHTML
        )
    ]
