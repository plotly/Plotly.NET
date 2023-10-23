module Tests.LayoutObjects.TraceStyle

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


let createEmptyTrace() = Trace2D.initScatter(id)

[<Tests>]
let ``TraceStyle tests`` =
    testList "Traces.TraceStyle" [
        testCase "Marker" (fun _ ->
            Expect.equal
                (createEmptyTrace() |> TraceStyle.Marker(Color=Color.fromKeyword Red, Opacity = 0.))
                (Trace2D.initScatter(Trace2DStyle.Scatter(Marker = Marker.init(Color=Color.fromKeyword Red, Opacity = 0.))))
                "TraceStyle.Marker did not produce the correct trace object"
        )
        testCase "Line" (fun _ ->
            Expect.equal
                (createEmptyTrace() |> TraceStyle.Line(Color=Color.fromKeyword Red, Width = 0.))
                (Trace2D.initScatter(Trace2DStyle.Scatter(Line = Line.init(Color=Color.fromKeyword Red, Width = 0.))))
                "TraceStyle.Line did not produce the correct trace object"
        )
    ]