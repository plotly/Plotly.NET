#load "StyleParams.fs"
#load "DynamicObj.fs"
#load "Colors.fs"
#load "StockData.fs"
#load "Font.fs"
#load "Pathbar.fs"
#load "TreemapTiling.fs"
#load "Colorbar.fs"
#load "RangeSlider.fs"
#load "Light.fs"
#load "Contours.fs"
#load "Dimensions.fs"
#load "Domain.fs"
#load "Line.fs"
#load "Box.fs"
#load "Meanline.fs"
#load "Marker.fs"
#load "Hoverlabel.fs"
#load "Axis.fs"
#load "Bins.fs"
#load "Cumulative.fs"
#load "Scene.fs"
#load "Selected.fs"
#load "Shape.fs"
#load "Error.fs"
#load "Table.fs"
#load "Trace.fs"
#load "Trace3d.fs"
#load "LayoutGrid.fs"
#load "Layout.fs"
#load "Config.fs"
#r @"..\..\packages\Newtonsoft.Json\lib\netstandard2.0\Newtonsoft.Json.dll"
#load "GenericChart.fs"
#load "Chart.fs"
#load "ChartExtensions.fs"
#load "CandelstickExtension.fs"
#load "SankeyExtension.fs"
#load "Templates.fs"

open FSharp.Plotly
open GenericChart

let manyPoints = 
    let rnd = new System.Random()
    [for i = 0 to 50000 do (rnd.NextDouble(),rnd.NextDouble()) ]
  
let manyBubbles =  
    let rnd = new System.Random()
    [for i = 0 to 50000 do (rnd.NextDouble(),rnd.NextDouble(),rnd.NextDouble()) ]
//we can see here that the advantage of webgl fades with many small scattergl traces.
let manyLines = 
    let rnd = new System.Random()
    [for i = 0 to 5000 do 
        [for i in [0 .. 10 .. 100] do (rnd.NextDouble(),rnd.NextDouble())]
    ]
  
  
//Test Stackgroups

[
    Chart.Scatter(x = [1;2;3], y = [2;3;4],mode=StyleParam.Mode.Markers, StackGroup = "meem", Orientation= StyleParam.Orientation.Vertical, GroupNorm = StyleParam.GroupNorm.Percent )
    Chart.Scatter(x = [1;2;3], y = [4;3;4],mode=StyleParam.Mode.Markers, StackGroup = "meem", Orientation= StyleParam.Orientation.Vertical, GroupNorm = StyleParam.GroupNorm.Percent )
]
|> Chart.Combine
|> Chart.Show

//Just try this, its amazing how much faster WebGL loads and zooms
Chart.Point(manyPoints,UseWebGL=true)
|> Chart.Show

Chart.Point(manyPoints)
|> Chart.Show

manyLines
|> List.map (fun l -> Chart.Line(l,UseWebGL=true))
|> Chart.Combine
|> Chart.Show

Chart.Line(manyPoints,UseWebGL=true)
|> Chart.Show

Chart.Line(manyPoints,UseWebGL=false)
|> Chart.Show

Chart.Spline(manyPoints,UseWebGL=true)
|> Chart.Show

Chart.Spline(manyPoints,UseWebGL=false)
|> Chart.Show

Chart.Bubble(manyBubbles,UseWebGL=true)
|> Chart.Show

Chart.Bubble(manyBubbles,UseWebGL=false)
|> Chart.Show

