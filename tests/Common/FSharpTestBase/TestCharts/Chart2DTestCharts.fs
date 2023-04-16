module Chart2DTestCharts

open Plotly.NET

module Point =
    
    let ``Point chart with full plotly.js reference`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(xData, yData, UseDefaults = false)
        |> Chart.withDisplayOptions(
            DisplayOptions.init(
                PlotlyJSReference = Full
            )
        )
        
    let ``Point chart with plotly.js cdn reference`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(xData, yData, UseDefaults = false)
        |> Chart.withDisplayOptions(
            DisplayOptions.init(
                PlotlyJSReference = CDN $"https://cdn.plot.ly/plotly-2.0.0.min"
            )
        )

    let ``Point chart referencing plotly.js using require.js`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(xData, yData, UseDefaults = false)
        |> Chart.withDisplayOptions(
            DisplayOptions.init(
                PlotlyJSReference = Require $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"
            )
        )

    let ``Point chart with axis labels and title`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(x = xData, y = yData, UseDefaults = false)
        |> Chart.withTitle "Hello world!"
        |> Chart.withXAxisStyle (TitleText = "xAxis", ShowGrid=false)
        |> Chart.withYAxisStyle (TitleText = "yAxis", ShowGrid=false)

    let ``Point chart with text labels`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        let labels  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]
        Chart.Point(
            x = x,y = y,
            Name="points",
            MultiText=labels,
            TextPosition=StyleParam.TextPosition.TopRight, 
            UseDefaults = false
        )

module Line = 

    let ``Simple line chart`` = Chart.Line([ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ], UseDefaults = false)

    let ``Line chart with line styling`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        Chart.Line(
            x = x,
            y = y,
            Name="line",
            ShowMarkers=true,
            MarkerSymbol=StyleParam.MarkerSymbol.Square,
            UseDefaults = false
        )    
        |> Chart.withLineStyle(Width=2.,Dash=StyleParam.DrawingStyle.Dot)

module Spline =

    let ``Simple spline chart`` = 
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        Chart.Spline(x = x, y = y, Name="spline", UseDefaults = false)   

        
module Bubble = 

    let ``Simple bubble chart`` =
        let x = [2; 4; 6;]
        let y = [4; 1; 6;]
        let size = [19; 26; 55;]
        Chart.Bubble(x = x, y = y,sizes = size, UseDefaults = false)

module Range = 

    let ``Styled range chart`` =
        let rnd = System.Random(5)
    
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    
        let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
        let yLower = y |> List.map (fun v -> v - rnd.NextDouble())
        Chart.Range(
            x = x, 
            y = y,
            upper = yUpper,
            lower = yLower,
            mode = StyleParam.Mode.Lines_Markers,
            MarkerColor=Color.fromString "grey",
            RangeColor=Color.fromString "lightblue", 
            UseDefaults = false)

module Area = 
    
    let ``Simple area chart`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
        Chart.Area(x = x, y = y, UseDefaults = false)

module SplineArea = 
    
    let ``Simple spline area chart`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
        Chart.SplineArea(x = x, y = y, UseDefaults = false)

