module ChartCompositeTestCharts

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

module Venn =

    let ``Two set venn diagram`` =
        Chart.Venn(
            set1 = Set.ofList [ 1; 2; 3; 4 ],
            set2 = Set.ofList [ 3; 4; 5; 6 ],
            Label1 = "A",
            Label2 = "B",
            UseDefaults = false
        )

    let ``Three set venn diagram`` =
        // every region (3 single, 3 pairwise, 1 triple) is populated with a distinct count
        Chart.Venn(
            set1 = Set.ofList [ 1; 2; 3; 4; 5; 6; 11 ],
            set2 = Set.ofList [ 1; 2; 3; 7; 8; 9; 10; 12; 13 ],
            Set3 = Set.ofList [ 1; 4; 5; 6; 7; 8; 9; 10; 14; 15; 16 ],
            Label1 = "A",
            Label2 = "B",
            Label3 = "C",
            UseDefaults = false
        )

    let ``Styled two set venn diagram`` =
        Chart.Venn(
            set1 = Set.ofList [ 1; 2; 3; 4 ],
            set2 = Set.ofList [ 3; 4; 5; 6 ],
            Label1 = "A",
            Label2 = "B",
            Colors = [| Color.fromKeyword Aqua; Color.fromKeyword Salmon |],
            TextFont = Font.init (Family = StyleParam.FontFamily.Courier_New, Size = 20., Color = Color.fromKeyword Purple),
            UseDefaults = false
        )
