module Tests.SimpleCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open Plotly.NET.StyleParam

let withLineStyleChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    Chart.Line(
        x,y,
        Name="line",
        ShowMarkers=true,
        MarkerSymbol=StyleParam.Symbol.Square)    
    |> Chart.withLineStyle(Width=2.,Dash=StyleParam.DrawingStyle.Dot)

let chartLineChart =
    [ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ]
    |> Chart.Line

let splineChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    Chart.Spline(x, y, Name="spline")   

let textLabelChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let labels  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]
    Chart.Point(
        x,y,
        Name="points",
        Labels=labels,
        TextPosition=StyleParam.TextPosition.TopRight
    )

[<Tests>]
let ``Line and scatter plots`` =
    testList "SimpleCharts.Line and scatter plots" [
        testCase "With LineStyle data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines+markers\",\"line\":{\"width\":2.0,\"dash\":\"dot\"},\"name\":\"line\",\"marker\":{\"symbol\":1}}];"
            |> chartGeneratedContains withLineStyleChart
        );
        testCase "With LineStyle layout" ( fun () ->
            emptyLayout withLineStyleChart
        );
        testCase "Chart line data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,12.0,13.0,14.0,15.0,16.0,17.0,18.0,19.0,20.0,21.0,22.0,23.0,24.0,25.0,26.0,27.0,28.0,29.0,30.0,31.0,32.0,33.0,34.0,35.0,36.0,37.0,38.0,39.0,40.0,41.0,42.0,43.0,44.0,45.0,46.0,47.0,48.0,49.0,50.0,51.0,52.0,53.0,54.0,55.0,56.0,57.0,58.0,59.0,60.0,61.0,62.0,63.0,64.0,65.0,66.0,67.0,68.0,69.0,70.0,71.0,72.0,73.0,74.0,75.0,76.0,77.0,78.0,79.0,80.0,81.0,82.0,83.0,84.0,85.0,86.0,87.0,88.0,89.0,90.0,91.0,92.0,93.0,94.0,95.0,96.0,97.0,98.0,99.0,100.0],\"y\":[1.0,4.0,9.0,16.0,25.0,36.0,49.0,64.0,81.0,100.0,121.0,144.0,169.0,196.0,225.0,256.0,289.0,324.0,361.0,400.0,441.0,484.0,529.0,576.0,625.0,676.0,729.0,784.0,841.0,900.0,961.0,1024.0,1089.0,1156.0,1225.0,1296.0,1369.0,1444.0,1521.0,1600.0,1681.0,1764.0,1849.0,1936.0,2025.0,2116.0,2209.0,2304.0,2401.0,2500.0,2601.0,2704.0,2809.0,2916.0,3025.0,3136.0,3249.0,3364.0,3481.0,3600.0,3721.0,3844.0,3969.0,4096.0,4225.0,4356.0,4489.0,4624.0,4761.0,4900.0,5041.0,5184.0,5329.0,5476.0,5625.0,5776.0,5929.0,6084.0,6241.0,6400.0,6561.0,6724.0,6889.0,7056.0,7225.0,7396.0,7569.0,7744.0,7921.0,8100.0,8281.0,8464.0,8649.0,8836.0,9025.0,9216.0,9409.0,9604.0,9801.0,10000.0],\"mode\":\"lines\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains chartLineChart
        );
        testCase "Chart line layout" ( fun () ->
            emptyLayout chartLineChart
        );
        testCase "Spline chart data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"name\":\"spline\",\"line\":{\"shape\":\"spline\"},\"marker\":{}}];"
            |> chartGeneratedContains splineChart
        );
        testCase "Spline chart layout" ( fun () ->
            emptyLayout splineChart
        );
        testCase "Text label data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers+text\",\"name\":\"points\",\"marker\":{},\"text\":[\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\"],\"textposition\":\"top right\"}];"
            |> chartGeneratedContains textLabelChart
        );
        testCase "Text label layout" ( fun () ->
            emptyLayout textLabelChart
        );
    ]


let columnChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    Chart.Column(keys, values)

let barChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    Chart.Bar(keys, values)

let stackedBarChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    [
        Chart.StackedBar(keys,values,Name="old");
        Chart.StackedBar(keys,[8; 21; 13;],Name="new")
    ]
    |> Chart.combine

let stackedColumnChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    [
        Chart.StackedColumn(keys,values,Name="old");
        Chart.StackedColumn(keys,[8; 21; 13;],Name="new")
    ]
    |> Chart.combine

[<Tests>]
let ``Bar and column charts`` =
    testList "SimpleCharts.Bar and column charts" [
        testCase "Column chart data" ( fun () ->
            "var data = [{\"type\":\"bar\",\"x\":[\"Product A\",\"Product B\",\"Product C\"],\"y\":[20,14,23],\"marker\":{}}];"
            |> chartGeneratedContains columnChart
        );
        testCase "Column chart layout" ( fun () ->
            emptyLayout columnChart
        );
        testCase "Bar chart data" ( fun () ->
            "var data = [{\"type\":\"bar\",\"x\":[20,14,23],\"y\":[\"Product A\",\"Product B\",\"Product C\"],\"orientation\":\"h\",\"marker\":{}}];"
            |> chartGeneratedContains barChart
        );
        testCase "Bar chart layout" ( fun () ->
            emptyLayout barChart
        );
        testCase "Stacked bar data" ( fun () ->
            "var data = [{\"type\":\"bar\",\"x\":[20,14,23],\"y\":[\"Product A\",\"Product B\",\"Product C\"],\"orientation\":\"h\",\"marker\":{},\"name\":\"old\"},{\"type\":\"bar\",\"x\":[8,21,13],\"y\":[\"Product A\",\"Product B\",\"Product C\"],\"orientation\":\"h\",\"marker\":{},\"name\":\"new\"}];"
            |> chartGeneratedContains stackedBarChart
        );
        testCase "Stacked bar layout" ( fun () ->
            "var layout = {\"barmode\":\"stack\"};"
            |> chartGeneratedContains stackedColumnChart
        );
        testCase "Stacked column data" ( fun () ->
            "var data = [{\"type\":\"bar\",\"x\":[\"Product A\",\"Product B\",\"Product C\"],\"y\":[20,14,23],\"marker\":{},\"name\":\"old\"},{\"type\":\"bar\",\"x\":[\"Product A\",\"Product B\",\"Product C\"],\"y\":[8,21,13],\"marker\":{},\"name\":\"new\"}];"
            |> chartGeneratedContains stackedColumnChart
        );
        testCase "Stacked column layout" ( fun () ->
            "var layout = {\"barmode\":\"stack\"};"
            |> chartGeneratedContains stackedColumnChart
        );
    ]


let simpleAreaChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
    Chart.Area(x,y)

let withSplineChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
    Chart.SplineArea(x,y)

let stackedAreaChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
    [
        Chart.StackedArea(x,y)
        Chart.StackedArea(x,y |> Seq.rev)
    ]
    |> Chart.combine

[<Tests>]
let ``Area charts`` =
    testList "SimpleCharts.Area charts" [
        testCase "Simple area data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],\"mode\":\"lines\",\"fill\":\"tozeroy\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains simpleAreaChart
        );
        testCase "Simple area layout" ( fun () ->
            emptyLayout simpleAreaChart
        );
        testCase "Spline data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],\"mode\":\"lines\",\"fill\":\"tozeroy\",\"line\":{\"shape\":\"spline\"},\"marker\":{}}];"
            |> chartGeneratedContains withSplineChart
        );
        testCase "Spline layout" ( fun () ->
            emptyLayout withSplineChart
        );
        testCase "Stacked area data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],\"mode\":\"lines\",\"line\":{},\"marker\":{},\"stackgroup\":\"static\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[5.0,5.5,4.5,7.5,2.5,5.0,7.5,5.0,2.5,5.0],\"mode\":\"lines\",\"line\":{},\"marker\":{},\"stackgroup\":\"static\"}];"
            |> chartGeneratedContains stackedAreaChart
        );
        testCase "Stacked area layout" ( fun () ->
            emptyLayout stackedAreaChart
        );
    ]


