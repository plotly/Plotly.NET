module ChartDomainTestCharts

open Plotly.NET
open Plotly.NET.TraceObjects

module Pie = 

    let ``Simple pie chart`` =
        let values = [19; 26; 55;]
        let labels = ["Residential"; "Non-Residential"; "Utility"]
        Chart.Pie(values = values, Labels = labels, UseDefaults = false)

    let ``Styled pie chart`` = 

        let values = [19; 26; 55;]
        let labels = ["Residential"; "Non-Residential"; "Utility"]

        Chart.Pie(
            values = values,
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
            MultiPull = [0.; 0.3; 0.],
            UseDefaults = false
        )

module Doughnut =

    let ``Simple doughnut chart`` =
        let values = [19; 26; 55;]
        let labels = ["Residential"; "Non-Residential"; "Utility"]
        Chart.Doughnut(
            values = values,
            Labels = labels,
            Hole=0.3,
            MultiText=labels, 
            UseDefaults = false
        )

module FunnelArea = 

    let ``Simple funnelarea chart`` = 
        let values = [|5; 4; 3; 2; 1|]
        let text = [|"The 1st"; "The 2nd"; "The 3rd"; "The 4th"; "The 5th"|]
        let line = Line.init (Color=Color.fromString "purple", Width=3.)
        Chart.FunnelArea(values=values, MultiText=text, SectionOutline=line, UseDefaults = false)


    
    let ``Styled funnelarea chart`` =
        let values = [|5; 4; 3|]
        let labels = [|"The 1st"; "The 2nd"; "The 3rd"|]

        Chart.FunnelArea(
            values = values,
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
            BaseRatio = 0.1,
            UseDefaults = false
        )

module Sunburst = 

    
    let ``Simple sunburst chart`` =
        Chart.Sunburst(
            labels = ["A";"B";"C";"D";"E"],
            parents = ["";"";"B";"B";""],
            Values=[5.;0.;3.;2.;3.],
            MultiText=["At";"Bt";"Ct";"Dt";"Et"], 
            UseDefaults = false
        )

    let ``Styled sunburst chart`` = 
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

module Treemap = 
    
    
    let ``Styled treemap chart`` = 
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

module ParallelCoord = 
    
    let ``Simple parallel coordinates chart`` =
        let data = 
            [
                "A",[1.;4.;3.4;0.7;]
                "B",[3.;1.5;1.7;2.3;]
                "C",[2.;4.;3.1;5.]
                "D",[4.;2.;2.;4.;]
            ]
        Chart.ParallelCoord(keyValues = data,LineColor=Color.fromString "blue", UseDefaults = false)

    let ``Styled parallel coordinates chart`` =

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

module ParallelCategories = 

    let ``Simple parallel categories chart`` =
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

    let ``Styled parallel categories chart`` =
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

module Sankey = 
    
    let ``Styled sankey chart`` = 
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


module Table =

    let ``Simple table chart`` =
        let header = ["<b>RowIndex</b>";"A";"simple";"table"]
        let rows = 
            [
             ["0";"I"     ;"am"     ;"a"]        
             ["1";"little";"example";"!"]       
            ]
        Chart.Table(headerValues = header, cellsValues = rows, UseDefaults = false)

    let ``Styled table chart`` =
        let header = ["<b>RowIndex</b>";"A";"simple";"table"]
        let rows = 
              [
               ["0";"I"     ;"am"     ;"a"]        
               ["1";"little";"example";"!"]       
              ]
        Chart.Table(
            headerValues = header,
            cellsValues = rows,
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

    let ``Cell color dependent table chart`` =
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
            headerValues = header2,
            cellsValues = rowvalues,
            CellsFillColor=cellcolor, 
            UseDefaults = false
        )

    
    let ``Sequence representation table chart`` =
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
            headerValues = headers,
            cellsValues = cells,
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

module Indicator = 
    
    open Plotly.NET.TraceObjects
    open Plotly.NET.LayoutObjects

    let ``Angular gauge indicator`` =
        ChartDomain.Chart.Indicator(
            value = 200., 
            mode = StyleParam.IndicatorMode.NumberDeltaGauge,
            Delta   = IndicatorDelta.init(Reference=160),
            Range   = StyleParam.Range.MinMax(0., 250.),
            Domain  = Domain.init(Row = 0, Column = 0), 
            UseDefaults = false
        )

    let ``Bullet gauge indicator`` =
        Chart.Indicator(
            value = 120, 
            mode = StyleParam.IndicatorMode.NumberDeltaGauge,
            DeltaReference = 90,
            Range = StyleParam.Range.MinMax(-200., 200.),
            GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
            ShowGaugeAxis = false,
            Domain  = Domain.init(Row = 0, Column = 1), 
            UseDefaults = false
        )

    let ``Delta indicator with reference`` =
        Chart.Indicator(
            value = "300", 
            mode = StyleParam.IndicatorMode.NumberDelta,
            DeltaReference = 90.,
            Domain  = Domain.init(Row = 1, Column = 0), 
            UseDefaults = false
        )

    let ``Delta indicator`` =
        Chart.Indicator(
            value = 40., 
            mode = StyleParam.IndicatorMode.Delta,
            DeltaReference = 90.,
            Domain  = Domain.init(Row = 1, Column = 1), 
            UseDefaults = false
        )


module Icicle = 

    let ``Simple icicle chart`` =
        Chart.Icicle(
            labels  = ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"],
            parents = [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve"],
            ShowSectionColorScale = true,
            SectionColorScale = StyleParam.Colorscale.Viridis,
            TilingOrientation = StyleParam.Orientation.Vertical,
            TilingFlip = StyleParam.TilingFlip.Y,
            PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash, 
            UseDefaults = false
        )

    let ``Styled icicle chart`` = 
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