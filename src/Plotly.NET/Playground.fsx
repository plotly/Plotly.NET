#r "nuget: FSharp.Data"
#r "nuget: Deedle"
#r "nuget: FSharpAux"
#r "nuget: DynamicObj"
#r "nuget: Newtonsoft.Json, 13.0.1"

#load "InternalUtils.fs"

#I "CommonAbstractions"

#load "StyleParams.fs"
#load "ColorKeyword.fs"
#load "Colors.fs"
#load "Frame.fs"
#load "Font.fs"
#load "Title.fs"
#load "Line.fs"

#I "Layout/ObjectAbstractions/Common"

#load "LayoutImage.fs"
#load "Button.fs"
#load "RangeSelector.fs"
#load "RangeSlider.fs"
#load "Transition.fs"
#load "ActiveShape.fs"
#load "ModeBar.fs"
#load "DefaultColorScales.fs"
#load "UniformText.fs"
#load "Margin.fs"
#load "Domain.fs"
#load "Shape.fs"
#load "Hoverlabel.fs"
#load "Annotation.fs"
#load "LayoutGrid.fs"
#load "Legend.fs"
#load "TickFormatStop.fs"
#load "ColorBar.fs"
#load "Rangebreak.fs"
#load "LinearAxis.fs"
#load "ColorAxis.fs"
#load "Padding.fs"

#I "Layout/ObjectAbstractions/Map"

#load "GeoProjection.fs"
#load "Geo.fs"
#load "MapboxLayerSymbol.fs"
#load "MapboxLayer.fs"
#load "Mapbox.fs"

#I "Layout/ObjectAbstractions/3D"

#load "Camera.fs"
#load "AspectRatio.fs"
#load "Scene.fs"

#I "Layout/ObjectAbstractions/Polar"

#load "AngularAxis.fs"
#load "RadialAxis.fs"
#load "Polar.fs"

#I "Layout/ObjectAbstractions/Ternary"

#load "Ternary.fs"

#I "Layout/ObjectAbstractions/Common/Slider"

#load "SliderCurrentValue.fs"
#load "SliderStep.fs"
#load "Slider.fs"

#load "Layout/Layout.fs"

#I "Traces/ObjectAbstractions"

#load "Gradient.fs"
#load "Pattern.fs"
#load "Marker.fs"
#load "Projection.fs"
#load "Surface.fs"
#load "SpaceFrame.fs"
#load "Slices.fs"
#load "Caps.fs"
#load "StreamTubeStarts.fs"
#load "Lighting.fs"
#load "Selection.fs"
#load "StockData.fs"
#load "Pathbar.fs"
#load "TreemapTiling.fs"
#load "Contours.fs"
#load "Dimensions.fs"
#load "WaterfallConnector.fs"
#load "FunnelConnector.fs"
#load "Box.fs"
#load "MeanLine.fs"
#load "Bins.fs"
#load "Cumulative.fs"
#load "Error.fs"
#load "Table.fs"
#load "Indicator.fs"
#load "Icicle.fs"

#I "Traces"

#load "Trace.fs"
#load "Trace2D.fs"
#load "Trace3D.fs"
#load "TracePolar.fs"
#load "TraceGeo.fs"
#load "TraceMapbox.fs"
#load "TraceTernary.fs"
#load "TraceCarpet.fs"
#load "TraceDomain.fs"
#load "TraceID.fs"

#I "Config/ObjectAbstractions"

#load "ToImageButtonOptions.fs"

#I "Config"

#load "Config.fs"

#I "DisplayOptions"

#load "DisplayOptions.fs"

#I "Templates"

#load "Template.fs"
#load "ChartTemplates.fs"
#load "Defaults.fs"

#I "ChartAPI"

#load "GenericChart.fs"
#load "Chart.fs"
#load "Chart2D.fs"
#load "Chart3D.fs"
#load "ChartPolar.fs"
#load "ChartMap.fs"
#load "ChartTernary.fs"
#load "ChartCarpet.fs"
#load "ChartDomain.fs"

