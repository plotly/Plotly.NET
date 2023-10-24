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
let main argv =
    [
        Chart.Point(xy = [1,2; 2,3], Name = "2D Cartesian", UseDefaults = false)
        Chart.Point3D(xyz = [1,3,2], Name = "3D Cartesian", UseDefaults = false)
        Chart.PointPolar(rTheta = [10,20], Name = "Polar", UseDefaults = false)
        Chart.PointGeo(lonlat = [1,2], Name = "Geo", UseDefaults = false)
        Chart.PointMapbox(lonlat = [1,2], Name = "MapBox", UseDefaults = false) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
        Chart.PointTernary(abc = [1,2,3; 2,3,4], Name = "Ternary", UseDefaults = false)
        [
            Chart.Carpet(
                carpetId = "contour",
                A = [0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.],
                B = [4.; 4.; 4.; 4.; 5.; 5.; 5.; 5.; 6.; 6.; 6.; 6.],
                X = [2.; 3.; 4.; 5.; 2.2; 3.1; 4.1; 5.1; 1.5; 2.5; 3.5; 4.5],
                Y = [1.; 1.4; 1.6; 1.75; 2.; 2.5; 2.7; 2.75; 3.; 3.5; 3.7; 3.75],
                AAxis = LinearAxis.initCarpet(
                    TickPrefix = "a = ",
                    Smoothing = 0.,
                    MinorGridCount = 9,
                    AxisType = StyleParam.AxisType.Linear
                ),
                BAxis = LinearAxis.initCarpet(
                    TickPrefix = "b = ",
                    Smoothing = 0.,
                    MinorGridCount = 9,
                    AxisType = StyleParam.AxisType.Linear
                ), 
                UseDefaults = false,
                Opacity = 0.75
            )    
            Chart.ContourCarpet(
                z = [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
                carpetAnchorId = "contour",
                A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
                B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6], 
                UseDefaults = false,
                ContourLineColor = Color.fromKeyword White,
                ShowContourLabels = true,
                ShowScale = false
            )
        ]
        |> Chart.combine
        Chart.Pie(values = [10;40;50;], Name = "Domain", UseDefaults = false)
        Chart.BubbleSmith(
            real = [0.5; 1.; 2.; 3.],
            imag = [0.5; 1.; 2.; 3.],
            sizes = [10;20;30;40],
            MultiText=["one";"two";"three";"four";"five";"six";"seven"],
            TextPosition=StyleParam.TextPosition.TopCenter,
            Name = "Smith",
            UseDefaults = false
        )
        [
            // you can use nested combined charts, but they have to have the same trace type (Cartesian2D in this case)
            let y =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
            Chart.BoxPlot(X = "y" ,Y = y,Name="Combined 1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
            Chart.BoxPlot(X = "y'",Y = y,Name="Combined 2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
        ]
        |> Chart.combine
    ]
    |> Chart.Grid(4,3)
    |> Chart.withSize(1000,1000)
    |> Chart.show
    0