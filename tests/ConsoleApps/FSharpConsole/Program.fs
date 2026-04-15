open Plotly.NET

[<EntryPoint>]
let main _ =

    let chartSplomEncodedRootPoC =
        Chart.Splom(
            keyValuesEncoded = [
                "Feature A", EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0; 4.0 |]
                "Feature B", EncodedTypedArray.ofFloat64Array [| 4.0; 1.5; 3.5; 2.0 |]
                "Feature C", EncodedTypedArray.ofFloat64Array [| 2.5; 3.0; 1.0; 4.5 |]
            ],
            Name = "encoded splom root",
            ShowLowerHalf = false,
            UseDefaults = true
        )
        |> Chart.withTitle "SPLOM: encoded dimensions at chart root"

    chartSplomEncodedRootPoC |> Chart.show

    0
