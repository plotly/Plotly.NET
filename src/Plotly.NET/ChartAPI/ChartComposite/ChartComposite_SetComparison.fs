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

    /// A single region of a Venn diagram: the labels of the sets it belongs to, together with its members.
    type internal VennSet<'a when 'a: comparison> = {
        Label: string list
        Set: Set<'a>
    }

    /// A generic venn, mapping each region id to its corresponding set of members.
    type internal GenericVenn<'a when 'a: comparison> = Map<string, VennSet<'a>>

    /// Converts a label list to a string id by concatenating the labels with "&".
    let internal labelToId (label: string list) = label |> String.concat "&"

    /// Generates a generic venn from an array of labeled sets.
    let internal ofSetList (labels: string[]) (sets: Set<'a>[]) =
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
    let internal toVennCountLabelArr (genericVenn: GenericVenn<'a>) =
        genericVenn
        |> Seq.map (fun kv -> kv.Value.Label |> Array.ofList, kv.Value.Set.Count)
        |> Array.ofSeq

    /// Initializes the circle shape used to draw a single venn set.
    let internal initCircleShape x0 y0 x1 y1 color =
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

    [<Extension>]
    type Chart =

        /// <summary>
        /// Creates a Venn diagram comparing two or three sets.
        ///
        /// The size of each circle is fixed; the diagram annotates each region (single sets and their intersections) with the number of members it contains.
        /// </summary>
        /// <param name="set1">Sets the first set to compare.</param>
        /// <param name="set2">Sets the second set to compare.</param>
        /// <param name="Set3">Sets an optional third set to compare. If omitted, a two-set diagram is created.</param>
        /// <param name="Label1">Sets the label of the first set. Defaults to "Set 1".</param>
        /// <param name="Label2">Sets the label of the second set. Defaults to "Set 2".</param>
        /// <param name="Label3">Sets the label of the third set. Defaults to "Set 3". Ignored when no third set is given.</param>
        /// <param name="Colors">Sets the fill colors of the circle shapes, one per set.</param>
        /// <param name="TextFont">Sets the font used for the region count annotations.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Venn
            (
                set1: Set<'a>,
                set2: Set<'a>,
                ?Set3: Set<'a>,
                ?Label1: string,
                ?Label2: string,
                ?Label3: string,
                ?Colors: Color[],
                ?TextFont: Font,
                ?UseDefaults: bool
            ) =
            let useDefaults = defaultArg UseDefaults true

            let labels, sets =
                match Set3 with
                | Some set3 ->
                    [| defaultArg Label1 "Set 1"; defaultArg Label2 "Set 2"; defaultArg Label3 "Set 3" |],
                    [| set1; set2; set3 |]
                | None ->
                    [| defaultArg Label1 "Set 1"; defaultArg Label2 "Set 2" |],
                    [| set1; set2 |]

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

                let colors = Colors |> Option.defaultValue defaultColors

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