let stockData =
    [|("2020-01-17T13:40:00", 0.68888, 0.68888, 0.68879, 0.6888);
      ("2020-01-17T13:41:00", 0.68883, 0.68884, 0.68875, 0.68877);
      ("2020-01-17T13:42:00", 0.68878, 0.68889, 0.68878, 0.68886);
      ("2020-01-17T13:43:00", 0.68886, 0.68886, 0.68876, 0.68879);
      ("2020-01-17T13:44:00", 0.68879, 0.68879, 0.68873, 0.68874);
      ("2020-01-17T13:45:00", 0.68875, 0.68877, 0.68867, 0.68868);
      ("2020-01-17T13:46:00", 0.68869, 0.68887, 0.68869, 0.68883);
      ("2020-01-17T13:47:00", 0.68883, 0.68899, 0.68883, 0.68899);
      ("2020-01-17T13:48:00", 0.68898, 0.689, 0.68885, 0.68889);
      ("2020-01-17T13:49:00", 0.68889, 0.68893, 0.68881, 0.68893);
      ("2020-01-17T13:50:00", 0.68891, 0.68896, 0.68886, 0.68891);
    |]
    |> Array.map (fun (d,o,h,l,c)->System.DateTime.Parse d, StockData.Create(o,h,l,c))

Chart.Candlestick stockData
|> Chart.Show

Chart.OHLC stockData
|> Chart.Show

Chart.Treemap(
    ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"],
    [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ],
    Values = [10.; 14.; 12.; 10.; 2.; 6.; 6.; 4.; 4.]
)
|> Chart.withTitle "Treemap test"
|> Chart.Show


//Sunbursst example from plotly docs: https://plotly.com/javascript/sunburst-charts
Chart.Sunburst(
    ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"],
    [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ],
    Values = [10.; 14.; 12.; 10.; 2.; 6.; 6.; 4.; 4.]
)
|> Chart.withTitle "Sunburst test"
|> Chart.Show




let grid ((gCharts:seq<#seq<GenericChart>>),sharedAxes:bool,xGap,yGap) =

    let nRows = Seq.length gCharts
    let nCols = gCharts |> Seq.maxBy Seq.length |> Seq.length
    let pattern = if sharedAxes then StyleParam.LayoutGridPattern.Coupled else StyleParam.LayoutGridPattern.Independent

    let grid = 
        LayoutGrid.init(
            Rows=nRows,Columns=nCols,XGap= xGap,YGap= yGap,Pattern=pattern
        )

    let generateDomainRanges (count:int) (gap:float) =
        [|0. .. (1. / (float count)) .. 1.|]
        |> fun doms -> 
            doms
            |> Array.windowed 2
            |> Array.mapi (fun i x -> 
                if i = 0 then
                    x.[0], (x.[1] - (gap / 2.))
                elif i = (doms.Length - 1) then
                   (x.[0] + (gap / 2.)),x.[1]
                else
                   (x.[0] + (gap / 2.)) , (x.[1] - (gap / 2.))
            )

    let yDomains = generateDomainRanges nRows yGap
    let xDomains = generateDomainRanges nCols xGap

    gCharts
    |> Seq.mapi (fun rowIndex row ->
        row |> Seq.mapi (fun colIndex gChart ->
            let xdomain = xDomains.[colIndex]
            let ydomain = yDomains.[rowIndex]

            let newXIndex, newYIndex =
                (if sharedAxes then colIndex + 1 else ((nRows * rowIndex) + (colIndex + 1))),
                (if sharedAxes then rowIndex + 1 else ((nRows * rowIndex) + (colIndex + 1)))


            let xaxis,yaxis,layout = 
                let layout = GenericChart.getLayout gChart
                let xAxisName, yAxisName = StyleParam.AxisId.X 1 |> StyleParam.AxisId.toString, StyleParam.AxisId.Y 1 |> StyleParam.AxisId.toString
                
                let updateXAxis index domain axis = 
                    axis |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax domain)
                
                let updateYAxis index domain axis = 
                    axis |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax domain)
                match (layout.TryGetTypedValue<Axis.LinearAxis> xAxisName),(layout.TryGetTypedValue<Axis.LinearAxis> yAxisName) with
                | Some x, Some y ->
                    // remove axis
                    DynObj.remove layout xAxisName
                    DynObj.remove layout yAxisName

                    x |> updateXAxis newXIndex xdomain,
                    y |> updateYAxis newYIndex ydomain,
                    layout

                | Some x, None -> 
                    // remove x - axis
                    DynObj.remove layout xAxisName

                    x |> updateXAxis newXIndex xdomain,
                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y newYIndex ,Domain=StyleParam.Range.MinMax ydomain),
                    layout

                | None, Some y -> 
                    // remove y - axis
                    DynObj.remove layout yAxisName

                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X newXIndex,Domain=StyleParam.Range.MinMax xdomain),
                    y |> updateYAxis newYIndex ydomain,
                    layout
                | None, None ->
                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X newXIndex,Domain=StyleParam.Range.MinMax xdomain),
                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y newYIndex,Domain=StyleParam.Range.MinMax ydomain),
                    layout

            gChart
            |> GenericChart.setLayout layout
            |> Chart.withAxisAnchor(X=newXIndex,Y=newYIndex) 
            |> Chart.withX_Axis(xaxis,newXIndex)
            |> Chart.withY_Axis(yaxis,newYIndex)
        )
    )
    |> Seq.map Chart.Combine
    |> Chart.Combine
    |> Chart.withLayoutGrid grid

