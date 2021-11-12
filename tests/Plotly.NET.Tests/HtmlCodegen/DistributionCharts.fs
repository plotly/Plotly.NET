module Tests.DistributionCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

let histoChart =
    let rnd = System.Random(5)
    let x = [for i=0 to 500 do yield rnd.NextDouble() ]
    Chart.Histogram(x, UseDefaults = false)
    |> Chart.withSize(500, 500)

[<Tests>]
let ``Histogram charts`` =
    testList "DistributionCharts.Histogram charts" [
        testCase "Histo data" ( fun () ->
            // the string is too big to be here fully.
            [
                "var data = [{\"type\":\"histogram\",\"x\":[0.33836984091362443,0.2844184475412678,0.2629626417825756,0.6253758443637638,0.46346185284827923,0.9283738280312968,0.1463105539541275,0.9505998873853124,0.5961332552116985"
                "0.7608672612164483,0.8280196519699039,0.040246858280267035,0.0017312127173557937],\"marker\":{}}];"
            ]
            |> chartGeneratedContainsList histoChart
        );
        testCase "Histo layout" ( fun () ->
            "var layout = {\"width\":500,\"height\":500};"
            |> chartGeneratedContains histoChart
        );
    ]

let box1Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.BoxPlot(x,y,Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false)

let box2Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.BoxPlot(y,x,Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All,Orientation=StyleParam.Orientation.Horizontal, UseDefaults = false)

let box3Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
        Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All, UseDefaults = false);
    ]
    |> Chart.combine

[<Tests>]
let ``Box charts`` =
    testList "DistributionCharts.Box charts" [
        testCase "Box1 data" ( fun () ->
            """var data = [{"type":"box","x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"marker":{}}];"""
            |> chartGeneratedContains box1Chart
        );
        testCase "Box1 layout" ( fun () ->
            emptyLayout box1Chart
        );
        testCase "Box2 data" ( fun () ->
            """var data = [{"type":"box","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"orientation":"h","boxpoints":"all","jitter":0.1,"marker":{}}];"""
            |> chartGeneratedContains box2Chart
        );
        testCase "Box2 layout" ( fun () ->
            emptyLayout box2Chart
        );
        testCase "Box3 data" ( fun () ->
            """ar data = [{"type":"box","x":"y","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"name":"bin1","marker":{}},{"type":"box","x":"y'","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"name":"bin2","marker":{}}];"""
            |> chartGeneratedContains box3Chart
        );
        testCase "Box3 layout" ( fun () ->
            emptyLayout box3Chart
        );
    ]


let violin1Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.Violin (
        x,y,
        Points=StyleParam.JitterPoints.All, 
        UseDefaults = false
    )

let violin2Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.Violin(
        y,x,
        Jitter=0.1,
        Points=StyleParam.JitterPoints.All,
        Orientation=StyleParam.Orientation.Horizontal,
        MeanLine=MeanLine.init(Visible=true), 
        UseDefaults = false
    )

let violin3Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Violin ("y" ,y,Name="bin1",Jitter=0.1,Points=StyleParam.JitterPoints.All, UseDefaults = false);
        Chart.Violin ("y'",y',Name="bin2",Jitter=0.1,Points=StyleParam.JitterPoints.All, UseDefaults = false);
    ]
    |> Chart.combine

[<Tests>]
let ``Violin charts`` =
    testList "DistributionCharts.Violin charts" [
        testCase "Violin1 data" ( fun () ->
            """var data = [{"type":"violin","x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"box":{},"points":"all","marker":{}}];"""
            |> chartGeneratedContains violin1Chart
        );
        testCase "Violin1 layout" ( fun () ->
            emptyLayout violin1Chart
        );
        testCase "Violin2 data" ( fun () ->
            """var data = [{"type":"violin","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"orientation":"h","box":{},"jitter":0.1,"meanline":{"visible":true},"points":"all","marker":{}}];"""
            |> chartGeneratedContains violin2Chart
        );
        testCase "Violin2 layout" ( fun () ->
            emptyLayout violin2Chart
        );
        testCase "Violin3 data" ( fun () ->
            """var data = [{"type":"violin","name":"bin1","x":"y","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"box":{},"jitter":0.1,"points":"all","marker":{}},{"type":"violin","name":"bin2","x":"y'","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"box":{},"jitter":0.1,"points":"all","marker":{}}];"""
            |> chartGeneratedContains violin3Chart
        );
        testCase "Violin3 layout" ( fun () ->
            emptyLayout violin3Chart
        );
    ]

let contourChart =
    // Generate linearly spaced vector
    let linspace (min,max,n) = 
        if n <= 2 then failwithf "n needs to be larger then 2"
        let bw = float (max - min) / (float n - 1.)
        [|min ..bw ..max|]
    
    // Create example data
    let size = 100
    let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
    let y = linspace(-2. * Math.PI, 2. * Math.PI, size)
    
    let f x y = - (5. * x / (x**2. + y**2. + 1.) )
    
    let z = 
        Array.init size (fun i -> 
            Array.init size (fun j -> 
                f x.[j] y.[i] 
            )
        )

    Chart.Contour(z, UseDefaults = false)
    |> Chart.withSize(600.,600.)

