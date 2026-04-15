open Plotly.NET

[<EntryPoint>]
let main _ =

    let chartTreemapEncodedRootPoC =
        Chart.Treemap(
            labelsEncoded = EncodedTypedArray.ofInt32Array [| 0; 1; 2; 3 |],
            parentsEncoded = EncodedTypedArray.ofInt32Array [| -1; 0; 0; 1 |],
            valuesEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 50.0; 30.0; 20.0 |],
            Name = "encoded treemap root",
            UseDefaults = true
        )
        |> Chart.withTitle "Treemap: encoded hierarchy arrays at chart root"

    chartTreemapEncodedRootPoC |> Chart.show

    0
