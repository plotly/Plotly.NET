module Tests.ChartLayout

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open Giraffe.ViewEngine

open TestUtils.HtmlCodegen

let axisStylingChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let plot1 =
        Chart.Point(x = x,y = y, UseDefaults = false)
        |> Chart.withXAxisStyle (TitleText = "X axis title quack quack", MinMax = (-1.,10.))
        |> Chart.withYAxisStyle (TitleText = "Y axis title boo foo", MinMax = (-1.,10.))
    plot1


[<Tests>]
let ``Axis styling`` =
    testList "ChartLayout.Axis styling tests" [
        testCase "X With axis has title" ( fun c ->
            "\"title\":{\"text\":\"X axis title quack quack\"}"
            |> chartGeneratedContains axisStylingChart
        );
        testCase "Y With axis has title" ( fun c ->
            "\"title\":{\"text\":\"Y axis title boo foo\"}"
            |> chartGeneratedContains axisStylingChart
        );
        testCase "Should have range" ( fun c ->
            "\"range\":[-1.0,10.0]"
            |> chartGeneratedContains axisStylingChart
        )
    ]


let multipleAxesChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y' = y |> List.map (fun y -> y * 2.) |> List.rev

    let anchoredAt1 =
        Chart.Line (x = x,y = y,Name="anchor 1", UseDefaults = false)
            |> Chart.withAxisAnchor(Y=1)
    
    let anchoredAt2 =
         Chart.Line (x = x,y = y',Name="anchor 2", UseDefaults = false)
            |> Chart.withAxisAnchor(Y=2)
    
    let twoYAxes1 = 
        [
           anchoredAt1
           anchoredAt2
        ]
        |> Chart.combine
        |> Chart.withYAxisStyle(
            TitleText = "axis 1",
            Side=StyleParam.Side.Left,
            Id= StyleParam.SubPlotId.YAxis 1
        )
        |> Chart.withYAxisStyle(
            TitleText = "axis2",
            Side=StyleParam.Side.Right,
            Id=StyleParam.SubPlotId.YAxis 2,
            Overlaying=StyleParam.LinearAxisId.Y 1
        )
    twoYAxes1

[<Tests>]
let ``Multiple Axes styling`` =
    testList "ChartLayout.Multiple Axes styling tests" [
        testCase "Layout" ( fun () ->
            "var layout = {\"yaxis\":{\"title\":{\"text\":\"axis 1\"},\"side\":\"left\"},\"yaxis2\":{\"title\":{\"text\":\"axis2\"},\"side\":\"right\",\"overlaying\":\"y\"}};"
            |> chartGeneratedContains multipleAxesChart
        );
    ]


let errorBarsChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let xError = [|0.2;0.3;0.2;0.1;0.2;0.4;0.2;0.08;0.2;0.1;|]
    let yError = [|0.3;0.2;0.1;0.4;0.2;0.4;0.1;0.18;0.02;0.2;|]
    Chart.Point(x = x,y=y',Name="points with errors", UseDefaults = false)    
    |> Chart.withXErrorStyle (Array=xError,Symmetric=true)
    |> Chart.withYErrorStyle (Array=yError, Arrayminus = xError)


[<Tests>]
let ``Error bars`` =
    testList "ChartLayout.Error bars tests" [
        testCase "Full data test" ( fun () ->
            """var data = [{"type":"scatter","name":"points with errors","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"error_x":{"symmetric":true,"array":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]},"error_y":{"array":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],"arrayminus":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}}];"""
            |> chartGeneratedContains errorBarsChart
        );
        testCase "Expecting name" ( fun () ->
            "\"name\":\"points with errors\""
            |> chartGeneratedContains errorBarsChart
        );
        testCase "Expecting error X data" ( fun () ->
            "\"error_x\":{\"symmetric\":true,\"array\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}"
            |> chartGeneratedContains errorBarsChart
        );
        testCase "Expecting error Y data" ( fun () ->
            "\"error_y\":{\"array\":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],\"arrayminus\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}"
            |> chartGeneratedContains errorBarsChart
        );
    ]


let combinedChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Line(x = x, y = y, Name="first", UseDefaults = false)
        Chart.Line(x = y, y = x, Name="second", UseDefaults = false)
    ]
    |> Chart.combine

let subPlotChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x = x, y = y, Name="1,1", UseDefaults = false)
        |> Chart.withXAxisStyle "x1"
        |> Chart.withYAxisStyle "y1"    
        Chart.Line(x = x, y = y, Name="1,2", UseDefaults = false)
        |> Chart.withXAxisStyle "x2"
        |> Chart.withYAxisStyle "y2"
        Chart.Spline(x = x, y = y, Name="2,1", UseDefaults = false)
        |> Chart.withXAxisStyle "x3"
        |> Chart.withYAxisStyle "y3"    
        Chart.Point(x = x, y = y, Name="2,2", UseDefaults = false)
        |> Chart.withXAxisStyle "x4"
        |> Chart.withYAxisStyle "y4"
    ]
    |> Chart.Grid(2, 2)


let singleStackChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x = x, y = y, UseDefaults = false) 
        |> Chart.withYAxisStyle("This title must")
    
        Chart.Line(x = x, y = y, UseDefaults = false) 
        |> Chart.withYAxisStyle("be set on the",ZeroLine=false)
        
        Chart.Spline(x = x, y = y, UseDefaults = false) 
        |> Chart.withYAxisStyle("respective subplots",ZeroLine=false)
    ]
    |> Chart.SingleStack(Pattern = StyleParam.LayoutGridPattern.Coupled)
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withXAxisStyle("im the shared xAxis")

let multiTraceGrid = 
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

let multiTraceSingleStack = 
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

[<Tests>]
let ``Multicharts and subplots`` =
    testList "ChartLayout.Multicharts and subplots" [
        testCase "Combining" ( fun () ->
            """var data = [{"type":"scatter","name":"first","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}},{"type":"scatter","name":"second","mode":"lines","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains combinedChart
        );
        testCase "Subplot grids data" ( fun () ->
            """var data = [{"type":"scatter","name":"1,1","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","name":"1,2","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","name":"2,1","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{"shape":"spline"},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","name":"2,2","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"xaxis":"x4","yaxis":"y4"}];"""
            |> chartGeneratedContains subPlotChart
        );
        testCase "Subplot grids layout" ( fun () ->
            """var layout = {"yaxis":{"title":{"text":"y1"}},"xaxis":{"title":{"text":"x1"}},"yaxis2":{"title":{"text":"y2"}},"xaxis2":{"title":{"text":"x2"}},"yaxis3":{"title":{"text":"y3"}},"xaxis3":{"title":{"text":"x3"}},"yaxis4":{"title":{"text":"y4"}},"xaxis4":{"title":{"text":"x4"}},"annotations":[],"grid":{"rows":2,"columns":2,"roworder":"top to bottom","pattern":"independent"}};"""
            |> chartGeneratedContains subPlotChart
        );        
        testCase "MultiTrace Subplot grid data" ( fun () ->
            """var data = [{"type":"scatter","name":"2D Cartesian","mode":"markers","x":[1,2],"y":[2,3],"marker":{},"line":{},"xaxis":"x","yaxis":"y"},{"type":"scatter3d","name":"3D Cartesian","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene2"},{"type":"scatterpolar","name":"Polar","mode":"markers","r":[10],"theta":[20],"marker":{},"subplot":"polar3"},{"type":"scattergeo","name":"Geo","mode":"markers","lat":[2],"lon":[1],"marker":{},"line":{},"geo":"geo4"},{"type":"scattermapbox","name":"MapBox","mode":"markers","lat":[2],"lon":[1],"cluster":{},"marker":{},"line":{},"subplot":"mapbox5"},{"type":"scatterternary","name":"Ternary","mode":"markers","a":[1,2],"b":[2,3],"c":[3,4],"marker":{},"line":{},"subplot":"ternary6"},{"type":"carpet","opacity":0.75,"x":[2.0,3.0,4.0,5.0,2.2,3.1,4.1,5.1,1.5,2.5,3.5,4.5],"y":[1.0,1.4,1.6,1.75,2.0,2.5,2.7,2.75,3.0,3.5,3.7,3.75],"a":[0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0],"b":[4.0,4.0,4.0,4.0,5.0,5.0,5.0,5.0,6.0,6.0,6.0,6.0],"aaxis":{"type":"linear","tickprefix":"a = ","minorgridcount":9,"smoothing":0.0},"baxis":{"type":"linear","tickprefix":"b = ","minorgridcount":9,"smoothing":0.0},"carpet":"contour","xaxis":"x7","yaxis":"y7"},{"type":"contourcarpet","z":[1.0,1.96,2.56,3.0625,4.0,5.0625,1.0,7.5625,9.0,12.25,15.21,14.0625],"a":[0,1,2,3,0,1,2,3,0,1,2,3],"b":[4,4,4,4,5,5,5,5,6,6,6,6],"line":{"color":"rgba(255, 255, 255, 1.0)"},"showscale":false,"carpet":"contour","contours":{"showlabels":true}},{"type":"pie","name":"Domain","values":[10,40,50],"marker":{"line":{},"pattern":{}},"domain":{"row":2,"column":1}},{"type":"scattersmith","name":"Smith","mode":"markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["one","two","three","four","five","six","seven"],"textposition":"top center","marker":{"size":[10,20,30,40]},"line":{},"subplot":"smith9"},{"type":"box","name":"Combined 1","x":"y","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"boxpoints":"all","jitter":0.1,"xaxis":"x10","yaxis":"y10"},{"type":"box","name":"Combined 2","x":"y'","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"boxpoints":"all","jitter":0.1,"xaxis":"x10","yaxis":"y10"}];"""
            |> chartGeneratedContains multiTraceGrid
        );
        testCase "MultiTrace Subplot grid layout" ( fun () ->
            """var layout = {"xaxis":{},"yaxis":{},"scene2":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":0,"column":1}},"polar3":{"domain":{"row":0,"column":2}},"geo4":{"domain":{"row":1,"column":0}},"mapbox5":{"style":"open-street-map","domain":{"row":1,"column":1}},"ternary6":{"domain":{"row":1,"column":2}},"xaxis7":{},"yaxis7":{},"smith9":{"domain":{"row":2,"column":2}},"xaxis10":{},"yaxis10":{},"annotations":[],"grid":{"rows":4,"columns":3,"roworder":"top to bottom","pattern":"independent"},"width":1000,"height":1000};"""
            |> chartGeneratedContains multiTraceGrid
        );
        testCase "Single Stack data" ( fun () -> 
            """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{"shape":"spline"},"xaxis":"x","yaxis":"y3"}];"""
            |> chartGeneratedContains singleStackChart
        );
        testCase "Single Stack layout" ( fun () -> 
            """var layout = {"xaxis":{"title":{"text":"im the shared xAxis"}},"yaxis":{"title":{"text":"This title must"}},"xaxis2":{},"yaxis2":{"title":{"text":"be set on the"},"zeroline":false},"xaxis3":{},"yaxis3":{"title":{"text":"respective subplots"},"zeroline":false},"annotations":[],"grid":{"rows":3,"columns":1,"roworder":"top to bottom","pattern":"coupled","ygap":0.1,"xside":"bottom"},"title":{"text":"Hi i am the new SingleStackChart"}};"""
            |> chartGeneratedContains singleStackChart
        );        
        
        testCase "MultiTrace Single Stack data" ( fun () -> 
            """var data = [{"type":"scatter","mode":"markers","x":[1,2],"y":[2,3],"marker":{},"line":{},"xaxis":"x","yaxis":"y"},{"type":"scatterternary","mode":"markers","a":[1,2],"b":[2,3],"c":[3,4],"marker":{},"line":{},"subplot":"ternary2"},{"type":"heatmap","z":[[1,2],[3,4]],"showscale":false,"xaxis":"x3","yaxis":"y3"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"marker":{},"line":{},"scene":"scene4"},{"type":"scattermapbox","mode":"markers","lat":[2],"lon":[1],"cluster":{},"marker":{},"line":{},"subplot":"mapbox5"},{"type":"box","name":"bin1","x":"y","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"boxpoints":"all","jitter":0.1,"xaxis":"x6","yaxis":"y6"},{"type":"box","name":"bin2","x":"y'","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{},"boxpoints":"all","jitter":0.1,"xaxis":"x6","yaxis":"y6"}];"""
            |> chartGeneratedContains multiTraceSingleStack
        );
        testCase "MultiTrace Single Stack layout" ( fun () -> 
            """var layout = {"xaxis":{},"yaxis":{},"ternary2":{"domain":{"row":1,"column":0}},"xaxis3":{},"yaxis3":{},"scene4":{"camera":{"projection":{"type":"perspective"}},"domain":{"row":3,"column":0}},"mapbox5":{"style":"open-street-map","domain":{"row":4,"column":0}},"xaxis6":{},"yaxis6":{},"annotations":[],"grid":{"rows":6,"columns":1,"roworder":"top to bottom","pattern":"independent"},"width":1000,"height":1000};"""
            |> chartGeneratedContains multiTraceSingleStack
        );
    ]


let shapesChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let s1 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Rectangle,
            X0=2.,X1=4.,Y0=3.,Y1=4.,
            Opacity=0.3,
            FillColor=Color.fromHex "#d3d3d3"
        )
    let s2 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Circle,
            X0=5.,X1=7.,Y0=3.,Y1=4.,
            Opacity=0.3,
            FillColor=Color.fromHex "#d3d3d3"
        )
    let s3 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Line,
                X0=1.,X1=2.,Y0=1.,Y1=2.,
                Opacity=0.3,
                FillColor=Color.fromHex "#d3d3d3"
        )
    let s4 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.SvgPath,
            Path=" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z"
        )
    Chart.Line(x = x,y = y',Name="line", UseDefaults = false)    
    |> Chart.withShapes([s1;s2;s3;s4])

let shapesWithLabelsChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let s1 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Rectangle,
            X0=2.,X1=4.,Y0=3.,Y1=4.,
            Opacity=0.3,
            FillColor=Color.fromHex "#d3d3d3",
            Label = ShapeLabel.init(Text="Rectangle")
        )
    let s2 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Circle,
            X0=5.,X1=7.,Y0=3.,Y1=4.,
            Opacity=0.3,
            FillColor=Color.fromHex "#d3d3d3",
            Label = ShapeLabel.init(Text="Circle")
        )
    let s3 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Line,
                X0=1.,X1=2.,Y0=1.,Y1=2.,
                Opacity=0.3,
                FillColor=Color.fromHex "#d3d3d3",
                Label = ShapeLabel.init(Text="Line")
        )
    let s4 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.SvgPath,
            Path=" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z",
            Label = ShapeLabel.init(Text="SVGPath", TextAngle = StyleParam.TextAngle.Degrees 33)
        )
    Chart.Line(x = x,y = y',Name="line", UseDefaults = false)    
    |> Chart.withShapes([s1;s2;s3;s4])


[<Tests>]
let ``Shapes`` =
    testList "ChartLayout.Shapes" [
        testCase "Shapes Data" ( fun () ->
            """var data = [{"type":"scatter","name":"line","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains shapesChart
        );
        testCase "Shapes Layout" ( fun () ->
            """var layout = {"shapes":[{"fillcolor":"rgba(211, 211, 211, 1.0)","opacity":0.3,"type":"rect","x0":2.0,"x1":4.0,"y0":3.0,"y1":4.0},{"fillcolor":"rgba(211, 211, 211, 1.0)","opacity":0.3,"type":"circle","x0":5.0,"x1":7.0,"y0":3.0,"y1":4.0},{"fillcolor":"rgba(211, 211, 211, 1.0)","opacity":0.3,"type":"line","x0":1.0,"x1":2.0,"y0":1.0,"y1":2.0},{"path":" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z","type":"path"}]};"""
            |> chartGeneratedContains shapesChart
        );        
        testCase "Shapes with labels Data" ( fun () ->
            """var data = [{"type":"scatter","name":"line","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains shapesWithLabelsChart
        );
        testCase "Shapes with labels Layout" ( fun () ->
            """var layout = {"shapes":[{"fillcolor":"rgba(211, 211, 211, 1.0)","label":{"text":"Rectangle"},"opacity":0.3,"type":"rect","x0":2.0,"x1":4.0,"y0":3.0,"y1":4.0},{"fillcolor":"rgba(211, 211, 211, 1.0)","label":{"text":"Circle"},"opacity":0.3,"type":"circle","x0":5.0,"x1":7.0,"y0":3.0,"y1":4.0},{"fillcolor":"rgba(211, 211, 211, 1.0)","label":{"text":"Line"},"opacity":0.3,"type":"line","x0":1.0,"x1":2.0,"y0":1.0,"y1":2.0},{"label":{"text":"SVGPath","textangle":33.0},"path":" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z","type":"path"}]};"""
            |> chartGeneratedContains shapesWithLabelsChart
        );
    ]

let displayOptionsChartDescriptionChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let description1 = [
        h3 [] [str "Hello"]
        p [] [str "F#"] 
    ]
    Chart.Point(x = x,y = y,Name="desc1", UseDefaults = false)    
    |> Chart.withDescription(description1)
    
let additionalHeadTagsChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let bulmaHero = 
        section [_class"hero is-primary is-bold"] [
            div [_class "hero-body"] [
              p [_class "title"] [str "Hero title"]
              p [_class "subtitle"] [str "Hero subtitle"]
            ]
        ]
    // chart description containing bulma classes
    let description3 = [
        h1 [_class "title"] [str "I am heading"]
        bulmaHero
    ]
    Chart.Point(x = x,y = y,Name="desc3", UseDefaults = false)    
    |> Chart.withDescription description3
    // Add reference to the bulma css framework
    |> Chart.withAdditionalHeadTags [link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bulma@0.9.2/css/bulma.min.css"]]

let mathtexv3Chart =
    [
        Chart.Point(xy = [(1.,2.)], Name = @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$", UseDefaults = false)
        Chart.Point(xy = [(2.,4.)], Name = @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$", UseDefaults = false)
    ]
    |> Chart.combine
    |> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
    // include mathtex tags in <head>. pass true to append these scripts, false to ONLY include MathTeX.
    |> Chart.withMathTex(true)

let mathtexv2Chart =
    [
        Chart.Point(xy = [(1.,2.)], Name = @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$", UseDefaults = false)
        Chart.Point(xy = [(2.,4.)], Name = @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$", UseDefaults = false)
    ]
    |> Chart.combine
    |> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
    // include mathtex tags in <head>. pass true to append these scripts, false to ONLY include MathTeX.
    |> Chart.withMathTex(true, MathJaxVersion = 2)

[<Tests>]
let ``Display options`` =
    testList "ChartLayout.Display options" [
        testCase "Chart description data" ( fun () ->
            """var data = [{"type":"scatter","name":"desc1","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains displayOptionsChartDescriptionChart
        );
        testCase "Chart description layout" ( fun () ->
            "var layout = {};"
            |> chartGeneratedContains displayOptionsChartDescriptionChart
        );
        testCase "Chart description header" ( fun () ->
            "<h3>Hello</h3>"
            |> substringIsInChart displayOptionsChartDescriptionChart GenericChart.toEmbeddedHTML
        );
        testCase "Chart description paragraph" ( fun () ->
            "<p>F#</p>"
            |> substringIsInChart displayOptionsChartDescriptionChart GenericChart.toEmbeddedHTML
        );
        testCase "Additional head tags" ( fun () ->
            [ "<h1 class=\"title\">I am heading</h1>"
              "<section class=\"hero is-primary is-bold\">"
              "<div class=\"hero-body\">"
              "<p class=\"title\">"
              "Hero title"
              "<p class=\"subtitle\">"
              "Hero subtitle"
            ]
            |> substringListIsInChart additionalHeadTagsChart GenericChart.toEmbeddedHTML
        );
        testCase "MathTex v2 data" ( fun () ->
            """var data = [{"type":"scatter","name":"$\\beta_{1c} = 25 \\pm 11 \\text{ km s}^{-1}$","mode":"markers","x":[1.0],"y":[2.0],"marker":{},"line":{}},{"type":"scatter","name":"$\\beta_{1c} = 25 \\pm 11 \\text{ km s}^{-1}$","mode":"markers","x":[2.0],"y":[4.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains mathtexv2Chart
        );
        testCase "MathTex v2 layout" ( fun () ->
            "var layout = {\"title\":{\"text\":\"$\\\\beta_{1c} = 25 \\\\pm 11 \\\\text{ km s}^{-1}$\"}};"
            |> chartGeneratedContains mathtexv2Chart
        );
        testCase "MathTex v2 include mathjax" ( fun () ->
            "https://cdnjs.cloudflare.com/ajax/libs/mathjax/"
            |> substringIsInChart mathtexv2Chart GenericChart.toEmbeddedHTML
        )        
        testCase "MathTex v3 data" ( fun () ->
            """var data = [{"type":"scatter","name":"$\\beta_{1c} = 25 \\pm 11 \\text{ km s}^{-1}$","mode":"markers","x":[1.0],"y":[2.0],"marker":{},"line":{}},{"type":"scatter","name":"$\\beta_{1c} = 25 \\pm 11 \\text{ km s}^{-1}$","mode":"markers","x":[2.0],"y":[4.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains mathtexv3Chart
        );
        testCase "MathTex v3 layout" ( fun () ->
            "var layout = {\"title\":{\"text\":\"$\\\\beta_{1c} = 25 \\\\pm 11 \\\\text{ km s}^{-1}$\"}};"
            |> chartGeneratedContains mathtexv3Chart
        );
        testCase "MathTex v3 include mathjax" ( fun () ->
            "https://cdn.jsdelivr.net/npm/mathjax@3"
            |> substringIsInChart mathtexv3Chart GenericChart.toEmbeddedHTML
        )
    ]