let rangePlotsChart =
    let rnd = System.Random(5)
    
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    
    let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
    let yLower = y |> List.map (fun v -> v - rnd.NextDouble())
    Chart.Range(
        x,y,yUpper,yLower,
        StyleParam.Mode.Lines_Markers,
        Color="grey",
        RangeColor="lightblue")


[<Tests>]
let ``Range plot`` =
    testList "SimpleCharts.Range plot" [
        testCase "Range plot data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[1.0244410755226578,1.1291130737537114,4.930085632917511,1.4292117752736488,2.5179894182449156,2.3470285278032668,1.5358344954605374,1.4046562835130172,2.6874669190437843,0.7493837949584163],\"mode\":\"lines\",\"fillcolor\":\"lightblue\",\"name\":\"lower\",\"showlegend\":false,\"line\":{\"width\":0.0},\"marker\":{\"color\":\"lightblue\"}},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.338369840913624,1.7844184475412679,5.2629626417825754,2.125375844363764,3.4634618528482792,3.4283738280312965,2.6463105539541276,2.4505998873853123,4.096133255211699,1.1174599459010455],\"mode\":\"lines\",\"fill\":\"tonexty\",\"fillcolor\":\"lightblue\",\"name\":\"upper\",\"showlegend\":false,\"line\":{\"width\":0.0},\"marker\":{\"color\":\"lightblue\"}},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines+markers\",\"fillcolor\":\"grey\",\"line\":{\"color\":\"grey\"},\"marker\":{\"color\":\"grey\"}}];"
            |> chartGeneratedContains rangePlotsChart
        );
        testCase "Range plot layout" ( fun () ->
            emptyLayout rangePlotsChart
        );
    ]

let bubbleCharts =
    let x = [2; 4; 6;]
    let y = [4; 1; 6;]
    let size = [19; 26; 55;]
    Chart.Bubble(x, y, size)

[<Tests>]
let ``Bubble charts`` =
    testList "SimpleCharts.Bubble charts" [
        testCase "Bubble data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[2,4,6],\"y\":[4,1,6],\"mode\":\"markers\",\"marker\":{\"size\":[19,26,55]}}];"
            |> chartGeneratedContains bubbleCharts
        );
        testCase "Bubble layout" ( fun () ->
            emptyLayout bubbleCharts
        );
    ]

let pieChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Pie(values, labels)

let doughnutChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        Textinfo=labels
    )

let sunburstChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Sunburst(
        ["A";"B";"C";"D";"E"],
        ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        Text=["At";"Bt";"Ct";"Dt";"Et"]
    )

[<Tests>]
let ``Pie and doughnut Charts`` =
    testList "SimpleCharts.Pie and doughnut Charts" [
        testCase "Pie data" ( fun () ->
            "var data = [{\"type\":\"pie\",\"values\":[19,26,55],\"labels\":[\"Residential\",\"Non-Residential\",\"Utility\"],\"marker\":{},\"text\":[\"Residential\",\"Non-Residential\",\"Utility\"]}];"
            |> chartGeneratedContains pieChart
        );
        testCase "Pie layout" ( fun () ->
            emptyLayout pieChart
        );
        testCase "Doughnut data" ( fun () ->
            "var data = [{\"type\":\"pie\",\"values\":[19,26,55],\"labels\":[\"Residential\",\"Non-Residential\",\"Utility\"],\"textinfo\":[\"Residential\",\"Non-Residential\",\"Utility\"],\"hole\":0.3,\"marker\":{},\"text\":[\"Residential\",\"Non-Residential\",\"Utility\"]}];"
            |> chartGeneratedContains doughnutChart
        );
        testCase "Doughnut layout" ( fun () ->
            emptyLayout doughnutChart
        );
        testCase "Sunburst data" ( fun () ->
            "var data = [{\"type\":\"sunburst\",\"labels\":[\"A\",\"B\",\"C\",\"D\",\"E\"],\"parents\":[\"\",\"\",\"B\",\"B\",\"\"],\"values\":[5.0,0.0,3.0,2.0,3.0],\"text\":[\"At\",\"Bt\",\"Ct\",\"Dt\",\"Et\"],\"marker\":{}}];"
            |> chartGeneratedContains sunburstChart
        );
        testCase "Sunburst layout" ( fun () ->
            emptyLayout sunburstChart
        );
    ]


