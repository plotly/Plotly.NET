module Tests.LayoutObjects.TraceID

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


let allTraceTypesChart =
    [
        Chart.Point([])
        Chart.Point3D([])
        Chart.PointPolar([])
        Chart.ChoroplethMap([],[])
        Chart.ChoroplethMapbox([],[],obj)
        Chart.PointTernary([1,2,3])
        Chart.PointCarpet([], "")
        Chart.Pie([2])
        [
            Chart.PointCarpet([], "")
            Chart.Pie([2])
        ]
        |> Chart.combine
    ]
    |> Chart.combine

[<Tests>]
let ``TraceID tests`` =
    testList "Traces.TraceID" [
        testCase "extract single TraceID from Chart" (fun _ ->
            Expect.equal
                (allTraceTypesChart |> GenericChart.getTraceID)
                TraceID.Multi
                "GenericChart.getTraceID did not return the correct TraceID for all traces"
            )
        testCase "extract all TraceIDS from Chart" (fun _ ->
            Expect.equal
                (allTraceTypesChart |> GenericChart.getTraceIDs)
                [
                    TraceID.Cartesian2D
                    TraceID.Cartesian3D
                    TraceID.Polar
                    TraceID.Geo
                    TraceID.Mapbox
                    TraceID.Ternary
                    TraceID.Carpet
                    TraceID.Domain                    
                    TraceID.Carpet
                    TraceID.Domain
                ]
                "GenericChart.getTraceIDs did not return the correct TraceIDs for all traces."
        )
    ]