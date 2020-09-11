//#I "./bin/Debug"
//#r "./bin/Debug/netstandard2.0/Newtonsoft.Json.dll"
#r @"..\..\bin\Plotly.NET\netstandard2.0\Plotly.NET.dll"
#r "netstandard"

open Plotly.NET


let x = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let y = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let y' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

Chart.Spline(x,y',Name="spline") 
|> Chart.withConfig
    (Config.init
        (
            Autosizable = true,
            ShowEditInChartStudio = true,
            ToImageButtonOptions =
                ToImageButtonOptions.init
                    (
                        Format = StyleParam.ImageFormat.SVG,
                        Filename = "SOOOOS"
                    )
        )
    )
|> Chart.Show
//|> Chart.withYError(Options.Error(Array=[1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]))


//|> Chart.withLineStyle(Width=2,Dash=StyleParam.DrawingStyle.Dot)
//|> Chart.withLineOption(Options.Line(Width=10))
//|> Chart.withX_AxisStyle("x axis title") 
//|> Chart.withY_AxisStyle("y axis title") 
//|> layoutJson
//|> GenericChart.toChartHtmlWithSize 500 500

//|> Chart.ShowAsImage StyleParam.ImageFormat.SVG 

let dims' =
    [
        Dimensions.init(["Cat1";"Cat1";"Cat1";"Cat1";"Cat2";"Cat2";"Cat3"],Label="A")
        Dimensions.init([0;1;0;1;0;0;0],Label="B",TickText=["YES","NO"])
    ]
    
Chart.ParallelCategories(dims=dims',Color=[0.;1.;0.;1.;0.;0.;0.],Colorscale = StyleParam.Colorscale.Blackbody)
|> Chart.Show

let data3d = List.zip3 [0 .. 15] [0 .. 15] [0 .. 15]
let data2d = List.zip  [0 .. 15] [0 .. 15]

[
    Chart.Point (data2d)
    Chart.Scatter3d(xyz=data3d,mode = StyleParam.Mode.Markers)
    Chart.Scatter3d(xyz=data3d,mode = StyleParam.Mode.Markers)
    Chart.Scatter3d(xyz=data3d,mode = StyleParam.Mode.Markers)
    Chart.Scatter3d(xyz=data3d,mode = StyleParam.Mode.Markers)
]
|> Chart.Stack 2
|> Chart.Show









