module Tests.LayoutObjects.Trace

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects




[<Tests>]
let ``TraceStyle tests`` =
    testList "Traces.Trace static members" [

        let marker = Marker.init(Color=Color.fromKeyword Red, Opacity = 0.)
        let markerTrace = Trace2D.initScatter(Trace2DStyle.Scatter(Marker = marker))

        testCase "getMarker" (fun _ ->
            Expect.equal
                (markerTrace |> Trace.getMarker)
                marker
                "TraceStyle.getMarker did not return the correct marker object"
        )
        testCase "setMarker" (fun _ ->
            Expect.equal
                (Trace2D.initScatter(id) |> Trace.setMarker(Marker.init(Color=Color.fromKeyword Red, Opacity = 0.)))
                markerTrace
                "TraceStyle.setMarker did not produce the correct trace object"
        )

        let line = Line.init(Color=Color.fromKeyword Red, Width = 0.)
        let lineTrace = Trace2D.initScatter(Trace2DStyle.Scatter(Line = line))

        testCase "getLine" (fun _ ->
            Expect.equal
                (lineTrace |> Trace.getLine)
                line
                "TraceStyle.getLine did not return the correct line object"
        )
        testCase "setLine" (fun _ ->
            Expect.equal
                (Trace2D.initScatter(id) |> Trace.setLine(Line.init(Color=Color.fromKeyword Red, Width = 0.)))
                lineTrace
                "TraceStyle.setLine did not produce the correct trace object"
        )

        let error = Error.init(Value = 2., Symmetric = true)
        let xErrorTrace = Trace3D.initScatter3D(Trace3DStyle.Scatter3D(XError = error))
        let yErrorTrace = Trace3D.initScatter3D(Trace3DStyle.Scatter3D(YError = error))
        let zErrorTrace = Trace3D.initScatter3D(Trace3DStyle.Scatter3D(ZError = error))

        testCase "getXError" (fun _ ->
            Expect.equal
                (xErrorTrace |> Trace.getXError)
                error
                "TraceStyle.getXError did not return the correct error object"
        )
        testCase "setXError" (fun _ ->
            Expect.equal
                (Trace3D.initScatter3D(id) |> Trace.setXError(Error.init(Value = 2., Symmetric = true)))
                xErrorTrace
                "TraceStyle.setXError did not produce the correct trace object"
        )
        testCase "getYError" (fun _ ->
            Expect.equal
                (yErrorTrace |> Trace.getYError)
                error
                "TraceStyle.getYError did not return the correct error object"
        )
        testCase "setYError" (fun _ ->
            Expect.equal
                (Trace3D.initScatter3D(id) |> Trace.setYError(Error.init(Value = 2., Symmetric = true)))
                yErrorTrace
                "TraceStyle.setYError did not produce the correct trace object"
        )
        testCase "getZError" (fun _ ->
            Expect.equal
                (zErrorTrace |> Trace.getZError)
                error
                "TraceStyle.getZError did not return the correct error object"
        )
        testCase "setZError" (fun _ ->
            Expect.equal
                (Trace3D.initScatter3D(id) |> Trace.setZError(Error.init(Value = 2., Symmetric = true)))
                zErrorTrace
                "TraceStyle.setZError did not produce the correct trace object"
        )
        
        let colorAxisAnchor = StyleParam.SubPlotId.ColorAxis 69
        let colorAxisAnchorTrace = Trace2D.initScatter(Trace2DStyle.Heatmap(ColorAxis = colorAxisAnchor))

        testCase "getColorAxisAnchor" (fun _ ->
            Expect.equal
                (colorAxisAnchorTrace |> Trace.getColorAxisAnchor)
                colorAxisAnchor
                "TraceStyle.getStackGroup did not return the correct color axis anchor"
        )
        testCase "setColorAxisAnchor" (fun _ ->
            Expect.equal
                (Trace2D.initHeatmap(id) |> Trace.setColorAxisAnchor 69)
                colorAxisAnchorTrace
                "TraceStyle.setColorAxisAnchor did not produce the correct trace object"
        )

        let domain = Domain.init(Row = 1, Column = 2)
        let domainTrace = TraceDomain.initPie(TraceDomainStyle.Pie(Domain = domain))

        testCase "getDomain" (fun _ ->
            Expect.equal
                (domainTrace |> Trace.getDomain)
                domain
                "TraceStyle.getDomain did not return the correct domain object"
        )
        testCase "setDomain" (fun _ ->
            Expect.equal
                (TraceDomain.initPie(id) |> Trace.setDomain (Domain.init(Row = 1, Column = 2)))
                domainTrace
                "TraceStyle.setDomain did not produce the correct trace object"
        )

        let stackGroup = "soos"
        let stackGroupTrace = Trace2D.initScatter(Trace2DStyle.Scatter(StackGroup = stackGroup))

        testCase "getStackGroup" (fun _ ->
            Expect.equal
                (stackGroupTrace |> Trace.getStackGroup)
                stackGroup
                "TraceStyle.getStackGroup did not return the correct stack group"
        )
        testCase "setStackGroup" (fun _ ->
            Expect.equal
                (Trace2D.initScatter(id) |> Trace.setStackGroup "soos")
                stackGroupTrace
                "TraceStyle.setStackGroup did not produce the correct trace object"
        )
    ]