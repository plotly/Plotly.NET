module Tests.ForeignChartFactory

open Giraffe.ViewEngine
open Plotly.NET

/// Invoked by reflection after this assembly and its chart dependencies are loaded in another ALC.
let create (mode: string) (multiple: bool) : obj =
    let first = Chart.Point(x = [ 1; 2 ], y = [ 3; 4 ], UseDefaults = false)
    let chart =
        if multiple then
            [ first; Chart.Line(x = [ 1; 2 ], y = [ 5; 6 ], UseDefaults = false) ] |> Chart.combine
        else first
    let reference =
        match mode with
        | "full" -> Full
        | "none" -> NoReference
        | "require" -> Require "https://example.invalid/plotly"
        | _ -> CDN "https://example.invalid/plotly.js"
    chart
    |> GenericChart.setDisplayOptions (
        DisplayOptions.init (
            PlotlyJSReference = reference,
            AdditionalHeadTags = [ style [] [ rawText ".foreign-chart { color: red; }" ] ],
            ChartDescription = [ p [ _class "foreign-chart" ] [ str "Foreign description" ] ]))
    |> box
