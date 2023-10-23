module Tests.ChartAPIs.WithAxis

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Newtonsoft.Json
open DynamicObj

let testAxis1() = LinearAxis.init(Title = Title.init("soos"))
let testAxis2() = LinearAxis.init(Title = Title.init("saas", X = 1., Y = 2.))
let combinedAxis() = LinearAxis.init(Title = Title.init("soos", X = 1., Y = 2.))

let combineXTargetChart() =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?xaxis <- testAxis2()
            l
    )

let combineYTargetChart() =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?yaxis <- testAxis2()
            l
    )

let combineZTargetChart() =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?scene <- Scene.init(ZAxis = testAxis2())
            l
    )
    

let combinedXAxisChart =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?xaxis <- combinedAxis()
            l
    )

let notCombinedXAxisChart =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?xaxis <- testAxis1()
            l
    )

let combinedYAxisChart =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?yaxis <- combinedAxis()
            l
    )

let notCombinedYAxisChart =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?yaxis <- testAxis1()
            l
    )

let combinedZAxisChart =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?scene <- Scene.init(ZAxis = combinedAxis())
            l
    )

let notCombinedZAxisChart =
    Chart.Invisible()
    |> GenericChart.mapLayout(
        fun l ->
            l?scene <- Scene.init(ZAxis = testAxis1())
            l
    )

[<Tests>]
let ``Chart.Combine layouts tests`` =
    testList "ChartAPIs.WithAxis" [
        testList "setAxis" [
            testCase "should combine x axis when combine is set to true" (fun _ ->
                let actual = 
                    combineXTargetChart() 
                    |> Chart.setAxis(
                        LinearAxis.init(Title = Title.init("soos")), 
                        StyleParam.SubPlotId.XAxis 1,
                        Combine = true
                    )
                Expect.equal actual combinedXAxisChart "Chart.setAxis did not set correct axis objects"
            )
            testCase "should not combine x axis when combine is set to false (default)" (fun _ ->
                let actual = 
                    combineXTargetChart() 
                    |> Chart.setAxis(
                        LinearAxis.init(Title = Title.init("soos")), 
                        StyleParam.SubPlotId.XAxis 1
                        
                    )
                Expect.equal actual notCombinedXAxisChart "Chart.setAxis did not set correct axis objects"
            )
            testCase "should combine y axis when combine is set to true" (fun _ ->
                let actual = 
                    combineYTargetChart() 
                    |> Chart.setAxis(
                        LinearAxis.init(Title = Title.init("soos")), 
                        StyleParam.SubPlotId.YAxis 1,
                        Combine = true
                    )
                Expect.equal actual combinedYAxisChart "Chart.setAxis did not set correct axis objects"
            )
            testCase "should not combine y axis when combine is set to false (default)" (fun _ ->
                let actual = 
                    combineYTargetChart() 
                    |> Chart.setAxis(
                        LinearAxis.init(Title = Title.init("soos")), 
                        StyleParam.SubPlotId.YAxis 1
                        
                    )
                Expect.equal actual notCombinedYAxisChart "Chart.setAxis did not set correct axis objects"
            )
            testCase "should combine z axis when combine is set to true" (fun _ ->
                let actual = 
                    combineZTargetChart() 
                    |> Chart.setAxis(
                        LinearAxis.init(Title = Title.init("soos")), 
                        StyleParam.SubPlotId.Scene 1,
                        SceneAxis = StyleParam.SubPlotId.ZAxis,
                        Combine = true
                    )
                Expect.equal actual combinedZAxisChart "Chart.setAxis did not set correct axis objects"
            )
            testCase "should not combine z axis when combine is set to false (default)" (fun _ ->
                let actual = 
                    combineZTargetChart() 
                    |> Chart.setAxis(
                        LinearAxis.init(Title = Title.init("soos")), 
                        StyleParam.SubPlotId.Scene 1,
                        SceneAxis = StyleParam.SubPlotId.ZAxis
                        
                    )
                Expect.equal actual notCombinedZAxisChart "Chart.setAxis did not set correct axis objects"
            )
        ]
        testList "withAxis" [
            testCase "should combine x axis" (fun _ ->
                let actual = 
                    combineXTargetChart() 
                    |> Chart.withXAxis(LinearAxis.init(Title = Title.init("soos")))
                Expect.equal actual combinedXAxisChart "Chart.withXAxis did not set correct axis objects"
            )
            testCase "should combine y axis" (fun _ ->
                let actual = 
                    combineYTargetChart() 
                    |> Chart.withYAxis(LinearAxis.init(Title = Title.init("soos")))
                Expect.equal actual combinedYAxisChart "Chart.withYAxis did not set correct axis objects"
            )
            testCase "should combine z axis" (fun _ ->
                let actual = 
                    combineZTargetChart() 
                    |> Chart.withZAxis(LinearAxis.init(Title = Title.init("soos")))
                Expect.equal actual combinedZAxisChart "Chart.withXAxis did not set correct axis objects"
            )
        ]
        testList "withAxisStyle" [
            testCase "should style x axis" (fun _ ->
                let actual = 
                    combineXTargetChart() 
                    |> Chart.withXAxisStyle(Title = Title.init("soos"))
                Expect.equal actual combinedXAxisChart "Chart.withXAxisStyle did not set correct axis styles"
            )
            testCase "should stlye y axis" (fun _ ->
                let actual = 
                    combineYTargetChart() 
                    |> Chart.withYAxisStyle(Title = Title.init("soos"))
                Expect.equal actual combinedYAxisChart "Chart.withYAxisStyle did not set correct axis styles"
            )
            testCase "should style z axis" (fun _ ->
                let actual = 
                    combineZTargetChart() 
                    |> Chart.withZAxisStyle(Title = Title.init("soos"))
                Expect.equal actual combinedZAxisChart "Chart.withXAxisStyle did not set correct axis styles"
            )
        ]
    ]