#I "CSharpLayer"

#load "GenericChartExtensions.fs"

#I "Extensions"

#load "SankeyExtension.fs"

open DynamicObj

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects

open FSharp.Data
open Newtonsoft.Json
open System.Text
open System.IO
open Deedle
open FSharpAux

open System
open System.IO

Chart.Line([1,2; 3,4])
|> Chart.show

let layout =
    Layout.init (Font = Font.init (Family = StyleParam.FontFamily.Raleway, Size = 14.))

let traceTemplates = [
    Trace2D.initScatter (
        Trace2DStyle.Scatter(Marker = Marker.init (Symbol = StyleParam.MarkerSymbol.Diamond, Size = 20))
    )
    Trace2D.initScatter (
        Trace2DStyle.Scatter(Marker = Marker.init (Symbol = StyleParam.MarkerSymbol.ArrowBarLeft, Size = 10))
    )
]

let template = Template.init (layout, traceTemplates)

[
    Chart.Scatter(x = [ 0; 1; 2 ], y = [ 2; 1; 3 ], mode = StyleParam.Mode.Markers)
    Chart.Scatter(x = [ 0; 1; 2 ], y = [ 1; 2; 4 ], mode = StyleParam.Mode.Markers)
]
|> Chart.combine
|> Chart.withLayout (Layout.init (Title = Title.init ("Figure Title")))
|> Chart.withTemplate template
//|> GenericChart.mapTrace (fun t -> t.Remove("marker"); t)
|> Chart.show

let y=[2.37; 2.16; 4.82; 1.73; 1.04; 0.23; 1.32; 2.91; 0.11; 4.51; 0.51; 3.75; 1.35; 2.98; 4.50; 0.18; 4.66; 1.30; 2.06; 1.19]

[
    Chart.BoxPlot(y=y,BoxPoints=StyleParam.BoxPoints.All,Jitter=0.5,Notched=true,MarkerColor = Color.fromString "red",BoxMean=StyleParam.BoxMean.True,Name="Only Mean");
    Chart.BoxPlot(y=y,BoxPoints=StyleParam.BoxPoints.All,Jitter=0.5,Notched=true,MarkerColor = Color.fromString "blue",BoxMean=StyleParam.BoxMean.SD,Name="Mean & SD")
]
|> Chart.combine
|> Chart.show

Chart.Histogram2DContour(
    [for _ in 0 .. 10000 do yield System.Random().NextDouble()], 
    [for _ in 0 .. 10000 do yield System.Random().NextDouble()],
    LineDash = StyleParam.DrawingStyle.DashDot,
    NContours= 20,
    LineColor= Color.fromKeyword White,
    ColorScale = StyleParam.Colorscale.Viridis
)
|> Chart.show

[
    Chart.Histogram(
        [for i in 0 .. 10000 do yield System.Random().NextDouble() *  10.], 
        StyleParam.Orientation.Vertical,
        HistFunc = StyleParam.HistFunc.Avg,
        HistNorm = StyleParam.HistNorm.ProbabilityDensity,
        BinGroup = "myHist",
        Opacity = 0.6,
        Cumulative = Cumulative.init(Enabled=true)
    )    
    Chart.Histogram(
        [for i in 0 .. 1000 do yield System.Random().NextDouble() *  10.], 
        StyleParam.Orientation.Vertical,
        HistFunc = StyleParam.HistFunc.Avg,
        HistNorm = StyleParam.HistNorm.ProbabilityDensity,
        BinGroup = "myHist",
        Opacity = 0.6,
        Cumulative = Cumulative.init(Enabled=true,Direction = StyleParam.CumulativeDirection.Decreasing)
    )
]
|> Chart.combine
|> Chart.withLayout(
    Layout.init(
        BarMode = StyleParam.BarMode.Overlay
    )
)
|> Chart.show

