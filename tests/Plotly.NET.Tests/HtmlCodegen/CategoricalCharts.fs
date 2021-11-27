module Tests.CategoricalCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

let parcats =
    let dims =
        [
            Dimension.initParallel(Values = ["Cat1";"Cat1";"Cat1";"Cat1";"Cat2";"Cat2";"Cat3"],Label="A")
            Dimension.initParallel(Values = [0;1;0;1;0;0;0],Label="B",TickText=["YES";"NO"])
        ]
    
    Chart.ParallelCategories(
        dims,
        LineColor=Color.fromColorScaleValues [0.;1.;0.;1.;0.;0.;0.],
        LineColorScale = StyleParam.Colorscale.Blackbody, 
        UseDefaults = false
    )


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
        BundleColors = false,
        UseDefaults = false
    )

[<Tests>]
let ``Parallel categories charts`` =
    testList "CategoricalCharts.Parallel categories charts" [
        testCase "Parallel categories data" ( fun () ->
            """var data = [{"type":"parcats","dimensions":[{"label":"A","values":["Cat1","Cat1","Cat1","Cat1","Cat2","Cat2","Cat3"],"axis":{}},{"label":"B","values":[0,1,0,1,0,0,0],"ticktext":["YES","NO"],"axis":{}}],"line":{"color":[0.0,1.0,0.0,1.0,0.0,0.0,0.0],"colorscale":"Blackbody"}}];"""
            |> chartGeneratedContains parcats
        );
        testCase "Parallel categories layout" ( fun () ->
            emptyLayout parcats
        );        
        testCase "Parallel categories styled data" ( fun () ->
            """var data = [{"type":"parcats","dimensions":[{"label":"Lvl1","values":["A","A","A","B","B","B","C","D"],"axis":{}},{"label":"Lvl2","values":["AA","AA","AB","AB","AB","AB","AB","AB"],"axis":{}},{"label":"Lvl3","values":["AAA","AAB","AAC","AAC","AAB","AAB","AAA","AAA"],"axis":{}}],"line":{"color":[0,1,2,2,1,1,0,0],"colorscale":"Viridis"},"bundlecolors":false}];"""
            |> chartGeneratedContains parcatsStyled
        );
        testCase "Parallel categories styled layout" ( fun () ->
            emptyLayout parcatsStyled
        );
    ]


let parcoords =
    let data = 
        [
            "A",[1.;4.;3.4;0.7;]
            "B",[3.;1.5;1.7;2.3;]
            "C",[2.;4.;3.1;5.]
            "D",[4.;2.;2.;4.;]
        ]
    Chart.ParallelCoord(data,LineColor=Color.fromString "blue", UseDefaults = false)

open FSharp.Data
open Deedle

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
        LineColor = colors,
        UseDefaults = false
    )