[<Tests>]
let ``Contour charts`` =
    testList "DistributionCharts.Contour charts" [
        testCase "Contour data" ( fun () ->
            "var data = [{\"type\":\"contour\",\"z\":[[0.3929110807586562,0.39272903726671055,0.3923748718856843,0.3918384347714509,0.39110921172503726,0.39017633288191317,0.38902858492457726"
            |> chartGeneratedContains contourChart
        );
        testCase "Contour layout" ( fun () ->
            "var layout = {\"width\":600,\"height\":600};"
            |> chartGeneratedContains contourChart
        );
    ]

let histogramContourChart =
    let normal (rnd:System.Random) mu tau =
        let mutable v1 = 2.0 * rnd.NextDouble() - 1.0
        let mutable v2 = 2.0 * rnd.NextDouble() - 1.0
        let mutable r = v1 * v1 + v2 * v2
        while (r >= 1.0 || r = 0.0) do
            v1 <- 2.0 * rnd.NextDouble() - 1.0
            v2 <- 2.0 * rnd.NextDouble() - 1.0
            r <- v1 * v1 + v2 * v2
        let fac = sqrt(-2.0*(log r)/r)
        (tau * v1 * fac + mu)
    
    let rnd = System.Random(5)
    let n = 2000
    let a = -1.
    let b = 1.2
    let step i = a +  ((b - a) / float (n - 1)) * float i
    
    //---------------------- generate data distributed in x and y direction ---------------------- 
    let x = Array.init n (fun i -> ((step i)**3.) + (0.3 * (normal (rnd) 0. 2.) ))
    let y = Array.init n (fun i -> ((step i)**6.) + (0.3 * (normal (rnd) 0. 2.) ))
    [
        Chart.Histogram2DContour (x,y,Line=Line.init(Width=0.), UseDefaults = false)
        Chart.Point(x,y,Opacity=0.3, UseDefaults = false)
    ]
    |> Chart.combine


let histogram2DChart =
    let normal (rnd:System.Random) mu tau =
        let mutable v1 = 2.0 * rnd.NextDouble() - 1.0
        let mutable v2 = 2.0 * rnd.NextDouble() - 1.0
        let mutable r = v1 * v1 + v2 * v2
        while (r >= 1.0 || r = 0.0) do
            v1 <- 2.0 * rnd.NextDouble() - 1.0
            v2 <- 2.0 * rnd.NextDouble() - 1.0
            r <- v1 * v1 + v2 * v2
        let fac = sqrt(-2.0*(log r)/r)
        (tau * v1 * fac + mu)
    
    let rnd = System.Random(5)
    let n = 2000
    let a = -1.
    let b = 1.2
    let step i = a +  ((b - a) / float (n - 1)) * float i
    
    //---------------------- generate data distributed in x and y direction ---------------------- 
    let x = Array.init n (fun i -> ((step i)**3.) + (0.3 * (normal (rnd) 0. 2.) ))
    let y = Array.init n (fun i -> ((step i)**6.) + (0.3 * (normal (rnd) 0. 2.) ))
    Chart.Histogram2D (x,y, UseDefaults = false)

[<Tests>]
let ``Histogram 2D charts`` =
    testList "DistributionCharts.Histogram charts" [
        testCase "Histo contour data" ( fun () ->
            "var data = [{\"type\":\"histogram2Dcontour\",\"x\":[-1.566002360265054,-1.833996340961623,-1.0330391275776571,-0.8476993487909306,-0.8471270832604864,-1.021055309868153,-0.5368298779218124,-0.9982579324563884,-0.6367576994858231,-1.433590036163408,-1.3735531103452598"
            |> chartGeneratedContains histogramContourChart
        );
        testCase "Histo contour layout" ( fun () ->
            emptyLayout histogramContourChart
        );
        testCase "Histo 2D data" ( fun () ->
            "var data = [{\"type\":\"histogram2D\",\"x\":[-1.566002360265054,-1.833996340961623,-1.0330391275776571,-0.8476993487909306,-0.8471270832604864,-1.021055309868153,-0.5368298779218124,-0.9982579324563884,-0.6367576994858231,-1.433590036163408,-1.3735531103452598"
            |> chartGeneratedContains histogram2DChart
        );
        testCase "Histo 2D layout" ( fun () ->
            emptyLayout histogram2DChart
        );
    ]


let scatterplotMatrixChart =
    let data = 
        [
            "A",[|1.;4.;3.4;0.7;|]
            "B",[|3.;1.5;1.7;2.3;|]
            "C",[|2.;4.;3.1;5.|]
            "D",[|4.;2.;2.;4.;|]
        ]
    Chart.Splom(data, Color=Color.fromString "blue", UseDefaults = false)

[<Tests>]
let ``Scatterplot matrix charts`` =
    testList "DistributionCharts.Scatterplot matrix charts" [
        testCase "Scatterplot data" ( fun () ->
            "var data = [{\"type\":\"splom\",\"dimensions\":[{\"values\":[1.0,4.0,3.4,0.7],\"label\":\"A\"},{\"values\":[3.0,1.5,1.7,2.3],\"label\":\"B\"},{\"values\":[2.0,4.0,3.1,5.0],\"label\":\"C\"},{\"values\":[4.0,2.0,2.0,4.0],\"label\":\"D\"}],\"line\":{\"color\":\"blue\"}}];"
            |> chartGeneratedContains scatterplotMatrixChart
        );
        testCase "Scatterplot layout" ( fun () ->
            emptyLayout scatterplotMatrixChart
        );
    ]