let table1Chart =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
        [
         ["0";"I"     ;"am"     ;"a"]        
         ["1";"little";"example";"!"]       
        ]
    Chart.Table(header, rows)

let tableStyledChart =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
          [
           ["0";"I"     ;"am"     ;"a"]        
           ["1";"little";"example";"!"]       
          ]
    Chart.Table(
        header,
        rows,
        AlignHeader = [HorizontalAlign.Center],
        AlignCells  = [HorizontalAlign.Left; HorizontalAlign.Center; HorizontalAlign.Right],
        ColorHeader = "#45546a",    
        ColorCells  = ["#deebf7"; "lightgrey"; "#deebf7"; "lightgrey"],
        FontHeader  = Font.init(FontFamily.Courier_New, Size=12., Color="white"),      
        HeightHeader= 30.,
        LineHeader  = Line.init(2., "black"),                     
        ColumnWidth = [70; 50; 100; 70],      
        ColumnOrder = [1; 2; 3; 4]                                  
    )

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
        Colors.fromRgb 255 (255 - proportion) proportion
        |> Colors.toWebColor
        
    //Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
    let cellcolor = 
         rowvalues
         |> Seq.map (fun row ->
            row 
            |> Seq.mapi (fun index value -> 
                if index = 0 then "white"
                else mapColor 0. 5. value
                )
            )
        |> Seq.transpose

    Chart.Table(header2,rowvalues,ColorCells=cellcolor)

let sequencePresentationTableChart =
    let sequence =
        [
        "ATGAGACGTCGAGACTGATAGACGTCGATAGACGTCGATAGACCG"
        "ATAGACTCGTGATAGACGTCGATAGACGTCGATAGAGTATAGACC"
        "GTGATAGACGTCGAGAAGACGTCGATAGACGTCGATAGACGTCGA"
        "TAGAGATAGACGTCGATAGACCGTATAGAAGACGTCGATAGATAG"
        "ACGTCGATAGACCGTAGACGTCGATAGACGTCGATAGACCGT"
        ]
        |> String.concat ""

    let elementsPerRow = 60

    let headers = 
        [0..elementsPerRow] 
        |> Seq.map (fun x -> 
            if x%10=0 && x <> 0 then "|" 
            else ""
            )

    let cells = 
        sequence
        |> Seq.chunkBySize elementsPerRow
        |> Seq.mapi (fun i x -> Seq.append [string (i * elementsPerRow)] (Seq.map string x))

    let cellcolors =
        cells
        |> Seq.map (fun row -> 
            row 
            |> Seq.map (fun element -> 
                match element with
                //colors taken from DRuMS 
                //(http://biomodel.uah.es/en/model4/dna/atgc.htm)
                | "A" -> "#5050FF" 
                | "T" -> "#E6E600"
                | "G" -> "#00C000"
                | "C" -> "#E00000"
                | "U" -> "#B48100"
                | _   -> "white"
                )
            )
        |> Seq.transpose
        |> Seq.map (fun x -> Seq.append x (seq ["white"]))

    let font = Font.init(FontFamily.Consolas,Size=14.)
    let line = Line.init(0.,"white")
    let chartwidth = 50. + 10. * float elementsPerRow

    Chart.Table(
        headers,
        cells,
        LineCells   = line,
        LineHeader  = line,
        HeightCells = 20.,
        FontHeader  = font,
        FontCells   = font,
        ColumnWidth = [50;10],
        AlignCells  = [HorizontalAlign.Right;HorizontalAlign.Center],
        ColorCells  = cellcolors
        )
    |> Chart.withSize(chartwidth,nan)
    |> Chart.withTitle "Sequence A"


