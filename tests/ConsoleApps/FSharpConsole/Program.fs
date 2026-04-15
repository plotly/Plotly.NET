open Plotly.NET

[<EntryPoint>]
let main _ =

    let chartHeatmapEncodedRootPoC =
        Chart.Heatmap(
            zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 4.0; 2.0; 5.0; 3.0; 6.0 |], shape = [ 2; 3 ]),
            xEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 100.0; 200.0 |],
            Name = "encoded heatmap root",
            ReverseYAxis = true,
            UseDefaults = true
        )
        |> Chart.withTitle "Heatmap: encoded matrix at chart root"

    chartHeatmapEncodedRootPoC |> Chart.show

    0
