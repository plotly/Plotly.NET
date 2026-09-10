open Plotly.NET

[<EntryPoint>]
let main _ =

    let encodedHeatmap =
        Chart.Heatmap(
            zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0; 7.0; 8.0; 9.0 |], shape = [ 3; 3 ]),
            Name = "encoded heatmap",
            UseDefaults = false
        )

    // sample sets with overlapping members to exercise every venn region
    let setA = [| "1"; "2"; "3"; "4"; "5"; "6"; "11" |]
    let setB = [| "1"; "2"; "3"; "7"; "8"; "9"; "10"; "12"; "13" |]
    let setC = [| "1"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "14"; "15"; "16" |]

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

    // upset plot comparing the same three sets
    let upset =
        Chart.UpSet(
            labels = [| "A"; "B"; "C" |],
            sets = [| setA; setB; setC |],
            MinIntersectionSize = 1,
            UseDefaults = true
        )

    encodedHeatmap |> Chart.show
    twoSetVenn |> Chart.show
    threeSetVenn |> Chart.show
    upset |> Chart.show

    0