let violin1Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.Violin (
        x,y,
        Points=StyleParam.JitterPoints.All
    )

let violin2Chart =
    let x =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.Violin(
        x,y,
        Jitter=0.1,
        Points=StyleParam.JitterPoints.All,
        Orientation=StyleParam.Orientation.Horizontal,
        MeanLine=MeanLine.init(Visible=true)
    )

let violin3Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Violin ("y" ,y,Name="bin1",Jitter=0.1,Points=StyleParam.JitterPoints.All);
        Chart.Violin ("y'",y',Name="bin2",Jitter=0.1,Points=StyleParam.JitterPoints.All);
    ]
    |> Chart.combine

violin1Chart |> Chart.show
violin2Chart |> Chart.show
violin3Chart |> Chart.show

let character   = ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"]
let parent      = [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ]

Chart.Icicle(
    character,
    parent,
    ShowScale = true,
    ColorScale = StyleParam.Colorscale.Viridis,
    TilingOrientation = StyleParam.Orientation.Vertical,
    TilingFlip = StyleParam.TilingFlip.Y,
    PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash
)
|> Chart.show

[
    Chart.Indicator(
        120., StyleParam.IndicatorMode.NumberDeltaGauge,
        Title = "Bullet gauge",
        DeltaReference = 90.,
        Range = StyleParam.Range.MinMax(-200., 200.),
        GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
        ShowGaugeAxis = false,
        Domain  = Domain.init(Row = 0, Column = 0)
    )
    Chart.Indicator(
        200., StyleParam.IndicatorMode.NumberDeltaGauge,
        Title = "Angular gauge",
        Delta = IndicatorDelta.init(Reference=160),
        Range = StyleParam.Range.MinMax(0., 250.),
        Domain = Domain.init(Row = 0, Column = 1)
    )
    Chart.Indicator(
        300., StyleParam.IndicatorMode.NumberDelta,
        Title = "number and delta",
        DeltaReference = 90.,
        Domain  = Domain.init(Row = 1, Column = 0)
    )        
    Chart.Indicator(
        40., StyleParam.IndicatorMode.Delta,
        Title = "delta",
        DeltaReference = 90.,
        Domain  = Domain.init(Row = 1, Column = 1)
    )
]
|> Chart.combine
|> Chart.withLayoutGridStyle(Rows = 2, Columns = 2)
|> Chart.withMarginSize(Left = 200)
|> Chart.show


[
    Chart.Carpet(
        "contour",
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
        )
    )    
    Chart.ContourCarpet(
        "contour",
        [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
        A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
        B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6]
    )
]
|> Chart.combine
|> Chart.show

let a = [4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6.]
let b = [1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.]
let y = [2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10.]

let carpets = 
    [
        Chart.Carpet("carpet1",A = a, B = b, Y = y)
        Chart.Carpet("carpet2",A = (a |> List.rev) , B = (b |> List.rev), Y = (y |> List.map (fun x -> x + 10.)))
        Chart.Carpet("carpet3",A = a, B = b, Y = (y |> List.map (fun x -> x + 20.)))
        Chart.Carpet("carpet4",A = (a |> List.rev) , B = (b |> List.rev), Y = (y |> List.map (fun x -> x + 30.)))
        Chart.Carpet("carpet5",A = a, B = b, Y = (y |> List.map (fun x -> x + 40.)))
    ]

let aData = [4.; 5.; 5.; 6.]
let bData = [1.; 1.; 2.; 3.]
let sizes = [5; 10; 15; 20]

