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
#load "Treemap.fs"
#load "Sunburst.fs"
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
#load "FinanceMarker.fs"
#load "SplomDiagonal.fs"
#load "Sankey.fs"

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

open Plotly.NET 

open System
open Plotly.NET 

#r "nuget: FSharp.Data"
#r "nuget: Deedle"

open FSharp.Data
open Deedle

let pieStyled =

    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]

    Chart.Pie(
        values,
        Labels = labels,
        SectionColors = [
            Color.fromKeyword Aqua
            Color.fromKeyword Salmon
            Color.fromKeyword Tan
        ],
        SectionOutlineColor = Color.fromKeyword Black,
        SectionOutlineWidth = 2.,
        MultiText = [
            "Some"
            "More"
            "Stuff"
        ],
        MultiTextPosition = [
            StyleParam.TextPosition.Inside
            StyleParam.TextPosition.Outside
            StyleParam.TextPosition.Inside
        ],
        Rotation = 45.,
        MultiPull = [0.; 0.3; 0.]
    )
    |> Chart.show

let funnelAreaStyled =
    let values = [|5; 4; 3|]
    let labels = [|"The 1st"; "The 2nd"; "The 3rd"|]

    Chart.FunnelArea(
        values,
        Labels = labels,
        MultiText = labels,
        SectionColors = [
            Color.fromKeyword Aqua
            Color.fromKeyword Salmon
            Color.fromKeyword Tan
        ],
        SectionOutlineColor = Color.fromKeyword Black,
        SectionOutlineWidth = 2.,
        AspectRatio = 0.75,
        BaseRatio = 0.1
    )
    |> Chart.show

let sunburstStyled = 
    let labelsParents = [
        ("A",""), 20
        ("B",""), 1
        ("C",""), 2
        ("D",""), 3
        ("E",""), 4

        ("AA","A"), 15
        ("AB","A"), 5

        ("BA","B"), 1

        ("AAA", "AA"), 10
        ("AAB", "AA"), 5
    ]

    Chart.Sunburst(
        labelsParents |> Seq.map fst,
        Values = (labelsParents |> Seq.map snd), 
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Rotation = 45
    )
    |> Chart.show

let treemapStyled = 
    let labelsParents = [
        ("A",""), 20
        ("B",""), 1
        ("C",""), 2
        ("D",""), 3
        ("E",""), 4

        ("AA","A"), 15
        ("AB","A"), 5

        ("BA","B"), 1

        ("AAA", "AA"), 10
        ("AAB", "AA"), 5
    ]

    Chart.Treemap(
        labelsParents |> Seq.map fst,
        Values = (labelsParents |> Seq.map snd), 
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Tiling = TreemapTiling.init(Packing = StyleParam.TreemapTilingPacking.SliceDice)
    )
    |> Chart.show

let icicleStyled = 
    let labelsParents = [
        ("A",""), 20
        ("B",""), 1
        ("C",""), 2
        ("D",""), 3
        ("E",""), 4

        ("AA","A"), 15
        ("AB","A"), 5

        ("BA","B"), 1

        ("AAA", "AA"), 10
        ("AAB", "AA"), 5
    ]

    Chart.Icicle(
        labelsParents |> Seq.map fst,
        Values = (labelsParents |> Seq.map snd), 
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Tiling = IcicleTiling.init(Flip = StyleParam.TilingFlip.XY)
    )
    |> Chart.show

let parcatsStyled =
    let dims =
        [
            Dimension.initParallel(Values = ["A";"A";"A";"B";"B";"B";"C";"D"],Label="Lvl1")
            Dimension.initParallel(Values = ["AA";"AA";"AB";"AB";"AB";"AB";"AB";"AB"],Label="Lvl2")
            Dimension.initParallel(Values = ["AAA";"AAB";"AAC";"AAC";"AAB";"AAB";"AAA";"AAA"],Label="Lvl3")
        ]

    Chart.ParallelCategories(
        dims,
        LineColor = Color.fromColorScaleValues [0; 1; 2; 2; 1; 1; 0; 0], // These values map to the last category axis, meaning [AAA => 0; AAB = 1; AAC => 2]
        LineColorScale = StyleParam.Colorscale.Viridis,
        BundleColors = false
    )
    |> Chart.show