[<Tests>]
let ``Table charts`` =
    testList "SimpleCharts.Table charts" [
        testCase "First table data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"<b>RowIndex</b>\",\"A\",\"simple\",\"table\"]},\"cells\":{\"values\":[[\"0\",\"1\"],[\"I\",\"little\"],[\"am\",\"example\"],[\"a\",\"!\"]]}}];"
            |> chartGeneratedContains table1Chart
        );
        testCase "First table layout" ( fun () ->
            emptyLayout table1Chart
        );
        testCase "Styled table data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"<b>RowIndex</b>\",\"A\",\"simple\",\"table\"],\"align\":[\"center\"],\"height\":30.0,\"fill\":{\"color\":\"#45546a\"},\"line\":{\"color\":\"black\",\"width\":2.0},\"font\":{\"family\":\"Courier New\",\"size\":12.0,\"color\":\"white\"}},\"cells\":{\"values\":[[\"0\",\"1\"],[\"I\",\"little\"],[\"am\",\"example\"],[\"a\",\"!\"]],\"align\":[\"left\",\"center\",\"right\"],\"fill\":{\"color\":[\"#deebf7\",\"lightgrey\",\"#deebf7\",\"lightgrey\"]}},\"columnwidth\":[70,50,100,70],\"columnorder\":[1,2,3,4]}];"
            |> chartGeneratedContains tableStyledChart
        );
        testCase "Styled table layout" ( fun () ->
            emptyLayout tableStyledChart
        );
        testCase "Color dependent chart data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"Identifier\",\"T0\",\"T1\",\"T2\",\"T3\"]},\"cells\":{\"values\":[[10004.0,10001.0,10005.0,10006.0,10007.0,10002.0,10003.0],[0.0,0.2,1.0,1.0,2.0,2.1,4.5],[0.1,2.0,1.6,0.8,2.0,2.0,3.0],[0.3,4.0,1.8,1.5,2.1,1.8,2.0],[0.2,5.0,2.2,0.7,1.9,2.1,2.5]],\"fill\":{\"color\":[[\"white\",\"white\",\"white\",\"white\",\"white\",\"white\",\"white\"],[\"#FFFF00\",\"#FFF50A\",\"#FFCC33\",\"#FFCC33\",\"#FF9966\",\"#FF946B\",\"#FF1AE5\"],[\"#FFFA05\",\"#FF9966\",\"#FFAE51\",\"#FFD728\",\"#FF9966\",\"#FF9966\",\"#FF6699\"],[\"#FFF00F\",\"#FF33CC\",\"#FFA45B\",\"#FFB34C\",\"#FF946B\",\"#FFA45B\",\"#FF9966\"],[\"#FFF50A\",\"#FF00FF\",\"#FF8F70\",\"#FFDC23\",\"#FF9F60\",\"#FF946B\",\"#FF807F\"]]}}}];"
            |> chartGeneratedContains tableColorDependentChart
        );
        testCase "Color dependent chart layout" ( fun () ->
            emptyLayout tableColorDependentChart
        );
        testCase "Sequence presentation table data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\"],\"line\":{\"color\":\"white\",\"width\":0.0},\"font\":{\"family\":\"Consolas\",\"size\":14.0}},\"cells\":{\"values\":[[\"0\",\"60\",\"120\",\"180\"],[\"A\",\"A\",\"G\",\"A\"],[\"T\",\"C\",\"T\",\"C\"],[\"G\",\"G\",\"C\",\"G\"],[\"A\",\"T\",\"G\",\"T\"],[\"G\",\"C\",\"A\",\"C\"],[\"A\",\"G\",\"T\",\"G\"],[\"C\",\"A\",\"A\",\"A\"],[\"G\",\"T\",\"G\",\"T\"],[\"T\",\"A\",\"A\",\"A\"],[\"C\",\"G\",\"C\",\"G\"],[\"G\",\"A\",\"G\",\"A\"],[\"A\",\"C\",\"T\",\"C\"],[\"G\",\"G\",\"C\",\"C\"],[\"A\",\"T\",\"G\",\"G\"],[\"C\",\"C\",\"A\",\"T\"],[\"T\",\"G\",\"T\",\"A\"],[\"G\",\"A\",\"A\",\"G\"],[\"A\",\"T\",\"G\",\"A\"],[\"T\",\"A\",\"A\",\"C\"],[\"A\",\"G\",\"G\",\"G\"],[\"G\",\"A\",\"A\",\"T\"],[\"A\",\"G\",\"T\",\"C\"],[\"C\",\"T\",\"A\",\"G\"],[\"G\",\"A\",\"G\",\"A\"],[\"T\",\"T\",\"A\",\"T\"],[\"C\",\"A\",\"C\",\"A\"],[\"G\",\"G\",\"G\",\"G\"],[\"A\",\"A\",\"T\",\"A\"],[\"T\",\"C\",\"C\",\"C\"],[\"A\",\"C\",\"G\",\"G\"],[\"G\",\"G\",\"A\",\"T\"],[\"A\",\"T\",\"T\",\"C\"],[\"C\",\"G\",\"A\",\"G\"],[\"G\",\"A\",\"G\",\"A\"],[\"T\",\"T\",\"A\",\"T\"],[\"C\",\"A\",\"C\",\"A\"],[\"G\",\"G\",\"C\",\"G\"],[\"A\",\"A\",\"G\",\"A\"],[\"T\",\"C\",\"T\",\"C\"],[\"A\",\"G\",\"A\",\"C\"],[\"G\",\"T\",\"T\",\"G\"],[\"A\",\"C\",\"A\",\"T\"],[\"C\",\"G\",\"G\"],[\"C\",\"A\",\"A\"],[\"G\",\"G\",\"A\"],[\"A\",\"A\",\"G\"],[\"T\",\"A\",\"A\"],[\"A\",\"G\",\"C\"],[\"G\",\"A\",\"G\"],[\"A\",\"C\",\"T\"],[\"C\",\"G\",\"C\"],[\"T\",\"T\",\"G\"],[\"C\",\"C\",\"A\"],[\"G\",\"G\",\"T\"],[\"T\",\"A\",\"A\"],[\"G\",\"T\",\"G\"],[\"A\",\"A\",\"A\"],[\"T\",\"G\",\"T\"],[\"A\",\"A\",\"A\"],[\"G\",\"C\",\"G\"]],\"align\":[\"right\",\"center\"],\"height\":20.0,\"fill\":{\"color\":[[\"white\",\"white\",\"white\",\"white\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E00000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#00C000\",\"#00C000\",\"#E00000\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#00C000\",\"#E6E600\",\"white\"],[\"#00C000\",\"#E00000\",\"#5050FF\",\"#E00000\",\"white\"],[\"#5050FF\",\"#00C000\",\"#E6E600\",\"#00C000\",\"white\"],[\"#E00000\",\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#E6E600\",\"#00C000\",\"#E6E600\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#E00000\",\"#00C000\",\"#E00000\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#5050FF\",\"#E00000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#00C000\",\"#00C000\",\"#E00000\",\"#E00000\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#00C000\",\"#00C000\",\"white\"],[\"#E00000\",\"#E00000\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E6E600\",\"#00C000\",\"#E6E600\",\"#5050FF\",\"white\"],[\"#00C000\",\"#5050FF\",\"#5050FF\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"#E00000\",\"white\"],[\"#5050FF\",\"#00C000\",\"#00C000\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#5050FF\",\"#00C000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#E00000\",\"#E6E600\",\"#5050FF\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E6E600\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E00000\",\"#5050FF\",\"#E00000\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#00C000\",\"#00C000\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#E6E600\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E00000\",\"#E00000\",\"#E00000\",\"white\"],[\"#5050FF\",\"#E00000\",\"#00C000\",\"#00C000\",\"white\"],[\"#00C000\",\"#00C000\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#E6E600\",\"#E00000\",\"white\"],[\"#E00000\",\"#00C000\",\"#5050FF\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E6E600\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E00000\",\"#5050FF\",\"#E00000\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#E00000\",\"#00C000\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E00000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#5050FF\",\"#00C000\",\"#5050FF\",\"#E00000\",\"white\"],[\"#00C000\",\"#E6E600\",\"#E6E600\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E00000\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E00000\",\"#00C000\",\"#00C000\",\"white\"],[\"#E00000\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#5050FF\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#00C000\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#5050FF\",\"#00C000\",\"#E00000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E00000\",\"#E6E600\",\"white\"],[\"#E00000\",\"#00C000\",\"#E00000\",\"white\"],[\"#E6E600\",\"#E6E600\",\"#00C000\",\"white\"],[\"#E00000\",\"#E00000\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#E6E600\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#E6E600\",\"#00C000\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#00C000\",\"#E6E600\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#E00000\",\"#00C000\",\"white\"]]},\"line\":{\"color\":\"white\",\"width\":0.0},\"font\":{\"family\":\"Consolas\",\"size\":14.0}},\"columnwidth\":[50,10]}];"
            |> chartGeneratedContains sequencePresentationTableChart
        );
        testCase "Sequence presentation table  layout" ( fun () ->
            "var layout = {\"width\":650.0,\"height\":\"NaN\",\"title\":{\"text\":\"Sequence A\"}};"
            |> chartGeneratedContains sequencePresentationTableChart
        );
    ]