[<Tests>]
let ``Parallel coordinates charts`` =
    testList "CategoricalCharts.Parallel coordinates charts" [
        testCase "Parallel coordinates data" ( fun () ->
            """var data = [{"type":"parcoords","dimensions":[{"label":"A","values":[1.0,4.0,3.4,0.7],"axis":{}},{"label":"B","values":[3.0,1.5,1.7,2.3],"axis":{}},{"label":"C","values":[2.0,4.0,3.1,5.0],"axis":{}},{"label":"D","values":[4.0,2.0,2.0,4.0],"axis":{}}],"line":{"color":"blue"}}];"""
            |> chartGeneratedContains parcoords
        );
        testCase "Parallel coordinates layout" ( fun () ->
            emptyLayout parcoords
        );
        testCase "Parallel coordinates styled data" ( fun () ->
            """var data = [{"type":"parcoords","dimensions":[{"label":"sepal_length","values":[5.1,4.9,4.7,4.6,5.0,5.4,4.6,5.0,4.4,4.9,5.4,4.8,4.8,4.3,5.8,5.7,5.4,5.1,5.7,5.1,5.4,5.1,4.6,5.1,4.8,5.0,5.0,5.2,5.2,4.7,4.8,5.4,5.2,5.5,4.9,5.0,5.5,4.9,4.4,5.1,5.0,4.5,4.4,5.0,5.1,4.8,5.1,4.6,5.3,5.0,7.0,6.4,6.9,5.5,6.5,5.7,6.3,4.9,6.6,5.2,5.0,5.9,6.0,6.1,5.6,6.7,5.6,5.8,6.2,5.6,5.9,6.1,6.3,6.1,6.4,6.6,6.8,6.7,6.0,5.7,5.5,5.5,5.8,6.0,5.4,6.0,6.7,6.3,5.6,5.5,5.5,6.1,5.8,5.0,5.6,5.7,5.7,6.2,5.1,5.7,6.3,5.8,7.1,6.3,6.5,7.6,4.9,7.3,6.7,7.2,6.5,6.4,6.8,5.7,5.8,6.4,6.5,7.7,7.7,6.0,6.9,5.6,7.7,6.3,6.7,7.2,6.2,6.1,6.4,7.2,7.4,7.9,6.4,6.3,6.1,7.7,6.3,6.4,6.0,6.9,6.7,6.9,5.8,6.8,6.7,6.7,6.3,6.5,6.2,5.9],"range":[0.0,8.0],"axis":{}},{"label":"sepal_width","values":[3.5,3.0,3.2,3.1,3.6,3.9,3.4,3.4,2.9,3.1,3.7,3.4,3.0,3.0,4.0,4.4,3.9,3.5,3.8,3.8,3.4,3.7,3.6,3.3,3.4,3.0,3.4,3.5,3.4,3.2,3.1,3.4,4.1,4.2,3.1,3.2,3.5,3.1,3.0,3.4,3.5,2.3,3.2,3.5,3.8,3.0,3.8,3.2,3.7,3.3,3.2,3.2,3.1,2.3,2.8,2.8,3.3,2.4,2.9,2.7,2.0,3.0,2.2,2.9,2.9,3.1,3.0,2.7,2.2,2.5,3.2,2.8,2.5,2.8,2.9,3.0,2.8,3.0,2.9,2.6,2.4,2.4,2.7,2.7,3.0,3.4,3.1,2.3,3.0,2.5,2.6,3.0,2.6,2.3,2.7,3.0,2.9,2.9,2.5,2.8,3.3,2.7,3.0,2.9,3.0,3.0,2.5,2.9,2.5,3.6,3.2,2.7,3.0,2.5,2.8,3.2,3.0,3.8,2.6,2.2,3.2,2.8,2.8,2.7,3.3,3.2,2.8,3.0,2.8,3.0,2.8,3.8,2.8,2.8,2.6,3.0,3.4,3.1,3.0,3.1,3.1,3.1,2.7,3.2,3.3,3.0,2.5,3.0,3.4,3.0],"range":[0.0,8.0],"axis":{}},{"label":"petal_length","values":[1.4,1.4,1.3,1.5,1.4,1.7,1.4,1.5,1.4,1.5,1.5,1.6,1.4,1.1,1.2,1.5,1.3,1.4,1.7,1.5,1.7,1.5,1.0,1.7,1.9,1.6,1.6,1.5,1.4,1.6,1.6,1.5,1.5,1.4,1.5,1.2,1.3,1.5,1.3,1.5,1.3,1.3,1.3,1.6,1.9,1.4,1.6,1.4,1.5,1.4,4.7,4.5,4.9,4.0,4.6,4.5,4.7,3.3,4.6,3.9,3.5,4.2,4.0,4.7,3.6,4.4,4.5,4.1,4.5,3.9,4.8,4.0,4.9,4.7,4.3,4.4,4.8,5.0,4.5,3.5,3.8,3.7,3.9,5.1,4.5,4.5,4.7,4.4,4.1,4.0,4.4,4.6,4.0,3.3,4.2,4.2,4.2,4.3,3.0,4.1,6.0,5.1,5.9,5.6,5.8,6.6,4.5,6.3,5.8,6.1,5.1,5.3,5.5,5.0,5.1,5.3,5.5,6.7,6.9,5.0,5.7,4.9,6.7,4.9,5.7,6.0,4.8,4.9,5.6,5.8,6.1,6.4,5.6,5.1,5.6,6.1,5.6,5.5,4.8,5.4,5.6,5.1,5.1,5.9,5.7,5.2,5.0,5.2,5.4,5.1],"range":[0.0,8.0],"axis":{}},{"label":"petal_width","values":[0.2,0.2,0.2,0.2,0.2,0.4,0.3,0.2,0.2,0.1,0.2,0.2,0.1,0.1,0.2,0.4,0.4,0.3,0.3,0.3,0.2,0.4,0.2,0.5,0.2,0.2,0.4,0.2,0.2,0.2,0.2,0.4,0.1,0.2,0.1,0.2,0.2,0.1,0.2,0.2,0.3,0.3,0.2,0.6,0.4,0.3,0.2,0.2,0.2,0.2,1.4,1.5,1.5,1.3,1.5,1.3,1.6,1.0,1.3,1.4,1.0,1.5,1.0,1.4,1.3,1.4,1.5,1.0,1.5,1.1,1.8,1.3,1.5,1.2,1.3,1.4,1.4,1.7,1.5,1.0,1.1,1.0,1.2,1.6,1.5,1.6,1.5,1.3,1.3,1.3,1.2,1.4,1.2,1.0,1.3,1.2,1.3,1.3,1.1,1.3,2.5,1.9,2.1,1.8,2.2,2.1,1.7,1.8,1.8,2.5,2.0,1.9,2.1,2.0,2.4,2.3,1.8,2.2,2.3,1.5,2.3,2.0,2.0,1.8,2.1,1.8,1.8,1.8,2.1,1.6,1.9,2.0,2.2,1.5,1.4,2.3,2.4,1.8,1.8,2.1,2.4,2.3,1.9,2.3,2.5,2.3,1.9,2.0,2.3,1.8],"range":[0.0,8.0],"axis":{}}],"line":{"color":[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3],"colorscale":"Viridis"}}];"""
            |> chartGeneratedContains parcoordsStyled
        );
        testCase "Parallel coordinates styled layout" ( fun () ->
            emptyLayout parcoordsStyled
        );
    ]



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
        LinkOutlineWidth = 1.,
        UseDefaults = false
    )