let parcoordsStyled =

    let data =
        "https://raw.githubusercontent.com/bcdunbar/datasets/master/iris.csv"
        |> Http.RequestString
        |> Frame.ReadCsvString

    data.Print()

    let dims = 
        [
            Dimension.initParallel(Label = "sepal_length", Values = (data |> Frame.getCol "sepal_length" |> Series.values), Range = StyleParam.Range.MinMax(0., 8.))
            Dimension.initParallel(Label = "sepal_width" , Values = (data |> Frame.getCol "sepal_width"  |> Series.values), Range = StyleParam.Range.MinMax(0., 8.))
            Dimension.initParallel(Label = "petal_length", Values = (data |> Frame.getCol "petal_length" |> Series.values), Range = StyleParam.Range.MinMax(0., 8.))
            Dimension.initParallel(Label = "petal_width" , Values = (data |> Frame.getCol "petal_width"  |> Series.values), Range = StyleParam.Range.MinMax(0., 8.))
        ]

    let colors = 
        data
        |> Frame.getCol "species_id"
        |> Series.values
        |> Color.fromColorScaleValues

    Chart.ParallelCoord(
        dims,
        LineColorScale = StyleParam.Colorscale.Viridis,
        LineColor = colors
    )
    |> Chart.show


let table1Chart =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
        [
         ["0";"I"     ;"am"     ;"a"]        
         ["1";"little";"example";"!"]       
        ]
    Chart.Table(header, rows, UseDefaults = false)
    |> Chart.show

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
        HeaderAlign = StyleParam.HorizontalAlign.Center,
        CellsMultiAlign  = [StyleParam.HorizontalAlign.Left; StyleParam.HorizontalAlign.Center; StyleParam.HorizontalAlign.Right],
        HeaderFillColor = Color.fromString "#45546a",
        CellsFillColor  = Color.fromColors [Color.fromString "#deebf7"; Color.fromString "lightgrey"; Color.fromString "#deebf7"; Color.fromString "lightgrey"],
        HeaderHeight = 30,
        HeaderOutlineColor  = Color.fromString "black",                     
        HeaderOutlineWidth  = 2.,                     
        MultiColumnWidth = [70.; 50.; 100.; 70.],      
        ColumnOrder = [1; 2; 3; 4],
        UseDefaults = false
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

    Chart.Table(
        header2,
        rowvalues,
        CellsFillColor=cellcolor, 
        UseDefaults = false
    )
    |> Chart.show

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
                | "A" -> Color.fromString "#5050FF" 
                | "T" -> Color.fromString "#E6E600"
                | "G" -> Color.fromString "#00C000"
                | "C" -> Color.fromString "#E00000"
                | "U" -> Color.fromString "#B48100"
                | _   -> Color.fromString "white"
                )
            )
        |> Seq.transpose
        |> Seq.map (fun x -> Seq.append x (seq [Color.fromString "white"]))
        |> Seq.map Color.fromColors
        |> Color.fromColors

    let line = Line.init(Width = 0., Color = Color.fromString "white")
    let chartwidth = 50 + 10 * elementsPerRow

    Chart.Table(
        headers,
        cells,
        CellsOutline   = line,
        HeaderOutline  = line,
        CellsHeight = 20,
        MultiColumnWidth = [50.;10.],
        CellsMultiAlign  = [StyleParam.HorizontalAlign.Right;StyleParam.HorizontalAlign.Center],
        CellsFillColor  = cellcolors, 
        UseDefaults = false
        )
    |> Chart.withSize(Width=chartwidth)
    |> Chart.withTitle "Sequence A"
    |> Chart.show

let styledSankey = 
    Chart.Sankey(
        nodeLabels = ["A1"; "A2"; "B1"; "B2"; "C1"; "C2"; "D1"],
        linkedNodeIds = [
            0,2
            0,3
            1,3
            2,4
            3,4
            3,5
            4,6
            5,6
        ],
        NodeOutlineColor = Color.fromKeyword Black,
        NodeOutlineWidth = 1.,
        linkValues = [8; 4; 2; 7; 3; 2; 5; 2],
        LinkColor = Color.fromColors [
            Color.fromHex "#828BFB"
            Color.fromHex "#828BFB"
            Color.fromHex "#F27762"
            Color.fromHex "#33D6AB"
            Color.fromHex "#BC82FB"
            Color.fromHex "#BC82FB"
            Color.fromHex "#FFB47B"
            Color.fromHex "#47DCF5"
        ],
        LinkOutlineColor = Color.fromKeyword Black,
        LinkOutlineWidth = 1.
    )
    |> Chart.show