let carpetCharts =
    [
        Chart.ScatterCarpet(
            aData,bData,
            StyleParam.Mode.Lines_Markers,
            "carpet1",
            Name = "Scatter",
            MultiMarkerSymbol =[
                StyleParam.MarkerSymbol.ArrowDown
                StyleParam.MarkerSymbol.TriangleNW
                StyleParam.MarkerSymbol.DiamondX
                StyleParam.MarkerSymbol.Hexagon2
            ],
            MultiSize = sizes,
            Color = Color.fromColors ([Red; Blue; Green; Yellow] |> List.map Color.fromKeyword)
        )
        Chart.PointCarpet(aData,bData,"carpet2",Name = "Point")
        Chart.LineCarpet(aData,bData,"carpet3",Name = "Line")
        Chart.SplineCarpet(aData,bData,"carpet4",Name = "Spline")
        Chart.BubbleCarpet((Seq.zip3 aData bData sizes),"carpet5",Name = "Bubble")
    ]

let scatter = Chart.combine [carpets.[0]; carpetCharts.[0]]
let point   = Chart.combine [carpets.[1]; carpetCharts.[1]]
let line    = Chart.combine [carpets.[2]; carpetCharts.[2]]
let spline  = Chart.combine [carpets.[3]; carpetCharts.[3]]
let bubble  = Chart.combine [carpets.[4]; carpetCharts.[4]]

scatter |> Chart.show
point   |> Chart.show
line    |> Chart.show
spline  |> Chart.show
bubble  |> Chart.show 


let crazyMarker =
    Marker.init(
        MultiSymbol = [
            StyleParam.MarkerSymbol.ArrowBarDown
            StyleParam.MarkerSymbol.Modified(StyleParam.MarkerSymbol.DiamondCross, StyleParam.SymbolStyle.OpenDot)
            StyleParam.MarkerSymbol.Modified(StyleParam.MarkerSymbol.Square, StyleParam.SymbolStyle.Open)
            StyleParam.MarkerSymbol.Modified(StyleParam.MarkerSymbol.Hexagon2, StyleParam.SymbolStyle.Dot)
        ],
        MultiSize = [50;60;100;70],
        MultiOpacity = [0.3; 0.6; 0.9; 1.],
        Color = Color.fromColorScaleValues [0.; 0.5; 1.; 0.8],
        Colorscale = StyleParam.Colorscale.Viridis,
        ShowScale = true
    )

Chart.Point [1,1; 2,2; 3,3; 4,4]
|> Chart.withMarker crazyMarker
|> Chart.show


let labels, values = 
    [
        "A", 1
        "B", 3
        "C", 2
        "D", 4
        "E", 6
        "F", 5
        "G", 7
        "H", 8
    ]
    |> List.unzip

Chart.Bar(
    values,
    Color = Color.fromColorScaleValues values
)
|> Chart.withMarkerStyle(
    Colorscale = StyleParam.Colorscale.Viridis,
    ShowScale = true,
    Pattern = Pattern.init(
        MultiShape = [
            StyleParam.PatternShape.None 
            StyleParam.PatternShape.DiagonalDescending
            StyleParam.PatternShape.DiagonalAscending
            StyleParam.PatternShape.DiagonalChecked
            StyleParam.PatternShape.HorizontalLines
            StyleParam.PatternShape.VerticalLines
            StyleParam.PatternShape.Checked
            StyleParam.PatternShape.Dots
        ]
    )
)
|> Chart.show



Chart.Line([0.; 0.5; 1.; 2.; 2.2], y=[1.23; 2.5; 0.42; 3.; 1.])
|> Chart.withLayoutImage(
    LayoutImage.init(
        Source="https://fsharp.org/img/logo/fsharp.svg",
        XRef="x",
        YRef="y",
        X=0,
        Y=3,
        SizeX=2,
        SizeY=2,
        Sizing=StyleParam.LayoutImageSizing.Stretch,
        Opacity=0.5,
        Layer=StyleParam.Layer.Below
    )
)
|> Chart.show

let imagebase64 =
    System.Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\schne\Pictures\Untitled.jpg"))

Chart.Image(
    Source=($"data:image/jpg;base64,{imagebase64}")
)
|> Chart.show

