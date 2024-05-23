open System
open Deedle
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine
open Newtonsoft.Json

[<EntryPoint>]
let main args = 
    [
        Chart.Point(xy = [1,2; 2,3], UseDefaults = false)
        Chart.PointTernary(abc = [1,2,3; 2,3,4], UseDefaults = false)
        Chart.Heatmap(zData = [[1; 2];[3; 4]], ShowScale=false, UseDefaults = false)
        Chart.Point3D(xyz = [1,3,2], UseDefaults = false)
        Chart.PointMapbox(lonlat = [1,2], UseDefaults = false) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
        [
            // you can use nested combined charts, but they have to have the same trace type (Cartesian2D in this case)
            let y =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
            Chart.BoxPlot(X = "y" ,Y = y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
            Chart.BoxPlot(X = "y'",Y = y,Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
        ]
        |> Chart.combine
    ]
    |> Chart.SingleStack()
    |> Chart.withSize(1000,1000)
    |> Chart.show
    0