module StackedArea = 
    
    let ``Two stacked areas chart`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
        [
            Chart.StackedArea(x = x, y = y, UseDefaults = false)
            Chart.StackedArea(x = x, y = (y |> Seq.rev), UseDefaults = false)
        ]
        |> Chart.combine


module Funnel = ()

module StackedFunnel = ()

module Waterfall = ()

module Bar = 

    let ``Simple bar chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        Chart.Bar(values = values, Keys = keys, UseDefaults = false)

    let ``Two stacked bars chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        [
            Chart.StackedBar(values = values, Keys = keys, Name="old", UseDefaults = false);
            Chart.StackedBar(values = [8; 21; 13;], Keys = keys, Name="new", UseDefaults = false)
        ]
        |> Chart.combine

module StackedBar = ()

module Column = 

    let ``Simple column chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        Chart.Column(values = values, Keys = keys, UseDefaults = false)

    let ``Two stacked columns chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        [
            Chart.StackedColumn(values = values, Keys = keys,Name="old", UseDefaults = false);
            Chart.StackedColumn(values = [8; 21; 13;], Keys = keys,Name="new", UseDefaults = false)
        ]
        |> Chart.combine

module StackedColumn = ()

module Histogram = ()

module Histogram2D = ()

module BoxPlot = ()

module Violin = ()

module Histogram2DContour = ()

module Heatmap = 
    
    let ``simple heatmap with custom colorscale`` =
        let matrix =
            [[1.;1.5;0.7;2.7];
            [2.;0.5;1.2;1.4];
            [0.1;2.6;2.4;3.0];]
    
        let rownames = ["p3";"p2";"p1"]
        let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
    
        let colorscaleValue = 
            StyleParam.Colorscale.Custom [(0.0,Color.fromString "#3D9970");(1.0,Color.fromString "#001f3f")]
    
        Chart.Heatmap(
            zData = matrix,
            colNames = colnames,
            rowNames = rownames,
            ColorScale=colorscaleValue,
            ShowScale=true, 
            UseDefaults = false
        )
        |> Chart.withSize(700,500)
        |> Chart.withMarginSize(Left=200.)

        
    let ``Simple heatmal with custom colorscale and styled colorbar`` =
        let matrix =
            [[1.;1.5;0.7;2.7];
            [2.;0.5;1.2;1.4];
            [0.1;2.6;2.4;3.0];]
    
        let rownames = ["p3";"p2";"p1"]
        let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
    
        let colorscaleValue = 
            StyleParam.Colorscale.Custom [(0.0,Color.fromString "#3D9970");(1.0,Color.fromString "#001f3f")]
    
        Chart.Heatmap(
            zData = matrix,
            colNames = colnames,
            rowNames = rownames,
            ColorScale=colorscaleValue,
            ShowScale=true, 
            UseDefaults = false
        )
        |> Chart.withSize(700.,500.)
        |> Chart.withMarginSize(Left=200.)
        |> Chart.withColorBarStyle(TitleText = "Im the Colorbar")


module AnnotatedHeatmap = 


    let ``Simple annotated heatmap`` = 
        Chart.AnnotatedHeatmap(
            zData = [
                [1..5]
                [6..10]
                [11..15]
            ],
            annotationText = [
                ["1,1";"1,2";"1,3"]
                ["2,1";"2,2";"2,3"]
                ["3,1";"3,2";"3,3"]
            ],
            X = ["C1";"C2";"C3"],
            Y = ["R1";"R2";"R3"],
            ReverseYAxis = true,
            UseDefaults = false
        )

module Image = 

    let private colors = [
        [[0  ;0  ;255]; [255;255;0  ]; [0  ;0  ;255]]
        [[255;0  ;0  ]; [255;0  ;255]; [255;0  ;255]]
        [[0  ;255;0  ]; [0  ;255;255]; [255;0  ;0  ]]
    ]

    let ``Raw color component image chart`` = 
        Chart.Image(Z=colors, UseDefaults = false)
        |> Chart.withTitle "Image chart from raw color component arrays"

    let ``HSL image chart`` = 
        Chart.Image(Z=colors, ColorModel=StyleParam.ColorModel.HSL, UseDefaults = false)
        |> Chart.withTitle "HSL color model"

    let ``ARGB image chart`` = 
        let argbs = [
            [ColorKeyword.AliceBlue     ; ColorKeyword.CornSilk ; ColorKeyword.LavenderBlush ] |> List.map ARGB.fromKeyword
            [ColorKeyword.DarkGray      ; ColorKeyword.Snow     ; ColorKeyword.MidnightBlue  ] |> List.map ARGB.fromKeyword
            [ColorKeyword.LightSteelBlue; ColorKeyword.DarkKhaki; ColorKeyword.LightAkyBlue  ] |> List.map ARGB.fromKeyword
        ]
        Chart.Image(z = argbs, UseDefaults = false)
        |> Chart.withTitle "ARGB image chart"

    let ``Image chart from base64 string`` = 
        let base64String = TestUtils.getLogoPNG()
        Chart.Image(
            Source=($"data:image/jpg;base64,{base64String}"),
            UseDefaults = false
        )
        |> Chart.withTitle "This is Plotly.NET:"

module Contour = ()

module OHLC = ()

module Candlestick = ()

module Splom = ()

module PointDensity = ()