let colors = [
    [[0  ;0  ;255]; [255;255;0  ]; [0  ;0  ;255]]
    [[255;0  ;0  ]; [255;0  ;255]; [255;0  ;255]]
    [[0  ;255;0  ]; [0  ;255;255]; [255;0  ;0  ]]
]

Chart.Image(
    Z=colors
)
|> Chart.show

let argbs = [
    [(0  ,0  ,255); (0  ,255,255); (0  ,0  ,255)] |> List.map (fun (r,g,b) -> ARGB.fromRGB r g b )
    [(255,0  ,0  ); (255,0  ,255); (0  ,0  ,0  )] |> List.map (fun (r,g,b) -> ARGB.fromRGB r g b )
    [(0  ,255,0  ); (255,255,0  ); (0  ,0  ,255)] |> List.map (fun (r,g,b) -> ARGB.fromRGB r g b )
]

Chart.Image(
    argbs
)
|> Chart.show

Chart.ScatterTernary(
    A = [1; 2; 3],
    B = [3; 2; 1],
    C = [0; 1; 2],
    Labels = ["A"; "B"; "C"],
    Mode= StyleParam.Mode.Lines_Markers_Text,
    TextPosition = StyleParam.TextPosition.BottomCenter
)
|> Chart.withLineStyle(Shape=StyleParam.Shape.Spline)
|> Chart.withMarkerStyle(Symbol = StyleParam.MarkerSymbol.Cross)
|> Chart.show

Chart.LineTernary(
    A = [10; 20; 30; 40; 50; 60; 70; 80;],
    B = ([10; 20; 30; 40; 50; 60; 70; 80;] |> List.rev),
    Sum = 100,
    ShowMarkers = true,
    Dash = StyleParam.DrawingStyle.DashDot
)
|> Chart.withTernary(
    Ternary.init(
        AAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkOrchid),
        BAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkRed),
        CAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkCyan)
    )
)
|> Chart.show

Chart.PointTernary([1,2,3])
|> Chart.withAAxis(LinearAxis.init(Title = Title.init("A"), Color = Color.fromKeyword ColorKeyword.DarkOrchid))
|> Chart.withBAxis(LinearAxis.init(Title = Title.init("B"), Color = Color.fromKeyword ColorKeyword.DarkRed))
|> Chart.withCAxis(LinearAxis.init(Title = Title.init("C"), Color = Color.fromKeyword ColorKeyword.DarkCyan))
|> Chart.show

let doughnutChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        TextLabels=labels
    )
    |> Chart.show

Chart.Doughnut(
    values = [10; 15; 15; 30; 22],
    Labels = ["some"; "random"; "slice"; "labels"; "bruh"],
    TextLabels = ["text"; "labels"; "are"; "different"; "thing"],
    TextPosition = StyleParam.TextPosition.Outside,
    Direction = StyleParam.Direction.CounterClockwise,
    Pull = 0.1,
    SectionColors = [
        Color.fromKeyword ColorKeyword.DarkCyan
        Color.fromKeyword ColorKeyword.DarkOrchid
        Color.fromKeyword ColorKeyword.DarkKhaki
        Color.fromKeyword ColorKeyword.DarkGoldenRod
        Color.fromKeyword ColorKeyword.Darkolivegreen
    ],
    Sort = false
)
|> Chart.show

let tableColorDependentChart =
    let header2 = ["Identifier";"T0";"T1";"T2";"T3"]
    let rowvalues = 
        [
         [10001.;0.2;2.0;4.0;5.0]
         [10002.;2.1;2.0;1.8;2.1]
         [10003.;4.5;3.0;2.0;2.5]
         [10004.;0.0;0.1;0.3;0.2]
         [10005.;1.0;1.6;1.8;2.2]
         [10006.;1.0;0.8;1.5;0.7]
         [10007.;2.0;2.0;2.1;1.9]
        ]
        |> Seq.sortBy (fun x -> x.[1])
    
    //map color from value to hex representation
    let mapColor min max value = 
        let proportion = 
            (255. * (value - min) / (max - min))
            |> int
        Color.fromRGB 255 (255 - proportion) proportion
        
    //Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
    let cellcolor = 
         rowvalues
         |> Seq.map (fun row ->
            row 
            |> Seq.mapi (fun index value -> 
                if index = 0 then Color.fromString "white"
                else mapColor 0. 5. value
                )
            )
        |> Seq.transpose
        |> Seq.map Color.fromColors
        |> Color.fromColors

    Chart.Table(header2,rowvalues,ColorCells=cellcolor)

