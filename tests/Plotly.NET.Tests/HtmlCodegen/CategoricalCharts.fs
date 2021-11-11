module Tests.CategoricalCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

let parallelCategoriesChart =
    let dims =
        [
            Dimensions.init(["Cat1";"Cat1";"Cat1";"Cat1";"Cat2";"Cat2";"Cat3"],Label="A")
            Dimensions.init([0;1;0;1;0;0;0],Label="B",TickText=["YES";"NO"])
        ]
    
    Chart.ParallelCategories(
        dims,
        Color=Color.fromColorScaleValues [0.;1.;0.;1.;0.;0.;0.],
        Colorscale = StyleParam.Colorscale.Blackbody, 
        UseDefaults = false
    )

[<Tests>]
let ``Parallel categories charts`` =
    testList "CategoricalCharts.Parallel categories charts" [
        testCase "Parallel categories data" ( fun () ->
            "var data = [{\"type\":\"parcats\",\"dimensions\":[{\"values\":[\"Cat1\",\"Cat1\",\"Cat1\",\"Cat1\",\"Cat2\",\"Cat2\",\"Cat3\"],\"label\":\"A\"},{\"values\":[0,1,0,1,0,0,0],\"label\":\"B\",\"ticktext\":[\"YES\",\"NO\"]}],\"color\":[0.0,1.0,0.0,1.0,0.0,0.0,0.0],\"line\":{\"colorscale\":\"Blackbody\"}}];"
            |> chartGeneratedContains parallelCategoriesChart
        );
        testCase "Parallel categories layout" ( fun () ->
            emptyLayout parallelCategoriesChart
        );
    ]


let parcoords1Chart =
    let data = 
        [
            "A",[1.;4.;3.4;0.7;]
            "B",[3.;1.5;1.7;2.3;]
            "C",[2.;4.;3.1;5.]
            "D",[4.;2.;2.;4.;]
        ]
    Chart.ParallelCoord(data,Color=Color.fromString "blue", UseDefaults = false)

let parcoordsChart = 
    let v = [|
        Dimensions.init([|1.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),StyleParam.Range.MinMax (1.,2.),Label="A");
        Dimensions.init([|3.;1.5;|], 
            StyleParam.Range.MinMax (1.,5.),Label="B",Tickvals=[|1.5;3.;4.;5.;|]);
        Dimensions.init([|2.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),Label="C",Tickvals=[|1.;2.;4.;5.;|],
                TickText=[|"txt 1";"txt 2";"txt 4";"txt 5";|]);
        Dimensions.init([|4.;2.;|],  
            StyleParam.Range.MinMax (1.,5.),Label="D");
    |]

    let dyn = Trace("parcoords")

    dyn?dimensions <- v
    dyn?line <- Line.init(Color =Color.fromString "blue")

    dyn
    |> GenericChart.ofTraceObject false

[<Tests>]
let ``Parallel coordinates charts`` =
    testList "CategoricalCharts.Parallel coordinates charts" [
        testCase "Parallel coordinates 1 data" ( fun () ->
            "var data = [{\"type\":\"parcoords\",\"dimensions\":[{\"values\":[1.0,4.0,3.4,0.7],\"label\":\"A\"},{\"values\":[3.0,1.5,1.7,2.3],\"label\":\"B\"},{\"values\":[2.0,4.0,3.1,5.0],\"label\":\"C\"},{\"values\":[4.0,2.0,2.0,4.0],\"label\":\"D\"}],\"line\":{\"color\":\"blue\"}}];"
            |> chartGeneratedContains parcoords1Chart
        );
        testCase "Parallel coordinates 1 layout" ( fun () ->
            emptyLayout parcoords1Chart
        );
        testCase "Parallel coordinates data" ( fun () ->
            "var data = [{\"type\":\"parcoords\",\"dimensions\":[{\"values\":[1.0,4.0],\"range\":[1.0,5.0],\"constraintrange\":[1.0,2.0],\"label\":\"A\"},{\"values\":[3.0,1.5],\"range\":[1.0,5.0],\"label\":\"B\",\"tickvals\":[1.5,3.0,4.0,5.0]},{\"values\":[2.0,4.0],\"range\":[1.0,5.0],\"label\":\"C\",\"tickvals\":[1.0,2.0,4.0,5.0],\"ticktext\":[\"txt 1\",\"txt 2\",\"txt 4\",\"txt 5\"]},{\"values\":[4.0,2.0],\"range\":[1.0,5.0],\"label\":\"D\"}],\"line\":{\"color\":\"blue\"}}];"
            |> chartGeneratedContains parcoordsChart
        );
        testCase "Parallel coordinates layout" ( fun () ->
            emptyLayout parcoordsChart
        );
    ]


let sankey1 = 
    // create nodes
    let n1 = Node.Create("a",color=Color.fromString "Black")
    let n2 = Node.Create("b",color=Color.fromString "Red")
    let n3 = Node.Create("c",color=Color.fromString "Purple")
    let n4 = Node.Create("d",color=Color.fromString "Green")
    let n5 = Node.Create("e",color=Color.fromString "Orange")
    
    // create links between nodes
    let link1 = Link.Create(n1,n2,value=1.0)
    let link2 = Link.Create(n2,n3,value=2.0)
    let link3 = Link.Create(n1,n5,value=1.3)
    let link4 = Link.Create(n4,n5,value=1.5)
    let link5 = Link.Create(n3,n5,value=0.5)
    Chart.Sankey(
        [n1;n2;n3;n4;n5],
        [link1;link2;link3;link4;link5], 
        UseDefaults = false
    )
    |> Chart.withTitle "Sankey Sample"

[<Tests>]
let ``Sankey charts`` =
    testList "CategoricalCharts.Sankey charts" [
        testCase "Sankey data" ( fun () ->
            "var data = [{\"type\":\"sankey\",\"node\":{\"label\":[\"a\",\"b\",\"c\",\"d\",\"e\"],\"color\":[\"Black\",\"Red\",\"Purple\",\"Green\",\"Orange\"]},\"link\":{\"source\":[0,1,0,3,2],\"target\":[1,2,4,4,4],\"value\":[1.0,2.0,1.3,1.5,0.5]}}];"
            |> chartGeneratedContains sankey1
        )
        testCase "Sankey layout" ( fun () ->
            "var layout = {\"title\":{\"text\":\"Sankey Sample\"}};"
            |> chartGeneratedContains sankey1
        )
    ]

let character   = ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"]
let parent      = [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ]

let icicleChart =
    Chart.Icicle(
        character,
        parent,
        ShowScale = true,
        ColorScale = StyleParam.Colorscale.Viridis,
        TilingOrientation = StyleParam.Orientation.Vertical,
        TilingFlip = StyleParam.TilingFlip.Y,
        PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash, 
        UseDefaults = false
    )

[<Tests>]
let ``Icicle charts`` =
    testList "CategoricalCharts.Icicle charts" [
        testCase "Icicle data" ( fun () ->
            """var data = [{"type":"icicle","parents":["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"],"labels":["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"],"tiling":{"flip":"y","orientation":"v"},"pathbar":{"edgeshape":"\\"},"marker":{"colorscale":"Viridis","showscale":true}}];"""
            |> chartGeneratedContains icicleChart
        )
        testCase "Icicle layout" ( fun () ->
            emptyLayout icicleChart
        )
    ]