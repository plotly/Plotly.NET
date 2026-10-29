(**
---
title: UpSet plots
category: Set comparison charts
categoryindex: 14
index: 2
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
# UpSet plots

`Chart.UpSet` compares membership across several sets using a dot matrix and bar charts.
It is useful when a [Venn diagram](venn.html) would become difficult to read.

Each matrix column represents an **exclusive intersection**: a member belongs to every set marked
with a dark dot and to none of the sets marked with a pale dot. Connecting lines join the dark dots.
The bar above a column counts its members; the horizontal bars on the left show the full set sizes.
Intersections are ordered by decreasing size by default.

## Basic example

Provide one unique label for each set, in the same order as the `sets` input. Members are strings,
and duplicate entries within a set are ignored. Here, A and B share `"2"` and `"3"` exclusively;
`"1"` belongs to all three sets and is counted in a separate column.

The default `MinIntersectionSize` is **5**. This small example uses **1** to show every nonempty
intersection, including those containing just one member.
*)

open Plotly.NET

let labels = [| "A"; "B"; "C" |]

let sets =
    [|
        [| "1"; "2"; "3"; "4"; "5"; "6"; "11" |]
        [| "1"; "2"; "3"; "7"; "8"; "9"; "10"; "12"; "13" |]
        [| "1"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "14"; "15"; "16" |]
    |]

let upset =
    Chart.UpSet(
        labels = labels,
        sets = sets,
        MinIntersectionSize = 1
    )
    |> Chart.withTitle "Membership across three sets"
    |> Chart.withSize(640, 500)
    |> Chart.withMarginSize(Left = 65, Right = 25, Top = 65, Bottom = 45)

(*** hide ***)
upset |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
## Filtering and styling

Raise `MinIntersectionSize` to hide small intersections. The set-size bars still count all members
of each input set, including members whose intersection columns have been filtered out.

`MainColor` controls the bars and the active membership dots and lines. `SecondaryColor` controls
the inactive dots. `MarkerSize`, `TextFont`, and `TextFontLabel` adjust the matrix markers,
axis titles, and set labels respectively.
*)

let upsetStyled =
    Chart.UpSet(
        labels = labels,
        sets = sets,
        MinIntersectionSize = 2,
        MainColor = Color.fromHex "#2A6F97",
        SecondaryColor = Color.fromHex "#DCE6ED",
        MarkerSize = 18,
        TextFont = Font.init(Family = StyleParam.FontFamily.Arial, Size = 14.),
        TextFontLabel = Font.init(Family = StyleParam.FontFamily.Arial, Size = 16.)
    )
    |> Chart.withTitle "Intersections with at least two members"
    |> Chart.withSize(640, 500)
    |> Chart.withMarginSize(Left = 65, Right = 25, Top = 65, Bottom = 45)

(*** hide ***)
upsetStyled |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
## Adding member measurements

`SetData` adds feature plots above the intersection counts. Each map associates a member identifier
with a measurement and must contain every member in every displayed intersection. A map covering
only one input set is insufficient; this example builds one map for the entire union.

Provide one `(chart function, title)` pair in `SetDataChartsTitle` for each map in `SetData`, in the
same order. The chart function receives the values for one exclusive intersection at a time.
Here, a box plot shows the measurements for each displayed intersection. For this illustration,
a member's score is simply the numeric value of its identifier.
*)

let memberScores =
    sets
    |> Seq.collect id
    |> Seq.distinct
    |> Seq.map (fun memberId -> memberId, float (int memberId))
    |> Map.ofSeq

let scoreBoxPlot (scores: float[]) =
    Chart.BoxPlot(
        Y = scores,
        BoxPoints = StyleParam.BoxPoints.All,
        Jitter = 0.15,
        PointPos = 0.,
        MarkerColor = Color.fromHex "#2A6F97",
        OutlineColor = Color.fromHex "#2A6F97"
    )

let upsetWithScores =
    Chart.UpSet(
        labels = labels,
        sets = sets,
        MinIntersectionSize = 2,
        SetData = [ memberScores ],
        SetDataChartsTitle = [ (scoreBoxPlot, "Member score") ],
        MarkerSize = 18,
        TextFont = Font.init(Family = StyleParam.FontFamily.Arial, Size = 14.),
        TextFontLabel = Font.init(Family = StyleParam.FontFamily.Arial, Size = 16.)
    )
    |> Chart.withTitle "Member scores within each intersection"
    |> Chart.withSize(640, 600)
    |> Chart.withMarginSize(Left = 65, Right = 25, Top = 65, Bottom = 45)

(*** hide ***)
upsetWithScores |> GenericChart.toChartHTML
(*** include-it-raw ***)