tableColorDependentChart |> Chart.show

Chart.Invisible() 
|> Chart.withLayout(
    Layout.init(
        DragMode = StyleParam.DragMode.DrawRect
    )
)
|> Chart.withConfig(
    Config.init(
        ModeBarButtonsToAdd = [
            StyleParam.ModeBarButton.DrawLine
            StyleParam.ModeBarButton.DrawOpenPath
            StyleParam.ModeBarButton.DrawClosedPath
            StyleParam.ModeBarButton.DrawCircle
            StyleParam.ModeBarButton.DrawRect
            StyleParam.ModeBarButton.EraseShape

        ]
    )
)
|> Chart.show

[

    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
        [
         ["0";"I"     ;"am"     ;"a"]        
         ["1";"little";"example";"!"]       
        ]

    
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
    [
        Chart.Contour(z, Showscale = false)
        [
            Chart.Carpet(
                "contour",
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
                )
            )    
            Chart.ContourCarpet(
                "contour",
                [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
                A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
                B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6],
                ShowScale = false
            )
        ]
        |> Chart.combine
        Chart.Point3d([1,3,2])
    ]
    [
        [
            Chart.Line([1,2; 3,4; 5,6])
            Chart.Spline([1,2; 3,4; 5,7])
        ]
        |> Chart.combine
        Chart.PointPolar([1,2])
        Chart.PointTernary([1,2,3])
    ]
    [
        Chart.PointMapbox([1,2]) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
        Chart.Sunburst(
            ["A";"B";"C";"D";"E"],
            ["";"";"B";"B";""],
            Values=[5.;0.;3.;2.;3.],
            Text=["At";"Bt";"Ct";"Dt";"Et"]
        )
        let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
        let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    

        [
            Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
            Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
        ]
        |> Chart.combine
    
    ]

]
|> Chart.Grid()
|> Chart.withSize(1500,1500)
|> Chart.show

let z0=[|1; 2; 3; 4;4;-3;-1;1;|];
let z1=[|10; 2; 1; 0;4;3;5;6;|];
let seq1 = [1 ..4 ] |> Seq.map(fun _-> z0) |> Seq.toArray
let seq2 = [1 ..4 ] |> Seq.map(fun _-> z1) |> Seq.toArray
let marker = Marker.init(Size= 25,Colorscale=StyleParam.Colorscale.Viridis, ShowScale=false);

let heatmap1=
           Chart.Heatmap(data=seq1)
           |> Chart.withMarker(marker)
           |> Chart.withColorAxisAnchor(1)

let heatmap2=
           Chart.Heatmap(seq2)
           |> Chart.withMarker(marker)
           |> Chart.withColorAxisAnchor(1)

[|heatmap1;heatmap2|]
|> Chart.Grid(1,2)
|> Chart.withColorAxis(ColorAxis.init(AutoColorScale=true))
|> Chart.show

[
    Chart.Point([1,2; 2,3])
    Chart.PointTernary([1,2,3; 2,3,4])
    Chart.Heatmap([[1; 2];[3; 4]], Showscale=false)
    Chart.Point3d([1,3,2])
    Chart.PointMapbox([1,2]) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
    [
        let y =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
        Chart.BoxPlot("y'",y,Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
    ]
    |> Chart.combine
]
|> Chart.Grid(2,3)
|> Chart.withSize(1000,1000)
|> Chart.show