[<Tests>]
let ``Sankey charts`` =
    testList "CategoricalCharts.Sankey charts" [
        testCase "Sankey data" ( fun () ->
            """var data = [{"type":"sankey","node":{"label":["A1","A2","B1","B2","C1","C2","D1"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0}},"link":{"color":["rgba(130, 139, 251, 1.0)","rgba(130, 139, 251, 1.0)","rgba(242, 119, 98, 1.0)","rgba(51, 214, 171, 1.0)","rgba(188, 130, 251, 1.0)","rgba(188, 130, 251, 1.0)","rgba(255, 180, 123, 1.0)","rgba(71, 220, 245, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0},"source":[0,0,1,2,3,3,4,5],"target":[2,3,3,4,4,5,6,6],"value":[8,4,2,7,3,2,5,2]}}];"""
            |> chartGeneratedContains styledSankey
        )
        testCase "Sankey layout" ( fun () ->
            emptyLayout styledSankey
        )
    ]

let character   = ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"]
let parent      = [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ]

let icicleChart =
    Chart.Icicle(
        character,
        parent,
        ShowSectionColorScale = true,
        SectionColorScale = StyleParam.Colorscale.Viridis,
        TilingOrientation = StyleParam.Orientation.Vertical,
        TilingFlip = StyleParam.TilingFlip.Y,
        PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash, 
        UseDefaults = false
    )

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
        Tiling = IcicleTiling.init(Flip = StyleParam.TilingFlip.XY),
        UseDefaults = false
    )

[<Tests>]
let ``Icicle charts`` =
    testList "CategoricalCharts.Icicle charts" [
        testCase "Icicle data" ( fun () ->
            """var data = [{"type":"icicle","parents":["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"],"labels":["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"],"marker":{"colorscale":"Viridis","line":{},"showscale":true},"tiling":{"flip":"y","orientation":"v"},"pathbar":{"edgeshape":"\\"}}];"""
            |> chartGeneratedContains icicleChart
        )
        testCase "Icicle layout" ( fun () ->
            emptyLayout icicleChart
        )        
        testCase "Icicle styled data" ( fun () ->
            """var data = [{"type":"icicle","parents":["","","","","","A","A","B","AA","AA"],"values":[20,1,2,3,4,15,5,1,10,5],"labels":["A","B","C","D","E","AA","AB","BA","AAA","AAB"],"marker":{"colorscale":"Viridis","line":{"color":"rgba(0, 0, 0, 1.0)"},"showscale":true},"branchvalues":"total","tiling":{"flip":"x+y"},"pathbar":{}}];"""
            |> chartGeneratedContains icicleStyled
        )
        testCase "Icicle styled layout" ( fun () ->
            emptyLayout icicleStyled
        )
    ]