let heatmap1Chart =
    let matrix =
        [[1.;1.5;0.7;2.7];
        [2.;0.5;1.2;1.4];
        [0.1;2.6;2.4;3.0];]
    
    let rownames = ["p3";"p2";"p1"]
    let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
    
    let colorscaleValue = 
        StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    
    Chart.Heatmap(
        matrix,colnames,rownames,
        Colorscale=colorscaleValue,
        Showscale=true
    )
    |> Chart.withSize(700.,500.)
    |> Chart.withMarginSize(Left=200.)

let heatmapStyledChart =
    let matrix =
        [[1.;1.5;0.7;2.7];
        [2.;0.5;1.2;1.4];
        [0.1;2.6;2.4;3.0];]
    
    let rownames = ["p3";"p2";"p1"]
    let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
    
    let colorscaleValue = 
        StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    
    Chart.Heatmap(
        matrix,colnames,rownames,
        Colorscale=colorscaleValue,
        Showscale=true
    )
    |> Chart.withSize(700.,500.)
    |> Chart.withMarginSize(Left=200.)
    |> Chart.withColorBarStyle(
        "Im the Colorbar",
        TitleSide = StyleParam.Side.Right,
        TitleFont = Font.init(Size=20.)
    )


[<Tests>]
let ``Heatmap charts`` =
    testList "SimpleCharts.Heatmap charts" [
        testCase "Heatmap data" ( fun () ->
            "var data = [{\"type\":\"heatmap\",\"z\":[[1.0,1.5,0.7,2.7],[2.0,0.5,1.2,1.4],[0.1,2.6,2.4,3.0]],\"x\":[\"Tp0\",\"Tp30\",\"Tp60\",\"Tp160\"],\"y\":[\"p3\",\"p2\",\"p1\"],\"colorscale\":[[0.0,\"#3D9970\"],[1.0,\"#001f3f\"]],\"showscale\":true}];"
            |> chartGeneratedContains heatmap1Chart
        );
        testCase "Heatmap layout" ( fun () ->
            "var layout = {\"width\":700.0,\"height\":500.0,\"margin\":{\"l\":200.0}};"
            |> chartGeneratedContains heatmap1Chart
        );
        testCase "Heatmap styled data" ( fun () ->
            "var data = [{\"type\":\"heatmap\",\"z\":[[1.0,1.5,0.7,2.7],[2.0,0.5,1.2,1.4],[0.1,2.6,2.4,3.0]],\"x\":[\"Tp0\",\"Tp30\",\"Tp60\",\"Tp160\"],\"y\":[\"p3\",\"p2\",\"p1\"],\"colorscale\":[[0.0,\"#3D9970\"],[1.0,\"#001f3f\"]],\"showscale\":true,\"colorbar\":{\"title\":\"Im the Colorbar\",\"titlefont\":{\"size\":20.0},\"titleside\":\"right\"}}];"
            |> chartGeneratedContains heatmapStyledChart
        );
        testCase "Heatmap styled layout" ( fun () ->
            "var layout = {\"width\":700.0,\"height\":500.0,\"margin\":{\"l\":200.0}};"
            |> chartGeneratedContains heatmapStyledChart
        );
    ]