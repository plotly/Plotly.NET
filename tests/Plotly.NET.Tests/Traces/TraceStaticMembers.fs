module Tests.LayoutObjects.Trace

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart

let createEmpty2DTrace() = Trace2D.initScatter(id)
let createEmpty3DTrace() = Trace3D.initScatter3D(id)

[<Tests>]
let ``TraceStyle tests`` =
    testList "Traces.Trace static members" [

        let marker = Marker.init(Color=Color.fromKeyword Red, Opacity = 0.)
        let markerTrace = Trace2D.initScatter(Trace2DStyle.Scatter(Marker = marker))

        testCase "SetMarker" (fun _ ->
            Expect.equal
                (createEmpty2DTrace() |> Trace.setMarker(Marker.init(Color=Color.fromKeyword Red, Opacity = 0.)))
                markerTrace
                "TraceStyle.SetMarker did not produce the correct trace object"
        )
        testCase "GetMarker" (fun _ ->
            Expect.equal
                (markerTrace |> Trace.getMarker)
                marker
                "TraceStyle.GetMarker did not return the correct marker object"
        )

        let line = Line.init(Color=Color.fromKeyword Red, Width = 0.)
        let lineTrace = Trace2D.initScatter(Trace2DStyle.Scatter(Line = line))

        testCase "SetLine" (fun _ ->
            Expect.equal
                (createEmpty2DTrace() |> Trace.setLine(Line.init(Color=Color.fromKeyword Red, Width = 0.)))
                lineTrace
                "TraceStyle.SetLine did not produce the correct trace object"
        )
        testCase "GetLine" (fun _ ->
            Expect.equal
                (lineTrace |> Trace.getLine)
                line
                "TraceStyle.GetLine did not return the correct line object"
        )

        let error = Error.init(Value = 2., Symmetric = true)
        let xErrorTrace = Trace3D.initScatter3D(Trace3DStyle.Scatter3D(XError = error))
        let yErrorTrace = Trace3D.initScatter3D(Trace3DStyle.Scatter3D(YError = error))
        let zErrorTrace = Trace3D.initScatter3D(Trace3DStyle.Scatter3D(ZError = error))

        testCase "SetXError" (fun _ ->
            Expect.equal
                (createEmpty3DTrace() |> Trace.SetXError(Error.init(Value = 2., Symmetric = true)))
                xErrorTrace
                "TraceStyle.SetXError did not produce the correct trace object"
        )
        testCase "GetXError" (fun _ ->
            Expect.equal
                (xErrorTrace |> Trace.GetXError)
                error
                "TraceStyle.GetXError did not return the correct error object"
        )
        testCase "SetYError" (fun _ ->
            Expect.equal
                (createEmpty3DTrace() |> Trace.SetYError(Error.init(Value = 2., Symmetric = true)))
                yErrorTrace
                "TraceStyle.SetYError did not produce the correct trace object"
        )
        testCase "GetYError" (fun _ ->
            Expect.equal
                (yErrorTrace |> Trace.GetYError)
                error
                "TraceStyle.GetYError did not return the correct error object"
        )
        testCase "SetZError" (fun _ ->
            Expect.equal
                (createEmpty3DTrace() |> Trace.SetZError(Error.init(Value = 2., Symmetric = true)))
                zErrorTrace
                "TraceStyle.SetZError did not produce the correct trace object"
        )
        testCase "GetZError" (fun _ ->
            Expect.equal
                (zErrorTrace |> Trace.GetZError)
                error
                "TraceStyle.GetZError did not return the correct error object"
        )
        
    ]