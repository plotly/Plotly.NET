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
        dimensions = dims,
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
        dimensions = dims,
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
    Chart.ParallelCoord(keyValues = data,LineColor=Color.fromString "blue", UseDefaults = false)

let parcoordsStyled =

    let dims = 
        [
            Dimension.initParallel(Label = "1", Values = ([1;2;3;4] ), Range = StyleParam.Range.MinMax(0., 8.))
            Dimension.initParallel(Label = "2", Values = ([1;2;3;4] |> List.rev ), Range = StyleParam.Range.MinMax(0., 8.))
            Dimension.initParallel(Label = "3", Values = ([1;2;3;4] ), Range = StyleParam.Range.MinMax(0., 8.))
            Dimension.initParallel(Label = "4", Values = ([1;2;3;4] |> List.rev ), Range = StyleParam.Range.MinMax(0., 8.))
        ]

    let colors = 
        [1;2;3;4]
        |> Color.fromColorScaleValues

    Chart.ParallelCoord(
        dimensions = dims,
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
            """var data = [{"type":"parcoords","dimensions":[{"label":"1","values":[1,2,3,4],"range":[0.0,8.0],"axis":{}},{"label":"2","values":[4,3,2,1],"range":[0.0,8.0],"axis":{}},{"label":"3","values":[1,2,3,4],"range":[0.0,8.0],"axis":{}},{"label":"4","values":[4,3,2,1],"range":[0.0,8.0],"axis":{}}],"line":{"color":[1,2,3,4],"colorscale":"Viridis"}}];"""
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
        labels = character,
        parents = parent,
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
        labelsparents = (labelsParents |> Seq.map fst),
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


let sunburstChart =
    Chart.Sunburst(
        labels = ["A";"B";"C";"D";"E"],
        parents = ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        MultiText=["At";"Bt";"Ct";"Dt";"Et"], 
        UseDefaults = false
    )

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
        labelsparents = (labelsParents |> Seq.map fst),
        Values = (labelsParents |> Seq.map snd), 
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Rotation = 45,
        UseDefaults = false
    )

[<Tests>]
let ``Sunburst charts`` =
    testList "CategoricalCharts.Sunburst charts" [
        testCase "Sunburst data" ( fun () ->
            """var data = [{"type":"sunburst","parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"labels":["A","B","C","D","E"],"text":["At","Bt","Ct","Dt","Et"],"marker":{"line":{}}}];"""
            |> chartGeneratedContains sunburstChart
        );
        testCase "Sunburst layout" ( fun () ->
            emptyLayout sunburstChart
        );       
        testCase "Sunburst styled data" ( fun () ->
            """var data = [{"type":"sunburst","parents":["","","","","","A","A","B","AA","AA"],"values":[20,1,2,3,4,15,5,1,10,5],"labels":["A","B","C","D","E","AA","AB","BA","AAA","AAB"],"marker":{"colorscale":"Viridis","line":{"color":"rgba(0, 0, 0, 1.0)"},"showscale":true},"branchvalues":"total","rotation":45}];"""
            |> chartGeneratedContains sunburstStyled
        );
        testCase "Sunburst styled layout" ( fun () ->
            emptyLayout sunburstStyled
        );
    ]


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
        labelsparents = (labelsParents |> Seq.map fst),
        Values = (labelsParents |> Seq.map snd), 
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Tiling = TreemapTiling.init(Packing = StyleParam.TreemapTilingPacking.SliceDice),
        UseDefaults = false
    )

[<Tests>]
let ``Treemap charts`` =
    testList "CategoricalCharts.Treemap charts" [
        testCase "Treemap styled data" ( fun () ->
            """var data = [{"type":"treemap","parents":["","","","","","A","A","B","AA","AA"],"values":[20,1,2,3,4,15,5,1,10,5],"labels":["A","B","C","D","E","AA","AB","BA","AAA","AAB"],"marker":{"colorscale":"Viridis","line":{"color":"rgba(0, 0, 0, 1.0)"},"showscale":true},"branchvalues":"total","tiling":{"packing":"slice-dice"}}];"""
            |> chartGeneratedContains treemapStyled
        );
        testCase "Treemap styled layout" ( fun () ->
            emptyLayout treemapStyled
        );
    ]