grid ([
    [Chart.Point([(0,1)]);Chart.Point([(0,1)]);Chart.Point([(0,1)]);]
    [Chart.Point([(0,1)]);Chart.Point([(0,1)]);Chart.Point([(0,1)]);]
    [Chart.Point([(0,1)]);Chart.Point([(0,1)]);Chart.Point([(0,1)]);]
],true, 0.05,0.05)
|> Chart.Show

let stack ( columns:int, space) = 
    (fun (charts:#seq<GenericChart>) ->  

        let col = columns
        let len      = charts |> Seq.length
        let colWidth = 1. / float col
        let rowWidth = 
            let tmp = float len / float col |> ceil
            1. / tmp
        let space = 
            let s = defaultArg space 0.05
            if s < 0. || s > 1. then 
                printfn "Space should be between 0.0 - 1.0. Automaticaly set to default (0.05)"
                0.05
            else
                s

        let contains3d ch =
            ch 
            |> existsTrace (fun t -> 
                match t with
                | :? Trace3d -> true
                | _ -> false)

        charts
        |> Seq.mapi (fun i ch ->
            let colI,rowI,index = (i%col+1), (i/col+1),(i+1)
            let xdomain = (colWidth * float (colI-1), (colWidth * float colI) - space ) 
            let ydomain = (1. - ((rowWidth * float rowI) - space ),1. - (rowWidth * float (rowI-1)))
            xdomain)
        )

let a = 
    stack (2, None) [Chart.Point([0,1]);Chart.Point([0,1])]
    |> Array.ofSeq

let generateDomainRanges nRows nCols =
    
    if nCols > 0 && nRows > 0 then

        [0. .. (1. / (float nRows)) .. 1.]
        |> List.windowed 2
        |> List.map (fun x -> x.[0], x.[1])
        ,
        [0. .. (1. / (float nCols)) .. 1.]
        |> List.windowed 2
        |> List.map (fun x -> x.[0], x.[1])

    else failwith "negative amount of rows or columns is stupid."

generateDomainRanges 8 1




[
    Chart.Point([(0,1)]) |> Chart.withY_AxisStyle("This title")
    Chart.Point([(0,1)]) 
    |> Chart.withY_AxisStyle("Must be set",Zeroline=false)
    Chart.Point([(0,1)]) 
    |> Chart.withY_AxisStyle("on the respective charts",Zeroline=false)
]
|> Chart.SingleStack
|> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom)
|> Chart.withTitle("Hi i am the new SingleStackChart")
|> Chart.withX_AxisStyle("im the shared xAxis")
|> Chart.Show

[
    [1;2]
    [3;4]
]
|> Chart.Heatmap
|> Chart.withColorBarStyle(
    "Hallo?",
    TitleSide=StyleParam.Side.Right,
    TitleFont=Font.init(Size=20)
)
|> Chart.Show
