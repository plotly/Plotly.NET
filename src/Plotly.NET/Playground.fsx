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

let tableStyled =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
        [
             ["0";"I"     ;"am"     ;"a"]        // The Table chart constructor uses rowmajor data per default.
             ["1";"little";"example";"!"]        // Keep in mind that this is different from the underlying raw trace constructor 
             ["2";"more";"text";"!"]             // (which uses colum major data just as plotly.js) Set TransposeCells = false to prevent this.
        ]

    Chart.Table(
        header, 
        rows
    )
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