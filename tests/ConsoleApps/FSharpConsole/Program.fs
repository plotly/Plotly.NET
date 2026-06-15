open Plotly.NET

[<EntryPoint>]
let main _ =

    // sample sets with overlapping members to exercise every venn region
    let setA = Set.ofList [ 1; 2; 3; 4; 5; 6; 11 ]
    let setB = Set.ofList [ 1; 2; 3; 7; 8; 9; 10; 12; 13 ]
    let setC = Set.ofList [ 1; 4; 5; 6; 7; 8; 9; 10; 14; 15; 16 ]

    // two-set venn diagram
    let twoSetVenn =
        Chart.Venn(
            set1 = setA,
            set2 = setB,
            Label1 = "A",
            Label2 = "B",
            UseDefaults = true
        )
        |> Chart.withTitle "Venn: two sets"

    // three-set venn diagram with custom colors and font
    let threeSetVenn =
        Chart.Venn(
            set1 = setA,
            set2 = setB,
            Set3 = setC,
            Label1 = "A",
            Label2 = "B",
            Label3 = "C",
            Colors = [| Color.fromKeyword Aqua; Color.fromKeyword Salmon; Color.fromKeyword LightGreen |],
            TextFont = Font.init (Family = StyleParam.FontFamily.Courier_New, Size = 18., Color = Color.fromKeyword Black),
            UseDefaults = true
        )
        |> Chart.withTitle "Venn: three sets (styled)"

    twoSetVenn |> Chart.show
    threeSetVenn |> Chart.show

    0
