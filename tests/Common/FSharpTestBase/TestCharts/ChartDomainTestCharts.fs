module ChartDomainTestCharts

open Plotly.NET

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

module FunnelArea = ()

module Sunburst = ()

module Treemap = ()

module ParralelCoord = ()

module ParralelCategories = ()

module Sankey = ()

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

module Indicator = ()

module Icicle = ()