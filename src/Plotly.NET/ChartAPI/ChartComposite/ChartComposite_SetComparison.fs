namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartComposite_SetComparison =

    module internal VennUtils =

        /// A single region of a Venn diagram: the labels of the sets it belongs to, together with its members.
        type VennSet<'a when 'a: comparison> = {
            Label: string list
            Set: Set<'a>
        }

        /// A generic venn, mapping each region id to its corresponding set of members.
        type GenericVenn<'a when 'a: comparison> = Map<string, VennSet<'a>>

        /// Converts a label list to a string id by concatenating the labels with "&".
        let labelToId (label: string list) = label |> String.concat "&"

        /// Generates a generic venn from an array of labeled sets.
        let ofSetList (labels: string[]) (sets: Set<'a>[]) =
            let union = Set.unionMany sets

            let toLabel (membership: bool[]) =
                membership
                |> Array.mapi (fun i isMember -> if isMember then Some labels.[i] else None)
                |> Array.choose id
                |> Array.toList

            union
            |> Seq.map (fun item -> item, Array.init sets.Length (fun i -> sets.[i].Contains item))
            |> Seq.groupBy snd
            |> Seq.map (fun (membership, items) ->
                let label = toLabel membership
                let set = items |> Seq.map fst |> Set.ofSeq
                labelToId label, { Label = label; Set = set })
            |> Map.ofSeq

        /// Converts a generic venn to an array of (labels, count) pairs.
        let toVennCountLabelArr (genericVenn: GenericVenn<'a>) =
            genericVenn
            |> Seq.map (fun kv -> kv.Value.Label |> Array.ofList, kv.Value.Set.Count)
            |> Array.ofSeq

        /// Initializes the circle shape used to draw a single venn set.
        let initCircleShape x0 y0 x1 y1 color =
            Shape.init(
                Opacity = 0.3,
                Xref = "x",
                Yref = "y",
                FillColor = color,
                X0 = x0,
                Y0 = y0,
                X1 = x1,
                Y1 = y1,
                ShapeType = StyleParam.ShapeType.Circle,
                Line = Line.init(Color = color)
            )

    module internal UpSetUtils =

        /// Combines two arrays by taking the next element alternating from array a and b.
        let combineArrayAlternating (a: array<'a>) (b: array<'a>) =
            List.fold2 (fun acc a' b' ->
                b' :: a' :: acc
            ) [] (a |> List.ofArray) (b |> List.ofArray)
            |> List.rev
            |> Array.ofList

        /// Creates a linear axis without lines and ticks with a given range.
        let createLinearAxisWithRange (maxRange: float) =
            let range = StyleParam.Range.MinMax(-0.5, maxRange)
            LinearAxis.init(Range = range, ShowGrid = false, ShowLine = false, ShowTickLabels = false, ZeroLine = false)

        /// Creates a linear axis without lines and ticks with a given range and domain.
        let createLinearAxisWithRangeDomain (maxRange: float) domain =
            let range = StyleParam.Range.MinMax(-0.5, maxRange)
            LinearAxis.init(Range = range, ShowGrid = false, ShowLine = false, ShowTickLabels = false, ZeroLine = false, Domain = StyleParam.Range.MinMax domain)

        /// Creates a linear axis without lines with a given range and custom tick labels.
        let createLinearAxisWithRangeTickLabel (maxRange: float) (labels: string[]) (font: Font) =
            let range = StyleParam.Range.MinMax(-0.5, maxRange)
            LinearAxis.init(Range = range, ShowGrid = false, ShowLine = false, ShowTickLabels = true, ZeroLine = false, TickMode = StyleParam.TickMode.Array, TickVals = [ 0 .. labels.Length - 1 ], TickText = labels, TickFont = font)

        /// Creates the line chart connecting the sets present in the intersection for the intersection matrix.
        let createIntersectionLineChart (useDefaults: bool) (data: (int * int)[]) (markerSize: int) (color: Color) =
            Chart.Line(
                data,
                ShowMarkers = true,
                LineDash = StyleParam.DrawingStyle.Solid,
                LineWidth = (float markerSize / 5.),
                LineColor = color,
                UseDefaults = useDefaults
            )
            |> Chart.withMarkerStyle(
                Symbol = StyleParam.MarkerSymbol.Circle,
                Size = markerSize
            )

        /// Creates the point chart for the sets not present in the intersection for the intersection matrix.
        let createIntersectionPointChart (useDefaults: bool) (data: (int * int)[]) (markerSize: int) (color: Color) =
            Chart.Point(data, UseDefaults = useDefaults)
            |> Chart.withMarkerStyle(
                Symbol = StyleParam.MarkerSymbol.Circle,
                Size = markerSize,
                Color = color
            )

        /// Creates the part of the intersection matrix representing the current intersection.
        /// The position on the y-Axis is based on the order the labels and sets are given in.
        /// The position on the x-Axis is based on the given position (determined by intersection size).
        let createIntersectionPlotPart (useDefaults: bool) (position: int) (intersectingSets: string list) (labelIDs: (string * int)[]) (markerSize: int) (colorIntersecting: Color) (colorNotIntersecting: Color) =
            let setIDsPresent, setIDsNotPresent =
                labelIDs
                |> Array.partition (fun (label, _) -> intersectingSets |> List.contains label)
            let lineChart =
                let idWithPosition =
                    setIDsPresent
                    |> Array.map (fun (_, id) -> position, id)
                createIntersectionLineChart useDefaults idWithPosition markerSize colorIntersecting
            let pointChart =
                let idWithPosition =
                    setIDsNotPresent
                    |> Array.map (fun (_, id) -> position, id)
                createIntersectionPointChart useDefaults idWithPosition markerSize colorNotIntersecting
            [
                pointChart
                lineChart
            ]
            |> Chart.combine

        /// Creates a bar chart with the set sizes.
        let createSetSizePlot (useDefaults: bool) (labels: array<string>) (sets: array<Set<'a>>) (maxY: float) (color: Color) (domainSet: float * float) (textFont: Font) =
            let labelCount =
                Array.map2 (fun label (set: Set<'a>) -> label, set.Count) labels sets
            let maxSetSize =
                labelCount
                |> Array.maxBy snd
                |> snd
            Chart.Bar(labelCount, MarkerColor = color, UseDefaults = useDefaults)
            |> Chart.withXAxisStyle("Set Size", MinMax = (float maxSetSize, 0.), Domain = domainSet, TitleFont = textFont)
            |> Chart.withYAxis(createLinearAxisWithRange maxY)
            |> Chart.withTraceInfo(ShowLegend = false)

        /// Creates a bar chart with the intersection sizes.
        let createIntersectionSizePlots (useDefaults: bool) (intersectionCount: (string list * int)[]) (maxX: float) (color: Color) (domainIntersection: float * float) (textFont: Font) =
            intersectionCount
            |> Array.map snd
            |> fun count -> Chart.Column(count, MarkerColor = color, UseDefaults = useDefaults)
            |> Chart.withXAxis(createLinearAxisWithRangeDomain maxX domainIntersection)
            |> Chart.withYAxisStyle("Intersection Size", TitleFont = textFont)
            |> Chart.withTraceInfo(ShowLegend = false)

        /// Aligns the per-set element->feature maps to the intersections.
        let alignIntersectionData (venn: (string list * Set<'a>)[]) (setData: Map<'a, 'b>) =
            venn
            |> Array.map (fun (_, set) ->
                set
                |> Set.toArray
                |> Array.map (fun entry -> setData.[entry])
            )

        /// Creates the intersection feature plot with the given charting function.
        let createIntersectionDataPlots (intersectionData: array<array<'b>>) (title: string) (maxX: float) (chartFun: array<'b> -> GenericChart) (domainIntersection: float * float) (textFont: Font) =
            intersectionData
            |> Array.map chartFun
            |> Chart.combine
            |> Chart.withLegendStyle(Visible = false)
            |> Chart.withXAxis(createLinearAxisWithRangeDomain maxX domainIntersection)
            |> Chart.withYAxisStyle(title, TitleFont = textFont)

    open VennUtils
    open UpSetUtils

    [<Extension>]
    type Chart =

        /// <summary>
        /// Creates a Venn diagram comparing two or three sets.
        ///
        /// The size of each circle is fixed; the diagram annotates each region (single sets and their intersections) with the number of members it contains.
        ///
        /// Each input array is interpreted as a set: duplicate entries are ignored.
        /// </summary>
        /// <param name="set1">Sets the members of the first set. Duplicate entries are ignored.</param>
        /// <param name="set2">Sets the members of the second set. Duplicate entries are ignored.</param>
        /// <param name="Set3">Sets the members of an optional third set. If omitted, a two-set diagram is created. Duplicate entries are ignored.</param>
        /// <param name="Label1">Sets the label of the first set. Defaults to "Set 1".</param>
        /// <param name="Label2">Sets the label of the second set. Defaults to "Set 2".</param>
        /// <param name="Label3">Sets the label of the third set. Defaults to "Set 3". Ignored when no third set is given.</param>
        /// <param name="Colors">Sets the fill colors of the circle shapes, one per set.</param>
        /// <param name="TextFont">Sets the font used for the region count annotations.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Venn
            (
                set1: #seq<string>,
                set2: #seq<string>,
                ?Set3: #seq<string>,
                ?Label1: string,
                ?Label2: string,
                ?Label3: string,
                ?Colors: #seq<Color>,
                ?TextFont: Font,
                ?UseDefaults: bool
            ) =
            let useDefaults = defaultArg UseDefaults true

            // the public API takes plain string sequences for interop; internally they are treated as sets
            let labels, sets =
                match Set3 with
                | Some set3 ->
                    [| defaultArg Label1 "Set 1"; defaultArg Label2 "Set 2"; defaultArg Label3 "Set 3" |],
                    [| Set.ofSeq set1; Set.ofSeq set2; Set.ofSeq set3 |]
                | None ->
                    [| defaultArg Label1 "Set 1"; defaultArg Label2 "Set 2" |],
                    [| Set.ofSeq set1; Set.ofSeq set2 |]

            let textFont =
                TextFont
                |> Option.defaultValue (
                    Font.init(
                        Family = StyleParam.FontFamily.Arial,
                        Size = 18.,
                        Color = Color.fromKeyword Black
                    )
                )

            let vennCount =
                ofSetList labels sets
                |> toVennCountLabelArr

            let xAxis =
                LinearAxis.init(ShowTickLabels = false, ShowGrid = false, ZeroLine = false)

            // anchor the y-axis to the x-axis at a 1:1 pixel-per-unit ratio so the circle shapes
            // render as actual circles rather than being stretched to fill the plot area
            let yAxis =
                LinearAxis.init(
                    ShowTickLabels = false,
                    ShowGrid = false,
                    ZeroLine = false,
                    ScaleAnchor = StyleParam.ScaleAnchor.X 1,
                    ScaleRatio = 1.
                )

            // single-set regions are annotated with their label and count: "<label><br><count>"
            let singleText =
                vennCount
                |> Array.filter (fun (label, _) -> label.Length = 1)
                |> Array.map (fun (label, count) -> sprintf "%s<br>%i" label.[0] count)

            // builds the final chart from the per-arm geometry, default colors and intersection annotations
            let buildChart
                (circlePositions: {| X0: float; Y0: float; X1: float; Y1: float |}[])
                (textX: float[])
                (textY: float[])
                (defaultColors: Color[])
                (intersectionText: string[]) =

                let colors = Colors |> Option.map Array.ofSeq |> Option.defaultValue defaultColors

                let shapes =
                    Array.zip circlePositions colors
                    |> Array.map (fun (p, color) -> initCircleShape p.X0 p.Y0 p.X1 p.Y1 color)

                let layout =
                    Layout.init(
                        Shapes = shapes,
                        Margin = Margin.init(Left = 20, Right = 20, Bottom = 100)
                    )
                    |> Layout.updateLinearAxisById(StyleParam.SubPlotId.XAxis 1, xAxis)
                    |> Layout.updateLinearAxisById(StyleParam.SubPlotId.YAxis 1, yAxis)

                Trace2D.initScatter(
                    Trace2DStyle.Scatter(
                        X = textX,
                        Y = textY,
                        Mode = StyleParam.Mode.Text,
                        MultiText = Array.append singleText intersectionText,
                        TextFont = textFont
                    )
                )
                |> GenericChart.ofTraceObject useDefaults
                |> Chart.withLayout layout

            match Set3 with
            | None ->
                let intersectionText =
                    vennCount
                    |> Array.filter (fun (label, _) -> label.Length > 1)
                    |> Array.map (fun (_, count) -> string count)

                buildChart
                    [|
                        {| X0 = 0.;  Y0 = 0.; X1 = 2.;  Y1 = 2. |}
                        {| X0 = 1.5; Y0 = 0.; X1 = 3.5; Y1 = 2. |}
                    |]
                    [| 1.; 2.5; 1.75 |]
                    [| 1.; 1.; 1. |]
                    [| Color.fromKeyword Blue; Color.fromKeyword Red |]
                    intersectionText
            | Some _ ->
                let intersectionText =
                    let singleLabels =
                        vennCount
                        |> Array.filter (fun (label, _) -> label.Length = 1)
                        |> Array.collect fst

                    let multipleLabels =
                        vennCount
                        |> Array.filter (fun (label, _) -> label.Length > 1)

                    // true when a region is the pairwise intersection of exactly the two given single sets
                    let isPairwiseOf i1 i2 (label: string[]) =
                        label.Length = 2
                        && Array.contains singleLabels.[i1] label
                        && Array.contains singleLabels.[i2] label

                    // ordering must match the text positions below: A∩B, A∩C, B∩C, then A∩B∩C
                    [|
                        multipleLabels |> Array.filter (fun (label, _) -> isPairwiseOf 0 1 label)
                        multipleLabels |> Array.filter (fun (label, _) -> isPairwiseOf 0 2 label)
                        multipleLabels |> Array.filter (fun (label, _) -> isPairwiseOf 1 2 label)
                        multipleLabels |> Array.filter (fun (label, _) -> label.Length = 3)
                    |]
                    |> Array.concat
                    |> Array.map (fun (_, count) -> string count)

                buildChart
                    [|
                        {| X0 = 0.;   Y0 = 0.;  X1 = 2.;   Y1 = 2. |}
                        {| X0 = 1.5;  Y0 = 0.;  X1 = 3.5;  Y1 = 2. |}
                        {| X0 = 0.75; Y0 = 1.3; X1 = 2.75; Y1 = 3.3 |}
                    |]
                    [| 1.; 2.5; 1.75; 1.75; 1.325; 2.125; 1.75 |]
                    [| 1.; 1.; 2.25; 1.; 1.6625; 1.6625; 1.45 |]
                    [| Color.fromKeyword Blue; Color.fromKeyword Red; Color.fromKeyword Green |]
                    intersectionText

        /// <summary>
        /// Creates an UpSet plot visualizing the intersections between an arbitrary number of sets.
        ///
        /// An UpSet plot consists of an intersection matrix (which sets take part in each intersection), a bar chart of intersection sizes, a bar chart of the individual set sizes, and optionally additional per-intersection feature plots.
        ///
        /// Each input array is interpreted as a set: duplicate entries are ignored.
        /// </summary>
        /// <param name="labels">Sets the labels of the compared sets, in the order they are drawn on the matrix' y-axis.</param>
        /// <param name="sets">Sets the members of each compared set, aligned with `labels`. Duplicate entries within a set are ignored.</param>
        /// <param name="SetData">Sets per-set maps from a set member to an associated feature value, used together with `SetDataChartsTitle` to draw additional feature plots above each intersection.</param>
        /// <param name="SetDataChartsTitle">Sets the charting function and title for each additional feature plot, aligned with `SetData`.</param>
        /// <param name="MarkerSize">Sets the size of the markers in the intersection matrix. Defaults to 25.</param>
        /// <param name="MainColor">Sets the main color used for the bars and for sets present in an intersection. Defaults to dark blue.</param>
        /// <param name="SecondaryColor">Sets the color used for sets that are not present in an intersection. Defaults to light blue.</param>
        /// <param name="DomainSet">Sets the x-axis domain of the set size bar chart. Defaults to (0., 0.2).</param>
        /// <param name="DomainIntersection">Sets the x-axis domain of the intersection matrix and intersection size charts. Defaults to (0.3, 1.).</param>
        /// <param name="TextFont">Sets the font used for the axis titles. Defaults to Arial, size 20.</param>
        /// <param name="TextFontLabel">Sets the font used for the set labels on the intersection matrix. Defaults to Arial, size 20.</param>
        /// <param name="MinIntersectionSize">Sets the minimum number of members an intersection must contain to be drawn. Defaults to 5.</param>
        /// <param name="SortIntersectionsBy">Sets the function used to order the drawn intersections. Defaults to descending intersection size.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member UpSet
            (
                labels: #seq<string>,
                sets: #seq<#seq<string>>,
                ?SetData: #seq<Map<string, 'b>>,
                ?SetDataChartsTitle: #seq<(array<'b> -> GenericChart) * string>,
                ?MarkerSize: int,
                ?MainColor: Color,
                ?SecondaryColor: Color,
                ?DomainSet: float * float,
                ?DomainIntersection: float * float,
                ?TextFont: Font,
                ?TextFontLabel: Font,
                ?MinIntersectionSize: int,
                ?SortIntersectionsBy: (string list * Set<string>)[] -> (string list * Set<string>)[],
                ?UseDefaults: bool
            ) =
            let useDefaults = defaultArg UseDefaults true
            let setData = SetData |> Option.map Array.ofSeq |> Option.defaultValue Array.empty
            let setDataChartsTitle = SetDataChartsTitle |> Option.map Array.ofSeq |> Option.defaultValue Array.empty
            let markerSize = MarkerSize |> Option.defaultValue 25
            let mainColor = MainColor |> Option.defaultValue (Color.fromKeyword DarkBlue)
            let secondaryColor = SecondaryColor |> Option.defaultValue (Color.fromKeyword LightBlue)
            let domainSet = DomainSet |> Option.defaultValue (0., 0.2)
            let domainIntersection = DomainIntersection |> Option.defaultValue (0.3, 1.)
            let textFont = TextFont |> Option.defaultValue (Font.init(StyleParam.FontFamily.Arial, Size = 20.))
            let textFontLabel = TextFontLabel |> Option.defaultValue (Font.init(StyleParam.FontFamily.Arial, Size = 20.))
            let minIntersectionSize = MinIntersectionSize |> Option.defaultValue 5
            let sortIntersectionsBy = SortIntersectionsBy |> Option.defaultValue (Array.sortByDescending (snd >> Set.count))

            // the public API takes plain string sequences for interop; internally they are treated as sets
            let labels = labels |> Array.ofSeq
            let sets = sets |> Seq.map Set.ofSeq |> Array.ofSeq

            let labelIDs =
                labels
                |> Array.mapi (fun i label -> label, i)
            let venn =
                ofSetList labels sets
                |> Map.toArray
                |> Array.map (fun (_, labelSet) -> labelSet.Label, labelSet.Set)
                |> Array.filter (fun (id, s) -> not id.IsEmpty && s.Count >= minIntersectionSize)
                |> sortIntersectionsBy
            let vennCount =
                venn
                |> Array.map (fun (id, set) -> id, set.Count)
            let maxX = float vennCount.Length - 0.5
            let maxY = float labels.Length - 0.5
            let intersectionData =
                setData
                |> Array.map (alignIntersectionData venn)
            let intersectionDataCharts =
                let charts =
                    intersectionData
                    |> Array.map2 (fun (chartFun, title) sD ->
                        createIntersectionDataPlots sD title maxX chartFun domainIntersection textFont
                    ) setDataChartsTitle
                let emptyCharts =
                    [| 0 .. setData.Length - 1 |]
                    |> Array.map (fun _ -> Chart.Invisible())
                combineArrayAlternating emptyCharts charts
            let intersectionPlot =
                vennCount
                |> Array.mapi (fun position (intersectingSets, _) ->
                    createIntersectionPlotPart useDefaults position intersectingSets labelIDs markerSize mainColor secondaryColor
                )
                |> Chart.combine
                |> Chart.withYAxis(createLinearAxisWithRangeTickLabel maxY labels textFontLabel)
                |> Chart.withXAxis(createLinearAxisWithRangeDomain maxX domainIntersection)
                |> Chart.withTraceInfo(ShowLegend = false)
            let setSizePlot = createSetSizePlot useDefaults labels sets maxY mainColor domainSet textFont
            let intersectionSizePlot = createIntersectionSizePlots useDefaults vennCount maxX mainColor domainIntersection textFont
            let grid =
                Array.append
                    intersectionDataCharts
                    [|
                        Chart.Invisible()
                        intersectionSizePlot
                        setSizePlot
                        intersectionPlot
                    |]
                |> Chart.Grid(2 + setData.Length, 2)
            grid
