module Fix_3d_GridPosition

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open DynamicObj

// https://github.com/plotly/Plotly.NET/issues/413

module ``Remove all existing subplots from individual charts on grid creation #413`` = 
    
    let ``2x2 grid with only 3D charts and correct scene positioning`` =
        [
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
        ]
        |> Chart.Grid(2,2, SubPlotTitles = ["1";"2";"3";"4"])

    let ``2x2 grid chart creation ignores other scenes`` =
        [
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            |> Chart.withScene(Scene.init(), Id = 2)
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            |> Chart.withScene(Scene.init(), Id = 420)
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            |> Chart.withScene(Scene.init(), Id = 69)
            Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
            |> Chart.withScene(Scene.init(), Id = 1337)
        ]
        |> Chart.Grid(2,2, SubPlotTitles = ["1";"2";"3";"4"])