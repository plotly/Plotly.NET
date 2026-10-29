(**
---
title: Venn diagrams
category: Set comparison charts
categoryindex: 14
index: 1
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.3"
#r "nuget: DynamicObj, 8.0.0"
#r "nuget: Giraffe.ViewEngine, 1.4.0"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(**
# Venn diagrams

`Chart.Venn` compares two or three sets of string identifiers. Each region shows the number
of members that belong to exactly that combination of sets. Duplicate identifiers within a
set are ignored.

The circles have fixed sizes: their areas do not represent set or intersection sizes.
Read the region counts to compare membership. For more than three sets, use an
[UpSet plot](upset.html).

## Two sets

The sets below share identifiers `"3"` and `"4"`. The overlap therefore contains two members,
and each set also has two members outside the overlap.
*)

open Plotly.NET

let setA = [ "1"; "2"; "3"; "4" ]
let setB = [ "3"; "4"; "5"; "6" ]

let twoSets =
    Chart.Venn(
        set1 = setA,
        set2 = setB,
        Label1 = "A",
        Label2 = "B"
    )
    |> Chart.withSize (640, 440)

(*** hide ***)
twoSets |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
## Three sets and styling

Pass `Set3` to add a third set. In this example all seven regions contain members:
the center contains `"1"`, which belongs to all three sets. The pairwise regions exclude
that shared member; for example, the A-and-B-only region contains `"2"` and `"3"`.

Give each set a distinct label. `Colors` takes one color per set, in input order, and
`TextFont` controls the region-count text. The chart preserves a 1:1 axis scale so the
circles stay round when its dimensions change.
*)

let threeSets =
    Chart.Venn(
        set1 = [ "1"; "2"; "3"; "4"; "5"; "6"; "11" ],
        set2 = [ "1"; "2"; "3"; "7"; "8"; "9"; "10"; "12"; "13" ],
        Set3 = [ "1"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "14"; "15"; "16" ],
        Label1 = "A",
        Label2 = "B",
        Label3 = "C",
        Colors = [ Color.fromHex "#247BA0"; Color.fromHex "#F25F5C"; Color.fromHex "#70C1B3" ],
        TextFont = Font.init(Family = StyleParam.FontFamily.Arial, Size = 18.)
    )
    |> Chart.withSize (640, 500)

(*** hide ***)
threeSets |> GenericChart.toChartHTML
(*** include-it-raw ***)
